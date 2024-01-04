﻿using LibHac;
using XbTool.Common;

namespace XbTool
{
    public class Options
    {
        public Game Game { get; set; }
        public Task Task { get; set; }
        public string ArdFilename { get; set; }
        public string ArhFilename { get; set; }
        public string BdatDir { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string Filter { get; set; }
        public string Xb2Dir { get; set; }
        public string SdPath { get; set; }
        public IProgressReport Progress { get; set; }
    }

    public enum Task
    {
        ExtractArchive = 1,
        DecryptBdat,
        BdatCodeGen,
        Bdat2Html,
        Bdat2Json,
        Bdat2Psql,
        GenerateData,
        CreateBlade,
        ExtractWilay,
        DescrambleScript,
        SalvageRaffle,
        ReadSave,
        DecompressIraSave,
        CombineBdat,
        ReadGimmick,
        ReadScript,
        DecodeCatex,
        ExtractMinimap,
        GenerateSite,
        ExportQuests,
        ReplaceArchive,
        SdPrintTest,
        GenerateDropTables
    }
}
