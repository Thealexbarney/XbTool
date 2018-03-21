using System.IO;
using Xb2.Bdat;
using Xb2.BdatString;
using Xb2.CodeGen;

namespace Xb2
{
    public static class HtmlGen
    {
        public static void OutputHtml(BdatStringCollection bdats, BdatInfo info, string htmlDir)
        {
            PrintSeparateTables(bdats, info, htmlDir);
        }

        public static void PrintSeparateTables(BdatStringCollection bdats, BdatInfo info, string htmlDir)
        {
            foreach (string tableName in bdats.Tables.Keys)
            {
                var sb = new Indenter(2);
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLineAndIncrease("<html>");
                sb.AppendLineAndIncrease("<head>");
                sb.AppendLine("<meta charset=\"utf-8\" />");
                sb.AppendLine($"<title>{tableName}</title>");
                sb.DecreaseAndAppendLine("</head>");

                sb.AppendLineAndIncrease("<body>");
                PrintTable(bdats, info, tableName, sb);
                sb.DecreaseAndAppendLine("</body>");
                sb.DecreaseAndAppendLine("</html>");

                string outDir = htmlDir;
                string tableFilename = bdats[tableName].Filename;

                if (tableFilename != null)
                {
                    outDir = Path.Combine(outDir, tableFilename);
                }

                string filename = Path.Combine(outDir, tableName + ".html");
                Directory.CreateDirectory(outDir);
                File.WriteAllText(filename, sb.ToString());
            }
        }

        public static void PrintTable(BdatStringCollection tables, BdatInfo info, string tableName, Indenter sb)
        {
            BdatStringTable table = tables[tableName];

            sb.AppendLineAndIncrease("<table border=\"1\">");
            sb.AppendLineAndIncrease("<thead>");
            sb.AppendLineAndIncrease("<tr>");
            sb.AppendLine("<th>ID</th>");

            foreach (BdatMember member in table.Members)
            {
                if (info.FieldInfo.TryGetValue((tableName, member.Name), out var field))
                {
                    if (field.Type == BdatFieldType.Hide) continue;
                }
                switch (member.Type)
                {
                    case BdatMemberType.Scalar:
                    case BdatMemberType.Flag:
                        sb.AppendLine($"<th>{member.Name}</th>");
                        break;
                    case BdatMemberType.Array:
                        sb.AppendLine($"<th colspan=\"{member.ArrayCount}\">{member.Name}</th>");
                        break;
                }
            }

            sb.DecreaseAndAppendLine("</tr>");
            sb.DecreaseAndAppendLine("</thead>");
            int id = table.BaseId;

            foreach (BdatStringItem item in table.Items)
            {
                sb.AppendLineAndIncrease($"<tr id=\"{id}\">");
                sb.AppendLine($"<td>{id}</td>");

                foreach (BdatMember member in table.Members)
                {
                    if (info.FieldInfo.TryGetValue((tableName, member.Name), out var field))
                    {
                        if (field.Type == BdatFieldType.Hide) continue;
                    }

                    switch (member.Type)
                    {
                        case BdatMemberType.Scalar:
                        case BdatMemberType.Flag:
                            var val = BdatStringTools.ReadValue(tableName, id, member.Name, tables, info);
                            if (val.childTable != null)
                            {
                                var link = GetLink(table, tables[val.childTable], val.childId);
                                sb.AppendLine($"<td><a href=\"{link}\">{val.value}</td></a>");
                            }
                            else
                            {
                                sb.AppendLine($"<td>{val.value}</td>");
                            }
                            break;
                        case BdatMemberType.Array:
                            var arr = (string[])item.Values[member.Name];
                            foreach (string value in arr)
                            {
                                sb.AppendLine($"<td>{value}</td>");
                            }
                            break;
                    }
                }

                sb.DecreaseAndAppendLine("</tr>");
                id++;
            }

            sb.DecreaseAndAppendLine("</table>");
        }

        public static string GetLink(BdatStringTable table, BdatStringTable childTable, string childId)
        {
            string path = string.Empty;
            if (table.Filename == null && childTable.Filename != null)
            {
                path = $"{childTable.Filename}/";
            }

            if (table.Filename != null && childTable.Filename == null)
            {
                path = "../";
            }

            if (table.Filename != null && childTable.Filename != null && table.Filename != childTable.Filename)
            {
                path = $"../{childTable.Filename}/";
            }

            return $"{path}{childTable.Name}.html#{childId}";
        }
    }
}
