using System;
using System.IO;
using System.Reflection;

namespace XbTool
{
    internal static class CliArguments
    {
        public static Options Parse(string[] args)
        {
            var options = new Options();

            for (int i = 0; i < args.Length; i++)
            {
                if (string.IsNullOrEmpty(args[i])) continue;

                if (args[i][0] == '-' || args[i][0] == '/')
                {
                    switch (args[i].Split(':')[0].Substring(1).ToUpper())
                    {
                        case "G":
                        case "-GAME":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -g switch.");
                                return null;
                            }

                            if (!Enum.TryParse(args[i + 1], true, out Game game))
                            {
                                PrintWithUsage("Specified game is invalid.");
                                return null;
                            }

                            options.Game = game;
                            i++;
                            continue;
                        case "T":
                        case "-TASK":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -t switch.");
                                return null;
                            }

                            if (!Enum.TryParse(args[i + 1], true, out Task task))
                            {
                                PrintWithUsage("Specified task is invalid.");
                                return null;
                            }

                            options.Task = task;
                            i++;
                            continue;
                        case "A":
                        case "-ARCHIVE":
                            if (i + 2 >= args.Length)
                            {
                                PrintWithUsage("2 arguments after the -a switch are required.");
                                return null;
                            }

                            options.ArhFilename = args[i + 1];
                            options.ArdFilename = args[i + 2];
                            i += 2;
                            continue;
                        case "B":
                        case "-Bdats":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -b switch.");
                                return null;
                            }

                            options.BdatDir = args[i + 1];
                            i++;
                            continue;
                        case "I":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -i switch.");
                                return null;
                            }

                            options.Input = args[i + 1];
                            i++;
                            continue;
                        case "O":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -o switch.");
                                return null;
                            }

                            options.Output = args[i + 1];
                            i++;
                            continue;
                        case "F":
                        case "-FILTER":
                            if (i + 1 >= args.Length)
                            {
                                PrintWithUsage("No argument after -f switch.");
                                return null;
                            }

                            options.Filter = args[i + 1];
                            i++;
                            continue;
                    }
                }

                PrintWithUsage($"Unknown parameter: {args[i]}");
                return null;
            }

            if (!ValidateArguments(options)) return null;

            return options;
        }

        private static bool ValidateArguments(Options options)
        {
            if (options.Game == 0)
            {
                PrintWithUsage("Game must be specified");
                return false;
            }

            if (options.Task == 0)
            {
                PrintWithUsage("Task must be specified");
                return false;
            }

            return true;
        }

        private static void PrintWithUsage(string toPrint)
        {
            Console.WriteLine(toPrint);
            PrintUsage();
        }

        private static void PrintUsage()
        {
            Console.WriteLine($"Usage: {GetProgramName()} options");
            Console.WriteLine("\nRequired Arguments:");
            Console.WriteLine("  -g, --game <game>  Game the input data is from (xb1 | xbx | xb2)");
            Console.WriteLine("  -t, --task <task>  Task to perform");

            Console.WriteLine("\nOther Options:");
            Console.WriteLine("  -a, --archive <arh> <ard>   Input Xenoblade 2 archive file");
            Console.WriteLine("  -b, --bdat <path>           Directory to load BDAT files from");
            Console.WriteLine("  -i <path>                   Input file or directory");
            Console.WriteLine("  -o <path>                   Output file or directory");
            Console.WriteLine("  -f, --filter <pattern>      Search pattern to use when reading a directory");
            Console.WriteLine("                              Usable whenever inputting a directory");

            Console.WriteLine("\nTasks:");
            Console.WriteLine("  ExtractArchive - Extracts Xenoblade 2's file archive");
            Console.WriteLine("    ExtractArchive -a <archive> -o <output_path>");

            Console.WriteLine("\n  DecryptBdat - Decrypts a BDAT file or directory");
            Console.WriteLine("    DecryptBdat -i <input_file> [-o <output_file>]");
            Console.WriteLine("    DecryptBdat -i <input_dir>");

            Console.WriteLine("\n  BdatCodeGen - Generates code for deserializing BDAT files");
            Console.WriteLine("    BdatCodeGen (-a <archive> | -b <bdat_dir>) -o <output_dir>");

            Console.WriteLine("\n  Bdat2Html - Generates HTML tables from BDAT files");
            Console.WriteLine("    Bdat2Html (-a <archive> | -b <bdat_dir>) -o <output_dir>");

            Console.WriteLine("\n  Bdat2Json - Generates JSON files from BDAT files");
            Console.WriteLine("    Bdat2Json (-a <archive> | -b <bdat_dir>) -o <output_dir>");

            Console.WriteLine("\n  GenerateData - Generates various data from BDAT files");
            Console.WriteLine("    GenerateData (-a <archive> | -b <bdat_dir>) -o <output_dir>");

            Console.WriteLine("\n  DescrambleScript - Descrambles a .sb script file or directory");
            Console.WriteLine("    DescrambleScript -i <input_file> [-o <output_file>]");
            Console.WriteLine("    DescrambleScript -i <input_dir>");

            Console.WriteLine("\n  ExtractWilay - Extracts textures from .wilay files");
            Console.WriteLine("                 When reading from an archive, -i specifies the");
            Console.WriteLine("                 directory in the archive to search e.g. /menu/image");
            Console.WriteLine("    ExtractWilay -i <input_path> -o <output_dir>");
            Console.WriteLine("    ExtractWilay -a <archive> [-i <input_path>] -o <output_dir>");

            Console.WriteLine("\n  CreateBlade - Runs the Xenoblade 2 common blade generator");
            Console.WriteLine("    CreateBlade (-a <archive> | -b <bdat_input_dir>)");

            Console.WriteLine("\n  ReadSave - XB2 save file reading example");
            Console.WriteLine("             Outputs common blade information");
            Console.WriteLine("    ReadSave (-a <archive> | -b <bdat_input_dir>) -i <save_file> -o <out_text_file>");
        }

        private static string GetProgramName() => Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly()?.Location ?? "");
    }
}
