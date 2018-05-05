namespace Xb2.Save
{
    public class SDataSave
    {
        public SDataSystem SystemSave;
        public SDataGame GameSave;

        public SDataSave(DataBuffer save)
        {
            SystemSave = new SDataSystem(save);
            GameSave = new SDataGame(save.Slice(0x10));
        }
    }

    public class SDataSystem
    {
        public uint Magic;
        public RealTime SaveTime;

        public SDataSystem(DataBuffer save)
        {
            Magic = save.ReadUInt32(0);
            SaveTime = new RealTime(save.ReadUInt64(8));
        }
    }

    public class RealTime
    {
        public int Millisecond;
        public int Second;
        public int Minute;
        public int Hour;
        public int Day;
        public int Month;
        public int Year;

        public RealTime(ulong time)
        {
            Millisecond = (int)(time >> 6 & ((1u << 10) - 1));
            Second = (int)(time >> 16 & ((1u << 6) - 1));
            Minute = (int)(time >> 22 & ((1u << 6) - 1));
            Hour = (int)(time >> 28 & ((1u << 5) - 1));
            Day = (int)(time >> 33 & ((1u << 5) - 1));
            Month = (int)(time >> 47 & ((1u << 4) - 1));
            Year = (int)(time >> 51);
        }
    }
}
