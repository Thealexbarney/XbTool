// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedField.Global

using System;

namespace XbTool.Types
{
    [BdatType]
    [Serializable]
    public class BdatEnum
    {
        public int Id;
        public string name;
        public short value;
    }

    [BdatType]
    [Serializable]
    public class BdatStateEnum
    {
        public int Id;
        public string name;
        public short value;
        public string stat;
    }

    [BdatType]
    [Serializable]
    public class BdatValue
    {
        public int Id;
        public uint Value;
    }

    [BdatType]
    [Serializable]
    public class BLD_BladeList
    {
        public int Id;
        public byte Category;
        public ushort StatusID;
        public CHR_Bl _StatusID;
    }

    [BdatType]
    [Serializable]
    public class BLD_BladeModelList
    {
        public int Id;
        public byte QuestRace;
        public byte Gender;
        public byte IdeaMin;
        public byte IdeaMax;
        public byte Model1;
        public byte Model2;
        public byte PartsNumMin;
        public byte PartsNumMax;
        public byte Parts1;
        public byte Parts2;
        public byte Parts3;
        public byte Parts4;
        public MNU_Name _Gender;
        public MNU_Name _QuestRace;
        public byte[] _Parts;
    }

    [BdatType]
    [Serializable]
    public class BLD_BladeTable
    {
        public int Id;
        public ushort CharaID1;
        public byte CharID1Percent;
        public ushort CharaID2;
        public byte CharID2Percent;
        public ushort CharaID3;
        public byte CharID3Percent;
        public ushort CharaID4;
        public byte CharID4Percent;
        public ushort CharaID5;
        public byte CharID5Percent;
        public ushort CharaID6;
        public byte CharID6Percent;
        public ushort CharaID7;
        public byte CharID7Percent;
        public ushort CharaID8;
        public byte CharID8Percent;
        public ushort CharaID9;
        public byte CharID9Percent;
        public ushort CharaID10;
        public byte CharID10Percent;
        public ushort CharaID11;
        public byte CharID11Percent;
        public ushort CharaID12;
        public byte CharID12Percent;
        public ushort CharaID13;
        public byte CharID13Percent;
        public ushort CharaID14;
        public byte CharID14Percent;
        public ushort CharaID15;
        public byte CharID15Percent;
        public ushort CharaID16;
        public byte CharID16Percent;
    }

    [BdatType]
    [Serializable]
    public class BLD_CommonList
    {
        public int Id;
        public byte QuestRace;
        public byte Gender;
        public uint Weapon;
        public byte Atr;
        public ushort ModelTable;
        public byte IdeaType;
        public byte IdeaMin;
        public byte IdeaMax;
        public byte Ratio;
        public byte RarityMin;
        public byte RarityMax;
        public byte Fskill;
        public byte ArtsAchievementSet1;
        public byte ArtsAchievementSet2;
        public byte ArtsAchievementSet3;
        public byte SkillAchievementSet1;
        public byte SkillAchievementSet2;
        public byte SkillAchievementSet3;
        public byte FskillAchivementSet1;
        public byte FskillAchivementSet2;
        public byte FskillAchivementSet3;
        public byte KeyAchievementSet;
        public byte FavoriteCategoryMax;
        public byte FavoriteItemMax;
        public FLD_AchievementSet _ArtsAchievementSet1;
        public FLD_AchievementSet _ArtsAchievementSet2;
        public FLD_AchievementSet _ArtsAchievementSet3;
        public FieldSkillCategory _Fskill;
        public FLD_AchievementSet _FskillAchivementSet1;
        public FLD_AchievementSet _FskillAchivementSet2;
        public FLD_AchievementSet _FskillAchivementSet3;
        public MNU_Name _Gender;
        public IdeaCategoryBits _IdeaType;
        public FLD_AchievementSet _KeyAchievementSet;
        public BLD_BladeModelList _ModelTable;
        public MNU_Name _QuestRace;
        public FLD_AchievementSet _SkillAchievementSet1;
        public FLD_AchievementSet _SkillAchievementSet2;
        public FLD_AchievementSet _SkillAchievementSet3;
    }

    [BdatType]
    [Serializable]
    public class BLD_Idea
    {
        public int Id;
        public uint NeedPoint;
        public ushort ProbRev;
        public ushort AtrDamRev;
    }

    [BdatType]
    [Serializable]
    public class BLD_IdeaTable
    {
        public int Id;
        public ushort Item;
        public byte IdeaBlue;
        public byte IdeaRed;
        public byte IdeaWhite;
        public byte IdeaBlack;
        public ushort Condition;
        public ushort BladeTable;
    }

    [BdatType]
    [Serializable]
    public class BLD_NameList
    {
        public int Id;
        public ushort Category;
        public byte Race;
        public byte Gender;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Category;
        public MNU_Name _Gender;
    }

    [BdatType]
    [Serializable]
    public class BLD_RareList
    {
        public int Id;
        public ushort Blade;
        public ushort Condition;
        public float Prob1;
        public byte Assure1;
        public float Prob2;
        public byte Assure2;
        public float Prob3;
        public byte Assure3;
        public float Prob4;
        public byte Assure4;
        public float Prob5;
        public byte Assure5;
        public CHR_Bl _Blade;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class BLD_ReleaceReward
    {
        public int Id;
        public ushort Releace001;
        public ushort Releace002;
        public ushort Releace003;
        public ushort Releace004;
        public ushort Releace005;
        public ushort Releace006;
        public ushort Releace007;
    }

    [BdatType]
    [Serializable]
    public class BTL_Ai
    {
        public int Id;
        public string Script;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_Bl
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Caption;
        public byte WpnType;
        public byte CmnBlType;
        public byte SpLv;
        public byte ActNo;
        public byte MoveRev;
        public byte LoopNum;
        public byte ArtsType;
        public byte ArtsBuff;
        public byte ArtsDeBuff;
        public byte CircleID;
        public byte Flag;
        public byte Target;
        public ushort Distance;
        public byte Multi;
        public byte RangeType;
        public ushort Radius;
        public ushort Length;
        public byte Atr;
        public sbyte Hate;
        public sbyte HitRevise;
        public sbyte CriRevise;
        public ushort BulletID;
        public ushort BulletEffID;
        public byte EfpType;
        public byte BulletNum;
        public byte BulletAngle;
        public byte HitFrm1;
        public byte HitFrm2;
        public byte HitFrm3;
        public byte HitFrm4;
        public byte HitFrm5;
        public byte HitFrm6;
        public byte HitFrm7;
        public byte HitFrm8;
        public byte HitFrm9;
        public byte HitFrm10;
        public byte HitFrm11;
        public byte HitFrm12;
        public byte HitFrm13;
        public byte HitFrm14;
        public byte HitFrm15;
        public byte HitFrm16;
        public byte Efp1;
        public byte Efp2;
        public byte Efp3;
        public byte Efp4;
        public byte Efp5;
        public byte Efp6;
        public byte Efp7;
        public byte Efp8;
        public byte Efp9;
        public byte Efp10;
        public byte Efp11;
        public byte Efp12;
        public byte Efp13;
        public byte Efp14;
        public byte Efp15;
        public byte Efp16;
        public byte HitDirID1;
        public byte HitDirID2;
        public byte HitDirID3;
        public byte HitDirID4;
        public byte HitDirID5;
        public byte HitDirID6;
        public byte HitDirID7;
        public byte HitDirID8;
        public byte HitDirID9;
        public byte HitDirID10;
        public byte HitDirID11;
        public byte HitDirID12;
        public byte HitDirID13;
        public byte HitDirID14;
        public byte HitDirID15;
        public byte HitDirID16;
        public byte DmgRt1;
        public byte DmgRt2;
        public byte DmgRt3;
        public byte DmgRt4;
        public byte DmgRt5;
        public byte DmgRt6;
        public byte DmgRt7;
        public byte DmgRt8;
        public byte DmgRt9;
        public byte DmgRt10;
        public byte DmgRt11;
        public byte DmgRt12;
        public byte DmgRt13;
        public byte DmgRt14;
        public byte DmgRt15;
        public byte DmgRt16;
        public byte ReAct1;
        public byte ReAct2;
        public byte ReAct3;
        public byte ReAct4;
        public byte ReAct5;
        public byte ReAct6;
        public byte ReAct7;
        public byte ReAct8;
        public byte ReAct9;
        public byte ReAct10;
        public byte ReAct11;
        public byte ReAct12;
        public byte ReAct13;
        public byte ReAct14;
        public byte ReAct15;
        public byte ReAct16;
        public ushort DmgMgn1;
        public ushort DmgMgn2;
        public ushort DmgMgn3;
        public ushort DmgMgn4;
        public ushort DmgMgn5;
        public ushort DmgMgn6;
        public byte AtrNum;
        public ushort Enhance1;
        public ushort Enhance2;
        public ushort Enhance3;
        public ushort Enhance4;
        public ushort Enhance5;
        public ushort Enhance6;
        public byte BtnType;
        public ushort BtnChal1;
        public ushort UI;
        public byte AtrEff1S;
        public byte AtrEff1E;
        public string AtrEff1Ca;
        public byte AtrEff2S;
        public byte AtrEff2E;
        public string AtrEff2Ca;
        public byte AtrEffArtsCa;
        public ushort HitEff;
        public byte VoiceNum;
        public ushort VoiceDelay;
        public byte SeNum;
        public byte GravOffNum;
        public ushort GravOffF;
        public byte GravOnNum;
        public ushort GravOnF;
        public ushort DynSlowRev;
        public bool common;
        public bool Pierce;
        public bool NoMove;
        public bool NoColli;
        public bool NoWpn;
        public bool Return;
        public bool Shoot;
        public bool HitfD;
        public BTL_Buff _ArtsBuff;
        public BTL_Buff _ArtsDeBuff;
        public ArtType _ArtsType;
        public MNU_Name _Atr;
        public MNU_BtnChallenge2 _BtnChal1;
        public BTL_Bullet _BulletID;
        public Message _Caption;
        public CommonBladeType _CmnBlType;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public BTL_Enhance _Enhance3;
        public BTL_Enhance _Enhance4;
        public BTL_Enhance _Enhance5;
        public BTL_Enhance _Enhance6;
        public BTL_HitDirection _HitDirID1;
        public BTL_HitDirection _HitDirID10;
        public BTL_HitDirection _HitDirID11;
        public BTL_HitDirection _HitDirID12;
        public BTL_HitDirection _HitDirID13;
        public BTL_HitDirection _HitDirID14;
        public BTL_HitDirection _HitDirID15;
        public BTL_HitDirection _HitDirID16;
        public BTL_HitDirection _HitDirID2;
        public BTL_HitDirection _HitDirID3;
        public BTL_HitDirection _HitDirID4;
        public BTL_HitDirection _HitDirID5;
        public BTL_HitDirection _HitDirID6;
        public BTL_HitDirection _HitDirID7;
        public BTL_HitDirection _HitDirID8;
        public BTL_HitDirection _HitDirID9;
        public BTL_HitEffect _HitEff;
        public Message _Name;
        public ArtRangeType _RangeType;
        public ReactType _ReAct1;
        public ReactType _ReAct10;
        public ReactType _ReAct11;
        public ReactType _ReAct12;
        public ReactType _ReAct13;
        public ReactType _ReAct14;
        public ReactType _ReAct15;
        public ReactType _ReAct16;
        public ReactType _ReAct2;
        public ReactType _ReAct3;
        public ReactType _ReAct4;
        public ReactType _ReAct5;
        public ReactType _ReAct6;
        public ReactType _ReAct7;
        public ReactType _ReAct8;
        public ReactType _ReAct9;
        public ITM_PcWpnType _WpnType;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_Bl_Cam
    {
        public int Id;
        public byte Camera1;
        public byte Camera2;
        public byte Camera3;
        public byte Camera4;
        public byte Camera5;
        public byte Camera6;
        public byte Camera7;
        public byte Flag;
        public bool EnTarget;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_BlSp
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Caption;
        public byte WpnType;
        public ushort Condition;
        public byte CmnBlType;
        public byte ActNoDr;
        public byte ActNoBl;
        public byte ActNoBl2;
        public byte MoveRev;
        public byte BuddyDr;
        public ushort AddBl;
        public byte ActType;
        public ushort PC01;
        public ushort PC02;
        public ushort PC03;
        public ushort PC06;
        public byte ArtsType;
        public byte ArtsBuff;
        public ushort Flag;
        public byte Target;
        public ushort Distance;
        public byte Multi;
        public byte RangeType;
        public ushort Radius;
        public ushort Length;
        public byte Atr;
        public sbyte Hate;
        public sbyte HitRevise;
        public sbyte CriRevise;
        public ushort BulletID;
        public ushort BulletEffID;
        public byte EfpType;
        public byte BulletNum;
        public byte BulletAngle;
        public byte HitFrm1;
        public byte HitFrm2;
        public byte HitFrm3;
        public byte HitFrm4;
        public byte HitFrm5;
        public byte HitFrm6;
        public byte HitFrm7;
        public byte HitFrm8;
        public byte HitFrm9;
        public byte HitFrm10;
        public byte HitFrm11;
        public byte HitFrm12;
        public byte HitFrm13;
        public byte HitFrm14;
        public byte HitFrm15;
        public byte HitFrm16;
        public byte Efp1;
        public byte Efp2;
        public byte Efp3;
        public byte Efp4;
        public byte Efp5;
        public byte Efp6;
        public byte Efp7;
        public byte Efp8;
        public byte Efp9;
        public byte Efp10;
        public byte Efp11;
        public byte Efp12;
        public byte Efp13;
        public byte Efp14;
        public byte Efp15;
        public byte Efp16;
        public byte HitDirID1;
        public byte HitDirID2;
        public byte HitDirID3;
        public byte HitDirID4;
        public byte HitDirID5;
        public byte HitDirID6;
        public byte HitDirID7;
        public byte HitDirID8;
        public byte HitDirID9;
        public byte HitDirID10;
        public byte HitDirID11;
        public byte HitDirID12;
        public byte HitDirID13;
        public byte HitDirID14;
        public byte HitDirID15;
        public byte HitDirID16;
        public byte DmgRt1;
        public byte DmgRt2;
        public byte DmgRt3;
        public byte DmgRt4;
        public byte DmgRt5;
        public byte DmgRt6;
        public byte DmgRt7;
        public byte DmgRt8;
        public byte DmgRt9;
        public byte DmgRt10;
        public byte DmgRt11;
        public byte DmgRt12;
        public byte DmgRt13;
        public byte DmgRt14;
        public byte DmgRt15;
        public byte DmgRt16;
        public byte ReAct1;
        public byte ReAct2;
        public byte ReAct3;
        public byte ReAct4;
        public byte ReAct5;
        public byte ReAct6;
        public byte ReAct7;
        public byte ReAct8;
        public byte ReAct9;
        public byte ReAct10;
        public byte ReAct11;
        public byte ReAct12;
        public byte ReAct13;
        public byte ReAct14;
        public byte ReAct15;
        public byte ReAct16;
        public ushort DmgMgn;
        public ushort Recast;
        public byte AtrNum;
        public ushort Enhance;
        public byte BtnType;
        public ushort BtnChal1;
        public ushort BtnChal2;
        public ushort BtnChal3;
        public ushort BtnChal6;
        public string Camera1;
        public string Camera2;
        public string Camera3;
        public ushort CameraCT1;
        public ushort CameraCT2;
        public byte CameraEndf;
        public ushort SlowDirection;
        public ushort HitEff;
        public ushort VoiceSet;
        public byte SeNum;
        public byte GravOffNum;
        public ushort GravOffF;
        public byte GravOnNum;
        public ushort GravOnF;
        public bool Pierce;
        public bool NoMove;
        public bool NoColli;
        public bool NoWpn;
        public bool Return;
        public bool TransWpn;
        public bool Fcombo;
        public bool NoPraise;
        public bool Shoot;
        public bool HitfD;
        public CHR_Bl _AddBl;
        public BTL_Buff _ArtsBuff;
        public ArtType _ArtsType;
        public MNU_Name _Atr;
        public MNU_BtnChallenge2 _BtnChal1;
        public MNU_BtnChallenge2 _BtnChal2;
        public MNU_BtnChallenge2 _BtnChal3;
        public MNU_BtnChallenge2 _BtnChal6;
        public BTL_Bullet _BulletID;
        public Message _Caption;
        public CommonBladeType _CmnBlType;
        public BTL_Enhance _Enhance;
        public BTL_HitDirection _HitDirID1;
        public BTL_HitDirection _HitDirID10;
        public BTL_HitDirection _HitDirID11;
        public BTL_HitDirection _HitDirID12;
        public BTL_HitDirection _HitDirID13;
        public BTL_HitDirection _HitDirID14;
        public BTL_HitDirection _HitDirID15;
        public BTL_HitDirection _HitDirID16;
        public BTL_HitDirection _HitDirID2;
        public BTL_HitDirection _HitDirID3;
        public BTL_HitDirection _HitDirID4;
        public BTL_HitDirection _HitDirID5;
        public BTL_HitDirection _HitDirID6;
        public BTL_HitDirection _HitDirID7;
        public BTL_HitDirection _HitDirID8;
        public BTL_HitDirection _HitDirID9;
        public BTL_HitEffect _HitEff;
        public Message _Name;
        public BTL_Arts_BlSp _PC01;
        public BTL_Arts_BlSp _PC02;
        public BTL_Arts_BlSp _PC03;
        public BTL_Arts_BlSp _PC06;
        public ReactType _ReAct1;
        public ReactType _ReAct10;
        public ReactType _ReAct11;
        public ReactType _ReAct12;
        public ReactType _ReAct13;
        public ReactType _ReAct14;
        public ReactType _ReAct15;
        public ReactType _ReAct16;
        public ReactType _ReAct2;
        public ReactType _ReAct3;
        public ReactType _ReAct4;
        public ReactType _ReAct5;
        public ReactType _ReAct6;
        public ReactType _ReAct7;
        public ReactType _ReAct8;
        public ReactType _ReAct9;
        public ITM_PcWpnType _WpnType;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_BlSpVo
    {
        public int Id;
        public byte Talker1;
        public byte MotionNum1;
        public short Motionf1;
        public ushort VoiceNum1;
        public byte Talker2;
        public byte MotionNum2;
        public short Motionf2;
        public ushort VoiceNum2;
        public byte Talker3;
        public byte MotionNum3;
        public short Motionf3;
        public ushort VoiceNum3;
        public byte Talker4;
        public byte MotionNum4;
        public short Motionf4;
        public ushort VoiceNum4;
        public byte Talker5;
        public byte MotionNum5;
        public short Motionf5;
        public ushort VoiceNum5;
        public byte Talker6;
        public byte MotionNum6;
        public short Motionf6;
        public ushort VoiceNum6;
        public byte Talker7;
        public byte MotionNum7;
        public short Motionf7;
        public ushort VoiceNum7;
        public byte Talker8;
        public byte MotionNum8;
        public short Motionf8;
        public ushort VoiceNum8;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_Dr
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Caption;
        public byte Driver;
        public byte WpnType;
        public byte IrType;
        public byte Condition;
        public byte ActNo;
        public byte ActSpeed;
        public byte MoveRev;
        public byte LoopNum;
        public byte IKStNo;
        public byte IKStf;
        public byte IKEndNo;
        public byte IKEndf;
        public byte ArtsType;
        public byte ArtsBuff;
        public byte ArtsDeBuff;
        public byte AtrType;
        public byte Flag;
        public ushort NextArts;
        public byte Target;
        public ushort Distance;
        public byte Multi;
        public byte RangeType;
        public ushort Radius;
        public ushort Length;
        public sbyte Hate;
        public sbyte HitRevise;
        public sbyte CriRevise;
        public ushort BulletID;
        public ushort BulletEffID;
        public byte EfpType;
        public byte BulletNum;
        public byte BulletAngle;
        public byte HitFrm1;
        public byte HitFrm2;
        public byte HitFrm3;
        public byte HitFrm4;
        public byte HitFrm5;
        public byte HitFrm6;
        public byte HitFrm7;
        public byte HitFrm8;
        public byte HitFrm9;
        public byte HitFrm10;
        public byte HitFrm11;
        public byte HitFrm12;
        public byte HitFrm13;
        public byte HitFrm14;
        public byte HitFrm15;
        public byte HitFrm16;
        public byte Efp1;
        public byte Efp2;
        public byte Efp3;
        public byte Efp4;
        public byte Efp5;
        public byte Efp6;
        public byte Efp7;
        public byte Efp8;
        public byte Efp9;
        public byte Efp10;
        public byte Efp11;
        public byte Efp12;
        public byte Efp13;
        public byte Efp14;
        public byte Efp15;
        public byte Efp16;
        public byte HitDirID1;
        public byte HitDirID2;
        public byte HitDirID3;
        public byte HitDirID4;
        public byte HitDirID5;
        public byte HitDirID6;
        public byte HitDirID7;
        public byte HitDirID8;
        public byte HitDirID9;
        public byte HitDirID10;
        public byte HitDirID11;
        public byte HitDirID12;
        public byte HitDirID13;
        public byte HitDirID14;
        public byte HitDirID15;
        public byte HitDirID16;
        public byte DmgRt1;
        public byte DmgRt2;
        public byte DmgRt3;
        public byte DmgRt4;
        public byte DmgRt5;
        public byte DmgRt6;
        public byte DmgRt7;
        public byte DmgRt8;
        public byte DmgRt9;
        public byte DmgRt10;
        public byte DmgRt11;
        public byte DmgRt12;
        public byte DmgRt13;
        public byte DmgRt14;
        public byte DmgRt15;
        public byte DmgRt16;
        public byte ReAct1;
        public byte ReAct2;
        public byte ReAct3;
        public byte ReAct4;
        public byte ReAct5;
        public byte ReAct6;
        public byte ReAct7;
        public byte ReAct8;
        public byte ReAct9;
        public byte ReAct10;
        public byte ReAct11;
        public byte ReAct12;
        public byte ReAct13;
        public byte ReAct14;
        public byte ReAct15;
        public byte ReAct16;
        public byte MoveCancelFrm;
        public ushort DmgMgn1;
        public ushort DmgMgn2;
        public ushort DmgMgn3;
        public ushort DmgMgn4;
        public ushort DmgMgn5;
        public ushort DmgMgn6;
        public ushort Recast1;
        public ushort Recast2;
        public ushort Recast3;
        public ushort Recast4;
        public ushort Recast5;
        public ushort Recast6;
        public byte AtrNum;
        public ushort Enhance1;
        public ushort Enhance2;
        public ushort Enhance3;
        public ushort Enhance4;
        public ushort Enhance5;
        public ushort Enhance6;
        public byte ReleaseLv1;
        public byte ReleaseLv2;
        public byte ReleaseLv3;
        public byte ReleaseLv4;
        public byte ReleaseLv5;
        public ushort NeedWP2;
        public ushort NeedWP3;
        public ushort NeedWP4;
        public ushort NeedWP5;
        public ushort HitEff;
        public byte VoiceNum;
        public ushort VoiceNum2;
        public ushort VoiceDelay;
        public ushort UI;
        public byte Priority;
        public byte GravOffNum;
        public ushort GravOffF;
        public byte GravOnNum;
        public ushort GravOnF;
        public bool Normal;
        public bool Pierce;
        public bool NoRepelled;
        public bool NoMove;
        public bool SArmor1;
        public bool SArmor2;
        public bool NoColli;
        public BTL_Buff _ArtsBuff;
        public BTL_Buff _ArtsDeBuff;
        public ArtType _ArtsType;
        public BTL_Bullet _BulletID;
        public Message _Caption;
        public CHR_Dr _Driver;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public BTL_Enhance _Enhance3;
        public BTL_Enhance _Enhance4;
        public BTL_Enhance _Enhance5;
        public BTL_Enhance _Enhance6;
        public BTL_HitDirection _HitDirID1;
        public BTL_HitDirection _HitDirID10;
        public BTL_HitDirection _HitDirID11;
        public BTL_HitDirection _HitDirID12;
        public BTL_HitDirection _HitDirID13;
        public BTL_HitDirection _HitDirID14;
        public BTL_HitDirection _HitDirID15;
        public BTL_HitDirection _HitDirID16;
        public BTL_HitDirection _HitDirID2;
        public BTL_HitDirection _HitDirID3;
        public BTL_HitDirection _HitDirID4;
        public BTL_HitDirection _HitDirID5;
        public BTL_HitDirection _HitDirID6;
        public BTL_HitDirection _HitDirID7;
        public BTL_HitDirection _HitDirID8;
        public BTL_HitDirection _HitDirID9;
        public BTL_HitEffect _HitEff;
        public Message _Name;
        public BTL_Arts_Dr _NextArts;
        public ArtRangeType _RangeType;
        public ReactType _ReAct1;
        public ReactType _ReAct10;
        public ReactType _ReAct11;
        public ReactType _ReAct12;
        public ReactType _ReAct13;
        public ReactType _ReAct14;
        public ReactType _ReAct15;
        public ReactType _ReAct16;
        public ReactType _ReAct2;
        public ReactType _ReAct3;
        public ReactType _ReAct4;
        public ReactType _ReAct5;
        public ReactType _ReAct6;
        public ReactType _ReAct7;
        public ReactType _ReAct8;
        public ReactType _ReAct9;
        public MNU_IconList _UI;
        public ITM_PcWpnType _WpnType;
    }

    [BdatType]
    [Serializable]
    public class BTL_Arts_En
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte WpnNo;
        public byte ActNo;
        public byte ArtsType;
        public byte ArtsBuff;
        public byte ArtsDeBuff;
        public uint Flag;
        public byte MoveRev;
        public ushort NextArts;
        public byte Target;
        public byte RotAssist;
        public ushort Distance;
        public byte Multi;
        public byte RangeType;
        public ushort Radius;
        public ushort Length;
        public byte Atr;
        public sbyte HitRevise;
        public sbyte CriRevise;
        public ushort BulletID;
        public ushort BulletEffID;
        public byte EfpType;
        public byte BulletNum;
        public byte LoopNum;
        public byte BulletAngle;
        public byte HitFrm1;
        public byte HitFrm2;
        public byte HitFrm3;
        public byte HitFrm4;
        public byte HitFrm5;
        public byte HitFrm6;
        public byte HitFrm7;
        public byte HitFrm8;
        public byte HitFrm9;
        public byte HitFrm10;
        public byte HitFrm11;
        public byte HitFrm12;
        public byte HitFrm13;
        public byte HitFrm14;
        public byte HitFrm15;
        public byte HitFrm16;
        public byte Efp1;
        public byte Efp2;
        public byte Efp3;
        public byte Efp4;
        public byte Efp5;
        public byte Efp6;
        public byte Efp7;
        public byte Efp8;
        public byte Efp9;
        public byte Efp10;
        public byte Efp11;
        public byte Efp12;
        public byte Efp13;
        public byte Efp14;
        public byte Efp15;
        public byte Efp16;
        public byte DmgRt1;
        public byte DmgRt2;
        public byte DmgRt3;
        public byte DmgRt4;
        public byte DmgRt5;
        public byte DmgRt6;
        public byte DmgRt7;
        public byte DmgRt8;
        public byte DmgRt9;
        public byte DmgRt10;
        public byte DmgRt11;
        public byte DmgRt12;
        public byte DmgRt13;
        public byte DmgRt14;
        public byte DmgRt15;
        public byte DmgRt16;
        public byte ReAct1;
        public byte ReAct2;
        public byte ReAct3;
        public byte ReAct4;
        public byte ReAct5;
        public byte ReAct6;
        public byte ReAct7;
        public byte ReAct8;
        public byte ReAct9;
        public byte ReAct10;
        public byte ReAct11;
        public byte ReAct12;
        public byte ReAct13;
        public byte ReAct14;
        public byte ReAct15;
        public byte ReAct16;
        public ushort DmgMgn;
        public ushort Recast;
        public sbyte StartRecast;
        public byte AtrNum;
        public ushort Enhance;
        public ushort HitEff;
        public ushort Summon;
        public byte CircleID;
        public byte VoiceNum;
        public ushort VoiceDelay;
        public ushort SeSlot;
        public byte SeNum;
        public bool Normal;
        public bool DoLast;
        public bool Pierce;
        public bool Fcombo;
        public bool NoRepelled;
        public bool NoTarget;
        public bool NoMove;
        public bool SArmor1;
        public bool SArmor2;
        public bool AtrSe;
        public bool NoColli;
        public bool ColliDown;
        public bool Shoot;
        public bool BackAtk;
        public bool MyBom;
        public bool CallEnemy;
        public bool Vision;
        public BTL_Buff _ArtsBuff;
        public BTL_Buff _ArtsDeBuff;
        public ArtType _ArtsType;
        public MNU_Name _Atr;
        public BTL_Bullet _BulletID;
        public BTL_Enhance _Enhance;
        public Message _Name;
        public ReactType _ReAct1;
        public ReactType _ReAct10;
        public ReactType _ReAct11;
        public ReactType _ReAct12;
        public ReactType _ReAct13;
        public ReactType _ReAct14;
        public ReactType _ReAct15;
        public ReactType _ReAct16;
        public ReactType _ReAct2;
        public ReactType _ReAct3;
        public ReactType _ReAct4;
        public ReactType _ReAct5;
        public ReactType _ReAct6;
        public ReactType _ReAct7;
        public ReactType _ReAct8;
        public ReactType _ReAct9;
        public BTL_Summon _Summon;
    }

    [BdatType]
    [Serializable]
    public class BTL_ArtsDirection
    {
        public int Id;
        public byte MotionNo1;
        public ushort Startf1;
        public ushort Keepf1;
        public ushort SlowRate1;
        public byte MotionNo2;
        public ushort Startf2;
        public ushort Keepf2;
        public ushort SlowRate2;
        public byte MotionNo3;
        public ushort Startf3;
        public ushort Keepf3;
        public ushort SlowRate3;
        public byte MotionNo4;
        public ushort Startf4;
        public ushort Keepf4;
        public ushort SlowRate4;
    }

    [BdatType]
    [Serializable]
    public class BTL_Aura
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Enhance1;
        public ushort Enhance2;
        public ushort Enhance3;
        public byte ChangeAtr;
        public MNU_Name _ChangeAtr;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public BTL_Enhance _Enhance3;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_BallBreak
    {
        public int Id;
        public ushort DamageRate;
        public ushort FBGauge;
        public ushort FBBonus;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bl_KizunaBase
    {
        public int Id;
        public ushort KizunaDef;
        public sbyte KizunaUpRev;
        public sbyte KizunaDownRev;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bl_KizunaLink
    {
        public int Id;
        public ushort LinkNum;
        public ushort DeadNum;
        public ushort AppStNum;
        public ushort AppEndNum;
        public byte SpActType;
        public byte SpActNum;
        public ushort SpActf;
        public byte StandDir;
        public byte AppCond;
        public ushort AppCondNum;
        public byte ReJudgef;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bl_KizunaLinkSet
    {
        public int Id;
        public ushort KizunaLink1;
        public ushort KizunaLink2;
        public ushort LinkChType;
        public ushort LinkChNum;
        public byte VoiceID;
        public BTL_Bl_KizunaLink _KizunaLink1;
        public BTL_Bl_KizunaLink _KizunaLink2;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bl_KizunaUpDown
    {
        public int Id;
        public short ParamE;
        public short ParamD;
        public short ParamC;
        public short ParamB;
        public short ParamA;
        public short ParamS;
        public short ParamS1;
        public short ParamS2;
        public short ParamS3;
        public short ParamS4;
        public short ParamS5;
        public short ParamS6;
        public short ParamS7;
        public short ParamS8;
        public short ParamS9;
        public short ParamSS;
        public byte Target;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bl_Personality
    {
        public int Id;
        public byte Flag;
        public byte KizunaBase;
        public byte VoiceID;
        public byte BLC_A;
        public ushort BLC_PARAM_A;
        public byte BLC_B;
        public ushort BLC_PARAM_B;
        public ushort BLC_C;
        public ushort BLC_D;
        public byte Custom01;
        public byte CustomParam01;
        public byte Custom02;
        public byte CustomParam02;
        public byte Custom03;
        public byte CustomParam03;
        public bool common;
        public BTL_Bl_KizunaBase _KizunaBase;
    }

    [BdatType]
    [Serializable]
    public class BTL_BtnChallenge
    {
        public int Id;
        public ushort Speed;
        public ushort GSuccess;
        public ushort Success;
        public byte RecastRate;
    }

    [BdatType]
    [Serializable]
    public class BTL_Buff
    {
        public int Id;
        public byte Name;
        public string DebugName;
        public byte Caption;
        public ushort BaseNum;
        public ushort BaseTime;
        public ushort BaseRecast;
        public byte BaseProb;
        public ushort Interval;
        public string Effect;
        public byte VoiceNum;
        public byte Flag;
        public ushort Icon;
        public bool Buff;
        public bool SE;
        public Message _Caption;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_Bullet
    {
        public int Id;
        public byte MoveType;
        public ushort SpdFirst;
        public ushort SpdLast;
        public ushort AclStart;
        public ushort AclEnd;
        public byte ExpNum;
        public byte ExpDelay;
        public byte BltMaxAng;
        public byte Flag;
        public byte ReboundDir;
        public byte UpDist;
        public byte AddAtkNum;
        public byte AddAtkDelay;
        public bool Ball;
        public bool Pierce;
    }

    [BdatType]
    [Serializable]
    public class BTL_BulletEffect
    {
        public int Id;
        public byte Flag;
        public byte EffPack;
        public byte WpnType;
        public string Muzzle;
        public string Bullet;
        public string Impact;
        public ushort MuzzleScale;
        public ushort BulletScale;
        public ushort ImpactScale;
        public ushort MuzSePack;
        public byte MuzSeSlot;
        public ushort ImpSePack;
        public byte ImpSeSlot;
        public bool Atr;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChainAttackCam
    {
        public int Id;
        public byte CamType;
        public byte EnSize;
        public byte SpeedType;
        public ushort SpeedNum;
        public byte MoveType;
        public int S_PosX;
        public int S_PosY;
        public int S_PosZ;
        public byte S_LookPosType;
        public int S_LookX;
        public int S_LookY;
        public int S_LookZ;
        public int E_PosX;
        public int E_PosY;
        public int E_PosZ;
        public byte E_LookPosType;
        public int E_LookX;
        public int E_LookY;
        public int E_LookZ;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChainAttackFull
    {
        public int Id;
        public string Wpn01;
        public string Wpn02;
        public string Wpn03;
        public string Wpn04;
        public string Wpn05;
        public string Wpn06;
        public string Wpn07;
        public string Wpn08;
        public string Wpn09;
        public string Wpn10;
        public string Wpn11;
        public string Wpn12;
        public string Wpn13;
        public string Wpn14;
        public string Wpn15;
        public string Wpn16;
        public string Wpn17;
        public string Wpn18;
        public string Wpn19;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChainAttackStart
    {
        public int Id;
        public string Wpn01;
        public string Wpn01b;
        public string Wpn02;
        public string Wpn02b;
        public string Wpn03;
        public string Wpn03b;
        public string Wpn04;
        public string Wpn04b;
        public string Wpn05;
        public string Wpn05b;
        public string Wpn06;
        public string Wpn06b;
        public string Wpn07;
        public string Wpn07b;
        public string Wpn08;
        public string Wpn08b;
        public string Wpn09;
        public string Wpn09b;
        public string Wpn10;
        public string Wpn10b;
        public string Wpn11;
        public string Wpn11b;
        public string Wpn12;
        public string Wpn12b;
        public string Wpn13;
        public string Wpn13b;
        public string Wpn14;
        public string Wpn14b;
        public string Wpn15;
        public string Wpn15b;
        public string Wpn16;
        public string Wpn16b;
        public string Wpn17;
        public string Wpn17b;
        public string Wpn18;
        public string Wpn18b;
        public string Wpn19;
        public string Wpn19b;
        public string Wpn90;
        public string Wpn91;
        public string Wpn92;
        public string Wpn93;
        public string Wpn94;
        public string Wpn95;
        public string Wpn96;
        public string Wpn97;
        public string Wpn98;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChBtl
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte ListNum;
        public byte Difficult;
        public ushort Caption;
        public ushort MapJump;
        public byte Weather;
        public byte Type;
        public ushort NeedDefeat;
        public byte MaxLevel;
        public byte MaxWpnRank;
        public ushort WpnRevTable;
        public ushort TimeLimit;
        public byte JoinNumber;
        public byte Driver1;
        public byte Driver2;
        public byte Driver3;
        public ushort Condition;
        public ushort ConditionCap;
        public byte Flag;
        public ushort ClearReward;
        public ushort TresureSet1;
        public ushort TresureSet2;
        public ushort TresureSet3;
        public ushort TresureNeed1;
        public ushort TresureNeed2;
        public ushort TresureNeed3;
        public ushort TresureResource1;
        public ushort TresureResource2;
        public ushort TresureResource3;
        public uint Voice1;
        public uint Voice2;
        public uint Voice3;
        public uint Voice4;
        public bool Hide;
        public Message _Caption;
        public object _ClearReward;
        public FLD_ConditionList _Condition;
        public CHR_Dr _Driver1;
        public CHR_Dr _Driver2;
        public CHR_Dr _Driver3;
        public SYS_MapJumpEvList _MapJump;
        public Message _Name;
        public RSC_TboxList _TresureResource1;
        public RSC_TboxList _TresureResource2;
        public RSC_TboxList _TresureResource3;
        public BTL_ChBtlRewardSet _TresureSet1;
        public BTL_ChBtlRewardSet _TresureSet2;
        public BTL_ChBtlRewardSet _TresureSet3;
        public BTL_ChBtlWpnRev _WpnRevTable;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChBtlRewardItem
    {
        public int Id;
        public ushort ItemID;
        public ushort ItemValue;
        public ushort Param1;
        public object _ItemID;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChBtlRewardSet
    {
        public int Id;
        public uint GoldMin;
        public uint GoldMax;
        public byte GoldPopMin;
        public byte GoldPopMax;
        public byte ItemNumMin;
        public byte ItemNumMax;
        public ushort ItemValueMin;
        public ushort ItemValueMax;
        public ushort ItemValueMin2;
        public ushort ItemValueMax2;
        public ushort AppointItem;
        public byte UpCategory1;
        public byte UpCategory2;
        public byte DownCategory1;
        public byte DownCategory2;
        public ushort UpItemID1;
        public ushort UpItemID2;
        public ushort UpItemID3;
        public ushort UpItemID4;
        public ushort DownItemID1;
        public ushort DownItemID2;
        public ushort DownItemID3;
        public ushort DownItemID4;
        public object _UpItemID1;
        public object _UpItemID2;
        public object _UpItemID3;
        public object _UpItemID4;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChBtlScore
    {
        public int Id;
        public ushort Score;
        public ushort Cube;
        public byte CubeDiv;
    }

    [BdatType]
    [Serializable]
    public class BTL_ChBtlWpnRev
    {
        public int Id;
        public ushort WpnDmg1;
        public ushort WpnDmg2;
        public ushort WpnDmg3;
        public ushort WpnDmg4;
        public ushort WpnDmg5;
        public ushort WpnDmg6;
        public ushort WpnDmg7;
        public ushort WpnDmg8;
        public ushort WpnDmg9;
        public ushort WpnDmg10;
        public ushort WpnDmg11;
        public ushort WpnDmg12;
        public ushort WpnDmg13;
        public ushort WpnDmg14;
        public ushort WpnDmg15;
        public ushort WpnDmg16;
        public ushort WpnDmg17;
        public ushort WpnDmg18;
        public ushort WpnDmg19;
        public ushort WpnDmg20;
        public ushort WpnDmg21;
        public ushort WpnDmg22;
        public ushort WpnDmg23;
        public ushort WpnDmg24;
        public ushort WpnDmg25;
        public ushort WpnDmg26;
    }

    [BdatType]
    [Serializable]
    public class BTL_Circle
    {
        public int Id;
        public byte Point;
        public byte Radius;
        public ushort Damage;
        public byte Target;
        public byte Interval;
        public ushort Lifespan;
        public string Effect;
    }

    [BdatType]
    [Serializable]
    public class BTL_Class
    {
        public int Id;
        public ushort Name;
        public byte Role1;
        public byte Role2;
        public byte Role3;
        public byte DamageDown;
        public byte DamageUP;
        public byte HealUP;
        public sbyte AutoHate;
        public sbyte ArtsHate;
        public byte Flag;
        public byte DamageDownNum;
        public byte DamageUPNum;
        public byte HealUPNum;
        public sbyte AutoHateNum;
        public sbyte ArtsHateNum;
        public bool Pot;
        public bool HealMode;
        public Message _Name;
        public Message _Role1;
        public Message _Role2;
        public Message _Role3;
    }

    [BdatType]
    [Serializable]
    public class BTL_CmnBl_Armor
    {
        public int Id;
        public byte WpnType;
        public byte PArmorCon;
        public byte PArmorRand;
        public byte EArmorCon;
        public byte EArmorRand;
        public ITM_PcWpnType _WpnType;
    }

    [BdatType]
    [Serializable]
    public class BTL_CmnBl_Capacity
    {
        public int Id;
        public byte ArtsLv1Prob;
        public byte ArtsLv2Prob;
        public byte ArtsLv3Prob;
        public byte ArtsLv4Prob;
        public byte ArtsLv5Prob;
        public byte ArtsRevCon;
        public byte ArtsRevRand;
        public byte SpArtsRevCon;
        public byte SpArtsRevRand;
        public byte SkillNum1Prob;
        public byte SkillNum2Prob;
        public byte SkillNum3Prob;
        public byte SkillLv1Prob;
        public byte SkillLv2Prob;
        public byte SkillLv3Prob;
        public byte SkillLv4Prob;
        public byte SkillLv5Prob;
        public byte OrbNum0Prob;
        public byte OrbNum1Prob;
        public byte OrbNum2Prob;
        public byte OrbNum3Prob;
        public byte NartsNum1Prob;
        public byte NartsNum2Prob;
        public byte NartsNum3Prob;
        public byte NartsRevCon;
        public byte NartsRevRand;
        public byte StatusRevCon;
        public byte StatusRevRand;
        public byte ArtsNum1Prob;
        public byte ArtsNum2Prob;
        public byte ArtsNum3Prob;
        public byte[] _ArtsLvProb;
        public byte[] _SkillNumProb;
        public byte[] _SkillLvProb;
        public byte[] _OrbNumProb;
        public byte[] _NartsNumProb;
        public byte[] _ArtsNumProb;
    }

    [BdatType]
    [Serializable]
    public class BTL_CmnBl_NewBlArts
    {
        public int Id;
        public byte WpnType;
        public byte NBA_01;
        public byte NBA_02;
        public byte NBA_03;
        public byte NBA_04;
        public byte NBA_05;
        public byte NBA_06;
        public byte NBA_07;
        public byte NBA_08;
        public ITM_PcWpnType _WpnType;
        public byte[] _NBA;
    }

    [BdatType]
    [Serializable]
    public class BTL_CmnBl_Power
    {
        public int Id;
        public byte MinLv;
        public byte MaxLv;
        public ushort Pow01;
        public ushort Pow02;
        public ushort Pow03;
        public ushort Pow04;
        public ushort Pow05;
        public ushort Pow06;
        public ushort Pow07;
        public ushort Pow08;
        public ushort Pow09;
        public ushort Pow10;
        public ushort[] _Pow;
    }

    [BdatType]
    [Serializable]
    public class BTL_CmnBl_StatusType
    {
        public int Id;
        public byte WpnType;
        public byte Status01;
        public byte Status02;
        public byte Status03;
        public byte Status04;
        public byte Status05;
        public byte Status06;
        public ITM_PcWpnType _WpnType;
        public byte[] _Status;
    }

    [BdatType]
    [Serializable]
    public class BTL_Condition
    {
        public int Id;
        public ushort FLD_CondID;
        public ushort Param01;
        public FLD_ConditionList _FLD_CondID;
    }

    [BdatType]
    [Serializable]
    public class BTL_DifSetting
    {
        public int Id;
        public string DebugName;
        public byte ParamMin;
        public ushort ParamMax;
        public byte Interval;
        public ushort Normal;
        public ushort Easy;
        public ushort Hard;
        public ushort Ult;
    }

    [BdatType]
    [Serializable]
    public class BTL_Dr_IdeaUpType
    {
        public int Id;
        public byte IdeaBlue;
        public byte IdeaRed;
        public byte IdeaWhite;
        public byte IdeaBlack;
    }

    [BdatType]
    [Serializable]
    public class BTL_Drop_Heal
    {
        public int Id;
        public byte RatioDeath;
        public byte PotNumMin1;
        public byte PotNumMax1;
        public byte PotLvMin1;
        public byte PotLvMax1;
        public byte RatioStumbled;
        public byte PotNumMin2;
        public byte PotNumMax2;
        public byte PotLvMin2;
        public byte PotLvMax2;
        public byte RatioLaunch;
        public byte PotNumMin3;
        public byte PotNumMax3;
        public byte PotLvMin3;
        public byte PotLvMax3;
        public byte RatioStrike;
        public byte PotNumMin4;
        public byte PotNumMax4;
        public byte PotLvMin4;
        public byte PotLvMax4;
    }

    [BdatType]
    [Serializable]
    public class BTL_ElementalCombo
    {
        public int Id;
        public byte Name;
        public string DebugName;
        public byte Caption;
        public byte Atr;
        public byte ComboStage;
        public byte PreCombo;
        public byte Range;
        public ushort BaseTime;
        public byte Reaction;
        public byte ReactionLv;
        public ushort DD;
        public ushort Dot;
        public ushort Interval;
        public float DDEn;
        public float DotEn;
        public ushort DDf1;
        public ushort DDf2;
        public ushort DDf3;
        public ushort DDf4;
        public ushort DDf5;
        public ushort DDf6;
        public ushort DDf7;
        public ushort DDf8;
        public ushort DDf9;
        public ushort DDf10;
        public ushort DDf11;
        public ushort DDf12;
        public ushort DDf13;
        public ushort DDf14;
        public ushort DDf15;
        public ushort DDf16;
        public byte DmgRt1;
        public byte DmgRt2;
        public byte DmgRt3;
        public byte DmgRt4;
        public byte DmgRt5;
        public byte DmgRt6;
        public byte DmgRt7;
        public byte DmgRt8;
        public byte DmgRt9;
        public byte DmgRt10;
        public byte DmgRt11;
        public byte DmgRt12;
        public byte DmgRt13;
        public byte DmgRt14;
        public byte DmgRt15;
        public byte DmgRt16;
        public byte ReAct1;
        public byte ReAct2;
        public byte ReAct3;
        public byte ReAct4;
        public byte ReAct5;
        public byte ReAct6;
        public byte ReAct7;
        public byte ReAct8;
        public byte ReAct9;
        public byte ReAct10;
        public byte ReAct11;
        public byte ReAct12;
        public byte ReAct13;
        public byte ReAct14;
        public byte ReAct15;
        public byte ReAct16;
        public string Effect;
        public byte SE;
        public byte DamageRate;
        public byte FusionName1;
        public byte FusionName2;
        public byte FusionName3;
        public byte FusionName4;
        public ushort Icon;
        public byte NeedAtrNum;
        public MNU_Name _Atr;
        public Message _Name;
        public BTL_ElementalCombo _PreCombo;
        public ReactType _ReAct1;
        public ReactType _ReAct10;
        public ReactType _ReAct11;
        public ReactType _ReAct12;
        public ReactType _ReAct13;
        public ReactType _ReAct14;
        public ReactType _ReAct15;
        public ReactType _ReAct16;
        public ReactType _ReAct2;
        public ReactType _ReAct3;
        public ReactType _ReAct4;
        public ReactType _ReAct5;
        public ReactType _ReAct6;
        public ReactType _ReAct7;
        public ReactType _ReAct8;
        public ReactType _ReAct9;
        public BTL_Reaction _Reaction;
    }

    [BdatType]
    [Serializable]
    public class BTL_ElementalEffect
    {
        public int Id;
        public byte Name;
        public string DebugName;
        public byte Caption;
        public byte Atr1;
        public string Effect;
        public byte SE;
        public MNU_Name _Atr1;
        public Message _Caption;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnAwake
    {
        public int Id;
        public ushort Name;
        public byte NormalProb;
        public byte AngryProb;
        public byte AttackBonus;
        public byte RecastBonus;
        public ushort ReduceElmCombo;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnBook
    {
        public int Id;
        public ushort BaseEnemyID;
        public uint BOOK_POP_TIME;
        public byte BOOK_popWeather;
        public CHR_EnArrange _BaseEnemyID;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnDropItem
    {
        public int Id;
        public byte LimitNum;
        public byte SelectType;
        public ushort ItemID1;
        public ushort DropProb1;
        public byte NoGetByEnh1;
        public byte FirstNamed1;
        public ushort ItemID2;
        public ushort DropProb2;
        public byte NoGetByEnh2;
        public byte FirstNamed2;
        public ushort ItemID3;
        public ushort DropProb3;
        public byte NoGetByEnh3;
        public byte FirstNamed3;
        public ushort ItemID4;
        public ushort DropProb4;
        public byte NoGetByEnh4;
        public byte FirstNamed4;
        public ushort ItemID5;
        public ushort DropProb5;
        public byte NoGetByEnh5;
        public byte FirstNamed5;
        public ushort ItemID6;
        public ushort DropProb6;
        public byte NoGetByEnh6;
        public byte FirstNamed6;
        public ushort ItemID7;
        public ushort DropProb7;
        public byte NoGetByEnh7;
        public byte FirstNamed7;
        public ushort ItemID8;
        public ushort DropProb8;
        public byte NoGetByEnh8;
        public byte FirstNamed8;
        public object _ItemID1;
        public object _ItemID2;
        public object _ItemID3;
        public object _ItemID4;
        public object _ItemID5;
        public object _ItemID6;
        public object _ItemID7;
        public object _ItemID8;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnDropQuest
    {
        public int Id;
        public ushort ItemID1;
        public ushort DropProb1;
        public ushort GetConditon1;
        public ushort ItemID2;
        public ushort DropProb2;
        public ushort GetConditon2;
        public ushort ItemID3;
        public ushort DropProb3;
        public ushort GetConditon3;
        public ushort ItemID4;
        public ushort DropProb4;
        public ushort GetConditon4;
        public FLD_ConditionList _GetConditon1;
        public FLD_ConditionList _GetConditon2;
        public FLD_ConditionList _GetConditon3;
        public FLD_ConditionList _GetConditon4;
        public object _ItemID1;
        public object _ItemID2;
        public object _ItemID3;
        public object _ItemID4;
    }

    [BdatType]
    [Serializable]
    public class BTL_Enhance
    {
        public int Id;
        public ushort EnhanceEffect;
        public float Param1;
        public float Param2;
        public ushort Caption;
        public BTL_EnhanceEff _EnhanceEffect;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnhanceEff
    {
        public int Id;
        public byte Category;
        public byte Icon;
        public byte Flag;
        public ushort Param;
        public ushort Name;
        public byte Direct;
        public byte SortCat;
        public bool Condition;
        public bool UI;
        public bool PG;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_EnhanceMax
    {
        public int Id;
        public ushort Max;
    }

    [BdatType]
    [Serializable]
    public class BTL_FightCombo
    {
        public int Id;
        public byte Name;
        public string DebugName;
        public byte ComboStage;
        public byte PreCombo;
        public ushort BaseNum;
        public ushort BaseTime;
        public byte Reaction;
        public byte ReactionLv;
        public byte DamageRate;
        public ushort Icon;
        public byte Caption;
        public Message _Name;
        public BTL_Reaction _Reaction;
    }

    [BdatType]
    [Serializable]
    public class BTL_Grow
    {
        public int Id;
        public uint LevelExp;
        public uint LevelExp2;
        public ushort EnemyExp;
        public ushort EnemyWP;
        public ushort EnemySP;
        public uint EnemyGold;
        public byte GoldDivide;
    }

    [BdatType]
    [Serializable]
    public class BTL_HanaBase
    {
        public int Id;
        public byte NCondNum;
        public byte ECondNum;
        public byte NArtsNum;
        public ushort Circuit1Num;
        public ushort Circuit2Num;
        public ushort Circuit3Num;
        public ushort Circuit4Num;
        public ushort Circuit5Num;
        public ushort Circuit6Num;
        public string UI;
    }

    [BdatType]
    [Serializable]
    public class BTL_HanaChipset
    {
        public int Id;
        public ushort RoleParts;
        public ushort AtrParts;
        public ushort NArtsParts1;
        public ushort NArtsParts2;
        public ushort NArtsParts3;
        public ushort NCondParts1;
        public ushort NCondParts2;
        public ushort NCondParts3;
        public string UI;
        public object _AtrParts;
        public object _NArtsParts1;
        public object _NArtsParts2;
        public object _NArtsParts3;
        public object _RoleParts;
    }

    [BdatType]
    [Serializable]
    public class BTL_HanaPower
    {
        public int Id;
        public ushort PowerNum1;
        public ushort PowerNum2;
        public ushort PowerNum3;
        public uint EtherNum1;
        public uint EtherNum2;
        public uint EtherNum3;
    }

    [BdatType]
    [Serializable]
    public class BTL_HealPot
    {
        public int Id;
        public byte DropRsc;
        public byte HpRatio;
        public string Category;
    }

    [BdatType]
    [Serializable]
    public class BTL_HitCameraParam
    {
        public int Id;
        public byte type;
        public byte sub_type;
        public byte param01;
        public byte param02;
        public byte param03;
        public byte param04;
    }

    [BdatType]
    [Serializable]
    public class BTL_HitDirection
    {
        public int Id;
        public byte DirectType;
        public byte DirectFrm;
        public byte CamType;
        public byte CamAngle;
    }

    [BdatType]
    [Serializable]
    public class BTL_HitEffect
    {
        public int Id;
        public short x0;
        public short y0;
        public short z0;
        public short x1;
        public short y1;
        public short z1;
        public short x2;
        public short y2;
        public short z2;
        public short x3;
        public short y3;
        public short z3;
        public short x4;
        public short y4;
        public short z4;
        public short x5;
        public short y5;
        public short z5;
        public short x6;
        public short y6;
        public short z6;
        public short x7;
        public short y7;
        public short z7;
        public short x8;
        public short y8;
        public short z8;
        public short x9;
        public short y9;
        public short z9;
        public short x10;
        public short y10;
        public short z10;
        public short x11;
        public short y11;
        public short z11;
        public short x12;
        public short y12;
        public short z12;
        public short x13;
        public short y13;
        public short z13;
        public short x14;
        public short y14;
        public short z14;
        public short x15;
        public short y15;
        public short z15;
        public readonly byte[] type = new byte[16];
        public readonly string[] name = new string[16];
    }

    [BdatType]
    [Serializable]
    public class BTL_HitEffectRim
    {
        public int Id;
        public string RimName;
    }

    [BdatType]
    [Serializable]
    public class BTL_IrGroupRev
    {
        public int Id;
        public byte GroupRev1;
        public byte GroupRev2;
        public byte GroupRev3;
        public BTL_Class _GroupRev1;
        public BTL_Class _GroupRev2;
        public BTL_Class _GroupRev3;
    }

    [BdatType]
    [Serializable]
    public class BTL_Kizuna
    {
        public int Id;
        public ushort KizunaMin;
        public ushort KizunaMax;
        public ushort BArtsProbRev;
        public ushort BArtsDamageRev;
        public ushort CriRateRev;
        public ushort MoveSpeedRev;
        public ushort DArtsRecastRev;
    }

    [BdatType]
    [Serializable]
    public class BTL_Lv_Rev
    {
        public int Id;
        public ushort ExpRevHigh;
        public ushort ExpRevLow;
        public ushort DamageRevHigh;
        public ushort DamageRevLow;
        public ushort HitRevLow;
        public ushort ReactRevHigh;
    }

    [BdatType]
    [Serializable]
    public class BTL_MapRev
    {
        public int Id;
        public ushort Flag;
        public ushort KizunaCap;
        public byte ArtSp;
        public byte PC01Atk;
        public byte PC01Def;
        public byte PC02Atk;
        public byte PC02Def;
        public byte PC03Atk;
        public byte PC03Def;
        public byte PC04Atk;
        public byte PC04Def;
        public byte PC05Atk;
        public byte PC05Def;
        public byte PC06Atk;
        public byte PC06Def;
        public byte PC07Atk;
        public byte PC07Def;
        public byte PC08Atk;
        public byte PC08Def;
        public byte PC09Atk;
        public byte PC09Def;
        public bool Rex;
        public bool Nia;
        public bool Sieg;
        public bool Tora;
        public bool Vandamme;
        public bool Melef;
        public bool Sin;
        public bool Metsu;
        public bool Sin2;
        public bool nba;
    }

    [BdatType]
    [Serializable]
    public class BTL_NamedList
    {
        public int Id;
        public ushort EnemyID;
        public CHR_EnArrange _EnemyID;
    }

    [BdatType]
    [Serializable]
    public class BTL_PartyGauge
    {
        public int Id;
        public short Param;
    }

    [BdatType]
    [Serializable]
    public class BTL_Points
    {
        public int Id;
        public ushort Point;
    }

    [BdatType]
    [Serializable]
    public class BTL_PouchBuff
    {
        public int Id;
        public ushort Max;
        public byte Name;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_PouchBuffSet
    {
        public int Id;
        public byte PBuff1;
        public float PBuffParam1;
        public byte PBuff2;
        public float PBuffParam2;
        public byte PBuff3;
        public float PBuffParam3;
    }

    [BdatType]
    [Serializable]
    public class BTL_Reaction
    {
        public int Id;
        public byte Name;
        public string DebugName;
        public byte Priority;
        public ushort PowLv1_S;
        public ushort PowLv1_M;
        public ushort PowLv1_L;
        public ushort PowLv1_LL;
        public ushort PowLv2_S;
        public ushort PowLv2_M;
        public ushort PowLv2_L;
        public ushort PowLv2_LL;
        public ushort PowLv3_S;
        public ushort PowLv3_M;
        public ushort PowLv3_L;
        public ushort PowLv3_LL;
        public ushort PowLv4_S;
        public ushort PowLv4_M;
        public ushort PowLv4_L;
        public ushort PowLv4_LL;
        public ushort PowLv5_S;
        public ushort PowLv5_M;
        public ushort PowLv5_L;
        public ushort PowLv5_LL;
        public ushort PowLv6_S;
        public ushort PowLv6_M;
        public ushort PowLv6_L;
        public ushort PowLv6_LL;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_SE
    {
        public int Id;
        public string PackName;
        public string tag;
        public byte delivered;
    }

    [BdatType]
    [Serializable]
    public class BTL_Skill_Bl
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Enhance1;
        public ushort Enhance2;
        public ushort Enhance3;
        public ushort Enhance4;
        public ushort Enhance5;
        public byte Flag;
        public byte Tank;
        public byte Attacker;
        public byte Healer;
        public ushort UI;
        public byte Role;
        public byte MaxLv;
        public ushort Caption;
        public bool common;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public BTL_Enhance _Enhance3;
        public BTL_Enhance _Enhance4;
        public BTL_Enhance _Enhance5;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_Skill_Dr
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Enhance;
        public ushort UI;
        public BTL_Enhance _Enhance;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_Skill_Dr_Table
    {
        public int Id;
        public ushort SkillID;
        public ushort NeedSp;
        public byte Round;
        public byte ColumnNum;
        public byte RowNum;
        public BTL_Skill_Dr _SkillID;
    }

    [BdatType]
    [Serializable]
    public class BTL_SpArtsRecast
    {
        public int Id;
        public byte Param;
        public byte Param2;
    }

    [BdatType]
    [Serializable]
    public class BTL_Summon
    {
        public int Id;
        public byte SummonType;
        public ushort LimitRad;
        public byte Num;
        public byte Rate;
        public readonly ushort[] EnemyID = new ushort[3];
        public readonly ushort[] Unique = new ushort[3];
        public readonly short[] PosA = new short[3];
        public readonly short[] PosB = new short[3];
        public readonly short[] PosC = new short[3];
        public CHR_EnArrange _EnemyID;
    }

    [BdatType]
    [Serializable]
    public class BTL_SystemBalance
    {
        public int Id;
        public short Param;
        public byte Decimal;
    }

    [BdatType]
    [Serializable]
    public class BTL_TestSetting
    {
        public int Id;
        public byte Dr1;
        public byte Dr1Lv;
        public ushort Dr1Bl1;
        public ushort Dr1Bl2;
        public ushort Dr1Bl3;
        public byte Dr2;
        public byte Dr2Lv;
        public ushort Dr2Bl1;
        public ushort Dr2Bl2;
        public ushort Dr2Bl3;
        public byte Dr3;
        public byte Dr3Lv;
        public ushort Dr3Bl1;
        public ushort Dr3Bl2;
        public ushort Dr3Bl3;
    }

    [BdatType]
    [Serializable]
    public class BTL_UCDirect
    {
        public int Id;
        public byte Slow;
        public byte Slowf;
        public byte Camera;
        public byte Waitf;
        public byte UIEffType;
        public byte UIStartf;
        public byte UIEndf;
        public byte Voicef;
    }

    [BdatType]
    [Serializable]
    public class BTL_UniteCombo
    {
        public int Id;
        public byte StageSum;
        public byte NorDamageBonus;
        public byte NorTimeBonus;
        public byte NorPartyBonus;
        public byte BonusRate;
        public byte Direction;
        public byte DamageBonusNum;
        public byte TimeBonusNum;
        public byte PartyBonusNum;
    }

    [BdatType]
    [Serializable]
    public class BTL_VolumeFade
    {
        public int Id;
        public string VolumeName;
    }

    [BdatType]
    [Serializable]
    public class BTL_VtxParticle
    {
        public int Id;
        public string Name;
    }

    [BdatType]
    [Serializable]
    public class BTL_Wpn_En
    {
        public int Id;
        public ushort RscR;
        public ushort RscL;
        public byte TypeRange;
        public ushort Damage;
        public byte Stability;
        public RSC_EnWpn _RscL;
        public RSC_EnWpn _RscR;
    }

    [BdatType]
    [Serializable]
    public class CAM_MaxLevel
    {
        public int Id;
        public byte RevReset;
        public byte RevAuto;
        public byte RotSpeed;
        public byte ZoomSpeed;
    }

    [BdatType]
    [Serializable]
    public class CAM_Params
    {
        public int Id;
        public byte RevReset;
        public byte RevAuto;
        public byte YawRotSpeed;
        public byte PitchRotSpeed;
        public byte ZoomSpeed;
    }

    [BdatType]
    [Serializable]
    public class CHR_Bl
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte Race;
        public byte RotateLimitPitch;
        public byte RotateLimitRoll;
        public byte Gender;
        public byte QuestRace;
        public string Model;
        public string Motion;
        public string AddMotion;
        public ushort Condition;
        public string Model2;
        public string Motion2;
        public ushort Still;
        public string Voice;
        public string ClipEvent;
        public string Com_SE;
        public string SePack;
        public string Com_Eff;
        public string Com_Vo;
        public ushort OffsetID;
        public byte EyeRot;
        public ushort ChestHeight;
        public ushort LandingHeight;
        public byte FootStep;
        public byte FootStepEffect;
        public byte WeaponType;
        public ushort Scale;
        public ushort WpnScale;
        public byte Flag;
        public ushort PrivateWpnR;
        public ushort PrivateWpnL;
        public ushort PrivateWpnR_Driver;
        public ushort PrivateWpnL_Driver;
        public string WpnrOut;
        public string WpnlOut;
        public byte OrbNum;
        public byte Atr;
        public byte Personality;
        public ushort CoolTime;
        public ushort DefWeapon;
        public ushort BArts1;
        public ushort BArts2;
        public ushort BArts3;
        public ushort BartsEx;
        public ushort BartsEx2;
        public byte NArts1;
        public byte NArtsRecastRev1;
        public byte NArts2;
        public byte NArtsRecastRev2;
        public byte NArts3;
        public byte NArtsRecastRev3;
        public ushort BSkill1;
        public ushort BSkill2;
        public ushort BSkill3;
        public byte PArmor;
        public byte EArmor;
        public byte HpMaxRev;
        public byte StrengthRev;
        public byte PowEtherRev;
        public byte DexRev;
        public byte AgilityRev;
        public byte LuckRev;
        public ushort BKLSet;
        public ushort FSkill1;
        public ushort FSkill2;
        public ushort FSkill3;
        public ushort ArtsAchievement1;
        public ushort ArtsAchievement2;
        public ushort ArtsAchievement3;
        public ushort SkillAchievement1;
        public ushort SkillAchievement2;
        public ushort SkillAchievement3;
        public ushort FskillAchivement1;
        public ushort FskillAchivement2;
        public ushort FskillAchivement3;
        public ushort KeyAchievement;
        public byte IdeaBlue;
        public byte IdeaRed;
        public byte IdeaWhite;
        public byte IdeaBlack;
        public ushort FavoriteCategory1;
        public ushort FavoriteItem1;
        public ushort FavoriteCategory2;
        public ushort FavoriteItem2;
        public ushort CreateEventID;
        public ushort NormalTalk;
        public ushort CollisionId;
        public byte BladeSize;
        public byte MemorySlot;
        public ushort EventAsset;
        public string CenterBone;
        public string CamBone;
        public ushort MerceName;
        public byte ReleaseLock;
        public ushort CreateInfo;
        public byte ExtraParts1;
        public byte ExtraParts2;
        public byte ExtraParts3;
        public byte ExtraParts4;
        public ushort MnuCastName;
        public ushort MnuIlustName;
        public string MnuVoice1;
        public string MnuVoice2;
        public string MnuVoice3;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool OnlyWpn;
        public bool NoBuildWpn;
        public bool OnlyChBtl;
        public bool FreeEngage;
        public bool NoMapRev;
        public FLD_AchievementSet _ArtsAchievement1;
        public FLD_AchievementSet _ArtsAchievement2;
        public FLD_AchievementSet _ArtsAchievement3;
        public MNU_Name _Atr;
        public BTL_Arts_Bl _BArts1;
        public BTL_Arts_Bl _BArts2;
        public BTL_Arts_Bl _BArts3;
        public BTL_Arts_BlSp _BartsEx;
        public BTL_Arts_BlSp _BartsEx2;
        public BTL_Skill_Bl _BSkill1;
        public BTL_Skill_Bl _BSkill2;
        public BTL_Skill_Bl _BSkill3;
        public FLD_ConditionList _Condition;
        public ITM_PcWpn _DefWeapon;
        public Message _FavoriteCategory1;
        public Message _FavoriteCategory2;
        public ITM_FavoriteList _FavoriteItem1;
        public ITM_FavoriteList _FavoriteItem2;
        public FLD_FieldSkillList _FSkill1;
        public FLD_FieldSkillList _FSkill2;
        public FLD_FieldSkillList _FSkill3;
        public FLD_AchievementSet _FskillAchivement1;
        public FLD_AchievementSet _FskillAchivement2;
        public FLD_AchievementSet _FskillAchivement3;
        public MNU_Name _Gender;
        public FLD_AchievementSet _KeyAchievement;
        public Message _MerceName;
        public Message _MnuCastName;
        public Message _MnuIlustName;
        public Message _Name;
        public BTL_Buff _NArts1;
        public BTL_Buff _NArts2;
        public BTL_Buff _NArts3;
        public BTL_Bl_Personality _Personality;
        public MNU_Name _QuestRace;
        public FLD_AchievementSet _SkillAchievement1;
        public FLD_AchievementSet _SkillAchievement2;
        public FLD_AchievementSet _SkillAchievement3;
        public MNU_IconList _Still;
        public ITM_PcWpnType _WeaponType;
        public BTL_Arts_Bl[] _BArts;
        public BTL_Buff[] _NArts;
        public byte[] _NArtsRecastRev;
        public BTL_Skill_Bl[] _BSkill;
        public FLD_FieldSkillList[] _FSkill;
        public FLD_AchievementSet[] _ArtsAchievement;
        public FLD_AchievementSet[] _SkillAchievement;
        public FLD_AchievementSet[] _FskillAchivement;
        public FLD_AchievementSet[] _Achievement;
        public Message[] _FavoriteCategory;
        public ITM_FavoriteList[] _FavoriteItem;
    }

    [BdatType]
    [Serializable]
    public class CHR_Dr
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte Race;
        public byte RotateLimitPitch;
        public byte RotateLimitRoll;
        public byte Gender;
        public string Model;
        public ushort Condition;
        public string Model2;
        public string Motion;
        public ushort Still;
        public ushort OffsetID;
        public byte EyeRot;
        public string Voice;
        public string ClipEvent;
        public string Com_SE;
        public string Com_Eff;
        public string Com_Vo;
        public ushort AiID;
        public ushort ChestHeight;
        public ushort LandingHeight;
        public byte FootStep;
        public byte FootStepEffect;
        public ushort DefBlade1;
        public ushort DefBlade2;
        public ushort DefBlade3;
        public byte DefLvType;
        public byte DefLv;
        public byte DefWPType;
        public ushort DefWP;
        public byte DefSPType;
        public ushort DefSP;
        public ushort DefAcce;
        public byte DefIdeaBlue;
        public byte DefIdeaRed;
        public byte DefIdeaWhite;
        public byte DefIdeaBlack;
        public ushort HpMaxLv1;
        public ushort StrengthLv1;
        public ushort PowEtherLv1;
        public ushort DexLv1;
        public ushort AgilityLv1;
        public ushort LuckLv1;
        public ushort HpMaxLv99;
        public ushort StrengthLv99;
        public ushort PowEtherLv99;
        public ushort DexLv99;
        public ushort AgilityLv99;
        public ushort LuckLv99;
        public readonly byte[] WpnType = new byte[34];
        public readonly byte[] WpRate = new byte[34];
        public ushort FavoriteCategory1;
        public ushort FavoriteItem1;
        public ushort FavoriteCategory2;
        public ushort FavoriteItem2;
        public ushort CollisionId;
        public ushort EventAsset;
        public sbyte RotateX;
        public sbyte RotateY;
        public sbyte RotateZ;
        public sbyte RotateDeg;
        public ushort RotEffScale;
        public string CenterBone;
        public string CamBone;
        public byte Personality;
        public ushort IraParam;
        public BTL_Ai _AiID;
        public FLD_ConditionList _Condition;
        public ITM_PcEquip _DefAcce;
        public CHR_Bl _DefBlade1;
        public CHR_Bl _DefBlade2;
        public CHR_Bl _DefBlade3;
        public Message _FavoriteCategory1;
        public Message _FavoriteCategory2;
        public ITM_FavoriteList _FavoriteItem1;
        public ITM_FavoriteList _FavoriteItem2;
        public MNU_Name _Gender;
        public CHR_Ir _IraParam;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class CHR_DriverParam
    {
        public int Id;
        public ushort ExtMountNpc;
        public string ExtMountBone;
        public ushort ExtMountCond;
        public FLD_ConditionList _ExtMountCond;
        public RSC_NpcList _ExtMountNpc;
    }

    [BdatType]
    [Serializable]
    public class CHR_EnArrange
    {
        public int Id;
        public ushort ParamID;
        public ushort EnemyBladeID;
        public ushort BladeID;
        public byte BladeAtr;
        public byte ExtraParts;
        public ushort Name;
        public string Debug_Name;
        public byte Lv;
        public byte LvRand;
        public byte HpOver;
        public ushort ExpRev;
        public ushort GoldRev;
        public ushort WPRev;
        public ushort SPRev;
        public ushort DropTableID;
        public ushort DropTableID2;
        public ushort DropTableID3;
        public ushort PreciousID;
        public ushort Score;
        public ushort ECube;
        public ushort Scale;
        public byte ChrSize;
        public byte TurnSize;
        public byte CamSize;
        public uint Flag;
        public byte LinkRadius;
        public byte Detects;
        public ushort SearchRange;
        public ushort SearchAngle;
        public byte SearchRadius;
        public byte BatInterval;
        public byte BatArea;
        public byte EN_WATER_DEAD_NONE;
        public byte BatAreaType;
        public byte DrawWait;
        public byte AiGroup;
        public byte AiGroupNum;
        public ushort BookID;
        public ushort EnhanceID1;
        public ushort EnhanceID2;
        public ushort EnhanceID3;
        public ushort ParamRev;
        public ushort RstDebuffRev;
        public byte HealPotTypeRev;
        public ushort SummonID;
        public byte BGMID;
        public byte SeEnvID;
        public byte ZoneID;
        public byte TimeSet;
        public byte WeatherSet;
        public byte DriverLev;
        public ushort Race;
        public byte LvMin;
        public byte LvMax;
        public ushort ScaleMin;
        public ushort ScaleMax;
        public bool Named;
        public bool mBoss;
        public bool Child;
        public bool FAOff;
        public bool NoEcSkip;
        public bool LinkType;
        public bool ChrColiOff;
        public bool NoTarget;
        public bool HikariSP4;
        public bool Homuri;
        public bool Hikari;
        public bool NoNaviMesh;
        public bool Fixed;
        public bool DropFront;
        public bool NoWarp;
        public bool IgnoreLevPow;
        public bool AlwaysAttack;
        public bool PGMax;
        public bool Salvage;
        public MNU_Filename _BGMID;
        public CHR_Bl _BladeID;
        public BTL_EnBook _BookID;
        public BTL_EnDropItem _DropTableID;
        public BTL_EnDropItem _DropTableID2;
        public BTL_EnDropItem _DropTableID3;
        public CHR_EnArrange _EnemyBladeID;
        public BTL_Enhance _EnhanceID1;
        public BTL_Enhance _EnhanceID2;
        public BTL_Enhance _EnhanceID3;
        public Message _Name;
        public CHR_EnParam _ParamID;
        public CHR_EnParam_Rev _ParamRev;
        public object _PreciousID;
        public FLD_maplist _ZoneID;
    }

    [BdatType]
    [Serializable]
    public class CHR_EnParam
    {
        public int Id;
        public string Debug_Name;
        public ushort ResourceID;
        public ushort AiID;
        public byte EnemyRole;
        public byte WalkSpeed;
        public byte RunSpeed;
        public byte BtlSpeed;
        public byte HpDefault;
        public byte HpLimit;
        public byte ScoutStartHp;
        public byte ScoutJoinRad;
        public byte ScoutEndHp;
        public ushort HpMaxRev;
        public ushort StrengthRev;
        public ushort PowEtherRev;
        public ushort DexRev;
        public ushort AgilityRev;
        public ushort LuckRev;
        public ushort Parmor;
        public ushort Earmor;
        public sbyte RstPower;
        public sbyte RstEther;
        public byte Atr;
        public sbyte RstFire;
        public sbyte RstWater;
        public sbyte RstWind;
        public sbyte RstEarth;
        public sbyte RstThunder;
        public sbyte RstIce;
        public sbyte RstDark;
        public sbyte RstLight;
        public byte CriticalRate;
        public byte GuardRate;
        public byte Flag;
        public byte HealPotDrop;
        public uint RstDebuff;
        public uint IvdDebuff;
        public uint WeakDebuff;
        public ushort RstFiCombo;
        public ushort IvdFiCombo;
        public ushort Aura;
        public byte AwakeLev;
        public byte DyingHP;
        public byte WTNormal;
        public byte WTDying;
        public byte Hate0Target;
        public ushort DeathArts;
        public uint DeathArtsStop;
        public ushort ArtsNum1;
        public ushort ArtsNum2;
        public ushort ArtsNum3;
        public ushort ArtsNum4;
        public ushort ArtsNum5;
        public ushort ArtsNum6;
        public ushort ArtsNum7;
        public ushort ArtsNum8;
        public ushort ArtsNum9;
        public ushort ArtsNum10;
        public ushort ArtsNum11;
        public ushort ArtsNum12;
        public ushort ArtsNum13;
        public ushort ArtsNum14;
        public ushort ArtsNum15;
        public ushort ArtsNum16;
        public ushort NormalAttackTop;
        public bool GrdDirFront;
        public bool GrdDirLeft;
        public bool GrdDirRight;
        public bool GrdDirBack;
        public bool FldDmgType;
        public bool TrgRndLady;
        public BTL_Ai _AiID;
        public BTL_Arts_En _ArtsNum1;
        public BTL_Arts_En _ArtsNum10;
        public BTL_Arts_En _ArtsNum11;
        public BTL_Arts_En _ArtsNum12;
        public BTL_Arts_En _ArtsNum13;
        public BTL_Arts_En _ArtsNum14;
        public BTL_Arts_En _ArtsNum15;
        public BTL_Arts_En _ArtsNum16;
        public BTL_Arts_En _ArtsNum2;
        public BTL_Arts_En _ArtsNum3;
        public BTL_Arts_En _ArtsNum4;
        public BTL_Arts_En _ArtsNum5;
        public BTL_Arts_En _ArtsNum6;
        public BTL_Arts_En _ArtsNum7;
        public BTL_Arts_En _ArtsNum8;
        public BTL_Arts_En _ArtsNum9;
        public MNU_Name _Atr;
        public BTL_Aura _Aura;
        public RSC_En _ResourceID;
    }

    [BdatType]
    [Serializable]
    public class CHR_EnParam_Rev
    {
        public int Id;
        public ushort HpMaxRev;
        public ushort StrengthRev;
        public ushort PowEtherRev;
        public ushort DexRev;
        public ushort AgilityRev;
        public ushort LuckRev;
    }

    [BdatType]
    [Serializable]
    public class CHR_EnParamTable
    {
        public int Id;
        public uint HpMaxBase;
        public ushort StrengthBase;
        public ushort PowEtherBase;
        public ushort DexBase;
        public ushort AgilityBase;
        public ushort LuckBase;
    }

    [BdatType]
    [Serializable]
    public class CHR_EnRstDebuff_Rev
    {
        public int Id;
        public byte RevType;
        public ushort RstFiCombo;
        public ushort IvdFiCombo;
        public uint RstDebuffRev;
        public uint IvdDebuffRev;
        public uint WeakDebuffRev;
    }

    [BdatType]
    [Serializable]
    public class CHR_Ir
    {
        public int Id;
        public ushort driverID;
        public byte Type;
        public byte GroupID;
        public byte DriverWpn;
        public ushort DefWpnAcce;
        public byte Flag;
        public ushort LinkSet;
        public bool WpnInNonView;
        public ITM_PcEquip _DefWpnAcce;
        public CHR_Dr _driverID;
        public ITM_PcWpnIr _DriverWpn;
        public BTL_Bl_KizunaLinkSet _LinkSet;
        public IraCharType _Type;
    }

    [BdatType]
    [Serializable]
    public class COL_CharList
    {
        public int Id;
        public ushort Radius;
        public ushort Height;
    }

    [BdatType]
    [Serializable]
    public class EFF_KizunaLink
    {
        public int Id;
        public short WavePower;
        public short WaveInterval;
        public short WaveSpeed;
        public short UTiling;
        public short VTiling;
        public short UScroll;
        public short VScroll;
        public short Bloom;
        public byte Red1;
        public byte Green1;
        public byte Blue1;
        public byte Alpha1;
        public byte Red2;
        public byte Green2;
        public byte Blue2;
        public byte Alpha2;
        public string Texture;
    }

    [BdatType]
    [Serializable]
    public class EventChange
    {
        public int Id;
        public string chgName;
        public sbyte chgType;
        public int id;
        public int value0;
        public int value1;
        public string string0;
        public EventGroup _chgType;
    }

    [BdatType]
    [Serializable]
    public class EventGroup
    {
        public int Id;
        public string grpName;
        public string grpNameJP;
        public byte atrDisp;
        public string atrName;
        public string atrNameJP;
        public byte atrType;
        public string atrOptStr1;
        public string atrOptStr2;
        public string atrDefStr1;
    }

    [BdatType]
    [Serializable]
    public class EVT_acttype
    {
        public int Id;
        public string name;
        public short value;
        public string stat0;
        public string stat1;
        public string stat2;
        public string statI;
        public string cmd0;
        public string cmd1;
        public string cmd2;
    }

    [BdatType]
    [Serializable]
    public class EVT_assetList
    {
        public int Id;
        public string facialSeat;
        public short lensID;
    }

    [BdatType]
    [Serializable]
    public class EVT_bgm
    {
        public int Id;
        public string nodeName;
        public string nodeNameJP;
        public byte nodeExtra;
        public byte nodeWidth;
        public string grpName;
        public string grpNameJP;
        public byte grpExtra;
        public byte grpArray;
        public byte atrDisp;
        public string atrName;
        public string atrNameJP;
        public byte atrType;
        public string atrOptStr1;
        public string atrOptStr2;
        public string atrDefStr1;
    }

    [BdatType]
    [Serializable]
    public class EVT_cutscene_bl
    {
        public int Id;
        public string resource;
        public short id;
    }

    [BdatType]
    [Serializable]
    public class EVT_cutscene_pc
    {
        public int Id;
        public string resource;
        public short id;
        public int scenarioMin;
        public int scenarioMax;
    }

    [BdatType]
    [Serializable]
    public class EVT_cutscene_wp
    {
        public int Id;
        public short id;
        public short blade;
        public string resourceR;
        public string resourceL;
        public int scenarioMin;
        public int scenarioMax;
    }

    [BdatType]
    [Serializable]
    public class EVT_dof
    {
        public int Id;
        public string name;
        public float dist;
        public float range;
        public float foMin;
        public float pixel;
        public float lens;
        public float strength;
        public float blend;
        public short pixelLv;
        public short hlv;
    }

    [BdatType]
    [Serializable]
    public class EVT_eyetype
    {
        public int Id;
        public string name;
        public short value;
        public string stat;
        public sbyte disableWink;
    }

    [BdatType]
    [Serializable]
    public class EVT_facialtype
    {
        public int Id;
        public string name;
    }

    [BdatType]
    [Serializable]
    public class EVT_formation
    {
        public int Id;
        public string name;
        public float ofsX;
        public float ofsZ;
        public float rot;
    }

    [BdatType]
    [Serializable]
    public class EVT_headtype
    {
        public int Id;
        public string name;
        public short value;
        public string stat;
        public short blend;
        public float weight;
    }

    [BdatType]
    [Serializable]
    public class EVT_lens
    {
        public int Id;
        public short thMin;
        public short thMax;
        public short tvMin;
        public short tvMax;
        public short rhMin;
        public short rhMax;
        public short rvMin;
        public short rvMax;
    }

    [BdatType]
    [Serializable]
    public class EVT_liptype
    {
        public int Id;
        public string name;
        public short value;
        public string stat;
        public sbyte disableTalkLip;
    }

    [BdatType]
    [Serializable]
    public class EVT_listBf
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public byte cssnd;
        public ushort scenarioFlag;
        public string scriptName;
        public int scriptStartId;
        public ushort nextIDtheater;
        public float toneMap;
        public EventCategory _category;
        public EventChange _chgEdID;
        public EventChange _chgStID;
        public SYS_MapJumpEvList _edFormID;
        public EVT_listBf _envSeam;
        public EVT_listBf _linkID;
        public EVT_listBf _nextIDtheater;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_listBl
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public byte cssnd;
        public string scriptName;
        public int scriptStartId;
        public float toneMap;
        public EventCategory _category;
        public SYS_MapJumpEvList _edFormID;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_listDeb01
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public byte cssnd;
        public ushort centerID;
        public float centerX;
        public float centerY;
        public float centerZ;
        public float centerR;
        public ushort centerForm;
        public string scriptName;
        public int scriptStartId;
        public ushort nextIDtheater;
        public float toneMap;
        public EventCategory _category;
        public EventChange _chgEdID;
        public EventChange _chgStID;
        public SYS_MapJumpEvList _edFormID;
        public EVT_setupB _setupID;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_listFev01
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public ushort centerID;
        public float centerX;
        public float centerY;
        public float centerZ;
        public float centerR;
        public ushort centerForm;
        public string scriptName;
        public int scriptStartId;
        public float toneMap;
        public EventCategory _category;
        public EventChange _chgEdID;
        public EventChange _chgStID;
        public SYS_MapJumpEvList _edFormID;
        public EVT_setupB _setupID;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_listList
    {
        public int Id;
        public byte type;
        public byte chap;
        public string listSeat;
        public string setupSeat;
        public string chgSeat;
        public byte target;
    }

    [BdatType]
    [Serializable]
    public class EVT_listQst01
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public ushort centerID;
        public float centerX;
        public float centerY;
        public float centerZ;
        public float centerR;
        public ushort centerForm;
        public string scriptName;
        public int scriptStartId;
        public ushort nextIDtheater;
        public float toneMap;
        public EventCategory _category;
        public EventChange _chgEdID;
        public EventChange _chgStID;
        public SYS_MapJumpEvList _edFormID;
        public EVT_setupB _setupID;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_listTlk01
    {
        public int Id;
        public string evtName;
        public string mstxt;
        public ushort setupID;
        public ushort chgStID;
        public ushort chgEdID;
        public byte category;
        public byte weather;
        public string clock;
        public byte clockStop;
        public byte cloud;
        public byte text;
        public byte opFadeOutEnable;
        public ushort opFadeOut;
        public ushort opFadeWait;
        public byte opFadeInEnable;
        public ushort opFadeIn;
        public byte opFadeColR;
        public byte opFadeColG;
        public byte opFadeColB;
        public byte edFadeOutEnable;
        public ushort edFadeOut;
        public ushort edFadeWait;
        public byte edFadeInEnable;
        public ushort edFadeIn;
        public byte edFadeColR;
        public byte edFadeColG;
        public byte edFadeColB;
        public ushort stFormID;
        public ushort edFormID;
        public byte opBgm;
        public byte edBgm;
        public byte hideNpc;
        public byte hideEne;
        public byte hideMob;
        public byte hideMap;
        public ushort outsiderOpt;
        public byte outsiderEnable;
        public byte outsiderType;
        public float outsiderX;
        public float outsiderY;
        public float outsiderZ;
        public float outsiderR;
        public byte listenType;
        public float listenX;
        public float listenY;
        public float listenZ;
        public ushort nextID;
        public ushort zoneID;
        public float zoneX;
        public float zoneY;
        public float zoneZ;
        public float zoneR;
        public byte chapID;
        public ushort linkID;
        public byte jijiDisp;
        public ushort wpnDisp;
        public ushort colFilterNear;
        public ushort colFilterFar;
        public ushort envSeam;
        public string evtLight;
        public byte hood;
        public byte voice;
        public string scriptName;
        public int scriptStartId;
        public EventCategory _category;
        public EventChange _chgEdID;
        public EventChange _chgStID;
        public SYS_MapJumpEvList _edFormID;
        public EVT_setupB _setupID;
        public SYS_MapJumpEvList _stFormID;
        public FLD_maplist _zoneID;
    }

    [BdatType]
    [Serializable]
    public class EVT_nearfar
    {
        public int Id;
        public string name;
        public float near;
        public float far;
    }

    [BdatType]
    [Serializable]
    public class EVT_randtype
    {
        public int Id;
        public string name;
        public short value;
        public string id;
    }

    [BdatType]
    [Serializable]
    public class EVT_setup
    {
        public int Id;
        public string setupName;
        public string objName;
        public sbyte objType;
        public string objID;
        public string objModel;
        public string wpnBlade;
    }

    [BdatType]
    [Serializable]
    public class EVT_setupB
    {
        public int Id;
        public string setupName;
        public string objName;
        public byte objType;
        public string objID;
        public string objModel;
        public string wpnBlade;
    }

    [BdatType]
    [Serializable]
    public class FacialConfig
    {
        public int Id;
        public string name;
        public short brow_type;
        public float brow_weight;
        public short eye_type;
        public float eye_weight;
        public short lip_type;
        public float lip_weight;
        public short facial_blend;
        public float talk_head_weight;
        public float talk_head_speed;
        public float talk_lip_weight;
        public float talk_lip_speed;
        public short talk_blend;
        public BdatStateEnum _brow_type;
        public EVT_eyetype _eye_type;
        public EVT_liptype _lip_type;
    }

    [BdatType]
    [Serializable]
    public class FLD_Achievement
    {
        public int Id;
        public ushort StatsID;
        public uint Count;
        public string DebugName;
    }

    [BdatType]
    [Serializable]
    public class FLD_AchievementList
    {
        public int Id;
        public ushort Title;
        public byte Category;
        public ushort Icon;
        public ushort Task;
        public ushort VoiceCategory;
        public ushort AfterVoice;
        public byte Difficulty;
        public byte IdeaCategory;
        public ushort IdeaValue;
        public FLD_QuestList _Task;
    }

    [BdatType]
    [Serializable]
    public class FLD_AchievementSet
    {
        public int Id;
        public byte Category;
        public byte AbilityLevel;
        public ushort AchievementID1;
        public ushort AchievementID2;
        public ushort AchievementID3;
        public ushort AchievementID4;
        public ushort AchievementID5;
        public FLD_AchievementList _AchievementID1;
        public FLD_AchievementList _AchievementID2;
        public FLD_AchievementList _AchievementID3;
        public FLD_AchievementList _AchievementID4;
        public FLD_AchievementList _AchievementID5;
        public FLD_AchievementList[] _AchievementID;
    }

    [BdatType]
    [Serializable]
    public class FLD_actorSE
    {
        public int Id;
        public string LOD;
        public byte se_type;
        public ushort seName;
        public float max_volume_Dist;
        public float min_volume_Dist;
        public byte volumeMAX;
        public byte volumeMIN;
        public float offsetX;
        public float offsetY;
        public float offsetZ;
    }

    [BdatType]
    [Serializable]
    public class FLD_AddItem
    {
        public int Id;
        public ushort ItemID1;
        public sbyte ItemNumber1;
        public ushort ItemID2;
        public sbyte ItemNumber2;
        public ushort ItemID3;
        public sbyte ItemNumber3;
        public object _ItemID1;
        public object _ItemID2;
        public object _ItemID3;
    }

    [BdatType]
    [Serializable]
    public class FLD_AntiBladeArea
    {
        public int Id;
        public string name;
        public ushort BTL_MapRevId;
        public BTL_MapRev _BTL_MapRevId;
    }

    [BdatType]
    [Serializable]
    public class FLD_BattleChallange
    {
        public int Id;
        public string name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_BladePop
    {
        public int Id;
        public string name;
        public byte BladeSizeCheck;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Mot;
        public byte NpcTurn;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort BattleReaction;
        public ushort BattleMot;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public FLD_ConditionList _Condition;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class FLD_BtnChallenge
    {
        public int Id;
        public ushort Start;
        public ushort Speed;
        public ushort Gsuccess;
        public ushort Success;
    }

    [BdatType]
    [Serializable]
    public class FLD_CampPop
    {
        public int Id;
        public string name;
        public ushort ConditionID;
        public ushort CampPointName;
        public Message _CampPointName;
        public FLD_ConditionList _ConditionID;
    }

    [BdatType]
    [Serializable]
    public class FLD_ClimbingPOP
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public byte OP_gimmickType;
        public ushort OP_gimmickID;
        public ushort climiconRadius;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_CollectionTable
    {
        public int Id;
        public ushort FSID;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public ushort itm1ID;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Per;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public byte rsc_paramID;
        public FLD_FieldSkillList _FSID;
        public object _itm1ID;
        public object _itm2ID;
        public object _itm3ID;
        public object _itm4ID;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionAchievement
    {
        public int Id;
        public ushort AchievementSetID;
        public byte Value;
        public FLD_AchievementSet _AchievementSetID;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionEnv
    {
        public int Id;
        public uint TimeRange;
        public uint Weather;
        public byte CloudHeight;
        public BdatEnum _CloudHeight;
        public TimeRange _TimeRange;
        public WeatherBits _Weather;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionFieldSkiiLevel
    {
        public int Id;
        public ushort FieldSkillID;
        public byte Level;
        public FLD_FieldSkillList _FieldSkillID;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionFlag
    {
        public int Id;
        public byte FlagType;
        public ushort FlagID;
        public ushort FlagMin;
        public ushort FlagMax;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionIdea
    {
        public int Id;
        public ushort PCID;
        public byte IdeaLevelBlue;
        public byte IdeaLevelRed;
        public byte IdeaLevelWhite;
        public byte IdeaLevelBlack;
        public ushort Compatibility;
        public ushort TrustPoint;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionItem
    {
        public int Id;
        public byte ItemCategory;
        public ushort ItemID;
        public byte Number;
        public object _ItemID;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionLevel
    {
        public int Id;
        public ushort PCID;
        public byte Level;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionList
    {
        public int Id;
        public byte Premise;
        public byte ConditionType1;
        public ushort Condition1;
        public byte ConditionType2;
        public ushort Condition2;
        public byte ConditionType3;
        public ushort Condition3;
        public byte ConditionType4;
        public ushort Condition4;
        public byte ConditionType5;
        public ushort Condition5;
        public byte ConditionType6;
        public ushort Condition6;
        public byte ConditionType7;
        public ushort Condition7;
        public byte ConditionType8;
        public ushort Condition8;
        public object _Condition1;
        public object _Condition2;
        public object _Condition3;
        public object _Condition4;
        public object _Condition5;
        public object _Condition6;
        public object _Condition7;
        public object _Condition8;
        public ConditionType _ConditionType1;
        public ConditionType _ConditionType2;
        public ConditionType _ConditionType3;
        public ConditionType _ConditionType4;
        public ConditionType _ConditionType5;
        public ConditionType _ConditionType6;
        public ConditionType _ConditionType7;
        public ConditionType _ConditionType8;
        public BdatEnum _Premise;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionMapGimmick
    {
        public int Id;
        public ushort MapGimmickID;
        public byte EndCheck;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionNamed
    {
        public int Id;
        public ushort Named;
        public byte Difficult;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionPT
    {
        public int Id;
        public byte Category;
        public ushort PCID1;
        public ushort PCID2;
        public ushort PCID3;
        public PartyConditionType _Category;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionQuest
    {
        public int Id;
        public ushort QuestFlag1;
        public byte QuestFlagMin1;
        public byte QuestFlagMax1;
        public ushort QuestFlag2;
        public byte QuestFlagMin2;
        public byte QuestFlagMax2;
        public ushort NotQuestFlag1;
        public byte NotQuestFlagMin1;
        public byte NotQuestFlagMax1;
        public ushort NotQuestFlag2;
        public byte NotQuestFlagMin2;
        public byte NotQuestFlagMax2;
    }

    [BdatType]
    [Serializable]
    public class FLD_ConditionScenario
    {
        public int Id;
        public ushort ScenarioMin;
        public ushort ScenarioMax;
        public ushort NotScenarioMin;
        public ushort NotScenarioMax;
    }

    [BdatType]
    [Serializable]
    public class FLD_DMGFloor
    {
        public int Id;
        public ushort Condition;
        public ushort MAPID;
        public ushort attributeID;
        public float DMG_interval;
        public byte Pc_dmg;
        public byte EN_dmg;
        public FLD_ConditionList _Condition;
        public FLD_maplist _MAPID;
    }

    [BdatType]
    [Serializable]
    public class FLD_DMGGimmick
    {
        public int Id;
        public string name;
        public ushort Condition;
        public byte DEPOP_gimmickType;
        public ushort DEPOP_gimmickID;
        public ushort DEPOP_Condition;
        public float DMG_interval;
        public byte Pc_dmg;
        public byte EN_dmg;
        public string effect_name;
        public byte SE_name;
        public byte volumeMAX;
        public byte volumeMIN;
        public ushort effect_disp_r;
        public byte effect_release_r;
        public short dmggim_nextwait;
        public FLD_ConditionList _Condition;
        public FLD_ConditionList _DEPOP_Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_DoorGimmick
    {
        public int Id;
        public string name;
        public ushort Condition;
        public byte gimmickType;
        public ushort gimmickID;
        public byte OP_gimmickType;
        public ushort OP_gimmickID;
        public byte response_type;
        public byte response_CHR;
        public ushort tgtMSG_ID;
        public ushort nameRadius;
        public ushort offsetID;
        public ushort LODmodel;
        public ushort missMSG_ID;
        public byte flag;
        public ushort open_SE;
        public byte open_SE_size;
        public string open_camGim_ID;
        public byte open_camGim_ATR;
        public ushort close_SE;
        public byte close_SE_size;
        public string close_camGim_ID;
        public byte close_camGim_ATR;
        public float door_nextwait;
        public byte SPOP_gimmickType;
        public ushort SPOP_gimmickID;
        public string sp_close_camGim_ID;
        public byte sp_close_camGim_ATR;
        public bool open_LODanime;
        public bool open_SE_type;
        public bool close_LODanime;
        public bool close_SE_type;
        public bool gmkCamPos;
        public FLD_ConditionList _Condition;
        public FLD_LODList _LODmodel;
    }

    [BdatType]
    [Serializable]
    public class FLD_EffectPop
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_ElevatorGimmick
    {
        public int Id;
        public string name;
        public ushort OP_Condition;
        public ushort tgt_callswitchMSG_ID;
        public ushort callnameRadius;
        public ushort call_offsetID;
        public ushort tgt_liftswitchMSG_ID;
        public ushort liftnameRadius;
        public ushort lift_offsetID;
        public ushort LIFTLOD;
        public ushort shtALOD;
        public ushort shtBLOD;
        public ushort switchALOD;
        public ushort switchBLOD;
        public ushort switchSE;
        public ushort shutterSE;
        public ushort LiftStartSE;
        public ushort LiftLoopSE;
        public ushort LiftStopSE;
        public byte LiftMinVolDist;
        public byte LiftMaxVolDist;
        public byte flag;
        public float call_liftspeed;
        public byte mapjump_startPOS;
        public ushort missMSG_ID;
        public short elevator_nextwait;
        public ushort liftAMapJumpId;
        public ushort liftBMapJumpId;
        public bool shutterfade;
        public bool lift_reverse;
        public FLD_ConditionList _OP_Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_ENActMove
    {
        public int Id;
        public byte actIDL_Per;
        public byte actMove_Per;
        public byte IDL_Per;
        public byte IDL_Time;
        public byte UIDL1_Per;
        public byte UIDL2_Per;
        public byte ExIDL1_Per;
        public byte ExIDL1_Time;
        public byte ExIDL2_Per;
        public byte ExIDL2_Time;
        public byte actIDL_Atr;
        public byte walk_Per;
        public byte run_Per;
        public byte Dir_Per;
        public ushort Dir_Line;
        public ushort Dir_Curve;
        public byte Dis_Min;
        public byte Dis_Max;
        public byte fldEne_Param;
        public byte actMove_Atr;
    }

    [BdatType]
    [Serializable]
    public class FLD_EnemyGroup
    {
        public int Id;
        public ushort EnemyID1;
        public ushort EnemyID2;
        public ushort EnemyID3;
        public ushort EnemyID4;
        public ushort EnemyID5;
        public ushort EnemyID6;
        public ushort EnemyID7;
        public ushort EnemyID8;
        public ushort EnemyID9;
        public ushort EnemyID10;
        public ushort EnemyID11;
        public ushort EnemyID12;
        public CHR_EnArrange _EnemyID1;
        public CHR_EnArrange _EnemyID10;
        public CHR_EnArrange _EnemyID11;
        public CHR_EnArrange _EnemyID12;
        public CHR_EnArrange _EnemyID2;
        public CHR_EnArrange _EnemyID3;
        public CHR_EnArrange _EnemyID4;
        public CHR_EnArrange _EnemyID5;
        public CHR_EnArrange _EnemyID6;
        public CHR_EnArrange _EnemyID7;
        public CHR_EnArrange _EnemyID8;
        public CHR_EnArrange _EnemyID9;
    }

    [BdatType]
    [Serializable]
    public class FLD_EnemyWave
    {
        public int Id;
        public string name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public byte instanceMax;
        public byte onlyOnce;
        public ushort gimmick;
        public ushort waitTime;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_EnemyWaveIra
    {
        public int Id;
        public string name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public byte instanceMax;
        public byte onlyOnce;
        public ushort gimmick;
        public ushort waitTime;
        public ushort nameRadius;
        public ushort offsetID;
        public ushort tgtMSG_ID;
        public ushort actionwindowID;
        public ushort sealedStonePopID;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_FieldLockGimmick
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public byte rockTYPE;
        public ushort txtID;
        public ushort map_collisionID;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_FieldSkillList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Type;
        public ushort RandomID;
        public byte MinLevel;
        public byte MaxLevel;
        public byte Category;
        public byte Rarity;
        public ushort Icon;
        public ushort VoiceCategory;
        public byte Attirbute;
        public MNU_Name _Attirbute;
        public Message _Caption;
        public FieldSkillCategory _Category;
        public Message _Name;
        public FLD_FieldSkillRandom _RandomID;
    }

    [BdatType]
    [Serializable]
    public class FLD_FieldSkillRandom
    {
        public int Id;
        public byte Level1Chance;
        public byte Level2Chance;
        public byte Level3Chance;
    }

    [BdatType]
    [Serializable]
    public class FLD_FieldSkillSetting
    {
        public int Id;
        public ushort Name;
        public ushort FieldSkillID1;
        public byte FieldSkillLevel1;
        public ushort FieldSkillID2;
        public byte FieldSkillLevel2;
        public ushort SuccessVoiceCategory;
        public ushort MissVoiceCategory;
        public FLD_FieldSkillList _FieldSkillID1;
        public FLD_FieldSkillList _FieldSkillID2;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class FLD_FootPrintsRoutes
    {
        public int Id;
        public string name;
        public string FootEffect;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_GravePopList
    {
        public int Id;
        public string name;
        public ushort RSC_ID;
        public ushort en_popID;
    }

    [BdatType]
    [Serializable]
    public class FLD_IdeaTable
    {
        public int Id;
        public uint TrustPoint;
        public ushort WpnRatio;
        public byte NArtsProbRev;
        public short BladeChangeRev;
        public short BladeArtsRev;
        public ushort FormSwichF;
    }

    [BdatType]
    [Serializable]
    public class FLD_InnEvent
    {
        public int Id;
        public ushort Condition;
        public ushort EventID;
        public ushort KizunaTalkID;
    }

    [BdatType]
    [Serializable]
    public class FLD_JumpGimmick
    {
        public int Id;
        public string name;
        public ushort Condition;
        public ushort FSID;
        public byte jumpType;
        public ushort tgtMSG_ID;
        public ushort nameRadius;
        public ushort offsetID;
        public short jump_nextwait;
        public ushort menuMapImage;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
    }

    [BdatType]
    [Serializable]
    public class FLD_KizunaTalk
    {
        public int Id;
        public string name;
        public ushort ConditionID;
        public ushort Title;
        public ushort EventID;
        public ushort EVCondition;
        public ushort menuMapImage;
        public FLD_ConditionList _ConditionID;
        public FLD_ConditionList _EVCondition;
        public EVT_listFev01 _EventID;
        public Message _Title;
    }

    [BdatType]
    [Serializable]
    public class FLD_LODList
    {
        public int Id;
        public ushort LODID;
        public uint flag;
        public ushort ScenarioFlagMin1;
        public ushort ScenarioFlagMax1;
        public ushort QuestFlag1;
        public byte QuestFlagMin1;
        public byte QuestFlagMax1;
        public ushort Condition1;
        public ushort ScenarioFlagMin2;
        public ushort ScenarioFlagMax2;
        public ushort QuestFlag2;
        public byte QuestFlagMin2;
        public byte QuestFlagMax2;
        public ushort Condition2;
        public ushort ScenarioFlagMin3;
        public ushort ScenarioFlagMax3;
        public ushort QuestFlag3;
        public byte QuestFlagMin3;
        public byte QuestFlagMax3;
        public ushort Condition3;
        public string effect_anime_normal;
        public string effect_anime_reverse;
        public string effect_visibleON;
        public string effect_visibleOFF;
        public string effect_fadeOUT;
        public float LOD_fadeIN_TIME;
        public float LOD_fadeOUT_TIME;
        public ushort effect_skipframe;
        public float effect_pop_dist;
        public bool Visible;
        public bool AnimReverse;
        public bool VisibleChange1;
        public bool AnimReverseChange1;
        public bool AnimReverseSkip1;
        public bool AnimPause1;
        public bool VisibleChange2;
        public bool AnimReverseChange2;
        public bool AnimReverseSkip2;
        public bool AnimPause2;
        public bool VisibleChange3;
        public bool AnimReverseChange3;
        public bool AnimReverseSkip3;
        public bool AnimPause3;
        public bool LOD_fadeIN_collision;
        public bool LOD_fadeOUT_collision;
        public bool LOD_bind_type;
        public FLD_ConditionList _Condition1;
        public FLD_ConditionList _Condition2;
        public FLD_ConditionList _Condition3;
    }

    [BdatType]
    [Serializable]
    public class FLD_LookSetBl
    {
        public int Id;
        public ushort RefID;
        public ushort LookType;
        public ushort Chara;
    }

    [BdatType]
    [Serializable]
    public class FLD_LookSetEn
    {
        public int Id;
        public ushort RefID;
        public ushort Chara;
    }

    [BdatType]
    [Serializable]
    public class FLD_LookType000
    {
        public int Id;
        public ushort Chara;
        public float Radius;
        public float UpperHeight;
        public float LowerHeight;
        public float LookTime;
        public float Interval;
        public sbyte Priority;
    }

    [BdatType]
    [Serializable]
    public class FLD_MapGimmick
    {
        public int Id;
        public string name;
        public uint popTime;
        public byte popWeather;
        public byte gimmickType;
        public ushort gimmickID;
        public ushort Condition;
        public byte response_CHR;
        public ushort nameRadius;
        public ushort offsetID;
        public ushort tgtMSG_ID;
        public ushort actionwindowID;
        public ushort missMSG_ID;
        public byte G1_LOD_switchtype;
        public byte G2_LOD_switchtype;
        public byte G3_LOD_switchtype;
        public byte G4_LOD_switchtype;
        public byte G5_LOD_switchtype;
        public ushort OP_ScenarioFlagMin;
        public ushort OP_ScenarioFlagMax;
        public ushort OP_QuestFlag;
        public byte OP_QuestFlagMin;
        public byte OP_QuestFlagMax;
        public ushort OP_Condition;
        public ushort OP_Time;
        public byte OP_Weather;
        public byte OP_gimmickType;
        public ushort OP_gimmickID;
        public ushort FSID;
        public ushort G1_LODmodel;
        public byte G1_LODanime_play;
        public ushort G1_LOD_SE;
        public byte G1_LOD_size;
        public short nextwait1;
        public ushort G2_LODmodel;
        public byte G2_LODanime_play;
        public ushort G2_LOD_SE;
        public byte G2_LOD_size;
        public short nextwait2;
        public ushort G3_LODmodel;
        public byte G3_LODanime_play;
        public ushort G3_LOD_SE;
        public byte G3_LOD_size;
        public short nextwait3;
        public ushort G4_LODmodel;
        public byte G4_LODanime_play;
        public ushort G4_LOD_SE;
        public byte G4_LOD_size;
        public short nextwait4;
        public ushort G5_LODmodel;
        public byte G5_LODanime_play;
        public ushort G5_LOD_SE;
        public byte G5_LOD_size;
        public short nextwait5;
        public ushort mapobjID;
        public string mapobjeffect;
        public ushort mapobjSE;
        public float mapobj_fadeOUT_TIME;
        public ushort flag;
        public ushort mapobj_nextwait;
        public string gmkCamName;
        public byte camGim_ATR;
        public ushort menuMapImage;
        public ushort effectID;
        public bool MSG_ray;
        public bool mapobj_fadeOUT_collision;
        public bool gmkCamPos;
        public bool nowaitGmkCam;
        public bool G1_LOD_SE_type;
        public bool G2_LOD_SE_type;
        public bool G3_LOD_SE_type;
        public bool G4_LOD_SE_type;
        public bool G5_LOD_SE_type;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
        public FLD_ConditionList _OP_Condition;
        public Message _tgtMSG_ID;
    }

    [BdatType]
    [Serializable]
    public class FLD_MapJump
    {
        public int Id;
        public string name;
        public ushort MapJumpId;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class FLD_maplist
    {
        public int Id;
        public string resource;
        public string select;
        public uint rscGmkId;
        public byte ene_disp_r;
        public byte ene_disp_h;
        public byte ene_release_r;
        public byte ene_release_h;
        public byte wa_type;
        public byte wa_pop_rate;
        public ushort wa_time_BNS;
        public byte wa_end_time;
        public byte wb_type;
        public byte wb_pop_rate;
        public ushort wb_time_BNS;
        public byte wb_end_time;
        public byte wc_type;
        public byte wc_pop_rate;
        public ushort wc_time_BNS;
        public byte wc_end_time;
        public byte wd_type;
        public byte wd_pop_rate;
        public ushort wd_time_BNS;
        public byte wd_end_time;
        public byte wind_mor;
        public byte wind_non;
        public byte wind_eve;
        public byte wind_nit;
        public byte wind_mnit;
        public byte wind_emor;
        public byte wind_WA;
        public byte wind_WB;
        public byte wind_WC;
        public byte wind_WD;
        public byte weatherATR;
        public byte e_repoptime;
        public byte m_repoptime;
        public byte mapATR;
        public ushort wa_ON_cndID;
        public ushort wa_OFF_cndID;
        public ushort wb_ON_cndID;
        public ushort wb_OFF_cndID;
        public ushort wc_ON_cndID;
        public ushort wc_OFF_cndID;
        public ushort wd_ON_cndID;
        public ushort wd_OFF_cndID;
        public ushort stopTIME_cndID;
        public ushort ebb_ON_cndID;
        public ushort ebb_inn_cndID;
        public byte ebb_pop_rate;
        public ushort st_allOFF_cndID;
        public ushort st_OFF_cndID;
        public ushort bgm_cndID;
        public ushort name_cndID;
        public ushort nameID;
        public ushort change_nameID;
        public ushort mapON_cndID;
        public ushort textID;
        public byte e_balloondisp_r;
        public byte zone;
        public RSC_BgmCondition _bgm_cndID;
        public Message _change_nameID;
        public FLD_ConditionList _ebb_inn_cndID;
        public FLD_ConditionList _ebb_ON_cndID;
        public FLD_ConditionList _mapON_cndID;
        public FLD_ConditionList _name_cndID;
        public Message _nameID;
        public FLD_ConditionList _st_allOFF_cndID;
        public FLD_ConditionList _stopTIME_cndID;
        public FLD_ConditionList _wa_OFF_cndID;
        public FLD_ConditionList _wa_ON_cndID;
        public TimeRange _wa_time_BNS;
        public FLD_WeatherInfo _wa_type;
        public FLD_ConditionList _wb_OFF_cndID;
        public FLD_ConditionList _wb_ON_cndID;
        public TimeRange _wb_time_BNS;
        public FLD_WeatherInfo _wb_type;
        public FLD_ConditionList _wc_OFF_cndID;
        public FLD_ConditionList _wc_ON_cndID;
        public TimeRange _wc_time_BNS;
        public FLD_WeatherInfo _wc_type;
        public FLD_ConditionList _wd_OFF_cndID;
        public FLD_ConditionList _wd_ON_cndID;
        public TimeRange _wd_time_BNS;
        public FLD_WeatherInfo _wd_type;
        public Message _zone;
    }

    [BdatType]
    [Serializable]
    public class FLD_MercenariesMission
    {
        public int Id;
        public ushort QuestID;
        public byte Category;
        public ushort RequestPerformance;
        public byte Repeatable;
        public ushort AutoStart;
        public FLD_ConditionList _AutoStart;
        public FLD_QuestList _QuestID;
    }

    [BdatType]
    [Serializable]
    public class FLD_MobGroupList
    {
        public int Id;
        public ushort MOBID1;
        public ushort MOBID2;
        public ushort MOBID3;
        public ushort MOBID4;
        public ushort MOBID5;
        public ushort MOBID6;
        public ushort MOBID7;
        public ushort MOBID8;
        public RSC_MobList _MOBID1;
        public RSC_MobList _MOBID2;
        public RSC_MobList _MOBID3;
        public RSC_MobList _MOBID4;
        public RSC_MobList _MOBID5;
        public RSC_MobList _MOBID6;
        public RSC_MobList _MOBID7;
        public RSC_MobList _MOBID8;
    }

    [BdatType]
    [Serializable]
    public class FLD_NpcGroupId
    {
        public int Id;
        public byte memberNum;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public FLD_ConditionList _Condition;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class FLD_NpcMobMotionId
    {
        public int Id;
        public string cmdName;
        public byte flag;
        public bool notEyeBlink;
    }

    [BdatType]
    [Serializable]
    public class FLD_OwnerBonus
    {
        public int Id;
        public ushort Caption;
        public ushort Type;
        public ushort Value;
        public BTL_EnhanceMax _Type;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestBattle
    {
        public int Id;
        public byte Refer;
        public ushort EnemyID;
        public ushort EnemyGroupID;
        public ushort EnemySpeciesID;
        public ushort EnemyRaceID;
        public byte Count;
        public ushort CountFlag;
        public byte DeadAll;
        public ushort TimeCount;
        public byte TimeCountFlag;
        public ushort ReduceEnemyHP;
        public ushort ReducePCHP;
        public FLD_EnemyGroup _EnemyGroupID;
        public CHR_EnArrange _EnemyID;
        public RSC_EnGenus _EnemySpeciesID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestCollect
    {
        public int Id;
        public byte Refer;
        public ushort ItemID;
        public byte Category;
        public byte Count;
        public byte Deduct;
        public ushort TresureID;
        public ushort EnemyID;
        public ushort MapID;
        public ushort NpcID;
        public ushort CollectionID;
        public Message _Category;
        public CHR_EnArrange _EnemyID;
        public object _ItemID;
        public FLD_maplist _MapID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestCondition
    {
        public int Id;
        public ushort ConditionID;
        public ushort MapID;
        public ushort NpcID;
        public FLD_ConditionList _ConditionID;
        public FLD_maplist _MapID;
        public RSC_NpcList _NpcID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestEvent
    {
        public int Id;
        public ushort EventID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestFieldSkillCount
    {
        public int Id;
        public byte FieldSkillID;
        public ushort Count;
        public FLD_FieldSkillList _FieldSkillID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestGimmick
    {
        public int Id;
        public ushort MapID;
        public ushort DoorGimmickID;
        public ushort ElevatorGimmickID;
        public ushort JumpGimmickID;
        public ushort MapGimmickID;
        public byte MapGmkIconOff;
        public ushort WarpGimmickID;
        public ushort SalvagePointID;
        public ushort TboxPopID;
        public ushort EnemyWaveID;
        public ushort CampPopID;
        public ushort CollectionPopID;
        public ushort CollectionPopID_0;
        public byte EndCheck;
        public FLD_maplist _MapID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestHints
    {
        public int Id;
        public ushort MainChar1;
        public ushort MainChar2;
        public ushort MainChar3;
        public ushort MainChar4;
        public ushort FSkillID1;
        public ushort FSkillID2;
        public ushort FSkillID3;
        public ushort ClientNpc;
        public ushort ZoneID;
        public RSC_NpcList _ClientNpc;
        public FLD_FieldSkillList _FSkillID1;
        public FLD_FieldSkillList _FSkillID2;
        public FLD_FieldSkillList _FSkillID3;
        public FLD_maplist _ZoneID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestList
    {
        public int Id;
        public ushort QuestTitle;
        public byte QuestCategory;
        public byte Visible;
        public ushort Talker;
        public ushort Summary;
        public ushort ResultA;
        public ushort ResultB;
        public ushort SortNo;
        public byte RewardDisp;
        public ushort RewardSetA;
        public ushort RewardSetB;
        public ushort PRTQuestID;
        public ushort FlagPRT;
        public ushort FlagCLD;
        public ushort PurposeID;
        public byte CountCancel;
        public ushort NextQuestA;
        public ushort CallEventA;
        public ushort NextQuestB;
        public ushort CallEventB;
        public ushort HintsID;
        public ushort ClearVoice;
        public byte AutoStart;
        public ushort ItemLost;
        public ushort CancelCondition;
        public ushort QuestIcon;
        public ushort LinkedQuestID;
        public FLD_QuestHints _HintsID;
        public FLD_QuestList _LinkedQuestID;
        public FLD_QuestList _NextQuestA;
        public FLD_QuestList _NextQuestB;
        public FLD_QuestList _PRTQuestID;
        public FLD_QuestTask _PurposeID;
        public FLD_QuestReward _RewardSetA;
        public FLD_QuestReward _RewardSetB;
        public Message _QuestTitle;
        public Message _ResultA;
        public Message _ResultB;
        public Message _Summary;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestReach
    {
        public int Id;
        public byte Category;
        public ushort MapID;
        public ushort PlaceID;
        public FLD_maplist _MapID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestReward
    {
        public int Id;
        public uint Gold;
        public uint EXP;
        public ushort Sp;
        public ushort Coin;
        public byte DevelopZone;
        public ushort DevelopPoint;
        public ushort TrustPoint;
        public ushort MercenariesPoint;
        public byte IdeaCategory;
        public ushort IdeaValue;
        public ushort ItemID1;
        public byte ItemNumber1;
        public ushort ItemID2;
        public byte ItemNumber2;
        public ushort ItemID3;
        public byte ItemNumber3;
        public ushort ItemID4;
        public byte ItemNumber4;
        public FLD_maplist _DevelopZone;
        public object _ItemID1;
        public object _ItemID2;
        public object _ItemID3;
        public object _ItemID4;
        public object[] _ItemID;
        public byte[] _ItemNumber;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestRewardRandom
    {
        public int Id;
        public ushort Name;
        public ushort ItemCategory1;
        public ushort ItemID1;
        public ushort ItemIDPercent1;
        public ushort ItemCategory2;
        public ushort ItemID2;
        public ushort ItemIDPercent2;
        public ushort ItemCategory3;
        public ushort ItemID3;
        public ushort ItemIDPercent3;
        public ushort ItemCategory4;
        public ushort ItemID4;
        public ushort ItemIDPercent4;
        public ushort ItemCategory5;
        public ushort ItemID5;
        public ushort ItemIDPercent5;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestTalk
    {
        public int Id;
        public ushort MapID;
        public ushort NpcID;
        public ushort DummyGroup;
        public FLD_QuestTalkDummyGroup _DummyGroup;
        public FLD_maplist _MapID;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestTalkDummyGroup
    {
        public int Id;
        public ushort NpcID1;
        public ushort NpcID2;
        public ushort NpcID3;
        public ushort NpcID4;
        public ushort NpcID5;
        public ushort NpcID6;
        public ushort NpcID7;
        public ushort NpcID8;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestTask
    {
        public int Id;
        public byte PreCondition;
        public byte TaskType1;
        public ushort TaskID1;
        public byte Branch1;
        public ushort TaskLog1;
        public byte TaskUI1;
        public ushort TaskCondition1;
        public byte TaskType2;
        public ushort TaskID2;
        public byte Branch2;
        public ushort TaskLog2;
        public byte TaskUI2;
        public ushort TaskCondition2;
        public byte TaskType3;
        public ushort TaskID3;
        public byte Branch3;
        public ushort TaskLog3;
        public byte TaskUI3;
        public ushort TaskCondition3;
        public byte TaskType4;
        public ushort TaskID4;
        public byte Branch4;
        public ushort TaskLog4;
        public byte TaskUI4;
        public ushort TaskCondition4;
        public FLD_ConditionList _TaskCondition1;
        public FLD_ConditionList _TaskCondition2;
        public FLD_ConditionList _TaskCondition3;
        public FLD_ConditionList _TaskCondition4;
        public object _TaskID1;
        public object _TaskID2;
        public object _TaskID3;
        public object _TaskID4;
        public Message _TaskLog1;
        public Message _TaskLog2;
        public Message _TaskLog3;
        public Message _TaskLog4;
        public TaskType _TaskType1;
        public TaskType _TaskType2;
        public TaskType _TaskType3;
        public TaskType _TaskType4;
    }

    [BdatType]
    [Serializable]
    public class FLD_QuestUse
    {
        public int Id;
        public ushort ItemID;
        public byte Category;
        public byte ItemNumber;
        public ushort PartyInPC;
        public ushort bladeID;
        public CHR_Bl _bladeID;
        public Message _Category;
        public object _ItemID;
    }

    [BdatType]
    [Serializable]
    public class FLD_randomTalk
    {
        public int Id;
        public sbyte type;
        public short talk0;
        public short text0;
        public sbyte target0;
        public short talk1;
        public short text1;
        public sbyte target1;
        public Message _text0;
        public Message _text1;
        public EVT_randtype _type;
    }

    [BdatType]
    [Serializable]
    public class FLD_RequestBlade
    {
        public int Id;
        public byte RequestCategory;
        public byte RequestAtr;
        public ushort RequestPerformance;
        public ushort RequestRace;
        public ushort RequestGender;
        public ushort RequestArts;
        public byte RequestArtsLevel;
        public ushort RequestFSkill;
        public byte RequestFSLevel;
        public byte RequestNumber;
    }

    [BdatType]
    [Serializable]
    public class FLD_RequestItemSet
    {
        public int Id;
        public ushort ItemID1;
        public byte Count1;
        public ushort ItemID2;
        public byte Count2;
        public ushort ItemID3;
        public byte Count3;
        public ushort ItemID4;
        public byte Count4;
        public ushort ItemID5;
        public byte Count5;
        public byte Count5_0;
        public ushort MapID;
        public ushort NpcID;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvageClimbLotTable
    {
        public int Id;
        public byte NoTBox;
        public byte TBox;
        public byte RTBox;
        public byte SRTBox;
        public byte Enemy;
        public byte REnemy;
        public string Voice1;
        public string Voice2;
        public string Voice3;
        public string Voice4;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvageEnemySet
    {
        public int Id;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte pop_act_type;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvageEvent
    {
        public int Id;
        public ushort EventID1;
        public byte Percent1;
        public ushort EventID2;
        public byte Percent2;
        public ushort EventID3;
        public byte Percent3;
        public ushort EventID4;
        public byte Percent4;
        public ushort EventID5;
        public byte Percent5;
        public ushort EventID6;
        public byte Percent6;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvageItemSet
    {
        public int Id;
        public ushort RSC_ID;
        public byte flag;
        public byte msgVisible;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort itm1ID;
        public byte itm1Num;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Num;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Num;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Num;
        public byte itm4Per;
        public ushort itm5ID;
        public byte itm5Num;
        public byte itm5Per;
        public ushort itm6ID;
        public byte itm6Num;
        public byte itm6Per;
        public ushort itm7ID;
        public byte itm7Num;
        public byte itm7Per;
        public ushort itm8ID;
        public byte itm8Num;
        public byte itm8Per;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public byte rsc_paramID;
        public bool accessAngle;
        public object _itm1ID;
        public object _itm2ID;
        public object _itm3ID;
        public object _itm4ID;
        public object _itm5ID;
        public object _itm6ID;
        public object _itm7ID;
        public object _itm8ID;
        public RSC_TboxList _RSC_ID;
        public object[] _itmID;
        public byte[] _itmNum;
        public byte[] _itmPer;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvagePointList
    {
        public int Id;
        public string name;
        public ushort SalvagePointName;
        public ushort Condition;
        public ushort BtnChallenge0;
        public ushort BtnChallenge1;
        public ushort BtnChallenge2;
        public ushort StartEventID;
        public ushort SpecialItem;
        public ushort SpecialEventID;
        public ushort SalvageTable1;
        public ushort SalvageTable2;
        public ushort SalvageTable3;
        public ushort SalvageTable4;
        public ushort SalvageTable5;
        public ushort menuMapImage;
        public MNU_BtnChallenge2 _BtnChallenge0;
        public MNU_BtnChallenge2 _BtnChallenge1;
        public MNU_BtnChallenge2 _BtnChallenge2;
        public FLD_ConditionList _Condition;
        public Message _SalvagePointName;
        public FLD_SalvageTable _SalvageTable1;
        public FLD_SalvageTable _SalvageTable2;
        public FLD_SalvageTable _SalvageTable3;
        public FLD_SalvageTable _SalvageTable4;
        public FLD_SalvageTable _SalvageTable5;
        public object _SpecialItem;
        public MNU_BtnChallenge2[] _BtnChallenge;
        public FLD_SalvageTable[] _SalvageTable;
    }

    [BdatType]
    [Serializable]
    public class FLD_SalvageTable
    {
        public int Id;
        public ushort ColleTable1;
        public ushort ColleTablePercent1;
        public ushort ColleTable2;
        public ushort ColleTablePercent2;
        public ushort ColleTable3;
        public ushort ColleTablePercent3;
        public ushort TresureBoxHit;
        public ushort TresureTable1;
        public ushort TresureTablePercent1;
        public ushort TresureTable2;
        public ushort TresureTablePercent2;
        public ushort TresureTable3;
        public ushort TresureTablePercent3;
        public byte EnemyLotteries;
        public ushort EnemyPopHit;
        public ushort EnemyPopTable1;
        public ushort EnemyPopTablePercent1;
        public ushort EnemyPopTable2;
        public ushort EnemyPopTablePercent2;
        public ushort EnemyPopTable3;
        public ushort EnemyPopTablePercent3;
        public FLD_SalvageItemSet _ColleTable1;
        public FLD_SalvageItemSet _ColleTable2;
        public FLD_SalvageItemSet _ColleTable3;
        public FLD_SalvageEnemySet _EnemyPopTable1;
        public FLD_SalvageEnemySet _EnemyPopTable2;
        public FLD_SalvageEnemySet _EnemyPopTable3;
        public FLD_SalvageItemSet _TresureTable1;
        public FLD_SalvageItemSet _TresureTable2;
        public FLD_SalvageItemSet _TresureTable3;
        public FLD_SalvageItemSet[] _ColleTable;
        public ushort[] _ColleTablePercent;
        public FLD_SalvageItemSet[] _TresureTable;
        public ushort[] _TresureTablePercent;
        public FLD_SalvageEnemySet[] _EnemyPopTable;
        public ushort[] _EnemyPopTablePercent;
    }

    [BdatType]
    [Serializable]
    public class FLD_SealedStone
    {
        public int Id;
        public string name;
        public ushort RSC_ID;
        public string FeedbackEffectName;
        public string FinishEffectName;
        public float FinishWaitTime;
        public string StateName;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public byte Priority;
        public float EffectScale;
        public float EffectOffsetX;
        public float EffectOffsetY;
        public float EffectOffsetZ;
    }

    [BdatType]
    [Serializable]
    public class FLD_SePop
    {
        public int Id;
        public string name;
        public byte flag;
        public ushort seName;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public ushort SEpopTime;
        public byte wtrSEType;
        public byte gimmickType;
        public ushort gimmickID;
        public byte OP_gimmickType;
        public ushort OP_gimmickID;
        public byte volumeMAX;
        public byte volumeMIN;
        public byte InRoom_volume;
        public bool se_type;
        public bool play_once;
        public FLD_ConditionList _Condition;
        public TimeRange _SEpopTime;
    }

    [BdatType]
    [Serializable]
    public class FLD_TimeInfo
    {
        public int Id;
        public ushort msg;
        public Message _msg;
    }

    [BdatType]
    [Serializable]
    public class FLD_Tutorial
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public byte SysMultiFlag;
    }

    [BdatType]
    [Serializable]
    public class FLD_UniquePreset
    {
        public int Id;
        public ushort Frequency;
        public ushort Chara0;
        public byte Motion0;
        public float Delay0;
        public ushort Chara1;
        public byte Motion1;
        public float Delay1;
        public ushort Chara2;
        public byte Motion2;
        public float Delay2;
        public ushort Chara3;
        public byte Motion3;
        public float Delay3;
        public ushort Chara4;
        public byte Motion4;
        public float Delay4;
        public ushort Chara5;
        public byte Motion5;
        public float Delay5;
    }

    [BdatType]
    [Serializable]
    public class FLD_UniqueTable
    {
        public int Id;
        public ushort RefID;
        public ushort Probability;
        public float DelayMin;
        public float DelayMax;
        public ushort FrequencyA;
        public ushort FrequencyB;
        public ushort FrequencyC;
    }

    [BdatType]
    [Serializable]
    public class FLD_VoiceTable
    {
        public int Id;
        public string Driver1;
        public string Driver2;
        public string Driver3;
        public string Driver4;
        public string Driver5;
        public string Driver6;
    }

    [BdatType]
    [Serializable]
    public class FLD_VoiceTableBlade
    {
        public int Id;
        public string Blade1;
        public string Blade2;
        public string Blade3;
        public string Blade4;
        public string Blade5;
        public string Blade6;
        public string Blade7;
        public string Blade8;
        public string Blade9;
        public string Blade10;
        public string Blade11;
    }

    [BdatType]
    [Serializable]
    public class FLD_VoiceTableCommon
    {
        public int Id;
        public string CommonBlade1;
        public string CommonBlade2;
        public string CommonBlade3;
        public string CommonBlade4;
        public string CommonBlade5;
        public string CommonBlade6;
        public string CommonBlade7;
        public string CommonBlade8;
        public string CommonBlade9;
        public string CommonBlade10;
        public string CommonBlade11;
        public string CommonBlade12;
        public string CommonBlade13;
        public string CommonBlade14;
        public string CommonBlade15;
        public string CommonBlade16;
        public string CommonBlade17;
        public string CommonBlade18;
        public string CommonBlade19;
        public string CommonBlade20;
        public string CommonBlade21;
        public string CommonBlade22;
        public string CommonBlade23;
        public string CommonBlade24;
        public string CommonBlade25;
        public string CommonBlade26;
        public string CommonBlade27;
        public string CommonBlade28;
        public string CommonBlade29;
        public string CommonBlade30;
        public string CommonBlade31;
        public string CommonBlade32;
    }

    [BdatType]
    [Serializable]
    public class FLD_VoiceTableRare
    {
        public int Id;
        public string RareBlade1;
        public string RareBlade2;
        public string RareBlade3;
        public string RareBlade4;
        public string RareBlade5;
        public string RareBlade6;
        public string RareBlade7;
        public string RareBlade8;
        public string RareBlade9;
        public string RareBlade10;
        public string RareBlade11;
        public string RareBlade12;
        public string RareBlade13;
        public string RareBlade14;
        public string RareBlade15;
        public string RareBlade16;
        public string RareBlade17;
        public string RareBlade18;
        public string RareBlade19;
        public string RareBlade20;
        public string RareBlade21;
        public string RareBlade22;
        public string RareBlade23;
        public string RareBlade24;
        public string RareBlade25;
        public string RareBlade26;
        public string RareBlade27;
        public string RareBlade28;
        public string RareBlade29;
        public string RareBlade30;
        public string RareBlade31;
        public string RareBlade32;
        public string RareBlade33;
        public string RareBlade34;
        public string RareBlade35;
        public string RareBlade36;
        public string RareBlade37;
        public string RareBlade38;
        public string RareBlade39;
        public string RareBlade40;
        public string RareBlade41;
        public string RareBlade42;
        public string RareBlade43;
    }

    [BdatType]
    [Serializable]
    public class FLD_WarpGimmick
    {
        public int Id;
        public string name;
        public ushort Condition;
        public byte gimmickType;
        public ushort gimmickID;
        public ushort FSID;
        public ushort tgtMSG_ID;
        public ushort nameRadius;
        public ushort offsetID;
        public float fadeIN_Time;
        public float fadeOUT_Time;
        public short warp_nextwait;
        public ushort menuMapImage;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
    }

    [BdatType]
    [Serializable]
    public class FLD_WeatherInfo
    {
        public int Id;
        public ushort msg;
        public string eff;
        public string snd;
        public string sndBegin;
        public Message _msg;
    }

    [BdatType]
    [Serializable]
    public class FLD_wildcardData
    {
        public int Id;
        public float valueF4;
        public ushort valueU2;
    }

    [BdatType]
    [Serializable]
    public class Fx_Act_Surface_Table
    {
        public int Id;
        public byte SolidDefault;
        public byte SolidWater;
        public byte SolidSoil;
        public byte SolidSand;
        public byte SolidGrass;
        public byte SolidWood;
        public byte SolidIron;
        public byte SolidWiremesh;
        public byte SolidSnow;
        public byte SolidCarpet;
        public byte SolidGel;
        public byte SolidCloud;
        public byte SolidIce;
        public byte FxSolidLuminescence;
        public byte FxSolidSpore;
        public byte FxSolidCloud;
        public byte LiquidWater;
        public byte LiquidCloud;
        public byte FxLiquidLuminescence;
    }

    [BdatType]
    [Serializable]
    public class Fx_FileName
    {
        public int Id;
        public string file_name;
    }

    [BdatType]
    [Serializable]
    public class Fx_Surface_Chara_Table
    {
        public int Id;
        public byte TYPE_HUMAN;
        public byte TYPE_HUMAN_HEELS;
        public byte TYPE_HUMAN_GETA;
        public byte TYPE_NOPON;
        public byte TYPE_HUGE;
        public byte TYPE_FOUR_FOOTED;
        public byte TYPE_ENEMY_M;
        public byte TYPE_ENEMY_L;
    }

    [BdatType]
    [Serializable]
    public class IRA_Party
    {
        public int Id;
        public ushort driver11;
        public ushort blade11;
        public ushort blade12;
        public ushort driver21;
        public ushort blade21;
        public ushort blade22;
        public ushort driver31;
        public ushort blade31;
        public ushort blade32;
        public byte Guest1;
        public byte Guest2;
        public byte Guest3;
        public CHR_Dr _blade11;
        public CHR_Dr _blade12;
        public CHR_Dr _blade21;
        public CHR_Dr _blade22;
        public CHR_Dr _blade31;
        public CHR_Dr _blade32;
        public CHR_Dr _driver11;
        public CHR_Dr _driver21;
        public CHR_Dr _driver31;
    }

    [BdatType]
    [Serializable]
    public class ITM_BoosterList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Category;
        public sbyte Idea;
        public byte Rarity;
        public uint Price;
        public byte ValueMax;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Category;
        public Message _Name;
        public Message _Rarity;
    }

    [BdatType]
    [Serializable]
    public class ITM_CollectionList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Category;
        public ushort Zone;
        public byte Rarity;
        public uint Price;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Category;
        public Message _Name;
        public Message _Rarity;
        public FLD_maplist _Zone;
    }

    [BdatType]
    [Serializable]
    public class ITM_CrystalList
    {
        public int Id;
        public ushort Name;
        public byte Rarity;
        public uint Price;
        public ushort Condition;
        public ushort NoMultiple;
        public byte ValueMax;
        public byte RareTableProb;
        public ushort RareBladeRev;
        public byte CommonPow;
        public ushort AssureP;
        public ushort BladeID;
        public ushort CommonID;
        public byte CommonWpn;
        public byte CommonAtr;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public CHR_Bl _BladeID;
        public MNU_Name _CommonAtr;
        public ITM_PcWpnType _CommonWpn;
        public FLD_ConditionList _Condition;
        public Message _Name;
        public Message _Rarity;
    }

    [BdatType]
    [Serializable]
    public class ITM_EtherCrystal
    {
        public int Id;
        public ushort Score;
    }

    [BdatType]
    [Serializable]
    public class ITM_EventList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Caption;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class ITM_FavoriteList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Category;
        public ushort Zone;
        public byte Rarity;
        public uint Price;
        public ushort Type;
        public ushort Time;
        public byte ValueMax;
        public ushort TrustPoint;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Category;
        public Message _Name;
        public Message _Rarity;
        public BTL_PouchBuffSet _Type;
        public FLD_maplist _Zone;
    }

    [BdatType]
    [Serializable]
    public class ITM_HanaArtsEnh
    {
        public int Id;
        public ushort Name;
        public ushort Enhance;
        public byte Flag;
        public ushort NeedPow;
        public uint NeedEther;
        public uint DustEther;
        public ushort Condition;
        public string UI;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool JS;
        public bool JK;
        public bool JD;
        public FLD_ConditionList _Condition;
        public BTL_Enhance _Enhance;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class ITM_HanaAssist
    {
        public int Id;
        public ushort Name;
        public ushort Enhance;
        public byte EnhanceCategory;
        public byte Flag;
        public ushort NeedPow;
        public uint NeedEther;
        public uint DustEther;
        public ushort Condition;
        public string UI;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool JS;
        public bool JK;
        public bool JD;
        public FLD_ConditionList _Condition;
        public BTL_Enhance _Enhance;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class ITM_HanaAtr
    {
        public int Id;
        public byte Name;
        public byte Caption;
        public byte Atr;
        public byte Flag;
        public ushort NeedPow;
        public uint NeedEther;
        public uint DustEther;
        public ushort Condition;
        public string UI;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool JS;
        public bool JK;
        public bool JD;
        public MNU_Name _Atr;
        public Message _Caption;
        public FLD_ConditionList _Condition;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class ITM_HanaNArtsSet
    {
        public int Id;
        public byte Name;
        public byte NArts;
        public byte NArtsRecastRev;
        public byte Flag;
        public ushort NeedPow;
        public uint NeedEther;
        public uint DustEther;
        public ushort Condition;
        public string UI;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool JS;
        public bool JK;
        public bool JD;
        public FLD_ConditionList _Condition;
        public Message _Name;
        public BTL_Buff _NArts;
    }

    [BdatType]
    [Serializable]
    public class ITM_HanaRole
    {
        public int Id;
        public byte Name;
        public byte Role;
        public byte PArmor;
        public byte EArmor;
        public byte HpMaxRev;
        public byte StrengthRev;
        public byte PowEtherRev;
        public byte DexRev;
        public byte AgilityRev;
        public byte LuckRev;
        public sbyte AutoHate;
        public sbyte ArtsHate;
        public byte Flag;
        public ushort NeedPow;
        public uint NeedEther;
        public uint DustEther;
        public ushort Condition;
        public string UI;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool JS;
        public bool JK;
        public bool JD;
        public FLD_ConditionList _Condition;
        public Message _Name;
        public Message _Role;
    }

    [BdatType]
    [Serializable]
    public class ITM_InfoList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public uint Price;
        public byte ClearNewGame;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Caption;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class ITM_Orb
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Recipe;
        public ushort EquipItemID;
        public uint Price;
        public byte Rarity;
        public byte Flag;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool NoSell;
        public object _EquipItemID;
        public Message _Name;
        public Message _Rarity;
        public ITM_OrbRecipe _Recipe;
    }

    [BdatType]
    [Serializable]
    public class ITM_OrbEquip
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public ushort Enhance;
        public byte EnhanceCategory;
        public uint Price;
        public byte Rarity;
        public byte Flag;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool NoSell;
        public BTL_Enhance _Enhance;
        public Message _Name;
        public Message _Rarity;
    }

    [BdatType]
    [Serializable]
    public class ITM_OrbRecipe
    {
        public int Id;
        public byte RecipeType;
        public byte Rarity;
        public byte RscCat;
        public ushort AssortNumber;
        public ushort ItemID1;
        public ushort ItemNumber1;
        public ushort ItemID2;
        public ushort ItemNumber2;
        public ushort ItemID3;
        public ushort ItemNumber3;
        public ushort ItemID4;
        public ushort ItemNumber4;
        public ushort ItemID5;
        public ushort ItemNumber5;
        public ushort ItemID6;
        public ushort ItemNumber6;
        public ushort ItemID7;
        public ushort ItemNumber7;
        public ushort ItemID8;
        public ushort ItemNumber8;
        public object _ItemID1;
        public object _ItemID2;
        public object _ItemID3;
        public object _ItemID4;
        public object _ItemID5;
        public object _ItemID6;
        public object _ItemID7;
        public object _ItemID8;
        public Message _Rarity;
        public RecipeType _RecipeType;
        public Message _RscCat;
    }

    [BdatType]
    [Serializable]
    public class ITM_PcEquip
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte ArmorType;
        public ushort Enhance1;
        public byte AddAtr;
        public uint Price;
        public byte Rarity;
        public ushort Flag;
        public ushort PArmor;
        public ushort EArmor;
        public ushort Bns_HpMax;
        public ushort Bns_Strength;
        public ushort Bns_PowEther;
        public ushort Bns_Dex;
        public ushort Bns_Agility;
        public ushort Bns_Luck;
        public ushort Enhance2;
        public byte Icon;
        public ushort Zone;
        public ushort Zone2;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool NoSell;
        public bool EqPC01;
        public bool EqPC02;
        public bool EqPC03;
        public bool EqPC04;
        public bool EqPC05;
        public bool EqPC06;
        public bool EqPC07;
        public bool EqPC08;
        public bool EqPC09;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public Message _Name;
        public Message _Rarity;
        public FLD_maplist _Zone;
        public FLD_maplist _Zone2;
    }

    [BdatType]
    [Serializable]
    public class ITM_PcWpn
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte Rank;
        public byte Flag;
        public ushort RscR;
        public ushort RscL;
        public byte TypeRange;
        public byte WpnType;
        public ushort Damage;
        public byte Stability;
        public byte CriRate;
        public byte GuardRate;
        public ushort Enhance1;
        public ushort PArmor;
        public ushort EArmor;
        public ushort Enhance2;
        public bool Private;
        public BTL_Enhance _Enhance1;
        public BTL_Enhance _Enhance2;
        public Message _Name;
        public RSC_PcWpn _RscL;
        public RSC_PcWpn _RscR;
        public ITM_PcWpnType _WpnType;
    }

    [BdatType]
    [Serializable]
    public class ITM_PcWpnChip
    {
        public int Id;
        public ushort Name;
        public string DebugName;
        public byte Rank;
        public ushort CreateWpn1;
        public ushort CreateWpn2;
        public ushort CreateWpn3;
        public ushort CreateWpn4;
        public ushort CreateWpn5;
        public ushort CreateWpn6;
        public ushort CreateWpn7;
        public ushort CreateWpn8;
        public ushort CreateWpn9;
        public ushort CreateWpn10;
        public ushort CreateWpn11;
        public ushort CreateWpn12;
        public ushort CreateWpn13;
        public ushort CreateWpn14;
        public ushort CreateWpn15;
        public ushort CreateWpn16;
        public ushort CreateWpn17;
        public ushort CreateWpn18;
        public ushort CreateWpn19;
        public ushort CreateWpn20;
        public ushort CreateWpn21;
        public ushort CreateWpn22;
        public ushort CreateWpn23;
        public ushort CreateWpn24;
        public ushort CreateWpn25;
        public ushort CreateWpn26;
        public ushort CreateWpn27;
        public ushort CreateWpn28;
        public ushort CreateWpn29;
        public ushort CreateWpn30;
        public ushort CreateWpn31;
        public ushort CreateWpn32;
        public ushort CreateWpn33;
        public ushort CreateWpn34;
        public uint Price;
        public byte Rarity;
        public byte Flag;
        public ushort Zone;
        public ushort Zone2;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public bool NoSell;
        public ITM_PcWpn _CreateWpn1;
        public ITM_PcWpn _CreateWpn10;
        public ITM_PcWpn _CreateWpn11;
        public ITM_PcWpn _CreateWpn12;
        public ITM_PcWpn _CreateWpn13;
        public ITM_PcWpn _CreateWpn14;
        public ITM_PcWpn _CreateWpn15;
        public ITM_PcWpn _CreateWpn16;
        public ITM_PcWpn _CreateWpn17;
        public ITM_PcWpn _CreateWpn18;
        public ITM_PcWpn _CreateWpn19;
        public ITM_PcWpn _CreateWpn2;
        public ITM_PcWpn _CreateWpn20;
        public ITM_PcWpn _CreateWpn21;
        public ITM_PcWpn _CreateWpn22;
        public ITM_PcWpn _CreateWpn23;
        public ITM_PcWpn _CreateWpn24;
        public ITM_PcWpn _CreateWpn25;
        public ITM_PcWpn _CreateWpn26;
        public ITM_PcWpn _CreateWpn27;
        public ITM_PcWpn _CreateWpn28;
        public ITM_PcWpn _CreateWpn29;
        public ITM_PcWpn _CreateWpn3;
        public ITM_PcWpn _CreateWpn30;
        public ITM_PcWpn _CreateWpn31;
        public ITM_PcWpn _CreateWpn32;
        public ITM_PcWpn _CreateWpn33;
        public ITM_PcWpn _CreateWpn34;
        public ITM_PcWpn _CreateWpn4;
        public ITM_PcWpn _CreateWpn5;
        public ITM_PcWpn _CreateWpn6;
        public ITM_PcWpn _CreateWpn7;
        public ITM_PcWpn _CreateWpn8;
        public ITM_PcWpn _CreateWpn9;
        public Message _Name;
        public Message _Rarity;
        public FLD_maplist _Zone;
        public FLD_maplist _Zone2;
        public ITM_PcWpn[] _CreateWpn;
        public FLD_maplist[] _Zones;
    }

    [BdatType]
    [Serializable]
    public class ITM_PcWpnIr
    {
        public int Id;
        public ushort AtkLv1;
        public ushort AtkLv99;
        public byte StbLv1;
        public byte StbLv99;
        public byte CriRateLv1;
        public byte CriRateLv99;
        public byte GuardRateLv1;
        public byte GuardRateLv99;
    }

    [BdatType]
    [Serializable]
    public class ITM_PcWpnType
    {
        public int Id;
        public ushort Name;
        public byte Role;
        public byte EffType;
        public byte JustRange;
        public byte JustRange2;
        public byte VoiceType;
        public byte Motion;
        public ITM_PcWpnType _Motion;
        public Message _Name;
        public Message _Role;
    }

    [BdatType]
    [Serializable]
    public class ITM_PreciousList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Category;
        public ushort Type;
        public uint Price;
        public byte ValueMax;
        public byte ClearNewGame;
        public ushort NoMultiple;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Caption;
        public Message _Name;
        public FLD_OwnerBonus _Type;
    }

    [BdatType]
    [Serializable]
    public class ITM_SalvageList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Rarity;
        public uint Price;
        public byte Quest;
        public byte NoSell;
        public byte Protect;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Caption;
        public Message _Name;
        public Message _Rarity;
    }

    [BdatType]
    [Serializable]
    public class ITM_TresureList
    {
        public int Id;
        public ushort Name;
        public ushort Caption;
        public byte Category;
        public ushort Graphic;
        public ushort Zone;
        public byte Rarity;
        public uint Price;
        public ushort Flag;
        public ushort NoMultiple;
        public byte ClearNewGame;
        public uint sortJP;
        public uint sortGE;
        public uint sortFR;
        public uint sortSP;
        public uint sortIT;
        public uint sortGB;
        public uint sortCN;
        public uint sortTW;
        public Message _Name;
        public Message _Rarity;
        public FLD_maplist _Zone;
    }

    [BdatType]
    [Serializable]
    public class LabeledMessage
    {
        public int Id;
        public string label;
        public ushort style;
        public string name;
    }

    [BdatType]
    [Serializable]
    public class ma01a_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public byte ene_disp_r;
        public byte ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma01a_FLD_LandmarkPop
    {
        public int Id;
        public string name;
        public ushort MSGID;
        public byte category;
        public ushort cndID;
        public ushort getEXP;
        public ushort getSP;
        public byte developZone;
        public ushort get_DPT;
        public ushort MAPJUMPID;
        public ushort stoff_cndID;
        public byte flag;
        public bool noTelop;
        public LandmarkType _category;
        public FLD_ConditionList _cndID;
        public SYS_MapJumpEvList _MAPJUMPID;
        public Message _MSGID;
        public FLD_ConditionList _stoff_cndID;
    }

    [BdatType]
    [Serializable]
    public class ma01a_FLD_MapObjPop
    {
        public int Id;
        public string name;
        public ushort Condition;
        public ushort RSC_ID;
        public string StateName;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public byte Priority;
        public byte flag;
        public bool mapobjcol;
        public FLD_ConditionList _Condition;
        public RSC_MapObjList _RSC_ID;
    }

    [BdatType]
    [Serializable]
    public class ma01a_FLD_NpcPop
    {
        public int Id;
        public string name;
        public ushort NpcID;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Group;
        public ushort Mot;
        public ushort MountPoint;
        public ushort MountObject;
        public ushort MountPoint2;
        public ushort MountObject2;
        public byte flag;
        public ushort EventID;
        public byte NpcTurn;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort QuestID;
        public ushort ShopID;
        public ushort CloseRange;
        public ushort MoveSpeed;
        public ushort ReactionRange;
        public ushort ReactionPercent;
        public ushort ReactionMot;
        public ushort BattleReaction;
        public ushort BattleMot;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public ushort FSID1;
        public ushort FSID2;
        public ushort FSID3;
        public bool Talkable;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID1;
        public FLD_FieldSkillSetting _FSID2;
        public FLD_FieldSkillSetting _FSID3;
        public FLD_NpcGroupId _Group;
        public FLD_NpcMobMotionId _Mot;
        public RSC_NpcList _NpcID;
        public MNU_ShopList _ShopID;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_AutoTalk
    {
        public int Id;
        public ushort MOBID;
        public ushort Range;
        public ushort Condition;
        public ushort Text;
        public ushort Ontime;
        public ushort BeforeID;
        public ma02a_FLD_AutoTalk _BeforeID;
        public FLD_ConditionList _Condition;
        public object _MOBID;
        public Message _Text;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_CollectionPopList
    {
        public int Id;
        public string name;
        public ushort gimmickID;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort FSID;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public ushort itm1ID;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Per;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort nameRadius;
        public byte rsc_paramID;
        public float initWaitTime;
        public float initWaitTimeRand;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillList _FSID;
        public ITM_CollectionList _itm1ID;
        public ITM_CollectionList _itm2ID;
        public ITM_CollectionList _itm3ID;
        public ITM_CollectionList _itm4ID;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_EventPop
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public ushort EventID;
        public ushort Icon;
        public ushort Name;
        public ushort UIOffset;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_LandmarkPop
    {
        public int Id;
        public string name;
        public ushort MSGID;
        public byte category;
        public ushort cndID;
        public ushort getEXP;
        public ushort getSP;
        public byte developZone;
        public ushort get_DPT;
        public ushort MAPJUMPID;
        public ushort stoff_cndID;
        public ushort menuGroup;
        public ushort menuMapImage;
        public ushort menuPriority;
        public short menu_transX;
        public short menu_transY;
        public byte flag;
        public bool noTelop;
        public LandmarkType _category;
        public FLD_ConditionList _cndID;
        public SYS_MapJumpEvList _MAPJUMPID;
        public MNU_MapGroup _menuGroup;
        public Message _MSGID;
        public FLD_ConditionList _stoff_cndID;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_MobPop
    {
        public int Id;
        public string name;
        public ushort MobID;
        public ushort MOBGroupID;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Group;
        public ushort Mot;
        public ushort MountPoint;
        public ushort MountObject;
        public ushort MountPoint2;
        public ushort MountObject2;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort ReactionRange;
        public ushort ReactionPercent;
        public ushort ReactionMot;
        public byte ScaleMin;
        public byte ScaleMax;
        public byte PopMin;
        public byte PopMax;
        public byte MotSpeedMin;
        public byte MotSpeedMax;
        public ushort BattleReaction;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public ushort squadId;
        public FLD_ConditionList _Condition;
        public FLD_NpcGroupId _Group;
        public FLD_MobGroupList _MOBGroupID;
        public RSC_MobList _MobID;
        public FLD_NpcMobMotionId _Mot;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class ma02a_FLD_TboxPop
    {
        public int Id;
        public string name;
        public ushort RSC_ID;
        public ushort Condition;
        public ushort FSID;
        public ushort FSID2;
        public byte flag;
        public byte msgVisible;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort itm1ID;
        public byte itm1Num;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Num;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Num;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Num;
        public byte itm4Per;
        public ushort itm5ID;
        public byte itm5Num;
        public byte itm5Per;
        public ushort itm6ID;
        public byte itm6Num;
        public byte itm6Per;
        public ushort itm7ID;
        public byte itm7Num;
        public byte itm7Per;
        public ushort itm8ID;
        public byte itm8Num;
        public byte itm8Per;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public byte rsc_paramID;
        public byte msgdigVisible;
        public ushort menuMapImage;
        public bool Digflg;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
        public FLD_FieldSkillSetting _FSID2;
        public object _itm1ID;
        public object _itm2ID;
        public object _itm3ID;
        public object _itm4ID;
        public object _itm5ID;
        public object _itm6ID;
        public object _itm7ID;
        public object _itm8ID;
        public RSC_TboxList _RSC_ID;
    }

    [BdatType]
    [Serializable]
    public class ma03a_FLD_TboxPop
    {
        public int Id;
        public string name;
        public ushort RSC_ID;
        public ushort Condition;
        public ushort FSID;
        public ushort FSID2;
        public byte flag;
        public byte msgVisible;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort itm1ID;
        public byte itm1Num;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Num;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Num;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Num;
        public byte itm4Per;
        public ushort itm5ID;
        public byte itm5Num;
        public byte itm5Per;
        public ushort itm6ID;
        public byte itm6Num;
        public byte itm6Per;
        public ushort itm7ID;
        public byte itm7Num;
        public byte itm7Per;
        public ushort itm8ID;
        public byte itm8Num;
        public byte itm8Per;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public byte rsc_paramID;
        public byte msgdigVisible;
        public bool Digflg;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
        public FLD_FieldSkillSetting _FSID2;
        public object _itm1ID;
        public object _itm2ID;
        public object _itm3ID;
        public object _itm4ID;
        public object _itm5ID;
        public object _itm6ID;
        public object _itm7ID;
        public object _itm8ID;
        public RSC_TboxList _RSC_ID;
    }

    [BdatType]
    [Serializable]
    public class ma04a_FLD_PreciousPopList
    {
        public int Id;
        public string name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort itmID;
        public ushort QuestID;
        public FLD_ConditionList _Condition;
        public ITM_PreciousList _itmID;
    }

    [BdatType]
    [Serializable]
    public class ma05a_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public byte ene_disp_r;
        public byte ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public bool noNaviMesh;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma05a_FLD_LandmarkPop
    {
        public int Id;
        public string name;
        public ushort MSGID;
        public byte category;
        public ushort cndID;
        public ushort getEXP;
        public ushort getSP;
        public byte developZone;
        public ushort get_DPT;
        public ushort MAPJUMPID;
        public ushort menuGroup;
        public ushort menuMapImage;
        public ushort stoff_cndID;
        public ushort menuPriority;
        public short menu_transX;
        public short menu_transY;
        public byte flag;
        public bool noTelop;
        public LandmarkType _category;
        public FLD_ConditionList _cndID;
        public SYS_MapJumpEvList _MAPJUMPID;
        public MNU_MapGroup _menuGroup;
        public Message _MSGID;
        public FLD_ConditionList _stoff_cndID;
    }

    [BdatType]
    [Serializable]
    public class ma05a_FLD_NpcPop
    {
        public int Id;
        public string name;
        public ushort NpcID;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Group;
        public ushort Mot;
        public ushort MountPoint;
        public ushort MountObject;
        public ushort MountPoint2;
        public ushort MountObject2;
        public byte flag;
        public ushort EventID;
        public byte NpcTurn;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort QuestID;
        public ushort ShopID;
        public ushort CloseRange;
        public ushort MoveSpeed;
        public ushort ReactionRange;
        public ushort ReactionPercent;
        public ushort ReactionMot;
        public ushort BattleReaction;
        public ushort BattleMot;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public ushort FSID1;
        public ushort FSID2;
        public ushort FSID3;
        public ushort FSID4;
        public ushort FSID5;
        public bool Talkable;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID1;
        public FLD_FieldSkillSetting _FSID2;
        public FLD_FieldSkillSetting _FSID3;
        public FLD_FieldSkillSetting _FSID4;
        public FLD_FieldSkillSetting _FSID5;
        public FLD_NpcGroupId _Group;
        public FLD_NpcMobMotionId _Mot;
        public RSC_NpcList _NpcID;
        public MNU_ShopList _ShopID;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class ma05c_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public byte ene_disp_r;
        public byte ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public byte Wpop_Priority;
        public ushort Wpop_TimerCond;
        public byte Wpop_PopNumCond;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma07a_FLD_CollectionPopList
    {
        public int Id;
        public string name;
        public ushort gimmickID;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort FSID;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public ushort itm1ID;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Per;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort nameRadius;
        public byte rsc_paramID;
        public float initWaitTime;
        public float initWaitTimeRand;
        public ushort menuMapImage;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillList _FSID;
        public ITM_CollectionList _itm1ID;
        public ITM_CollectionList _itm2ID;
        public ITM_CollectionList _itm3ID;
        public ITM_CollectionList _itm4ID;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma07a_FLD_EventPop
    {
        public int Id;
        public string name;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort Condition;
        public ushort EventID;
        public ushort Icon;
        public ushort Name;
        public ushort UIOffset;
        public ushort menuMapImage;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class ma07a_FLD_NpcPop
    {
        public int Id;
        public string name;
        public ushort NpcID;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Group;
        public ushort Mot;
        public ushort MountPoint;
        public ushort MountObject;
        public ushort MountPoint2;
        public ushort MountObject2;
        public byte flag;
        public ushort EventID;
        public byte NpcTurn;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort QuestID;
        public ushort ShopID;
        public ushort CloseRange;
        public ushort MoveSpeed;
        public ushort ReactionRange;
        public ushort ReactionPercent;
        public ushort ReactionMot;
        public ushort BattleReaction;
        public ushort BattleMot;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public ushort FSID1;
        public ushort FSID2;
        public ushort FSID3;
        public ushort menuMapImage;
        public bool Talkable;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID1;
        public FLD_FieldSkillSetting _FSID2;
        public FLD_FieldSkillSetting _FSID3;
        public FLD_NpcGroupId _Group;
        public FLD_NpcMobMotionId _Mot;
        public RSC_NpcList _NpcID;
        public MNU_ShopList _ShopID;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class ma08a_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public ushort ene_disp_r;
        public ushort ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma10a_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public ushort ene_disp_r;
        public byte ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public bool noNaviMesh;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma20a_FLD_EnemyPop
    {
        public int Id;
        public string name;
        public ushort tagetpoint_name;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort ene1ID;
        public sbyte ene1Lv;
        public byte ene1Per;
        public byte ene1num;
        public byte ene1move;
        public ushort ene2ID;
        public sbyte ene2Lv;
        public byte ene2Per;
        public byte ene2num;
        public byte ene2move;
        public ushort ene3ID;
        public sbyte ene3Lv;
        public byte ene3Per;
        public byte ene3num;
        public byte ene3move;
        public ushort ene4ID;
        public sbyte ene4Lv;
        public byte ene4Per;
        public byte ene4num;
        public byte ene4move;
        public byte party_flag;
        public byte flag;
        public byte pop_act_type;
        public byte form_range;
        public ushort squadId;
        public ushort squadScale;
        public ushort ene_disp_r;
        public ushort ene_disp_h;
        public ushort battlelockname;
        public ushort muteki_QuestFlag;
        public byte muteki_QuestFlagMin;
        public byte muteki_QuestFlagMax;
        public ushort muteki_Condition;
        public bool ene_priority;
        public bool pop_smn;
        public bool popCloud;
        public bool noNaviMesh;
        public FLD_ConditionList _Condition;
        public CHR_EnArrange _ene1ID;
        public CHR_EnArrange _ene2ID;
        public CHR_EnArrange _ene3ID;
        public CHR_EnArrange _ene4ID;
        public FLD_ConditionList _muteki_Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma40a_FLD_CollectionPopList
    {
        public int Id;
        public string name;
        public ushort gimmickID;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort CollectionTable;
        public ushort nameRadius;
        public float initWaitTime;
        public float initWaitTimeRand;
        public byte rarity;
        public FLD_ConditionList _Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class ma40a_FLD_MobPop
    {
        public int Id;
        public string name;
        public ushort MobID;
        public ushort MOBGroupID;
        public ushort ScenarioFlagMin;
        public ushort ScenarioFlagMax;
        public ushort QuestFlag;
        public byte QuestFlagMin;
        public byte QuestFlagMax;
        public ushort TimeRange;
        public ushort Condition;
        public ushort Group;
        public ushort Mot;
        public ushort MountPoint;
        public ushort MountObject;
        public ushort MountPoint2;
        public ushort MountObject2;
        public byte LookAt;
        public ushort LookAtRange;
        public ushort ReactionRange;
        public ushort ReactionPercent;
        public ushort ReactionMot;
        public byte ScaleMin;
        public byte ScaleMax;
        public byte PopMin;
        public byte PopMax;
        public byte MotSpeedMin;
        public byte MotSpeedMax;
        public ushort BattleReaction;
        public ushort Visible_XZ;
        public ushort Visible_Y;
        public ushort Invisible_XZ;
        public ushort Invisible_Y;
        public ushort squadId;
        public ushort CloseRange;
        public FLD_ConditionList _Condition;
        public FLD_NpcGroupId _Group;
        public FLD_MobGroupList _MOBGroupID;
        public RSC_MobList _MobID;
        public FLD_NpcMobMotionId _Mot;
        public TimeRange _TimeRange;
    }

    [BdatType]
    [Serializable]
    public class ma40a_FLD_TboxPop
    {
        public int Id;
        public string name;
        public ushort RSC_ID;
        public ushort Condition;
        public ushort FSID;
        public ushort FSID2;
        public byte flag;
        public byte msgVisible;
        public uint goldMin;
        public uint goldMax;
        public byte goldPopMin;
        public byte goldPopMax;
        public ushort itm1ID;
        public byte itm1Num;
        public byte itm1Per;
        public ushort itm2ID;
        public byte itm2Num;
        public byte itm2Per;
        public ushort itm3ID;
        public byte itm3Num;
        public byte itm3Per;
        public ushort itm4ID;
        public byte itm4Num;
        public byte itm4Per;
        public ushort itm5ID;
        public byte itm5Num;
        public byte itm5Per;
        public ushort itm6ID;
        public byte itm6Num;
        public byte itm6Per;
        public ushort itm7ID;
        public byte itm7Num;
        public byte itm7Per;
        public ushort itm8ID;
        public byte itm8Num;
        public byte itm8Per;
        public byte randitmPopMin;
        public byte randitmPopMax;
        public byte rsc_paramID;
        public byte msgdigVisible;
        public ushort menuMapImage;
        public bool Digflg;
        public bool DigPopflg;
        public FLD_ConditionList _Condition;
        public FLD_FieldSkillSetting _FSID;
        public FLD_FieldSkillSetting _FSID2;
        public object _itm1ID;
        public object _itm2ID;
        public object _itm3ID;
        public object _itm4ID;
        public object _itm5ID;
        public object _itm6ID;
        public object _itm7ID;
        public object _itm8ID;
        public RSC_TboxList _RSC_ID;
    }

    [BdatType]
    [Serializable]
    public class ma41a_FLD_CollectionPopList
    {
        public int Id;
        public string name;
        public ushort gimmickID;
        public ushort Condition;
        public uint POP_TIME;
        public byte popWeather;
        public ushort CollectionTable;
        public ushort nameRadius;
        public byte rsc_paramID;
        public float initWaitTime;
        public float initWaitTimeRand;
        public FLD_ConditionList _Condition;
        public TimeRange _POP_TIME;
    }

    [BdatType]
    [Serializable]
    public class Message
    {
        public int Id;
        public ushort style;
        public string name;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_Crystal
    {
        public int Id;
        public ushort Score;
        public string Res;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_Enemy
    {
        public int Id;
        public string Name;
        public byte MoveType;
        public byte HitType;
        public byte HitW;
        public byte HitH;
        public byte Atk;
        public ushort Speed;
        public ushort Range;
        public ushort Search;
        public ushort ActSpd;
        public byte Hp;
        public byte BackFrm;
        public ushort BackSpd;
        public ushort Score;
        public byte ResID;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_PC
    {
        public int Id;
        public ushort Hp;
        public byte HitW;
        public byte HitH;
        public byte AtkW;
        public byte AtkH;
        public ushort SpdU;
        public ushort SpdLR;
        public ushort SpdD;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_Stage
    {
        public int Id;
        public ushort SpdD;
        public ushort SpdU;
        public ushort AccU;
        public ushort MaxU;
        public ushort Scroll;
        public ushort Bonus;
        public ushort StarRate;
        public ushort BotRate;
        public byte BotVal;
        public ushort BonusTime;
        public ushort UniRate;
        public byte EthRate;
        public byte BonusEntry;
        public ushort Condition;
        public string Res;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_Tbox
    {
        public int Id;
        public byte Type;
        public ushort tdef1;
        public ushort cond1;
        public ushort tdef2;
        public ushort cond2;
        public ushort tdef3;
        public ushort cond3;
        public ushort tdef4;
        public ushort cond4;
        public ushort tdef5;
        public ushort cond5;
        public ushort tdef6;
        public ushort cond6;
        public ushort tdef7;
        public ushort cond7;
        public ushort tdef8;
        public ushort cond8;
        public ushort tdef9;
        public ushort cond9;
        public ushort tdef10;
        public ushort cond10;
        public FLD_ConditionList _cond1;
        public FLD_ConditionList _cond10;
        public FLD_ConditionList _cond2;
        public FLD_ConditionList _cond3;
        public FLD_ConditionList _cond4;
        public FLD_ConditionList _cond5;
        public FLD_ConditionList _cond6;
        public FLD_ConditionList _cond7;
        public FLD_ConditionList _cond8;
        public FLD_ConditionList _cond9;
        public MIN_TT_Tdef _tdef1;
        public MIN_TT_Tdef _tdef10;
        public MIN_TT_Tdef _tdef2;
        public MIN_TT_Tdef _tdef3;
        public MIN_TT_Tdef _tdef4;
        public MIN_TT_Tdef _tdef5;
        public MIN_TT_Tdef _tdef6;
        public MIN_TT_Tdef _tdef7;
        public MIN_TT_Tdef _tdef8;
        public MIN_TT_Tdef _tdef9;
    }

    [BdatType]
    [Serializable]
    public class MIN_TT_Tdef
    {
        public int Id;
        public ushort item1;
        public byte rate1;
        public ushort item2;
        public byte rate2;
        public ushort item3;
        public byte rate3;
        public ushort item4;
        public byte rate4;
        public ushort item5;
        public byte rate5;
        public ushort item6;
        public byte rate6;
        public ushort item7;
        public byte rate7;
        public ushort item8;
        public byte rate8;
        public ushort item9;
        public byte rate9;
        public ushort item10;
        public byte rate10;
        public ushort item11;
        public byte rate11;
        public ushort item12;
        public byte rate12;
        public object _item1;
        public object _item10;
        public object _item11;
        public object _item12;
        public object _item2;
        public object _item3;
        public object _item4;
        public object _item5;
        public object _item6;
        public object _item7;
        public object _item8;
        public object _item9;
    }

    [BdatType]
    [Serializable]
    public class MNU_AnnouncePage
    {
        public int Id;
        public ushort title;
        public ushort summary;
        public ushort image;
        public Message _summary;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_AnnounceSchedule
    {
        public int Id;
        public ushort title;
        public ushort summary;
        public ushort schedule;
        public byte available;
        public byte @new;
        public byte order;
        public Message _schedule;
        public Message _summary;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_BladeCreate
    {
        public int Id;
        public ushort limited_item;
        public byte after_pt_in;
        public object _limited_item;
    }

    [BdatType]
    [Serializable]
    public class MNU_BlCoolTimeLv
    {
        public int Id;
        public uint value;
    }

    [BdatType]
    [Serializable]
    public class MNU_BlImageID
    {
        public int Id;
        public ushort icon_id;
        public short offs_x;
        public short offs_y;
        public float scale;
        public short offs_x2;
        public short offs_y2;
        public float scale2;
        public short offs_x3;
        public short offs_y3;
        public float scale3;
        public short offs_x4;
        public short offs_y4;
        public float scale4;
        public short offs_x5;
        public short offs_y5;
        public float scale5;
    }

    [BdatType]
    [Serializable]
    public class MNU_BtnChallenge2
    {
        public int Id;
        public byte Speed;
        public ushort Wait;
        public byte Type;
        public ushort Start1;
        public ushort Hit1;
        public ushort End1;
        public byte Param1;
        public byte BtnType1;
        public byte Point1;
        public ushort Start2;
        public ushort Hit2;
        public ushort End2;
        public byte Param2;
        public byte BtnType2;
        public byte Point2;
        public ushort Start3;
        public ushort Hit3;
        public ushort End3;
        public byte Param3;
        public byte BtnType3;
        public byte Point3;
        public ButtonType _BtnType1;
        public ButtonType _BtnType2;
        public ButtonType _BtnType3;
        public MNU_ChallengeParam _Param1;
        public MNU_ChallengeParam _Param2;
        public MNU_ChallengeParam _Param3;
    }

    [BdatType]
    [Serializable]
    public class MNU_BtnChallengeSeq
    {
        public int Id;
        public ushort challenge01;
        public ushort challenge02;
        public ushort challenge03;
        public byte challenge04;
        public ushort challenge05;
        public MNU_BtnChallenge2 _challenge01;
        public MNU_BtnChallenge2 _challenge02;
        public MNU_BtnChallenge2 _challenge03;
        public MNU_BtnChallenge2 _challenge04;
        public MNU_BtnChallenge2 _challenge05;
    }

    [BdatType]
    [Serializable]
    public class MNU_CampCraft
    {
        public int Id;
        public ushort driver_id;
        public ushort shop_id;
        public ushort summary_msg;
        public CHR_Dr _driver_id;
        public MNU_ShopList _shop_id;
        public Message _summary_msg;
    }

    [BdatType]
    [Serializable]
    public class MNU_ChallengeParam
    {
        public int Id;
        public byte InputType;
        public ushort PushRange;
        public ushort PushSweetRange;
        public byte MashingCount;
        public ushort MashingTime;
        public ushort PushSweetFrame;
    }

    [BdatType]
    [Serializable]
    public class MNU_ChallengeResult
    {
        public int Id;
        public byte Point;
        public uint Text;
        public Message _Text;
    }

    [BdatType]
    [Serializable]
    public class MNU_CharOrder
    {
        public int Id;
        public ushort layer;
        public ushort useCond;
        public MNU_FSMenu _layer;
        public MNU_Condition _useCond;
    }

    [BdatType]
    [Serializable]
    public class MNU_CmnJog
    {
        public int Id;
        public ushort angle_range;
        public ushort start_angle;
        public byte def_select;
        public string theme_col;
        public string item_sheet;
    }

    [BdatType]
    [Serializable]
    public class MNU_CmnList
    {
        public int Id;
        public readonly ushort[] item = new ushort[9];
    }

    [BdatType]
    [Serializable]
    public class MNU_CmnWindow
    {
        public int Id;
        public byte type;
        public byte select;
        public ushort text;
        public ushort title;
        public ushort select_ok_txt;
        public ushort select_cancel_txt;
        public Message _select_cancel_txt;
        public Message _select_ok_txt;
        public Message _text;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_ColorList
    {
        public int Id;
        public string name;
        public byte col_r;
        public byte col_g;
        public byte col_b;
    }

    [BdatType]
    [Serializable]
    public class MNU_Condition
    {
        public int Id;
        public ushort cond;
        public FLD_ConditionList _cond;
    }

    [BdatType]
    [Serializable]
    public class MNU_DamageValue
    {
        public int Id;
        public float value;
    }

    [BdatType]
    [Serializable]
    public class MNU_DlcGift
    {
        public int Id;
        public byte releasecount;
        public ushort title;
        public ushort condition;
        public byte category;
        public ushort item_id;
        public ushort value;
        public byte disp_item_info;
        public ushort getflag;
        public FLD_ConditionList _condition;
        public object _item_id;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_EventTheater
    {
        public int Id;
        public ushort title;
        public ushort event_id;
        public ushort condition;
        public ushort thumbnail;
        public byte category;
        public byte chapter;
        public byte maincast;
        public ushort blade_id;
        public ushort flag_index;
        public ushort map_id;
        public byte fixed_time;
        public byte in_dlc;
        public ushort fixed_weather;
        public byte vandamme_in;
        public byte melef_in;
        public byte seeg_in;
        public byte rex_awaking;
        public CHR_Bl _blade_id;
        public MNU_Name _chapter;
        public MNU_Name _maincast;
        public FLD_maplist _map_id;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_FacePatternList
    {
        public int Id;
        public string name;
        public byte image_no;
    }

    [BdatType]
    [Serializable]
    public class MNU_Filename
    {
        public int Id;
        public string filename;
    }

    [BdatType]
    [Serializable]
    public class MNU_FontSet01
    {
        public int Id;
        public byte type;
        public uint resource;
        public byte image_type;
    }

    [BdatType]
    [Serializable]
    public class MNU_FSMenu
    {
        public int Id;
        public ushort next_jog;
        public ushort layer_id;
        public ushort icon;
        public ushort text;
        public ushort desc;
        public MNU_Name _desc;
        public Message _text;
    }

    [BdatType]
    [Serializable]
    public class MNU_HanaMode
    {
        public int Id;
        public ushort JS_SET;
        public ushort JK_SET;
        public ushort JD_SET;
        public ushort JS_EXPAND;
        public ushort JK_EXPAND;
        public ushort JD_EXPAND;
        public ushort ITEM_MAKE;
        public ushort BASE_SET;
    }

    [BdatType]
    [Serializable]
    public class MNU_HanaSet
    {
        public int Id;
        public ushort name;
        public ushort icon;
        public ushort slotIcon;
        public Message _name;
    }

    [BdatType]
    [Serializable]
    public class MNU_IconList
    {
        public int Id;
        public byte icon_index;
    }

    [BdatType]
    [Serializable]
    public class MNU_InputAct
    {
        public int Id;
        public byte act_id;
        public ushort text;
        public ushort text2;
        public ushort text3;
        public ushort text4;
        public byte repeat;
    }

    [BdatType]
    [Serializable]
    public class MNU_InputPad
    {
        public int Id;
        public string name;
        public sbyte pad_select;
        public ushort select_text;
        public byte loop;
        public byte repeat;
        public byte shift;
        public byte key_sort;
        public byte pad_decide;
        public byte pad_cancel;
        public byte pad_A;
        public byte pad_B;
        public byte pad_X;
        public byte pad_Y;
        public byte pad_L1;
        public byte pad_L2;
        public byte pad_L3;
        public byte pad_R1;
        public byte pad_R2;
        public byte pad_R3;
        public byte pad_START;
        public byte pad_SELECT;
        public byte pad_UP;
        public byte pad_DOWN;
        public byte pad_RIGHT;
        public byte pad_LEFT;
        public byte pad_LS_UP;
        public byte pad_LS_DOWN;
        public byte pad_LS_RIGHT;
        public byte pad_LS_LEFT;
        public byte pad_RS_UP;
        public byte pad_RS_DOWN;
        public byte pad_RS_RIGHT;
        public byte pad_RS_LEFT;
    }

    [BdatType]
    [Serializable]
    public class MNU_InputPointer
    {
        public int Id;
        public string name;
        public sbyte pointer_speed;
        public byte snap;
        public ushort select_text;
        public byte key_sort;
        public sbyte pad_decide;
        public sbyte pad_cancel;
        public sbyte pad_A;
        public sbyte pad_B;
        public sbyte pad_X;
        public sbyte pad_Y;
        public sbyte pad_L1;
        public sbyte pad_L2;
        public sbyte pad_R1;
        public sbyte pad_R2;
        public sbyte pad_START;
        public sbyte pad_SELECT;
        public sbyte pad_UP;
        public sbyte pad_DOWN;
        public sbyte pad_RIGHT;
        public sbyte pad_LEFT;
    }

    [BdatType]
    [Serializable]
    public class MNU_InputWheel
    {
        public int Id;
        public string name;
        public ushort start_angle;
        public ushort angle_range;
        public byte select_dir;
        public sbyte pad_decide;
        public sbyte pad_cancel;
        public sbyte pad_A;
        public sbyte pad_B;
        public sbyte pad_X;
        public sbyte pad_Y;
        public sbyte pad_L1;
        public sbyte pad_L2;
        public sbyte pad_R1;
        public sbyte pad_R2;
        public sbyte pad_START;
        public sbyte pad_SELECT;
    }

    [BdatType]
    [Serializable]
    public class MNU_jog_txt
    {
        public int Id;
        public ushort fs_menu_id;
        public ushort txt;
        public ushort lock_flag;
    }

    [BdatType]
    [Serializable]
    public class MNU_KeyOrder
    {
        public int Id;
        public ushort key;
        public ushort order;
        public ushort order2;
    }

    [BdatType]
    [Serializable]
    public class MNU_Layer
    {
        public int Id;
        public byte group;
        public string sheet01;
        public byte prio01;
        public string sheet02;
        public byte prio02;
        public string sheet03;
        public byte prio03;
        public string sheet04;
        public byte prio04;
        public string sheet05;
        public byte prio05;
        public string sheet06;
        public byte prio06;
        public byte hud_group;
    }

    [BdatType]
    [Serializable]
    public class MNU_MainOrder
    {
        public int Id;
        public ushort layer;
        public ushort useCond;
        public ushort guide;
        public ushort title;
        public ushort titleIcon;
        public ushort subTitle;
        public string resName;
        public MNU_Name _guide;
        public MNU_Msg_SubContents _subTitle;
        public Message _title;
        public MNU_Condition _useCond;
    }

    [BdatType]
    [Serializable]
    public class MNU_MapGroup
    {
        public int Id;
        public string include_map;
        public ushort disp_name;
        public byte under_water;
        public ushort condition;
        public FLD_ConditionList _condition;
        public Message _disp_name;
    }

    [BdatType]
    [Serializable]
    public class MNU_MapInfo
    {
        public int Id;
        public string level_name;
        public ushort disp_name;
        public byte under_water;
        public ushort level_priority;
        public ushort condition;
        public string level_name2;
        public FLD_ConditionList _condition;
        public Message _disp_name;
    }

    [BdatType]
    [Serializable]
    public class MNU_ModelView
    {
        public int Id;
        public string camera_file;
        public string efp_file;
        public ushort obj_model01;
        public ushort obj_model02;
    }

    [BdatType]
    [Serializable]
    public class MNU_Msg_SubContents
    {
        public int Id;
        public ushort name;
        public ushort caption;
        public MNU_Name _caption;
        public Message _name;
    }

    [BdatType]
    [Serializable]
    public class MNU_MsgChapterEnd
    {
        public int Id;
        public ushort index;
        public ushort title;
        public Message _index;
        public Message _title;
    }

    [BdatType]
    [Serializable]
    public class MNU_MsgGiftFilter
    {
        public int Id;
        public ushort name;
        public byte number;
        public Message _name;
    }

    [BdatType]
    [Serializable]
    public class MNU_MsgPopupTitle
    {
        public int Id;
        public ushort name;
        public string color;
        public ushort name2;
        public Message _name;
        public Message _name2;
    }

    [BdatType]
    [Serializable]
    public class MNU_MsgQListTab
    {
        public int Id;
        public ushort item01;
        public ushort item02;
        public ushort item03;
        public ushort item04;
    }

    [BdatType]
    [Serializable]
    public class MNU_Name
    {
        public int Id;
        public ushort name;
        public Message _name;
    }

    [BdatType]
    [Serializable]
    public class MNU_OffsetList
    {
        public int Id;
        public float offs_x;
        public float offs_y;
        public float offs_z;
        public string bone_name;
    }

    [BdatType]
    [Serializable]
    public class MNU_OptionCamera
    {
        public int Id;
        public ushort name_id;
        public ushort cap_id;
        public string setting_name;
        public byte default_level;
        public Message _cap_id;
        public Message _name_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_OptionDisp
    {
        public int Id;
        public ushort name_id;
        public ushort cap_id;
        public byte max_level;
        public byte default_level;
        public Message _cap_id;
        public Message _name_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_OptionGameDif
    {
        public int Id;
        public ushort name_id;
        public ushort cap_id;
        public Message _cap_id;
        public Message _name_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_ResFont
    {
        public int Id;
        public string file;
    }

    [BdatType]
    [Serializable]
    public class MNU_ScriptList
    {
        public int Id;
        public string name;
        public string script;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopCategoryName
    {
        public int Id;
        public ushort icon_id;
        public ushort name;
        public Message _name;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopChange
    {
        public int Id;
        public ushort DefTaskSet1;
        public ushort DefTaskSet2;
        public ushort DefTaskSet3;
        public ushort DefTaskSet4;
        public ushort DefTaskSet5;
        public ushort DefTaskSet6;
        public ushort DefTaskSet7;
        public ushort DefTaskSet8;
        public ushort AddTaskSet1;
        public ushort AddCondition1;
        public ushort AddTaskSet2;
        public ushort AddCondition2;
        public ushort AddTaskSet3;
        public ushort AddCondition3;
        public ushort AddTaskSet4;
        public ushort AddCondition4;
        public ushort AddTaskSet5;
        public ushort AddCondition5;
        public ushort AddTaskSet6;
        public ushort AddCondition6;
        public ushort AddTaskSet7;
        public ushort AddCondition7;
        public ushort AddTaskSet8;
        public ushort AddCondition8;
        public ushort LinkQuestTask;
        public ushort LinkQuestTaskID;
        public ushort UnitText;
        public FLD_ConditionList _AddCondition1;
        public FLD_ConditionList _AddCondition2;
        public FLD_ConditionList _AddCondition3;
        public FLD_ConditionList _AddCondition4;
        public FLD_ConditionList _AddCondition5;
        public FLD_ConditionList _AddCondition6;
        public FLD_ConditionList _AddCondition7;
        public FLD_ConditionList _AddCondition8;
        public MNU_ShopChangeTask _AddTaskSet1;
        public MNU_ShopChangeTask _AddTaskSet2;
        public MNU_ShopChangeTask _AddTaskSet3;
        public MNU_ShopChangeTask _AddTaskSet4;
        public MNU_ShopChangeTask _AddTaskSet5;
        public MNU_ShopChangeTask _AddTaskSet6;
        public MNU_ShopChangeTask _AddTaskSet7;
        public MNU_ShopChangeTask _AddTaskSet8;
        public MNU_ShopChangeTask _DefTaskSet1;
        public MNU_ShopChangeTask _DefTaskSet2;
        public MNU_ShopChangeTask _DefTaskSet3;
        public MNU_ShopChangeTask _DefTaskSet4;
        public MNU_ShopChangeTask _DefTaskSet5;
        public MNU_ShopChangeTask _DefTaskSet6;
        public MNU_ShopChangeTask _DefTaskSet7;
        public MNU_ShopChangeTask _DefTaskSet8;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopChangeTask
    {
        public int Id;
        public ushort Name;
        public ushort SetItem1;
        public ushort SetNumber1;
        public ushort SetItem2;
        public ushort SetNumber2;
        public ushort SetItem3;
        public ushort SetNumber3;
        public ushort SetItem4;
        public ushort SetNumber4;
        public ushort SetItem5;
        public ushort SetNumber5;
        public ushort HideReward;
        public ushort Reward;
        public ushort HideRewardFlag;
        public byte AddFlagValue;
        public Message _Name;
        public FLD_QuestReward _Reward;
        public object _SetItem1;
        public object _SetItem2;
        public object _SetItem3;
        public object _SetItem4;
        public object _SetItem5;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopInn
    {
        public int Id;
        public ushort Price;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopList
    {
        public int Id;
        public ushort Name;
        public ushort ShopIcon;
        public byte ShopType;
        public ushort TableID;
        public byte Discount1;
        public byte Discount2;
        public byte Discount3;
        public byte Discount4;
        public byte Discount5;
        public Message _Name;
        public ShopType _ShopType;
    }

    [BdatType]
    [Serializable]
    public class MNU_ShopNormal
    {
        public int Id;
        public ushort DefItem1;
        public ushort DefItem2;
        public ushort DefItem3;
        public ushort DefItem4;
        public ushort DefItem5;
        public ushort DefItem6;
        public ushort DefItem7;
        public ushort DefItem8;
        public ushort DefItem9;
        public ushort DefItem10;
        public ushort Addtem1;
        public ushort AddCondition1;
        public byte PrivilegeCheck1;
        public ushort Addtem2;
        public ushort AddCondition2;
        public byte PrivilegeCheck2;
        public ushort Addtem3;
        public ushort AddCondition3;
        public byte PrivilegeCheck3;
        public ushort Addtem4;
        public ushort AddCondition4;
        public byte PrivilegeCheck4;
        public ushort Addtem5;
        public ushort AddCondition5;
        public byte PrivilegeCheck5;
        public ushort PrivilegeFlag;
        public ushort PrivilegeItem;
        public FLD_ConditionList _AddCondition1;
        public FLD_ConditionList _AddCondition2;
        public FLD_ConditionList _AddCondition3;
        public FLD_ConditionList _AddCondition4;
        public FLD_ConditionList _AddCondition5;
        public object _Addtem1;
        public object _Addtem2;
        public object _Addtem3;
        public object _Addtem4;
        public object _Addtem5;
        public object _DefItem1;
        public object _DefItem10;
        public object _DefItem2;
        public object _DefItem3;
        public object _DefItem4;
        public object _DefItem5;
        public object _DefItem6;
        public object _DefItem7;
        public object _DefItem8;
        public object _DefItem9;
        public object _PrivilegeItem;
    }

    [BdatType]
    [Serializable]
    public class MNU_SortBuff
    {
        public int Id;
        public ushort buff1;
    }

    [BdatType]
    [Serializable]
    public class MNU_SortEnhance
    {
        public int Id;
        public ushort enhance1;
        public ushort enhance2;
        public ushort enhance3;
        public ushort enhance4;
        public Message _enhance1;
        public Message _enhance2;
        public Message _enhance3;
        public Message _enhance4;
    }

    [BdatType]
    [Serializable]
    public class MNU_SortFieldSkill
    {
        public int Id;
        public ushort fs1;
        public FLD_FieldSkillList _fs1;
    }

    [BdatType]
    [Serializable]
    public class MNU_SortRole
    {
        public int Id;
        public ushort role1;
        public Message _role1;
    }

    [BdatType]
    [Serializable]
    public class MNU_SortTable
    {
        public int Id;
        public ushort sort_type1;
        public ushort sort_type2;
        public ushort sort_type3;
        public ushort sort_type4;
        public ushort sort_type5;
        public ushort sort_type6;
        public ushort sort_type7;
        public ushort sort_type8;
        public ushort sort_type9;
        public ushort sort_type10;
        public ushort sort_type11;
        public ushort sort_type12;
        public ushort sort_type13;
        public ushort sort_type14;
        public MNU_Name _sort_type1;
        public MNU_Name _sort_type10;
        public MNU_Name _sort_type11;
        public MNU_Name _sort_type12;
        public MNU_Name _sort_type13;
        public MNU_Name _sort_type14;
        public MNU_Name _sort_type2;
        public MNU_Name _sort_type3;
        public MNU_Name _sort_type4;
        public MNU_Name _sort_type5;
        public MNU_Name _sort_type6;
        public MNU_Name _sort_type7;
        public MNU_Name _sort_type8;
        public MNU_Name _sort_type9;
    }

    [BdatType]
    [Serializable]
    public class MNU_SoundBgm
    {
        public int Id;
        public ushort resource;
        public float time;
        public MNU_Filename _resource;
    }

    [BdatType]
    [Serializable]
    public class MNU_SoundSe
    {
        public int Id;
        public ushort resource_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_SpecialShop
    {
        public int Id;
        public ushort shop_id;
        public ushort scenario_flag;
        public MNU_ShopList _shop_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_Stream_full_bl
    {
        public int Id;
        public string filename;
        public string filename_2nd;
    }

    [BdatType]
    [Serializable]
    public class MNU_TextProperty
    {
        public int Id;
        public string name;
        public byte col_r;
        public byte col_g;
        public byte col_b;
        public byte Bold;
    }

    [BdatType]
    [Serializable]
    public class MNU_Tutorial
    {
        public int Id;
        public string script_file;
        public uint param1;
    }

    [BdatType]
    [Serializable]
    public class MNU_txt
    {
        public int Id;
        public string obj_name;
        public uint text_id;
        public Message _text_id;
    }

    [BdatType]
    [Serializable]
    public class MNU_UioReplace
    {
        public int Id;
        public string file;
        public string replace01;
    }

    [BdatType]
    [Serializable]
    public class MNU_WorldMap
    {
        public int Id;
        public short posX;
        public short posY;
    }

    [BdatType]
    [Serializable]
    public class MNU_WorldMapCond
    {
        public int Id;
        public ushort mapId;
        public ushort cond1;
        public ushort pos1;
        public ushort cond2;
        public ushort pos2;
        public ushort cond3;
        public ushort pos3;
        public ushort enter;
        public FLD_ConditionList _cond1;
        public FLD_ConditionList _cond2;
        public FLD_ConditionList _cond3;
        public FLD_ConditionList _enter;
        public FLD_maplist _mapId;
        public MNU_WorldMap _pos1;
        public MNU_WorldMap _pos2;
        public MNU_WorldMap _pos3;
    }

    [BdatType]
    [Serializable]
    public class RSC_AreaBgmList
    {
        public int Id;
        public string name;
        public ushort bgmCondition;
        public RSC_BgmCondition _bgmCondition;
    }

    [BdatType]
    [Serializable]
    public class RSC_BgmCondition
    {
        public int Id;
        public ushort ConditionA;
        public ushort BgmIDA;
        public ushort ConditionB;
        public ushort BgmIDB;
        public ushort ConditionC;
        public ushort BgmIDC;
        public ushort ConditionD;
        public ushort BgmIDD;
        public byte Priority;
        public MNU_Filename _BgmIDA;
        public MNU_Filename _BgmIDB;
        public MNU_Filename _BgmIDC;
        public MNU_Filename _BgmIDD;
        public FLD_ConditionList _ConditionA;
        public FLD_ConditionList _ConditionB;
        public FLD_ConditionList _ConditionC;
        public FLD_ConditionList _ConditionD;
    }

    [BdatType]
    [Serializable]
    public class RSC_dropitemList
    {
        public int Id;
        public string mdo;
        public ushort paramid0;
        public ushort paramid1;
        public ushort paramid2;
        public ushort paramid3;
        public ushort dropSE;
        public ushort getdropSE;
        public byte limitType;
    }

    [BdatType]
    [Serializable]
    public class RSC_dropitemParam
    {
        public int Id;
        public float height;
        public float heightRand;
        public float distance;
        public float distanceRand;
        public float time;
        public float speedAtte;
        public float rotYRand;
        public float lifeTime;
        public float flashTime;
        public float flashInterval1;
        public float flashInterval2;
        public float vanishTime1;
        public float vanishTime2;
        public float radius;
        public float initHeight;
        public float startScale;
        public float endScale;
        public float scaleTime;
        public byte isSpin;
        public float spinSpeed;
        public byte startSpinBound;
        public float startSpinTime;
        public byte boundNum;
    }

    [BdatType]
    [Serializable]
    public class RSC_En
    {
        public int Id;
        public string DebugName;
        public byte TypeFamily;
        public byte TypeGenus;
        public byte ActType;
        public short FlyHeight;
        public byte FldMoveType;
        public byte Material;
        public byte ProxyID;
        public byte EnRadius;
        public byte EnRadius2;
        public ushort ChestHeight;
        public ushort ChestHeight2;
        public float BallRadius;
        public float BallHeight;
        public float CharColli;
        public ushort offsetID;
        public byte EyeRot;
        public string SearchBaseBone;
        public string CenterBone;
        public string CamBone;
        public byte FrontAngle;
        public byte TurnAngleSmall;
        public byte TurnAngleBig;
        public byte Unduration;
        public string Model;
        public string ChrFile;
        public string ActFile;
        public string Motion;
        public string RefMotion;
        public string EffectPack;
        public string LoopEffect;
        public string SePack;
        public string Voice;
        public byte VoiceEx;
        public string ClipEvent;
        public string Comp_Eff;
        public string Comp_Se;
        public string Comp_Vo;
        public ushort Flag;
        public ushort WeaponNum1;
        public ushort WeaponNum2;
        public ushort WeaponNum3;
        public ushort WeaponNum4;
        public ushort WeaponNum5;
        public byte MemorySlot;
        public byte Race;
        public byte DrType;
        public sbyte GoldDivideRev;
        public byte FootStep;
        public byte FootStepEffect;
        public short SearchBoneRX;
        public short SearchBoneRY;
        public short SearchBoneRZ;
        public sbyte RotateX;
        public sbyte RotateY;
        public sbyte RotateZ;
        public sbyte RotateDeg;
        public string RotateBone;
        public ushort RotEffScale;
        public byte ExtraParts1;
        public byte ExtraParts2;
        public byte ExtraParts3;
        public byte ExtraParts4;
        public byte DeadSeNum;
        public bool NoEcSkip;
        public bool Map;
        public bool Evt;
        public bool NoWinVo;
        public bool Bait;
        public bool UseSearchBone;
        public bool NoVanish;
        public bool NoCamera;
        public bool WeaponDrawDisp;
        public bool JoinAll;
        public bool DeathMotion;
        public MNU_Name _TypeFamily;
        public RSC_EnGenus _TypeGenus;
    }

    [BdatType]
    [Serializable]
    public class RSC_EnGenus
    {
        public int Id;
        public byte NAME;
        public byte CAPTION;
        public byte Flag;
        public bool gimmicktype;
        public Message _NAME;
    }

    [BdatType]
    [Serializable]
    public class RSC_EnUnd
    {
        public int Id;
        public byte Flag;
        public sbyte UndMinX;
        public sbyte UndMaxX;
        public sbyte UndMinZ;
        public sbyte UndMaxZ;
        public byte UndDeg;
        public bool UndX;
        public bool UndZ;
    }

    [BdatType]
    [Serializable]
    public class RSC_EnWpn
    {
        public int Id;
        public string Model;
        public ushort Scale;
        public string Motion;
        public string MtpInChara;
        public string MtpInWpn;
        public string MtpOutChara;
        public string MtpOutWpn;
    }

    [BdatType]
    [Serializable]
    public class RSC_GmkSetList
    {
        public int Id;
        public ushort mapId;
        public string enemy;
        public string enemy_bdat;
        public string npc;
        public string npc_bdat;
        public string mapObj;
        public string mapObj_bdat;
        public string tbox;
        public string tbox_bdat;
        public string @event;
        public string event_bdat;
        public string fieldLock;
        public string fieldLock_bdat;
        public string effect;
        public string effect_bdat;
        public string se;
        public string se_bdat;
        public string mob;
        public string mob_bdat;
        public string autoTalk;
        public string autoTalk_ms;
        public string landmark;
        public string landmark_bdat;
        public string formPc;
        public string formPcEv;
        public string collection;
        public string collection_bdat;
        public string areaBgm;
        public string areaBgm_bdat;
        public string areaWeather;
        public string salvage;
        public string salvage_bdat;
        public string mapGimmick;
        public string mapGimmick_bdat;
        public string precious;
        public string precious_bdat;
        public string grave;
        public string grave_bdat;
        public string kizunaTalk;
        public string kizunaTalk_bdat;
        public string jump;
        public string jump_bdat;
        public string warp;
        public string warp_bdat;
        public string squad;
        public string door;
        public string door_bdat;
        public string elevator;
        public string elevator_bdat;
        public string mapJump;
        public string mapJump_bdat;
        public string fieldVolume;
        public string climbing;
        public string climbing_bdat;
        public string blade;
        public string blade_bdat;
        public string dmgGimmick;
        public string dmgGimmick_bdat;
        public string footPrint;
        public string footPrint_bdat;
        public string antiBladeArea;
        public string antiBladeArea_bdat;
        public string tutorial;
        public string tutorial_bdat;
        public string enemyWave;
        public string enemyWave_bdat;
        public string battleChallenge;
        public string battleChallenge_bdat;
        public string campPop;
        public string campPop_bdat;
        public string sealedStone;
        public string sealedStone_bdat;
        public FLD_maplist _mapId;
    }

    [BdatType]
    [Serializable]
    public class RSC_MapObjList
    {
        public int Id;
        public string Model;
        public string Motion;
        public string Comp_Eff;
        public string SE;
        public ushort SeEnv;
        public byte flag;
        public byte ExtraParts1;
        public bool BigObj;
    }

    [BdatType]
    [Serializable]
    public class RSC_MobList
    {
        public int Id;
        public string Model;
        public string Motion;
        public string AddMotion;
        public string Comp_Eff;
        public ushort CollisionId;
        public string SE;
        public ushort SeEnv;
        public byte Race;
        public ushort FootStep;
        public byte FootStepEffect;
        public ushort OffsetID;
        public byte ExtraParts1;
        public byte ExtraParts2;
        public byte ExtraParts3;
        public byte ExtraParts4;
        public byte ExtraParts5;
        public byte ExtraParts6;
    }

    [BdatType]
    [Serializable]
    public class RSC_NpcList
    {
        public int Id;
        public string Model;
        public string Motion;
        public string AddMotion;
        public byte EvtRetarget;
        public string Comp_Eff;
        public ushort CollisionId;
        public string SE;
        public ushort SeEnv;
        public byte Race;
        public ushort FootStep;
        public byte FootStepEffect;
        public byte Roots;
        public byte Gender;
        public ushort Name;
        public ushort OffsetID;
        public byte EyeRot;
        public byte ExtraParts1;
        public byte ExtraParts2;
        public byte ExtraParts3;
        public byte ExtraParts4;
        public byte ExtraParts5;
        public byte ExtraParts6;
        public ushort Scale;
        public ushort EventAsset;
        public ushort Job;
        public ushort HitonowaFlag;
        public ushort NpcMeetFlag;
        public ushort MSGID;
        public Message _Name;
    }

    [BdatType]
    [Serializable]
    public class RSC_NpcWpn
    {
        public int Id;
        public string Model;
        public string Motion;
    }

    [BdatType]
    [Serializable]
    public class RSC_PcWpn
    {
        public int Id;
        public string Model;
        public string Motion;
        public string Effpack;
        public byte Flag;
        public ushort MenuImageID;
        public bool SpMuz;
        public MNU_Filename _MenuImageID;
    }

    [BdatType]
    [Serializable]
    public class RSC_PcWpnMount
    {
        public int Id;
        public string Wpn01rIn;
        public string Wpn01rOut;
        public string Wpn02rIn;
        public string Wpn02rOut;
        public string Wpn03rIn;
        public string Wpn03rOut;
        public string Wpn03lIn;
        public string Wpn03lOut;
        public string Wpn04rIn;
        public string Wpn04rOut;
        public string Wpn05rIn;
        public string Wpn05rOut;
        public string Wpn05lIn;
        public string Wpn05lOut;
        public string Wpn06rIn;
        public string Wpn06rOut;
        public string Wpn07rIn;
        public string Wpn07rOut;
        public string Wpn07lIn;
        public string Wpn07lOut;
        public string Wpn08rIn;
        public string Wpn08rOut;
        public string Wpn09rIn;
        public string Wpn09rOut;
        public string Wpn09lIn;
        public string Wpn09lOut;
        public string Wpn10rIn;
        public string Wpn10rOut;
        public string Wpn10lIn;
        public string Wpn10lOut;
        public string Wpn11rIn;
        public string Wpn11rOut;
        public string Wpn12rIn;
        public string Wpn12rOut;
        public string Wpn12lIn;
        public string Wpn12lOut;
        public string Wpn13rIn;
        public string Wpn13rOut;
        public string Wpn14rIn;
        public string Wpn14rOut;
        public string Wpn15rIn;
        public string Wpn15rOut;
        public string Wpn16rIn;
        public string Wpn16rOut;
        public string Wpn16lIn;
        public string Wpn16lOut;
        public string Wpn17rIn;
        public string Wpn17rOut;
        public string Wpn18rIn;
        public string Wpn18rOut;
        public string Wpn19rIn;
        public string Wpn19rOut;
        public string Wpn20rIn;
        public string Wpn20rOut;
        public string Wpn20lIn;
        public string Wpn20lOut;
        public string Wpn21rIn;
        public string Wpn21rOut;
        public string Wpn22rIn;
        public string Wpn22rOut;
        public string Wpn22lIn;
        public string Wpn22lOut;
        public string Wpn23rIn;
        public string Wpn23rOut;
        public string Wpn23lIn;
        public string Wpn23lOut;
        public string Wpn24rIn;
        public string Wpn24rOut;
        public string Wpn24lIn;
        public string Wpn24lOut;
        public string Wpn25rIn;
        public string Wpn25rOut;
        public string Wpn25lIn;
        public string Wpn25lOut;
        public string Wpn26rIn;
        public string Wpn26rOut;
        public string Wpn26lIn;
        public string Wpn26lOut;
        public string Wpn28rIn;
        public string Wpn28rOut;
        public string Wpn28lIn;
        public string Wpn28lOut;
        public string Wpn29rIn;
        public string Wpn29rOut;
        public string Wpn29lIn;
        public string Wpn29lOut;
        public string Wpn30rIn;
        public string Wpn30rOut;
        public string Wpn30lIn;
        public string Wpn30lOut;
        public string Wpn31rIn;
        public string Wpn31rOut;
        public string Wpn31lIn;
        public string Wpn31lOut;
        public string Wpn32rIn;
        public string Wpn32rOut;
        public string Wpn32lIn;
        public string Wpn32lOut;
        public string Wpn33rIn;
        public string Wpn33rOut;
        public string Wpn33lIn;
        public string Wpn33lOut;
        public string Wpn34rIn;
        public string Wpn34rOut;
        public string Wpn34lIn;
        public string Wpn34lOut;
    }

    [BdatType]
    [Serializable]
    public class RSC_TboxList
    {
        public int Id;
        public string Model;
        public string Motion;
        public string Effect;
        public string SE;
        public float baseHeight;
        public float box_distance;
        public float initWaitTime;
        public float initWaitTimeRand;
        public ushort offsetID;
        public ushort MSG_ID;
        public ushort visible_Radius;
        public ushort invisible_Radius;
        public byte shapeType;
        public float posX;
        public float posY;
        public float posZ;
        public float base_offset_Y;
        public float FS_starttime;
        public float TBOX_open_starttime;
        public byte flag;
        public bool TBOX_category;
    }

    [BdatType]
    [Serializable]
    public class RSC_TypeWpn
    {
        public int Id;
        public string rex;
        public string nia;
        public string sieg;
        public string tora;
        public string vandamme;
        public string melef;
        public string sin;
        public string metsu;
    }

    [BdatType]
    [Serializable]
    public class SYS_BasicFormation
    {
        public int Id;
        public float OffsetDr1X;
        public float OffsetDr1Z;
        public float OffsetDr1RotY;
        public float OffsetDr2X;
        public float OffsetDr2Z;
        public float OffsetDr2RotY;
    }

    [BdatType]
    [Serializable]
    public class SYS_BladeOffset
    {
        public int Id;
        public float OffsetBlX;
        public float OffsetBlZ;
        public float OffsetBlRotY;
    }

    [BdatType]
    [Serializable]
    public class SYS_MapJumpEvList
    {
        public int Id;
        public byte MapList;
        public ushort FormationId;
        public string InfoPict;
        public ushort InfoTxt;
        public byte DecoType;
        public string debugName;
        public EVT_formation _FormationId;
        public FLD_maplist _MapList;
    }

    [BdatType]
    [Serializable]
    public class SYS_PcBtlKeyList
    {
        public int Id;
        public byte Shift;
        public byte Type1;
        public byte Button1;
        public byte Type2;
        public byte Button2;
        public byte Func;
        public byte Ignore;
        public byte UiPos;
        public ushort FLD_A;
        public ushort FLD_B;
        public ushort BTL_A;
        public ushort BTL_B;
        public ushort Text1;
        public ushort Text2;
        public bool move;
        public bool cam;
        public bool act;
        public bool hopper;
        public bool social;
        public bool challenge;
    }

    [BdatType]
    [Serializable]
    public class Vo_Battle_Blade
    {
        public int Id;
        public byte Priority;
        public byte Group;
        public ushort CTDriver;
        public readonly byte[] Cond = new byte[2];
        public byte LotRate;
        public ushort Reply;
        public byte ReplyGroup;
        public byte Flag;
        public byte Interval;
        public readonly string[] Voice = new string[4];
        public bool LotNum;
        public bool NoOverwrite;
        public bool Dead;
        public bool NoDir;
        public bool NoChain;
        public bool NoReplyOK;
    }

    [BdatType]
    [Serializable]
    public class Vo_Battle_Driver
    {
        public int Id;
        public byte Priority;
        public byte Group;
        public ushort CTDriver;
        public readonly byte[] Cond = new byte[2];
        public byte LotRate;
        public ushort Reply;
        public byte ReplyGroup;
        public byte Flag;
        public byte Interval;
        public byte SoloMode;
        public readonly string[] Voice = new string[4];
        public bool LotNum;
        public bool NoOverwrite;
        public bool Dead;
        public bool NoDir;
        public bool NoChain;
        public bool NoReplyOK;
    }

    [BdatType]
    [Serializable]
    public class Vo_Battle_Enemy
    {
        public int Id;
        public byte Priority;
        public byte Group;
        public ushort EnemyVC;
        public readonly byte[] Cond = new byte[2];
        public ushort CondEx;
        public byte LotRate;
        public ushort Reply;
        public byte ReplyGroup;
        public byte Flag;
        public byte Interval;
        public readonly string[] Voice = new string[4];
        public bool NoOverwrite;
        public bool Dead;
        public bool NoDir;
        public bool NoChain;
        public bool NoReplyOK;
        public FLD_ConditionList _CondEx;
    }

    [BdatType]
    [Serializable]
    public class Vo_Condition
    {
        public int Id;
    }

    [BdatType]
    [Serializable]
    public class Vo_Field
    {
        public int Id;
        public byte Priority;
    }

    [BdatType]
    [Serializable]
    public class Vo_Field_Filter
    {
        public int Id;
        public string TargetFile;
        public ushort Condition;
        public string ChangeFile;
        public FLD_ConditionList _Condition;
    }

    [BdatType]
    [Serializable]
    public class Vo_Filter
    {
        public int Id;
        public string TargetFile;
        public byte Condition;
        public ushort Param1;
        public ushort Param2;
        public string ChangeFile;
        public ushort NextID;
    }

    [BdatType]
    [Serializable]
    public class Vo_Group
    {
        public int Id;
        public byte Interval;
    }

    [BdatType]
    [Serializable]
    public class Vo_WinSp
    {
        public int Id;
        public ushort FLD_CondID;
        public ushort NeedChrID;
        public readonly ushort[] ChrID = new ushort[3];
        public readonly uint[] Voice = new uint[3];
        public readonly ushort[] Timer = new ushort[3];
        public FLD_ConditionList _FLD_CondID;
    }
}
