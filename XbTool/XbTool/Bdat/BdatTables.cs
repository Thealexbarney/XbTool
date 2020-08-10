﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using LibHac;
using LibHac.Fs;
using LibHac.FsSystem;
using XbTool.CodeGen;
using XbTool.Common;
using XbTool.Types;

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
        public byte[] FileData { get; }

        public BdatTables(IFileSystem fs, bool readMetadata, IProgressReport progress = null, string lang = "gb")
        {
            Game = Game.XB2;
            progress?.LogMessage("Reading BDAT files");
            Tables = ReadAllBdats(fs, progress, lang);
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            progress?.LogMessage("Reading BDAT metadata");
            if (readMetadata) ReadMetadata();
        }

        public BdatTables(string[] filenames, Game game, bool readMetadata)
        {
            Game = game;
            Tables = ReadAllBdats(filenames, game);

            // todo: better way of dealing with XB1's duplicate name
            var dictionary = new Dictionary<string, BdatTable>();

            foreach (BdatTable table in Tables)
            {
                if (dictionary.ContainsKey(table.Name))
                {
                    table.Name = table.Filename + table.Name;
                }
                dictionary.Add(table.Name, table);
            }

            TablesDict = dictionary;
            if (readMetadata) ReadMetadata();
        }

        public BdatTables(string filename, Game game, bool readMetadata)
        {
            Game = game;
            FileData = File.ReadAllBytes(filename);
            var tables = new List<BdatTable>();

            var buffer = new DataBuffer(FileData, game, 0);
            tables.AddRange(ReadBdatFile(buffer, filename));
            Tables = tables.ToArray();
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            if (readMetadata) ReadMetadata();
        }

        public BdatTables(byte[] tables, Game game, bool readMetadata)
        {
            Game = game;
            var buffer = new DataBuffer(tables, game, 0);
            Tables = ReadBdatFile(buffer, "");
            TablesDict = Tables.ToDictionary(x => x.Name, x => x);
            if (readMetadata) ReadMetadata();
        }

        public BdatTable GetTable(string tableName)
        {
            return TablesDict.TryGetValue(tableName, out BdatTable table) ? table : null;
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

        public static BdatTable[] ReadAllBdats(IFileSystem fs, IProgressReport progress = null, string lang = "gb")
        {
            var tables = new List<BdatTable>();

            tables.AddRange(ReadBdatFile(new DataBuffer(fs.ReadFile("/bdat/common.bdat"), Game.XB2, 0), "/bdat/common.bdat"));
            tables.AddRange(ReadBdatFile(new DataBuffer(fs.ReadFile("/bdat/common_gmk.bdat"), Game.XB2, 0), "/bdat/common_gmk.bdat"));
            tables.AddRange(ReadBdatFile(new DataBuffer(fs.ReadFile("/bdat/lookat.bdat"), Game.XB2, 0), "/bdat/lookat.bdat"));

            string[] files = fs.EnumerateEntries($"/bdat/{lang}", "*").Select(x => x.FullPath).ToArray();

            progress?.SetTotal(files.Length);

            foreach (string filename in files)
            {
                var buffer = new DataBuffer(fs.ReadFile(filename), Game.XB2, 0);
                tables.AddRange(ReadBdatFile(buffer, filename));
                progress?.ReportAdd(1);
            }

            return tables.ToArray();
        }

        public static BdatTable[] ReadAllBdats(string[] filenames, Game game)
        {
            var tables = new List<BdatTable>();

            foreach (string file in filenames)
            {
                var buffer = new DataBuffer(File.ReadAllBytes(file), game, 0);
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
            Dictionary<(string table, string member), BdatFieldInfo> newFields = BdatInfoImport.ReadBdatNewFieldInfo(Game.ToString().ToLower());

            ResolveFieldInfoWildcards(newFields, false);
            AddNewFields(newFields);

            ResolveFieldInfoWildcards(BdatFields, true);

            Dictionary<string, BdatTable> tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            int removed = 0;
            foreach (KeyValuePair<(string table, string member), BdatFieldInfo> fieldKvp in BdatFields.ToArray())
            {
                BdatFieldInfo field = fieldKvp.Value;

                if (!tablesDict.TryGetValue(field.Table, out BdatTable table))
                {
                    BdatFields.Remove(fieldKvp.Key);
                    removed++;
                    continue;
                }

                BdatMember fieldInfo = table.Members.FirstOrDefault(x => x.Name == field.Field);
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
            foreach (BdatArrayInfo array in BdatArrays)
            {
                BdatType type = Types.FirstOrDefault(x => x.Name == array.Table);

                if (type == null) continue;

                array.IsReferences = true;

                foreach (string element in array.Elements)
                {
                    BdatFieldInfo tableRef = type.TableRefs.FirstOrDefault(x => x.Field == element);

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
                    foreach (string element in array.Elements)
                    {
                        BdatMember member = type.Members.First(x => x.Name == element);

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

            ResolveTableInfoWildcards();

            foreach (BdatTable table in Tables)
            {
                if (DisplayFields.ContainsKey(table.Name)) continue;

                string displayFieldName = table.Members.FirstOrDefault(x => x.Name.ToLower() == "name" && x.Type == BdatMemberType.Scalar)?.Name;

                if (displayFieldName != null)
                {
                    DisplayFields.Add(table.Name, displayFieldName);
                }
            }
        }

        private void ResolveFieldInfoWildcards(Dictionary<(string table, string member), BdatFieldInfo> bdatFields, bool verifyFieldExists)
        {
            KeyValuePair<(string table, string member), BdatFieldInfo>[] fields = bdatFields.Where(x => x.Value.Table.Contains('*')).ToArray();
            Dictionary<string, BdatTable> tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            foreach (KeyValuePair<(string table, string member), BdatFieldInfo> field in fields)
            {
                bool hasFieldWildcard = field.Value.Field?.Contains('*') == true;
                var regex = new Regex("^" + Regex.Escape(field.Value.Table).Replace(@"\*\#", "(.\\d*)").Replace(@"\*", "(.*)") + "$");
                Match[] matches = Tables.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                foreach (Match match in matches)
                {
                    if (!hasFieldWildcard &&
                        verifyFieldExists &&
                        !tablesDict[match.Value].Members.Select(x => x.Name).Contains(field.Value.Field))
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

                    if (!bdatFields.ContainsKey((newInfo.Table, newInfo.Field)))
                    {
                        bdatFields.Add((newInfo.Table, newInfo.Field), newInfo);
                    }
                }

                bdatFields.Remove(field.Key);
            }

            fields = bdatFields.Where(x => x.Value.Field.Contains('*')).ToArray();

            foreach (KeyValuePair<(string table, string member), BdatFieldInfo> field in fields)
            {
                string st = "^" + Regex.Escape(field.Value.Field).Replace(@"\*\#", "(.\\d*)").Replace(@"\*", "(.*)") + "$";
                var regex = new Regex(st);
                if (tablesDict.TryGetValue(field.Value.Table, out BdatTable table))
                {
                    Match[] matches = table.Members.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                    foreach (Match match in matches)
                    {
                        BdatFieldInfo newInfo = field.Value.Clone();
                        newInfo.Field = match.Value;

                        if (newInfo.RefTable?.Contains('*') == true)
                        {
                            newInfo.RefTable = newInfo.RefTable.Replace("*", match.Groups[1].Value);

                            if (!tablesDict.ContainsKey(newInfo.RefTable))
                            {
                                continue;
                            }
                        }

                        if (!bdatFields.ContainsKey((newInfo.Table, newInfo.Field)))
                        {
                            bdatFields.Add((newInfo.Table, newInfo.Field), newInfo);
                        }
                    }
                }

                bdatFields.Remove(field.Key);
            }
        }

        private void ResolveTableInfoWildcards()
        {
            KeyValuePair<string, string>[] tables = DisplayFields.Where(x => x.Key.Contains('*')).ToArray();
            Dictionary<string, BdatTable> tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            foreach (KeyValuePair<string, string> table in tables)
            {
                var regex = new Regex("^" + Regex.Escape(table.Key).Replace(@"\*\#", "(.\\d*)").Replace(@"\*", "(.*)") + "$");
                Match[] matches = Tables.Select(x => regex.Match(x.Name)).Where(x => x.Success).ToArray();
                foreach (Match match in matches)
                {
                    DisplayFields.Add(match.Value, table.Value);
                }

                DisplayFields.Remove(table.Key);
            }
        }

        private void AddNewFields(Dictionary<(string table, string member), BdatFieldInfo> newFields)
        {
            Dictionary<string, BdatTable> tablesDict = Tables.ToDictionary(x => x.Name, x => x);

            int removed = 0;
            foreach (KeyValuePair<(string table, string member), BdatFieldInfo> fieldKvp in newFields)
            {
                BdatFieldInfo field = fieldKvp.Value;

                if (!tablesDict.TryGetValue(field.Table, out BdatTable table))
                {
                    removed++;
                    continue;
                }

                BdatMember fieldInfo = table.Members.FirstOrDefault(x => x.Name == fieldKvp.Key.member);
                if (fieldInfo != null)
                {
                    removed++;
                    continue;
                }

                var newMember = new BdatMember(fieldKvp.Key.member, BdatMemberType.None, BdatValueType.None);
                table.PrependMember(newMember);

                BdatFields.Add(fieldKvp.Key, fieldKvp.Value);
            }
            if (removed > 0) Console.WriteLine($"Ignoring {removed} invalid new fields.");
        }

        private static BdatType[] CalculateBdatTypes(BdatTable[] tables)
        {
            Dictionary<string, string> customTypeNames = ReadTypeNames();

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
            var tables = new List<BdatTableDesc>();

            ILookup<string, BdatFieldInfo> refs = BdatFields.Values.Where(x => ReadableFieldTypes.Contains(x.Type)).ToLookup(x => x.Table);
            ILookup<string, BdatArrayInfo> arrays = BdatArrays.ToLookup(x => x.Table);

            IOrderedEnumerable<string> tableNames = refs.Select(x => x.Key).Concat(arrays.Select(x => x.Key)).Distinct().OrderBy(x => x);

            foreach (string table in tableNames)
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
            foreach (BdatTable table in Tables)
            {
                foreach (BdatMember member in table.Members.Where(x => x.Type == BdatMemberType.Flag))
                {
                    BdatMember flagVar = table.Members[member.FlagVarIndex];

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
            BdatFieldType.OneWayReference,
            BdatFieldType.Message,
            BdatFieldType.Item,
            BdatFieldType.Enum,
            BdatFieldType.Condition,
            BdatFieldType.Task
        };
    }
}
