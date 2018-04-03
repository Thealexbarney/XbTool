using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xb2.BdatString;

namespace Xb2.Bdat
{
    public class BdatInfo
    {
        public Dictionary<string, string> DisplayFields { get; set; }
        public Dictionary<(string table, string member), BdatFieldInfo> FieldInfo { get; set; }
    }

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
    }

    public enum BdatFieldType
    {
        Message,
        Reference,
        Item,
        Condition,
        ConditionEnum,
        Character,
        Task,
        TaskTypeEnum,
        Hide,
        Enhance,
        TimeRange,
        WeatherBitfield,
        WeatherIdMap,
        PartyConditionEnum,
        IdeaCatEnumBits,
        FieldSkillEnum,
        ButtonTypeEnum,
        PouchBuff,
        LandmarkTypeEnum,
        Event,
        ShopTypeEnum,
        ShopTable,
        Enum
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
        public static BdatInfo GetBdatInfo(BdatStringCollection tables)
        {
            BdatInfo info = new BdatInfo
            {
                FieldInfo = ReadBdatFieldInfo(),
                DisplayFields = ReadBdatTableInfo()
            };
            ResolveWildcards(tables, info);
            SetDisplayFields(tables, info);

            return info;
        }

        public static Dictionary<(string table, string member), BdatFieldInfo> ReadBdatFieldInfo()
        {
            var info = new Dictionary<(string table, string member), BdatFieldInfo>();

            using (var stream = new FileStream("fieldInfo.csv", FileMode.Open, FileAccess.Read))
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
                case BdatFieldType.ShopTable:
                    fInfo.RefField = line[col++];
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
                case BdatFieldType.Character:
                case BdatFieldType.Item:
                case BdatFieldType.Hide:
                case BdatFieldType.Enhance:
                case BdatFieldType.WeatherIdMap:
                case BdatFieldType.Event:
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

        public static BdatArrayInfo[] ReadBdatArrayInfo()
        {
            var info = new List<BdatArrayInfo>();

            using (var stream = new FileStream("arrays.csv", FileMode.Open, FileAccess.Read))
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

        public static Dictionary<string, string> ReadBdatTableInfo()
        {
            var display = new Dictionary<string, string>();

            using (var stream = new FileStream("tableInfo.csv", FileMode.Open, FileAccess.Read))
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

        public static void ResolveWildcards(BdatStringCollection tables, BdatInfo info)
        {
            var fields = info.FieldInfo.Where(x => x.Value.Table.Contains('*')).ToArray();

            foreach (var field in fields)
            {
                var regex = new Regex("^" + Regex.Escape(field.Value.Table).Replace(@"\*", "(.*)") + "$");
                var matches = tables.Tables.Select(x => regex.Match(x.Key)).Where(x => x.Success).ToArray();
                foreach (var match in matches)
                {
                    var newInfo = field.Value.Clone();
                    newInfo.Table = match.Value;

                    if (newInfo.RefTable?.Contains('*') == true)
                    {
                        newInfo.RefTable = newInfo.RefTable.Replace("*", match.Groups[1].Value);

                        if (!tables.Tables.ContainsKey(newInfo.RefTable)) continue;
                    }

                    info.FieldInfo.Add((newInfo.Table, newInfo.Field), newInfo);
                }

                info.FieldInfo.Remove(field.Key);
            }

            fields = info.FieldInfo.Where(x => x.Value.Field.Contains('*')).ToArray();

            foreach (var field in fields)
            {
                var st = Regex.Escape(field.Value.Field).Replace(@"\*", "(.*)");
                var regex = new Regex(st);
                var matches = tables[field.Value.Table].Members.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                foreach (var match in matches)
                {
                    var newInfo = field.Value.Clone();
                    newInfo.Field = match.Value;
                    info.FieldInfo.Add((newInfo.Table, newInfo.Field), newInfo);

                    if (newInfo.RefField?.Contains('*') == true)
                    {
                        newInfo.RefField = newInfo.RefField.Replace("*", match.Groups[1].Value);
                    }
                }

                info.FieldInfo.Remove(field.Key);
            }
        }

        public static void SetDisplayFields(BdatStringCollection tables, BdatInfo info)
        {
            foreach (BdatStringTable table in tables.Tables.Values)
            {
                if (info.DisplayFields.ContainsKey(table.Name)) continue;

                var fieldName = table.Members.FirstOrDefault(x => x.Name.ToLower() == "name")?.Name;

                if (fieldName != null)
                {
                    info.DisplayFields.Add(table.Name, fieldName);
                }
            }
        }
    }
}
