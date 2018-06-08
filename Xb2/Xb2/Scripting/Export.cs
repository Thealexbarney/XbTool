using System.Text;

namespace Xb2.Scripting
{
    public static class Export
    {
        public static string PrintScript(Script script)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Sections:");
            var table = new Table("Name", "Items", "Offset", "Length");
            foreach (Section section in script.Sections)
            {
                table.AddRow(section.Name, section.Count.ToString(), section.Offset.ToString("x6"), section.Length.ToString("x6"));
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("Id Pool:");
            table = new Table("Index", "Value");
            for (int i = 0; i < script.IdPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.IdPool[i]);
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("Function Pool:");
            table = new Table("Index", "Name", "Start", "End");
            for (int i = 0; i < script.FunctionPool.Length; i++)
            {
                var func = script.FunctionPool[i];
                table.AddRow(i.ToString(), func.Name, func.Start.ToString("x6"), func.End.ToString("x6"));
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("Function Initial Stacks:");
            for (int i = 0; i < script.FunctionPool.Length; i++)
            {
                var func = script.FunctionPool[i];
                if (func.LocalPoolIndex == ushort.MaxValue) continue;

                table = new Table("Type", "Len", "Value", "F8");
                var items = script.LocalPool[func.LocalPoolIndex];

                for (int j = 0; j < items.Length; j++)
                {
                    table.AddRow(items[j].Type.ToString(), items[j].Length.ToString(), items[j].Value.ToString(), items[j].Field8.ToString());
                }

                sb.AppendLine(func.Name);
                sb.AppendLine(table.Print());
            }

            sb.AppendLine("String Pool:");
            table = new Table("Index", "Value");
            for (int i = 0; i < script.StringPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.StringPool[i]);
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("Plugin Imports:");
            table = new Table("Index", "Plugin", "Function");
            for (int i = 0; i < script.Plugins.Length; i++)
            {
                table.AddRow(i.ToString(), script.Plugins[i].Plugin, script.Plugins[i].Function);
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("OC Imports:");
            table = new Table("Index", "Name");
            for (int i = 0; i < script.OcImports.Length; i++)
            {
                table.AddRow(i.ToString(), script.OcImports[i]);
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("Static Variables:");
            table = new Table("Type", "Len", "Value", "F8");
            for (int i = 0; i < script.StaticVars.Length; i++)
            {
                var item = script.StaticVars[i];
                table.AddRow(item.Type.ToString(), item.Length.ToString(), item.Value.ToString(), item.Field8.ToString());
            }
            sb.AppendLine(table.Print());

            sb.AppendLine("System Attribute Pool:");
            table = new Table("Index", "Value");
            for (int i = 0; i < script.SysAtrPool.Length; i++)
            {
                table.AddRow(i.ToString(), script.SysAtrPool[i]);
            }
            sb.AppendLine(table.Print());

            return sb.ToString();
        }
    }
}
