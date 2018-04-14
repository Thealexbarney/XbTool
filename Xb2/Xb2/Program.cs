using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Bdat;
using Xb2.BdatString;
using Xb2.CodeGen;
using Xb2.Scripting;
using Xb2.Serialization;
using Xb2.Textures;
using Xb2.Types;

namespace Xb2
{
    public static class Program
    {
        private static void ExtractArchive(string arhFilename, string ardFilename, string outDir)
        {
            using (var archive = new FileArchive(arhFilename, ardFilename))
            {
                FileArchive.Extract(archive, outDir);
            }
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

        private static void RunClassGen(string arhFilename, string ardFilename, string csDir)
        {
            BdatTables bdats;
            using (var archive = new FileArchive(arhFilename, ardFilename))
            {
                bdats = new BdatTables(archive);
            }

            SerializationCode.CreateFiles(bdats, csDir);
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
            var files = new List<byte[]>();

            using (var archive = new FileArchive(arhFilename, ardFilename))
            {
                files.Add(archive.ReadFile("/bdat/common.bdat"));
                files.Add(archive.ReadFile("/bdat/common_gmk.bdat"));
                foreach (var file in archive.GetChildFileInfos("/bdat/gb/"))
                {
                    byte[] bdat = archive.ReadFile(file);
                    if (bdat == null) continue;
                    files.Add(bdat);
                }
            }

            BdatCollection tables = Deserialize.ReadBdats(files.ToArray());
            return tables;
        }


        private static void BdatToHtmlArchive(string arhFilename, string ardFilename, string htmlDir)
        {
            var watch = Stopwatch.StartNew();
            BdatTables bdats;
            using (var archive = new FileArchive(arhFilename, ardFilename))
            {
                bdats = new BdatTables(archive);
            }

            watch.PrintAndRestart();
            BdatStringCollection tables = DeserializeStrings.DeserializeTables(bdats);

            watch.PrintAndRestart();
            Metadata.ApplyMetadata(tables);

            watch.PrintAndRestart();
            HtmlGen.PrintSeparateTables(tables, htmlDir);

            watch.PrintAndRestart();
        }

        public static void PrintAndRestart(this Stopwatch watch)
        {
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
            watch.Restart();
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
            using (var archive = new FileArchive(arhFilename, ardFilename))
            {
                Extract.ExtractTextures(archive, inPath, outPath);
            }
        }

        private static void DescrambleScript(string filename)
        {
            byte[] script = File.ReadAllBytes(filename);
            ScriptTools.DescrambleScript(script);
            var s = new Script(script);

            File.WriteAllLines(filename + ".txt", s.Ids.Strings);
            File.WriteAllBytes(filename, script);
        }

        private static void DescrambleScript(string directory, string pattern)
        {
            string[] filenames = Directory.GetFiles(directory, pattern);
            foreach (string filename in filenames)
            {
                DescrambleScript(filename);
            }
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
                case "decryptbdat" when args.Length == 2:
                    DecryptBdatFile(args[1]);
                    break;
                case "decryptbdat" when args.Length == 3:
                    DecryptBdatFiles(args[1], args[2]);
                    break;
                case "classgen" when args.Length == 4:
                    RunClassGen(args[1], args[2], args[3]);
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
                case "descramblescript" when args.Length == 2:
                    DescrambleScript(args[1]);
                    break;
                case "descramblescript" when args.Length == 3:
                    DescrambleScript(args[1], args[2]);
                    break;
                default:
                    PrintUsage();
                    break;
            }
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Xb2 extract <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 decryptbdat <bdat filename>");
            Console.WriteLine("Xb2 decryptbdat <directory> <search pattern>");
            Console.WriteLine("Xb2 bdat2html <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 generatedata <arh filename> <ard filename> <out dir>");
            Console.WriteLine("Xb2 createblade <arh filename> <ard filename>");
            Console.WriteLine("Xb2 wilay <arh filename> <ard filename> <wilay dir> <out dir>");
            Console.WriteLine("Xb2 descramblescript <script filename>");
            Console.WriteLine("Xb2 descramblescript <directory> <search pattern>");
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
