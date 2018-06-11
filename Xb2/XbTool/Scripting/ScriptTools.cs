namespace XbTool.Scripting
{
    public static class ScriptTools
    {
        public static void DescrambleScript(DataBuffer script)
        {
            script.GuessEndianness32(8, x => x > 0 && x < 100000);

            var flags = script.ReadUInt8(6);
            if ((flags & 2) == 0) return;

            int idPoolOffset = script.ReadInt32(0xC, true);
            int intPoolOffset = script.ReadInt32();
            int stringPoolOffset = script.ReadInt32(0x18, true);
            int functionPoolOffset = script.ReadInt32();

            int idTableOffset = script.ReadInt32(idPoolOffset, true);
            int idCount = script.ReadInt32();
            int idSize = script.ReadInt32();

            int stringTableOffset = script.ReadInt32(stringPoolOffset, true);
            int stringCount = script.ReadInt32();
            int stringSize = script.ReadInt32();

            int idStringOffset = idPoolOffset + idTableOffset + idCount * idSize;
            int idStringLength = intPoolOffset - idStringOffset;

            int stringDataOffset = stringPoolOffset + stringTableOffset + stringCount * stringSize;
            int stringDataLength = functionPoolOffset - stringDataOffset;

            DescrambleSection(script.Slice(idStringOffset, idStringLength));
            DescrambleSection(script.Slice(stringDataOffset, stringDataLength));

            flags &= unchecked((byte)~2);
            script.WriteUInt8(flags, 6);
        }

        private static void DescrambleSection(DataBuffer data)
        {
            var originalEndianness = data.Endianness;
            data.Endianness = Endianness.Big;

            for (int i = 0; i < data.Length / 4; i++)
            {
                uint scr = data.ReadUInt32(i * 4);
                scr = RotateRight(scr, 2);
                data.WriteUInt32(scr, i * 4);
            }

            data.Endianness = originalEndianness;
        }

        private static uint RotateRight(uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }
    }
}
