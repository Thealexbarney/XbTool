using System;
using System.IO;
using System.Linq;
using LibHac.IO;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.CodeGen;
using XbTool.Common;
using XbTool.Common.Textures;
using XbTool.CreateBlade;
using XbTool.Gimmick;
using XbTool.Salvaging;
using XbTool.Save;
using XbTool.Scripting;
using XbTool.Serialization;
using XbTool.Types;
using XbTool.Xb2;

namespace XbTool
{
    public static class Tasks
    {
        internal static void RunTask(Options options)
        {
            using (var progress = new ProgressBar())
            {
                options.Progress = progress;
                switch (options.Task)
                {
                    case Task.ExtractArchive:
                        ExtractArchive(options);
                        break;
                    case Task.DecryptBdat:
                        DecryptBdat(options);
                        break;
                    case Task.BdatCodeGen:
                        BdatCodeGen(options);
                        break;
                    case Task.Bdat2Html:
                        Bdat2Html(options);
                        break;
                    case Task.Bdat2Json:
                        Bdat2Json(options);
                        break;
                    case Task.Bdat2Psql:
                        Bdat2Psql(options);
                        break;
                    case Task.GenerateData:
                        GenerateData(options);
                        break;
                    case Task.CreateBlade:
                        CreateBlade(options);
                        break;
                    case Task.ExtractWilay:
                        ExtractWilay(options);
                        break;
                    case Task.DescrambleScript:
                        DescrambleScript(options);
                        break;
                    case Task.SalvageRaffle:
                        SalvageRaffle(options);
                        break;
                    case Task.ReadSave:
                        ReadSave(options);
                        break;
                    case Task.DecompressIraSave:
                        DecompressSave(options);
                        break;
                    case Task.CombineBdat:
                        CombineBdat(options);
                        break;
                    case Task.ReadGimmick:
                        ReadGimmick(options);
                        break;
                    case Task.ReadScript:
                        ReadScript(options);
                        break;
                    case Task.DecodeCatex:
                        DecodeCatex(options);
                        break;
                    case Task.ExtractMinimap:
                        ExtractMinimap(options);
                        break;
                    case Task.GenerateSite:
                        GenerateSite(options);
                        break;
                    case Task.ExportQuests:
                        ExportQuests(options);
                        break;
                    case Task.ReplaceArchive:
                        ReplaceArchive(options);
                        break;
                    case Task.SdPrintTest:
                        SdPrintTest(options);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void ExtractArchive(Options options)
        {
            if (options.ArdFilename == null) throw new NullReferenceException("Archive must be specified");

            using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
            {
                FileArchive.Extract(archive, options.Output, options.Progress);
            }
        }

        private static void ReplaceArchive(Options options)
        {
            if (options.ArdFilename == null) throw new NullReferenceException("Archive must be specified");
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
            {
                byte[] replacement = File.ReadAllBytes(options.Input);
                archive.ReplaceFile(options.Output, replacement);
            }
        }

        private static void DecryptBdat(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");

            if (File.Exists(options.Input))
            {
                string output = options.Output ?? options.Input;
                DecryptFile(options.Input, output);
            }

            if (Directory.Exists(options.Input))
            {
                string pattern = options.Filter ?? "*";
                string[] filenames = Directory.GetFiles(options.Input, pattern);
                foreach (string filename in filenames)
                {
                    DecryptFile(filename, filename);
                }
            }

            void DecryptFile(string input, string output)
            {
                var bdat = new DataBuffer(File.ReadAllBytes(input), options.Game, 0);
                BdatTools.DecryptBdat(bdat);
                File.WriteAllBytes(output, bdat.File);
                Console.WriteLine("Finished decrypting");
            }
        }

        private static void BdatCodeGen(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output file was not specified.");

            BdatTables bdats = ReadBdatTables(options, true);
            SerializationCode.CreateFiles(bdats, options.Output);
        }

        private static BdatTables ReadBdatTables(Options options, bool readMetadata)
        {
            if (options.Game == Game.XB2 && options.ArdFilename != null)
            {
                using (var headerFile = new LocalFile(options.ArhFilename, OpenMode.Read))
                using (var dataFile = new LocalFile(options.ArdFilename, OpenMode.Read))
                {
                    var archive = new ArchiveFileSystem(headerFile, dataFile);
                    return new BdatTables(archive, readMetadata);
                }
            }

            if (options.Game == Game.XB2 && options.SdPath != null)
            {
                var archive = new Xb2FileSystem(options.SdPath);
                return new BdatTables(archive, readMetadata);
            }

            string pattern = options.Filter ?? "*";
            string[] filenames = Directory.GetFiles(options.BdatDir, pattern);
            return new BdatTables(filenames, options.Game, readMetadata);
        }

        private static BdatStringCollection GetBdatStringCollection(Options options)
        {
            BdatTables bdats = ReadBdatTables(options, true);
            BdatStringCollection tables = DeserializeStrings.DeserializeTables(bdats);
            Metadata.ApplyMetadata(tables);
            return tables;
        }

        public static BdatCollection GetBdatCollection(Options options)
        {
            BdatTables bdats = ReadBdatTables(options, false);
            BdatCollection tables = Deserialize.DeserializeTables(bdats);
            return tables;
        }

        public static BdatCollection GetBdatCollection(IFileSystem fs, bool readMetadata)
        {
            var bdats = new BdatTables(fs, readMetadata);
            BdatCollection tables = Deserialize.DeserializeTables(bdats);
            return tables;
        }

        private static void Bdat2Html(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            BdatStringCollection tables = GetBdatStringCollection(options);
            HtmlGen.PrintSeparateTables(tables, options.Output, options.Progress);
        }

        private static void Bdat2Json(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            BdatStringCollection tables = GetBdatStringCollection(options);
            JsonGen.PrintAllTables(tables, options.Output, options.Progress);
        }

        private static void Bdat2Psql(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Ouput directory (Schema) was not specified.");

            BdatStringCollection tables = GetBdatStringCollection(options);
            DbGen.PrintAllTables(tables, options.Output, options.Progress);
        }

        private static void GenerateData(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            BdatCollection tables = GetBdatCollection(options);
            Directory.CreateDirectory(options.Output);

            string chBtlRewards = ChBtlRewards.PrintHtml(tables);
            File.WriteAllText(Path.Combine(options.Output, "chbtlrewards.html"), chBtlRewards);

            string chBtlRewardsCsv = ChBtlRewards.PrintCsv(tables);
            File.WriteAllText(Path.Combine(options.Output, "chbtlrewards.csv"), chBtlRewardsCsv);

            string salvaging = SalvagingTable.Print(tables);
            File.WriteAllText(Path.Combine(options.Output, "salvaging.html"), salvaging);

            using (var writer = new StreamWriter(Path.Combine(options.Output, "enemies.csv")))
            {
                Enemies.PrintEnemies(tables, writer);
            }

            using (var writer = new StreamWriter(Path.Combine(options.Output, "achievements.csv")))
            {
                Achievements.PrintAchievements(tables, writer);
            }
        }

        private static void CreateBlade(Options options)
        {
            BdatCollection tables = GetBdatCollection(options);
            Run.PromptCreate(tables);
        }

        private static void ExtractWilay(Options options)
        {
            if (options.Input == null && options.ArdFilename == null) throw new NullReferenceException("Input was not specified.");
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            if (options.ArdFilename != null)
            {
                string input = options.Input ?? "/menu/image/";
                using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
                {
                    Extract.ExtractTextures(archive, input, options.Output, options.Progress);
                }
            }
            else
            {
                if (File.Exists(options.Input))
                {
                    Extract.ExtractTextures(new[] { options.Input }, options.Output, options.Progress);
                }

                if (Directory.Exists(options.Input))
                {
                    string pattern = options.Filter ?? "*";
                    string[] filenames = Directory.GetFiles(options.Input, pattern);
                    Extract.ExtractTextures(filenames, options.Output, options.Progress);
                }
            }
        }

        private static void DescrambleScript(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");

            if (File.Exists(options.Input))
            {
                string output = options.Output ?? options.Input;
                DescrambleFile(options.Input, output);
            }

            if (Directory.Exists(options.Input))
            {
                string pattern = options.Filter ?? "*";
                string[] filenames = Directory.GetFiles(options.Input, pattern);
                foreach (string filename in filenames)
                {
                    DescrambleFile(filename, filename);
                }
            }

            void DescrambleFile(string input, string output)
            {
                var script = new DataBuffer(File.ReadAllBytes(input), options.Game, 0);
                ScriptTools.DescrambleScript(script);
                File.WriteAllBytes(output, script.ToArray());
            }
        }

        private static void SalvageRaffle(Options options)
        {
            BdatCollection tables = GetBdatCollection(options);
            RunRaffle.Run(tables);
        }

        private static void ReadSave(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            byte[] saveFile = File.ReadAllBytes(options.Input);
            SDataSave saveData = Read.ReadSave(saveFile);
            byte[] newSave = Write.WriteSave(saveData);
            File.WriteAllBytes(options.Input + "_new.sav", newSave);

            BdatCollection tables = GetBdatCollection(options);
            string printout = Print.PrintSave(saveData, tables);
            File.WriteAllText(options.Output, printout);
        }

        private static void DecompressSave(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            byte[] saveFileComp = File.ReadAllBytes(options.Input);
            byte[] saveFileDecomp = Compression.DecompressSave(saveFileComp);
            File.WriteAllBytes(options.Output, saveFileDecomp);
        }

        private static void CombineBdat(Options options)
        {
            //if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            BdatTable[] tables = ReadBdatTables(options, false).Tables;
            byte[] combined = BdatTools.Combine(tables);
            File.WriteAllBytes(options.Output, combined);
        }

        private static void ReadGimmick(Options options)
        {
            if (options.SdPath == null) throw new NullReferenceException("Must specify SD card path.");
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");
            if (!Directory.Exists(options.SdPath)) throw new DirectoryNotFoundException($"{options.SdPath} is not a valid directory.");

            var xb2Fs = new Xb2FileSystem(options.SdPath);

            BdatCollection tables = GetBdatCollection(xb2Fs, false);

            MapInfo[] gimmicks = ReadGmk.ReadAll(xb2Fs, tables);
            ExportMap.ExportCsv(gimmicks, options.Output);

            ExportMap.Export(xb2Fs, gimmicks, options.Output);
        }

        private static void ReadScript(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input directory was specified.");
            if (options.Output == null) throw new NullReferenceException("No output directory was specified.");

            string[] files = Directory.GetFiles(options.Input, "*.sb", SearchOption.AllDirectories);
            Directory.CreateDirectory(options.Output);

            options.Progress.SetTotal(files.Length);
            foreach (string name in files)
            {
                byte[] file = File.ReadAllBytes(name);
                var script = new Script(new DataBuffer(file, options.Game, 0));
                string dump = Export.PrintScript(script);
                string relativePath = Helpers.GetRelativePath(name, options.Input);

                string output = Path.ChangeExtension(Path.Combine(options.Output, relativePath), "txt");
                Directory.CreateDirectory(Path.GetDirectoryName(output) ?? "");
                File.WriteAllText(output, dump);
                options.Progress.ReportAdd(1);
            }
        }

        private static void DecodeCatex(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");

            if (File.Exists(options.Input))
            {
                Xbx.Textures.Extract.ExtractTextures(new[] { options.Input }, options.Output);
            }

            if (Directory.Exists(options.Input))
            {
                string pattern = options.Filter ?? "*";
                string[] filenames = Directory.GetFiles(options.Input, pattern);
                Xbx.Textures.Extract.ExtractTextures(filenames, options.Output);
            }
        }

        private static void ExtractMinimap(Options options)
        {
            if (options.Game != Game.XBX) throw new NotImplementedException("Xenoblade X minimap only.");
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");
            if (!Directory.Exists(options.Input)) throw new DirectoryNotFoundException($"{options.Input} is not a valid directory.");

            Xbx.Textures.Minimap.ExtractMinimap(options.Input, options.Output);
        }

        private static void GenerateSite(Options options)
        {
            if (options.SdPath == null) throw new NullReferenceException("Must specify SD card path.");
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");
            if (!Directory.Exists(options.SdPath)) throw new DirectoryNotFoundException($"{options.SdPath} is not a valid directory.");

            options.Progress.LogMessage("Reading XB2 directories");
            var xb2Fs = new Xb2FileSystem(options.SdPath);

            Website.Generate.GenerateSite(xb2Fs, options.Output, options.Progress);

        }

        private static void ExportQuests(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");

            BdatCollection tables = GetBdatCollection(options);

            Xb2.Quest.Read.ExportQuests(tables, options.Output);
        }

        private static void SdPrintTest(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input path was specified.");
            if (options.Output == null) throw new NullReferenceException("No output path was specified.");

            IFileSystem fs = new Xb2FileSystem(options.Input);
            File.WriteAllLines(options.Output,
                fs.EnumerateEntries().Where(x => x.Type == DirectoryEntryType.File).Select(x => x.FullPath));

            var localFs = new LocalFileSystem("output");
            fs.CopyFileSystem(localFs, options.Progress);
        }
    }
}
