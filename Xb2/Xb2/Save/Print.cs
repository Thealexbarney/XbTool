using System;
using System.Text;
using Xb2.Types;

namespace Xb2.Save
{
    public static class Print
    {
        public static void PrintSave(SDataSave save, BdatCollection tables)
        {
            var delim = new string('=', 25);

            foreach (SDataBlade blade in save.GameSave.Blades)
            {
                if (blade.BladeId == 0) continue;
                Console.WriteLine();

                PrintBlade(blade, tables);

                Console.WriteLine(delim);

            }
        }

        public static void PrintBlade(SDataBlade blade, BdatCollection tables)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Blade ID: {blade.BladeId}");
            sb.AppendLine($"Name: {blade.GetName(tables)}");
            sb.AppendLine($"Favorite Category 1: {tables.menu_favorite_category.GetItemOrNull(blade.FavoriteCategory0 - 11)?.name}");
            sb.AppendLine($"Favorite Category 2: {tables.menu_favorite_category.GetItemOrNull(blade.FavoriteCategory1 - 11)?.name}");
            sb.AppendLine($"Favorite Item 1: {tables.ITM_FavoriteList.GetItemOrNull(blade.FavoriteItem0)?._Name?.name}");
            sb.AppendLine($"Favorite Item 2: {tables.ITM_FavoriteList.GetItemOrNull(blade.FavoriteItem1)?._Name.name}");

            Console.WriteLine(sb.ToString());
        }
    }
}
