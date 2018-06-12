using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotNet.Globbing;
using Ionic.Zlib;

namespace XbTool
{
    public class FileArchive : IDisposable, IFileReader
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
        private long Length { get; set; }

        private FileStream Stream { get; }

        public FileArchive(string headerFilename, string dataFilename)
        {
            var headerFile = File.ReadAllBytes(headerFilename);
            DecryptArh(headerFile);

            using (var stream = new MemoryStream(headerFile))
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

            Stream = new FileStream(dataFilename, FileMode.Open, FileAccess.Read);
            Length = Stream.Length;
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

        public FileInfo[] GetChildFileInfos(string path)
        {
            var fileInfos = new List<FileInfo>();
            foreach (var file in FileInfo)
            {
                if (file.Filename != null && file.Filename.StartsWith(path))
                {
                    fileInfos.Add(file);
                }
            }

            return fileInfos.ToArray();
        }

        public IEnumerable<string> FindFiles(string pattern)
        {
            Glob glob = Glob.Parse(pattern,
                new GlobOptions {Evaluation = new EvaluationOptions {CaseInsensitive = true}});
            var fileInfos = new List<string>();
            foreach (var file in FileInfo)
            {
                if (file.Filename != null && glob.IsMatch(file.Filename))
                {
                    fileInfos.Add(file.Filename);
                }
            }

            return fileInfos;
        }

        public bool Exists(string filename)
        {
            return GetFileInfo(filename) != null;
        }

        public byte[] ReadFile(string filename)
        {
            return ReadFile(GetFileInfo(filename));
        }

        public byte[] ReadFile(FileInfo fileInfo)
        {
            if (fileInfo.Offset + fileInfo.CompressedSize > Length) return null;

            int fileSize = fileInfo.Type == 2 ? fileInfo.UncompressedSize : fileInfo.CompressedSize;
            var output = new byte[fileSize];
            OutputFile(fileInfo, new MemoryStream(output));

            return output;
        }

        public void OutputFile(FileInfo fileInfo, Stream outStream)
        {
            OutputFile(fileInfo, Stream, outStream);
        }

        private void OutputFile(FileInfo fileInfo, Stream input, Stream output)
        {
            input.Position = fileInfo.Offset;

            switch (fileInfo.Type)
            {
                case 2:
                    input.Position += 0x30;

                    using (var deflate = new ZlibStream(input, CompressionMode.Decompress, true))
                    {
                        deflate.CopyTo(output, fileInfo.UncompressedSize);
                    }
                    break;
                case 0:
                    input.CopyStream(output, fileInfo.CompressedSize);
                    break;
            }
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
            var curNode = Nodes[cur];
            var nameSuffix = Stuff.GetUTF8Z(StringTable, -curNode.Next);
            var chars = new List<char>(nameSuffix.Reverse());

            while (curNode.Next != 0)
            {
                int prev = curNode.Prev;
                var prevNode = Nodes[prev];
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

        public static void Extract(FileArchive archive, string outDir)
        {
            foreach (FileInfo fileInfo in archive.FileInfo.Where(x => !string.IsNullOrWhiteSpace(x.Filename)))
            {
                string filename = Path.Combine(outDir, fileInfo.Filename.TrimStart('/'));
                string dir = Path.GetDirectoryName(filename) ?? throw new InvalidOperationException();
                Directory.CreateDirectory(dir);

                using (var outStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    archive.OutputFile(fileInfo, outStream);
                }
            }
        }

        private class Node
        {
            public int Next { get; set; }
            public int Prev { get; set; }
        }

        public void Dispose()
        {
            Stream?.Dispose();
        }
    }

    public class FileInfo
    {
        public FileInfo(BinaryReader reader)
        {
            Offset = reader.ReadInt64();
            CompressedSize = reader.ReadInt32();
            UncompressedSize = reader.ReadInt32();
            Type = reader.ReadInt32();
            Id = reader.ReadInt32();
        }

        public string Filename { get; set; }
        public long Offset { get; }
        public int CompressedSize { get; }
        public int UncompressedSize { get; }
        public int Type { get; }
        public int Id { get; }
    }
}
