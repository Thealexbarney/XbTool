using System;
using System.Linq;

namespace XbTool.Bdat
{
    public static class BdatTools
    {
        public static void DecryptBdat(DataBuffer file)
        {
            int tableCount = file.ReadInt32(0);

            for (int i = 0; i < tableCount; i++)
            {
                int offset = file.ReadInt32(8 + 4 * i);

                DataBuffer table = file.Slice(offset, file.Length - offset);

                DecryptTable(table);
            }
        }

        public static void DecryptTable(DataBuffer table)
        {
            if (table.ReadUTF8(0, 4) != "BDAT") return;
            if ((table[4] & 2) == 0) return;

            int namesOffset = table.ReadUInt16(6);
            int hashTableOffset = table.ReadUInt16(10);
            ushort checksum = table.ReadUInt16(22);
            int stringsOffset = table.ReadInt32(24);
            int stringsLength = table.ReadInt32(28);

            DecryptSection(table.File, checksum, table.Start + namesOffset, hashTableOffset - namesOffset);
            DecryptSection(table.File, checksum, table.Start + stringsOffset, stringsLength);

            table[4] &= unchecked((byte)~2);
        }

        public static void DecryptSection(byte[] data, ushort checksum, int start, int length)
        {
            int end = start + length;
            byte keyA = (byte)(~checksum >> 8);
            byte keyB = (byte)~checksum;

            for (int i = start; i < end; i += 2)
            {
                byte dataA = data[i];
                byte dataB = data[i + 1];

                data[i] ^= keyA;
                data[i + 1] ^= keyB;

                keyA += dataA;
                keyB += dataB;
            }
        }

        public static int HashString(string value)
        {
            int length = Math.Min(value.Length, 8);
            int r = 0;

            for (int i = 0; i < length; i++)
            {
                r = value[i] + 7 * r;
            }

            return r;
        }

        public static int GetHashOffset(string value, int hashTableSize)
        {
            var r = HashString(value);
            return r - r / hashTableSize * hashTableSize;
        }

        public static ushort CalcBdatTableChecksum(DataBuffer table)
        {
            int stringsOffset = table.ReadInt32(24);
            int stringsLength = table.ReadInt32(28);

            int end = stringsOffset + stringsLength;
            ushort checksum = 0;

            for (int i = 32; i < end; i++)
            {
                checksum += (byte)(table[i] << (i & 3));
            }

            return checksum;
        }

        public static byte[] Combine(BdatTable[] tables)
        {
            int count = tables.Length;
            int headerLength = 8 + count * 4;
            int bodyLength = tables.Sum(x => x.Data.Length);
            int length = headerLength + bodyLength;

            var combined = new byte[length];
            var buffer = new DataBuffer(combined, Game.XB2, 0);
            buffer.WriteInt32(count);
            buffer.WriteInt32(length);

            int offset = headerLength;
            foreach (BdatTable table in tables)
            {
                buffer.WriteInt32(offset);
                offset += table.Data.Length;
            }

            foreach (BdatTable table in tables)
            {
                buffer.WriteBytes(table.Data.ToArray());
            }

            return combined;
        }
    }

    public enum BdatMemberType
    {
        None = 0,
        Scalar = 1,
        Array = 2,
        Flag = 3
    }

    public enum BdatValueType
    {
        None = 0,
        UInt8 = 1,
        UInt16 = 2,
        UInt32 = 3,
        Int8 = 4,
        Int16 = 5,
        Int32 = 6,
        String = 7,
        FP32 = 8
    }
}
