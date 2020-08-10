using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zlib;
using LibHac;
using LibHac.Common;
using LibHac.Fs;
using LibHac.FsSystem;
using LibHac.FsSystem.RomFs;

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
        public HierarchicalRomFileTable<RomFileInfo> FileTable { get; }

        public ArchiveFileSystem(IFile headerFile, IFile dataFile)
        {
            headerFile.GetSize(out long size);
            var header = new byte[size];
            headerFile.Read(out long bytesRead, 0, header);

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

            FileTable = new HierarchicalRomFileTable<RomFileInfo>();
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

        public Result CreateFile(U8Span path, long size, CreateFileOptions options) => throw new NotSupportedException();
        public Result DeleteFile(U8Span path) => throw new NotSupportedException();
        public Result CreateDirectory(U8Span path) => throw new NotSupportedException();
        public Result DeleteDirectory(U8Span path) => throw new NotSupportedException();
        public Result DeleteDirectoryRecursively(U8Span path) => throw new NotSupportedException();
        public Result CleanDirectoryRecursively(U8Span path) => throw new NotSupportedException();
        public Result RenameFile(U8Span oldPath, U8Span newPath) => throw new NotSupportedException();
        public Result RenameDirectory(U8Span oldPath, U8Span newPath) => throw new NotSupportedException();

        public Result GetEntryType(out DirectoryEntryType entryType, U8Span path)
        {
            string normPath = PathTools.Normalize(path.ToString()).ToLowerInvariant();
            if (FileTable.TryOpenFile(normPath, out RomFileInfo _))
            {
                entryType = DirectoryEntryType.File;
                return Result.Success;
            }
            if (FileTable.TryOpenDirectory(normPath, out FindPosition _))
            {
                entryType = DirectoryEntryType.Directory;
                return Result.Success;
            }

            entryType = DirectoryEntryType.Directory;
            return ResultFs.PathNotFound.Log();
        }

        public Result GetFreeSpaceSize(out long freeSpace, U8Span path) => throw new NotSupportedException();

        public Result GetTotalSpaceSize(out long totalSpace, U8Span path) => throw new NotSupportedException();

        public Result OpenFile(out IFile file, U8Span path, OpenMode mode)
        {
            string normPath = PathTools.Normalize(path.ToString()).ToLowerInvariant();

            if (!FileTable.TryOpenFile(normPath, out RomFileInfo romFileInfo))
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
                    file = new ArchiveFile(decompData, OpenMode.Read);
                    return Result.Success;
                case 0:
                    file = new ArchiveFile(DataFile, fileInfo.Offset, fileInfo.CompressedSize);
                    return Result.Success;
                default:
                    throw new InvalidDataException();
            }
        }

        public Result OpenDirectory(out IDirectory directory, U8Span path, OpenDirectoryMode mode)
        {
            string normPath = PathTools.Normalize(path.ToString()).ToLowerInvariant();

            if (!FileTable.TryOpenDirectory(normPath, out FindPosition position))
            {
                throw new DirectoryNotFoundException();
            }
            directory = new ArchiveDirectory(this, path.ToString(), position, mode);
            return Result.Success;
        }

        Result IFileSystem.Commit() => Result.Success;
        public Result CommitProvisionally(long commitCount) => Result.Success;
        public Result Rollback() => Result.Success;
        public Result Flush() => Result.Success;
        public Result GetFileTimeStampRaw(out FileTimeStampRaw timeStamp, U8Span path) => throw new NotSupportedException();
        public Result QueryEntry(Span<byte> outBuffer, ReadOnlySpan<byte> inBuffer, QueryId queryId, U8Span path) => throw new NotSupportedException();
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
