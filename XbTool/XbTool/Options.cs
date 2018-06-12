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
    }

    public enum Task
    {
        ExtractArchive = 1,
        DecryptBdat,
        BdatCodeGen,
        Bdat2Html,
        Bdat2Json,
        GenerateData,
        CreateBlade,
        ExtractWilay,
        DescrambleScript,
        SalvageRaffle,
        ReadSave,
        CombineBdat,
        ReadGimmick,
        ReadScript
    }
}
