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
            sb.AppendLine($"Driver: {tables.CHR_Dr[blade.Creator]._Name.name}");
            sb.AppendLine($"Type: {blade.CommonBladeType}");
            sb.AppendLine($"Element: {blade.Attribute}");
            sb.AppendLine($"Weapon Type: {tables.ITM_PcWpnType[blade.WeaponType]._Name.name}");
            sb.AppendLine($"Trust Points: {blade.TrustPoints}");
            sb.AppendLine($"Trust Rank: {tables.MNU_MsgTrustRank[(int)blade.TrustRank]._name.name}");
            sb.AppendLine($"AUX Core Slots: {blade.AuxCoreCount}");
            sb.AppendLine();

            sb.AppendLine($"Physical Defense: {blade.PArmor}%");
            sb.AppendLine($"Ether Defense: {blade.EArmor}%");
            if (blade.HpMaxRev != 0) sb.AppendLine($"Max HP Mod: {blade.HpMaxRev}%");
            if (blade.StrengthRev != 0) sb.AppendLine($"Strength Mod: {blade.StrengthRev}%");
            if (blade.PowEtherRev != 0) sb.AppendLine($"Ether Mod: {blade.PowEtherRev}%");
            if (blade.DexRev != 0) sb.AppendLine($"Dexterity Mod: {blade.DexRev}%");
            if (blade.AgilityRev != 0) sb.AppendLine($"Agility Mod: {blade.AgilityRev}%");
            if (blade.LuckRev != 0) sb.AppendLine($"Luck Mod: {blade.LuckRev}%");
            sb.AppendLine();

            for (int i = 0; i < 3; i++)
            {
                var sk = blade.BArts[i];
                if (sk.Id == 0) continue;
                sb.AppendLine($"Special {i + 1}: {tables.BTL_Arts_Bl.GetItemOrNull(sk.Id)?._Name.name} {sk.Level}/{sk.MaxLevel}");
            }
            sb.AppendLine($"Special 4: {tables.BTL_Arts_BlSp.GetItemOrNull(blade.BartExId)?._Name.name}");
            sb.AppendLine($"Special 4 Mod: {blade.BladeArtsExH}%");


            sb.AppendLine();

            for (int i = 0; i < 3; i++)
            {
                var sk = blade.NArts[i];
                if (sk.Id == 0) continue;
                sb.AppendLine($"Blade Art {i + 1}: {tables.BTL_Buff.GetItemOrNull(sk.Id)?._Name.name}");
            }
            sb.AppendLine();

            for (int i = 0; i < 3; i++)
            {
                var sk = blade.BattleSkills[i];
                if (sk.Id == 0) continue;
                sb.AppendLine($"Battle Skill {i + 1}: {tables.BTL_Skill_Bl.GetItemOrNull(sk.Id)?._Name.name} {sk.Level}/{sk.MaxLevel}");
            }
            sb.AppendLine();

            for (int i = 0; i < 3; i++)
            {
                var sk = blade.FieldSkills[i];
                if (sk.Id == 0) continue;
                sb.AppendLine($"Field Skill {i + 1}: {tables.FLD_FieldSkillList.GetItemOrNull(sk.Id)?._Name.name} {sk.Level}/{sk.MaxLevel}");
            }
            sb.AppendLine();

            sb.Append($"Favorite Category 1: {tables.menu_favorite_category.GetItemOrNull(blade.FavoriteCategory0 - 11)?.name}");
            if (blade.FavoriteCategory0 > 11 && !blade.FavoriteCategory0Revealed) sb.Append(" (Hidden)");
            sb.AppendLine();

            sb.Append($"Favorite Category 2: {tables.menu_favorite_category.GetItemOrNull(blade.FavoriteCategory1 - 11)?.name}");
            if (blade.FavoriteCategory1 > 11 && !blade.FavoriteCategory1Revealed) sb.Append(" (Hidden)");
            sb.AppendLine();

            sb.Append($"Favorite Item 1: {tables.ITM_FavoriteList.GetItemOrNull(blade.FavoriteItem0)?._Name?.name}");
            if (blade.FavoriteItem0 > 0 && !blade.FavoriteItem0Revealed) sb.Append(" (Hidden)");
            sb.AppendLine();

            sb.Append($"Favorite Item 2: {tables.ITM_FavoriteList.GetItemOrNull(blade.FavoriteItem1)?._Name.name}");
            if (blade.FavoriteItem1 > 0 && !blade.FavoriteItem1Revealed) sb.Append(" (Hidden)");
            sb.AppendLine();

            Console.WriteLine(sb.ToString());
        }
    }
}
