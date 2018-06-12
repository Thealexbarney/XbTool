using System;
using System.IO;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.CodeGen;
using XbTool.CreateBlade;
using XbTool.Gimmick;
using XbTool.Salvaging;
using XbTool.Save;
using XbTool.Scripting;
using XbTool.Serialization;
using XbTool.Types;

namespace XbTool
{
    public static class Tasks
    {
        internal static void RunTask(Options options)
        {
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
                case Task.CombineBdat:
                    CombineBdat(options);
                    break;
                case Task.ReadGimmick:
                    ReadGimmick(options);
                    break;
                case Task.ReadScript:
                    ReadScript(options);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void ExtractArchive(Options options)
        {
            if (options.ArdFilename == null) throw new NullReferenceException("Archive must be specified");

            using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
            {
                FileArchive.Extract(archive, options.Output);
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
                using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
                {
                    return new BdatTables(archive, readMetadata);
                }
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

        private static void Bdat2Html(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            var tables = GetBdatStringCollection(options);
            HtmlGen.PrintSeparateTables(tables, options.Output);
        }

        private static void Bdat2Json(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            var tables = GetBdatStringCollection(options);
            JsonGen.PrintAllTables(tables, options.Output);
        }

        private static void GenerateData(Options options)
        {
            if (options.Output == null) throw new NullReferenceException("Output directory was not specified.");

            var tables = GetBdatCollection(options);

            Directory.CreateDirectory(options.Output);
            var salvaging = SalvagingTable.Print(tables);
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
            var tables = GetBdatCollection(options);
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
                    Textures.Extract.ExtractTextures(archive, input, options.Output);
                }
            }
            else
            {
                if (File.Exists(options.Input))
                {
                    Textures.Extract.ExtractTextures(new[] { options.Input }, options.Output);
                }

                if (Directory.Exists(options.Input))
                {
                    string pattern = options.Filter ?? "*";
                    string[] filenames = Directory.GetFiles(options.Input, pattern);
                    Textures.Extract.ExtractTextures(filenames, options.Output);
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
            var tables = GetBdatCollection(options);
            RunRaffle.Run(tables);
        }

        private static void ReadSave(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            byte[] saveFile = File.ReadAllBytes(options.Input);
            SDataSave saveData = Read.ReadSave(saveFile);
            var newSave = Write.WriteSave(saveData);
            File.WriteAllBytes(options.Input + "_new.sav", newSave);

            BdatCollection tables = GetBdatCollection(options);
            string printout = Print.PrintSave(saveData, tables);
            File.WriteAllText(options.Output, printout);
        }

        private static void CombineBdat(Options options)
        {
            //if (options.Input == null) throw new NullReferenceException("No input file was specified.");
            if (options.Output == null) throw new NullReferenceException("No output file was specified.");

            var tables = ReadBdatTables(options, false).Tables;
            var combined = BdatTools.Combine(tables);
            File.WriteAllBytes(options.Output, combined);
        }

        private static void ReadGimmick(Options options)
        {
            using (var archive = new FileArchive(options.ArhFilename, options.ArdFilename))
            {
                if (options.ArdFilename == null) throw new NullReferenceException("Archive must be specified");
                if (options.Output == null) throw new NullReferenceException("No output file was specified.");

                BdatCollection tables = GetBdatCollection(options);

                var gimmicks = ReadGmk.ReadAll(archive, tables);
                ExportMap.ExportCsv(gimmicks, options.Output);

                ExportMap.Export(archive, gimmicks, options.Output);
            }
        }

        private static void ReadScript(Options options)
        {
            if (options.Input == null) throw new NullReferenceException("No input directory was specified.");
            if (options.Output == null) throw new NullReferenceException("No output directory was specified.");

            var files = Directory.GetFiles(options.Input, "*.sb", SearchOption.AllDirectories);
            Directory.CreateDirectory(options.Output);

            using (var progress = new ProgressBar())
            {
                progress.SetTotal(files.Length);
                foreach (var name in files)
                {
                    var file = File.ReadAllBytes(name);
                    var script = new Script(new DataBuffer(file, options.Game, 0));
                    var dump = Export.PrintScript(script);
                    var relativePath = Helpers.GetRelativePath(name, options.Input);

                    var output = Path.ChangeExtension(Path.Combine(options.Output, relativePath), "txt");
                    Directory.CreateDirectory(Path.GetDirectoryName(output) ?? "");
                    File.WriteAllText(output, dump);
                    progress.ReportAdd(1);
                }
            }
        }
    }
}
