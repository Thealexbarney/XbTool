using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Bdat;
using Xb2.BdatString;
using Xb2.CodeGen;
using Xb2.Serialization;
using Xb2.Types;

namespace Xb2
{
    public static class Program
    {
        private static void Extract(string arhFilename, string ardFilename, string outDir)
        {
            ArhFile arhFile = ArdExtract.ReadArhFile(arhFilename);
            ArdExtract.ExtractArdFile(ardFilename, arhFile, outDir);
        }

        private static void DecryptBdatFile(string filename)
        {
            byte[] bdat = File.ReadAllBytes(filename);
            BdatTools.DecryptBdat(bdat);
            File.WriteAllBytes(filename, bdat);
        }

        private static void DecryptBdatFiles(string directory, string pattern)
        {
            string[] filenames = Directory.GetFiles(directory, pattern);
            foreach (string filename in filenames)
            {
                DecryptBdatFile(filename);
            }
        }

        private static void RunClassGen(string bdatDir, string csDir)
        {
            BdatTable[] tables = GetBdatMembers(bdatDir, "*");
            SerializationCode.CreateFiles(tables, csDir);
        }

        // ReSharper disable once UnusedMethodReturnValue.Local
        private static BdatCollection DeserializeBdat(string bdatDir, string pattern)
        {
            string[] filenames = Directory.GetFiles(bdatDir, pattern, SearchOption.AllDirectories);
            byte[][] files = new byte[filenames.Length][];

            for (int i = 0; i < filenames.Length; i++)
            {
                files[i] = File.ReadAllBytes(filenames[i]);
            }

            BdatCollection tables = Deserialize.ReadBdats(files);
            return tables;
        }

        private static BdatStringCollection DeserializeBdatString(string bdatDir, string pattern)
        {
            string[] filenames = Directory.GetFiles(bdatDir, pattern, SearchOption.AllDirectories);
            byte[][] files = new byte[filenames.Length][];

            for (int i = 0; i < filenames.Length; i++)
            {
                files[i] = File.ReadAllBytes(filenames[i]);
            }

            BdatStringCollection tables = DeserializeStrings.ReadBdats(files, filenames);
            return tables;
        }

        private static BdatTable[] GetBdatMembers(string bdatDir, string pattern)
        {
            string[] filenames = Directory.GetFiles(bdatDir, pattern, SearchOption.AllDirectories);
            byte[][] files = new byte[filenames.Length][];
            var tables = new BdatTable[filenames.Length][];

            for (int i = 0; i < filenames.Length; i++)
            {
                files[i] = File.ReadAllBytes(filenames[i]);
                tables[i] = new BdatFile(files[i], filenames[i]).Tables;
            }

            BdatTable[] flat = tables.SelectMany(x => x).ToArray();

            return flat;
        }

        private static void BdatToHtml(string bdatDir, string htmlDir)
        {
            var watch = Stopwatch.StartNew();
            BdatStringCollection tables = DeserializeBdatString(bdatDir, "*");
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);

            BdatInfo info = BdatInfoImport.GetBdatInfo(tables);


            watch.Restart();
            HtmlGen.OutputHtml(tables, info, htmlDir);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
        }

        public static void PrintAchievements(string bdatDir, string pattern)
        {
            var tables = DeserializeBdat(bdatDir, pattern);
            Achievements.PrintAchievements(tables);
        }

        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                PrintUsage();
                return;
            }

            switch (args[0])
            {
                case "extract" when args.Length == 4:
                    Extract(args[1], args[2], args[3]);
                    break;
                case "decrypt" when args.Length == 2:
                    DecryptBdatFile(args[1]);
                    break;
                case "decrypt" when args.Length == 3:
                    DecryptBdatFiles(args[1], args[2]);
                    break;
                case "classgen" when args.Length == 3:
                    RunClassGen(args[1], args[2]);
                    break;
                case "deserializebdat" when args.Length == 3:
                    DeserializeBdat(args[1], args[2]);
                    break;
                case "bdat2html" when args.Length == 3:
                    BdatToHtml(args[1], args[2]);
                    break;
                case "achievements" when args.Length == 3:
                    PrintAchievements(args[1], args[2]);
                    break;
                default:
                    PrintUsage();
                    break;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Xb2 extract <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 decrypt <bdat filename>");
            Console.WriteLine("Xb2 decrypt <directory> <search pattern>");
        }
    }

    public static class Stuff
    {
        public static string ReadUTF8Z(this BinaryReader reader)
        {
            var start = reader.BaseStream.Position;

            // Read until we hit the end of the stream (-1) or a zero
            while (reader.BaseStream.ReadByte() - 1 > 0) { }

            int size = (int)(reader.BaseStream.Position - start - 1);
            reader.BaseStream.Position = start;

            string text = reader.ReadUTF8(size);
            reader.BaseStream.Position++; // Skip the null byte
            return text;
        }

        public static string ReadUTF8(this BinaryReader reader, int size)
        {
            return Encoding.UTF8.GetString(reader.ReadBytes(size), 0, size);
        }

        public static void CopyStream(this Stream input, Stream output, int length)
        {
            int remaining = length;
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, Math.Min(buffer.Length, remaining))) > 0)
            {
                output.Write(buffer, 0, read);
                remaining -= read;
            }
        }

        public static string GetUTF8Z(byte[] value, int offset)
        {
            var length = 0;

            while (value[offset + length] != 0)
            {
                length++;
            }

            return Encoding.UTF8.GetString(value, offset, length);
        }
    }
}
