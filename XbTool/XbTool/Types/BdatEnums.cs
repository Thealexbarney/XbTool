// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System;

namespace XbTool.Types
{
    public enum ConditionType
    {
        Scenario = 1,
        Quest,
        Environment,
        Flag,
        Item,
        Party,
        Idea,
        Level,
        Achievement,
        FieldSkill
    }

    public enum PartyConditionType
    {
        InParty = 0, // In total party, not in merc
        InActiveParty, // In active party of 5
        IsLeader,
        BattleParty, // In battle party of 3
        IsMercTeamLeader,
        InPartyOrMerc,
        DriverInParty,
        IsReleased,
        T8
    }

    public enum BladeActiveType
    {
        ActivateUnuse,
        ActivateParty,
        ActivateMercenaryTeam
    }

    public enum TaskType
    {
        Battle = 1,
        T2,
        Collect,
        UseItem,
        ReachPlace,
        Talk,
        T7,
        Gimmick,
        Mercenary,
        QuestCondition,
        UseFieldSkill,
        StatCount
    }

    public enum IdeaCategory
    {
        Bravery,
        Truth,
        Compassion,
        Justice
    }

    [Flags]
    public enum IdeaCategoryBits
    {
        Bravery = 1 << 0,
        Truth = 1 << 1,
        Compassion = 1 << 2,
        Justice = 1 << 3
    }

    [Flags]
    public enum FieldSkillCategory
    {
        Collection = 1 << 0,
        Elemental = 1 << 1,
        Mercenary = 1 << 2,
        Rare = 1 << 3
    }

    public enum ButtonType
    {
        A = 1,
        B,
        X,
        Y,
        Random
    }

    public enum LandmarkType
    {
        Landmark,
        SecretArea,
        Location
    }

    public enum ShopType
    {
        Normal,
        Exchange,
        Inn,
        AuxCore
    }

    public enum ItemType
    {
        PcWpnChip = 1,
        PcEquip = 2,
        EquipOrb = 3,
        PcWpn = 4,
        Salvage = 5,
        Precious = 6,
        CollectionList = 7,
        Tresure = 8,
        EmptyOrb = 9,
        Favorite = 10,
        CrystalList = 11,
        Booster = 12,
        HealPot = 13,
        Info = 14,
        Event = 15,
        HanaRole = 16,
        HanaAtr = 17,
        HanaArtsEnh = 18,
        HanaNArtsSet = 19,
        HanaAssist = 20
    }

    public enum Weather
    {
        Overcast = 1,
        Lightning,
        Rain,
        Thunderstorm,
        Storm,
        Fog,
        Snow,
        Sandstorm,
        CrystalSquall,
        SurfaceHeat,
        NightIncense,
        Overcast2,
        Aurora,
        CloudSeaMist
    }

    [Flags]
    public enum WeatherBits
    {
        Overcast = 1 << 0,
        Lightning = 1 << 1,
        Rain = 1 << 2,
        Thunderstorm = 1 << 3,
        Storm = 1 << 4,
        Fog = 1 << 5,
        Snow = 1 << 6,
        Sandstorm = 1 << 7,
        CrystalSquall = 1 << 8,
        SurfaceHeat = 1 << 9,
        NightIncense = 1 << 10,
        Overcast2 = 1 << 11,
        Aurora = 1 << 12,
        CloudSeaMist = 1 << 13
    }

    [Flags]
    public enum TimeRange
    {
        Morning = 1 << 0,
        Noontime = 1 << 1,
        Afternoon = 1 << 2,
        Evening = 1 << 3,
        LateNight = 1 << 4,
        Dawn = 1 << 5,
        Daytime = 1 << 6,
        Nighttime = 1 << 7,
        Any = 1 << 8,
        Evening_ = 1 << 15,
    }

    public enum RecipeType
    {
        Rarity,
        Category,
        Specific
    }

    public enum ArtType
    {
        Physical = 1,
        Ether,
        Recovery,
        Type4,
        Type5,
        Type6,
        Type7,
        Summon,
        Reinforcements,
        Type10,
        Defensive = 11,
        Type12
    }

    public enum ReactType
    {
        Break = 1,
        Topple,
        Launch,
        Smash,
        KnockbackLv1,
        KnockbackLv2,
        KnockbackLv3,
        KnockbackLv4,
        KnockbackLv5,
        BlowdownLv1,
        BlowdownLv2,
        BlowdownLv3,
        BlowdownLv4,
        BlowdownLv5,
        React15,
        React16,
        React17,
        React18,
        React19,
        React20,
        React21,
        React22,
        React23,
        React24,
        React25,
        React26,
        React27,
        React28,
        React29,
        React30,
        React31,
        React32,
        React33,
        Reduce_Blade_Combo__Attack_Combo_Element,
        Random_Element_Change,
        React36,
        React37,
        React38,
        React39,
        React40,
        React41,
        React42,
        React43,
        React44,
        React45
    }

    public enum ArtRangeType
    {
        OneTarget = 0,
        CircleBullet = 1,
        Ahead = 2,
        CircleUser = 5
    }

    public enum ChangeType
    {
        scenario = 1,
        quest_entry,
        quest_comp,
        Change4,
        Change5,
        town8,
        Change7,
        Change8,
        town4,
        Change10,
        Change11,
        town1,
        Change13,
        sys8,
        Change15,
        Change16,
        sys4,
        Change18,
        Change19,
        sys1,
        Change21,
        hanyou,
        Change23,
        Change24,
        kizuna,
        Change26,
        Change27,
        meet,
        system_msg,
        quest_entry_disp,
        quest_result_disp,
        next_event,
        cancel,
        hide_npc,
        Change35,
        hide_npc_route,
        Change37,
        hide_mapobj,
        Change39,
        hide_eff_lv,
        Change41,
        hide_se,
        Change43,
        hide_lod,
        Change45,
        anim_lod,
        Change47,
        Change48,
        reward_item,
        parts_off,
        Change51,
        parts_on,
        Change53,
        money,
        trustpoint,
        Change56,
        mercenaries,
        mercenaries_fin,
        ext_param,
        Change60,
        Change61,
        field_env,
        wpn_parts_off,
        Change64,
        wpn_parts_on,
        Change66,
        rinne_gold
    }

    public enum ItemTypeXb1
    {
        Weapon = 2,
        Gem,
        HeadArmor,
        BodyArmor,
        ArmArmor,
        LegArmor,
        FootArmor,
        Crystal,
        Collectable,
        Material,
        KeyItem,
        ArtBook
    }

    public enum ItemTypeXbx
    {
        Lot,
        HeadArmor,
        BodyArmor,
        ArmArmorR,
        ArmArmorL,
        LegArmor,
        RangedWeapon,
        MeleeWeapon,
        Item8,
        Item9,
        SkellHeadArmor,
        SkellBodyArmor,
        SkellArmArmorR,
        SkellArmArmorL,
        SkellLegArmor,
        SkellWeaponTypeA,
        SkellWeaponTypeB,
        SkellWeaponTypeC,
        SkellWeaponTypeD,
        SkellWeaponTypeE,
        Item20,
        AugmentGround,
        Item22,
        Item23,
        AugmentSkell,
        Item25,
        Item26,
        Item27,
        Item28,
        Item29,
        Item30,
        Item31,
        Item32,
        Item33,
        Item34,
        Item35,
        Item36,
        Item37,
        Item38,
        Item39,
        Item40,
        Item41,
        Item42,
        Item43,
        Item44,
        Item45,
        Item46,
        Item47,
        Item48,
        Item49,
        Item50,
        Item51,
        Item52,
        Item53,
        Item54,
        Item55,
        Item56,
        Item57,
        Item58,
        Item59,
        Item60,
        Item61,
        Item62,
        Item63,
        Holofigure,
        Schematic
    }

    public enum CommonBladeType
    {
        Male = 1,
        Female,
        Brute,
        Animal
    }

    public enum BladeAttribute
    {
        None = 0,
        Fire,
        Water,
        Wind,
        Earth,
        Electric,
        Ice,
        Light,
        Dark
    }

    public enum IraCharType
    {
        Driver,
        Blade
    }

    public enum EventCategory
    {
        None,
        TEV,
        FEV,
        SEV,
        CS,
        MOV
    }

    public enum NpcRoot
    {
        None,
        Ardainian,
        Urayan,
        Indoline,
        Nopon,
        Gormotti,
        Tantalese
    }

    public enum Gender
    {
        None,
        Male,
        Female,
        Gender3,
        Animal
    }
}
