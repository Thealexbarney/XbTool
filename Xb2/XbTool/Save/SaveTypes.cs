// ReSharper disable InconsistentNaming RedundantCast MemberCanBePrivate.Global NotAccessedField.Global FieldCanBeMadeReadOnly.Global ForCanBeConvertedToForeach PartialTypeWithSinglePart

using XbTool.Types;

namespace XbTool.Save
{
    public partial class GfEquipHana
    {
        public ushort RoleItem { get; set; }
        public ushort AtrItem { get; set; }
        public ArtsEnhance[] BArtsEnhance { get; set; } = new ArtsEnhance[3];
        public ArtsEnhance[] NArts { get; set; } = new ArtsEnhance[3];
        public ushort[] Skills { get; set; } = new ushort[6];
        public GfItemHandle[] field_58 { get; set; } = new GfItemHandle[8];
        public ushort PowerCapacity { get; set; }
        public HanaCircuits OpenCircuits { get; set; }

        public GfEquipHana(DataBuffer save)
        {
            RoleItem = save.ReadUInt16();
            AtrItem = save.ReadUInt16();

            for (int i = 0; i < BArtsEnhance.Length; i++)
            {
                BArtsEnhance[i] = new ArtsEnhance(save);
            }

            for (int i = 0; i < NArts.Length; i++)
            {
                NArts[i] = new ArtsEnhance(save);
            }

            for (int i = 0; i < Skills.Length; i++)
            {
                Skills[i] = save.ReadUInt16();
            }

            for (int i = 0; i < field_58.Length; i++)
            {
                field_58[i] = new GfItemHandle(save);
            }

            PowerCapacity = save.ReadUInt16();
            OpenCircuits = new HanaCircuits(save);
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(RoleItem);
            save.WriteUInt16(AtrItem);

            for (int i = 0; i < BArtsEnhance.Length; i++)
            {
                BArtsEnhance[i].WriteSave(save);
            }

            for (int i = 0; i < NArts.Length; i++)
            {
                NArts[i].WriteSave(save);
            }

            for (int i = 0; i < Skills.Length; i++)
            {
                save.WriteUInt16(Skills[i]);
            }

            for (int i = 0; i < field_58.Length; i++)
            {
                field_58[i].WriteSave(save);
            }

            save.WriteUInt16(PowerCapacity);
            OpenCircuits.WriteSave(save);
        }
    }

    public partial class ArtsEnhance
    {
        public ushort EnhanceId { get; set; }
        public ushort RecastRev { get; set; }
        public ushort ItemId { get; set; }
        public ushort field_6 { get; set; }
        public GfItemHandle16 field_8 { get; set; }
        public GfItemHandle16 field_A { get; set; }

        public ArtsEnhance(DataBuffer save)
        {
            EnhanceId = save.ReadUInt16();
            RecastRev = save.ReadUInt16();
            ItemId = save.ReadUInt16();
            field_6 = save.ReadUInt16();
            field_8 = new GfItemHandle16(save);
            field_A = new GfItemHandle16(save);
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(EnhanceId);
            save.WriteUInt16(RecastRev);
            save.WriteUInt16(ItemId);
            save.WriteUInt16(field_6);
            field_8.WriteSave(save);
            field_A.WriteSave(save);
        }
    }

    public partial class GfDataBladeSkill
    {
        public ushort Id { get; set; }
        public byte field_2 { get; set; }
        public byte Level { get; set; }
        public byte MaxLevel { get; set; }
        public byte field_5 { get; set; }

        public GfDataBladeSkill(DataBuffer save)
        {
            Id = save.ReadUInt16();
            field_2 = save.ReadUInt8();
            Level = save.ReadUInt8();
            MaxLevel = save.ReadUInt8();
            field_5 = save.ReadUInt8();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(Id);
            save.WriteUInt8(field_2);
            save.WriteUInt8(Level);
            save.WriteUInt8(MaxLevel);
            save.WriteUInt8(field_5);
        }
    }

    public partial class GfDataBladeArts
    {
        public ushort Id { get; set; }
        public ushort RecastRev { get; set; }
        public ushort field_4 { get; set; }
        public byte field_6 { get; set; }
        public byte Level { get; set; }
        public byte MaxLevel { get; set; }
        public byte field_9 { get; set; }
        public ushort field_A { get; set; }

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

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(Id);
            save.WriteUInt16(RecastRev);
            save.WriteUInt16(field_4);
            save.WriteUInt8(field_6);
            save.WriteUInt8(Level);
            save.WriteUInt8(MaxLevel);
            save.WriteUInt8(field_9);
            save.WriteUInt16(field_A);
        }
    }

    public partial class GfDataBladeArtsN
    {
        public ushort Id { get; set; }
        public ushort RecastRev { get; set; }
        public ushort field_4 { get; set; }
        public ushort field_6 { get; set; }
        public ushort field_8 { get; set; }
        public ushort field_A { get; set; }

        public GfDataBladeArtsN(DataBuffer save)
        {
            Id = save.ReadUInt16();
            RecastRev = save.ReadUInt16();
            field_4 = save.ReadUInt16();
            field_6 = save.ReadUInt16();
            field_8 = save.ReadUInt16();
            field_A = save.ReadUInt16();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(Id);
            save.WriteUInt16(RecastRev);
            save.WriteUInt16(field_4);
            save.WriteUInt16(field_6);
            save.WriteUInt16(field_8);
            save.WriteUInt16(field_A);
        }
    }

    public partial class GfDataBladeArtsEx
    {
        public ushort Id { get; set; }
        public ushort DamageRev { get; set; }
        public ushort field_4 { get; set; }
        public ushort field_6 { get; set; }
        public byte field_8 { get; set; }
        public byte field_9 { get; set; }
        public ushort field_A { get; set; }

        public GfDataBladeArtsEx(DataBuffer save)
        {
            Id = save.ReadUInt16();
            DamageRev = save.ReadUInt16();
            field_4 = save.ReadUInt16();
            field_6 = save.ReadUInt16();
            field_8 = save.ReadUInt8();
            field_9 = save.ReadUInt8();
            field_A = save.ReadUInt16();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(Id);
            save.WriteUInt16(DamageRev);
            save.WriteUInt16(field_4);
            save.WriteUInt16(field_6);
            save.WriteUInt8(field_8);
            save.WriteUInt8(field_9);
            save.WriteUInt16(field_A);
        }
    }

    public partial class SDataBlade
    {
        public ushort DataType { get; set; }
        public ushort Creator { get; set; }
        public ushort SetDriver { get; set; }
        public ushort BladeId { get; set; }
        public ElapseTime BornTime { get; set; }
        public SDataIdea IdeaLevels { get; set; }
        public uint field_2C { get; set; }
        public byte field_30 { get; set; }
        public byte[] gap31 { get; set; } = new byte[3];
        public uint TrustPoints { get; set; }
        public uint TrustRank { get; set; }
        public GfDataBladeArts[] BArts { get; set; } = new GfDataBladeArts[3];
        public GfDataBladeArtsN[] NArts { get; set; } = new GfDataBladeArtsN[3];
        public GfDataBladeArtsEx[] BArtsEx { get; set; } = new GfDataBladeArtsEx[2];
        public GfDataBladeSkill[] BattleSkills { get; set; } = new GfDataBladeSkill[3];
        public GfDataBladeSkill[] FieldSkills { get; set; } = new GfDataBladeSkill[3];
        public byte[] ExtraParts2 { get; set; } = new byte[4];
        public GfAchievInfo[] BArtsAchievement { get; set; } = new GfAchievInfo[3];
        public GfAchievInfo[] BSkillsAchievement { get; set; } = new GfAchievInfo[3];
        public GfAchievInfo[] FSkillsAchievement { get; set; } = new GfAchievInfo[3];
        public GfAchievInfo KeyAchievement { get; set; }
        public ushort KeyReleaseLevel { get; set; }
        public ushort FavoriteCategory0 { get; set; }
        public ushort FavoriteItem0 { get; set; }
        public bool FavoriteCategory0Revealed { get; set; }
        public bool FavoriteItem0Revealed { get; set; }
        public ushort FavoriteCategory1 { get; set; }
        public ushort FavoriteItem1 { get; set; }
        public bool FavoriteCategory1Revealed { get; set; }
        public bool FavoriteItem1Revealed { get; set; }
        public ushort gap676 { get; set; }
        public ushort[] EquippedOrbs { get; set; } = new ushort[3];
        public ushort gap67E { get; set; }
        public GfItemHandle[] EquippedOrbHandles { get; set; } = new GfItemHandle[3];
        public GfEquipHana Poppiswap { get; set; }
        public byte Race { get; set; }
        public byte Gender { get; set; }
        public ushort Still { get; set; }
        public string ModelResourceName { get; set; }
        public string Model2Name { get; set; }
        public string MotionResourceName { get; set; }
        public string Motion2Name { get; set; }
        public string AddMotionName { get; set; }
        public string VoiceName { get; set; }
        public string ClipEvent { get; set; }
        public string Com_SE { get; set; }
        public string EffectResourceName { get; set; }
        public string Com_Vo { get; set; }
        public string CenterBone { get; set; }
        public string CamBone { get; set; }
        public string SeResourceName { get; set; }
        public byte BladeSize { get; set; }
        public byte WeaponType { get; set; }
        public byte AuxCoreCount { get; set; }
        public BladeAttribute Attribute { get; set; }
        public byte Personality { get; set; }
        public byte ExtraParts { get; set; }
        public byte EyeRot { get; set; }
        public byte gap_827 { get; set; }
        public ushort Cooldown { get; set; }
        public ushort Condition { get; set; }
        public ushort DefWeapon { get; set; }
        public ushort ChestHeight { get; set; }
        public ushort LandingHeight { get; set; }
        public ushort RareNameId { get; set; }
        public ushort CommonNameId { get; set; }
        public ushort Scale { get; set; }
        public ushort WpnScale { get; set; }
        public ushort OffsetID { get; set; }
        public ushort CollisionId { get; set; }
        public byte PArmor { get; set; }
        public byte EArmor { get; set; }
        public byte HpMaxRev { get; set; }
        public byte StrengthRev { get; set; }
        public byte PowEtherRev { get; set; }
        public byte DexRev { get; set; }
        public byte AgilityRev { get; set; }
        public byte LuckRev { get; set; }
        public byte QuestRace { get; set; }
        public byte ReleaseLock { get; set; }
        public byte FootStep { get; set; }
        public byte FootStepEffect { get; set; }
        public ushort KizunaLinkSet { get; set; }
        public ushort NormalTalk { get; set; }
        public ushort gap_84E { get; set; }
        public uint CreateEventID { get; set; }
        public ushort MountPoint { get; set; }
        public ushort MountObject { get; set; }
        public string Name { get; set; }
        public ushort CommonBladeIndex { get; set; }
        public byte EnableEngageRex { get; set; }
        public byte BladeReleaseStatus { get; set; }
        public byte isUnselect { get; set; }
        public byte AffinityChartStatus { get; set; }

        public SDataBlade(DataBuffer save)
        {
            DataType = save.ReadUInt16();
            Creator = save.ReadUInt16();
            SetDriver = save.ReadUInt16();
            BladeId = save.ReadUInt16();
            BornTime = new ElapseTime(save);
            IdeaLevels = new SDataIdea(save);
            field_2C = save.ReadUInt32();
            field_30 = save.ReadUInt8();

            for (int i = 0; i < gap31.Length; i++)
            {
                gap31[i] = save.ReadUInt8();
            }

            TrustPoints = save.ReadUInt32();
            TrustRank = save.ReadUInt32();

            for (int i = 0; i < BArts.Length; i++)
            {
                BArts[i] = new GfDataBladeArts(save);
            }

            for (int i = 0; i < NArts.Length; i++)
            {
                NArts[i] = new GfDataBladeArtsN(save);
            }

            for (int i = 0; i < BArtsEx.Length; i++)
            {
                BArtsEx[i] = new GfDataBladeArtsEx(save);
            }

            for (int i = 0; i < BattleSkills.Length; i++)
            {
                BattleSkills[i] = new GfDataBladeSkill(save);
            }

            for (int i = 0; i < FieldSkills.Length; i++)
            {
                FieldSkills[i] = new GfDataBladeSkill(save);
            }

            for (int i = 0; i < ExtraParts2.Length; i++)
            {
                ExtraParts2[i] = save.ReadUInt8();
            }

            for (int i = 0; i < BArtsAchievement.Length; i++)
            {
                BArtsAchievement[i] = new GfAchievInfo(save);
            }

            for (int i = 0; i < BSkillsAchievement.Length; i++)
            {
                BSkillsAchievement[i] = new GfAchievInfo(save);
            }

            for (int i = 0; i < FSkillsAchievement.Length; i++)
            {
                FSkillsAchievement[i] = new GfAchievInfo(save);
            }

            KeyAchievement = new GfAchievInfo(save);
            KeyReleaseLevel = save.ReadUInt16();
            FavoriteCategory0 = save.ReadUInt16();
            FavoriteItem0 = save.ReadUInt16();
            FavoriteCategory0Revealed = save.ReadUInt16() != 0;
            FavoriteItem0Revealed = save.ReadUInt16() != 0;
            FavoriteCategory1 = save.ReadUInt16();
            FavoriteItem1 = save.ReadUInt16();
            FavoriteCategory1Revealed = save.ReadUInt16() != 0;
            FavoriteItem1Revealed = save.ReadUInt16() != 0;
            gap676 = save.ReadUInt16();

            for (int i = 0; i < EquippedOrbs.Length; i++)
            {
                EquippedOrbs[i] = save.ReadUInt16();
            }

            gap67E = save.ReadUInt16();

            for (int i = 0; i < EquippedOrbHandles.Length; i++)
            {
                EquippedOrbHandles[i] = new GfItemHandle(save);
            }

            Poppiswap = new GfEquipHana(save);
            Race = save.ReadUInt8();
            Gender = save.ReadUInt8();
            Still = save.ReadUInt16();
            ModelResourceName = Read.ReadSizedUTF8(save, 16);
            Model2Name = Read.ReadSizedUTF8(save, 16);
            MotionResourceName = Read.ReadSizedUTF8(save, 16);
            Motion2Name = Read.ReadSizedUTF8(save, 16);
            AddMotionName = Read.ReadSizedUTF8(save, 16);
            VoiceName = Read.ReadSizedUTF8(save, 16);
            ClipEvent = Read.ReadSizedUTF8(save, 16);
            Com_SE = Read.ReadSizedUTF8(save, 16);
            EffectResourceName = Read.ReadSizedUTF8(save, 16);
            Com_Vo = Read.ReadSizedUTF8(save, 16);
            CenterBone = Read.ReadSizedUTF8(save, 16);
            CamBone = Read.ReadSizedUTF8(save, 16);
            SeResourceName = Read.ReadSizedUTF8(save, 32);
            BladeSize = save.ReadUInt8();
            WeaponType = save.ReadUInt8();
            AuxCoreCount = save.ReadUInt8();
            Attribute = (BladeAttribute)save.ReadUInt8();
            Personality = save.ReadUInt8();
            ExtraParts = save.ReadUInt8();
            EyeRot = save.ReadUInt8();
            gap_827 = save.ReadUInt8();
            Cooldown = save.ReadUInt16();
            Condition = save.ReadUInt16();
            DefWeapon = save.ReadUInt16();
            ChestHeight = save.ReadUInt16();
            LandingHeight = save.ReadUInt16();
            RareNameId = save.ReadUInt16();
            CommonNameId = save.ReadUInt16();
            Scale = save.ReadUInt16();
            WpnScale = save.ReadUInt16();
            OffsetID = save.ReadUInt16();
            CollisionId = save.ReadUInt16();
            PArmor = save.ReadUInt8();
            EArmor = save.ReadUInt8();
            HpMaxRev = save.ReadUInt8();
            StrengthRev = save.ReadUInt8();
            PowEtherRev = save.ReadUInt8();
            DexRev = save.ReadUInt8();
            AgilityRev = save.ReadUInt8();
            LuckRev = save.ReadUInt8();
            QuestRace = save.ReadUInt8();
            ReleaseLock = save.ReadUInt8();
            FootStep = save.ReadUInt8();
            FootStepEffect = save.ReadUInt8();
            KizunaLinkSet = save.ReadUInt16();
            NormalTalk = save.ReadUInt16();
            gap_84E = save.ReadUInt16();
            CreateEventID = save.ReadUInt32();
            MountPoint = save.ReadUInt16();
            MountObject = save.ReadUInt16();
            Name = Read.ReadSizedUTF8(save, 64);
            CommonBladeIndex = save.ReadUInt16();
            EnableEngageRex = save.ReadUInt8();
            BladeReleaseStatus = save.ReadUInt8();
            isUnselect = save.ReadUInt8();
            AffinityChartStatus = save.ReadUInt8();
            save.Position += 2;
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(DataType);
            save.WriteUInt16(Creator);
            save.WriteUInt16(SetDriver);
            save.WriteUInt16(BladeId);
            BornTime.WriteSave(save);
            IdeaLevels.WriteSave(save);
            save.WriteUInt32(field_2C);
            save.WriteUInt8(field_30);

            for (int i = 0; i < gap31.Length; i++)
            {
                save.WriteUInt8(gap31[i]);
            }

            save.WriteUInt32(TrustPoints);
            save.WriteUInt32(TrustRank);

            for (int i = 0; i < BArts.Length; i++)
            {
                BArts[i].WriteSave(save);
            }

            for (int i = 0; i < NArts.Length; i++)
            {
                NArts[i].WriteSave(save);
            }

            for (int i = 0; i < BArtsEx.Length; i++)
            {
                BArtsEx[i].WriteSave(save);
            }

            for (int i = 0; i < BattleSkills.Length; i++)
            {
                BattleSkills[i].WriteSave(save);
            }

            for (int i = 0; i < FieldSkills.Length; i++)
            {
                FieldSkills[i].WriteSave(save);
            }

            for (int i = 0; i < ExtraParts2.Length; i++)
            {
                save.WriteUInt8(ExtraParts2[i]);
            }

            for (int i = 0; i < BArtsAchievement.Length; i++)
            {
                BArtsAchievement[i].WriteSave(save);
            }

            for (int i = 0; i < BSkillsAchievement.Length; i++)
            {
                BSkillsAchievement[i].WriteSave(save);
            }

            for (int i = 0; i < FSkillsAchievement.Length; i++)
            {
                FSkillsAchievement[i].WriteSave(save);
            }

            KeyAchievement.WriteSave(save);
            save.WriteUInt16(KeyReleaseLevel);
            save.WriteUInt16(FavoriteCategory0);
            save.WriteUInt16(FavoriteItem0);
            save.WriteUInt16((ushort)(FavoriteCategory0Revealed ? 1 : 0));
            save.WriteUInt16((ushort)(FavoriteItem0Revealed ? 1 : 0));
            save.WriteUInt16(FavoriteCategory1);
            save.WriteUInt16(FavoriteItem1);
            save.WriteUInt16((ushort)(FavoriteCategory1Revealed ? 1 : 0));
            save.WriteUInt16((ushort)(FavoriteItem1Revealed ? 1 : 0));
            save.WriteUInt16(gap676);

            for (int i = 0; i < EquippedOrbs.Length; i++)
            {
                save.WriteUInt16(EquippedOrbs[i]);
            }

            save.WriteUInt16(gap67E);

            for (int i = 0; i < EquippedOrbHandles.Length; i++)
            {
                EquippedOrbHandles[i].WriteSave(save);
            }

            Poppiswap.WriteSave(save);
            save.WriteUInt8(Race);
            save.WriteUInt8(Gender);
            save.WriteUInt16(Still);
            save.WriteSizedUTF8(ModelResourceName, 16);
            save.WriteSizedUTF8(Model2Name, 16);
            save.WriteSizedUTF8(MotionResourceName, 16);
            save.WriteSizedUTF8(Motion2Name, 16);
            save.WriteSizedUTF8(AddMotionName, 16);
            save.WriteSizedUTF8(VoiceName, 16);
            save.WriteSizedUTF8(ClipEvent, 16);
            save.WriteSizedUTF8(Com_SE, 16);
            save.WriteSizedUTF8(EffectResourceName, 16);
            save.WriteSizedUTF8(Com_Vo, 16);
            save.WriteSizedUTF8(CenterBone, 16);
            save.WriteSizedUTF8(CamBone, 16);
            save.WriteSizedUTF8(SeResourceName, 32);
            save.WriteUInt8(BladeSize);
            save.WriteUInt8(WeaponType);
            save.WriteUInt8(AuxCoreCount);
            save.WriteUInt8((byte)Attribute);
            save.WriteUInt8(Personality);
            save.WriteUInt8(ExtraParts);
            save.WriteUInt8(EyeRot);
            save.WriteUInt8(gap_827);
            save.WriteUInt16(Cooldown);
            save.WriteUInt16(Condition);
            save.WriteUInt16(DefWeapon);
            save.WriteUInt16(ChestHeight);
            save.WriteUInt16(LandingHeight);
            save.WriteUInt16(RareNameId);
            save.WriteUInt16(CommonNameId);
            save.WriteUInt16(Scale);
            save.WriteUInt16(WpnScale);
            save.WriteUInt16(OffsetID);
            save.WriteUInt16(CollisionId);
            save.WriteUInt8(PArmor);
            save.WriteUInt8(EArmor);
            save.WriteUInt8(HpMaxRev);
            save.WriteUInt8(StrengthRev);
            save.WriteUInt8(PowEtherRev);
            save.WriteUInt8(DexRev);
            save.WriteUInt8(AgilityRev);
            save.WriteUInt8(LuckRev);
            save.WriteUInt8(QuestRace);
            save.WriteUInt8(ReleaseLock);
            save.WriteUInt8(FootStep);
            save.WriteUInt8(FootStepEffect);
            save.WriteUInt16(KizunaLinkSet);
            save.WriteUInt16(NormalTalk);
            save.WriteUInt16(gap_84E);
            save.WriteUInt32(CreateEventID);
            save.WriteUInt16(MountPoint);
            save.WriteUInt16(MountObject);
            save.WriteSizedUTF8(Name, 64);
            save.WriteUInt16(CommonBladeIndex);
            save.WriteUInt8(EnableEngageRex);
            save.WriteUInt8(BladeReleaseStatus);
            save.WriteUInt8(isUnselect);
            save.WriteUInt8(AffinityChartStatus);
            save.Position += 2;
        }
    }

    public partial class SDataDriver
    {
        public SDataIdea IdeaLevels { get; set; }
        public ActivateType ActivateType { get; set; }
        public ushort DriverId { get; set; }
        public ushort SetBlade { get; set; }
        public ushort[] EquippedBlades { get; set; } = new ushort[3];
        public uint gap2C { get; set; }
        public GfDataDriverSkill[] SkillsRound1 { get; set; } = new GfDataDriverSkill[5];
        public GfDataDriverSkill[] SkillsRound2 { get; set; } = new GfDataDriverSkill[5];
        public ushort Level { get; set; }
        public ushort HpMax { get; set; }
        public ushort Strength { get; set; }
        public ushort Ether { get; set; }
        public ushort Dex { get; set; }
        public ushort Agility { get; set; }
        public ushort Luck { get; set; }
        public ushort PArmor { get; set; }
        public ushort EArmor { get; set; }
        public byte CritRate { get; set; }
        public byte GuardRate { get; set; }
        public uint field_A8 { get; set; }
        public byte[] gap_AC { get; set; } = new byte[3];
        public byte field_AF { get; set; }
        public uint Exp { get; set; }
        public uint BattleExp { get; set; }
        public uint SkillPoints { get; set; }
        public uint TotalSkillPoints { get; set; }
        public DriverWeapon[] Weapons { get; set; } = new DriverWeapon[27];
        public byte[] gap_2DC { get; set; } = new byte[12];
        public ushort AccessoryId2 { get; set; }
        public byte[] gap_2EA { get; set; } = new byte[2];
        public GfItemHandle AccessoryHandle2 { get; set; }
        public byte[] DriverArtLevels { get; set; } = new byte[525];
        public byte[] gap_4FD { get; set; } = new byte[119];
        public GfItemHandle AccessoryHandle0 { get; set; }
        public ushort AccessoryId0 { get; set; }
        public ushort gap_57A { get; set; }
        public GfItemHandle AccessoryHandle1 { get; set; }
        public ushort AccessoryId1 { get; set; }
        public ushort gap_582 { get; set; }
        public SDataPouch[] PouchInfo { get; set; } = new SDataPouch[3];
        public byte[] ActivatedWeaponTypes { get; set; } = new byte[32];

        public SDataDriver(DataBuffer save)
        {
            IdeaLevels = new SDataIdea(save);
            ActivateType = (ActivateType)save.ReadUInt16();
            DriverId = save.ReadUInt16();
            SetBlade = save.ReadUInt16();

            for (int i = 0; i < EquippedBlades.Length; i++)
            {
                EquippedBlades[i] = save.ReadUInt16();
            }

            gap2C = save.ReadUInt32();

            for (int i = 0; i < SkillsRound1.Length; i++)
            {
                SkillsRound1[i] = new GfDataDriverSkill(save);
            }

            for (int i = 0; i < SkillsRound2.Length; i++)
            {
                SkillsRound2[i] = new GfDataDriverSkill(save);
            }

            Level = save.ReadUInt16();
            HpMax = save.ReadUInt16();
            Strength = save.ReadUInt16();
            Ether = save.ReadUInt16();
            Dex = save.ReadUInt16();
            Agility = save.ReadUInt16();
            Luck = save.ReadUInt16();
            PArmor = save.ReadUInt16();
            EArmor = save.ReadUInt16();
            CritRate = save.ReadUInt8();
            GuardRate = save.ReadUInt8();
            field_A8 = save.ReadUInt32();

            for (int i = 0; i < gap_AC.Length; i++)
            {
                gap_AC[i] = save.ReadUInt8();
            }

            field_AF = save.ReadUInt8();
            Exp = save.ReadUInt32();
            BattleExp = save.ReadUInt32();
            SkillPoints = save.ReadUInt32();
            TotalSkillPoints = save.ReadUInt32();

            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i] = new DriverWeapon(save);
            }

            for (int i = 0; i < gap_2DC.Length; i++)
            {
                gap_2DC[i] = save.ReadUInt8();
            }

            AccessoryId2 = save.ReadUInt16();

            for (int i = 0; i < gap_2EA.Length; i++)
            {
                gap_2EA[i] = save.ReadUInt8();
            }

            AccessoryHandle2 = new GfItemHandle(save);

            for (int i = 0; i < DriverArtLevels.Length; i++)
            {
                DriverArtLevels[i] = save.ReadUInt8();
            }

            for (int i = 0; i < gap_4FD.Length; i++)
            {
                gap_4FD[i] = save.ReadUInt8();
            }

            AccessoryHandle0 = new GfItemHandle(save);
            AccessoryId0 = save.ReadUInt16();
            gap_57A = save.ReadUInt16();
            AccessoryHandle1 = new GfItemHandle(save);
            AccessoryId1 = save.ReadUInt16();
            gap_582 = save.ReadUInt16();

            for (int i = 0; i < PouchInfo.Length; i++)
            {
                PouchInfo[i] = new SDataPouch(save);
            }
            Read.ReadBitfieldArray(save, ActivatedWeaponTypes, 32, 1);
        }

        public void WriteSave(DataBuffer save)
        {
            IdeaLevels.WriteSave(save);
            save.WriteUInt16((ushort)ActivateType);
            save.WriteUInt16(DriverId);
            save.WriteUInt16(SetBlade);

            for (int i = 0; i < EquippedBlades.Length; i++)
            {
                save.WriteUInt16(EquippedBlades[i]);
            }

            save.WriteUInt32(gap2C);

            for (int i = 0; i < SkillsRound1.Length; i++)
            {
                SkillsRound1[i].WriteSave(save);
            }

            for (int i = 0; i < SkillsRound2.Length; i++)
            {
                SkillsRound2[i].WriteSave(save);
            }

            save.WriteUInt16(Level);
            save.WriteUInt16(HpMax);
            save.WriteUInt16(Strength);
            save.WriteUInt16(Ether);
            save.WriteUInt16(Dex);
            save.WriteUInt16(Agility);
            save.WriteUInt16(Luck);
            save.WriteUInt16(PArmor);
            save.WriteUInt16(EArmor);
            save.WriteUInt8(CritRate);
            save.WriteUInt8(GuardRate);
            save.WriteUInt32(field_A8);

            for (int i = 0; i < gap_AC.Length; i++)
            {
                save.WriteUInt8(gap_AC[i]);
            }

            save.WriteUInt8(field_AF);
            save.WriteUInt32(Exp);
            save.WriteUInt32(BattleExp);
            save.WriteUInt32(SkillPoints);
            save.WriteUInt32(TotalSkillPoints);

            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i].WriteSave(save);
            }

            for (int i = 0; i < gap_2DC.Length; i++)
            {
                save.WriteUInt8(gap_2DC[i]);
            }

            save.WriteUInt16(AccessoryId2);

            for (int i = 0; i < gap_2EA.Length; i++)
            {
                save.WriteUInt8(gap_2EA[i]);
            }

            AccessoryHandle2.WriteSave(save);

            for (int i = 0; i < DriverArtLevels.Length; i++)
            {
                save.WriteUInt8(DriverArtLevels[i]);
            }

            for (int i = 0; i < gap_4FD.Length; i++)
            {
                save.WriteUInt8(gap_4FD[i]);
            }

            AccessoryHandle0.WriteSave(save);
            save.WriteUInt16(AccessoryId0);
            save.WriteUInt16(gap_57A);
            AccessoryHandle1.WriteSave(save);
            save.WriteUInt16(AccessoryId1);
            save.WriteUInt16(gap_582);

            for (int i = 0; i < PouchInfo.Length; i++)
            {
                PouchInfo[i].WriteSave(save);
            }
            Write.WriteBitfieldArray(save, ActivatedWeaponTypes, 32, 1);
        }
    }

    public partial class SDataIdea
    {
        public uint BraveryPoints { get; set; }
        public uint BraveryLevel { get; set; }
        public uint TruthPoints { get; set; }
        public uint TruthLevel { get; set; }
        public uint CompassionPoints { get; set; }
        public uint CompassionLevel { get; set; }
        public uint JusticePoints { get; set; }
        public uint JusticeLevel { get; set; }

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

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt32(BraveryPoints);
            save.WriteUInt32(BraveryLevel);
            save.WriteUInt32(TruthPoints);
            save.WriteUInt32(TruthLevel);
            save.WriteUInt32(CompassionPoints);
            save.WriteUInt32(CompassionLevel);
            save.WriteUInt32(JusticePoints);
            save.WriteUInt32(JusticeLevel);
        }
    }

    public partial class GfDataDriverSkill
    {
        public ushort[] Columns { get; set; } = new ushort[3];
        public ushort Row { get; set; }
        public ushort LevelUnlocked { get; set; }

        public GfDataDriverSkill(DataBuffer save)
        {
            for (int i = 0; i < Columns.Length; i++)
            {
                Columns[i] = save.ReadUInt16();
            }

            Row = save.ReadUInt16();
            LevelUnlocked = save.ReadUInt16();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Columns.Length; i++)
            {
                save.WriteUInt16(Columns[i]);
            }

            save.WriteUInt16(Row);
            save.WriteUInt16(LevelUnlocked);
        }
    }

    public partial class DriverWeapon
    {
        public uint[] Ids { get; set; } = new uint[3];
        public uint WeaponPoints { get; set; }
        public uint TotalWeaponPoints { get; set; }

        public DriverWeapon(DataBuffer save)
        {
            for (int i = 0; i < Ids.Length; i++)
            {
                Ids[i] = save.ReadUInt32();
            }

            WeaponPoints = save.ReadUInt32();
            TotalWeaponPoints = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Ids.Length; i++)
            {
                save.WriteUInt32(Ids[i]);
            }

            save.WriteUInt32(WeaponPoints);
            save.WriteUInt32(TotalWeaponPoints);
        }
    }

    public partial class SDataPouch
    {
        public float Time { get; set; }
        public ushort ItemId { get; set; }
        public ushort IsEnabled { get; set; }

        public SDataPouch(DataBuffer save)
        {
            Time = save.ReadSingle();
            ItemId = save.ReadUInt16();
            IsEnabled = save.ReadUInt16();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteSingle(Time);
            save.WriteUInt16(ItemId);
            save.WriteUInt16(IsEnabled);
        }
    }

    public partial class SDataSave
    {
        public SDataSystem SystemSave { get; set; }
        public SDataGame GameSave { get; set; }

        public SDataSave(DataBuffer save)
        {
            SystemSave = new SDataSystem(save);
            GameSave = new SDataGame(save);
        }

        public void WriteSave(DataBuffer save)
        {
            SystemSave.WriteSave(save);
            GameSave.WriteSave(save);
        }
    }

    public partial class SDataSystem
    {
        public uint Magic { get; set; }
        public uint field_4 { get; set; }
        public RealTime SaveTime { get; set; }

        public SDataSystem(DataBuffer save)
        {
            Magic = save.ReadUInt32();
            field_4 = save.ReadUInt32();
            SaveTime = new RealTime(save);
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt32(Magic);
            save.WriteUInt32(field_4);
            SaveTime.WriteSave(save);
        }
    }

    public partial class Vec3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vec3(DataBuffer save)
        {
            X = save.ReadSingle();
            Y = save.ReadSingle();
            Z = save.ReadSingle();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteSingle(X);
            save.WriteSingle(Y);
            save.WriteSingle(Z);
        }
    }

    public partial class Vec3Padded
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Padding { get; set; }

        public Vec3Padded(DataBuffer save)
        {
            X = save.ReadSingle();
            Y = save.ReadSingle();
            Z = save.ReadSingle();
            Padding = save.ReadSingle();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteSingle(X);
            save.WriteSingle(Y);
            save.WriteSingle(Z);
            save.WriteSingle(Padding);
        }
    }

    public partial class RealTime
    {
        public ulong UnkA { get; set; }
        public ulong Millisecond { get; set; }
        public ulong Second { get; set; }
        public ulong Minute { get; set; }
        public ulong Hour { get; set; }
        public ulong Day { get; set; }
        public ulong UnkB { get; set; }
        public ulong Month { get; set; }
        public ulong Year { get; set; }

        public RealTime(DataBuffer save)
        {
            ulong time = save.ReadUInt64();
            UnkA = (ulong)(time >> 0 & ((1u << 6) - 1));
            Millisecond = (ulong)(time >> 6 & ((1u << 10) - 1));
            Second = (ulong)(time >> 16 & ((1u << 6) - 1));
            Minute = (ulong)(time >> 22 & ((1u << 6) - 1));
            Hour = (ulong)(time >> 28 & ((1u << 5) - 1));
            Day = (ulong)(time >> 33 & ((1u << 5) - 1));
            UnkB = (ulong)(time >> 38 & ((1u << 9) - 1));
            Month = (ulong)(time >> 47 & ((1u << 4) - 1));
            Year = (ulong)(time >> 51 & ((1u << 11) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            ulong time = 0;
            time |= (ulong)((UnkA & ((1u << 6) - 1)) << 0);
            time |= (ulong)((Millisecond & ((1u << 10) - 1)) << 6);
            time |= (ulong)((Second & ((1u << 6) - 1)) << 16);
            time |= (ulong)((Minute & ((1u << 6) - 1)) << 22);
            time |= (ulong)((Hour & ((1u << 5) - 1)) << 28);
            time |= (ulong)((Day & ((1u << 5) - 1)) << 33);
            time |= (ulong)((UnkB & ((1u << 9) - 1)) << 38);
            time |= (ulong)((Month & ((1u << 4) - 1)) << 47);
            time |= (ulong)((Year & ((1u << 11) - 1)) << 51);
            save.WriteUInt64(time);
        }
    }

    public partial class GameTime
    {
        public uint Second { get; set; }
        public uint Minute { get; set; }
        public uint Hour { get; set; }
        public uint Day { get; set; }

        public GameTime(DataBuffer save)
        {
            uint time = save.ReadUInt32();
            Second = (uint)(time >> 0 & ((1u << 6) - 1));
            Minute = (uint)(time >> 6 & ((1u << 6) - 1));
            Hour = (uint)(time >> 12 & ((1u << 5) - 1));
            Day = (uint)(time >> 17 & ((1u << 15) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            uint time = 0;
            time |= (uint)((Second & ((1u << 6) - 1)) << 0);
            time |= (uint)((Minute & ((1u << 6) - 1)) << 6);
            time |= (uint)((Hour & ((1u << 5) - 1)) << 12);
            time |= (uint)((Day & ((1u << 15) - 1)) << 17);
            save.WriteUInt32(time);
        }
    }

    public partial class ElapseTime
    {
        public uint Second { get; set; }
        public uint Minute { get; set; }
        public uint Hour { get; set; }

        public ElapseTime(DataBuffer save)
        {
            uint time = save.ReadUInt32();
            Second = (uint)(time >> 0 & ((1u << 6) - 1));
            Minute = (uint)(time >> 6 & ((1u << 6) - 1));
            Hour = (uint)(time >> 12 & ((1u << 20) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            uint time = 0;
            time |= (uint)((Second & ((1u << 6) - 1)) << 0);
            time |= (uint)((Minute & ((1u << 6) - 1)) << 6);
            time |= (uint)((Hour & ((1u << 20) - 1)) << 12);
            save.WriteUInt32(time);
        }
    }

    public partial class GfAchievQuest
    {
        public ushort QuestID { get; set; }
        public ushort field_2 { get; set; }
        public uint Count { get; set; }
        public uint MaxCount { get; set; }
        public ushort field_C { get; set; }
        public ushort StatsID { get; set; }
        public ushort TaskType { get; set; }
        public ushort Column { get; set; }
        public ushort Row { get; set; }
        public ushort BladeId { get; set; }
        public ushort AchievementId { get; set; }

        public GfAchievQuest(DataBuffer save)
        {
            QuestID = save.ReadUInt16();
            field_2 = save.ReadUInt16();
            Count = save.ReadUInt32();
            MaxCount = save.ReadUInt32();
            field_C = save.ReadUInt16();
            StatsID = save.ReadUInt16();
            TaskType = save.ReadUInt16();
            Column = save.ReadUInt16();
            Row = save.ReadUInt16();
            BladeId = save.ReadUInt16();
            AchievementId = save.ReadUInt16();
            save.Position += 2;
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(QuestID);
            save.WriteUInt16(field_2);
            save.WriteUInt32(Count);
            save.WriteUInt32(MaxCount);
            save.WriteUInt16(field_C);
            save.WriteUInt16(StatsID);
            save.WriteUInt16(TaskType);
            save.WriteUInt16(Column);
            save.WriteUInt16(Row);
            save.WriteUInt16(BladeId);
            save.WriteUInt16(AchievementId);
            save.Position += 2;
        }
    }

    public partial class GfAchievInfo
    {
        public ushort Id { get; set; }
        public GfAchievQuest[] AchievQuests { get; set; } = new GfAchievQuest[5];

        public GfAchievInfo(DataBuffer save)
        {
            Id = save.ReadUInt16();
            save.Position += 2;

            for (int i = 0; i < AchievQuests.Length; i++)
            {
                AchievQuests[i] = new GfAchievQuest(save);
            }
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(Id);
            save.Position += 2;

            for (int i = 0; i < AchievQuests.Length; i++)
            {
                AchievQuests[i].WriteSave(save);
            }
        }
    }

    public partial class GfItemHandle
    {
        public uint Type { get; set; }
        public uint Serial { get; set; }

        public GfItemHandle(DataBuffer save)
        {
            uint handle = save.ReadUInt32();
            Type = (uint)(handle >> 0 & ((1u << 6) - 1));
            Serial = (uint)(handle >> 6 & ((1u << 26) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            uint handle = 0;
            handle |= (uint)((Type & ((1u << 6) - 1)) << 0);
            handle |= (uint)((Serial & ((1u << 26) - 1)) << 6);
            save.WriteUInt32(handle);
        }
    }

    public partial class GfItemHandle16
    {
        public ushort Type { get; set; }
        public ushort Serial { get; set; }

        public GfItemHandle16(DataBuffer save)
        {
            ushort handle = save.ReadUInt16();
            Type = (ushort)(handle >> 0 & ((1u << 6) - 1));
            Serial = (ushort)(handle >> 6 & ((1u << 10) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            ushort handle = 0;
            handle |= (ushort)((Type & ((1u << 6) - 1)) << 0);
            handle |= (ushort)((Serial & ((1u << 10) - 1)) << 6);
            save.WriteUInt16(handle);
        }
    }

    public partial class HanaCircuits
    {
        public ushort Specials0 { get; set; }
        public ushort Specials1 { get; set; }
        public ushort Specials2 { get; set; }
        public ushort Skill0 { get; set; }
        public ushort Skill1 { get; set; }
        public ushort Skill2 { get; set; }

        public HanaCircuits(DataBuffer save)
        {
            ushort circuits = save.ReadUInt16();
            Specials0 = (ushort)(circuits >> 0 & ((1u << 1) - 1));
            Specials1 = (ushort)(circuits >> 1 & ((1u << 1) - 1));
            Specials2 = (ushort)(circuits >> 2 & ((1u << 1) - 1));
            Skill0 = (ushort)(circuits >> 3 & ((1u << 1) - 1));
            Skill1 = (ushort)(circuits >> 4 & ((1u << 1) - 1));
            Skill2 = (ushort)(circuits >> 5 & ((1u << 1) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            ushort circuits = 0;
            circuits |= (ushort)((Specials0 & ((1u << 1) - 1)) << 0);
            circuits |= (ushort)((Specials1 & ((1u << 1) - 1)) << 1);
            circuits |= (ushort)((Specials2 & ((1u << 1) - 1)) << 2);
            circuits |= (ushort)((Skill0 & ((1u << 1) - 1)) << 3);
            circuits |= (ushort)((Skill1 & ((1u << 1) - 1)) << 4);
            circuits |= (ushort)((Skill2 & ((1u << 1) - 1)) << 5);
            save.WriteUInt16(circuits);
        }
    }

    public partial class GfSDataPartyMember
    {
        public ushort DriverId { get; set; }
        public ushort field_2 { get; set; }
        public ushort field_4 { get; set; }

        public GfSDataPartyMember(DataBuffer save)
        {
            DriverId = save.ReadUInt16();
            field_2 = save.ReadUInt16();
            field_4 = save.ReadUInt16();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(DriverId);
            save.WriteUInt16(field_2);
            save.WriteUInt16(field_4);
        }
    }

    public partial class GfSDataParty
    {
        public GfSDataPartyMember[] Members { get; set; } = new GfSDataPartyMember[10];
        public byte[] gap3C { get; set; } = new byte[4];
        public uint PartyLeader { get; set; }
        public uint field_44 { get; set; }
        public uint field_48 { get; set; }
        public ushort PartyGauge { get; set; }
        public ushort field_4E { get; set; }
        public uint field_50 { get; set; }

        public GfSDataParty(DataBuffer save)
        {
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i] = new GfSDataPartyMember(save);
            }

            for (int i = 0; i < gap3C.Length; i++)
            {
                gap3C[i] = save.ReadUInt8();
            }

            PartyLeader = save.ReadUInt32();
            field_44 = save.ReadUInt32();
            field_48 = save.ReadUInt32();
            PartyGauge = save.ReadUInt16();
            field_4E = save.ReadUInt16();
            field_50 = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i].WriteSave(save);
            }

            for (int i = 0; i < gap3C.Length; i++)
            {
                save.WriteUInt8(gap3C[i]);
            }

            save.WriteUInt32(PartyLeader);
            save.WriteUInt32(field_44);
            save.WriteUInt32(field_48);
            save.WriteUInt16(PartyGauge);
            save.WriteUInt16(field_4E);
            save.WriteUInt32(field_50);
        }
    }

    public partial class GfItemInfo
    {
        public uint Id { get; set; }
        public uint Type { get; set; }
        public uint Count { get; set; }
        public uint Unk1 { get; set; }
        public uint Equipped { get; set; }
        public uint Unk2 { get; set; }
        public ElapseTime Time { get; set; }
        public uint Serial { get; set; }
        public uint Unk3 { get; set; }

        public GfItemInfo(DataBuffer save)
        {
            uint item1 = save.ReadUInt32();
            Id = (uint)(item1 >> 0 & ((1u << 13) - 1));
            Type = (uint)(item1 >> 13 & ((1u << 6) - 1));
            Count = (uint)(item1 >> 19 & ((1u << 10) - 1));
            Unk1 = (uint)(item1 >> 29 & ((1u << 1) - 1));
            Equipped = (uint)(item1 >> 30 & ((1u << 1) - 1));
            Unk2 = (uint)(item1 >> 31 & ((1u << 1) - 1));
            Time = new ElapseTime(save);
            uint item2 = save.ReadUInt32();
            Serial = (uint)(item2 >> 0 & ((1u << 26) - 1));
            Unk3 = (uint)(item2 >> 26 & ((1u << 6) - 1));
        }

        public void WriteSave(DataBuffer save)
        {
            uint item1 = 0;
            item1 |= (uint)((Id & ((1u << 13) - 1)) << 0);
            item1 |= (uint)((Type & ((1u << 6) - 1)) << 13);
            item1 |= (uint)((Count & ((1u << 10) - 1)) << 19);
            item1 |= (uint)((Unk1 & ((1u << 1) - 1)) << 29);
            item1 |= (uint)((Equipped & ((1u << 1) - 1)) << 30);
            item1 |= (uint)((Unk2 & ((1u << 1) - 1)) << 31);
            save.WriteUInt32(item1);
            Time.WriteSave(save);
            uint item2 = 0;
            item2 |= (uint)((Serial & ((1u << 26) - 1)) << 0);
            item2 |= (uint)((Unk3 & ((1u << 6) - 1)) << 26);
            save.WriteUInt32(item2);
        }
    }

    public partial class GfItemBox
    {
        public GfItemInfo[] PcWpnChipBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] PcEquipBox { get; set; } = new GfItemInfo[900];
        public GfItemInfo[] EquipOrbBox { get; set; } = new GfItemInfo[500];
        public GfItemInfo[] SalvageBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] PreciousBox { get; set; } = new GfItemInfo[500];
        public GfItemInfo[] InfoBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] EventBox { get; set; } = new GfItemInfo[100];
        public GfItemInfo[] CollectionListBox { get; set; } = new GfItemInfo[500];
        public GfItemInfo[] TresureBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] EmptyOrbBox { get; set; } = new GfItemInfo[500];
        public GfItemInfo[] FavoriteBox { get; set; } = new GfItemInfo[500];
        public GfItemInfo[] CrystalListBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] BoosterBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] HanaRoleBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] HanaAtrBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] HanaArtsBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] HanaNArtsBox { get; set; } = new GfItemInfo[200];
        public GfItemInfo[] HanaAssistBox { get; set; } = new GfItemInfo[700];
        public uint[] Serials { get; set; } = new uint[19];

        public GfItemBox(DataBuffer save)
        {
            for (int i = 0; i < PcWpnChipBox.Length; i++)
            {
                PcWpnChipBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < PcEquipBox.Length; i++)
            {
                PcEquipBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < EquipOrbBox.Length; i++)
            {
                EquipOrbBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < SalvageBox.Length; i++)
            {
                SalvageBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < PreciousBox.Length; i++)
            {
                PreciousBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < InfoBox.Length; i++)
            {
                InfoBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < EventBox.Length; i++)
            {
                EventBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < CollectionListBox.Length; i++)
            {
                CollectionListBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < TresureBox.Length; i++)
            {
                TresureBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < EmptyOrbBox.Length; i++)
            {
                EmptyOrbBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < FavoriteBox.Length; i++)
            {
                FavoriteBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < CrystalListBox.Length; i++)
            {
                CrystalListBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < BoosterBox.Length; i++)
            {
                BoosterBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < HanaRoleBox.Length; i++)
            {
                HanaRoleBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < HanaAtrBox.Length; i++)
            {
                HanaAtrBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < HanaArtsBox.Length; i++)
            {
                HanaArtsBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < HanaNArtsBox.Length; i++)
            {
                HanaNArtsBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < HanaAssistBox.Length; i++)
            {
                HanaAssistBox[i] = new GfItemInfo(save);
            }

            for (int i = 0; i < Serials.Length; i++)
            {
                Serials[i] = save.ReadUInt32();
            }
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < PcWpnChipBox.Length; i++)
            {
                PcWpnChipBox[i].WriteSave(save);
            }

            for (int i = 0; i < PcEquipBox.Length; i++)
            {
                PcEquipBox[i].WriteSave(save);
            }

            for (int i = 0; i < EquipOrbBox.Length; i++)
            {
                EquipOrbBox[i].WriteSave(save);
            }

            for (int i = 0; i < SalvageBox.Length; i++)
            {
                SalvageBox[i].WriteSave(save);
            }

            for (int i = 0; i < PreciousBox.Length; i++)
            {
                PreciousBox[i].WriteSave(save);
            }

            for (int i = 0; i < InfoBox.Length; i++)
            {
                InfoBox[i].WriteSave(save);
            }

            for (int i = 0; i < EventBox.Length; i++)
            {
                EventBox[i].WriteSave(save);
            }

            for (int i = 0; i < CollectionListBox.Length; i++)
            {
                CollectionListBox[i].WriteSave(save);
            }

            for (int i = 0; i < TresureBox.Length; i++)
            {
                TresureBox[i].WriteSave(save);
            }

            for (int i = 0; i < EmptyOrbBox.Length; i++)
            {
                EmptyOrbBox[i].WriteSave(save);
            }

            for (int i = 0; i < FavoriteBox.Length; i++)
            {
                FavoriteBox[i].WriteSave(save);
            }

            for (int i = 0; i < CrystalListBox.Length; i++)
            {
                CrystalListBox[i].WriteSave(save);
            }

            for (int i = 0; i < BoosterBox.Length; i++)
            {
                BoosterBox[i].WriteSave(save);
            }

            for (int i = 0; i < HanaRoleBox.Length; i++)
            {
                HanaRoleBox[i].WriteSave(save);
            }

            for (int i = 0; i < HanaAtrBox.Length; i++)
            {
                HanaAtrBox[i].WriteSave(save);
            }

            for (int i = 0; i < HanaArtsBox.Length; i++)
            {
                HanaArtsBox[i].WriteSave(save);
            }

            for (int i = 0; i < HanaNArtsBox.Length; i++)
            {
                HanaNArtsBox[i].WriteSave(save);
            }

            for (int i = 0; i < HanaAssistBox.Length; i++)
            {
                HanaAssistBox[i].WriteSave(save);
            }

            for (int i = 0; i < Serials.Length; i++)
            {
                save.WriteUInt32(Serials[i]);
            }
        }
    }

    public partial class GameFlag
    {
        public byte[] Flags1Bit { get; set; } = new byte[65536];
        public byte[] Flags2Bit { get; set; } = new byte[65536];
        public byte[] Flags4Bit { get; set; } = new byte[8192];
        public byte[] Flags8Bit { get; set; } = new byte[8192];
        public ushort[] Flags16Bit { get; set; } = new ushort[3072];
        public uint[] Flags32Bit { get; set; } = new uint[3336];

        public GameFlag(DataBuffer save)
        {
            Read.ReadBitfieldArray(save, Flags1Bit, 65536, 1);
            Read.ReadBitfieldArray(save, Flags2Bit, 65536, 2);
            Read.ReadBitfieldArray(save, Flags4Bit, 8192, 4);

            for (int i = 0; i < Flags8Bit.Length; i++)
            {
                Flags8Bit[i] = save.ReadUInt8();
            }

            for (int i = 0; i < Flags16Bit.Length; i++)
            {
                Flags16Bit[i] = save.ReadUInt16();
            }

            for (int i = 0; i < Flags32Bit.Length; i++)
            {
                Flags32Bit[i] = save.ReadUInt32();
            }
        }

        public void WriteSave(DataBuffer save)
        {
            Write.WriteBitfieldArray(save, Flags1Bit, 65536, 1);
            Write.WriteBitfieldArray(save, Flags2Bit, 65536, 2);
            Write.WriteBitfieldArray(save, Flags4Bit, 8192, 4);

            for (int i = 0; i < Flags8Bit.Length; i++)
            {
                save.WriteUInt8(Flags8Bit[i]);
            }

            for (int i = 0; i < Flags16Bit.Length; i++)
            {
                save.WriteUInt16(Flags16Bit[i]);
            }

            for (int i = 0; i < Flags32Bit.Length; i++)
            {
                save.WriteUInt32(Flags32Bit[i]);
            }
        }
    }

    public partial class SDataMap
    {
        public Vec3Padded[] DriverPositions { get; set; } = new Vec3Padded[3];
        public Vec3Padded[] BladePositions { get; set; } = new Vec3Padded[3];
        public Vec3Padded[] DriverRotations { get; set; } = new Vec3Padded[3];
        public Vec3Padded[] BladeRotations { get; set; } = new Vec3Padded[3];
        public uint MapJumpId { get; set; }

        public SDataMap(DataBuffer save)
        {
            for (int i = 0; i < DriverPositions.Length; i++)
            {
                DriverPositions[i] = new Vec3Padded(save);
            }

            for (int i = 0; i < BladePositions.Length; i++)
            {
                BladePositions[i] = new Vec3Padded(save);
            }

            for (int i = 0; i < DriverRotations.Length; i++)
            {
                DriverRotations[i] = new Vec3Padded(save);
            }

            for (int i = 0; i < BladeRotations.Length; i++)
            {
                BladeRotations[i] = new Vec3Padded(save);
            }

            MapJumpId = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < DriverPositions.Length; i++)
            {
                DriverPositions[i].WriteSave(save);
            }

            for (int i = 0; i < BladePositions.Length; i++)
            {
                BladePositions[i].WriteSave(save);
            }

            for (int i = 0; i < DriverRotations.Length; i++)
            {
                DriverRotations[i].WriteSave(save);
            }

            for (int i = 0; i < BladeRotations.Length; i++)
            {
                BladeRotations[i].WriteSave(save);
            }

            save.WriteUInt32(MapJumpId);
        }
    }

    public partial class MercenaryTeam
    {
        public ushort[] MemberIds { get; set; } = new ushort[6];
        public uint field_C { get; set; }
        public uint TeamId { get; set; }
        public uint MissionId { get; set; }
        public uint field_18 { get; set; }
        public uint MissionTime { get; set; }
        public uint MissionTimeOriginal { get; set; }
        public uint field_24 { get; set; }

        public MercenaryTeam(DataBuffer save)
        {
            for (int i = 0; i < MemberIds.Length; i++)
            {
                MemberIds[i] = save.ReadUInt16();
            }

            field_C = save.ReadUInt32();
            TeamId = save.ReadUInt32();
            MissionId = save.ReadUInt32();
            field_18 = save.ReadUInt32();
            MissionTime = save.ReadUInt32();
            MissionTimeOriginal = save.ReadUInt32();
            field_24 = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < MemberIds.Length; i++)
            {
                save.WriteUInt16(MemberIds[i]);
            }

            save.WriteUInt32(field_C);
            save.WriteUInt32(TeamId);
            save.WriteUInt32(MissionId);
            save.WriteUInt32(field_18);
            save.WriteUInt32(MissionTime);
            save.WriteUInt32(MissionTimeOriginal);
            save.WriteUInt32(field_24);
        }
    }

    public partial class FixedVector3MercenaryTeam
    {
        public MercenaryTeam[] Data { get; set; } = new MercenaryTeam[3];
        public ulong Length { get; set; }

        public FixedVector3MercenaryTeam(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new MercenaryTeam(save);
            }

            Length = save.ReadUInt64();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i].WriteSave(save);
            }

            save.WriteUInt64(Length);
        }
    }

    public partial class FixedVector256QuestId
    {
        public uint[] Data { get; set; } = new uint[256];
        public uint Length { get; set; }

        public FixedVector256QuestId(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = save.ReadUInt32();
            }

            Length = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                save.WriteUInt32(Data[i]);
            }

            save.WriteUInt32(Length);
        }
    }

    public partial class MercenaryTeamPreset
    {
        public ushort[] Members { get; set; } = new ushort[6];

        public MercenaryTeamPreset(DataBuffer save)
        {
            for (int i = 0; i < Members.Length; i++)
            {
                Members[i] = save.ReadUInt16();
            }
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Members.Length; i++)
            {
                save.WriteUInt16(Members[i]);
            }
        }
    }

    public partial class TaskAchieve
    {
        public ushort field_0 { get; set; }
        public ushort field_2 { get; set; }
        public ushort field_4 { get; set; }
        public ushort field_6 { get; set; }
        public uint field_8 { get; set; }

        public TaskAchieve(DataBuffer save)
        {
            field_0 = save.ReadUInt16();
            field_2 = save.ReadUInt16();
            field_4 = save.ReadUInt16();
            field_6 = save.ReadUInt16();
            field_8 = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(field_0);
            save.WriteUInt16(field_2);
            save.WriteUInt16(field_4);
            save.WriteUInt16(field_6);
            save.WriteUInt32(field_8);
        }
    }

    public partial class FixedVector128TaskAchieve
    {
        public TaskAchieve[] Data { get; set; } = new TaskAchieve[128];
        public ulong Length { get; set; }

        public FixedVector128TaskAchieve(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new TaskAchieve(save);
            }

            Length = save.ReadUInt64();
        }

        public void WriteSave(DataBuffer save)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i].WriteSave(save);
            }

            save.WriteUInt64(Length);
        }
    }

    public partial class SDataWeather
    {
        public string Name { get; set; }
        public uint field_4 { get; set; }
        public uint field_8 { get; set; }
        public uint field_C { get; set; }
        public float field_10 { get; set; }
        public float field_14 { get; set; }
        public uint field_18 { get; set; }
        public uint field_1C { get; set; }

        public SDataWeather(DataBuffer save)
        {
            Name = save.ReadUTF8(4);
            field_4 = save.ReadUInt32();
            field_8 = save.ReadUInt32();
            field_C = save.ReadUInt32();
            field_10 = save.ReadSingle();
            field_14 = save.ReadSingle();
            field_18 = save.ReadUInt32();
            field_1C = save.ReadUInt32();
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUTF8(Name);
            save.WriteUInt32(field_4);
            save.WriteUInt32(field_8);
            save.WriteUInt32(field_C);
            save.WriteSingle(field_10);
            save.WriteSingle(field_14);
            save.WriteUInt32(field_18);
            save.WriteUInt32(field_1C);
        }
    }

    public partial class SDataEvent
    {
        public ushort EventId { get; set; }
        public ushort Creator { get; set; }
        public ushort PlayBladeId { get; set; }
        public ushort VoiceID { get; set; }
        public ushort Attribute { get; set; }
        public ushort ExtraParts { get; set; }
        public ushort A { get; set; }
        public ushort[] Weapons { get; set; } = new ushort[10];
        public ushort[] B { get; set; } = new ushort[6];
        public ushort[] Blades { get; set; } = new ushort[10];
        public ushort[] C { get; set; } = new ushort[5];
        public GameTime GameTime { get; set; }
        public ushort CurrentMapWeatherID { get; set; }
        public ushort CurrentWtrType { get; set; }
        public ushort[] D { get; set; } = new ushort[8];

        public SDataEvent(DataBuffer save)
        {
            EventId = save.ReadUInt16();
            Creator = save.ReadUInt16();
            PlayBladeId = save.ReadUInt16();
            VoiceID = save.ReadUInt16();
            Attribute = save.ReadUInt16();
            ExtraParts = save.ReadUInt16();
            A = save.ReadUInt16();

            for (int i = 0; i < Weapons.Length; i++)
            {
                Weapons[i] = save.ReadUInt16();
            }

            for (int i = 0; i < B.Length; i++)
            {
                B[i] = save.ReadUInt16();
            }

            for (int i = 0; i < Blades.Length; i++)
            {
                Blades[i] = save.ReadUInt16();
            }

            for (int i = 0; i < C.Length; i++)
            {
                C[i] = save.ReadUInt16();
            }

            GameTime = new GameTime(save);
            CurrentMapWeatherID = save.ReadUInt16();
            CurrentWtrType = save.ReadUInt16();

            for (int i = 0; i < D.Length; i++)
            {
                D[i] = save.ReadUInt16();
            }
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt16(EventId);
            save.WriteUInt16(Creator);
            save.WriteUInt16(PlayBladeId);
            save.WriteUInt16(VoiceID);
            save.WriteUInt16(Attribute);
            save.WriteUInt16(ExtraParts);
            save.WriteUInt16(A);

            for (int i = 0; i < Weapons.Length; i++)
            {
                save.WriteUInt16(Weapons[i]);
            }

            for (int i = 0; i < B.Length; i++)
            {
                save.WriteUInt16(B[i]);
            }

            for (int i = 0; i < Blades.Length; i++)
            {
                save.WriteUInt16(Blades[i]);
            }

            for (int i = 0; i < C.Length; i++)
            {
                save.WriteUInt16(C[i]);
            }

            GameTime.WriteSave(save);
            save.WriteUInt16(CurrentMapWeatherID);
            save.WriteUInt16(CurrentWtrType);

            for (int i = 0; i < D.Length; i++)
            {
                save.WriteUInt16(D[i]);
            }
        }
    }

    public partial class SDataGame
    {
        public uint Money { get; set; }
        public uint LandmarkPoint { get; set; }
        public Vec3 LandmarkPos { get; set; }
        public float LandmarkRotY { get; set; }
        public ushort isTimeStop { get; set; }
        public ushort ChapterSaveScenarioFlag { get; set; }
        public ushort ChapterSaveEventId { get; set; }
        public ushort field_2A { get; set; }
        public SDataDriver[] Drivers { get; set; } = new SDataDriver[16];
        public SDataBlade[] Blades { get; set; } = new SDataBlade[422];
        public GfSDataParty Party { get; set; }
        public GfItemBox ItemBox { get; set; }
        public GameFlag Flags { get; set; }
        public uint ScenarioQuest { get; set; }
        public uint CurrentQuest { get; set; }
        public SDataMap Map { get; set; }
        public GameTime GameTime { get; set; }
        public ElapseTime ElapseTime { get; set; }
        public FixedVector3MercenaryTeam MercTeams { get; set; }
        public MercenaryTeamPreset[] MercPresets { get; set; } = new MercenaryTeamPreset[8];
        public ushort[] CommonBladeIds { get; set; } = new ushort[192];
        public float PlayerCameraDistance { get; set; }
        public uint GameClearCount { get; set; }
        public FixedVector128TaskAchieve AchievementTasks { get; set; }
        public FixedVector256QuestId Quests { get; set; }
        public SDataWeather[] Weather { get; set; } = new SDataWeather[64];
        public uint EtherCrystals { get; set; }
        public float MoveDistance { get; set; }
        public float MoveDistanceB { get; set; }
        public uint AssurePoint { get; set; }
        public uint AssureCount { get; set; }
        public ushort RareBladeAppearType { get; set; }
        public ushort field_10AD52 { get; set; }
        public uint CoinCount { get; set; }
        public uint[] SavedEnemyHp { get; set; } = new uint[3];
        public RealTime Time { get; set; }
        public float CameraHeight { get; set; }
        public byte[] Minigame { get; set; } = new byte[256];
        public float CameraYaw { get; set; }
        public float CameraPitch { get; set; }
        public byte CameraFreeMode { get; set; }
        public byte IsHikariCurrent { get; set; }
        public ushort AutoEventAfterLoad { get; set; }
        public byte IsCollectFlagNewVersion { get; set; }
        public byte IsEndGameSave { get; set; }
        public byte CameraSide { get; set; }
        public byte gap_10AE83 { get; set; }
        public SDataEvent[] Events { get; set; } = new SDataEvent[500];
        public uint EventsLength { get; set; }
        public byte[] gap1171D8 { get; set; } = new byte[400];
        public float field_117368 { get; set; }
        public uint[] ContentVersions { get; set; } = new uint[5];
        public byte[] gap_117380 { get; set; } = new byte[776];
        public uint field_117688 { get; set; }

        public SDataGame(DataBuffer save)
        {
            Money = save.ReadUInt32();
            LandmarkPoint = save.ReadUInt32();
            save.Position += 8;
            LandmarkPos = new Vec3(save);
            save.Position += 4;
            LandmarkRotY = save.ReadSingle();
            isTimeStop = save.ReadUInt16();
            ChapterSaveScenarioFlag = save.ReadUInt16();
            ChapterSaveEventId = save.ReadUInt16();
            field_2A = save.ReadUInt16();

            for (int i = 0; i < Drivers.Length; i++)
            {
                Drivers[i] = new SDataDriver(save);
            }

            for (int i = 0; i < Blades.Length; i++)
            {
                Blades[i] = new SDataBlade(save);
            }

            Party = new GfSDataParty(save);
            ItemBox = new GfItemBox(save);
            Flags = new GameFlag(save);
            ScenarioQuest = save.ReadUInt32();
            CurrentQuest = save.ReadUInt32();
            save.Position += 4;
            Map = new SDataMap(save);
            save.Position += 12;
            GameTime = new GameTime(save);
            ElapseTime = new ElapseTime(save);
            MercTeams = new FixedVector3MercenaryTeam(save);

            for (int i = 0; i < MercPresets.Length; i++)
            {
                MercPresets[i] = new MercenaryTeamPreset(save);
            }

            for (int i = 0; i < CommonBladeIds.Length; i++)
            {
                CommonBladeIds[i] = save.ReadUInt16();
            }

            PlayerCameraDistance = save.ReadSingle();
            GameClearCount = save.ReadUInt32();
            AchievementTasks = new FixedVector128TaskAchieve(save);
            Quests = new FixedVector256QuestId(save);

            for (int i = 0; i < Weather.Length; i++)
            {
                Weather[i] = new SDataWeather(save);
            }

            EtherCrystals = save.ReadUInt32();
            MoveDistance = save.ReadSingle();
            MoveDistanceB = save.ReadSingle();
            AssurePoint = save.ReadUInt32();
            AssureCount = save.ReadUInt32();
            RareBladeAppearType = save.ReadUInt16();
            field_10AD52 = save.ReadUInt16();
            CoinCount = save.ReadUInt32();

            for (int i = 0; i < SavedEnemyHp.Length; i++)
            {
                SavedEnemyHp[i] = save.ReadUInt32();
            }
            save.Position += 4;

            Time = new RealTime(save);
            CameraHeight = save.ReadSingle();

            for (int i = 0; i < Minigame.Length; i++)
            {
                Minigame[i] = save.ReadUInt8();
            }

            CameraYaw = save.ReadSingle();
            CameraPitch = save.ReadSingle();
            CameraFreeMode = save.ReadUInt8();
            IsHikariCurrent = save.ReadUInt8();
            AutoEventAfterLoad = save.ReadUInt16();
            IsCollectFlagNewVersion = save.ReadUInt8();
            IsEndGameSave = save.ReadUInt8();
            CameraSide = save.ReadUInt8();
            gap_10AE83 = save.ReadUInt8();

            for (int i = 0; i < Events.Length; i++)
            {
                Events[i] = new SDataEvent(save);
            }

            EventsLength = save.ReadUInt32();

            for (int i = 0; i < gap1171D8.Length; i++)
            {
                gap1171D8[i] = save.ReadUInt8();
            }

            field_117368 = save.ReadSingle();

            for (int i = 0; i < ContentVersions.Length; i++)
            {
                ContentVersions[i] = save.ReadUInt32();
            }

            for (int i = 0; i < gap_117380.Length; i++)
            {
                gap_117380[i] = save.ReadUInt8();
            }

            field_117688 = save.ReadUInt32();
            save.Position += 4;
        }

        public void WriteSave(DataBuffer save)
        {
            save.WriteUInt32(Money);
            save.WriteUInt32(LandmarkPoint);
            save.Position += 8;
            LandmarkPos.WriteSave(save);
            save.Position += 4;
            save.WriteSingle(LandmarkRotY);
            save.WriteUInt16(isTimeStop);
            save.WriteUInt16(ChapterSaveScenarioFlag);
            save.WriteUInt16(ChapterSaveEventId);
            save.WriteUInt16(field_2A);

            for (int i = 0; i < Drivers.Length; i++)
            {
                Drivers[i].WriteSave(save);
            }

            for (int i = 0; i < Blades.Length; i++)
            {
                Blades[i].WriteSave(save);
            }

            Party.WriteSave(save);
            ItemBox.WriteSave(save);
            Flags.WriteSave(save);
            save.WriteUInt32(ScenarioQuest);
            save.WriteUInt32(CurrentQuest);
            save.Position += 4;
            Map.WriteSave(save);
            save.Position += 12;
            GameTime.WriteSave(save);
            ElapseTime.WriteSave(save);
            MercTeams.WriteSave(save);

            for (int i = 0; i < MercPresets.Length; i++)
            {
                MercPresets[i].WriteSave(save);
            }

            for (int i = 0; i < CommonBladeIds.Length; i++)
            {
                save.WriteUInt16(CommonBladeIds[i]);
            }

            save.WriteSingle(PlayerCameraDistance);
            save.WriteUInt32(GameClearCount);
            AchievementTasks.WriteSave(save);
            Quests.WriteSave(save);

            for (int i = 0; i < Weather.Length; i++)
            {
                Weather[i].WriteSave(save);
            }

            save.WriteUInt32(EtherCrystals);
            save.WriteSingle(MoveDistance);
            save.WriteSingle(MoveDistanceB);
            save.WriteUInt32(AssurePoint);
            save.WriteUInt32(AssureCount);
            save.WriteUInt16(RareBladeAppearType);
            save.WriteUInt16(field_10AD52);
            save.WriteUInt32(CoinCount);

            for (int i = 0; i < SavedEnemyHp.Length; i++)
            {
                save.WriteUInt32(SavedEnemyHp[i]);
            }
            save.Position += 4;

            Time.WriteSave(save);
            save.WriteSingle(CameraHeight);

            for (int i = 0; i < Minigame.Length; i++)
            {
                save.WriteUInt8(Minigame[i]);
            }

            save.WriteSingle(CameraYaw);
            save.WriteSingle(CameraPitch);
            save.WriteUInt8(CameraFreeMode);
            save.WriteUInt8(IsHikariCurrent);
            save.WriteUInt16(AutoEventAfterLoad);
            save.WriteUInt8(IsCollectFlagNewVersion);
            save.WriteUInt8(IsEndGameSave);
            save.WriteUInt8(CameraSide);
            save.WriteUInt8(gap_10AE83);

            for (int i = 0; i < Events.Length; i++)
            {
                Events[i].WriteSave(save);
            }

            save.WriteUInt32(EventsLength);

            for (int i = 0; i < gap1171D8.Length; i++)
            {
                save.WriteUInt8(gap1171D8[i]);
            }

            save.WriteSingle(field_117368);

            for (int i = 0; i < ContentVersions.Length; i++)
            {
                save.WriteUInt32(ContentVersions[i]);
            }

            for (int i = 0; i < gap_117380.Length; i++)
            {
                save.WriteUInt8(gap_117380[i]);
            }

            save.WriteUInt32(field_117688);
            save.Position += 4;
        }
    }
}
