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
}
