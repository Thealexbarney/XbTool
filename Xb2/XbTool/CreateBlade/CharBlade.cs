using System.Collections.Generic;
using XbTool.Types;

namespace XbTool.CreateBlade
{
    public class CharBlade
    {
        public BladeAttribute Attribute { get; set; }
        public Gender Gender { get; set; }
        public BladeWeapon WeaponType { get; set; }
        public Race QuestRace { get; set; }
        public int StatusId { get; set; }
        public BLD_BladeModelList Model { get; set; }
        public CHR_Bl ChrBlade { get; set; }
        public int ModelParts { get; set; }
        public CommonBladeType CommonBladeType { get; set; }
        public int NameId { get; set; }
        public string Name { get; set; }
        public int VoiceId { get; set; }
        public BTL_Bl_Personality Personality { get; set; }
        public BTL_Bl_KizunaLinkSet KizunaLinkSet { get; set; }
        public int Power { get; set; }
        public int OrbCount { get; set; }
        public StatusType StatusType { get; set; }
        public int StatusValue { get; set; }
        public int PhysicalArmor { get; set; }
        public int EtherArmor { get; set; }
        public int AffinityNodeCount { get; set; }
        public int CrownCount { get; set; }

        public List<Art> BArts { get; set; }
        public Art BArtEx { get; set; }
        public List<Art> NArts { get; set; }
        public List<Skill> BSkills { get; set; }
        public List<Skill> FSkills { get; set; }
        public ItemCategory[] FavCategories { get; set; }
        public ITM_FavoriteList[] FavItems { get; set; }
    }
}
