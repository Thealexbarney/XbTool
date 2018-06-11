using System;
using System.Text;

namespace XbTool
{
    public class DataBuffer
    {
        public Game Game { get; }
        public Endianness Endianness { get; set; }
        public byte[] File { get; }
        public int Start { get; }
        public int Length { get; }
        public int Position { get; set; }

        public byte[] ToArray()
        {
            var arr = new byte[Length];
            Array.Copy(File, Start, arr, 0, Length);
            return arr;
        }

        public DataBuffer(byte[] file, Game game, int start)
        {
            File = file;
            Start = start;
            Game = game;
            Endianness = game == Game.XB2 ? Endianness.Little : Endianness.Big;
            Length = file.Length - start;
        }

        public DataBuffer(byte[] file, Game game, int start, int length)
        {
            File = file;
            Start = start;
            Game = game;
            Endianness = game == Game.XB2 ? Endianness.Little : Endianness.Big;
            Length = length;
        }

        public byte this[int index]
        {
            get => File[Start + index];
            set => File[Start + index] = value;
        }

        public DataBuffer Slice(int start)
        {
            return new DataBuffer(File, Game, Start + start, Length - Start + start);
        }

        public DataBuffer Slice(int start, int length)
        {
            return new DataBuffer(File, Game, Start + start, length);
        }

        public byte ReadUInt8(int index, bool updatePosition = false)
        {
            byte result = File[Start + index];
            if (updatePosition) Position = index + sizeof(byte);
            return result;
        }

        public sbyte ReadInt8(int index, bool updatePosition = false)
        {
            sbyte result = (sbyte)File[Start + index];
            if (updatePosition) Position = index + sizeof(sbyte);
            return result;
        }

        public ushort ReadUInt16(int index, bool updatePosition = false)
        {
            ushort result = BitConverter.ToUInt16(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(ushort);
            return result;
        }

        public short ReadInt16(int index, bool updatePosition = false)
        {
            short result = BitConverter.ToInt16(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(short);
            return result;
        }

        public uint ReadUInt32(int index, bool updatePosition = false)
        {
            uint result = BitConverter.ToUInt32(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(uint);
            return result;
        }

        public int ReadInt32(int index, bool updatePosition = false)
        {
            int result = BitConverter.ToInt32(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(int);
            return result;
        }

        public ulong ReadUInt64(int index, bool updatePosition = false)
        {
            ulong result = BitConverter.ToUInt64(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(ulong);
            return result;
        }

        public long ReadInt64(int index, bool updatePosition = false)
        {
            long result = BitConverter.ToInt64(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(long);
            return result;
        }

        public float ReadSingle(int index, bool updatePosition = false)
        {
            float result = BitConverter.ToSingle(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            if (updatePosition) Position = index + sizeof(float);
            return result;
        }

        public byte[] ReadBytes(int index, int length, bool updatePosition = false)
        {
            byte[] result = new byte[length];
            Array.Copy(File, Start + index, result, 0, length);
            if (updatePosition) Position = index + length;
            return result;
        }

        public string ReadUTF8(int index, int length, bool updatePosition = false)
        {
            string result = Encoding.UTF8.GetString(File, Start + index, length);
            if (updatePosition) Position = index + length;
            return result;
        }

        public string ReadUTF8Z(int index, bool updatePosition = false)
        {
            return ReadUTF8ZLen(index, int.MaxValue, updatePosition);
        }

        public string ReadUTF8ZLen(int index, int maxLength, bool updatePosition = false)
        {
            int end = index;

            while (File[Start + end] != 0 && end - index < maxLength)
            {
                end++;
            }

            return ReadUTF8(index, end - index, updatePosition);
        }

        public string ReadText(string encoding, int index, int length, bool updatePosition = false)
        {
            string result = Encoding.GetEncoding(encoding).GetString(File, Start + index, length);
            if (updatePosition) Position = index + length;
            return result;
        }

        public string ReadTextZ(string encoding, int index, bool updatePosition = false)
        {
            return ReadTextZLen(encoding, index, int.MaxValue, updatePosition);
        }

        public string ReadTextZLen(string encoding, int index, int maxLength, bool updatePosition = false)
        {
            int end = index;

            while (File[Start + end] != 0 && end - index < maxLength)
            {
                end++;
            }

            return ReadText(encoding, index, end - index, updatePosition);
        }

        public byte ReadUInt8() => ReadUInt8(Position, true);
        public sbyte ReadInt8() => ReadInt8(Position, true);
        public ushort ReadUInt16() => ReadUInt16(Position, true);
        public short ReadInt16() => ReadInt16(Position, true);
        public uint ReadUInt32() => ReadUInt32(Position, true);
        public int ReadInt32() => ReadInt32(Position, true);
        public ulong ReadUInt64() => ReadUInt64(Position, true);
        public long ReadInt64() => ReadInt64(Position, true);
        public float ReadSingle() => ReadSingle(Position, true);
        public byte[] ReadBytes(int length) => ReadBytes(Position, length, true);
        public string ReadUTF8(int length) => ReadUTF8(Position, length, true);
        public string ReadUTF8Z() => ReadUTF8Z(Position, true);
        public string ReadUTF8ZLen(int maxLength = int.MaxValue) => ReadUTF8ZLen(Position, maxLength, true);
        public string ReadText(string encoding, int length) => ReadText(encoding, Position, length, true);
        public string ReadTextZ(string encoding) => ReadTextZ(encoding, Position, true);
        public string ReadTextZLen(string encoding, int maxLength = int.MaxValue) => ReadTextZLen(encoding, Position, maxLength, true);

        public void WriteUInt8(byte value, int index, bool updatePosition = false)
        {
            File[Start + index] = value;
            if (updatePosition) Position = index + sizeof(byte);
        }

        public void WriteInt8(sbyte value, int index, bool updatePosition = false)
        {
            File[Start + index] = (byte)value;
            if (updatePosition) Position = index + sizeof(sbyte);
        }

        public void WriteUInt16(ushort value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            if (updatePosition) Position = index + sizeof(ushort);
        }

        public void WriteInt16(short value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            if (updatePosition) Position = index + sizeof(short);
        }

        public void WriteUInt32(uint value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            File[Start + index + 2] = (byte)(value >> (8 * 2));
            File[Start + index + 3] = (byte)(value >> (8 * 3));
            if (updatePosition) Position = index + sizeof(uint);
        }

        public void WriteInt32(int value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            File[Start + index + 2] = (byte)(value >> (8 * 2));
            File[Start + index + 3] = (byte)(value >> (8 * 3));
            if (updatePosition) Position = index + sizeof(int);
        }

        public void WriteUInt64(ulong value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            File[Start + index + 2] = (byte)(value >> (8 * 2));
            File[Start + index + 3] = (byte)(value >> (8 * 3));
            File[Start + index + 4] = (byte)(value >> (8 * 4));
            File[Start + index + 5] = (byte)(value >> (8 * 5));
            File[Start + index + 6] = (byte)(value >> (8 * 6));
            File[Start + index + 7] = (byte)(value >> (8 * 7));
            if (updatePosition) Position = index + sizeof(ulong);
        }

        public void WriteInt64(long value, int index, bool updatePosition = false)
        {
            if (Endianness == Endianness.Big) value = Byte.ByteSwap(value);
            File[Start + index + 0] = (byte)(value >> (8 * 0));
            File[Start + index + 1] = (byte)(value >> (8 * 1));
            File[Start + index + 2] = (byte)(value >> (8 * 2));
            File[Start + index + 3] = (byte)(value >> (8 * 3));
            File[Start + index + 4] = (byte)(value >> (8 * 4));
            File[Start + index + 5] = (byte)(value >> (8 * 5));
            File[Start + index + 6] = (byte)(value >> (8 * 6));
            File[Start + index + 7] = (byte)(value >> (8 * 7));
            if (updatePosition) Position = index + sizeof(long);
        }

        public void WriteSingle(float value, int index, bool updatePosition = false)
        {
            byte[] a = BitConverter.GetBytes(value);
            if (Endianness == Endianness.Big)
            {
                byte t = a[0];
                a[0] = a[3];
                a[3] = t;
                t = a[1];
                a[1] = a[2];
                a[2] = t;
            }

            File[Start + index + 0] = a[0];
            File[Start + index + 1] = a[1];
            File[Start + index + 2] = a[2];
            File[Start + index + 3] = a[3];
            if (updatePosition) Position = index + sizeof(float);
        }

        public void WriteBytes(byte[] bytes, int index, bool updatePosition = false)
        {
            Array.Copy(bytes, 0, File, Start + index, bytes.Length);
            if (updatePosition) Position = index + bytes.Length;
        }

        public void WriteUTF8(string value, int index, bool updatePosition = false)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Array.Copy(bytes, 0, File, Start + index, bytes.Length);
            if (updatePosition) Position = index + bytes.Length;
        }

        public void WriteUTF8Z(string value, int index, bool updatePosition = false)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Array.Copy(bytes, 0, File, Start + index, bytes.Length);
            File[Start + index + bytes.Length] = 0;
            if (updatePosition) Position = index + bytes.Length + 1;
        }

        public void WriteUInt8(byte value) => WriteUInt8(value, Position, true);
        public void WriteInt8(sbyte value) => WriteInt8(value, Position, true);
        public void WriteUInt16(ushort value) => WriteUInt16(value, Position, true);
        public void WriteInt16(short value) => WriteInt16(value, Position, true);
        public void WriteUInt32(uint value) => WriteUInt32(value, Position, true);
        public void WriteInt32(int value) => WriteInt32(value, Position, true);
        public void WriteUInt64(ulong value) => WriteUInt64(value, Position, true);
        public void WriteInt64(long value) => WriteInt64(value, Position, true);
        public void WriteSingle(float value) => WriteSingle(value, Position, true);
        public void WriteBytes(byte[] bytes) => WriteBytes(bytes, Position, true);
        public void WriteUTF8(string value) => WriteUTF8(value, Position, true);
        public void WriteUTF8Z(string value) => WriteUTF8Z(value, Position, true);

        public void GuessEndianness32(int index, Func<int, bool> expected)
        {
            var original = Endianness;
            Endianness = Endianness.Little;
            var matchLittle = expected(ReadInt32(index));
            Endianness = Endianness.Big;
            var matchBig = expected(ReadInt32(index));

            if (!(matchLittle ^ matchBig))
            {
                Endianness = original;
                return;
            }

            Endianness = matchLittle ? Endianness.Little : Endianness.Big;
        }
    }

    public enum Endianness
    {
        Little,
        Big
    }

    public enum Game
    {
        XB1 = 1,
        XBX,
        XB2
    }
}
