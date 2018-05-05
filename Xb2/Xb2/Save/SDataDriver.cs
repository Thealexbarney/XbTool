// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedField.Local
// ReSharper disable UnusedMember.Local

#pragma warning disable 169
namespace Xb2.Save
{
    public class SDataDriver
    {
        SDataIdea IdeaLevels;
        ActivateType ActivateType;
        ushort DriverId;
        ushort SetBlade;
        ushort[] EquippedBlades = new ushort[3];
        GfDataDriverSkill[] SkillsRound1 = new GfDataDriverSkill[5];
        GfDataDriverSkill[] SkillsRound2 = new GfDataDriverSkill[5];
        ushort Level;
        ushort HpMax;
        ushort Strength;
        ushort Ether;
        ushort Dex;
        ushort Agility;
        ushort Luck;
        char field_A6;
        byte field_A7;
        int field_A8;
        char field_AF;
        uint Exp;
        uint BattleExp;
        uint SkillPoints;
        uint TotalSkillPoints;
        int[][] WeaponTypeInfo = Helpers.CreateJaggedArray<int[][]>(5, 5);
        byte[] DriverArtLevels = new byte[525];
        int field_574;
        ushort field_578;
        ushort gap_57A;
        int field_57C;
        ushort field_580;
        byte field_59F;

        public SDataDriver(DataBuffer save)
        {
            IdeaLevels = new SDataIdea(save);
            ActivateType = (ActivateType)save.ReadUInt16(0x20, true);
            DriverId = save.ReadUInt16();
            SetBlade = save.ReadUInt16();
            EquippedBlades[0] = save.ReadUInt16();
            EquippedBlades[1] = save.ReadUInt16();
            EquippedBlades[2] = save.ReadUInt16();

            save.Position = 0x30;
            for (int i = 0; i < SkillsRound1.Length; i++)
            {
                SkillsRound1[i] = new GfDataDriverSkill(save);
            }

            for (int i = 0; i < SkillsRound2.Length; i++)
            {
                SkillsRound2[i] = new GfDataDriverSkill(save);
            }

            Level = save.ReadUInt16(0x94, true);
            HpMax = save.ReadUInt16();
            Strength = save.ReadUInt16();
            Ether = save.ReadUInt16();
            Dex = save.ReadUInt16();
            Agility = save.ReadUInt16();
            Luck = save.ReadUInt16();

            Exp = save.ReadUInt32(0xb0, true);
            BattleExp = save.ReadUInt32();
            SkillPoints = save.ReadUInt32();
            TotalSkillPoints = save.ReadUInt32();
        }

    }

    public class SDataIdea
    {
        public uint BraveryPoints;
        public uint BraveryLevel;
        public uint TruthPoints;
        public uint TruthLevel;
        public uint CompassionPoints;
        public uint CompassionLevel;
        public uint JusticePoints;
        public uint JusticeLevel;

        public SDataIdea(DataBuffer save)
        {
            BraveryPoints = save.ReadUInt32();
            BraveryLevel = save.ReadUInt32();
            TruthPoints = save.ReadUInt32();
            TruthLevel = save.ReadUInt32();
            CompassionPoints = save.ReadUInt32();
            CompassionLevel = save.ReadUInt32();
            JusticePoints = save.ReadUInt32();
            JusticeLevel = save.ReadUInt32();
        }
    }

    public class GfDataDriverSkill
    {
        public ushort[] Columns = new ushort[3];
        public ushort Row;
        public ushort LevelUnlocked;

        public GfDataDriverSkill(DataBuffer save)
        {
            Columns[0] = save.ReadUInt16();
            Columns[1] = save.ReadUInt16();
            Columns[2] = save.ReadUInt16();
            Row = save.ReadUInt16();
            LevelUnlocked = save.ReadUInt16();
        }
    }
}
