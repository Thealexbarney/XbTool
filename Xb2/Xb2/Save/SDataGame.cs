namespace Xb2.Save
{
    public class SDataGame
    {
        public uint Money;
        public ushort IsTimeStop;
        public SDataDriver[] Drivers = new SDataDriver[16];
        public SDataBlade[] Blades = new SDataBlade[422];
        public short[] CommonBladeIds = new short[192];

        public SDataGame(DataBuffer save)
        {
            Money = save.ReadUInt32(0);
            IsTimeStop = save.ReadUInt16(0x24);

            for (int i = 0; i < Drivers.Length; i++)
            {
                Drivers[i] = new SDataDriver(save.Slice(0x2c + i * 0x5a0, 0x5a0));
            }

            for (int i = 0; i < Blades.Length; i++)
            {
                Blades[i] = new SDataBlade(save.Slice(0x5a2c + i * 0x8a4, 0x8a4));
            }

            save.Position = 0x1099a8;
            for (int i = 0; i < CommonBladeIds.Length; i++)
            {
                CommonBladeIds[i] = save.ReadInt16();
            }
        }
    }
}
