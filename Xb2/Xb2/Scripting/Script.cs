using System;

namespace Xb2.Scripting
{
    public class Script
    {
        public byte Field4;
        public byte Field5;
        public byte Field6;
        public byte Field7;
        public int Field8;
        public int FieldC;
        public int Field10;
        public int Field14;
        public int Field18;
        public int Field1C;
        public int Field20;
        public int Field24;
        public int Field28;
        public int Field2C;
        public int Field30;
        public int Field34;

        public StringArray Ids;
        public ScriptArray Array24;

        public Script(byte[] file)
        {
            ScriptTools.DescrambleScript(file);

            Field4 = file[4];
            Field5 = file[5];
            Field6 = file[6];
            Field7 = file[7];
            Field8 = BitConverter.ToInt32(file, 8);
            FieldC = BitConverter.ToInt32(file, 0xC);
            Field10 = BitConverter.ToInt32(file, 0x10);
            Field14 = BitConverter.ToInt32(file, 0x14);
            Field18 = BitConverter.ToInt32(file, 0x18);
            Field1C = BitConverter.ToInt32(file, 0x1C);
            Field20 = BitConverter.ToInt32(file, 0x20);
            Field24 = BitConverter.ToInt32(file, 0x24);
            Field28 = BitConverter.ToInt32(file, 0x28);
            Field2C = BitConverter.ToInt32(file, 0x2C);
            Field30 = BitConverter.ToInt32(file, 0x30);
            Field34 = BitConverter.ToInt32(file, 0x34);

            Ids = new StringArray(file, FieldC);
            Array24 = new ScriptArray(file, Field24);
        }
    }

    public class ScriptArray
    {
        public int Length { get; set; }
        public int[] Values { get; set; }

        public ScriptArray(byte[] file, int offset)
        {
            int tableOffset = offset + BitConverter.ToInt32(file, offset);
            Length = BitConverter.ToInt32(file, offset + 4);
            int size = BitConverter.ToInt32(file, offset + 8);
            Values = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                switch (size)
                {
                    case 2:
                        Values[i] = BitConverter.ToUInt16(file, tableOffset + i * size);
                        break;
                }
            }
        }
    }

    public class StringArray
    {
        public int Length { get; set; }
        public int[] Values { get; set; }
        public string[] Strings { get; set; }

        public StringArray(byte[] file, int offset)
        {
            int tableOffset = offset + BitConverter.ToInt32(file, offset);
            Length = BitConverter.ToInt32(file, offset + 4);
            int size = BitConverter.ToInt32(file, offset + 8);
            Values = new int[Length];
            Strings = new string[Length];

            for (int i = 0; i < Length; i++)
            {
                switch (size)
                {
                    case 2:
                        Values[i] = BitConverter.ToUInt16(file, tableOffset + i * size);
                        break;
                }

                Strings[i] = Stuff.GetUTF8Z(file, tableOffset + Values[i]);
            }
        }
    }
}
