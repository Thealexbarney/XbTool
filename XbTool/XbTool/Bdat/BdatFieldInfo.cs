using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using XbTool.Common;

namespace XbTool.Bdat
{
    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class BdatFieldInfo
    {
        public BdatFieldType Type { get; set; }
        public BdatMember Member { get; set; }
        public string Table { get; set; }
        public string TableType { get; set; }
        public string Field { get; set; }
        public string RefTable { get; set; }
        public string ChildType { get; set; }
        public string RefField { get; set; }
        public int Adjust { get; set; }
        public Type EnumType { get; set; }
        public string EnumTypeString { get; set; }

        public BdatFieldInfo Clone() => (BdatFieldInfo)MemberwiseClone();
        private string DebugString => $"Type: {Type} Table: {Table} Member: {Field}";
    }

    public enum BdatFieldType
    {
        Message,
        Reference,
        OneWayReference,
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
        Quest,
        QuestMenu,
        QuestFlag,
        QuestFlagIra,
        Flag,
        GameFlag,
        Change,
        EventSetup,
        ItemComment,
        Layer,
        Place,
        Enemy,
        ArmorStyle,
        WeaponStyle
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
            return ReadBdatFieldInfoImpl($"{prefix}_fieldInfo.csv");
        }

        public static Dictionary<(string table, string member), BdatFieldInfo> ReadBdatNewFieldInfo(string prefix)
        {
            return ReadBdatFieldInfoImpl($"{prefix}_newfields.csv");
        }

        public static Dictionary<(string table, string member), BdatFieldInfo> ReadBdatFieldInfoImpl(string filename)
        {
            using (FileStream stream = Helpers.TryOpenDataFile(filename))
            {
                if (stream == null) return new Dictionary<(string table, string member), BdatFieldInfo>();

                using (var reader = new StreamReader(stream))
                {
                    IEnumerable<BdatFieldInfo> csv =
                        new CsvReader(reader, new Configuration { HeaderValidated = null, MissingFieldFound = null })
                            .GetRecords<BdatFieldInfo>();
                    Dictionary<(string, string), BdatFieldInfo> readBdatFieldInfo =
                        csv.ToDictionary(x => (x.Table, x.Field), x => x);

                    foreach (BdatFieldInfo info in readBdatFieldInfo.Values.Where(x => x.EnumTypeString != null))
                    {
                        info.EnumType = Type.GetType($"XbTool.Types.{info.EnumTypeString}");
                    }

                    foreach (BdatFieldInfo info in readBdatFieldInfo.Values.Where(x => x.Type == BdatFieldType.Flag))
                    {
                        info.RefField = "FLG_" + info.RefField;
                    }

                    return readBdatFieldInfo;
                }
            }
        }

        public static BdatArrayInfo[] ReadBdatArrayInfo(string prefix)
        {
            var info = new List<BdatArrayInfo>();
            FileStream stream = Helpers.TryOpenDataFile($"{prefix}_arrays.csv");
            if (stream == null) return info.ToArray();

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
            FileStream stream = Helpers.TryOpenDataFile($"{prefix}_tableinfo.csv");
            if (stream == null) return display;

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
