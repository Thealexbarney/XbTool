using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xb2.CodeGen;

namespace Xb2.Bdat
{
    public class BdatCollInfo
    {
        public Dictionary<(string table, string member), BdatFieldInfo> BdatFields { get; set; }
        public BdatArrayInfo[] BdatArrays { get; set; }
        public BdatType[] Types { get; set; }
        public BdatTableDesc[] Tables { get; set; }

        public BdatCollInfo(BdatTable[] tables)
        {
            BdatFields = BdatInfoImport.ReadBdatFieldInfo();
            BdatArrays = BdatInfoImport.ReadBdatArrayInfo();
            Types = GetBdatTypes(tables);
            GetBdatRefs();
            ReadArrayInfo();
            GetTableDesc();
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
                    Arrays = arrays[table].ToArray()
                };

                tables.Add(desc);
            }

            Tables = tables.ToArray();
        }

        private static BdatType[] GetBdatTypes(BdatTable[] tables)
        {
            var types = new Dictionary<BdatTable, BdatType>(new BdatTableComparer());
            var names = ReadTypeNames();

            foreach (BdatTable table in tables)
            {
                if (!types.ContainsKey(table))
                {
                    types.Add(table, new BdatType { Name = table.Name, Members = table.Members });
                }

                types[table].TableNames.Add(table.Name);

                if (names.TryGetValue(table.Name, out string type))
                {
                    types[table].Name = type;
                }
            }

            return types.Values.OrderBy(x => x.Name).ToArray();
        }

        public void GetBdatRefs()
        {
            foreach (BdatFieldInfo bdatField in BdatFields.Values.Where(x => ReadableFieldTypes.Contains(x.Type)))
            {
                BdatType parentType = Types.First(x => x.TableNames.Contains(bdatField.Table));
                BdatType childType = Types.FirstOrDefault(x => x.TableNames.Contains(bdatField.RefTable));
                BdatFieldInfo typeRef = parentType.TableRefs.FirstOrDefault(x => x.Field == bdatField.Field);

                if (typeRef != null)
                {
                    if (childType != null && typeRef.ChildType != childType.Name)
                    {
                        throw new NotSupportedException();
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

        public void ReadArrayInfo()
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

        private static Dictionary<string, string> ReadTypeNames()
        {
            var names = new Dictionary<string, string>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream resourceStream = assembly.GetManifestResourceStream("Xb2.CodeGen.TypeNames.txt");
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

        private static readonly BdatFieldType[] ReadableFieldTypes =
        {
            BdatFieldType.Reference,
            BdatFieldType.Message,
            BdatFieldType.Item,
            BdatFieldType.ConditionEnum,
            BdatFieldType.Condition,
            BdatFieldType.TaskTypeEnum,
            BdatFieldType.Task
        };
    }

    public class BdatTableDesc
    {
        public string Name { get; set; }
        public BdatFieldInfo[] TableRefs { get; set; }
        public BdatArrayInfo[] Arrays { get; set; }
    }

    public class BdatType
    {
        public string Name { get; set; }
        public BdatMember[] Members { get; set; }
        public List<string> TableNames { get; } = new List<string>();
        public List<BdatFieldInfo> TableRefs { get; } = new List<BdatFieldInfo>();
        public List<BdatArrayInfo> Arrays { get; } = new List<BdatArrayInfo>();
    }
}
