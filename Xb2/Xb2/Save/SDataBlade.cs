// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedField.Local
// ReSharper disable UnusedMember.Local

using Xb2.CreateBlade;
using Xb2.Types;

#pragma warning disable 169

namespace Xb2.Save
{
    public class SDataBlade
    {
        public ushort DataType;
        public ushort Creator;
        public ushort SetDriver;
        public ushort BladeId;
        public uint BornTime;
        public SDataIdea IdeaLevels;
        public int field_2C;
        public char field_30;
        public uint TrustPoints;
        public uint TrustRank;
        public byte Gender;
        public CommonBladeType CommonBladeType;

        public GfDataBladeArts[] BArts = new GfDataBladeArts[3];
        public GfDataBladeArts[] NArts = new GfDataBladeArts[3];
        public ushort BartExId;
        public ushort BladeArtsExH;
        public ushort BartEx2Id;
        public ushort BladeArtsEx2H;
        public GfDataBladeSkill[] BattleSkills = new GfDataBladeSkill[3];
        public GfDataBladeSkill[] FieldSkills = new GfDataBladeSkill[3];

        public ushort FavoriteCategory0;
        public ushort FavoriteItem0;
        public bool FavoriteCategory0Revealed;
        public bool FavoriteItem0Revealed;
        public ushort FavoriteCategory1;
        public ushort FavoriteItem1;
        public bool FavoriteCategory1Revealed;
        public bool FavoriteItem1Revealed;

        public byte WeaponType;
        public byte AuxCoreCount;
        public BladeAttribute Attribute;

        public byte PArmor;
        public byte EArmor;
        public byte HpMaxRev;
        public byte StrengthRev;
        public byte PowEtherRev;
        public byte DexRev;
        public byte AgilityRev;
        public byte LuckRev;

        public ushort RareNameId;
        public ushort CommonNameId;
        public string Name;

        public SDataBlade(DataBuffer save)
        {
            DataType = save.ReadUInt16();
            Creator = save.ReadUInt16();
            SetDriver = save.ReadUInt16();
            BladeId = save.ReadUInt16();
            BornTime = save.ReadUInt32();
            IdeaLevels = new SDataIdea(save);

            TrustPoints = save.ReadUInt32(0x34, true);
            TrustRank = save.ReadUInt32();

            for (int i = 0; i < BArts.Length; i++)
            {
                BArts[i] = new GfDataBladeArts(save);
            }

            for (int i = 0; i < NArts.Length; i++)
            {
                NArts[i] = new GfDataBladeArts(save);
            }

            BartExId = save.ReadUInt16();
            BladeArtsExH = save.ReadUInt16();
            BartEx2Id = save.ReadUInt16(0x90, true);
            BladeArtsEx2H = save.ReadUInt16();

            save.Position = 0x9c;
            for (int i = 0; i < BattleSkills.Length; i++)
            {
                BattleSkills[i] = new GfDataBladeSkill(save);
            }
            for (int i = 0; i < FieldSkills.Length; i++)
            {
                FieldSkills[i] = new GfDataBladeSkill(save);
            }

            FavoriteCategory0 = save.ReadUInt16(0x666, true);
            FavoriteItem0 = save.ReadUInt16();
            FavoriteCategory0Revealed = save.ReadUInt16() != 0;
            FavoriteItem0Revealed = save.ReadUInt16() != 0;
            FavoriteCategory1 = save.ReadUInt16();
            FavoriteItem1 = save.ReadUInt16();
            FavoriteCategory1Revealed = save.ReadUInt16() != 0;
            FavoriteItem1Revealed = save.ReadUInt16() != 0;

            Gender = save.ReadUInt8(0x709, true);

            WeaponType = save.ReadUInt8(0x821, true);
            AuxCoreCount = save.ReadUInt8();
            Attribute = (BladeAttribute)save.ReadUInt8();

            PArmor = save.ReadUInt8(0x83e, true);
            EArmor = save.ReadUInt8();
            HpMaxRev = save.ReadUInt8();
            StrengthRev = save.ReadUInt8();
            PowEtherRev = save.ReadUInt8();
            DexRev = save.ReadUInt8();
            AgilityRev = save.ReadUInt8();
            LuckRev = save.ReadUInt8();

            RareNameId = save.ReadUInt16(0x832);
            CommonNameId = save.ReadUInt16(0x834);

            Name = save.ReadUTF8Z(0x858);
        }

        public string GetName(BdatCollection tables)
        {
            if (RareNameId != 0)
            {
                return tables.chr_bl_ms.GetItemOrNull(RareNameId)?.name ?? Name;
            }

            return tables.bld_bladename.GetItemOrNull(CommonNameId)?.name ?? Name;
        }
    }

    public class GfDataBladeArts
    {
        public ushort Id;
        public ushort RecastRev;
        public ushort field_4;
        public byte field_6;
        public byte Level;
        public byte MaxLevel;
        public byte field_9;
        public ushort field_A;

        public GfDataBladeArts(DataBuffer save)
        {
            Id = save.ReadUInt16();
            RecastRev = save.ReadUInt16();
            field_4 = save.ReadUInt16();
            field_6 = save.ReadUInt8();
            Level = save.ReadUInt8();
            MaxLevel = save.ReadUInt8();
            field_9 = save.ReadUInt8();
            field_A = save.ReadUInt16();
        }
    }

    public class GfDataBladeSkill
    {
        public ushort Id;
        public byte field_2;
        public byte Level;
        public byte MaxLevel;
        public byte field_5;

        public GfDataBladeSkill(DataBuffer save)
        {
            Id = save.ReadUInt16();
            field_2 = save.ReadUInt8();
            Level = save.ReadUInt8();
            MaxLevel = save.ReadUInt8();
            field_5 = save.ReadUInt8();
        }
    }
}
