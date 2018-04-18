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

        public DataBuffer Slice(int start, int length)
        {
            return new DataBuffer(File, Game, Start + start, length);
        }

        public ushort ReadUInt16(int index)
        {
            ushort result = BitConverter.ToUInt16(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            return result;
        }

        public short ReadInt16(int index)
        {
            short result = BitConverter.ToInt16(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            return result;
        }

        public uint ReadUInt32(int index)
        {
            uint result = BitConverter.ToUInt32(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            return result;
        }

        public int ReadInt32(int index)
        {
            int result = BitConverter.ToInt32(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            return result;
        }

        public float ReadSingle(int index)
        {
            float result = BitConverter.ToSingle(File, Start + index);
            if (Endianness == Endianness.Big) result = Byte.ByteSwap(result);
            return result;
        }

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
        XB1,
        XBX,
        XB2
    }
}
