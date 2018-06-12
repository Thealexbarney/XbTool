using System;

namespace XbTool
{
    public static class Byte
    {
        public static short ByteSwap(short value) => (short)ByteSwap((ushort)value);
        public static int ByteSwap(int value) => (int)ByteSwap((uint)value);
        public static long ByteSwap(long value) => (long)ByteSwap((ulong)value);

        public static ushort ByteSwap(ushort value)
        {
            return (ushort)((value >> 8) | (value << 8));
        }

        public static uint ByteSwap(uint value)
        {
            value = (value >> 16) | (value << 16);
            return ((value & 0xFF00FF00) >> 8) | ((value & 0x00FF00FF) << 8);
        }

        public static float ByteSwap(float value)
        {
            var a = BitConverter.GetBytes(value);
            byte t = a[0];
            a[0] = a[3];
            a[3] = t;
            t = a[1];
            a[1] = a[2];
            a[2] = t;
            return BitConverter.ToSingle(a, 0);
        }

        public static ulong ByteSwap(ulong value)
        {
            value = (value >> 32) | (value << 32);
            value = ((value & 0xFFFF0000FFFF0000) >> 16) | ((value & 0x0000FFFF0000FFFF) << 16);
            return ((value & 0xFF00FF00FF00FF00) >> 8) | ((value & 0x00FF00FF00FF00FF) << 8);
        }
    }
}
