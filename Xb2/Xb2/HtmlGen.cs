using System.IO;
using System.Linq;
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
            string bdatHtmlDir = Path.Combine(htmlDir, "bdat");

            PrintIndex(bdats, htmlDir);
            foreach (string tableName in bdats.Tables.Keys)
            {
                string outDir = bdatHtmlDir;
                string tableFilename = bdats[tableName].Filename;
                var indexPath = tableFilename == null ? "../index.html" : "../../index.html";

                var sb = new Indenter(2);
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLineAndIncrease("<html>");
                sb.AppendLineAndIncrease("<head>");
                sb.AppendLine("<meta charset=\"utf-8\" />");
                sb.AppendLine($"<title>{tableName}</title>");
                sb.AppendLineAndIncrease("<script>");
                sb.AppendLine(JsOpenAll);
                sb.DecreaseAndAppendLine("</script>");
                sb.DecreaseAndAppendLine("</head>");

                sb.AppendLineAndIncrease("<body>");
                sb.AppendLine($"<a href=\"{indexPath}\">Return to BDAT index</a><br/>");
                sb.AppendLine("<input type=\"button\" value=\"Open all references\" onclick=\"openAll(true)\" />");
                sb.AppendLine("<input type=\"button\" value=\"Close all references\" onclick=\"openAll(false)\" />");
                PrintTable(bdats, info, tableName, sb);
                sb.DecreaseAndAppendLine("</body>");
                sb.DecreaseAndAppendLine("</html>");
                
                if (tableFilename != null)
                {
                    outDir = Path.Combine(outDir, tableFilename);
                }

                string filename = Path.Combine(outDir, tableName + ".html");
                Directory.CreateDirectory(outDir);
                File.WriteAllText(filename, sb.ToString());
            }
        }

        public static void PrintIndex(BdatStringCollection bdats, string htmlDir)
        {
            string bdatHtmlDir = Path.Combine(htmlDir, "bdat");
            var sb = new Indenter(2);
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLineAndIncrease("<html>");
            sb.AppendLineAndIncrease("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>Xenoblade 2 BDAT Index</title>");
            sb.DecreaseAndAppendLine("</head>");

            sb.AppendLineAndIncrease("<body>");

            var grouped = bdats.Tables.Values.GroupBy(x => x.Filename).OrderBy(x => x.Key ?? "zzz");

            foreach (var group in grouped)
            {
                sb.AppendLine($"<h2>{group.Key ?? "Other"}</h2>");
                var subDir = Path.Combine("bdat", group.Key ?? string.Empty);
                foreach (var table in group.OrderBy(x => x.Name))
                {
                    var path = Path.Combine(subDir, table.Name) + ".html";
                    sb.AppendLine($"<a href=\"{path}\">{table.Name}</a><br/>");
                }
            }

            sb.DecreaseAndAppendLine("</body>");
            sb.DecreaseAndAppendLine("</html>");

            var filename = Path.Combine(htmlDir, "index.html");
            File.WriteAllText(filename, sb.ToString());
        }

        public static void PrintTable(BdatStringCollection tables, BdatInfo info, string tableName, Indenter sb)
        {
            BdatStringTable table = tables[tableName];

            sb.AppendLineAndIncrease("<table border=\"1\">");
            sb.AppendLineAndIncrease("<thead>");
            sb.AppendLineAndIncrease("<tr>");
            sb.AppendLine("<th>ID</th>");
            sb.AppendLine("<th>Referenced By</th>");

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
                sb.AppendLineAndIncrease("<td>");

                if (item.ReferencedBy.Count > 0)
                {
                    sb.AppendLineAndIncrease("<details>");
                    sb.AppendLine($"<summary>{item.ReferencedBy.Count} refs</summary>");

                    foreach (var a in item.ReferencedBy)
                    {
                        var link = GetLink(table, tables[a.Table], a.Id.ToString());
                        string display = a.Id.ToString();

                        if (info.DisplayFields.TryGetValue(a.Table, out var displayField))
                        {
                            var child = BdatStringTools.ReadValue(a.Table, a.Id, displayField, tables, info);
                            if (!string.IsNullOrWhiteSpace(child.value))
                            {
                                display = child.value;
                            }
                        }

                        sb.AppendLine($"<a href=\"{link}\">{a.Table}#{display}</a>");
                    }

                    sb.DecreaseAndAppendLine("</details>");
                }

                sb.DecreaseAndAppendLine("</td>");

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

        public static readonly string JsOpenAll =
            "function openAll(open) {\r\n    document.querySelectorAll(\"details\").forEach(function(details) {\r\n        details.open = open;\r\n    });\r\n}";
    }
}
