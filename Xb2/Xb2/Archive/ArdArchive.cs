using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xb2.Archive
{
    public class ArdArchive
    {
        private Node[] Nodes { get; }
        public FsEntry[] FileInfo { get; }
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

        public ArdArchive(byte[] arh)
        {
            DecryptArh(arh);

            using (var stream = new MemoryStream(arh))
            using (BinaryReader reader = new BinaryReader(stream))
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

                FileInfo = new FsEntry[FileCount];
                stream.Position = FileTableOffset;

                for (int i = 0; i < FileCount; i++)
                {
                    FileInfo[i] = new FsEntry(reader);
                }

                AddAllFilenames();
            }
        }

        public FsEntry GetFile(string filename)
        {
            int cur = 0;
            Node curNode = Nodes[cur];

            for (int i = 0; i < filename.Length; i++)
            {
                if (curNode.Next < 0) break;

                int next = curNode.Next ^ filename[i];
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

        private class Node
        {
            public int Next { get; set; }
            public int Prev { get; set; }
        }
    }

    public class FsEntry
    {
        public FsEntry(BinaryReader reader)
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
