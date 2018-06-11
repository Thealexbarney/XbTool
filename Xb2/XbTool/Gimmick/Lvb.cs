using System.Collections.Generic;
using System.Text;

namespace XbTool.Gimmick
{
    public class Lvb
    {
        public List<LvlbSection> Sections = new List<LvlbSection>();
        public Transform[] Xfrm { get; set; }
        public InfoEntry[] Info { get; set; }
        public ClctEntry[] Clct { get; set; }
        public BtlcEntry[] Btlc { get; set; }
        public byte[] Strings { get; set; }

        public string Filename { get; set; }
        public string BdatName { get; set; }

        public Lvb(DataBuffer data)
        {
            int length = data.ReadInt32(4);
            data.Position = 0x20;

            while (data.Position + 0x20 < length)
            {
                var sectionStart = data.Position;
                var section = new LvlbSection(data);
                Sections.Add(section);
                data.Position += 8;

                switch (section.Id)
                {
                    case "XFRM":
                        Xfrm = new Transform[section.ItemCount];

                        for (int i = 0; i < Xfrm.Length; i++)
                        {
                            Xfrm[i] = new Transform(data);
                        }
                        break;
                    case "INFO":
                        Info = new InfoEntry[section.ItemCount];

                        for (int i = 0; i < Info.Length; i++)
                        {
                            Info[i] = new InfoEntry(data);
                        }
                        break;
                    case "CLCT":
                        Clct = new ClctEntry[section.ItemCount];

                        for (int i = 0; i < Clct.Length; i++)
                        {
                            Clct[i] = new ClctEntry(data);
                        }
                        break;
                    case "BTLC":
                        Btlc = new BtlcEntry[section.ItemCount];

                        for (int i = 0; i < Btlc.Length; i++)
                        {
                            Btlc[i] = new BtlcEntry(data);
                        }
                        break;
                    case "STRG":
                        Strings = new byte[section.SectionLength - 0x20];
                        Strings = data.ReadBytes(section.SectionLength - 0x20);
                        break;
                }

                data.Position = sectionStart + section.SectionLength;
            }

            foreach (var info in Info)
            {
                info.Name = Stuff.GetUTF8Z(Strings, info.StringOffset);
                info.Xfrm = Xfrm[info.XfrmId];
            }

            for (int i = 2; i < Sections.Count; i++)
            {
                if (Sections[i].Id == "STRG") continue;
                var start = Sections[i].BaseId;
                var end = Sections[i].BaseId + Sections[i].ItemCount;
                var gmkType = Types.GimmickIds[Sections[i].Id];

                for (int j = start, k = 0; j < end; j++, k++)
                {
                    if (j < Info.Length)
                    {
                        Info[j].Id = k;
                        Info[j].IdInFile = j;
                        Info[j].GmkType = gmkType;
                    }
                }
            }
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Name,X,Y,Z");

            for (int i = 0; i < Info.Length; i++)
            {
                var xfrm = Xfrm[Info[i].XfrmId];
                sb.Append(Info[i].Name + ",");
                sb.Append(xfrm.Position.X + ",");
                sb.Append(xfrm.Position.Y + ",");
                sb.Append(xfrm.Position.Z + ",");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public class LvlbSection
    {
        public string Id;
        public int SectionLength;
        public int Type;
        public int ItemCount;
        public int ItemLength;
        public int BaseId;

        public LvlbSection(DataBuffer data)
        {
            int start = data.Position;
            Id = data.ReadUTF8ZLen(4);
            data.Position = start + 4;
            SectionLength = data.ReadInt32();
            Type = data.ReadInt32();
            ItemCount = data.ReadInt32();
            ItemLength = data.ReadInt32();
            BaseId = data.ReadInt32();
        }
    }

    public class Transform
    {
        public Point3 Position;
        public float FieldC;
        public Point3 Rotation;
        public float Field1C;
        public Point3 Scale;
        public float Field2C;
        public ushort Field30;
        public ushort Field32;
        public float Field34;
        public float Field38;
        public float Field3C;

        public Transform(DataBuffer data)
        {
            Position = new Point3(data);
            FieldC = data.ReadSingle();
            Rotation = new Point3(data);
            Field1C = data.ReadSingle();
            Scale = new Point3(data);
            Field2C = data.ReadSingle();
            Field30 = data.ReadUInt16();
            Field32 = data.ReadUInt16();
            Field34 = data.ReadSingle();
            Field38 = data.ReadSingle();
            Field3C = data.ReadSingle();
        }
    }

    public class InfoEntry
    {
        public int StringOffset;
        public int Field4;
        public int XfrmId;
        public int Type;

        public Transform Xfrm;
        public string Name;
        public string GmkType;
        public int Id;
        public int IdInFile;

        public InfoEntry(DataBuffer data)
        {
            StringOffset = data.ReadInt32();
            Field4 = data.ReadInt32();
            XfrmId = data.ReadInt32();
            Type = data.ReadInt32();
        }
    }

    public class ClctEntry
    {
        public int Field0;
        public int Field4;
        public int Field8;

        public ClctEntry(DataBuffer data)
        {
            Field0 = data.ReadInt32();
            Field4 = data.ReadInt32();
            Field8 = data.ReadInt32();
        }
    }

    public class BtlcEntry
    {
        public short Field0;
        public short Field2;

        public BtlcEntry(DataBuffer data)
        {
            Field0 = data.ReadInt16();
            Field2 = data.ReadInt16();
        }
    }

    public class StrgEntry
    {
    }
}
