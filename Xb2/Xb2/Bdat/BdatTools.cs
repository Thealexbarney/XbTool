using System;

namespace Xb2.Bdat
{
    public static class BdatTools
    {
        public static void DecryptBdat(byte[] file)
        {
            int tableCount = BitConverter.ToInt32(file, 0);

            for (int i = 0; i < tableCount; i++)
            {
                int offset = BitConverter.ToInt32(file, 8 + 4 * i);
                DecryptTable(file, offset);
            }
        }

        public static void DecryptTable(byte[] file, int offset)
        {
            if (BitConverter.ToUInt32(file, offset) != 0x54414442) return;
            if ((file[4 + offset] & 2) == 0) return;

            int namesOffset = BitConverter.ToUInt16(file, offset + 6) + offset;
            int hashTableOffset = BitConverter.ToUInt16(file, offset + 10) + offset;
            ushort checksum = BitConverter.ToUInt16(file, offset + 22);
            int stringsOffset = BitConverter.ToInt32(file, offset + 24) + offset;
            int stringsLength = BitConverter.ToInt32(file, offset + 28);

            DecryptSection(file, checksum, namesOffset, hashTableOffset - namesOffset);
            DecryptSection(file, checksum, stringsOffset, stringsLength);

            file[4 + offset] &= unchecked((byte)~2);
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

        public static ushort CalcBdatTableChecksum(byte[] file, int offset)
        {
            int stringsOffset = BitConverter.ToInt32(file, offset + 24);
            int stringsLength = BitConverter.ToInt32(file, offset + 28);

            int start = 32 + offset;
            int end = stringsOffset + stringsLength + offset;
            ushort checksum = 0;

            for (int i = start; i < end; i++)
            {
                checksum += (byte)(file[i] << (i & 3));
            }

            return checksum;
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
