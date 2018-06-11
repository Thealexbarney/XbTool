using System.Linq;
using XbTool.CodeGen;
using XbTool.Types;

namespace XbTool.Salvaging
{
    public static class SalvagingTable
    {
        public static string Print(BdatCollection tables)
        {
            var sb = new Indenter();
            var pointList = tables.FLD_SalvagePointList;

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLineAndIncrease("<html>");
            sb.AppendLineAndIncrease("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>Xenoblade 2 Salvaging Points</title>");
            sb.AppendLine("<style>.tbox td{vertical-align: top;} table.BtnChallenge td,th{border: 1px solid;}table{margin:0;padding:0;border-collapse: collapse;}</style>");
            sb.DecreaseAndAppendLine("</head>");

            sb.AppendLineAndIncrease("<body>");

            foreach (FLD_SalvagePointList point in pointList.Where(x => x.SalvagePointName > 0))
            {
                PrintPoint(point, sb);
            }

            sb.DecreaseAndAppendLine("</body>");
            sb.DecreaseAndAppendLine("</html>");

            return sb.ToString();
        }

        public static void PrintPoint(FLD_SalvagePointList point, Indenter sb)
        {
            sb.AppendLineAndIncrease("<div>");
            sb.AppendLine($"<h2>{point._SalvagePointName.name}</h2>");
            if (point.Condition != 0) sb.AppendLine($"<h3>Condition {point.Condition}</h3>");

            sb.AppendLine("<table class=\"BtnChallenge\">");
            sb.AppendLine("<tr><th>Button</th><th>Speed</th><th>Outer Ring</th><th>Inner Ring</th></tr>");
            for (int i = 0; i < 3; i++)
            {
                var chal = point._BtnChallenge[i];
                sb.AppendLine($"<tr><td>{chal._BtnType1}</td><td>{chal.Speed}</td><td>{chal._Param1.PushRange}</td><td>{chal._Param1.PushSweetRange}</td></tr>");
            }

            sb.AppendLine("</table>");

            for (int i = 0; i < 4; i++)
            {
                sb.AppendLine($"<h4>{GetCylinderQuality(i)} Cylinder<br/>");
                sb.AppendLine($"Base treasure chance: {point._SalvageTable[i].TresureBoxHit / 100.0}%</h4>");
                PrintSalvageTable(point._SalvageTable[i], sb);
            }

            sb.DecreaseAndAppendLine("</div>");
        }

        public static void PrintSalvageTable(FLD_SalvageTable table, Indenter sb)
        {
            sb.AppendLineAndIncrease("<table class=\"tbox\">");
            for (int i = 0; i < 3; i++)
            {
                if (table._TresureTablePercent[i] == 0) continue;
                sb.AppendLine("<td>");
                sb.AppendLineAndIncrease("<table>");
                sb.AppendLine("<tr><td colspan=\"2\">");
                sb.AppendLine($"Treasure Box {i + 1} {table._TresureTablePercent[i] / 10000.0:P}<br/>");
                PrintItemSet(table._TresureTable[i], sb);
                sb.AppendLine("</td>");
            }
            sb.DecreaseAndAppendLine("</table>");
        }

        public static void PrintItemSet(FLD_SalvageItemSet table, Indenter sb)
        {
            if (table.RSC_ID != 0) sb.AppendLine($"{GetTBoxType(table.RSC_ID)} treasure box<br/>");
            if (table.goldMin != 0)
            {
                sb.AppendLine($"{table.goldMin} - {table.goldMax} Gold<br/>");
            }

            if (table.randitmPopMin == table.randitmPopMax)
            {
                sb.AppendLine($"{table.randitmPopMin} Items<br/>");
            }
            else
            {
                sb.AppendLine($"{table.randitmPopMin} - {table.randitmPopMax} Items<br/>");
            }

            sb.AppendLine("<br/>");
            sb.AppendLine("</td></tr>");

            for (int i = 0; i < 8; i++)
            {
                if (table._itmID[i] == null) continue;
                string itemName = GetItemName(table._itmID[i]);
                sb.AppendLine($"<tr><td>{itemName}</td><td>{table._itmPer[i] / 100.0:P}</td></tr>");
            }
            sb.DecreaseAndAppendLine("</table>");

        }

        public static string GetCylinderQuality(int id)
        {
            switch (id)
            {
                case 0: return "Normal";
                case 1: return "Silver";
                case 2: return "Golden";
                case 3: return "Premium";
                default: return string.Empty;
            }
        }

        public static string GetTBoxType(int id)
        {
            switch (id)
            {
                case 4: return "Silver";
                case 5: return "Red";
                case 6: return "White";
                default: return string.Empty;
            }
        }

        public static string GetItemName(object item)
        {
            switch (item)
            {
                case ITM_CollectionList c: return c._Name.name;
                case ITM_TresureList t: return t._Name.name;
                case ITM_PreciousList p: return p._Name.name;
                default: return string.Empty;
            }
        }
    }
}
