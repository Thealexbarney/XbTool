using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CsvHelper;
using XbTool.CodeGen;

namespace XbTool.Save
{
    public static class SaveCodeGen
    {
        public static void GenerateSaveCode()
        {
            var types = ReadTypes();
            var sb = new Indenter();
            bool first = true;

            sb.AppendLine("// ReSharper disable InconsistentNaming RedundantCast MemberCanBePrivate.Global NotAccessedField.Global FieldCanBeMadeReadOnly.Global ForCanBeConvertedToForeach PartialTypeWithSinglePart");
            sb.AppendLine("");
            sb.AppendLine("using XbTool.Types");
            sb.AppendLine();
            sb.AppendLine("namespace XbTool.Save");
            sb.AppendLineAndIncrease("{");

            foreach (var type in types)
            {
                if (!first)
                {
                    sb.AppendLine();
                }

                GenerateClass(type, sb);

                first = false;
            }

            sb.DecreaseAndAppendLine("}");
            File.WriteAllText("SaveTypes.cs", sb.ToString());
        }

        public static void GenerateClass(SaveType type, Indenter sb)
        {
            sb.AppendLine($"public partial class {type.Name}");
            sb.AppendLineAndIncrease("{");

            foreach (var field in type.Fields)
            {
                switch (field.Type)
                {
                    case "Scalar":
                        sb.AppendLine($"public {field.DataType} {field.Name} {{ get; set; }}");
                        break;
                    case "Array":
                        sb.AppendLine($"public {field.DataType}[] {field.Name} {{ get; set; }} = new {field.DataType}[{field.Length}];");
                        break;
                    case "Bitfield":
                        foreach (var value in field.Bitfield)
                        {
                            sb.AppendLine($"public {field.DataType} {value.Name} {{ get; set; }}");
                        }
                        break;
                    case "BitfieldArray":
                        sb.AppendLine($"public byte[] {field.Name} {{ get; set; }} = new byte[{field.Length}];");
                        break;
                }
            }

            CreateReadFunction(type, sb);
            CreateWriteFunction(type, sb);
            sb.DecreaseAndAppendLine("}");
        }

        private static void CreateReadFunction(SaveType type, Indenter sb)
        {
            sb.AppendLine();
            sb.AppendLine($"public {type.Name}(DataBuffer save)");
            sb.AppendLineAndIncrease("{");
            bool firstField = true;
            bool prevWasArray = false;

            foreach (var field in type.Fields)
            {
                switch (field.Type)
                {
                    case "Scalar":
                        if (prevWasArray) sb.AppendLine();
                        if (field.DataType == "string")
                        {
                            sb.AppendLine(GetReadValue(field));
                        }
                        else
                        {
                            sb.AppendLine($"{field.Name} = {GetReadValue(field)}");
                        }

                        prevWasArray = false;

                        break;
                    case "Array":
                        if (!firstField) sb.AppendLine();
                        sb.AppendLine($"for (int i = 0; i < {field.Name}.Length; i++)");
                        sb.AppendLineAndIncrease("{");
                        sb.AppendLine($"{field.Name}[i] = {GetReadValue(field)}");

                        sb.DecreaseAndAppendLine("}");
                        prevWasArray = true;
                        break;
                    case "Bitfield":
                        sb.AppendLine($"{field.DataType} {field.Name} = {GetReadValue(field)}");
                        int bit = 0;
                        foreach (var value in field.Bitfield)
                        {
                            sb.AppendLine(
                                $"{value.Name} = ({field.DataType})({field.Name} >> {bit} & ((1u << {value.Size}) - 1));");
                            bit += int.Parse(value.Size);
                        }
                        break;
                    case "BitfieldArray":
                        sb.AppendLine($"Read.ReadBitfieldArray(save, {field.Name}, {field.Length}, {field.Size});");
                        break;
                    case "Padding":
                        sb.AppendLine($"save.Position += {field.Length};");
                        break;
                }

                firstField = false;
            }

            sb.DecreaseAndAppendLine("}");
        }

        private static void CreateWriteFunction(SaveType type, Indenter sb)
        {
            sb.AppendLine();
            sb.AppendLine("public void WriteSave(DataBuffer save)");
            sb.AppendLineAndIncrease("{");
            bool firstField = true;
            bool prevWasArray = false;

            foreach (var field in type.Fields)
            {
                switch (field.Type)
                {
                    case "Scalar":
                        if (prevWasArray) sb.AppendLine();
                        if (field.DataType == "string")
                        {
                            sb.AppendLine(GetWriteValue(field));
                        }
                        else
                        {
                            sb.AppendLine(GetWriteValue(field));
                        }

                        prevWasArray = false;

                        break;
                    case "Array":
                        if (!firstField) sb.AppendLine();
                        sb.AppendLine($"for (int i = 0; i < {field.Name}.Length; i++)");
                        sb.AppendLineAndIncrease("{");
                        sb.AppendLine($"{GetWriteValue(field, "[i]")}");

                        sb.DecreaseAndAppendLine("}");
                        prevWasArray = true;
                        break;
                    case "Bitfield":
                        sb.AppendLine($"{field.DataType} {field.Name} = 0;");
                        int bit = 0;
                        foreach (var value in field.Bitfield)
                        {
                            sb.AppendLine($"{field.Name} |= ({field.DataType})(({value.Name} & ((1u << {value.Size}) - 1)) << {bit});");
                            bit += int.Parse(value.Size);
                        }

                        sb.AppendLine(GetWriteValue(field));
                        break;
                    case "BitfieldArray":
                        sb.AppendLine($"Write.WriteBitfieldArray(save, {field.Name}, {field.Length}, {field.Size});");
                        break;
                    case "Padding":
                        sb.AppendLine($"save.Position += {field.Length};");
                        break;
                }

                firstField = false;
            }

            sb.DecreaseAndAppendLine("}");
        }

        public static string GetReadValue(SaveField field)
        {
            string result = "";
            string dataType = field.DataType;

            if (!string.IsNullOrWhiteSpace(field.Enum))
            {
                result += $"({field.DataType})";
                dataType = SizeToType[field.Size];
            }

            switch (dataType)
            {
                case "sbyte":
                case "byte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "ulong":
                case "float":
                    var readFunc = ReadFunctions[dataType];
                    result += $"save.{readFunc}();";
                    break;
                case "bool":
                    var readFuncBool = ReadFunctions[SizeToType[field.Length]];
                    result += $"save.{readFuncBool}() != 0;";
                    break;
                case "string" when !string.IsNullOrWhiteSpace(field.Size):
                    result += $"{field.Name} = Read.ReadSizedUTF8(save, {field.Length});";
                    break;
                case "string":
                    result += $"{field.Name} = save.ReadUTF8({field.Length});";
                    break;
                default:
                    result += $"new {dataType}(save);";
                    break;
            }

            return result;
        }

        public static string GetWriteValue(SaveField field, string append = null)
        {
            string result = "";
            string dataType = field.DataType;
            string enumCast = string.Empty;

            if (!string.IsNullOrWhiteSpace(field.Enum))
            {
                dataType = SizeToType[field.Size];
                enumCast = $"({dataType})";
            }

            switch (dataType)
            {
                case "sbyte":
                case "byte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "ulong":
                case "float":
                    var writeFunc = WriteFunctions[dataType];
                    result += $"save.{writeFunc}({enumCast}{field.Name}{append});";
                    break;
                case "bool":
                    var writeFuncBool = WriteFunctions[SizeToType[field.Length]];
                    result += $"save.{writeFuncBool}(({SizeToType[field.Length]})({field.Name} ? 1 : 0));";
                    break;
                case "string" when !string.IsNullOrWhiteSpace(field.Size):
                    result += $"save.WriteSizedUTF8({field.Name}, {field.Length});";
                    break;
                case "string":
                    result += $"save.WriteUTF8({field.Name}{append});";
                    break;
                default:
                    result += $"{field.Name}{append}.WriteSave(save);";
                    break;
            }

            return result;
        }

        public static List<SaveType> ReadTypes()
        {
            using (var stream = new FileStream("saveInfo.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                IEnumerable<SaveField> csv = new CsvReader(reader).GetRecords<SaveField>();
                var types = new List<SaveType>();
                SaveType type = null;
                SaveField bitfield = null;

                foreach (var field in csv)
                {
                    switch (field.Type)
                    {
                        case "Class":
                            type = new SaveType { Name = field.Name };
                            types.Add(type);
                            break;
                        case "Bitfield":
                            bitfield = field;
                            field.Bitfield = new List<SaveField>();
                            Debug.Assert(type != null, nameof(type) + " != null");
                            type.Fields.Add(field);
                            break;
                        case "BitfieldValue":
                            Debug.Assert(bitfield != null, nameof(bitfield) + " != null");
                            bitfield.Bitfield.Add(field);
                            break;
                        default:
                            Debug.Assert(type != null, nameof(type) + " != null");
                            type.Fields.Add(field);
                            break;
                    }
                }

                return types;
            }
        }

        private static readonly Dictionary<string, string> ReadFunctions = new Dictionary<string, string>
        {
            ["sbyte"] = "ReadInt8",
            ["byte"] = "ReadUInt8",
            ["short"] = "ReadInt16",
            ["ushort"] = "ReadUInt16",
            ["int"] = "ReadInt32",
            ["uint"] = "ReadUInt32",
            ["long"] = "ReadInt64",
            ["ulong"] = "ReadUInt64",
            ["float"] = "ReadSingle"
        };

        private static readonly Dictionary<string, string> WriteFunctions = new Dictionary<string, string>
        {
            ["sbyte"] = "WriteInt8",
            ["byte"] = "WriteUInt8",
            ["short"] = "WriteInt16",
            ["ushort"] = "WriteUInt16",
            ["int"] = "WriteInt32",
            ["uint"] = "WriteUInt32",
            ["long"] = "WriteInt64",
            ["ulong"] = "WriteUInt64",
            ["float"] = "WriteSingle"
        };

        private static readonly Dictionary<string, string> SizeToType = new Dictionary<string, string>
        {
            ["8"] = "byte",
            ["16"] = "ushort",
            ["32"] = "uint",
            ["64"] = "ulong"
        };
    }

    public class SaveType
    {
        public string Name;
        public List<SaveField> Fields { get; set; } = new List<SaveField>();
    }

    public class SaveField
    {
        public string Type { get; set; }
        public string DataType { get; set; }
        public string Name { get; set; }
        public string Length { get; set; }
        public string Enum { get; set; }
        public string Size { get; set; }
        public List<SaveField> Bitfield;
    }
}
