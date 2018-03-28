using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Bdat;
using Xb2.BdatString;
using Xb2.CodeGen;
using Xb2.Serialization;
using Xb2.Textures;
using Xb2.Types;

namespace Xb2
{
    public static class Program
    {
        private static void ExtractArchive(string arhFilename, string ardFilename, string outDir)
        {
            var arh = File.ReadAllBytes(arhFilename);
            var archive = new FileArchive(arh, ardFilename);
            FileArchive.Extract(archive, outDir);
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

        private static BdatCollection DeserializeBdatArchive(string arhFilename, string ardFilename)
        {
            var header = File.ReadAllBytes(arhFilename);
            var archive = new FileArchive(header, ardFilename);

            var files = new List<byte[]>();

            files.Add(archive.ReadFile("/bdat/common.bdat"));
            files.Add(archive.ReadFile("/bdat/common_gmk.bdat"));
            foreach (var file in archive.GetChildFileInfos("/bdat/gb/"))
            {
                byte[] bdat = archive.ReadFile(file);
                if (bdat == null) continue;
                files.Add(bdat);
            }

            BdatCollection tables = Deserialize.ReadBdats(files.ToArray());
            return tables;
        }

        private static BdatStringCollection DeserializeBdatStringArchive(string arhFilename, string ardFilename)
        {
            var header = File.ReadAllBytes(arhFilename);
            var archive = new FileArchive(header, ardFilename);

            var files = new List<byte[]>();
            var fileNames = new List<string>();

            files.Add(archive.ReadFile("/bdat/common.bdat"));
            fileNames.Add(Path.GetFileNameWithoutExtension("common.bdat"));
            files.Add(archive.ReadFile("/bdat/common_gmk.bdat"));
            fileNames.Add(Path.GetFileNameWithoutExtension("common_gmk.bdat"));
            foreach (var file in archive.GetChildFileInfos("/bdat/gb/"))
            {
                byte[] bdat = archive.ReadFile(file);
                if (bdat == null) continue;
                files.Add(bdat);
                fileNames.Add(Path.GetFileNameWithoutExtension(file.Filename));
            }

            BdatStringCollection tables = DeserializeStrings.ReadBdats(files.ToArray(), fileNames.ToArray());
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

        private static void BdatToHtmlArchive(string arhFilename, string ardFilename, string htmlDir)
        {
            var watch = Stopwatch.StartNew();
            BdatStringCollection tables = DeserializeBdatStringArchive(arhFilename, ardFilename);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);

            BdatInfo info = BdatInfoImport.GetBdatInfo(tables);
            BdatStringTools.ProcessReferences(tables, info);

            watch.Restart();
            HtmlGen.OutputHtml(tables, info, htmlDir);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
        }

        public static void PrintData(BdatCollection tables, string dataDir)
        {
            Directory.CreateDirectory(dataDir);

            using (var writer = new StreamWriter(Path.Combine(dataDir, "achievements.csv")))
            {
                Achievements.PrintAchievements(tables, writer);
            }
        }

        public static void ReadWilay(string arhFilename, string ardFilename, string inPath, string outPath)
        {
            byte[] header = File.ReadAllBytes(arhFilename);
            var archive = new FileArchive(header, ardFilename);
            Extract.ExtractTextures(archive, inPath, outPath);
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
                    ExtractArchive(args[1], args[2], args[3]);
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
                case "bdat2html" when args.Length == 4:
                    BdatToHtmlArchive(args[1], args[2], args[3]);
                    break;
                case "generatedatabdat" when args.Length == 4:
                    var tables = DeserializeBdat(args[1], args[2]);
                    PrintData(tables, args[3]);
                    break;
                case "generatedata" when args.Length == 4:
                    var tablesArd = DeserializeBdatArchive(args[1], args[2]);
                    PrintData(tablesArd, args[3]);
                    break;
                case "createblade" when args.Length == 3:
                    var tablesCb = DeserializeBdatArchive(args[1], args[2]);
                    CreateBlade.Run.PromptCreate(tablesCb);
                    break;
                case "wilay" when args.Length == 5:
                    ReadWilay(args[1], args[2], args[3], args[4]);
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
            Console.WriteLine("Xb2 bdat2html <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 generatedata <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 createblade <arh filename> <ard filename>");
            Console.WriteLine("Xb2 wilay <arh filename> <ard filename> <wilay dir> <out dir>");
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

        public static T ChooseRandom<T>(this IEnumerable<T> source, Random rand)
        {
            T[] arr = source.ToArray();
            return arr[rand.Next(arr.Length)];
        }

        public static T ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<int> probabilities)
        {
            T[] arr = source.ToArray();
            int[] probs = probabilities as int[] ?? probabilities.ToArray();

            var randVal = rand.NextDouble() * probs.Sum();
            float sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal)
                {
                    return arr[i];
                }
            }

            return default(T);
        }

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<byte> probabilities, int count) =>
            source.ChooseRandom(rand, probabilities.Select(x => (int)x), count);

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<int> probabilities, int count)
        {
            T[] arr = source as T[] ?? source.ToArray();
            int[] probs = probabilities as int[] ?? probabilities.ToArray();

            if (arr.Length < count)
                throw new ArgumentOutOfRangeException(nameof(count),
                    $"There are fewer than {count} elements in {nameof(source)}");

            var chosen = new HashSet<T>();
            while (chosen.Count < count)
            {
                chosen.Add(arr.ChooseRandom(rand, probs));
            }

            return chosen.ToArray();
        }

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, int count)
        {
            T[] arr = source.ToArray();
            if (arr.Length < count)
                throw new ArgumentOutOfRangeException(nameof(count),
                    $"There are fewer than {count} elements in {nameof(source)}");

            var chosen = new HashSet<T>();
            while (chosen.Count < count)
            {
                chosen.Add(arr[rand.Next(arr.Length)]);
            }

            return chosen.ToArray();
        }
    }
}
