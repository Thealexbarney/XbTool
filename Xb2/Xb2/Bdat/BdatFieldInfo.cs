using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xb2.BdatString;
using Xb2.Types;

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
        WeatherIdMap
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
                    string[] line = reader.ReadLine()?.Split(new[] { ',' });
                    if (line == null || line.Length < 2) continue;
                    int col = 0;

                    BdatFieldType type = (BdatFieldType)Enum.Parse(typeof(BdatFieldType), line[col++]);

                    var fInfo = new BdatFieldInfo
                    {
                        Type = type,
                        Table = line[col++],
                        Field = line[col++]
                    };

                    switch (type)
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
                        case BdatFieldType.ConditionEnum:
                            fInfo.EnumType = typeof(ConditionType);
                            break;
                        case BdatFieldType.TaskTypeEnum:
                            fInfo.EnumType = typeof(TaskType);
                            break;
                        case BdatFieldType.Task:
                            fInfo.RefField = line[col++];
                            break;
                        case BdatFieldType.Character:
                        case BdatFieldType.Item:
                        case BdatFieldType.Hide:
                        case BdatFieldType.Enhance:
                        case BdatFieldType.TimeRange:
                        case BdatFieldType.WeatherBitfield:
                        case BdatFieldType.WeatherIdMap:
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
            }

            return info;
        }

        public static BdatArrayInfo[] ReadBdatArrayInfo()
        {
            var info = new List<BdatArrayInfo>();

            using (var stream = new FileStream("arrays.csv", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(new[] { ',' });
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
                    string[] line = reader.ReadLine()?.Split(new[] { ',' });
                    if (line == null || line.Length < 2) continue;

                    display.Add(line[1], line[2]);
                }
            }

            return display;
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
