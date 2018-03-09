using System.Collections.Generic;
using System.IO;
using System.Text;
using Ionic.Zlib;

namespace Xb2
{
    public static class ArdExtract
    {
        public static ArhFile ReadArhFile(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                return new ArhFile(reader);
            }
        }

        public static void ExtractArdFile(string filename, ArhFile arh, string outDir)
        {
            var names = new HashSet<string>();
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                foreach (FsEntry fsEntry in arh.FileTable)
                {
                    var ard = new ArdEntry(fsEntry, reader);
                    if (!ard.Exists) continue;
                    Directory.CreateDirectory(outDir);

                    string outName = ard.Filename;

                    if (names.Contains(outName))
                    {
                        int i = 2;

                        while (names.Contains(outName))
                        {
                            outName = ard.Filename + $"_{i}";
                            i++;
                        }
                    }

                    names.Add(outName);
                    string outPath = Path.Combine(outDir, outName);

                    using (var outStream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                    {
                        ard.OutputFile(stream, outStream);
                    }
                }
            }
        }
    }

    public class ArdEntry
    {
        public ArdEntry(FsEntry file, BinaryReader reader)
        {
            File = file;
            if (file.Offset + file.CompressedSize > reader.BaseStream.Length) return;
            Exists = true;
            reader.BaseStream.Position = file.Offset;

            if (file.Type == 2)
            {
                Magic = reader.ReadUInt32();
                Unk4 = reader.ReadInt32();
                UncompressedSize = reader.ReadInt32();
                CompressedSize = reader.ReadInt32();
                Hash = reader.ReadUInt32();
                Filename = file.Id.ToString("D4") + " - " + Encoding.UTF8.GetString(reader.ReadBytes(28), 0, 28).TrimEnd('\0');
            }
            else if (file.Type == 0)
            {
                CompressedSize = file.CompressedSize;
                Filename = file.Id.ToString("D4");
            }
        }

        public void OutputFile(Stream input, Stream output)
        {
            if (!Exists) return;

            input.Position = File.Offset;

            switch (File.Type)
            {
                case 2:
                    input.Position += 0x30;

                    using (var deflate = new ZlibStream(input, CompressionMode.Decompress, true))
                    {
                        deflate.CopyTo(output, UncompressedSize);
                    }
                    break;
                case 0:
                    input.CopyStream(output, CompressedSize);
                    break;
            }
        }

        public FsEntry File;
        public bool Exists;
        public uint Magic;
        public int Unk4;
        public int CompressedSize;
        public int UncompressedSize;
        public uint Hash;
        public string Filename;
    }

    public class FsEntry
    {
        public void ReadTable1(BinaryReader reader)
        {
            Filename = reader.ReadUTF8Z();
            Id = reader.ReadInt32();
        }

        public void ReadTable3(BinaryReader reader)
        {
            Offset = reader.ReadInt64();
            CompressedSize = reader.ReadInt32();
            UncompressedSize = reader.ReadInt32();
            Type = reader.ReadInt32();
            Id = reader.ReadInt32();
        }

        public string Filename;
        public long Offset;
        public int CompressedSize;
        public int UncompressedSize;
        public int Type;
        public int Id;
    }

    public class ArhFile
    {
        public ArhFile(BinaryReader reader)
        {
            Magic = reader.ReadUInt32();
            Unk4 = reader.ReadInt32();
            Unk8 = reader.ReadInt32();
            Table1Offset = reader.ReadInt32();
            Table1Length = reader.ReadInt32();
            Table2Offset = reader.ReadInt32();
            Table2Length = reader.ReadInt32();
            FileTableOffset = reader.ReadInt32();
            EntryCount = reader.ReadInt32();
            Unk24 = reader.ReadUInt32();

            FileTable = new FsEntry[EntryCount];

            reader.BaseStream.Position = Table1Offset + 4;

            for (int i = 0; i < EntryCount; i++)
            {
                FileTable[i] = new FsEntry();
                FileTable[i].ReadTable1(reader);
            }


            reader.BaseStream.Position = FileTableOffset;

            for (int i = 0; i < EntryCount; i++)
            {
                FileTable[i].ReadTable3(reader);
            }
        }

        public uint Magic;
        public int Unk4;
        public int Unk8;
        public int Table1Offset;
        public int Table1Length;
        public int Table2Offset;
        public int Table2Length;
        public int FileTableOffset;
        public int EntryCount;
        public uint Unk24;

        public FsEntry[] FileTable;
    }
}
