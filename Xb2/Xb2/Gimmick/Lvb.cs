using System;
using System.Text;

namespace Xb2.Gimmick
{
    public class Lvb
    {
        public Transform[] Xfrm { get; set; }
        public InfoEntry[] Info { get; set; }
        public ClctEntry[] Clct { get; set; }
        public BtlcEntry[] Btlc { get; set; }
        public byte[] Strings { get; set; }

        public Lvb(byte[] data)
        {
            int length = BitConverter.ToInt32(data, 4);
            int pos = 0x20;

            while (pos < length)
            {
                int sectionLength = BitConverter.ToInt32(data, pos + 4);
                int count = BitConverter.ToInt32(data, pos + 0xc);

                string sectionType = Encoding.UTF8.GetString(data, pos, 4);
                switch (sectionType)
                {
                    case "XFRM":
                        Xfrm = new Transform[count];

                        for (int i = 0; i < count; i++)
                        {
                            Xfrm[i] = new Transform(data, pos + 0x20 + 0x40 * i);
                        }
                        break;
                    case "INFO":
                        Info = new InfoEntry[count];

                        for (int i = 0; i < count; i++)
                        {
                            Info[i] = new InfoEntry(data, pos + 0x20 + 0x10 * i);
                        }
                        break;
                    case "CLCT":
                        Clct = new ClctEntry[count];

                        for (int i = 0; i < count; i++)
                        {
                            Clct[i] = new ClctEntry(data, pos + 0x20 + 12 * i);
                        }
                        break;
                    case "BTLC":
                        Btlc = new BtlcEntry[count];

                        for (int i = 0; i < count; i++)
                        {
                            Btlc[i] = new BtlcEntry(data, pos + 0x20 + 4 * i);
                        }
                        break;
                    case "STRG":
                        Strings = new byte[sectionLength - 0x20];
                        Array.Copy(data, pos + 0x20, Strings, 0, sectionLength - 0x20);
                        break;
                }

                pos += sectionLength;
            }

            foreach (var info in Info)
            {
                info.String = Stuff.GetUTF8Z(Strings, info.StringOffset);
                info.Xfrm = Xfrm[info.XfrmId];
            }
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Name,X,Y,Z,Unk");

            for (int i = 0; i < Info.Length; i++)
            {
                var xfrm = Xfrm[Info[i].XfrmId];
                sb.Append(Info[i].String + ",");
                sb.Append(xfrm.Position.X + ",");
                sb.Append(xfrm.Position.Y + ",");
                sb.Append(xfrm.Position.Z + ",");
                sb.Append(xfrm.Field20 + ",");
                sb.Append(xfrm.Field24 + ",");
                sb.Append(xfrm.Field28 + ",");
                sb.Append(xfrm.Field14);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public class Transform
    {
        public Point3 Position;
        public float FieldC;
        public float Field10;
        public float Field14;
        public float Field18;
        public float Field1C;
        public float Field20;
        public float Field24;
        public float Field28;
        public float Field2C;
        public float Field30;
        public float Field34;
        public float Field38;
        public float Field3C;

        public Transform(byte[] data, int offset)
        {
            var x = BitConverter.ToSingle(data, offset);
            var y = BitConverter.ToSingle(data, offset + 4);
            var z = BitConverter.ToSingle(data, offset + 8);
            Position = new Point3(x, y, z);
            FieldC = BitConverter.ToSingle(data, offset + 0xC);
            Field10 = BitConverter.ToSingle(data, offset + 0x10);
            Field14 = BitConverter.ToSingle(data, offset + 0x14);
            Field18 = BitConverter.ToSingle(data, offset + 0x18);
            Field1C = BitConverter.ToSingle(data, offset + 0x1C);
            Field20 = BitConverter.ToSingle(data, offset + 0x20);
            Field24 = BitConverter.ToSingle(data, offset + 0x24);
            Field28 = BitConverter.ToSingle(data, offset + 0x28);
            Field2C = BitConverter.ToSingle(data, offset + 0x2C);
            Field30 = BitConverter.ToSingle(data, offset + 0x30);
            Field34 = BitConverter.ToSingle(data, offset + 0x34);
            Field38 = BitConverter.ToSingle(data, offset + 0x38);
            Field3C = BitConverter.ToSingle(data, offset + 0x3C);
        }
    }

    public class InfoEntry
    {
        public int StringOffset;
        public int Field4;
        public int XfrmId;
        public Transform Xfrm;
        public int FieldC;
        public string String;

        public InfoEntry(byte[] data, int offset)
        {
            StringOffset = BitConverter.ToInt32(data, offset);
            Field4 = BitConverter.ToInt32(data, offset + 4);
            XfrmId = BitConverter.ToInt32(data, offset + 8);
            FieldC = BitConverter.ToInt32(data, offset + 0xC);
        }
    }

    public class ClctEntry
    {
        public int Field0;
        public int Field4;
        public int Field8;

        public ClctEntry(byte[] data, int offset)
        {
            Field0 = BitConverter.ToInt32(data, offset);
            Field4 = BitConverter.ToInt32(data, offset + 4);
            Field8 = BitConverter.ToInt32(data, offset + 8);
        }
    }

    public class BtlcEntry
    {
        public short Field0;
        public short Field2;

        public BtlcEntry(byte[] data, int offset)
        {
            Field0 = BitConverter.ToInt16(data, offset);
            Field2 = BitConverter.ToInt16(data, offset + 2);
        }
    }

    public class StrgEntry
    {
    }

    public class LvlbSection
    {
        public string Id;
        public int Length;
        public int Field8;
        public int Count;
        public int Field10;
        public int Field14;
    }
}
