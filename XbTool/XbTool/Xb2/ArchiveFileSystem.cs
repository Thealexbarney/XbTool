using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zlib;
using LibHac.IO;
using LibHac.IO.RomFs;

namespace XbTool.Xb2
{
    public class ArchiveFileSystem : IFileSystem
    {
        private Node[] Nodes { get; }
        public FileInfo[] FileInfo { get; }
        public byte[] StringTable { get; }
        public int Field4 { get; }
        public int NodeCount { get; }
        public int StringTableOffset { get; }
        public int StringTableLength { get; }
        public int NodeTableOffset { get; }
        public int NodeTableLength { get; }
        public int FileTableOffset { get; }
        public int FileCount { get; }
        public uint Key { get; }

        private IStorage DataFile { get; }
        public HierarchicalRomFileTable FileTable { get; }

        public ArchiveFileSystem(IFile headerFile, IFile dataFile)
        {
            var header = new byte[headerFile.GetSize()];
            headerFile.Read(header, 0);

            DecryptArh(header);

            using (var stream = new MemoryStream(header))
            using (var reader = new BinaryReader(stream))
            {
                stream.Position = 4;
                Field4 = reader.ReadInt32();
                NodeCount = reader.ReadInt32();
                StringTableOffset = reader.ReadInt32();
                StringTableLength = reader.ReadInt32();
                NodeTableOffset = reader.ReadInt32();
                NodeTableLength = reader.ReadInt32();
                FileTableOffset = reader.ReadInt32();
                FileCount = reader.ReadInt32();
                Key = reader.ReadUInt32() ^ 0xF3F35353;

                stream.Position = StringTableOffset;
                StringTable = reader.ReadBytes(StringTableLength);

                Nodes = new Node[NodeCount];
                stream.Position = NodeTableOffset;

                for (int i = 0; i < NodeCount; i++)
                {
                    Nodes[i] = new Node
                    {
                        Next = reader.ReadInt32(),
                        Prev = reader.ReadInt32()
                    };
                }

                FileInfo = new FileInfo[FileCount];
                stream.Position = FileTableOffset;

                for (int i = 0; i < FileCount; i++)
                {
                    FileInfo[i] = new FileInfo(reader);
                }

                AddAllFilenames();
            }

            DataFile = dataFile.AsStorage();

            FileTable = new HierarchicalRomFileTable();
            var romFileInfo = new RomFileInfo();

            File.WriteAllLines("archive.txt", FileInfo.Select(x => x.Filename));

            for (int i = 0; i < FileInfo.Length; i++)
            {
                if (FileInfo[i].Filename == null) continue;

                romFileInfo.Offset = i;
                FileTable.AddFile(FileInfo[i].Filename, ref romFileInfo);
            }

            FileTable.TrimExcess();
        }

        public IDirectory OpenDirectory(string path, OpenDirectoryMode mode)
        {
            path = PathTools.Normalize(path).ToLowerInvariant();

            if (!FileTable.TryOpenDirectory(path, out FindPosition position))
            {
                throw new DirectoryNotFoundException();
            }

            return new ArchiveDirectory(this, path, position, mode);
        }

        public IFile OpenFile(string path, OpenMode mode)
        {
            path = PathTools.Normalize(path).ToLowerInvariant();

            if (!FileTable.TryOpenFile(path, out RomFileInfo romFileInfo))
            {
                throw new FileNotFoundException();
            }

            FileInfo fileInfo = FileInfo[romFileInfo.Offset];

            switch (fileInfo.Type)
            {
                case 2:
                    var decompData = new byte[fileInfo.UncompressedSize];
                    Stream compStream = DataFile.Slice(fileInfo.Offset + 0x30, fileInfo.CompressedSize).AsStream();

                    using (var deflate = new ZlibStream(compStream, CompressionMode.Decompress, true))
                    {
                        deflate.CopyTo(new MemoryStream(decompData), fileInfo.UncompressedSize);
                    }

                    return new ArchiveFile(decompData, OpenMode.Read);
                case 0:
                    return new ArchiveFile(DataFile, fileInfo.Offset, fileInfo.CompressedSize);
                default:
                    throw new InvalidDataException();
            }
        }

        public bool DirectoryExists(string path)
        {
            path = PathTools.Normalize(path).ToLowerInvariant();

            return FileTable.TryOpenDirectory(path, out FindPosition _);
        }

        public bool FileExists(string path)
        {
            path = PathTools.Normalize(path).ToLowerInvariant();

            return FileTable.TryOpenFile(path, out RomFileInfo _);
        }

        public DirectoryEntryType GetEntryType(string path)
        {
            path = PathTools.Normalize(path).ToLowerInvariant();

            if (FileExists(path)) return DirectoryEntryType.File;
            if (DirectoryExists(path)) return DirectoryEntryType.Directory;

            throw new FileNotFoundException(path);
        }

        public void Commit() { }

        private void AddAllFilenames()
        {
            for (int i = 0; i < Nodes.Length; i++)
            {
                if (Nodes[i].Next >= 0 || Nodes[i].Prev < 0) continue;

                int offset = -Nodes[i].Next;
                while (StringTable[offset] != 0)
                {
                    offset++;
                }
                offset++; // Skip null byte

                int fileId = BitConverter.ToInt32(StringTable, offset);
                FileInfo[fileId].Filename = GetStringFromEndNode(i);
            }
        }

        private string GetStringFromEndNode(int endNodeIdx)
        {
            int cur = endNodeIdx;
            Node curNode = Nodes[cur];
            string nameSuffix = Stuff.GetUTF8Z(StringTable, -curNode.Next);
            var chars = new List<char>(nameSuffix.Reverse());

            while (curNode.Next != 0)
            {
                int prev = curNode.Prev;
                Node prevNode = Nodes[prev];
                chars.Add((char)(cur ^ prevNode.Next));
                cur = prev;
                curNode = prevNode;
            }

            chars.Reverse();
            return new string(chars.ToArray());
        }

        public static void DecryptArh(byte[] file)
        {
            var filei = new int[file.Length / 4];
            Buffer.BlockCopy(file, 0, filei, 0, file.Length);

            int key = (int)(filei[9] ^ 0xF3F35353);
            filei[9] = unchecked((int)0xF3F35353);

            int stringTableStart = filei[3] / 4;
            int nodeTableStart = filei[5] / 4;
            int stringTableEnd = stringTableStart + filei[4] / 4;
            int nodeTableEnd = nodeTableStart + filei[6] / 4;

            for (int i = stringTableStart; i < stringTableEnd; i++)
            {
                filei[i] ^= key;
            }

            for (int i = nodeTableStart; i < nodeTableEnd; i++)
            {
                filei[i] ^= key;
            }

            Buffer.BlockCopy(filei, 0, file, 0, file.Length);
        }

        public FileInfo GetFileInfo(string filename)
        {
            int cur = 0;
            Node curNode = Nodes[cur];

            for (int i = 0; i < filename.Length; i++)
            {
                if (curNode.Next < 0) break;

                int next = curNode.Next ^ char.ToLower(filename[i]);
                Node nextNode = Nodes[next];
                if (nextNode.Prev != cur) return null;
                cur = next;
                curNode = nextNode;
            }

            int offset = -curNode.Next;
            while (StringTable[offset] != 0)
            {
                offset++;
            }
            offset++;

            int fileId = BitConverter.ToInt32(StringTable, offset);
            return FileInfo[fileId];
        }

        private class Node
        {
            public int Next { get; set; }
            public int Prev { get; set; }
        }

        public void CreateDirectory(string path) => throw new NotSupportedException();
        public void CreateFile(string path, long size, CreateFileOptions options) => throw new NotSupportedException();
        public void DeleteDirectory(string path) => throw new NotSupportedException();
        public void DeleteFile(string path) => throw new NotSupportedException();
        public void RenameDirectory(string srcPath, string dstPath) => throw new NotSupportedException();
        public void RenameFile(string srcPath, string dstPath) => throw new NotSupportedException();
    }
}
