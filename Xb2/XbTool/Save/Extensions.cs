using System.Linq;
using XbTool.Types;

namespace XbTool.Save
{
    public static class Extensions
    {
        public static string GetName(this SDataBlade blade, BdatCollection tables)
        {
            if (blade.RareNameId != 0)
            {
                return tables.chr_bl_ms.GetItemOrNull(blade.RareNameId)?.name ?? blade.Name;
            }

            return tables.bld_bladename.GetItemOrNull(blade.CommonNameId)?.name ?? blade.Name;
        }

        public static string GetFieldSkillLevel(this SDataBlade blade, string name, BdatCollection tables)
        {
            FLD_FieldSkillList a = tables.FLD_FieldSkillList.First(x => x?._Name?.name == name);
            foreach (var skill in blade.FieldSkills)
            {
                if (skill.Id == a.Id) return skill.MaxLevel.ToString();
            }

            return "";
        }

        public static string GetBattleSkillLevel(this SDataBlade blade, string name, BdatCollection tables)
        {
            BTL_Skill_Bl a = tables.BTL_Skill_Bl.First(x => x?._Name?.name == name);
            foreach (var skill in blade.BattleSkills)
            {
                if (skill.Id == a.Id) return skill.MaxLevel.ToString();
            }

            return "";
        }

        public static (string type, int percent) GetStatMod(this SDataBlade blade)
        {
            if (blade.HpMaxRev != 0) return ("Max HP", blade.HpMaxRev);
            if (blade.StrengthRev != 0) return ("Strength", blade.StrengthRev);
            if (blade.PowEtherRev != 0) return ("Ether", blade.PowEtherRev);
            if (blade.DexRev != 0) return ("Dexterity", blade.DexRev);
            if (blade.AgilityRev != 0) return ("Agility", blade.AgilityRev);
            if (blade.LuckRev != 0) return ("Luck", blade.LuckRev);
            return ("None", 0);
        }
    }
}
