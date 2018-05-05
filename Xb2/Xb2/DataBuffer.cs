using System;
using System.Text;

namespace Xb2
{
    public class DataBuffer
    {
        public Game Game { get; }
        public Endianness Endianness { get; }
        public byte[] File { get; }
        public int Start { get; }
        public int Length { get; }
        public int Position { get; set; }

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

        public byte ReadUInt8() => ReadUInt8(Position, true);
        public sbyte ReadInt8() => ReadInt8(Position, true);
        public ushort ReadUInt16() => ReadUInt16(Position, true);
        public short ReadInt16() => ReadInt16(Position, true);
        public uint ReadUInt32() => ReadUInt32(Position, true);
        public int ReadInt32() => ReadInt32(Position, true);
        public ulong ReadUInt64() => ReadUInt64(Position, true);
        public long ReadInt64() => ReadInt64(Position, true);
        public float ReadSingle() => ReadSingle(Position, true);

        public string ReadUTF8Z(int index)
        {
            int end = index;

            while (File[Start + end] != 0)
            {
                end++;
            }

            return ReadUTF8(index, end - index);
        }

        public string ReadUTF8(int index, int length)
        {
            return Encoding.UTF8.GetString(File, Start + index, length);
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
