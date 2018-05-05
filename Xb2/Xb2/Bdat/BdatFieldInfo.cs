using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Xb2.Bdat
{
    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class BdatFieldInfo
    {
        public BdatFieldType Type { get; set; }
        public string Table { get; set; }
        public string TableType { get; set; }
        public string Field { get; set; }
        public string RefTable { get; set; }
        public string ChildType { get; set; }
        public string RefField { get; set; }
        public int Adjust { get; set; }
        public Type EnumType { get; set; }

        public BdatFieldInfo Clone() => (BdatFieldInfo)MemberwiseClone();
        private string DebugString => $"Type: {Type} Table: {Table} Member: {Field}";
    }

    public enum BdatFieldType
    {
        Message,
        Reference,
        Item,
        Condition,
        Character,
        Task,
        Hide,
        Enhance,
        WeatherIdMap,
        PouchBuff,
        Event,
        ShopTable,
        Enum,
        QuestFlag,
        Flag,
        Change,
        EventSetup,
        ItemComment,
        Layer
    }

    public class BdatArrayInfo
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public string Type { get; set; }
        public bool IsReferences { get; set; }
        public List<string> Elements { get; } = new List<string>();
    }

    public static class BdatInfoImport
    {
        public static Dictionary<(string table, string member), BdatFieldInfo> ReadBdatFieldInfo(string prefix)
        {
            var info = new Dictionary<(string table, string member), BdatFieldInfo>();
            if (!File.Exists($"{prefix}_fieldInfo.csv")) return info;

            using (var stream = new FileStream($"{prefix}_fieldInfo.csv", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(',');
                    if (line == null || line.Length < 2) continue;
                    ReadBdatFieldInfoLine(info, line);
                }
            }

            return info;
        }

        private static void ReadBdatFieldInfoLine(Dictionary<(string table, string member), BdatFieldInfo> info, string[] line)
        {
            int col = 0;

            var fInfo = new BdatFieldInfo
            {
                Table = line[col++],
                Field = line[col++],
                Type = (BdatFieldType)Enum.Parse(typeof(BdatFieldType), line[col++])
            };

            switch (fInfo.Type)
            {
                case BdatFieldType.Message:
                    fInfo.RefTable = line[col++];
                    break;
                case BdatFieldType.Reference:
                    fInfo.RefTable = line[col++];
                    break;
                case BdatFieldType.Condition:
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.Change:
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.ShopTable:
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.Flag:
                    fInfo.RefField = "FLG_" + line[col++];
                    break;
                case BdatFieldType.Task:
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.PouchBuff:
                    fInfo.RefTable = "BTL_PouchBuff";
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.Enum:
                    string type = line[col++];
                    fInfo.EnumType = Type.GetType("Xb2.Types." + type);
                    break;
                case BdatFieldType.Item:
                    fInfo.RefField = line[col++];
                    break;
                case BdatFieldType.Character:
                case BdatFieldType.Hide:
                case BdatFieldType.Enhance:
                case BdatFieldType.WeatherIdMap:
                case BdatFieldType.Event:
                case BdatFieldType.EventSetup:
                case BdatFieldType.QuestFlag:
                case BdatFieldType.ItemComment:
                case BdatFieldType.Layer:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (line.Length >= col + 1 && int.TryParse(line[col], out int adjust))
            {
                fInfo.Adjust = adjust;
            }

            info.Add((fInfo.Table, fInfo.Field), fInfo);
        }

        public static BdatArrayInfo[] ReadBdatArrayInfo(string prefix)
        {
            var info = new List<BdatArrayInfo>();
            if (!File.Exists($"{prefix}_arrays.csv")) return info.ToArray();
            
            using (var stream = new FileStream($"{prefix}_arrays.csv", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(',');
                    if (line == null || line.Length < 3) continue;

                    var array = new BdatArrayInfo
                    {
                        Table = line[0],
                        Name = line[1]
                    };

                    for (int i = 2; i < line.Length; i++)
                    {
                        array.Elements.Add(line[i]);
                    }

                    info.Add(array);
                }
            }

            return info.ToArray();
        }

        public static Dictionary<string, string> ReadBdatTableInfo(string prefix)
        {
            var display = new Dictionary<string, string>();
            if (!File.Exists($"{prefix}_tableInfo.csv")) return display;
            
            using (var stream = new FileStream($"{prefix}_tableInfo.csv", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(',');
                    if (line == null || line.Length < 2) continue;

                    display.Add(line[1], line[2]);
                }
            }

            return display;
        }
    }
}
