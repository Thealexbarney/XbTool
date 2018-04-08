// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

using System;

namespace Xb2.Types
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
        Defensive = 11
    }

    public enum ArtRangeType
    {
        OneTarget = 0,
        CircleBullet = 1,
        Ahead = 2,
        CircleUser = 5
    }
}
