using System.Text;

namespace XbTool.Scripting
{
    public static class Export
    {
        public static string PrintScript(Script script)
        {
            var sb = new StringBuilder();

            PrintSectionsHeader(script, sb);
            PrintStaticVars(script, sb);
            PrintFunctionPool(script, sb);
            PrintIdPool(script, sb);
            PrintLocalPool(script, sb);
            PrintStringPool(script, sb);
            PrintPluginImports(script, sb);
            PrintOcImports(script, sb);
            PrintSysAtrPool(script, sb);
            PrintStaticSymbols(script, sb);
            PrintLocalSymbols(script, sb);
            PrintArgsSymbols(script, sb);
            PrintFilenameSymbols(script, sb);
            PrintLineSymbols(script, sb);
            return sb.ToString();
        }

        private static void PrintSectionsHeader(Script script, StringBuilder sb)
        {
            sb.AppendLine("Sections:");
            var table = new Table("Name", "Items", "Offset", "Length");
            foreach (Section section in script.Sections)
            {
                table.AddRow(section.Name, section.Count.ToString(), section.Offset.ToString("x6"),
                    section.Length.ToString("x6"));
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintFunctionPool(Script script, StringBuilder sb)
        {
            sb.AppendLine("Function Pool:");
            var table = new Table("Index", "Name", "Start", "End", "Local Vars", "Arg Count", "F4", "FA");
            for (int i = 0; i < script.FunctionPool.Length; i++)
            {
                LocalFunction func = script.FunctionPool[i];
                table.AddRow(i.ToString(), func.Name, func.Start.ToString("x6"), func.End.ToString("x6"),
                    func.LocalVarCount.ToString(),
                    func.ArgsCount.ToString(), func.Field4.ToString(), func.FieldA.ToString());
            }

            sb.AppendLine(table.Print());

            for (int i = 0; i < script.FunctionPool.Length; i++)
            {
                PrintFunction(script, sb, i);
            }
        }

        private static void PrintIdPool(Script script, StringBuilder sb)
        {
            sb.AppendLine("Id Pool:");
            var table = new Table("Index", "Value", "Uses");
            for (int i = 0; i < script.IdPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.IdPool[i], script.IdPoolRefs[i]);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintLocalPool(Script script, StringBuilder sb)
        {
            sb.AppendLine("Local Pool:");
            for (int i = 0; i < script.FunctionPool.Length; i++)
            {
                var func = script.FunctionPool[i];
                if (func.LocalPoolIndex == ushort.MaxValue) continue;

                var table = new Table("Name", "Type", "Len", "Value", "F8");
                var items = script.LocalPool[func.LocalPoolIndex];

                for (int j = 0; j < items.Length; j++)
                {
                    table.AddRow(items[j].Name, items[j].Type.ToString(), items[j].Length.ToString(), items[j].Value.ToString(),
                        items[j].Field8.ToString());
                }

                sb.AppendLine(func.Name);
                sb.AppendLine(table.Print());
            }
        }

        private static void PrintStringPool(Script script, StringBuilder sb)
        {
            sb.AppendLine("String Pool:");
            var table = new Table("Index", "Value");
            for (int i = 0; i < script.StringPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.StringPool[i]);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintPluginImports(Script script, StringBuilder sb)
        {
            sb.AppendLine("Plugin Imports:");
            var table = new Table("Index", "Plugin", "Function");
            for (int i = 0; i < script.Plugins.Length; i++)
            {
                table.AddRow(i.ToString(), script.Plugins[i].Plugin, script.Plugins[i].Function);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintOcImports(Script script, StringBuilder sb)
        {
            sb.AppendLine("OC Imports:");
            var table = new Table("Index", "Name");
            for (int i = 0; i < script.OcImports.Length; i++)
            {
                table.AddRow(i.ToString(), script.OcImports[i]);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintStaticVars(Script script, StringBuilder sb)
        {
            sb.AppendLine("Static Variables:");
            var table = new Table("Idx", "Name", "Type", "Len", "Value", "F8");
            for (int i = 0; i < script.StaticVars.Length; i++)
            {
                var item = script.StaticVars[i];
                table.AddRow(i.ToString(), item.Name, item.Type.ToString(), item.Length.ToString(), item.Value.ToString(), item.Field8.ToString());
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintSysAtrPool(Script script, StringBuilder sb)
        {
            sb.AppendLine("System Attribute Pool:");
            var table = new Table("Index", "Value");
            for (int i = 0; i < script.SysAtrPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.SysAtrPool[i]);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintStaticSymbols(Script script, StringBuilder sb)
        {
            if (script.StaticSymbols == null) return;

            sb.AppendLine("Static Var Symbols:");
            var table = new Table("Name", "Set", "Var", "F6", "F8");
            for (int i = 0; i < script.StaticSymbols.Length; i++)
            {
                var item = script.StaticSymbols[i];
                table.AddRow(item.Name, item.Field2.ToString(), item.Var.ToString(),
                    item.Field6.ToString(), item.Field8.ToString());
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintLocalSymbols(Script script, StringBuilder sb)
        {
            if (script.LocalSymbols == null) return;

            sb.AppendLine("Local Var Symbols:");
            var table = new Table("Function", "Name", "F2", "Var", "F6", "F8");
            for (int i = 0; i < script.LocalSymbols.Length; i++)
            {
                var function = script.FunctionPool[i].Name;
                for (int j = 0; j < script.LocalSymbols[i].Length; j++)
                {
                    var item = script.LocalSymbols[i][j];
                    table.AddRow(function, item.Name, item.Field2.ToString(), item.Var.ToString(),
                        item.Field6.ToString(), item.Field8.ToString());
                }
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintArgsSymbols(Script script, StringBuilder sb)
        {
            if (script.ArgsSymbols == null) return;

            sb.AppendLine("Argument Symbols:");
            var table = new Table("Function", "Name", "F2", "Var", "F6", "F8");
            for (int i = 0; i < script.ArgsSymbols.Length; i++)
            {
                var function = script.FunctionPool[i].Name;
                for (int j = 0; j < script.ArgsSymbols[i].Length; j++)
                {
                    var item = script.ArgsSymbols[i][j];
                    table.AddRow(function, item.Name, item.Field2.ToString(), item.Var.ToString(),
                        item.Field6.ToString(), item.Field8.ToString());
                }
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintFilenameSymbols(Script script, StringBuilder sb)
        {
            if (script.FilenameSymbols == null) return;

            sb.AppendLine("Filename Symbols:");
            var table = new Table("Index", "Name");
            for (int i = 0; i < script.FilenameSymbols.Length; i++)
            {
                table.AddRow(i.ToString(), script.FilenameSymbols[i]);
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintLineSymbols(Script script, StringBuilder sb)
        {
            if (script.LineSymbols == null) return;

            sb.AppendLine("Line Symbols:");
            var table = new Table("F0", "F2", "Address");
            for (int i = 0; i < script.LineSymbols.Length; i++)
            {
                var item = script.LineSymbols[i];
                table.AddRow(item.Field0.ToString(), item.Field2.ToString(), item.Address.ToString("x6"));
            }

            sb.AppendLine(table.Print());
        }

        private static void PrintFunction(Script script, StringBuilder sb, int index)
        {
            var func = script.FunctionPool[index];
            sb.Append($"function {func.Name}");
            sb.Append("(");

            var symbols = script.ArgsSymbols?[index];

            bool isFirst = true;

            for (int i = 0; i < func.ArgsCount; i++)
            {
                if (!isFirst) sb.Append(", ");
                sb.Append(symbols?[i].Name);
                isFirst = false;
            }

            sb.AppendLine(")");

            if (func.LocalPoolIndex != ushort.MaxValue)
            {
                sb.AppendLine("Local Variable Pool:");
                var table = new Table("Idx", "Name", "Type", "Len", "Value");
                var locals = script.LocalPool[func.LocalPoolIndex];

                for (int i = 0; i < locals.Length; i++)
                {
                    table.AddRow(i.ToString(), locals[i].Name, locals[i].Type.ToString(), locals[i].Length.ToString(), locals[i].Value.ToString());
                }

                sb.AppendLine(table.Print());
            }

            sb.AppendLine("Code:");
            var codeTab = new Table("Addr", "opcode", "operand", "comment");
            foreach (var inst in script.Code[index])
            {
                codeTab.AddRow(inst.Address.ToString("x"), inst.Opcode.ToString(), inst.Operand, inst.Comment);
            }

            sb.AppendLine(codeTab.Print());
            sb.AppendLine();
        }
    }
}
