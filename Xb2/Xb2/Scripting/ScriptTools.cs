using System;

namespace Xb2.Scripting
{
    public static class ScriptTools
    {
        public static void DescrambleScript(byte[] file)
        {
            if ((file[6] & 2) == 0) return;

            int idsOffset = BitConverter.ToInt32(file, 0xC);
            int offset10 = BitConverter.ToInt32(file, 0x10);
            int offset18 = BitConverter.ToInt32(file, 0x18);
            int offset1C = BitConverter.ToInt32(file, 0x1C);

            int idTableOffset = BitConverter.ToInt32(file, idsOffset);
            int idCount = BitConverter.ToInt32(file, idsOffset + 4);
            int idSize = BitConverter.ToInt32(file, idsOffset + 8);

            int arr18TableOffset = BitConverter.ToInt32(file, offset18);
            int arr18Count = BitConverter.ToInt32(file, offset18 + 4);
            int arr18Size = BitConverter.ToInt32(file, offset18 + 8);

            int idStringOffset = idsOffset + idTableOffset + idCount * idSize;
            int idStringLength = offset10 - idStringOffset;

            int arr18DataOffset = offset18 + arr18TableOffset + arr18Count * arr18Size;
            int arr18DataLength = offset1C - arr18DataOffset;

            DescrambleSection(file, idStringOffset, idStringLength);
            DescrambleSection(file, arr18DataOffset, arr18DataLength);

            file[6] &= unchecked((byte)~2);
        }

        private static void DescrambleSection(byte[] data, int offset, int length)
        {
            uint[] temp = new uint[length / 4];
            Buffer.BlockCopy(data, offset, temp, 0, temp.Length * sizeof(uint));

            for (int i = 0; i < temp.Length; i++)
            {
                uint scr = ByteSwap(temp[i]);
                scr = RotateRight(scr, 2);
                temp[i] = ByteSwap(scr);
            }

            Buffer.BlockCopy(temp, 0, data, offset, temp.Length * sizeof(uint));
        }

        private static uint RotateRight(uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }

        private static uint ByteSwap(uint value)
        {
            value = (value >> 16) | (value << 16);
            return ((value & 0xFF00FF00) >> 8) | ((value & 0x00FF00FF) << 8);
        }
    }
}
