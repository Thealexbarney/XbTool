using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using XbTool.CodeGen;

namespace XbTool.Bdat
{
    public class BdatTables
    {
        public BdatTable[] Tables { get; set; }
        private Dictionary<string, BdatTable> TablesDict { get; set; }
        public Game Game { get; }
        public Dictionary<(string table, string member), BdatFieldInfo> BdatFields { get; set; }
        public Dictionary<string, string> DisplayFields { get; set; }
        public BdatArrayInfo[] BdatArrays { get; set; }
        public BdatType[] Types { get; set; }
        public BdatTableDesc[] TableDesc { get; set; }

        public BdatTables(IFileReader fs, bool readMetadata, string lang = "gb")
        {
            Game = Game.XB2;
            Tables = ReadAllBdats(fs, lang);
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            if (readMetadata) ReadMetadata();
        }

        public BdatTables(string[] filenames, Game game, bool readMetadata)
        {
            Game = game;
            Tables = ReadAllBdats(filenames, game);
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            if (readMetadata) ReadMetadata();
        }

        public BdatTables(byte[] tables, Game game, bool readMetadata)
        {
            Game = game;
            DataBuffer buffer = new DataBuffer(tables, game, 0);
            Tables = ReadBdatFile(buffer, "");
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            if (readMetadata) ReadMetadata();
        }

        public BdatTable GetTable(string tableName)
        {
            return TablesDict.TryGetValue(tableName, out var table) ? table : null;
        }

        private void ReadMetadata()
        {
            BdatFields = new Dictionary<(string table, string member), BdatFieldInfo>();
            DisplayFields = new Dictionary<string, string>();

            ReadFieldInfo();
            ReadArrayInfo();
            ReadTableInfo();
            Types = CalculateBdatTypes(Tables);
            GetBdatRefs();
            ReadArrayInfos();
            GetTableDesc();
            MarkFlagMembers();
        }

        public static BdatTable[] ReadAllBdats(IFileReader fs, string lang = "gb")
        {
            var tables = new List<BdatTable>();

            tables.AddRange(ReadBdatFile(new DataBuffer(fs.ReadFile("/bdat/common.bdat"), Game.XB2, 0), "/bdat/common.bdat"));
            tables.AddRange(ReadBdatFile(new DataBuffer(fs.ReadFile("/bdat/common_gmk.bdat"), Game.XB2, 0), "/bdat/common_gmk.bdat"));

            foreach (var filename in fs.FindFiles($"/bdat/{lang}/*"))
            {
                DataBuffer buffer = new DataBuffer(fs.ReadFile(filename), Game.XB2, 0);
                tables.AddRange(ReadBdatFile(buffer, filename));
            }

            return tables.ToArray();
        }

        public static BdatTable[] ReadAllBdats(string[] filenames, Game game)
        {
            var tables = new List<BdatTable>();

            foreach (var file in filenames)
            {
                DataBuffer buffer = new DataBuffer(File.ReadAllBytes(file), game, 0);
                tables.AddRange(ReadBdatFile(buffer, file));
            }

            return tables.ToArray();
        }

        private static BdatTable[] ReadBdatFile(DataBuffer file, string filename)
        {
            if (file.Length <= 12) throw new InvalidDataException("File is too short");
            int fileLength = file.ReadInt32(4);
            if (file.Length < fileLength) throw new InvalidDataException("Incorrect file length field");

            BdatTools.DecryptBdat(file);
            int tableCount = file.ReadInt32(0);
            var tables = new BdatTable[tableCount];

            for (int i = 0; i < tableCount; i++)
            {
                int offset = file.ReadInt32(8 + 4 * i);
                int nextOffset = i < tableCount - 1 ? file.ReadInt32(8 + 4 * (i + 1)) : file.Length;
                int length = nextOffset - offset;

                DataBuffer tableBuffer = file.Slice(offset, length);

                var table = new BdatTable(tableBuffer);
                if (tableCount > 1) table.Filename = Path.GetFileNameWithoutExtension(filename);
                tables[i] = table;
            }

            return tables;
        }

        public void ReadFieldInfo()
        {
            BdatFields = BdatInfoImport.ReadBdatFieldInfo(Game.ToString().ToLower());
            ResolveWildcards();

            var tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            int removed = 0;
            foreach (var fieldKvp in BdatFields.ToArray())
            {
                BdatFieldInfo field = fieldKvp.Value;

                if (!tablesDict.TryGetValue(field.Table, out var table))
                {
                    BdatFields.Remove(fieldKvp.Key);
                    removed++;
                    continue;
                }

                var fieldInfo = table.Members.FirstOrDefault(x => x.Name == field.Field);
                if (fieldInfo == null)
                {
                    BdatFields.Remove(fieldKvp.Key);
                    removed++;
                    continue;
                }

                fieldInfo.Metadata = field;
            }
            if (removed > 0) Console.WriteLine($"Ignoring {removed} invalid relationships.");
        }

        public void ReadArrayInfo() => BdatArrays = BdatInfoImport.ReadBdatArrayInfo(Game.ToString().ToLower());

        public void ReadArrayInfos()
        {
            foreach (var array in BdatArrays)
            {
                var type = Types.First(x => x.Name == array.Table);
                array.IsReferences = true;

                foreach (var element in array.Elements)
                {
                    var tableRef = type.TableRefs.FirstOrDefault(x => x.Field == element);

                    if (tableRef == null)
                    {
                        array.IsReferences = false;
                        break;
                    }

                    if (array.Type != null && array.Type != tableRef.ChildType)
                    {
                        throw new NotSupportedException();
                    }

                    array.Type = tableRef.ChildType;
                }

                if (!array.IsReferences)
                {
                    foreach (var element in array.Elements)
                    {
                        var member = type.Members.First(x => x.Name == element);

                        if (array.Type != null && array.Type != SerializationCode.GetType(member.ValType))
                        {
                            throw new NotSupportedException();
                        }

                        array.Type = SerializationCode.GetType(member.ValType);
                    }
                }

                type.Arrays.Add(array);
            }
        }

        public void ReadTableInfo()
        {
            DisplayFields = BdatInfoImport.ReadBdatTableInfo(Game.ToString().ToLower());

            foreach (var table in Tables)
            {
                if (DisplayFields.ContainsKey(table.Name)) continue;

                string displayFieldName = table.Members.FirstOrDefault(x => x.Name.ToLower() == "name" && x.Type == BdatMemberType.Scalar)?.Name;

                if (displayFieldName != null)
                {
                    DisplayFields.Add(table.Name, displayFieldName);
                }
            }
        }

        private void ResolveWildcards()
        {
            var fields = BdatFields.Where(x => x.Value.Table.Contains('*')).ToArray();
            var tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            foreach (var field in fields)
            {
                bool hasFieldWildcard = field.Value.Field?.Contains('*') == true;
                var regex = new Regex("^" + Regex.Escape(field.Value.Table).Replace(@"\*\#", "(.\\d*)").Replace(@"\*", "(.*)") + "$");
                var matches = Tables.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                foreach (var match in matches)
                {
                    if (!hasFieldWildcard && !tablesDict[match.Value].Members.Select(x => x.Name).Contains(field.Value.Field))
                    {
                        continue;
                    }

                    BdatFieldInfo newInfo = field.Value.Clone();
                    newInfo.Table = match.Value;

                    if (newInfo.RefTable?.Contains('*') == true)
                    {
                        newInfo.RefTable = newInfo.RefTable.Replace("*", match.Groups[1].Value);

                        if (!tablesDict.ContainsKey(newInfo.RefTable)) continue;
                    }

                    if (!BdatFields.ContainsKey((newInfo.Table, newInfo.Field)))
                    {
                        BdatFields.Add((newInfo.Table, newInfo.Field), newInfo);
                    }
                }

                BdatFields.Remove(field.Key);
            }

            fields = BdatFields.Where(x => x.Value.Field.Contains('*')).ToArray();

            foreach (var field in fields)
            {
                var st = "^" + Regex.Escape(field.Value.Field).Replace(@"\*\#", "(.\\d*)").Replace(@"\*", "(.*)") + "$";
                var regex = new Regex(st);
                if (tablesDict.TryGetValue(field.Value.Table, out var table))
                {
                    var matches = table.Members.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                    foreach (var match in matches)
                    {
                        var newInfo = field.Value.Clone();
                        newInfo.Field = match.Value;

                        if (newInfo.RefTable?.Contains('*') == true)
                        {
                            newInfo.RefTable = newInfo.RefTable.Replace("*", match.Groups[1].Value);

                            if (!tablesDict.ContainsKey(newInfo.RefTable))
                            {
                                continue;
                            }
                        }

                        if (!BdatFields.ContainsKey((newInfo.Table, newInfo.Field)))
                        {
                            BdatFields.Add((newInfo.Table, newInfo.Field), newInfo);
                        }
                    }
                }

                BdatFields.Remove(field.Key);
            }
        }

        private static BdatType[] CalculateBdatTypes(BdatTable[] tables)
        {
            var customTypeNames = ReadTypeNames();

            return tables
                .ToLookup(x => x, x => x.Name, new BdatTableComparer())
                .Select(x => new BdatType(x.Key.Members, x.ToList(), customTypeNames))
                .OrderBy(x => x.Name)
                .ToArray();
        }

        public void GetBdatRefs()
        {
            foreach (BdatFieldInfo bdatField in BdatFields.Values.Where(x => ReadableFieldTypes.Contains(x.Type))
                .OrderBy(x => x.Table).ThenBy(x => x.Field))
            {
                BdatType parentType = Types.First(x => x.TableNames.Contains(bdatField.Table));
                BdatType childType = Types.FirstOrDefault(x => x.TableNames.Contains(bdatField.RefTable));
                BdatFieldInfo typeRef = parentType.TableRefs.FirstOrDefault(x => x.Field == bdatField.Field);

                if (typeRef != null)
                {
                    if (childType != null && typeRef.ChildType != childType.Name)
                    {
                        typeRef.ChildType = "object";
                    }
                }
                else
                {
                    switch (bdatField.Type)
                    {
                        case BdatFieldType.Item:
                            bdatField.ChildType = "object";
                            break;
                        default:
                            bdatField.ChildType = childType?.Name;
                            break;
                    }

                    bdatField.TableType = parentType.Name;
                    parentType.TableRefs.Add(bdatField);
                }
            }
        }

        private static Dictionary<string, string> ReadTypeNames()
        {
            var names = new Dictionary<string, string>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream resourceStream = assembly.GetManifestResourceStream("XbTool.CodeGen.TypeNames.txt");
            if (resourceStream == null) throw new InvalidOperationException("Can't open embedded resource");

            using (var reader = new StreamReader(resourceStream))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine()?.Split(',');
                    if (line == null || line.Length < 2) continue;

                    names.Add(line[0], line[1]);
                }
            }

            return names;
        }

        private void GetTableDesc()
        {
            List<BdatTableDesc> tables = new List<BdatTableDesc>();

            var refs = BdatFields.Values.Where(x => ReadableFieldTypes.Contains(x.Type)).ToLookup(x => x.Table);
            var arrays = BdatArrays.ToLookup(x => x.Table);

            var tableNames = refs.Select(x => x.Key).Concat(arrays.Select(x => x.Key)).Distinct().OrderBy(x => x);

            foreach (var table in tableNames)
            {
                var desc = new BdatTableDesc
                {
                    Name = table,
                    TableRefs = refs[table].ToArray(),
                    Arrays = arrays[table].ToArray(),
                    Type = Types.First(x => x.TableNames.Contains(table))
                };

                tables.Add(desc);
            }

            TableDesc = tables.ToArray();
        }

        private void MarkFlagMembers()
        {
            foreach (var table in Tables)
            {
                foreach (var member in table.Members.Where(x => x.Type == BdatMemberType.Flag))
                {
                    var flagVar = table.Members[member.FlagVarIndex];

                    if (flagVar.Metadata == null)
                    {
                        flagVar.Metadata = new BdatFieldInfo
                        {
                            Type = BdatFieldType.Hide
                        };
                    }
                }
            }
        }

        private static readonly BdatFieldType[] ReadableFieldTypes =
        {
            BdatFieldType.Reference,
            BdatFieldType.Message,
            BdatFieldType.Item,
            BdatFieldType.Enum,
            BdatFieldType.Condition,
            BdatFieldType.Task
        };
    }
}
