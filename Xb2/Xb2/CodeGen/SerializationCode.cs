using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Bdat;

namespace Xb2.CodeGen
{
    public static class SerializationCode
    {
        public static void CreateFiles(BdatTable[] tables, string csDir)
        {
            Directory.CreateDirectory(csDir);
            Dictionary<BdatTable, List<string>> types = GetClasses(tables);

            string bdatTypes = GenerateTypesFile(types.Keys.OrderBy(x => x.Name).ToArray());
            string readFunctions = GenerateReadFunctionsFile(types.Keys.OrderBy(x => x.Name).ToArray());
            string bdatCollection = GenerateBdatCollectionFile(types);
            string typeMap = GenerateTypeMapFile(types);

            File.WriteAllText(Path.Combine(csDir, "BdatTypes.cs"), bdatTypes);
            File.WriteAllText(Path.Combine(csDir, "ReadFunctions.cs"), readFunctions);
            File.WriteAllText(Path.Combine(csDir, "BdatCollection.cs"), bdatCollection);
            File.WriteAllText(Path.Combine(csDir, "TypeMap.txt"), typeMap);
        }

        private static Dictionary<BdatTable, List<string>> GetClasses(BdatTable[] tables)
        {
            var types = new Dictionary<BdatTable, List<string>>(new BdatTableComparer());
            foreach (BdatTable table in tables)
            {
                if (!types.ContainsKey(table))
                {
                    types.Add(table, new List<string>());
                }

                types[table].Add(table.Name);
            }

            return types;
        }

        private static string GetIdentifier(string input)
        {
            return Keywords.Contains(input) ? "@" + input : input;
        }

        private static string GenerateTypesFile(BdatTable[] tables)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace Xb2.Types");
            sb.AppendLineAndIncrease("{");

            for (int i = 0; i < tables.Length; i++)
            {
                if (i != 0) sb.AppendLine();
                GenerateType(tables[i], sb);
            }

            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static void GenerateType(BdatTable table, Indenter sb)
        {
            var added = new HashSet<string>();

            sb.AppendLine("[BdatType]");
            sb.AppendLine("[Serializable]");
            sb.AppendLine($"public class {table.Name}");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("public int Id;");

            foreach (var member in table.Members)
            {
                if (added.Contains(member.Name)) continue;
                added.Add(member.Name);

                var memberType = member.Type;
                var name = GetIdentifier(member.Name);
                switch (memberType)
                {
                    case BdatMemberType.Flag:
                        sb.AppendLine($"public bool {name};");
                        break;
                    case BdatMemberType.Scalar:
                        sb.AppendLine($"public {GetType(member.ValType)} {name};");
                        break;
                    case BdatMemberType.Array:
                        int length = member.ArrayCount;
                        var type = GetType(member.ValType);
                        sb.AppendLine($"public {type}[] {name} = new {type}[{length}];");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            sb.DecreaseAndAppendLine("}");
        }

        private static string GenerateReadFunctionsFile(BdatTable[] tables)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming").AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine("using Xb2.Types;").AppendLine();
            sb.AppendLine("namespace Xb2.Serialization");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("public static class ReadFunctions");
            sb.AppendLineAndIncrease("{");
            bool firstFunction = true;
            
            foreach (BdatTable table in tables)
            {
                if (!firstFunction) sb.AppendLine();
                firstFunction = false;
                GenerateReadFunction(table, sb);
            }

            sb.DecreaseAndAppendLine("}");
            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static void GenerateReadFunction(BdatTable table, Indenter sb)
        {
            sb.AppendLine($"public static {table.Name} Read{table.Name}(byte[] file, int itemOffset, int tableOffset)");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine($"var item = new {table.Name}();");

            foreach (var member in table.Members.Where(x => x.Type == BdatMemberType.Scalar))
            {
                sb.AppendLine(GetReader(member));
            }

            foreach (var member in table.Members.Where(x => x.Type == BdatMemberType.Array))
            {
                GetArrayReader(member, sb);
            }

            foreach (var member in table.Members.Where(x => x.Type == BdatMemberType.Flag))
            {
                var flagVarName = GetIdentifier(table.Members[member.FlagVarIndex].Name);
                sb.AppendLine($"item.{GetIdentifier(member.Name)} = (item.{flagVarName} & {member.FlagMask}) != 0;");
            }

            sb.AppendLine("return item;");
            sb.DecreaseAndAppendLine("}");
        }

        private static string GenerateTypeMapFile(Dictionary<BdatTable, List<string>> types)
        {
            var sb = new StringBuilder();

            foreach (var type in types.OrderBy(x => x.Key.Name))
            {
                sb.Append(type.Key.Name);
                foreach (var table in type.Value.OrderBy(x => x))
                {
                    sb.Append($",{table}");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string GenerateBdatCollectionFile(Dictionary<BdatTable, List<string>> types)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming").AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine("using Xb2.Bdat;").AppendLine();
            sb.AppendLine("namespace Xb2.Types");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("[Serializable]");
            sb.AppendLine("public class BdatCollection");
            sb.AppendLineAndIncrease("{");

            foreach (var type in types.OrderBy(x => x.Key.Name))
            {
                foreach (string table in type.Value.OrderBy(x => x))
                {
                    sb.AppendLine($"public BdatTable<{type.Key.Name}> {table};");
                }
            }

            sb.DecreaseAndAppendLine("}");
            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static string GetReader(BdatMember member)
        {
            string name = GetIdentifier(member.Name);
            switch (member.ValType)
            {
                case BdatValueType.UInt8:
                    return $"item.{name} = file[itemOffset + {member.MemberPos}];";
                case BdatValueType.UInt16:
                    return $"item.{name} = BitConverter.ToUInt16(file, itemOffset + {member.MemberPos});";
                case BdatValueType.UInt32:
                    return $"item.{name} = BitConverter.ToUInt32(file, itemOffset + {member.MemberPos});";
                case BdatValueType.Int8:
                    return $"item.{name} = (sbyte)file[itemOffset + {member.MemberPos}];";
                case BdatValueType.Int16:
                    return $"item.{name} = BitConverter.ToInt16(file, itemOffset + {member.MemberPos});";
                case BdatValueType.Int32:
                    return $"item.{name} = BitConverter.ToInt32(file, itemOffset + {member.MemberPos});";
                case BdatValueType.String:
                    return $"item.{name} = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + {member.MemberPos}));";
                case BdatValueType.FP32:
                    return $"item.{name} = BitConverter.ToSingle(file, itemOffset + {member.MemberPos});";
            }
            throw new ArgumentOutOfRangeException();
        }

        private static void GetArrayReader(BdatMember member, Indenter sb)
        {
            string name = GetIdentifier(member.Name);
            int itemSize = GetSize(member.ValType);

            sb.AppendLine($"for (int i = 0, offset = itemOffset + {member.MemberPos}; i < {member.ArrayCount}; i++, offset += {itemSize})");
            sb.AppendLineAndIncrease("{");

            switch (member.ValType)
            {
                case BdatValueType.UInt8:
                    sb.AppendLine($"item.{name}[i] = file[offset];");
                    break;
                case BdatValueType.UInt16:
                    sb.AppendLine($"item.{name}[i] = BitConverter.ToUInt16(file, offset);");
                    break;
                case BdatValueType.UInt32:
                    sb.AppendLine($"item.{name}[i] = BitConverter.ToUInt32(file, offset);");
                    break;
                case BdatValueType.Int8:
                    sb.AppendLine($"item.{name}[i] = (sbyte)file[offset];");
                    break;
                case BdatValueType.Int16:
                    sb.AppendLine($"item.{name}[i] = BitConverter.ToInt16(file, offset);");
                    break;
                case BdatValueType.Int32:
                    sb.AppendLine($"item.{name}[i] = BitConverter.ToInt32(file, offset);");
                    break;
                case BdatValueType.String:
                    sb.AppendLine($"item.{name}[i] = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, offset));");
                    break;
                case BdatValueType.FP32:
                    sb.AppendLine($"item.{name}[i] = BitConverter.ToSingle(file, offset);");
                    break;
            }

            sb.DecreaseAndAppendLine("}");
        }

        public static string GetType(BdatValueType inType)
        {
            switch (inType)
            {
                case BdatValueType.UInt8:
                    return "byte";
                case BdatValueType.UInt16:
                    return "ushort";
                case BdatValueType.UInt32:
                    return "uint";
                case BdatValueType.Int8:
                    return "sbyte";
                case BdatValueType.Int16:
                    return "short";
                case BdatValueType.Int32:
                    return "int";
                case BdatValueType.String:
                    return "string";
                case BdatValueType.FP32:
                    return "float";
                default:
                    throw new ArgumentOutOfRangeException(nameof(inType), inType, null);
            }
        }

        public static int GetSize(BdatValueType inType)
        {
            switch (inType)
            {
                case BdatValueType.UInt8:
                case BdatValueType.Int8:
                    return 1;
                case BdatValueType.UInt16:
                case BdatValueType.Int16:
                    return 2;
                case BdatValueType.UInt32:
                case BdatValueType.Int32:
                case BdatValueType.String:
                case BdatValueType.FP32:
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException(nameof(inType), inType, null);
            }
        }

        private static readonly HashSet<string> Keywords = new HashSet<string>(
            new[]
            {
                "as",
                "do",
                "if",
                "in",
                "is",
                "for",
                "int",
                "new",
                "out",
                "ref",
                "try",
                "base",
                "bool",
                "byte",
                "case",
                "char",
                "else",
                "enum",
                "goto",
                "lock",
                "long",
                "null",
                "this",
                "true",
                "uint",
                "void",
                "break",
                "catch",
                "class",
                "const",
                "event",
                "false",
                "fixed",
                "float",
                "sbyte",
                "short",
                "throw",
                "ulong",
                "using",
                "where",
                "while",
                "yield",
                "double",
                "extern",
                "object",
                "params",
                "public",
                "return",
                "sealed",
                "sizeof",
                "static",
                "string",
                "struct",
                "switch",
                "typeof",
                "unsafe",
                "ushort",
                "checked",
                "decimal",
                "default",
                "finally",
                "foreach",
                "partial",
                "private",
                "virtual",
                "abstract",
                "continue",
                "delegate",
                "explicit",
                "implicit",
                "internal",
                "operator",
                "override",
                "readonly",
                "volatile",
                "__arglist",
                "__makeref",
                "__reftype",
                "interface",
                "namespace",
                "protected",
                "unchecked",
                "__refvalue",
                "stackalloc"
            });
    }
}
