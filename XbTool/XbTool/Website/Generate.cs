﻿using LibHac;
using LibHac.Fs;
using System.IO;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.Gimmick;
using XbTool.Salvaging;
using XbTool.Serialization;
using XbTool.Types;
using XbTool.Xb2;

namespace XbTool.Website
{
    public static class Generate
    {
        private const string BdatDir = "bdat";
        private const string JsonDir = "json";
        private const string DataDir = "data";
        private const string GmkDir = "gimmick";

        public static void GenerateSite(IFileSystem fs, string outDir, IProgressReport progress)
        {
            Directory.CreateDirectory(outDir);
            GenerateBdatHtml(fs, outDir, progress);
        }

        public static void GenerateBdatHtml(IFileSystem fs, string outDir, IProgressReport progress)
        {
            var bdats = new BdatTables(fs, true, progress);
            BdatStringCollection tablesStr = DeserializeStrings.DeserializeTables(bdats, progress);
            Metadata.ApplyMetadata(tablesStr);
            HtmlGen.PrintSeparateTables(tablesStr, Path.Combine(outDir, BdatDir), progress);
            JsonGen.PrintAllTables(tablesStr, Path.Combine(outDir, JsonDir), progress);

            BdatCollection tables = Deserialize.DeserializeTables(bdats, progress);

            string dataDir = Path.Combine(outDir, DataDir);
            progress.SetTotal(0);
            progress.LogMessage("Creating salvaging tables");
            Directory.CreateDirectory(dataDir);
            string salvaging = SalvagingTable.Print(tables);
            File.WriteAllText(Path.Combine(dataDir, "salvaging.html"), salvaging);

            progress.LogMessage("Creating enemy tables");
            using (var writer = new StreamWriter(Path.Combine(dataDir, "enemies.csv")))
            {
                Enemies.PrintEnemies(tables, writer);
            }

            progress.LogMessage("Creating achievement tables");
            using (var writer = new StreamWriter(Path.Combine(dataDir, "achievements.csv")))
            {
                Achievements.PrintAchievements(tables, writer);
            }

            string gmkDir = Path.Combine(outDir, GmkDir);
            MapInfo[] gimmicks = ReadGmk.ReadAll(fs, tables, progress);
            progress.LogMessage("Writing map info and gimmick data");
            ExportMap.ExportCsv(gimmicks, gmkDir);
        }
    }
}
