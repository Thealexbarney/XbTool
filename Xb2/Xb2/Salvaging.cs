using System.Linq;
using Xb2.CodeGen;
using Xb2.Types;

namespace Xb2
{
    public static class Salvaging
    {
        public static string Print(BdatCollection tables)
        {
            var sb = new Indenter();
            var pointList = tables.FLD_SalvagePointList;

            foreach (FLD_SalvagePointList point in pointList.Where(x => x.SalvagePointName > 0))
            {
                PrintPoint(point, sb);
            }

            return sb.ToString();
        }

        public static void PrintPoint(FLD_SalvagePointList point, Indenter sb)
        {
            sb.AppendLineAndIncrease("<div>");
            sb.AppendLine($"<h2>{point._SalvagePointName.name}</h2>");
            if (point.Condition != 0) sb.AppendLine($"<h3>Condition {point.Condition}</h3>");

            for (int i = 0; i < 4; i++)
            {
                sb.AppendLine($"<h4>{GetCylinderQuality(i)} Cylinder</h4>");
                PrintSalvageTable(point._SalvageTable[i], sb);
                sb.AppendLine("<br/>");
            }

            sb.DecreaseAndAppendLine("</div>");
        }

        public static void PrintSalvageTable(FLD_SalvageTable table, Indenter sb)
        {
            sb.AppendLineAndIncrease("<table>");
            for (int i = 0; i < 3; i++)
            {
                if (table._TresureTablePercent[i] == 0) continue;
                sb.AppendLine("<td>");
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
            sb.AppendLineAndIncrease("<table>");
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
                case 4: return "Wooden";
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
