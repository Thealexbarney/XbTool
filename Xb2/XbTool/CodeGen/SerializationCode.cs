using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XbTool.Bdat;

namespace XbTool.CodeGen
{
    public static class SerializationCode
    {
        public static void CreateFiles(BdatTables tables, string csDir)
        {
            Directory.CreateDirectory(csDir);

            string bdatTypes = GenerateTypesFile(tables);
            string readFunctions = GenerateReadFunctionsFile(tables);
            string bdatCollection = GenerateBdatCollectionFile(tables);
            string typeMap = GenerateTypeMapFile(tables);

            File.WriteAllText(Path.Combine(csDir, "BdatTypes.cs"), bdatTypes);
            File.WriteAllText(Path.Combine(csDir, "ReadFunctions.cs"), readFunctions);
            File.WriteAllText(Path.Combine(csDir, "BdatCollection.cs"), bdatCollection);
            File.WriteAllText(Path.Combine(csDir, "TypeMap.txt"), typeMap);
        }

        private static string GetIdentifier(string input)
        {
            return Keywords.Contains(input) ? "@" + input : input;
        }

        private static string GenerateTypesFile(BdatTables info)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine("// ReSharper disable NotAccessedField.Global");
            sb.AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("using XbTool.Types");
            sb.AppendLineAndIncrease("{");

            for (int i = 0; i < info.Types.Length; i++)
            {
                if (i != 0) sb.AppendLine();
                GenerateType(info.Types[i], sb);
            }

            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static void GenerateType(BdatType type, Indenter sb)
        {
            var added = new HashSet<string>();

            sb.AppendLine("[BdatType]");
            sb.AppendLine("[Serializable]");
            sb.AppendLine($"public class {type.Name}");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("public int Id;");

            foreach (var member in type.Members)
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
                        var valType = GetType(member.ValType);
                        sb.AppendLine($"public readonly {valType}[] {name} = new {valType}[{length}];");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var bdatRef in type.TableRefs)
            {
                switch (bdatRef.Type)
                {
                    case BdatFieldType.Reference:
                    case BdatFieldType.Message:
                        sb.AppendLine($"public {bdatRef.ChildType} _{bdatRef.Field};");
                        break;
                    case BdatFieldType.Item:
                    case BdatFieldType.Task:
                    case BdatFieldType.Condition:
                        sb.AppendLine($"public object _{bdatRef.Field};");
                        break;
                    case BdatFieldType.Enum:
                        sb.AppendLine($"public {bdatRef.EnumType.Name} _{bdatRef.Field};");
                        break;
                    default:
                        if (bdatRef.EnumType != null)
                        {
                            sb.AppendLine($"public {bdatRef.EnumType.Name} _{bdatRef.Field};");
                        }
                        break;
                }
            }

            foreach (var array in type.Arrays)
            {
                sb.AppendLine($"public {array.Type}[] _{array.Name};");
            }

            sb.DecreaseAndAppendLine("}");
        }

        private static string GenerateReadFunctionsFile(BdatTables info)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine("// ReSharper disable UnusedMember.Global");
            sb.AppendLine("// ReSharper disable UseObjectOrCollectionInitializer");
            sb.AppendLine("// ReSharper disable UnusedParameter.Global").AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine("using XbTool.Types").AppendLine();
            sb.AppendLine("namespace XbTool.Serialization");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("public static class ReadFunctions");
            sb.AppendLineAndIncrease("{");
            bool firstFunction = true;

            foreach (var type in info.Types)
            {
                if (!firstFunction) sb.AppendLine();
                firstFunction = false;
                GenerateReadFunction(type, sb);
            }

            sb.AppendLine();
            GenerateSetReferencesFunction(sb, info);

            sb.DecreaseAndAppendLine("}");
            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static void GenerateReadFunction(BdatType type, Indenter sb)
        {
            sb.AppendLine($"public static {type.Name} Read{type.Name}(byte[] file, int itemId, int itemOffset, int tableOffset)");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine($"var item = new {type.Name}();");
            sb.AppendLine("item.Id = itemId;");

            foreach (var member in type.Members.Where(x => x.Type == BdatMemberType.Scalar))
            {
                sb.AppendLine(GetReader(member));
            }

            foreach (var member in type.Members.Where(x => x.Type == BdatMemberType.Array))
            {
                GetArrayReader(member, sb);
            }

            foreach (var member in type.Members.Where(x => x.Type == BdatMemberType.Flag))
            {
                var flagVarName = GetIdentifier(type.Members[member.FlagVarIndex].Name);
                sb.AppendLine($"item.{GetIdentifier(member.Name)} = (item.{flagVarName} & {member.FlagMask}) != 0;");
            }

            sb.AppendLine("return item;");
            sb.DecreaseAndAppendLine("}");
        }

        private static void GenerateSetReferencesFunction(Indenter sb, BdatTables info)
        {
            sb.AppendLine("public static void SetReferences(BdatCollection tables)");
            sb.AppendLineAndIncrease("{");
            bool firstTable = true;

            foreach (var table in info.TableDesc)
            {
                if (!firstTable) sb.AppendLine();
                firstTable = false;

                GenerateSetReferencesTable(sb, table);
            }

            sb.DecreaseAndAppendLine("}");
        }

        private static void GenerateSetReferencesTable(Indenter sb, BdatTableDesc table)
        {
            sb.AppendLine($"foreach ({table.Type.Name} item in tables.{table.Name}.Items)");
            sb.AppendLineAndIncrease("{");
            foreach (var fieldRef in table.TableRefs.OrderBy(x => x.Field))
            {
                switch (fieldRef.Type)
                {
                    case BdatFieldType.Reference:
                        sb.AppendLine($"item._{fieldRef.Field} = tables.{fieldRef.RefTable}.GetItemOrNull(item.{PrintFieldRefId(fieldRef)});");
                        break;
                    case BdatFieldType.Message:
                        sb.AppendLine($"item._{fieldRef.Field} = tables.{fieldRef.RefTable}.GetItemOrNull(item.{PrintFieldRefId(fieldRef)});");
                        break;
                    case BdatFieldType.Item:
                        sb.AppendLine($"item._{fieldRef.Field} = tables.GetItem(item.{PrintFieldRefId(fieldRef)});");
                        break;
                    case BdatFieldType.Task:
                        sb.AppendLine($"item._{fieldRef.Field} = tables.GetTask((TaskType)item.{fieldRef.RefField}, item.{PrintFieldRefId(fieldRef)});");
                        break;
                    case BdatFieldType.Condition:
                        sb.AppendLine($"item._{fieldRef.Field} = tables.GetCondition((ConditionType)item.{fieldRef.RefField}, item.{PrintFieldRefId(fieldRef)});");
                        break;
                    case BdatFieldType.Enum:
                        sb.AppendLine($"item._{fieldRef.Field} = ({fieldRef.EnumType.Name})item.{fieldRef.Field};");
                        break;
                    default:
                        if (fieldRef.EnumType != null)
                        {
                            sb.AppendLine($"item._{fieldRef.Field} = ({fieldRef.EnumType.Name})item.{PrintFieldRefId(fieldRef)};");
                        }
                        break;
                }
            }

            foreach (var array in table.Arrays.OrderBy(x => x.Name))
            {
                sb.AppendLine($"item._{array.Name} = new[]");
                sb.AppendLineAndIncrease("{");

                var elementCount = array.Elements.Count;
                for (int i = 0; i < elementCount; i++)
                {
                    string name = (array.IsReferences ? "_" : "") + array.Elements[i];
                    sb.AppendLine($"item.{name}{(i < elementCount - 1 ? "," : "")}");
                }

                sb.DecreaseAndAppendLine("};");
            }

            sb.DecreaseAndAppendLine("}");
        }

        private static string PrintFieldRefId(BdatFieldInfo fieldRef)
        {
            string output = fieldRef.Field;

            if (fieldRef.Adjust > 0)
            {
                output += $" + {fieldRef.Adjust}";
            }

            if (fieldRef.Adjust < 0)
            {
                output += $" - {-fieldRef.Adjust}";
            }

            return output;
        }

        private static string GenerateTypeMapFile(BdatTables info)
        {
            var sb = new StringBuilder();

            foreach (var type in info.Types)
            {
                sb.Append(type.Name);
                foreach (var table in type.TableNames.OrderBy(x => x))
                {
                    sb.Append($",{table}");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static string GenerateBdatCollectionFile(BdatTables info)
        {
            var sb = new Indenter();

            sb.AppendLine("// ReSharper disable InconsistentNaming");
            sb.AppendLine("// ReSharper disable UnassignedField.Global");
            sb.AppendLine("// ReSharper disable UnusedMember.Global").AppendLine();
            sb.AppendLine("using System;");
            sb.AppendLine("using XbTool.Bdat;").AppendLine();
            sb.AppendLine("using XbTool.Types");
            sb.AppendLineAndIncrease("{");
            sb.AppendLine("[Serializable]");
            sb.AppendLine("public class BdatCollection");
            sb.AppendLineAndIncrease("{");

            foreach (var type in info.Types)
            {
                foreach (string table in type.TableNames.OrderBy(x => x))
                {
                    sb.AppendLine($"public BdatTable<{type.Name}> {table};");
                }
            }

            sb.DecreaseAndAppendLine("}");
            sb.DecreaseAndAppendLine("}");
            return sb.ToString();
        }

        private static string GetReader(BdatMember member)
        {
            string name = GetIdentifier(member.Name);
            string memberPos = member.MemberPos > 0 ? $" + {member.MemberPos}" : string.Empty;
            switch (member.ValType)
            {
                case BdatValueType.UInt8:
                    return $"item.{name} = file[itemOffset{memberPos}];";
                case BdatValueType.UInt16:
                    return $"item.{name} = BitConverter.ToUInt16(file, itemOffset{memberPos});";
                case BdatValueType.UInt32:
                    return $"item.{name} = BitConverter.ToUInt32(file, itemOffset{memberPos});";
                case BdatValueType.Int8:
                    return $"item.{name} = (sbyte)file[itemOffset{memberPos}];";
                case BdatValueType.Int16:
                    return $"item.{name} = BitConverter.ToInt16(file, itemOffset{memberPos});";
                case BdatValueType.Int32:
                    return $"item.{name} = BitConverter.ToInt32(file, itemOffset{memberPos});";
                case BdatValueType.String:
                    return $"item.{name} = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset{memberPos}));";
                case BdatValueType.FP32:
                    return $"item.{name} = BitConverter.ToSingle(file, itemOffset{memberPos});";
            }
            throw new ArgumentOutOfRangeException();
        }

        private static void GetArrayReader(BdatMember member, Indenter sb)
        {
            string name = GetIdentifier(member.Name);
            int itemSize = GetSize(member.ValType);
            string memberPos = member.MemberPos > 0 ? $" + {member.MemberPos}" : string.Empty;

            sb.AppendLine($"for (int i = 0, offset = itemOffset{memberPos}; i < {member.ArrayCount}; i++, offset += {itemSize})");
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
