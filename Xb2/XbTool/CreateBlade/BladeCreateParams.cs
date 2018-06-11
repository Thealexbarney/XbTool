using System.Diagnostics;

namespace XbTool.CreateBlade
{
    public class BladeCreateParams
    {
        public CrystalType Crystal { get; set; }
        public int BoosterCount { get; set; }
        public IdeaCategory IdeaCategory { get; set; }
    }

    public class DriverInfo
    {
        public int Level { get; set; }
        public int[] IdeaLevels { get; set; } = new int[4];
    }

    [DebuggerDisplay("{Name} Lv {MaxLevel}")]
    public class Art
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public int BArtExRev { get; set; }
    }

    [DebuggerDisplay("{Name} Lv {MaxLevel}")]
    public class Skill
    {
        public int Id { get; }
        public string Name { get; }
        public int MaxLevel { get; }

        public Skill(int id, string name, int maxLevel)
        {
            Id = id;
            Name = name;
            MaxLevel = maxLevel;
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum CrystalType
    {
        Common = 45011,
        Rare,
        Legendary
    }

    public enum IdeaCategory
    {
        Bravery,
        Truth,
        Compassion,
        Justice
    }

    public enum BladeWeapon
    {
        AegisSword = 1,
        CatalystScimitar,
        TwinRings,
        DrillShield,
        MechArms,
        VariableSaber,
        Whipswords,
        BigBangEdge,
        DualScythes,
        Greataxe,
        Megalance,
        EtherCannon,
        ShieldHammer,
        ChromaKatana,
        Bitball,
        KnuckleClaws,
        Broadsword,
        Nodachi,
        SwordTonfa,
        CalamityScythe,
        CobraBardiche,
        InfinityFans,
        BrilliantTwinblades,
        DecimationCannon,
        RockrendingGauntlets
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        None = 4
    }

    public enum Race
    {
        Humanoid = 1,
        Animal = 2
    }

    public enum Role
    {
        Tank = 1,
        Attacker,
        Healer
    }

    public enum StatusType
    {
        MaxHP,
        Strength,
        Ether,
        Dexterity,
        Agility,
        Luck
    }

    public enum ItemCategory
    {
        StapleFoods = 12,
        Vegetables,
        Meat,
        Seafood,
        Desserts,
        Drinks,
        Instruments,
        Art,
        Literature,
        BoardGames,
        Cosmetics,
        Textiles
    }
}
