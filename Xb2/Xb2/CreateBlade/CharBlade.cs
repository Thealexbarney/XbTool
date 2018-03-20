using System.Collections.Generic;
using Xb2.Types;

namespace Xb2.CreateBlade
{
    public class CharBlade
    {
        public BladeAttribute Attribute { get; set; }
        public Gender Gender { get; set; }
        public BladeWeapon WeaponType { get; set; }
        public int DefaultWeaponId { get; set; }
        public Race QuestRace { get; set; }
        public int StatusId { get; set; }
        public BLD_BladeModelList Model { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string MotionName { get; set; }
        public string SePackName { get; set; }
        public int ModelParts { get; set; }
        public CommonBladeType CommonBladeType { get; set; }
        public int NameId { get; set; }
        public string Name { get; set; }
        public int VoiceId { get; set; }
        public int PersonalityId { get; set; }
        public int KizunaLinkSet { get; set; }
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
        public List<ItemCategory> FavCategories { get; set; }
        public List<Item> FavItems { get; set; }
    }
}
