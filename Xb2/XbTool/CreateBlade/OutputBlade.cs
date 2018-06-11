using System.Text;

namespace XbTool.CreateBlade
{
    public static class OutputBlade
    {
        public static string GetString(CharBlade blade)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {blade.Name}");
            sb.AppendLine($"Element: {blade.Attribute}");
            sb.AppendLine($"Weapon Type: {blade.WeaponType}");
            sb.AppendLine($"Gender: {blade.Gender}");
            sb.AppendLine($"Race: {blade.QuestRace}");
            sb.AppendLine($"Type: {blade.CommonBladeType}");

            sb.AppendLine();
            sb.AppendLine($"Power: {blade.Power}");
            sb.AppendLine($"Affinity Chart Nodes: {blade.AffinityNodeCount}");
            sb.AppendLine($"Crowns: {blade.CrownCount}");

            sb.AppendLine();
            sb.AppendLine($"AUX Core Slots: {blade.OrbCount}");
            sb.AppendLine($"Physical Armor Mod: {blade.PhysicalArmor}%");
            sb.AppendLine($"Ether Armor Mod: {blade.EtherArmor}%");
            sb.AppendLine($"Stat Mod: {blade.StatusType} {blade.StatusValue}%");

            sb.AppendLine();
            sb.AppendLine($"Voice ID: {blade.VoiceId}");
            sb.AppendLine($"Personality ID: {blade.Personality.Id}");

            sb.AppendLine();
            for (int i = 0; i < blade.FavCategories?.Length; i++)
            {
                sb.AppendLine($"Favorite Category {i + 1}: {blade.FavCategories[i].ToString()}");
            }

            for (int i = 0; i < blade.FavItems?.Length; i++)
            {
                sb.AppendLine($"Favorite Item {i + 1}: {blade.FavItems[i]._Name.name}");
            }

            sb.AppendLine();
            for (int i = 0; i < blade.BArts?.Count; i++)
            {
                sb.AppendLine($"Special {i + 1}: {blade.BArts[i].Name} Lv.{blade.BArts[i].MaxLevel}");
            }
            sb.AppendLine($"Special 4: {blade.BArtEx?.Name}");
            sb.AppendLine($"Special 4 Mod: {blade.BArtEx?.BArtExRev * 0.01}");

            sb.AppendLine();
            for (int i = 0; i < blade.NArts?.Count; i++)
            {
                Art art = blade.NArts[i];
                sb.AppendLine($"Blade Art {i + 1}: {art.Name}");
            }

            sb.AppendLine();
            for (int i = 0; i < blade.BSkills?.Count; i++)
            {
                sb.AppendLine($"Battle Skill {i + 1}: {blade.BSkills[i].Name} Lv.{blade.BSkills[i].MaxLevel}");
            }

            sb.AppendLine();
            for (int i = 0; i < blade.FSkills?.Count; i++)
            {
                sb.AppendLine($"Field Skill {i + 1}: {blade.FSkills[i].Name} Lv.{blade.FSkills[i].MaxLevel}");
            }

            return sb.ToString();
        }
    }
}
