using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.CodeGen;

namespace XbTool
{
    public static class HtmlGen
    {
        public static void PrintSeparateTables(BdatStringCollection bdats, string htmlDir)
        {
            string bdatHtmlDir = Path.Combine(htmlDir, "bdat");
            Directory.CreateDirectory(bdatHtmlDir);

            if (bdats.Game == Game.XB2) PrintIndex(bdats, htmlDir);
            PrintBdatIndex(bdats, bdatHtmlDir);
            foreach (string tableName in bdats.Tables.Keys)
            {
                string outDir = bdatHtmlDir;
                string tableFilename = bdats[tableName].Filename;
                var indexPath = tableFilename == null ? "index.html" : "../index.html";

                var sb = new Indenter(2);
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLineAndIncrease("<html>");
                sb.AppendLineAndIncrease("<head>");
                sb.AppendLine("<meta charset=\"utf-8\" />");
                sb.AppendLine($"<title>{tableName}</title>");
                sb.AppendLineAndIncrease("<style>");
                sb.AppendLine(CssSticky);
                sb.AppendLine(CssSortable);
                sb.DecreaseAndAppendLine("</style>");
                sb.DecreaseAndAppendLine("</head>");

                sb.AppendLineAndIncrease("<body>");
                sb.AppendLine($"<a href=\"{indexPath}\">Return to BDAT index</a><br/>");
                sb.AppendLine("<input type=\"button\" value=\"Open all references\" onclick=\"openAll(true)\" />");
                sb.AppendLine("<input type=\"button\" value=\"Close all references\" onclick=\"openAll(false)\" />");
                PrintTable(bdats[tableName], sb);
                sb.AppendLineAndIncrease("<script>");
                sb.AppendLine(JsOpenAll);
                sb.AppendLine(JsSortable);
                sb.AppendLine(JsAnchor);
                sb.DecreaseAndAppendLine("</script>");
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

        public static void PrintBdatIndex(BdatStringCollection bdats, string htmlDir)
        {
            var sb = new Indenter(2);
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLineAndIncrease("<html>");
            sb.AppendLineAndIncrease("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            var name = bdats.Game == Game.XB2 ? "2" : "X";
            sb.AppendLine($"<title>Xenoblade {name} Data Tables</title>");
            sb.DecreaseAndAppendLine("</head>");

            sb.AppendLineAndIncrease("<body>");

            var grouped = bdats.Tables.Values.GroupBy(x => x.Filename).OrderBy(x => x.Key ?? "zzz");

            foreach (var group in grouped)
            {
                sb.AppendLine($"<h2>{group.Key ?? "Other"}</h2>");
                var subDir = group.Key ?? string.Empty;
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

        public static void PrintIndex(BdatStringCollection bdats, string htmlDir)
        {
            var sb = new Indenter(2);
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLineAndIncrease("<html>");
            sb.AppendLineAndIncrease("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>Xenoblade 2</title>");
            sb.DecreaseAndAppendLine("</head>");

            sb.AppendLineAndIncrease("<body>");
            sb.AppendLine("<h1>Xenoblade 2 data tables</h1>");
            sb.AppendLine($"<p>{IndexText}</p>");
            sb.AppendLine($"<h2><a href=\"bdat\\index.html\">Complete table list</a></h2>");

            string prefix = bdats.Game.ToString().ToLower();
            if (!File.Exists($"{prefix}_tableDisplay.csv")) return;
            using (var stream = new FileStream($"{prefix}_tableDisplay.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
            {
                IEnumerable<BdatFriendlyInfo> csv = new CsvReader(reader).GetRecords<BdatFriendlyInfo>();
                var grouped = csv.GroupBy(x => x.Group).OrderBy(x => x.Key);

                foreach (var group in grouped)
                {
                    sb.AppendLine($"<h2>{group.Key ?? "Other"}</h2>");

                    foreach (var tableInfo in group.OrderBy(x => x.Display))
                    {
                        var table = bdats[tableInfo.TableName];
                        var path = Path.Combine("bdat", table.Filename ?? "", table.Name) + ".html";
                        sb.AppendLine($"<a href=\"{path}\">{tableInfo.Display}</a><br/>");
                    }
                }
            }
            sb.DecreaseAndAppendLine("</body>");
            sb.DecreaseAndAppendLine("</html>");

            var filename = Path.Combine(htmlDir, "index.html");
            File.WriteAllText(filename, sb.ToString());
        }

        public static void PrintTable(BdatStringTable table, Indenter sb)
        {
            sb.AppendLineAndIncrease("<table class=\"sortable\">");
            sb.AppendLineAndIncrease("<thead>");
            sb.AppendLineAndIncrease("<tr id=\"header\">");
            sb.AppendLine("<th class=\" dir-d \">ID</th>");
            sb.AppendLine("<th>Referenced By</th>");

            foreach (BdatMember member in table.Members)
            {
                if (member.Metadata?.Type == BdatFieldType.Hide) continue;

                var sticky = table.DisplayMember == member.Name;
                var cellTag = $"<th{(sticky ? " class=\"side\"" : "")}";

                switch (member.Type)
                {
                    case BdatMemberType.Scalar:
                    case BdatMemberType.Flag:
                        sb.AppendLine($"{cellTag}>{member.Name}</th>");
                        break;
                    case BdatMemberType.Array:
                        sb.AppendLine($"{cellTag} colspan=\"{member.ArrayCount}\">{member.Name}</th>");
                        break;
                }
            }

            sb.DecreaseAndAppendLine("</tr>");
            sb.DecreaseAndAppendLine("</thead>");

            foreach (BdatStringItem item in table.Items.Where(x => x != null))
            {
                sb.AppendLineAndIncrease($"<tr id=\"{item.Id}\">");
                sb.AppendLine($"<td>{item.Id}</td>");
                sb.AppendLineAndIncrease("<td>");

                if (item.ReferencedBy.Count > 0)
                {
                    sb.AppendLineAndIncrease("<details>");
                    sb.AppendLine($"<summary>{item.ReferencedBy.Count} refs</summary>");

                    foreach (BdatStringItem a in item.ReferencedBy.OrderBy(x => x.Table.Name).ThenBy(x => x.Id))
                    {
                        string link = GetLink(table, a.Table, a.Id.ToString());
                        string display = (string)a.Display?.Display ?? a.Id.ToString();

                        if (string.IsNullOrWhiteSpace(display))
                        {
                            display = a.Id.ToString();
                        }

                        sb.AppendLine($"<a href=\"{link}\">{a.Table.Name}#{display}</a>");
                    }

                    sb.DecreaseAndAppendLine("</details>");
                }

                sb.DecreaseAndAppendLine("</td>");

                foreach (BdatStringValue value in item.Values.Values)
                {
                    BdatMember member = value.Member;
                    if (member.Metadata?.Type == BdatFieldType.Hide) continue;

                    var sticky = value.Parent.Display == value;
                    var cellTag = $"<td{(sticky ? " class=\"side\"" : "")}>";
                    switch (member.Type)
                    {
                        case BdatMemberType.Scalar:
                        case BdatMemberType.Flag:
                            PrintValue(value, cellTag);

                            break;
                        case BdatMemberType.Array:
                            foreach (var arrValue in value.Array)
                            {
                                PrintValue(arrValue, cellTag);
                            }

                            break;
                    }
                }

                sb.DecreaseAndAppendLine("</tr>");
            }

            sb.DecreaseAndAppendLine("</table>");

            void PrintValue(BdatStringValue value, string cellTag)
            {
                BdatStringItem child = value.Reference;
                if (child != null)
                {
                    string display = child.Display?.DisplayString;
                    if (string.IsNullOrWhiteSpace(display))
                    {
                        display = child.Id.ToString();
                    }

                    var link = GetLink(table, child.Table, child.Id.ToString());
                    sb.AppendLine($"{cellTag}<a href=\"{link}\">{display}</td></a>");
                }
                else
                {
                    sb.AppendLine($"{cellTag}{value.DisplayString}</td>");
                }
            }
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

        public static readonly string IndexText = "This is a collection of all the data tables in Xenoblade 2.<br/>" +
                                                  "A list of commonly-used tables can be found below, along with a link to the complete list of tables.";
        public static readonly string JsOpenAll =
            "function openAll(open) {" +
            "\r\n        document.querySelectorAll(\"details\").forEach(function(details) {" +
            "\r\n          details.open = open;" +
            "\r\n        });" +
            "\r\n      }";

        public static readonly string CssSticky =
            "th {position:sticky; top:-1px; background-color:#F0F0F0;}" +
            "\r\n      table,th,td {border:1px solid black; border-collapse:collapse;}" +
            "\r\n      .side {position:sticky; left:-1px; background-color:#F0F0F0;}" +
            "\r\n      th.side {z-index:3}";

        public static readonly string CssSortable =
            ".sortable tbody tr:nth-child(odd){background:#F5F5F5}" +
            "\r\n      .sortable th{background:#e4e4e4;cursor:pointer;white-space:nowrap;vertical-align:middle}" +
            "\r\n      .sortable th.dir-d::after{content:\" \\025BE\";vertical-align:inherit}" +
            "\r\n      .sortable th.dir-u::after{content:\" \\025B4\";vertical-align:inherit}" +
            "\r\n      :target td {background-color:#CCC !important;}";

        public static readonly string JsSortable =
            "document.addEventListener(\"click\",function(e){var a=\" dir-d \",r=\" dir-u \",n=/ dir-(u|d) /,l=e.target;function o(e,a){e.className=e.className.replace(n,\"\")+(a||\"\")}if(\"TH\"==l.nodeName){var c=l.parentNode.parentNode.parentNode;if(/\\bsortable\\b/.test(c.className)){for(var t=0,d=l.parentNode.cells,i=0;i<d.length&&d[i]!==l;i++)t+=d[i].colSpan,o(d[i]);var s=a;-1!==l.className.indexOf(a)&&(s=r),o(l,s);var N=c.tBodies[0],p=[].slice.call(N.cloneNode(!0).rows,0),f=s==r;p.sort(function(e,a){if(e=e.cells[t].innerText,a=a.cells[t].innerText,f){var r=e;e=a,a=r}return isNaN(e-a)?e.localeCompare(a):e-a});var v=N.cloneNode();for(i in p)v.appendChild(p[i]);c.replaceChild(v,N)}}});";

        public static readonly string JsAnchor =
            "function offsetAnchor() {\r\n        if(location.hash.length !== 0) {\r\n          window.scrollTo(window.scrollX, window.scrollY - document.getElementById(\'header\').clientHeight);\r\n        }\r\n      }\r\n      window.addEventListener(\"hashchange\", offsetAnchor);\r\n      window.setTimeout(offsetAnchor, 1);";
    }

    public class BdatFriendlyInfo
    {
        public string Group { get; set; }
        public string TableName { get; set; }
        public string Display { get; set; }
    }
}
