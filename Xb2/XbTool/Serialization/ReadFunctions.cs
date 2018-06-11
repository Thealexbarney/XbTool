// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable UnusedParameter.Global

using System;
using XbTool.Types;

namespace XbTool.Serialization
{
    public static class ReadFunctions
    {
        public static BdatEnum ReadBdatEnum(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BdatEnum();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            return item;
        }

        public static BdatStateEnum ReadBdatStateEnum(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BdatStateEnum();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.stat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            return item;
        }

        public static BdatValue ReadBdatValue(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BdatValue();
            item.Id = itemId;
            item.Value = BitConverter.ToUInt32(file, itemOffset);
            return item;
        }

        public static BLD_BladeList ReadBLD_BladeList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_BladeList();
            item.Id = itemId;
            item.Category = file[itemOffset];
            item.StatusID = BitConverter.ToUInt16(file, itemOffset + 1);
            return item;
        }

        public static BLD_BladeModelList ReadBLD_BladeModelList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_BladeModelList();
            item.Id = itemId;
            item.QuestRace = file[itemOffset];
            item.Gender = file[itemOffset + 1];
            item.IdeaMin = file[itemOffset + 2];
            item.IdeaMax = file[itemOffset + 3];
            item.Model1 = file[itemOffset + 4];
            item.Model2 = file[itemOffset + 5];
            item.PartsNumMin = file[itemOffset + 6];
            item.PartsNumMax = file[itemOffset + 7];
            item.Parts1 = file[itemOffset + 8];
            item.Parts2 = file[itemOffset + 9];
            item.Parts3 = file[itemOffset + 10];
            item.Parts4 = file[itemOffset + 11];
            return item;
        }

        public static BLD_BladeTable ReadBLD_BladeTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_BladeTable();
            item.Id = itemId;
            item.CharaID1 = BitConverter.ToUInt16(file, itemOffset);
            item.CharID1Percent = file[itemOffset + 2];
            item.CharaID2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.CharID2Percent = file[itemOffset + 5];
            item.CharaID3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.CharID3Percent = file[itemOffset + 8];
            item.CharaID4 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.CharID4Percent = file[itemOffset + 11];
            item.CharaID5 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.CharID5Percent = file[itemOffset + 14];
            item.CharaID6 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.CharID6Percent = file[itemOffset + 17];
            item.CharaID7 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.CharID7Percent = file[itemOffset + 20];
            item.CharaID8 = BitConverter.ToUInt16(file, itemOffset + 21);
            item.CharID8Percent = file[itemOffset + 23];
            item.CharaID9 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.CharID9Percent = file[itemOffset + 26];
            item.CharaID10 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.CharID10Percent = file[itemOffset + 29];
            item.CharaID11 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.CharID11Percent = file[itemOffset + 32];
            item.CharaID12 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.CharID12Percent = file[itemOffset + 35];
            item.CharaID13 = BitConverter.ToUInt16(file, itemOffset + 36);
            item.CharID13Percent = file[itemOffset + 38];
            item.CharaID14 = BitConverter.ToUInt16(file, itemOffset + 39);
            item.CharID14Percent = file[itemOffset + 41];
            item.CharaID15 = BitConverter.ToUInt16(file, itemOffset + 42);
            item.CharID15Percent = file[itemOffset + 44];
            item.CharaID16 = BitConverter.ToUInt16(file, itemOffset + 45);
            item.CharID16Percent = file[itemOffset + 47];
            return item;
        }

        public static BLD_CommonList ReadBLD_CommonList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_CommonList();
            item.Id = itemId;
            item.QuestRace = file[itemOffset];
            item.Gender = file[itemOffset + 1];
            item.Weapon = BitConverter.ToUInt32(file, itemOffset + 2);
            item.Atr = file[itemOffset + 6];
            item.ModelTable = BitConverter.ToUInt16(file, itemOffset + 7);
            item.IdeaType = file[itemOffset + 9];
            item.IdeaMin = file[itemOffset + 10];
            item.IdeaMax = file[itemOffset + 11];
            item.Ratio = file[itemOffset + 12];
            item.RarityMin = file[itemOffset + 13];
            item.RarityMax = file[itemOffset + 14];
            item.Fskill = file[itemOffset + 15];
            item.ArtsAchievementSet1 = file[itemOffset + 16];
            item.ArtsAchievementSet2 = file[itemOffset + 17];
            item.ArtsAchievementSet3 = file[itemOffset + 18];
            item.SkillAchievementSet1 = file[itemOffset + 19];
            item.SkillAchievementSet2 = file[itemOffset + 20];
            item.SkillAchievementSet3 = file[itemOffset + 21];
            item.FskillAchivementSet1 = file[itemOffset + 22];
            item.FskillAchivementSet2 = file[itemOffset + 23];
            item.FskillAchivementSet3 = file[itemOffset + 24];
            item.KeyAchievementSet = file[itemOffset + 25];
            item.FavoriteCategoryMax = file[itemOffset + 26];
            item.FavoriteItemMax = file[itemOffset + 27];
            return item;
        }

        public static BLD_Idea ReadBLD_Idea(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_Idea();
            item.Id = itemId;
            item.NeedPoint = BitConverter.ToUInt32(file, itemOffset);
            item.ProbRev = BitConverter.ToUInt16(file, itemOffset + 4);
            item.AtrDamRev = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static BLD_IdeaTable ReadBLD_IdeaTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_IdeaTable();
            item.Id = itemId;
            item.Item = BitConverter.ToUInt16(file, itemOffset);
            item.IdeaBlue = file[itemOffset + 2];
            item.IdeaRed = file[itemOffset + 3];
            item.IdeaWhite = file[itemOffset + 4];
            item.IdeaBlack = file[itemOffset + 5];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.BladeTable = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static BLD_NameList ReadBLD_NameList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_NameList();
            item.Id = itemId;
            item.Category = BitConverter.ToUInt16(file, itemOffset);
            item.Race = file[itemOffset + 2];
            item.Gender = file[itemOffset + 3];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 4);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 8);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 12);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 32);
            return item;
        }

        public static BLD_RareList ReadBLD_RareList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_RareList();
            item.Id = itemId;
            item.Blade = BitConverter.ToUInt16(file, itemOffset);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Prob1 = BitConverter.ToSingle(file, itemOffset + 4);
            item.Assure1 = file[itemOffset + 8];
            item.Prob2 = BitConverter.ToSingle(file, itemOffset + 9);
            item.Assure2 = file[itemOffset + 13];
            item.Prob3 = BitConverter.ToSingle(file, itemOffset + 14);
            item.Assure3 = file[itemOffset + 18];
            item.Prob4 = BitConverter.ToSingle(file, itemOffset + 19);
            item.Assure4 = file[itemOffset + 23];
            item.Prob5 = BitConverter.ToSingle(file, itemOffset + 24);
            item.Assure5 = file[itemOffset + 28];
            return item;
        }

        public static BLD_ReleaceReward ReadBLD_ReleaceReward(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BLD_ReleaceReward();
            item.Id = itemId;
            item.Releace001 = BitConverter.ToUInt16(file, itemOffset);
            item.Releace002 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Releace003 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Releace004 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Releace005 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Releace006 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Releace007 = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static BTL_Ai ReadBTL_Ai(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Ai();
            item.Id = itemId;
            item.Script = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static BTL_Arts_Bl ReadBTL_Arts_Bl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_Bl();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 6);
            item.WpnType = file[itemOffset + 8];
            item.CmnBlType = file[itemOffset + 9];
            item.SpLv = file[itemOffset + 10];
            item.ActNo = file[itemOffset + 11];
            item.MoveRev = file[itemOffset + 12];
            item.LoopNum = file[itemOffset + 13];
            item.ArtsType = file[itemOffset + 14];
            item.ArtsBuff = file[itemOffset + 15];
            item.ArtsDeBuff = file[itemOffset + 16];
            item.CircleID = file[itemOffset + 17];
            item.Flag = file[itemOffset + 18];
            item.Target = file[itemOffset + 19];
            item.Distance = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Multi = file[itemOffset + 22];
            item.RangeType = file[itemOffset + 23];
            item.Radius = BitConverter.ToUInt16(file, itemOffset + 24);
            item.Length = BitConverter.ToUInt16(file, itemOffset + 26);
            item.Atr = file[itemOffset + 28];
            item.Hate = (sbyte)file[itemOffset + 29];
            item.HitRevise = (sbyte)file[itemOffset + 30];
            item.CriRevise = (sbyte)file[itemOffset + 31];
            item.BulletID = BitConverter.ToUInt16(file, itemOffset + 32);
            item.BulletEffID = BitConverter.ToUInt16(file, itemOffset + 34);
            item.EfpType = file[itemOffset + 36];
            item.BulletNum = file[itemOffset + 37];
            item.BulletAngle = file[itemOffset + 38];
            item.HitFrm1 = file[itemOffset + 39];
            item.HitFrm2 = file[itemOffset + 40];
            item.HitFrm3 = file[itemOffset + 41];
            item.HitFrm4 = file[itemOffset + 42];
            item.HitFrm5 = file[itemOffset + 43];
            item.HitFrm6 = file[itemOffset + 44];
            item.HitFrm7 = file[itemOffset + 45];
            item.HitFrm8 = file[itemOffset + 46];
            item.HitFrm9 = file[itemOffset + 47];
            item.HitFrm10 = file[itemOffset + 48];
            item.HitFrm11 = file[itemOffset + 49];
            item.HitFrm12 = file[itemOffset + 50];
            item.HitFrm13 = file[itemOffset + 51];
            item.HitFrm14 = file[itemOffset + 52];
            item.HitFrm15 = file[itemOffset + 53];
            item.HitFrm16 = file[itemOffset + 54];
            item.Efp1 = file[itemOffset + 55];
            item.Efp2 = file[itemOffset + 56];
            item.Efp3 = file[itemOffset + 57];
            item.Efp4 = file[itemOffset + 58];
            item.Efp5 = file[itemOffset + 59];
            item.Efp6 = file[itemOffset + 60];
            item.Efp7 = file[itemOffset + 61];
            item.Efp8 = file[itemOffset + 62];
            item.Efp9 = file[itemOffset + 63];
            item.Efp10 = file[itemOffset + 64];
            item.Efp11 = file[itemOffset + 65];
            item.Efp12 = file[itemOffset + 66];
            item.Efp13 = file[itemOffset + 67];
            item.Efp14 = file[itemOffset + 68];
            item.Efp15 = file[itemOffset + 69];
            item.Efp16 = file[itemOffset + 70];
            item.HitDirID1 = file[itemOffset + 71];
            item.HitDirID2 = file[itemOffset + 72];
            item.HitDirID3 = file[itemOffset + 73];
            item.HitDirID4 = file[itemOffset + 74];
            item.HitDirID5 = file[itemOffset + 75];
            item.HitDirID6 = file[itemOffset + 76];
            item.HitDirID7 = file[itemOffset + 77];
            item.HitDirID8 = file[itemOffset + 78];
            item.HitDirID9 = file[itemOffset + 79];
            item.HitDirID10 = file[itemOffset + 80];
            item.HitDirID11 = file[itemOffset + 81];
            item.HitDirID12 = file[itemOffset + 82];
            item.HitDirID13 = file[itemOffset + 83];
            item.HitDirID14 = file[itemOffset + 84];
            item.HitDirID15 = file[itemOffset + 85];
            item.HitDirID16 = file[itemOffset + 86];
            item.DmgRt1 = file[itemOffset + 87];
            item.DmgRt2 = file[itemOffset + 88];
            item.DmgRt3 = file[itemOffset + 89];
            item.DmgRt4 = file[itemOffset + 90];
            item.DmgRt5 = file[itemOffset + 91];
            item.DmgRt6 = file[itemOffset + 92];
            item.DmgRt7 = file[itemOffset + 93];
            item.DmgRt8 = file[itemOffset + 94];
            item.DmgRt9 = file[itemOffset + 95];
            item.DmgRt10 = file[itemOffset + 96];
            item.DmgRt11 = file[itemOffset + 97];
            item.DmgRt12 = file[itemOffset + 98];
            item.DmgRt13 = file[itemOffset + 99];
            item.DmgRt14 = file[itemOffset + 100];
            item.DmgRt15 = file[itemOffset + 101];
            item.DmgRt16 = file[itemOffset + 102];
            item.ReAct1 = file[itemOffset + 103];
            item.ReAct2 = file[itemOffset + 104];
            item.ReAct3 = file[itemOffset + 105];
            item.ReAct4 = file[itemOffset + 106];
            item.ReAct5 = file[itemOffset + 107];
            item.ReAct6 = file[itemOffset + 108];
            item.ReAct7 = file[itemOffset + 109];
            item.ReAct8 = file[itemOffset + 110];
            item.ReAct9 = file[itemOffset + 111];
            item.ReAct10 = file[itemOffset + 112];
            item.ReAct11 = file[itemOffset + 113];
            item.ReAct12 = file[itemOffset + 114];
            item.ReAct13 = file[itemOffset + 115];
            item.ReAct14 = file[itemOffset + 116];
            item.ReAct15 = file[itemOffset + 117];
            item.ReAct16 = file[itemOffset + 118];
            item.DmgMgn1 = BitConverter.ToUInt16(file, itemOffset + 119);
            item.DmgMgn2 = BitConverter.ToUInt16(file, itemOffset + 121);
            item.DmgMgn3 = BitConverter.ToUInt16(file, itemOffset + 123);
            item.DmgMgn4 = BitConverter.ToUInt16(file, itemOffset + 125);
            item.DmgMgn5 = BitConverter.ToUInt16(file, itemOffset + 127);
            item.DmgMgn6 = BitConverter.ToUInt16(file, itemOffset + 129);
            item.AtrNum = file[itemOffset + 131];
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 132);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 134);
            item.Enhance3 = BitConverter.ToUInt16(file, itemOffset + 136);
            item.Enhance4 = BitConverter.ToUInt16(file, itemOffset + 138);
            item.Enhance5 = BitConverter.ToUInt16(file, itemOffset + 140);
            item.Enhance6 = BitConverter.ToUInt16(file, itemOffset + 142);
            item.BtnType = file[itemOffset + 144];
            item.BtnChal1 = BitConverter.ToUInt16(file, itemOffset + 145);
            item.UI = BitConverter.ToUInt16(file, itemOffset + 147);
            item.AtrEff1S = file[itemOffset + 149];
            item.AtrEff1E = file[itemOffset + 150];
            item.AtrEff1Ca = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 151));
            item.AtrEff2S = file[itemOffset + 155];
            item.AtrEff2E = file[itemOffset + 156];
            item.AtrEff2Ca = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 157));
            item.AtrEffArtsCa = file[itemOffset + 161];
            item.HitEff = BitConverter.ToUInt16(file, itemOffset + 162);
            item.VoiceNum = file[itemOffset + 164];
            item.VoiceDelay = BitConverter.ToUInt16(file, itemOffset + 165);
            item.SeNum = file[itemOffset + 167];
            item.GravOffNum = file[itemOffset + 168];
            item.GravOffF = BitConverter.ToUInt16(file, itemOffset + 169);
            item.GravOnNum = file[itemOffset + 171];
            item.GravOnF = BitConverter.ToUInt16(file, itemOffset + 172);
            item.DynSlowRev = BitConverter.ToUInt16(file, itemOffset + 174);
            item.common = (item.Flag & 1) != 0;
            item.Pierce = (item.Flag & 2) != 0;
            item.NoMove = (item.Flag & 4) != 0;
            item.NoColli = (item.Flag & 8) != 0;
            item.NoWpn = (item.Flag & 16) != 0;
            item.Return = (item.Flag & 32) != 0;
            item.Shoot = (item.Flag & 64) != 0;
            item.HitfD = (item.Flag & 128) != 0;
            return item;
        }

        public static BTL_Arts_Bl_Cam ReadBTL_Arts_Bl_Cam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_Bl_Cam();
            item.Id = itemId;
            item.Camera1 = file[itemOffset];
            item.Camera2 = file[itemOffset + 1];
            item.Camera3 = file[itemOffset + 2];
            item.Camera4 = file[itemOffset + 3];
            item.Camera5 = file[itemOffset + 4];
            item.Camera6 = file[itemOffset + 5];
            item.Camera7 = file[itemOffset + 6];
            item.Flag = file[itemOffset + 7];
            item.EnTarget = (item.Flag & 1) != 0;
            return item;
        }

        public static BTL_Arts_BlSp ReadBTL_Arts_BlSp(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_BlSp();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 6);
            item.WpnType = file[itemOffset + 8];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 9);
            item.CmnBlType = file[itemOffset + 11];
            item.ActNoDr = file[itemOffset + 12];
            item.ActNoBl = file[itemOffset + 13];
            item.ActNoBl2 = file[itemOffset + 14];
            item.MoveRev = file[itemOffset + 15];
            item.BuddyDr = file[itemOffset + 16];
            item.AddBl = BitConverter.ToUInt16(file, itemOffset + 17);
            item.ActType = file[itemOffset + 19];
            item.PC01 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.PC02 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.PC03 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.PC06 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.ArtsType = file[itemOffset + 28];
            item.ArtsBuff = file[itemOffset + 29];
            item.Flag = BitConverter.ToUInt16(file, itemOffset + 30);
            item.Target = file[itemOffset + 32];
            item.Distance = BitConverter.ToUInt16(file, itemOffset + 33);
            item.Multi = file[itemOffset + 35];
            item.RangeType = file[itemOffset + 36];
            item.Radius = BitConverter.ToUInt16(file, itemOffset + 37);
            item.Length = BitConverter.ToUInt16(file, itemOffset + 39);
            item.Atr = file[itemOffset + 41];
            item.Hate = (sbyte)file[itemOffset + 42];
            item.HitRevise = (sbyte)file[itemOffset + 43];
            item.CriRevise = (sbyte)file[itemOffset + 44];
            item.BulletID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.BulletEffID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.EfpType = file[itemOffset + 49];
            item.BulletNum = file[itemOffset + 50];
            item.BulletAngle = file[itemOffset + 51];
            item.HitFrm1 = file[itemOffset + 52];
            item.HitFrm2 = file[itemOffset + 53];
            item.HitFrm3 = file[itemOffset + 54];
            item.HitFrm4 = file[itemOffset + 55];
            item.HitFrm5 = file[itemOffset + 56];
            item.HitFrm6 = file[itemOffset + 57];
            item.HitFrm7 = file[itemOffset + 58];
            item.HitFrm8 = file[itemOffset + 59];
            item.HitFrm9 = file[itemOffset + 60];
            item.HitFrm10 = file[itemOffset + 61];
            item.HitFrm11 = file[itemOffset + 62];
            item.HitFrm12 = file[itemOffset + 63];
            item.HitFrm13 = file[itemOffset + 64];
            item.HitFrm14 = file[itemOffset + 65];
            item.HitFrm15 = file[itemOffset + 66];
            item.HitFrm16 = file[itemOffset + 67];
            item.Efp1 = file[itemOffset + 68];
            item.Efp2 = file[itemOffset + 69];
            item.Efp3 = file[itemOffset + 70];
            item.Efp4 = file[itemOffset + 71];
            item.Efp5 = file[itemOffset + 72];
            item.Efp6 = file[itemOffset + 73];
            item.Efp7 = file[itemOffset + 74];
            item.Efp8 = file[itemOffset + 75];
            item.Efp9 = file[itemOffset + 76];
            item.Efp10 = file[itemOffset + 77];
            item.Efp11 = file[itemOffset + 78];
            item.Efp12 = file[itemOffset + 79];
            item.Efp13 = file[itemOffset + 80];
            item.Efp14 = file[itemOffset + 81];
            item.Efp15 = file[itemOffset + 82];
            item.Efp16 = file[itemOffset + 83];
            item.HitDirID1 = file[itemOffset + 84];
            item.HitDirID2 = file[itemOffset + 85];
            item.HitDirID3 = file[itemOffset + 86];
            item.HitDirID4 = file[itemOffset + 87];
            item.HitDirID5 = file[itemOffset + 88];
            item.HitDirID6 = file[itemOffset + 89];
            item.HitDirID7 = file[itemOffset + 90];
            item.HitDirID8 = file[itemOffset + 91];
            item.HitDirID9 = file[itemOffset + 92];
            item.HitDirID10 = file[itemOffset + 93];
            item.HitDirID11 = file[itemOffset + 94];
            item.HitDirID12 = file[itemOffset + 95];
            item.HitDirID13 = file[itemOffset + 96];
            item.HitDirID14 = file[itemOffset + 97];
            item.HitDirID15 = file[itemOffset + 98];
            item.HitDirID16 = file[itemOffset + 99];
            item.DmgRt1 = file[itemOffset + 100];
            item.DmgRt2 = file[itemOffset + 101];
            item.DmgRt3 = file[itemOffset + 102];
            item.DmgRt4 = file[itemOffset + 103];
            item.DmgRt5 = file[itemOffset + 104];
            item.DmgRt6 = file[itemOffset + 105];
            item.DmgRt7 = file[itemOffset + 106];
            item.DmgRt8 = file[itemOffset + 107];
            item.DmgRt9 = file[itemOffset + 108];
            item.DmgRt10 = file[itemOffset + 109];
            item.DmgRt11 = file[itemOffset + 110];
            item.DmgRt12 = file[itemOffset + 111];
            item.DmgRt13 = file[itemOffset + 112];
            item.DmgRt14 = file[itemOffset + 113];
            item.DmgRt15 = file[itemOffset + 114];
            item.DmgRt16 = file[itemOffset + 115];
            item.ReAct1 = file[itemOffset + 116];
            item.ReAct2 = file[itemOffset + 117];
            item.ReAct3 = file[itemOffset + 118];
            item.ReAct4 = file[itemOffset + 119];
            item.ReAct5 = file[itemOffset + 120];
            item.ReAct6 = file[itemOffset + 121];
            item.ReAct7 = file[itemOffset + 122];
            item.ReAct8 = file[itemOffset + 123];
            item.ReAct9 = file[itemOffset + 124];
            item.ReAct10 = file[itemOffset + 125];
            item.ReAct11 = file[itemOffset + 126];
            item.ReAct12 = file[itemOffset + 127];
            item.ReAct13 = file[itemOffset + 128];
            item.ReAct14 = file[itemOffset + 129];
            item.ReAct15 = file[itemOffset + 130];
            item.ReAct16 = file[itemOffset + 131];
            item.DmgMgn = BitConverter.ToUInt16(file, itemOffset + 132);
            item.Recast = BitConverter.ToUInt16(file, itemOffset + 134);
            item.AtrNum = file[itemOffset + 136];
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 137);
            item.BtnType = file[itemOffset + 139];
            item.BtnChal1 = BitConverter.ToUInt16(file, itemOffset + 140);
            item.BtnChal2 = BitConverter.ToUInt16(file, itemOffset + 142);
            item.BtnChal3 = BitConverter.ToUInt16(file, itemOffset + 144);
            item.BtnChal6 = BitConverter.ToUInt16(file, itemOffset + 146);
            item.Camera1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 148));
            item.Camera2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 152));
            item.Camera3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 156));
            item.CameraCT1 = BitConverter.ToUInt16(file, itemOffset + 160);
            item.CameraCT2 = BitConverter.ToUInt16(file, itemOffset + 162);
            item.CameraEndf = file[itemOffset + 164];
            item.SlowDirection = BitConverter.ToUInt16(file, itemOffset + 165);
            item.HitEff = BitConverter.ToUInt16(file, itemOffset + 167);
            item.VoiceSet = BitConverter.ToUInt16(file, itemOffset + 169);
            item.SeNum = file[itemOffset + 171];
            item.GravOffNum = file[itemOffset + 172];
            item.GravOffF = BitConverter.ToUInt16(file, itemOffset + 173);
            item.GravOnNum = file[itemOffset + 175];
            item.GravOnF = BitConverter.ToUInt16(file, itemOffset + 176);
            item.Pierce = (item.Flag & 1) != 0;
            item.NoMove = (item.Flag & 2) != 0;
            item.NoColli = (item.Flag & 4) != 0;
            item.NoWpn = (item.Flag & 8) != 0;
            item.Return = (item.Flag & 16) != 0;
            item.TransWpn = (item.Flag & 32) != 0;
            item.Fcombo = (item.Flag & 64) != 0;
            item.NoPraise = (item.Flag & 128) != 0;
            item.Shoot = (item.Flag & 256) != 0;
            item.HitfD = (item.Flag & 512) != 0;
            return item;
        }

        public static BTL_Arts_BlSpVo ReadBTL_Arts_BlSpVo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_BlSpVo();
            item.Id = itemId;
            item.Talker1 = file[itemOffset];
            item.MotionNum1 = file[itemOffset + 1];
            item.Motionf1 = BitConverter.ToInt16(file, itemOffset + 2);
            item.VoiceNum1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Talker2 = file[itemOffset + 6];
            item.MotionNum2 = file[itemOffset + 7];
            item.Motionf2 = BitConverter.ToInt16(file, itemOffset + 8);
            item.VoiceNum2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Talker3 = file[itemOffset + 12];
            item.MotionNum3 = file[itemOffset + 13];
            item.Motionf3 = BitConverter.ToInt16(file, itemOffset + 14);
            item.VoiceNum3 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Talker4 = file[itemOffset + 18];
            item.MotionNum4 = file[itemOffset + 19];
            item.Motionf4 = BitConverter.ToInt16(file, itemOffset + 20);
            item.VoiceNum4 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Talker5 = file[itemOffset + 24];
            item.MotionNum5 = file[itemOffset + 25];
            item.Motionf5 = BitConverter.ToInt16(file, itemOffset + 26);
            item.VoiceNum5 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.Talker6 = file[itemOffset + 30];
            item.MotionNum6 = file[itemOffset + 31];
            item.Motionf6 = BitConverter.ToInt16(file, itemOffset + 32);
            item.VoiceNum6 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.Talker7 = file[itemOffset + 36];
            item.MotionNum7 = file[itemOffset + 37];
            item.Motionf7 = BitConverter.ToInt16(file, itemOffset + 38);
            item.VoiceNum7 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.Talker8 = file[itemOffset + 42];
            item.MotionNum8 = file[itemOffset + 43];
            item.Motionf8 = BitConverter.ToInt16(file, itemOffset + 44);
            item.VoiceNum8 = BitConverter.ToUInt16(file, itemOffset + 46);
            return item;
        }

        public static BTL_Arts_Dr ReadBTL_Arts_Dr(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_Dr();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Driver = file[itemOffset + 8];
            item.WpnType = file[itemOffset + 9];
            item.IrType = file[itemOffset + 10];
            item.Condition = file[itemOffset + 11];
            item.ActNo = file[itemOffset + 12];
            item.ActSpeed = file[itemOffset + 13];
            item.MoveRev = file[itemOffset + 14];
            item.LoopNum = file[itemOffset + 15];
            item.IKStNo = file[itemOffset + 16];
            item.IKStf = file[itemOffset + 17];
            item.IKEndNo = file[itemOffset + 18];
            item.IKEndf = file[itemOffset + 19];
            item.ArtsType = file[itemOffset + 20];
            item.ArtsBuff = file[itemOffset + 21];
            item.ArtsDeBuff = file[itemOffset + 22];
            item.AtrType = file[itemOffset + 23];
            item.Flag = file[itemOffset + 24];
            item.NextArts = BitConverter.ToUInt16(file, itemOffset + 25);
            item.Target = file[itemOffset + 27];
            item.Distance = BitConverter.ToUInt16(file, itemOffset + 28);
            item.Multi = file[itemOffset + 30];
            item.RangeType = file[itemOffset + 31];
            item.Radius = BitConverter.ToUInt16(file, itemOffset + 32);
            item.Length = BitConverter.ToUInt16(file, itemOffset + 34);
            item.Hate = (sbyte)file[itemOffset + 36];
            item.HitRevise = (sbyte)file[itemOffset + 37];
            item.CriRevise = (sbyte)file[itemOffset + 38];
            item.BulletID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.BulletEffID = BitConverter.ToUInt16(file, itemOffset + 41);
            item.EfpType = file[itemOffset + 43];
            item.BulletNum = file[itemOffset + 44];
            item.BulletAngle = file[itemOffset + 45];
            item.HitFrm1 = file[itemOffset + 46];
            item.HitFrm2 = file[itemOffset + 47];
            item.HitFrm3 = file[itemOffset + 48];
            item.HitFrm4 = file[itemOffset + 49];
            item.HitFrm5 = file[itemOffset + 50];
            item.HitFrm6 = file[itemOffset + 51];
            item.HitFrm7 = file[itemOffset + 52];
            item.HitFrm8 = file[itemOffset + 53];
            item.HitFrm9 = file[itemOffset + 54];
            item.HitFrm10 = file[itemOffset + 55];
            item.HitFrm11 = file[itemOffset + 56];
            item.HitFrm12 = file[itemOffset + 57];
            item.HitFrm13 = file[itemOffset + 58];
            item.HitFrm14 = file[itemOffset + 59];
            item.HitFrm15 = file[itemOffset + 60];
            item.HitFrm16 = file[itemOffset + 61];
            item.Efp1 = file[itemOffset + 62];
            item.Efp2 = file[itemOffset + 63];
            item.Efp3 = file[itemOffset + 64];
            item.Efp4 = file[itemOffset + 65];
            item.Efp5 = file[itemOffset + 66];
            item.Efp6 = file[itemOffset + 67];
            item.Efp7 = file[itemOffset + 68];
            item.Efp8 = file[itemOffset + 69];
            item.Efp9 = file[itemOffset + 70];
            item.Efp10 = file[itemOffset + 71];
            item.Efp11 = file[itemOffset + 72];
            item.Efp12 = file[itemOffset + 73];
            item.Efp13 = file[itemOffset + 74];
            item.Efp14 = file[itemOffset + 75];
            item.Efp15 = file[itemOffset + 76];
            item.Efp16 = file[itemOffset + 77];
            item.HitDirID1 = file[itemOffset + 78];
            item.HitDirID2 = file[itemOffset + 79];
            item.HitDirID3 = file[itemOffset + 80];
            item.HitDirID4 = file[itemOffset + 81];
            item.HitDirID5 = file[itemOffset + 82];
            item.HitDirID6 = file[itemOffset + 83];
            item.HitDirID7 = file[itemOffset + 84];
            item.HitDirID8 = file[itemOffset + 85];
            item.HitDirID9 = file[itemOffset + 86];
            item.HitDirID10 = file[itemOffset + 87];
            item.HitDirID11 = file[itemOffset + 88];
            item.HitDirID12 = file[itemOffset + 89];
            item.HitDirID13 = file[itemOffset + 90];
            item.HitDirID14 = file[itemOffset + 91];
            item.HitDirID15 = file[itemOffset + 92];
            item.HitDirID16 = file[itemOffset + 93];
            item.DmgRt1 = file[itemOffset + 94];
            item.DmgRt2 = file[itemOffset + 95];
            item.DmgRt3 = file[itemOffset + 96];
            item.DmgRt4 = file[itemOffset + 97];
            item.DmgRt5 = file[itemOffset + 98];
            item.DmgRt6 = file[itemOffset + 99];
            item.DmgRt7 = file[itemOffset + 100];
            item.DmgRt8 = file[itemOffset + 101];
            item.DmgRt9 = file[itemOffset + 102];
            item.DmgRt10 = file[itemOffset + 103];
            item.DmgRt11 = file[itemOffset + 104];
            item.DmgRt12 = file[itemOffset + 105];
            item.DmgRt13 = file[itemOffset + 106];
            item.DmgRt14 = file[itemOffset + 107];
            item.DmgRt15 = file[itemOffset + 108];
            item.DmgRt16 = file[itemOffset + 109];
            item.ReAct1 = file[itemOffset + 110];
            item.ReAct2 = file[itemOffset + 111];
            item.ReAct3 = file[itemOffset + 112];
            item.ReAct4 = file[itemOffset + 113];
            item.ReAct5 = file[itemOffset + 114];
            item.ReAct6 = file[itemOffset + 115];
            item.ReAct7 = file[itemOffset + 116];
            item.ReAct8 = file[itemOffset + 117];
            item.ReAct9 = file[itemOffset + 118];
            item.ReAct10 = file[itemOffset + 119];
            item.ReAct11 = file[itemOffset + 120];
            item.ReAct12 = file[itemOffset + 121];
            item.ReAct13 = file[itemOffset + 122];
            item.ReAct14 = file[itemOffset + 123];
            item.ReAct15 = file[itemOffset + 124];
            item.ReAct16 = file[itemOffset + 125];
            item.MoveCancelFrm = file[itemOffset + 126];
            item.DmgMgn1 = BitConverter.ToUInt16(file, itemOffset + 127);
            item.DmgMgn2 = BitConverter.ToUInt16(file, itemOffset + 129);
            item.DmgMgn3 = BitConverter.ToUInt16(file, itemOffset + 131);
            item.DmgMgn4 = BitConverter.ToUInt16(file, itemOffset + 133);
            item.DmgMgn5 = BitConverter.ToUInt16(file, itemOffset + 135);
            item.DmgMgn6 = BitConverter.ToUInt16(file, itemOffset + 137);
            item.Recast1 = BitConverter.ToUInt16(file, itemOffset + 139);
            item.Recast2 = BitConverter.ToUInt16(file, itemOffset + 141);
            item.Recast3 = BitConverter.ToUInt16(file, itemOffset + 143);
            item.Recast4 = BitConverter.ToUInt16(file, itemOffset + 145);
            item.Recast5 = BitConverter.ToUInt16(file, itemOffset + 147);
            item.Recast6 = BitConverter.ToUInt16(file, itemOffset + 149);
            item.AtrNum = file[itemOffset + 151];
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 152);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 154);
            item.Enhance3 = BitConverter.ToUInt16(file, itemOffset + 156);
            item.Enhance4 = BitConverter.ToUInt16(file, itemOffset + 158);
            item.Enhance5 = BitConverter.ToUInt16(file, itemOffset + 160);
            item.Enhance6 = BitConverter.ToUInt16(file, itemOffset + 162);
            item.ReleaseLv1 = file[itemOffset + 164];
            item.ReleaseLv2 = file[itemOffset + 165];
            item.ReleaseLv3 = file[itemOffset + 166];
            item.ReleaseLv4 = file[itemOffset + 167];
            item.ReleaseLv5 = file[itemOffset + 168];
            item.NeedWP2 = BitConverter.ToUInt16(file, itemOffset + 169);
            item.NeedWP3 = BitConverter.ToUInt16(file, itemOffset + 171);
            item.NeedWP4 = BitConverter.ToUInt16(file, itemOffset + 173);
            item.NeedWP5 = BitConverter.ToUInt16(file, itemOffset + 175);
            item.HitEff = BitConverter.ToUInt16(file, itemOffset + 177);
            item.VoiceNum = file[itemOffset + 179];
            item.VoiceNum2 = BitConverter.ToUInt16(file, itemOffset + 180);
            item.VoiceDelay = BitConverter.ToUInt16(file, itemOffset + 182);
            item.UI = BitConverter.ToUInt16(file, itemOffset + 184);
            item.Priority = file[itemOffset + 186];
            item.GravOffNum = file[itemOffset + 187];
            item.GravOffF = BitConverter.ToUInt16(file, itemOffset + 188);
            item.GravOnNum = file[itemOffset + 190];
            item.GravOnF = BitConverter.ToUInt16(file, itemOffset + 191);
            item.Normal = (item.Flag & 1) != 0;
            item.Pierce = (item.Flag & 2) != 0;
            item.NoRepelled = (item.Flag & 4) != 0;
            item.NoMove = (item.Flag & 8) != 0;
            item.SArmor1 = (item.Flag & 16) != 0;
            item.SArmor2 = (item.Flag & 32) != 0;
            item.NoColli = (item.Flag & 64) != 0;
            return item;
        }

        public static BTL_Arts_En ReadBTL_Arts_En(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Arts_En();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.WpnNo = file[itemOffset + 6];
            item.ActNo = file[itemOffset + 7];
            item.ArtsType = file[itemOffset + 8];
            item.ArtsBuff = file[itemOffset + 9];
            item.ArtsDeBuff = file[itemOffset + 10];
            item.Flag = BitConverter.ToUInt32(file, itemOffset + 11);
            item.MoveRev = file[itemOffset + 15];
            item.NextArts = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Target = file[itemOffset + 18];
            item.RotAssist = file[itemOffset + 19];
            item.Distance = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Multi = file[itemOffset + 22];
            item.RangeType = file[itemOffset + 23];
            item.Radius = BitConverter.ToUInt16(file, itemOffset + 24);
            item.Length = BitConverter.ToUInt16(file, itemOffset + 26);
            item.Atr = file[itemOffset + 28];
            item.HitRevise = (sbyte)file[itemOffset + 29];
            item.CriRevise = (sbyte)file[itemOffset + 30];
            item.BulletID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.BulletEffID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.EfpType = file[itemOffset + 35];
            item.BulletNum = file[itemOffset + 36];
            item.LoopNum = file[itemOffset + 37];
            item.BulletAngle = file[itemOffset + 38];
            item.HitFrm1 = file[itemOffset + 39];
            item.HitFrm2 = file[itemOffset + 40];
            item.HitFrm3 = file[itemOffset + 41];
            item.HitFrm4 = file[itemOffset + 42];
            item.HitFrm5 = file[itemOffset + 43];
            item.HitFrm6 = file[itemOffset + 44];
            item.HitFrm7 = file[itemOffset + 45];
            item.HitFrm8 = file[itemOffset + 46];
            item.HitFrm9 = file[itemOffset + 47];
            item.HitFrm10 = file[itemOffset + 48];
            item.HitFrm11 = file[itemOffset + 49];
            item.HitFrm12 = file[itemOffset + 50];
            item.HitFrm13 = file[itemOffset + 51];
            item.HitFrm14 = file[itemOffset + 52];
            item.HitFrm15 = file[itemOffset + 53];
            item.HitFrm16 = file[itemOffset + 54];
            item.Efp1 = file[itemOffset + 55];
            item.Efp2 = file[itemOffset + 56];
            item.Efp3 = file[itemOffset + 57];
            item.Efp4 = file[itemOffset + 58];
            item.Efp5 = file[itemOffset + 59];
            item.Efp6 = file[itemOffset + 60];
            item.Efp7 = file[itemOffset + 61];
            item.Efp8 = file[itemOffset + 62];
            item.Efp9 = file[itemOffset + 63];
            item.Efp10 = file[itemOffset + 64];
            item.Efp11 = file[itemOffset + 65];
            item.Efp12 = file[itemOffset + 66];
            item.Efp13 = file[itemOffset + 67];
            item.Efp14 = file[itemOffset + 68];
            item.Efp15 = file[itemOffset + 69];
            item.Efp16 = file[itemOffset + 70];
            item.DmgRt1 = file[itemOffset + 71];
            item.DmgRt2 = file[itemOffset + 72];
            item.DmgRt3 = file[itemOffset + 73];
            item.DmgRt4 = file[itemOffset + 74];
            item.DmgRt5 = file[itemOffset + 75];
            item.DmgRt6 = file[itemOffset + 76];
            item.DmgRt7 = file[itemOffset + 77];
            item.DmgRt8 = file[itemOffset + 78];
            item.DmgRt9 = file[itemOffset + 79];
            item.DmgRt10 = file[itemOffset + 80];
            item.DmgRt11 = file[itemOffset + 81];
            item.DmgRt12 = file[itemOffset + 82];
            item.DmgRt13 = file[itemOffset + 83];
            item.DmgRt14 = file[itemOffset + 84];
            item.DmgRt15 = file[itemOffset + 85];
            item.DmgRt16 = file[itemOffset + 86];
            item.ReAct1 = file[itemOffset + 87];
            item.ReAct2 = file[itemOffset + 88];
            item.ReAct3 = file[itemOffset + 89];
            item.ReAct4 = file[itemOffset + 90];
            item.ReAct5 = file[itemOffset + 91];
            item.ReAct6 = file[itemOffset + 92];
            item.ReAct7 = file[itemOffset + 93];
            item.ReAct8 = file[itemOffset + 94];
            item.ReAct9 = file[itemOffset + 95];
            item.ReAct10 = file[itemOffset + 96];
            item.ReAct11 = file[itemOffset + 97];
            item.ReAct12 = file[itemOffset + 98];
            item.ReAct13 = file[itemOffset + 99];
            item.ReAct14 = file[itemOffset + 100];
            item.ReAct15 = file[itemOffset + 101];
            item.ReAct16 = file[itemOffset + 102];
            item.DmgMgn = BitConverter.ToUInt16(file, itemOffset + 103);
            item.Recast = BitConverter.ToUInt16(file, itemOffset + 105);
            item.StartRecast = (sbyte)file[itemOffset + 107];
            item.AtrNum = file[itemOffset + 108];
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 109);
            item.HitEff = BitConverter.ToUInt16(file, itemOffset + 111);
            item.Summon = BitConverter.ToUInt16(file, itemOffset + 113);
            item.CircleID = file[itemOffset + 115];
            item.VoiceNum = file[itemOffset + 116];
            item.VoiceDelay = BitConverter.ToUInt16(file, itemOffset + 117);
            item.SeSlot = BitConverter.ToUInt16(file, itemOffset + 119);
            item.SeNum = file[itemOffset + 121];
            item.Normal = (item.Flag & 1) != 0;
            item.DoLast = (item.Flag & 2) != 0;
            item.Pierce = (item.Flag & 4) != 0;
            item.Fcombo = (item.Flag & 8) != 0;
            item.NoRepelled = (item.Flag & 16) != 0;
            item.NoTarget = (item.Flag & 32) != 0;
            item.NoMove = (item.Flag & 64) != 0;
            item.SArmor1 = (item.Flag & 128) != 0;
            item.SArmor2 = (item.Flag & 256) != 0;
            item.AtrSe = (item.Flag & 512) != 0;
            item.NoColli = (item.Flag & 1024) != 0;
            item.ColliDown = (item.Flag & 2048) != 0;
            item.Shoot = (item.Flag & 4096) != 0;
            item.BackAtk = (item.Flag & 8192) != 0;
            item.MyBom = (item.Flag & 16384) != 0;
            item.CallEnemy = (item.Flag & 32768) != 0;
            item.Vision = (item.Flag & 65536) != 0;
            return item;
        }

        public static BTL_ArtsDirection ReadBTL_ArtsDirection(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ArtsDirection();
            item.Id = itemId;
            item.MotionNo1 = file[itemOffset];
            item.Startf1 = BitConverter.ToUInt16(file, itemOffset + 1);
            item.Keepf1 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.SlowRate1 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.MotionNo2 = file[itemOffset + 7];
            item.Startf2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Keepf2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.SlowRate2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.MotionNo3 = file[itemOffset + 14];
            item.Startf3 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.Keepf3 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.SlowRate3 = BitConverter.ToUInt16(file, itemOffset + 19);
            item.MotionNo4 = file[itemOffset + 21];
            item.Startf4 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Keepf4 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.SlowRate4 = BitConverter.ToUInt16(file, itemOffset + 26);
            return item;
        }

        public static BTL_Aura ReadBTL_Aura(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Aura();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Enhance3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ChangeAtr = file[itemOffset + 12];
            return item;
        }

        public static BTL_BallBreak ReadBTL_BallBreak(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_BallBreak();
            item.Id = itemId;
            item.DamageRate = BitConverter.ToUInt16(file, itemOffset);
            item.FBGauge = BitConverter.ToUInt16(file, itemOffset + 2);
            item.FBBonus = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static BTL_Bl_KizunaBase ReadBTL_Bl_KizunaBase(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bl_KizunaBase();
            item.Id = itemId;
            item.KizunaDef = BitConverter.ToUInt16(file, itemOffset);
            item.KizunaUpRev = (sbyte)file[itemOffset + 2];
            item.KizunaDownRev = (sbyte)file[itemOffset + 3];
            return item;
        }

        public static BTL_Bl_KizunaLink ReadBTL_Bl_KizunaLink(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bl_KizunaLink();
            item.Id = itemId;
            item.LinkNum = BitConverter.ToUInt16(file, itemOffset);
            item.DeadNum = BitConverter.ToUInt16(file, itemOffset + 2);
            item.AppStNum = BitConverter.ToUInt16(file, itemOffset + 4);
            item.AppEndNum = BitConverter.ToUInt16(file, itemOffset + 6);
            item.SpActType = file[itemOffset + 8];
            item.SpActNum = file[itemOffset + 9];
            item.SpActf = BitConverter.ToUInt16(file, itemOffset + 10);
            item.StandDir = file[itemOffset + 12];
            item.AppCond = file[itemOffset + 13];
            item.AppCondNum = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ReJudgef = file[itemOffset + 16];
            return item;
        }

        public static BTL_Bl_KizunaLinkSet ReadBTL_Bl_KizunaLinkSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bl_KizunaLinkSet();
            item.Id = itemId;
            item.KizunaLink1 = BitConverter.ToUInt16(file, itemOffset);
            item.KizunaLink2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.LinkChType = BitConverter.ToUInt16(file, itemOffset + 4);
            item.LinkChNum = BitConverter.ToUInt16(file, itemOffset + 6);
            item.VoiceID = file[itemOffset + 8];
            return item;
        }

        public static BTL_Bl_KizunaUpDown ReadBTL_Bl_KizunaUpDown(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bl_KizunaUpDown();
            item.Id = itemId;
            item.ParamE = BitConverter.ToInt16(file, itemOffset);
            item.ParamD = BitConverter.ToInt16(file, itemOffset + 2);
            item.ParamC = BitConverter.ToInt16(file, itemOffset + 4);
            item.ParamB = BitConverter.ToInt16(file, itemOffset + 6);
            item.ParamA = BitConverter.ToInt16(file, itemOffset + 8);
            item.ParamS = BitConverter.ToInt16(file, itemOffset + 10);
            item.ParamS1 = BitConverter.ToInt16(file, itemOffset + 12);
            item.ParamS2 = BitConverter.ToInt16(file, itemOffset + 14);
            item.ParamS3 = BitConverter.ToInt16(file, itemOffset + 16);
            item.ParamS4 = BitConverter.ToInt16(file, itemOffset + 18);
            item.ParamS5 = BitConverter.ToInt16(file, itemOffset + 20);
            item.ParamS6 = BitConverter.ToInt16(file, itemOffset + 22);
            item.ParamS7 = BitConverter.ToInt16(file, itemOffset + 24);
            item.ParamS8 = BitConverter.ToInt16(file, itemOffset + 26);
            item.ParamS9 = BitConverter.ToInt16(file, itemOffset + 28);
            item.ParamSS = BitConverter.ToInt16(file, itemOffset + 30);
            item.Target = file[itemOffset + 32];
            return item;
        }

        public static BTL_Bl_Personality ReadBTL_Bl_Personality(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bl_Personality();
            item.Id = itemId;
            item.Flag = file[itemOffset];
            item.KizunaBase = file[itemOffset + 1];
            item.VoiceID = file[itemOffset + 2];
            item.BLC_A = file[itemOffset + 3];
            item.BLC_PARAM_A = BitConverter.ToUInt16(file, itemOffset + 4);
            item.BLC_B = file[itemOffset + 6];
            item.BLC_PARAM_B = BitConverter.ToUInt16(file, itemOffset + 7);
            item.BLC_C = BitConverter.ToUInt16(file, itemOffset + 9);
            item.BLC_D = BitConverter.ToUInt16(file, itemOffset + 11);
            item.Custom01 = file[itemOffset + 13];
            item.CustomParam01 = file[itemOffset + 14];
            item.Custom02 = file[itemOffset + 15];
            item.CustomParam02 = file[itemOffset + 16];
            item.Custom03 = file[itemOffset + 17];
            item.CustomParam03 = file[itemOffset + 18];
            item.common = (item.Flag & 1) != 0;
            return item;
        }

        public static BTL_BtnChallenge ReadBTL_BtnChallenge(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_BtnChallenge();
            item.Id = itemId;
            item.Speed = BitConverter.ToUInt16(file, itemOffset);
            item.GSuccess = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Success = BitConverter.ToUInt16(file, itemOffset + 4);
            item.RecastRate = file[itemOffset + 6];
            return item;
        }

        public static BTL_Buff ReadBTL_Buff(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Buff();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.Caption = file[itemOffset + 5];
            item.BaseNum = BitConverter.ToUInt16(file, itemOffset + 6);
            item.BaseTime = BitConverter.ToUInt16(file, itemOffset + 8);
            item.BaseRecast = BitConverter.ToUInt16(file, itemOffset + 10);
            item.BaseProb = file[itemOffset + 12];
            item.Interval = BitConverter.ToUInt16(file, itemOffset + 13);
            item.Effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 15));
            item.VoiceNum = file[itemOffset + 19];
            item.Flag = file[itemOffset + 20];
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 21);
            item.Buff = (item.Flag & 1) != 0;
            item.SE = (item.Flag & 2) != 0;
            return item;
        }

        public static BTL_Bullet ReadBTL_Bullet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Bullet();
            item.Id = itemId;
            item.MoveType = file[itemOffset];
            item.SpdFirst = BitConverter.ToUInt16(file, itemOffset + 1);
            item.SpdLast = BitConverter.ToUInt16(file, itemOffset + 3);
            item.AclStart = BitConverter.ToUInt16(file, itemOffset + 5);
            item.AclEnd = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ExpNum = file[itemOffset + 9];
            item.ExpDelay = file[itemOffset + 10];
            item.BltMaxAng = file[itemOffset + 11];
            item.Flag = file[itemOffset + 12];
            item.ReboundDir = file[itemOffset + 13];
            item.UpDist = file[itemOffset + 14];
            item.AddAtkNum = file[itemOffset + 15];
            item.AddAtkDelay = file[itemOffset + 16];
            item.Ball = (item.Flag & 1) != 0;
            item.Pierce = (item.Flag & 2) != 0;
            return item;
        }

        public static BTL_BulletEffect ReadBTL_BulletEffect(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_BulletEffect();
            item.Id = itemId;
            item.Flag = file[itemOffset];
            item.EffPack = file[itemOffset + 1];
            item.WpnType = file[itemOffset + 2];
            item.Muzzle = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 3));
            item.Bullet = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 7));
            item.Impact = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 11));
            item.MuzzleScale = BitConverter.ToUInt16(file, itemOffset + 15);
            item.BulletScale = BitConverter.ToUInt16(file, itemOffset + 17);
            item.ImpactScale = BitConverter.ToUInt16(file, itemOffset + 19);
            item.MuzSePack = BitConverter.ToUInt16(file, itemOffset + 21);
            item.MuzSeSlot = file[itemOffset + 23];
            item.ImpSePack = BitConverter.ToUInt16(file, itemOffset + 24);
            item.ImpSeSlot = file[itemOffset + 26];
            item.Atr = (item.Flag & 1) != 0;
            return item;
        }

        public static BTL_ChainAttackCam ReadBTL_ChainAttackCam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChainAttackCam();
            item.Id = itemId;
            item.CamType = file[itemOffset];
            item.EnSize = file[itemOffset + 1];
            item.SpeedType = file[itemOffset + 2];
            item.SpeedNum = BitConverter.ToUInt16(file, itemOffset + 3);
            item.MoveType = file[itemOffset + 5];
            item.S_PosX = BitConverter.ToInt32(file, itemOffset + 6);
            item.S_PosY = BitConverter.ToInt32(file, itemOffset + 10);
            item.S_PosZ = BitConverter.ToInt32(file, itemOffset + 14);
            item.S_LookPosType = file[itemOffset + 18];
            item.S_LookX = BitConverter.ToInt32(file, itemOffset + 19);
            item.S_LookY = BitConverter.ToInt32(file, itemOffset + 23);
            item.S_LookZ = BitConverter.ToInt32(file, itemOffset + 27);
            item.E_PosX = BitConverter.ToInt32(file, itemOffset + 31);
            item.E_PosY = BitConverter.ToInt32(file, itemOffset + 35);
            item.E_PosZ = BitConverter.ToInt32(file, itemOffset + 39);
            item.E_LookPosType = file[itemOffset + 43];
            item.E_LookX = BitConverter.ToInt32(file, itemOffset + 44);
            item.E_LookY = BitConverter.ToInt32(file, itemOffset + 48);
            item.E_LookZ = BitConverter.ToInt32(file, itemOffset + 52);
            return item;
        }

        public static BTL_ChainAttackFull ReadBTL_ChainAttackFull(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChainAttackFull();
            item.Id = itemId;
            item.Wpn01 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Wpn02 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Wpn03 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Wpn04 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.Wpn05 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Wpn06 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.Wpn07 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.Wpn08 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.Wpn09 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.Wpn10 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.Wpn11 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.Wpn12 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.Wpn13 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.Wpn14 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.Wpn15 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 56));
            item.Wpn16 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 60));
            item.Wpn17 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 64));
            item.Wpn18 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 68));
            item.Wpn19 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 72));
            return item;
        }

        public static BTL_ChainAttackStart ReadBTL_ChainAttackStart(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChainAttackStart();
            item.Id = itemId;
            item.Wpn01 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Wpn01b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Wpn02 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Wpn02b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.Wpn03 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Wpn03b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.Wpn04 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.Wpn04b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.Wpn05 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.Wpn05b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.Wpn06 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.Wpn06b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.Wpn07 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.Wpn07b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.Wpn08 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 56));
            item.Wpn08b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 60));
            item.Wpn09 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 64));
            item.Wpn09b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 68));
            item.Wpn10 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 72));
            item.Wpn10b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 76));
            item.Wpn11 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 80));
            item.Wpn11b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 84));
            item.Wpn12 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 88));
            item.Wpn12b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 92));
            item.Wpn13 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 96));
            item.Wpn13b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 100));
            item.Wpn14 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 104));
            item.Wpn14b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 108));
            item.Wpn15 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 112));
            item.Wpn15b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 116));
            item.Wpn16 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.Wpn16b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 124));
            item.Wpn17 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 128));
            item.Wpn17b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 132));
            item.Wpn18 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 136));
            item.Wpn18b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 140));
            item.Wpn19 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 144));
            item.Wpn19b = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 148));
            item.Wpn90 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 152));
            item.Wpn91 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 156));
            item.Wpn92 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 160));
            item.Wpn93 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 164));
            item.Wpn94 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 168));
            item.Wpn95 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 172));
            item.Wpn96 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 176));
            item.Wpn97 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 180));
            item.Wpn98 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 184));
            return item;
        }

        public static BTL_ChBtl ReadBTL_ChBtl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChBtl();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.ListNum = file[itemOffset + 6];
            item.Difficult = file[itemOffset + 7];
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MapJump = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Weather = file[itemOffset + 12];
            item.Type = file[itemOffset + 13];
            item.NeedDefeat = BitConverter.ToUInt16(file, itemOffset + 14);
            item.MaxLevel = file[itemOffset + 16];
            item.MaxWpnRank = file[itemOffset + 17];
            item.WpnRevTable = BitConverter.ToUInt16(file, itemOffset + 18);
            item.TimeLimit = BitConverter.ToUInt16(file, itemOffset + 20);
            item.JoinNumber = file[itemOffset + 22];
            item.Driver1 = file[itemOffset + 23];
            item.Driver2 = file[itemOffset + 24];
            item.Driver3 = file[itemOffset + 25];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 26);
            item.ConditionCap = BitConverter.ToUInt16(file, itemOffset + 28);
            item.Flag = file[itemOffset + 30];
            item.ClearReward = BitConverter.ToUInt16(file, itemOffset + 31);
            item.TresureSet1 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.TresureSet2 = BitConverter.ToUInt16(file, itemOffset + 35);
            item.TresureSet3 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.TresureNeed1 = BitConverter.ToUInt16(file, itemOffset + 39);
            item.TresureNeed2 = BitConverter.ToUInt16(file, itemOffset + 41);
            item.TresureNeed3 = BitConverter.ToUInt16(file, itemOffset + 43);
            item.TresureResource1 = BitConverter.ToUInt16(file, itemOffset + 45);
            item.TresureResource2 = BitConverter.ToUInt16(file, itemOffset + 47);
            item.TresureResource3 = BitConverter.ToUInt16(file, itemOffset + 49);
            item.Voice1 = BitConverter.ToUInt32(file, itemOffset + 51);
            item.Voice2 = BitConverter.ToUInt32(file, itemOffset + 55);
            item.Voice3 = BitConverter.ToUInt32(file, itemOffset + 59);
            item.Voice4 = BitConverter.ToUInt32(file, itemOffset + 63);
            item.Hide = (item.Flag & 1) != 0;
            return item;
        }

        public static BTL_ChBtlRewardItem ReadBTL_ChBtlRewardItem(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChBtlRewardItem();
            item.Id = itemId;
            item.ItemID = BitConverter.ToUInt16(file, itemOffset);
            item.ItemValue = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Param1 = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static BTL_ChBtlRewardSet ReadBTL_ChBtlRewardSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChBtlRewardSet();
            item.Id = itemId;
            item.GoldMin = BitConverter.ToUInt32(file, itemOffset);
            item.GoldMax = BitConverter.ToUInt32(file, itemOffset + 4);
            item.GoldPopMin = file[itemOffset + 8];
            item.GoldPopMax = file[itemOffset + 9];
            item.ItemNumMin = file[itemOffset + 10];
            item.ItemNumMax = file[itemOffset + 11];
            item.ItemValueMin = BitConverter.ToUInt16(file, itemOffset + 12);
            item.ItemValueMax = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ItemValueMin2 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ItemValueMax2 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.AppointItem = BitConverter.ToUInt16(file, itemOffset + 20);
            item.UpCategory1 = file[itemOffset + 22];
            item.UpCategory2 = file[itemOffset + 23];
            item.DownCategory1 = file[itemOffset + 24];
            item.DownCategory2 = file[itemOffset + 25];
            item.UpItemID1 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.UpItemID2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.UpItemID3 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.UpItemID4 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.DownItemID1 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.DownItemID2 = BitConverter.ToUInt16(file, itemOffset + 36);
            item.DownItemID3 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.DownItemID4 = BitConverter.ToUInt16(file, itemOffset + 40);
            return item;
        }

        public static BTL_ChBtlScore ReadBTL_ChBtlScore(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChBtlScore();
            item.Id = itemId;
            item.Score = BitConverter.ToUInt16(file, itemOffset);
            item.Cube = BitConverter.ToUInt16(file, itemOffset + 2);
            item.CubeDiv = file[itemOffset + 4];
            return item;
        }

        public static BTL_ChBtlWpnRev ReadBTL_ChBtlWpnRev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ChBtlWpnRev();
            item.Id = itemId;
            item.WpnDmg1 = BitConverter.ToUInt16(file, itemOffset);
            item.WpnDmg2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.WpnDmg3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.WpnDmg4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.WpnDmg5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.WpnDmg6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.WpnDmg7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.WpnDmg8 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.WpnDmg9 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.WpnDmg10 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.WpnDmg11 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.WpnDmg12 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.WpnDmg13 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.WpnDmg14 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.WpnDmg15 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.WpnDmg16 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.WpnDmg17 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.WpnDmg18 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.WpnDmg19 = BitConverter.ToUInt16(file, itemOffset + 36);
            item.WpnDmg20 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.WpnDmg21 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.WpnDmg22 = BitConverter.ToUInt16(file, itemOffset + 42);
            item.WpnDmg23 = BitConverter.ToUInt16(file, itemOffset + 44);
            item.WpnDmg24 = BitConverter.ToUInt16(file, itemOffset + 46);
            item.WpnDmg25 = BitConverter.ToUInt16(file, itemOffset + 48);
            item.WpnDmg26 = BitConverter.ToUInt16(file, itemOffset + 50);
            return item;
        }

        public static BTL_Circle ReadBTL_Circle(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Circle();
            item.Id = itemId;
            item.Point = file[itemOffset];
            item.Radius = file[itemOffset + 1];
            item.Damage = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Target = file[itemOffset + 4];
            item.Interval = file[itemOffset + 5];
            item.Lifespan = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            return item;
        }

        public static BTL_Class ReadBTL_Class(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Class();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Role1 = file[itemOffset + 2];
            item.Role2 = file[itemOffset + 3];
            item.Role3 = file[itemOffset + 4];
            item.DamageDown = file[itemOffset + 5];
            item.DamageUP = file[itemOffset + 6];
            item.HealUP = file[itemOffset + 7];
            item.AutoHate = (sbyte)file[itemOffset + 8];
            item.ArtsHate = (sbyte)file[itemOffset + 9];
            item.Flag = file[itemOffset + 10];
            item.DamageDownNum = file[itemOffset + 11];
            item.DamageUPNum = file[itemOffset + 12];
            item.HealUPNum = file[itemOffset + 13];
            item.AutoHateNum = (sbyte)file[itemOffset + 14];
            item.ArtsHateNum = (sbyte)file[itemOffset + 15];
            item.Pot = (item.Flag & 1) != 0;
            item.HealMode = (item.Flag & 2) != 0;
            return item;
        }

        public static BTL_CmnBl_Armor ReadBTL_CmnBl_Armor(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_CmnBl_Armor();
            item.Id = itemId;
            item.WpnType = file[itemOffset];
            item.PArmorCon = file[itemOffset + 1];
            item.PArmorRand = file[itemOffset + 2];
            item.EArmorCon = file[itemOffset + 3];
            item.EArmorRand = file[itemOffset + 4];
            return item;
        }

        public static BTL_CmnBl_Capacity ReadBTL_CmnBl_Capacity(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_CmnBl_Capacity();
            item.Id = itemId;
            item.ArtsLv1Prob = file[itemOffset];
            item.ArtsLv2Prob = file[itemOffset + 1];
            item.ArtsLv3Prob = file[itemOffset + 2];
            item.ArtsLv4Prob = file[itemOffset + 3];
            item.ArtsLv5Prob = file[itemOffset + 4];
            item.ArtsRevCon = file[itemOffset + 5];
            item.ArtsRevRand = file[itemOffset + 6];
            item.SpArtsRevCon = file[itemOffset + 7];
            item.SpArtsRevRand = file[itemOffset + 8];
            item.SkillNum1Prob = file[itemOffset + 9];
            item.SkillNum2Prob = file[itemOffset + 10];
            item.SkillNum3Prob = file[itemOffset + 11];
            item.SkillLv1Prob = file[itemOffset + 12];
            item.SkillLv2Prob = file[itemOffset + 13];
            item.SkillLv3Prob = file[itemOffset + 14];
            item.SkillLv4Prob = file[itemOffset + 15];
            item.SkillLv5Prob = file[itemOffset + 16];
            item.OrbNum0Prob = file[itemOffset + 17];
            item.OrbNum1Prob = file[itemOffset + 18];
            item.OrbNum2Prob = file[itemOffset + 19];
            item.OrbNum3Prob = file[itemOffset + 20];
            item.NartsNum1Prob = file[itemOffset + 21];
            item.NartsNum2Prob = file[itemOffset + 22];
            item.NartsNum3Prob = file[itemOffset + 23];
            item.NartsRevCon = file[itemOffset + 24];
            item.NartsRevRand = file[itemOffset + 25];
            item.StatusRevCon = file[itemOffset + 26];
            item.StatusRevRand = file[itemOffset + 27];
            item.ArtsNum1Prob = file[itemOffset + 28];
            item.ArtsNum2Prob = file[itemOffset + 29];
            item.ArtsNum3Prob = file[itemOffset + 30];
            return item;
        }

        public static BTL_CmnBl_NewBlArts ReadBTL_CmnBl_NewBlArts(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_CmnBl_NewBlArts();
            item.Id = itemId;
            item.WpnType = file[itemOffset];
            item.NBA_01 = file[itemOffset + 1];
            item.NBA_02 = file[itemOffset + 2];
            item.NBA_03 = file[itemOffset + 3];
            item.NBA_04 = file[itemOffset + 4];
            item.NBA_05 = file[itemOffset + 5];
            item.NBA_06 = file[itemOffset + 6];
            item.NBA_07 = file[itemOffset + 7];
            item.NBA_08 = file[itemOffset + 8];
            return item;
        }

        public static BTL_CmnBl_Power ReadBTL_CmnBl_Power(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_CmnBl_Power();
            item.Id = itemId;
            item.MinLv = file[itemOffset];
            item.MaxLv = file[itemOffset + 1];
            item.Pow01 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Pow02 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Pow03 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Pow04 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Pow05 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Pow06 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Pow07 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Pow08 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Pow09 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Pow10 = BitConverter.ToUInt16(file, itemOffset + 20);
            return item;
        }

        public static BTL_CmnBl_StatusType ReadBTL_CmnBl_StatusType(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_CmnBl_StatusType();
            item.Id = itemId;
            item.WpnType = file[itemOffset];
            item.Status01 = file[itemOffset + 1];
            item.Status02 = file[itemOffset + 2];
            item.Status03 = file[itemOffset + 3];
            item.Status04 = file[itemOffset + 4];
            item.Status05 = file[itemOffset + 5];
            item.Status06 = file[itemOffset + 6];
            return item;
        }

        public static BTL_Condition ReadBTL_Condition(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Condition();
            item.Id = itemId;
            item.FLD_CondID = BitConverter.ToUInt16(file, itemOffset);
            item.Param01 = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static BTL_DifSetting ReadBTL_DifSetting(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_DifSetting();
            item.Id = itemId;
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ParamMin = file[itemOffset + 4];
            item.ParamMax = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Interval = file[itemOffset + 7];
            item.Normal = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Easy = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Hard = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Ult = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static BTL_Dr_IdeaUpType ReadBTL_Dr_IdeaUpType(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Dr_IdeaUpType();
            item.Id = itemId;
            item.IdeaBlue = file[itemOffset];
            item.IdeaRed = file[itemOffset + 1];
            item.IdeaWhite = file[itemOffset + 2];
            item.IdeaBlack = file[itemOffset + 3];
            return item;
        }

        public static BTL_Drop_Heal ReadBTL_Drop_Heal(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Drop_Heal();
            item.Id = itemId;
            item.RatioDeath = file[itemOffset];
            item.PotNumMin1 = file[itemOffset + 1];
            item.PotNumMax1 = file[itemOffset + 2];
            item.PotLvMin1 = file[itemOffset + 3];
            item.PotLvMax1 = file[itemOffset + 4];
            item.RatioStumbled = file[itemOffset + 5];
            item.PotNumMin2 = file[itemOffset + 6];
            item.PotNumMax2 = file[itemOffset + 7];
            item.PotLvMin2 = file[itemOffset + 8];
            item.PotLvMax2 = file[itemOffset + 9];
            item.RatioLaunch = file[itemOffset + 10];
            item.PotNumMin3 = file[itemOffset + 11];
            item.PotNumMax3 = file[itemOffset + 12];
            item.PotLvMin3 = file[itemOffset + 13];
            item.PotLvMax3 = file[itemOffset + 14];
            item.RatioStrike = file[itemOffset + 15];
            item.PotNumMin4 = file[itemOffset + 16];
            item.PotNumMax4 = file[itemOffset + 17];
            item.PotLvMin4 = file[itemOffset + 18];
            item.PotLvMax4 = file[itemOffset + 19];
            return item;
        }

        public static BTL_ElementalCombo ReadBTL_ElementalCombo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ElementalCombo();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.Caption = file[itemOffset + 5];
            item.Atr = file[itemOffset + 6];
            item.ComboStage = file[itemOffset + 7];
            item.PreCombo = file[itemOffset + 8];
            item.Range = file[itemOffset + 9];
            item.BaseTime = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Reaction = file[itemOffset + 12];
            item.ReactionLv = file[itemOffset + 13];
            item.DD = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Dot = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Interval = BitConverter.ToUInt16(file, itemOffset + 18);
            item.DDEn = BitConverter.ToSingle(file, itemOffset + 20);
            item.DotEn = BitConverter.ToSingle(file, itemOffset + 24);
            item.DDf1 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.DDf2 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.DDf3 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.DDf4 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.DDf5 = BitConverter.ToUInt16(file, itemOffset + 36);
            item.DDf6 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.DDf7 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.DDf8 = BitConverter.ToUInt16(file, itemOffset + 42);
            item.DDf9 = BitConverter.ToUInt16(file, itemOffset + 44);
            item.DDf10 = BitConverter.ToUInt16(file, itemOffset + 46);
            item.DDf11 = BitConverter.ToUInt16(file, itemOffset + 48);
            item.DDf12 = BitConverter.ToUInt16(file, itemOffset + 50);
            item.DDf13 = BitConverter.ToUInt16(file, itemOffset + 52);
            item.DDf14 = BitConverter.ToUInt16(file, itemOffset + 54);
            item.DDf15 = BitConverter.ToUInt16(file, itemOffset + 56);
            item.DDf16 = BitConverter.ToUInt16(file, itemOffset + 58);
            item.DmgRt1 = file[itemOffset + 60];
            item.DmgRt2 = file[itemOffset + 61];
            item.DmgRt3 = file[itemOffset + 62];
            item.DmgRt4 = file[itemOffset + 63];
            item.DmgRt5 = file[itemOffset + 64];
            item.DmgRt6 = file[itemOffset + 65];
            item.DmgRt7 = file[itemOffset + 66];
            item.DmgRt8 = file[itemOffset + 67];
            item.DmgRt9 = file[itemOffset + 68];
            item.DmgRt10 = file[itemOffset + 69];
            item.DmgRt11 = file[itemOffset + 70];
            item.DmgRt12 = file[itemOffset + 71];
            item.DmgRt13 = file[itemOffset + 72];
            item.DmgRt14 = file[itemOffset + 73];
            item.DmgRt15 = file[itemOffset + 74];
            item.DmgRt16 = file[itemOffset + 75];
            item.ReAct1 = file[itemOffset + 76];
            item.ReAct2 = file[itemOffset + 77];
            item.ReAct3 = file[itemOffset + 78];
            item.ReAct4 = file[itemOffset + 79];
            item.ReAct5 = file[itemOffset + 80];
            item.ReAct6 = file[itemOffset + 81];
            item.ReAct7 = file[itemOffset + 82];
            item.ReAct8 = file[itemOffset + 83];
            item.ReAct9 = file[itemOffset + 84];
            item.ReAct10 = file[itemOffset + 85];
            item.ReAct11 = file[itemOffset + 86];
            item.ReAct12 = file[itemOffset + 87];
            item.ReAct13 = file[itemOffset + 88];
            item.ReAct14 = file[itemOffset + 89];
            item.ReAct15 = file[itemOffset + 90];
            item.ReAct16 = file[itemOffset + 91];
            item.Effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 92));
            item.SE = file[itemOffset + 96];
            item.DamageRate = file[itemOffset + 97];
            item.FusionName1 = file[itemOffset + 98];
            item.FusionName2 = file[itemOffset + 99];
            item.FusionName3 = file[itemOffset + 100];
            item.FusionName4 = file[itemOffset + 101];
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 102);
            item.NeedAtrNum = file[itemOffset + 104];
            return item;
        }

        public static BTL_ElementalEffect ReadBTL_ElementalEffect(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_ElementalEffect();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.Caption = file[itemOffset + 5];
            item.Atr1 = file[itemOffset + 6];
            item.Effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 7));
            item.SE = file[itemOffset + 11];
            return item;
        }

        public static BTL_EnAwake ReadBTL_EnAwake(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnAwake();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.NormalProb = file[itemOffset + 2];
            item.AngryProb = file[itemOffset + 3];
            item.AttackBonus = file[itemOffset + 4];
            item.RecastBonus = file[itemOffset + 5];
            item.ReduceElmCombo = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static BTL_EnBook ReadBTL_EnBook(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnBook();
            item.Id = itemId;
            item.BaseEnemyID = BitConverter.ToUInt16(file, itemOffset);
            item.BOOK_POP_TIME = BitConverter.ToUInt32(file, itemOffset + 2);
            item.BOOK_popWeather = file[itemOffset + 6];
            return item;
        }

        public static BTL_EnDropItem ReadBTL_EnDropItem(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnDropItem();
            item.Id = itemId;
            item.LimitNum = file[itemOffset];
            item.SelectType = file[itemOffset + 1];
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DropProb1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NoGetByEnh1 = file[itemOffset + 6];
            item.FirstNamed1 = file[itemOffset + 7];
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.DropProb2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.NoGetByEnh2 = file[itemOffset + 12];
            item.FirstNamed2 = file[itemOffset + 13];
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.DropProb3 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.NoGetByEnh3 = file[itemOffset + 18];
            item.FirstNamed3 = file[itemOffset + 19];
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.DropProb4 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.NoGetByEnh4 = file[itemOffset + 24];
            item.FirstNamed4 = file[itemOffset + 25];
            item.ItemID5 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.DropProb5 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.NoGetByEnh5 = file[itemOffset + 30];
            item.FirstNamed5 = file[itemOffset + 31];
            item.ItemID6 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.DropProb6 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.NoGetByEnh6 = file[itemOffset + 36];
            item.FirstNamed6 = file[itemOffset + 37];
            item.ItemID7 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.DropProb7 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.NoGetByEnh7 = file[itemOffset + 42];
            item.FirstNamed7 = file[itemOffset + 43];
            item.ItemID8 = BitConverter.ToUInt16(file, itemOffset + 44);
            item.DropProb8 = BitConverter.ToUInt16(file, itemOffset + 46);
            item.NoGetByEnh8 = file[itemOffset + 48];
            item.FirstNamed8 = file[itemOffset + 49];
            return item;
        }

        public static BTL_EnDropQuest ReadBTL_EnDropQuest(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnDropQuest();
            item.Id = itemId;
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset);
            item.DropProb1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.GetConditon1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.DropProb2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.GetConditon2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.DropProb3 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.GetConditon3 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.DropProb4 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.GetConditon4 = BitConverter.ToUInt16(file, itemOffset + 22);
            return item;
        }

        public static BTL_Enhance ReadBTL_Enhance(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Enhance();
            item.Id = itemId;
            item.EnhanceEffect = BitConverter.ToUInt16(file, itemOffset);
            item.Param1 = BitConverter.ToSingle(file, itemOffset + 2);
            item.Param2 = BitConverter.ToSingle(file, itemOffset + 6);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static BTL_EnhanceEff ReadBTL_EnhanceEff(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnhanceEff();
            item.Id = itemId;
            item.Category = file[itemOffset];
            item.Icon = file[itemOffset + 1];
            item.Flag = file[itemOffset + 2];
            item.Param = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Name = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Direct = file[itemOffset + 7];
            item.SortCat = file[itemOffset + 8];
            item.Condition = (item.Flag & 1) != 0;
            item.UI = (item.Flag & 2) != 0;
            item.PG = (item.Flag & 4) != 0;
            return item;
        }

        public static BTL_EnhanceMax ReadBTL_EnhanceMax(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_EnhanceMax();
            item.Id = itemId;
            item.Max = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static BTL_FightCombo ReadBTL_FightCombo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_FightCombo();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.ComboStage = file[itemOffset + 5];
            item.PreCombo = file[itemOffset + 6];
            item.BaseNum = BitConverter.ToUInt16(file, itemOffset + 7);
            item.BaseTime = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Reaction = file[itemOffset + 11];
            item.ReactionLv = file[itemOffset + 12];
            item.DamageRate = file[itemOffset + 13];
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Caption = file[itemOffset + 16];
            return item;
        }

        public static BTL_Grow ReadBTL_Grow(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Grow();
            item.Id = itemId;
            item.LevelExp = BitConverter.ToUInt32(file, itemOffset);
            item.LevelExp2 = BitConverter.ToUInt32(file, itemOffset + 4);
            item.EnemyExp = BitConverter.ToUInt16(file, itemOffset + 8);
            item.EnemyWP = BitConverter.ToUInt16(file, itemOffset + 10);
            item.EnemySP = BitConverter.ToUInt16(file, itemOffset + 12);
            item.EnemyGold = BitConverter.ToUInt32(file, itemOffset + 14);
            item.GoldDivide = file[itemOffset + 18];
            return item;
        }

        public static BTL_HanaBase ReadBTL_HanaBase(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HanaBase();
            item.Id = itemId;
            item.NCondNum = file[itemOffset];
            item.ECondNum = file[itemOffset + 1];
            item.NArtsNum = file[itemOffset + 2];
            item.Circuit1Num = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Circuit2Num = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Circuit3Num = BitConverter.ToUInt16(file, itemOffset + 7);
            item.Circuit4Num = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Circuit5Num = BitConverter.ToUInt16(file, itemOffset + 11);
            item.Circuit6Num = BitConverter.ToUInt16(file, itemOffset + 13);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 15));
            return item;
        }

        public static BTL_HanaChipset ReadBTL_HanaChipset(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HanaChipset();
            item.Id = itemId;
            item.RoleParts = BitConverter.ToUInt16(file, itemOffset);
            item.AtrParts = BitConverter.ToUInt16(file, itemOffset + 2);
            item.NArtsParts1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NArtsParts2 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.NArtsParts3 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.NCondParts1 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.NCondParts2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.NCondParts3 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            return item;
        }

        public static BTL_HanaPower ReadBTL_HanaPower(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HanaPower();
            item.Id = itemId;
            item.PowerNum1 = BitConverter.ToUInt16(file, itemOffset);
            item.PowerNum2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.PowerNum3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.EtherNum1 = BitConverter.ToUInt32(file, itemOffset + 6);
            item.EtherNum2 = BitConverter.ToUInt32(file, itemOffset + 10);
            item.EtherNum3 = BitConverter.ToUInt32(file, itemOffset + 14);
            return item;
        }

        public static BTL_HealPot ReadBTL_HealPot(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HealPot();
            item.Id = itemId;
            item.DropRsc = file[itemOffset];
            item.HpRatio = file[itemOffset + 1];
            item.Category = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            return item;
        }

        public static BTL_HitCameraParam ReadBTL_HitCameraParam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HitCameraParam();
            item.Id = itemId;
            item.type = file[itemOffset];
            item.sub_type = file[itemOffset + 1];
            item.param01 = file[itemOffset + 2];
            item.param02 = file[itemOffset + 3];
            item.param03 = file[itemOffset + 4];
            item.param04 = file[itemOffset + 5];
            return item;
        }

        public static BTL_HitDirection ReadBTL_HitDirection(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HitDirection();
            item.Id = itemId;
            item.DirectType = file[itemOffset];
            item.DirectFrm = file[itemOffset + 1];
            item.CamType = file[itemOffset + 2];
            item.CamAngle = file[itemOffset + 3];
            return item;
        }

        public static BTL_HitEffect ReadBTL_HitEffect(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HitEffect();
            item.Id = itemId;
            item.x0 = BitConverter.ToInt16(file, itemOffset);
            item.y0 = BitConverter.ToInt16(file, itemOffset + 2);
            item.z0 = BitConverter.ToInt16(file, itemOffset + 4);
            item.x1 = BitConverter.ToInt16(file, itemOffset + 6);
            item.y1 = BitConverter.ToInt16(file, itemOffset + 8);
            item.z1 = BitConverter.ToInt16(file, itemOffset + 10);
            item.x2 = BitConverter.ToInt16(file, itemOffset + 12);
            item.y2 = BitConverter.ToInt16(file, itemOffset + 14);
            item.z2 = BitConverter.ToInt16(file, itemOffset + 16);
            item.x3 = BitConverter.ToInt16(file, itemOffset + 18);
            item.y3 = BitConverter.ToInt16(file, itemOffset + 20);
            item.z3 = BitConverter.ToInt16(file, itemOffset + 22);
            item.x4 = BitConverter.ToInt16(file, itemOffset + 24);
            item.y4 = BitConverter.ToInt16(file, itemOffset + 26);
            item.z4 = BitConverter.ToInt16(file, itemOffset + 28);
            item.x5 = BitConverter.ToInt16(file, itemOffset + 30);
            item.y5 = BitConverter.ToInt16(file, itemOffset + 32);
            item.z5 = BitConverter.ToInt16(file, itemOffset + 34);
            item.x6 = BitConverter.ToInt16(file, itemOffset + 36);
            item.y6 = BitConverter.ToInt16(file, itemOffset + 38);
            item.z6 = BitConverter.ToInt16(file, itemOffset + 40);
            item.x7 = BitConverter.ToInt16(file, itemOffset + 42);
            item.y7 = BitConverter.ToInt16(file, itemOffset + 44);
            item.z7 = BitConverter.ToInt16(file, itemOffset + 46);
            item.x8 = BitConverter.ToInt16(file, itemOffset + 48);
            item.y8 = BitConverter.ToInt16(file, itemOffset + 50);
            item.z8 = BitConverter.ToInt16(file, itemOffset + 52);
            item.x9 = BitConverter.ToInt16(file, itemOffset + 54);
            item.y9 = BitConverter.ToInt16(file, itemOffset + 56);
            item.z9 = BitConverter.ToInt16(file, itemOffset + 58);
            item.x10 = BitConverter.ToInt16(file, itemOffset + 60);
            item.y10 = BitConverter.ToInt16(file, itemOffset + 62);
            item.z10 = BitConverter.ToInt16(file, itemOffset + 64);
            item.x11 = BitConverter.ToInt16(file, itemOffset + 66);
            item.y11 = BitConverter.ToInt16(file, itemOffset + 68);
            item.z11 = BitConverter.ToInt16(file, itemOffset + 70);
            item.x12 = BitConverter.ToInt16(file, itemOffset + 72);
            item.y12 = BitConverter.ToInt16(file, itemOffset + 74);
            item.z12 = BitConverter.ToInt16(file, itemOffset + 76);
            item.x13 = BitConverter.ToInt16(file, itemOffset + 78);
            item.y13 = BitConverter.ToInt16(file, itemOffset + 80);
            item.z13 = BitConverter.ToInt16(file, itemOffset + 82);
            item.x14 = BitConverter.ToInt16(file, itemOffset + 84);
            item.y14 = BitConverter.ToInt16(file, itemOffset + 86);
            item.z14 = BitConverter.ToInt16(file, itemOffset + 88);
            item.x15 = BitConverter.ToInt16(file, itemOffset + 90);
            item.y15 = BitConverter.ToInt16(file, itemOffset + 92);
            item.z15 = BitConverter.ToInt16(file, itemOffset + 94);
            for (int i = 0, offset = itemOffset + 96; i < 16; i++, offset += 1)
            {
                item.type[i] = file[offset];
            }
            for (int i = 0, offset = itemOffset + 112; i < 16; i++, offset += 4)
            {
                item.name[i] = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, offset));
            }
            return item;
        }

        public static BTL_HitEffectRim ReadBTL_HitEffectRim(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_HitEffectRim();
            item.Id = itemId;
            item.RimName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static BTL_IrGroupRev ReadBTL_IrGroupRev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_IrGroupRev();
            item.Id = itemId;
            item.GroupRev1 = file[itemOffset];
            item.GroupRev2 = file[itemOffset + 1];
            item.GroupRev3 = file[itemOffset + 2];
            return item;
        }

        public static BTL_Kizuna ReadBTL_Kizuna(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Kizuna();
            item.Id = itemId;
            item.KizunaMin = BitConverter.ToUInt16(file, itemOffset);
            item.KizunaMax = BitConverter.ToUInt16(file, itemOffset + 2);
            item.BArtsProbRev = BitConverter.ToUInt16(file, itemOffset + 4);
            item.BArtsDamageRev = BitConverter.ToUInt16(file, itemOffset + 6);
            item.CriRateRev = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MoveSpeedRev = BitConverter.ToUInt16(file, itemOffset + 10);
            item.DArtsRecastRev = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static BTL_Lv_Rev ReadBTL_Lv_Rev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Lv_Rev();
            item.Id = itemId;
            item.ExpRevHigh = BitConverter.ToUInt16(file, itemOffset);
            item.ExpRevLow = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DamageRevHigh = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DamageRevLow = BitConverter.ToUInt16(file, itemOffset + 6);
            item.HitRevLow = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ReactRevHigh = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static BTL_MapRev ReadBTL_MapRev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_MapRev();
            item.Id = itemId;
            item.Flag = BitConverter.ToUInt16(file, itemOffset);
            item.KizunaCap = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ArtSp = file[itemOffset + 4];
            item.PC01Atk = file[itemOffset + 5];
            item.PC01Def = file[itemOffset + 6];
            item.PC02Atk = file[itemOffset + 7];
            item.PC02Def = file[itemOffset + 8];
            item.PC03Atk = file[itemOffset + 9];
            item.PC03Def = file[itemOffset + 10];
            item.PC04Atk = file[itemOffset + 11];
            item.PC04Def = file[itemOffset + 12];
            item.PC05Atk = file[itemOffset + 13];
            item.PC05Def = file[itemOffset + 14];
            item.PC06Atk = file[itemOffset + 15];
            item.PC06Def = file[itemOffset + 16];
            item.PC07Atk = file[itemOffset + 17];
            item.PC07Def = file[itemOffset + 18];
            item.PC08Atk = file[itemOffset + 19];
            item.PC08Def = file[itemOffset + 20];
            item.PC09Atk = file[itemOffset + 21];
            item.PC09Def = file[itemOffset + 22];
            item.Rex = (item.Flag & 1) != 0;
            item.Nia = (item.Flag & 2) != 0;
            item.Sieg = (item.Flag & 4) != 0;
            item.Tora = (item.Flag & 8) != 0;
            item.Vandamme = (item.Flag & 16) != 0;
            item.Melef = (item.Flag & 32) != 0;
            item.Sin = (item.Flag & 64) != 0;
            item.Metsu = (item.Flag & 128) != 0;
            item.Sin2 = (item.Flag & 256) != 0;
            item.nba = (item.Flag & 512) != 0;
            return item;
        }

        public static BTL_NamedList ReadBTL_NamedList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_NamedList();
            item.Id = itemId;
            item.EnemyID = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static BTL_PartyGauge ReadBTL_PartyGauge(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_PartyGauge();
            item.Id = itemId;
            item.Param = BitConverter.ToInt16(file, itemOffset);
            return item;
        }

        public static BTL_Points ReadBTL_Points(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Points();
            item.Id = itemId;
            item.Point = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static BTL_PouchBuff ReadBTL_PouchBuff(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_PouchBuff();
            item.Id = itemId;
            item.Max = BitConverter.ToUInt16(file, itemOffset);
            item.Name = file[itemOffset + 2];
            return item;
        }

        public static BTL_PouchBuffSet ReadBTL_PouchBuffSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_PouchBuffSet();
            item.Id = itemId;
            item.PBuff1 = file[itemOffset];
            item.PBuffParam1 = BitConverter.ToSingle(file, itemOffset + 1);
            item.PBuff2 = file[itemOffset + 5];
            item.PBuffParam2 = BitConverter.ToSingle(file, itemOffset + 6);
            item.PBuff3 = file[itemOffset + 10];
            item.PBuffParam3 = BitConverter.ToSingle(file, itemOffset + 11);
            return item;
        }

        public static BTL_Reaction ReadBTL_Reaction(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Reaction();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.Priority = file[itemOffset + 5];
            item.PowLv1_S = BitConverter.ToUInt16(file, itemOffset + 6);
            item.PowLv1_M = BitConverter.ToUInt16(file, itemOffset + 8);
            item.PowLv1_L = BitConverter.ToUInt16(file, itemOffset + 10);
            item.PowLv1_LL = BitConverter.ToUInt16(file, itemOffset + 12);
            item.PowLv2_S = BitConverter.ToUInt16(file, itemOffset + 14);
            item.PowLv2_M = BitConverter.ToUInt16(file, itemOffset + 16);
            item.PowLv2_L = BitConverter.ToUInt16(file, itemOffset + 18);
            item.PowLv2_LL = BitConverter.ToUInt16(file, itemOffset + 20);
            item.PowLv3_S = BitConverter.ToUInt16(file, itemOffset + 22);
            item.PowLv3_M = BitConverter.ToUInt16(file, itemOffset + 24);
            item.PowLv3_L = BitConverter.ToUInt16(file, itemOffset + 26);
            item.PowLv3_LL = BitConverter.ToUInt16(file, itemOffset + 28);
            item.PowLv4_S = BitConverter.ToUInt16(file, itemOffset + 30);
            item.PowLv4_M = BitConverter.ToUInt16(file, itemOffset + 32);
            item.PowLv4_L = BitConverter.ToUInt16(file, itemOffset + 34);
            item.PowLv4_LL = BitConverter.ToUInt16(file, itemOffset + 36);
            item.PowLv5_S = BitConverter.ToUInt16(file, itemOffset + 38);
            item.PowLv5_M = BitConverter.ToUInt16(file, itemOffset + 40);
            item.PowLv5_L = BitConverter.ToUInt16(file, itemOffset + 42);
            item.PowLv5_LL = BitConverter.ToUInt16(file, itemOffset + 44);
            item.PowLv6_S = BitConverter.ToUInt16(file, itemOffset + 46);
            item.PowLv6_M = BitConverter.ToUInt16(file, itemOffset + 48);
            item.PowLv6_L = BitConverter.ToUInt16(file, itemOffset + 50);
            item.PowLv6_LL = BitConverter.ToUInt16(file, itemOffset + 52);
            return item;
        }

        public static BTL_SE ReadBTL_SE(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_SE();
            item.Id = itemId;
            item.PackName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tag = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.delivered = file[itemOffset + 8];
            return item;
        }

        public static BTL_Skill_Bl ReadBTL_Skill_Bl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Skill_Bl();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Enhance3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Enhance4 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Enhance5 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Flag = file[itemOffset + 16];
            item.Tank = file[itemOffset + 17];
            item.Attacker = file[itemOffset + 18];
            item.Healer = file[itemOffset + 19];
            item.UI = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Role = file[itemOffset + 22];
            item.MaxLv = file[itemOffset + 23];
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 24);
            item.common = (item.Flag & 1) != 0;
            return item;
        }

        public static BTL_Skill_Dr ReadBTL_Skill_Dr(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Skill_Dr();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 6);
            item.UI = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static BTL_Skill_Dr_Table ReadBTL_Skill_Dr_Table(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Skill_Dr_Table();
            item.Id = itemId;
            item.SkillID = BitConverter.ToUInt16(file, itemOffset);
            item.NeedSp = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Round = file[itemOffset + 4];
            item.ColumnNum = file[itemOffset + 5];
            item.RowNum = file[itemOffset + 6];
            return item;
        }

        public static BTL_SpArtsRecast ReadBTL_SpArtsRecast(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_SpArtsRecast();
            item.Id = itemId;
            item.Param = file[itemOffset];
            item.Param2 = file[itemOffset + 1];
            return item;
        }

        public static BTL_Summon ReadBTL_Summon(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Summon();
            item.Id = itemId;
            item.SummonType = file[itemOffset];
            item.LimitRad = BitConverter.ToUInt16(file, itemOffset + 1);
            item.Num = file[itemOffset + 3];
            item.Rate = file[itemOffset + 4];
            for (int i = 0, offset = itemOffset + 5; i < 3; i++, offset += 2)
            {
                item.EnemyID[i] = BitConverter.ToUInt16(file, offset);
            }
            for (int i = 0, offset = itemOffset + 11; i < 3; i++, offset += 2)
            {
                item.Unique[i] = BitConverter.ToUInt16(file, offset);
            }
            for (int i = 0, offset = itemOffset + 17; i < 3; i++, offset += 2)
            {
                item.PosA[i] = BitConverter.ToInt16(file, offset);
            }
            for (int i = 0, offset = itemOffset + 23; i < 3; i++, offset += 2)
            {
                item.PosB[i] = BitConverter.ToInt16(file, offset);
            }
            for (int i = 0, offset = itemOffset + 29; i < 3; i++, offset += 2)
            {
                item.PosC[i] = BitConverter.ToInt16(file, offset);
            }
            return item;
        }

        public static BTL_SystemBalance ReadBTL_SystemBalance(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_SystemBalance();
            item.Id = itemId;
            item.Param = BitConverter.ToInt16(file, itemOffset);
            item.Decimal = file[itemOffset + 2];
            return item;
        }

        public static BTL_TestSetting ReadBTL_TestSetting(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_TestSetting();
            item.Id = itemId;
            item.Dr1 = file[itemOffset];
            item.Dr1Lv = file[itemOffset + 1];
            item.Dr1Bl1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Dr1Bl2 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Dr1Bl3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Dr2 = file[itemOffset + 8];
            item.Dr2Lv = file[itemOffset + 9];
            item.Dr2Bl1 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Dr2Bl2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Dr2Bl3 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Dr3 = file[itemOffset + 16];
            item.Dr3Lv = file[itemOffset + 17];
            item.Dr3Bl1 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Dr3Bl2 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Dr3Bl3 = BitConverter.ToUInt16(file, itemOffset + 22);
            return item;
        }

        public static BTL_UCDirect ReadBTL_UCDirect(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_UCDirect();
            item.Id = itemId;
            item.Slow = file[itemOffset];
            item.Slowf = file[itemOffset + 1];
            item.Camera = file[itemOffset + 2];
            item.Waitf = file[itemOffset + 3];
            item.UIEffType = file[itemOffset + 4];
            item.UIStartf = file[itemOffset + 5];
            item.UIEndf = file[itemOffset + 6];
            item.Voicef = file[itemOffset + 7];
            return item;
        }

        public static BTL_UniteCombo ReadBTL_UniteCombo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_UniteCombo();
            item.Id = itemId;
            item.StageSum = file[itemOffset];
            item.NorDamageBonus = file[itemOffset + 1];
            item.NorTimeBonus = file[itemOffset + 2];
            item.NorPartyBonus = file[itemOffset + 3];
            item.BonusRate = file[itemOffset + 4];
            item.Direction = file[itemOffset + 5];
            item.DamageBonusNum = file[itemOffset + 6];
            item.TimeBonusNum = file[itemOffset + 7];
            item.PartyBonusNum = file[itemOffset + 8];
            return item;
        }

        public static BTL_VolumeFade ReadBTL_VolumeFade(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_VolumeFade();
            item.Id = itemId;
            item.VolumeName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static BTL_VtxParticle ReadBTL_VtxParticle(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_VtxParticle();
            item.Id = itemId;
            item.Name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static BTL_Wpn_En ReadBTL_Wpn_En(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new BTL_Wpn_En();
            item.Id = itemId;
            item.RscR = BitConverter.ToUInt16(file, itemOffset);
            item.RscL = BitConverter.ToUInt16(file, itemOffset + 2);
            item.TypeRange = file[itemOffset + 4];
            item.Damage = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Stability = file[itemOffset + 7];
            return item;
        }

        public static CAM_MaxLevel ReadCAM_MaxLevel(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CAM_MaxLevel();
            item.Id = itemId;
            item.RevReset = file[itemOffset];
            item.RevAuto = file[itemOffset + 1];
            item.RotSpeed = file[itemOffset + 2];
            item.ZoomSpeed = file[itemOffset + 3];
            return item;
        }

        public static CAM_Params ReadCAM_Params(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CAM_Params();
            item.Id = itemId;
            item.RevReset = file[itemOffset];
            item.RevAuto = file[itemOffset + 1];
            item.YawRotSpeed = file[itemOffset + 2];
            item.PitchRotSpeed = file[itemOffset + 3];
            item.ZoomSpeed = file[itemOffset + 4];
            return item;
        }

        public static CHR_Bl ReadCHR_Bl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_Bl();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Race = file[itemOffset + 6];
            item.RotateLimitPitch = file[itemOffset + 7];
            item.RotateLimitRoll = file[itemOffset + 8];
            item.Gender = file[itemOffset + 9];
            item.QuestRace = file[itemOffset + 10];
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 11));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 15));
            item.AddMotion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 19));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Model2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 25));
            item.Motion2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 29));
            item.Still = BitConverter.ToUInt16(file, itemOffset + 33);
            item.Voice = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 35));
            item.ClipEvent = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 39));
            item.Com_SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 43));
            item.SePack = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 47));
            item.Com_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 51));
            item.Com_Vo = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 55));
            item.OffsetID = BitConverter.ToUInt16(file, itemOffset + 59);
            item.EyeRot = file[itemOffset + 61];
            item.ChestHeight = BitConverter.ToUInt16(file, itemOffset + 62);
            item.LandingHeight = BitConverter.ToUInt16(file, itemOffset + 64);
            item.FootStep = file[itemOffset + 66];
            item.FootStepEffect = file[itemOffset + 67];
            item.WeaponType = file[itemOffset + 68];
            item.Scale = BitConverter.ToUInt16(file, itemOffset + 69);
            item.WpnScale = BitConverter.ToUInt16(file, itemOffset + 71);
            item.Flag = file[itemOffset + 73];
            item.PrivateWpnR = BitConverter.ToUInt16(file, itemOffset + 74);
            item.PrivateWpnL = BitConverter.ToUInt16(file, itemOffset + 76);
            item.PrivateWpnR_Driver = BitConverter.ToUInt16(file, itemOffset + 78);
            item.PrivateWpnL_Driver = BitConverter.ToUInt16(file, itemOffset + 80);
            item.WpnrOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 82));
            item.WpnlOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 86));
            item.OrbNum = file[itemOffset + 90];
            item.Atr = file[itemOffset + 91];
            item.Personality = file[itemOffset + 92];
            item.CoolTime = BitConverter.ToUInt16(file, itemOffset + 93);
            item.DefWeapon = BitConverter.ToUInt16(file, itemOffset + 95);
            item.BArts1 = BitConverter.ToUInt16(file, itemOffset + 97);
            item.BArts2 = BitConverter.ToUInt16(file, itemOffset + 99);
            item.BArts3 = BitConverter.ToUInt16(file, itemOffset + 101);
            item.BartsEx = BitConverter.ToUInt16(file, itemOffset + 103);
            item.BartsEx2 = BitConverter.ToUInt16(file, itemOffset + 105);
            item.NArts1 = file[itemOffset + 107];
            item.NArtsRecastRev1 = file[itemOffset + 108];
            item.NArts2 = file[itemOffset + 109];
            item.NArtsRecastRev2 = file[itemOffset + 110];
            item.NArts3 = file[itemOffset + 111];
            item.NArtsRecastRev3 = file[itemOffset + 112];
            item.BSkill1 = BitConverter.ToUInt16(file, itemOffset + 113);
            item.BSkill2 = BitConverter.ToUInt16(file, itemOffset + 115);
            item.BSkill3 = BitConverter.ToUInt16(file, itemOffset + 117);
            item.PArmor = file[itemOffset + 119];
            item.EArmor = file[itemOffset + 120];
            item.HpMaxRev = file[itemOffset + 121];
            item.StrengthRev = file[itemOffset + 122];
            item.PowEtherRev = file[itemOffset + 123];
            item.DexRev = file[itemOffset + 124];
            item.AgilityRev = file[itemOffset + 125];
            item.LuckRev = file[itemOffset + 126];
            item.BKLSet = BitConverter.ToUInt16(file, itemOffset + 127);
            item.FSkill1 = BitConverter.ToUInt16(file, itemOffset + 129);
            item.FSkill2 = BitConverter.ToUInt16(file, itemOffset + 131);
            item.FSkill3 = BitConverter.ToUInt16(file, itemOffset + 133);
            item.ArtsAchievement1 = BitConverter.ToUInt16(file, itemOffset + 135);
            item.ArtsAchievement2 = BitConverter.ToUInt16(file, itemOffset + 137);
            item.ArtsAchievement3 = BitConverter.ToUInt16(file, itemOffset + 139);
            item.SkillAchievement1 = BitConverter.ToUInt16(file, itemOffset + 141);
            item.SkillAchievement2 = BitConverter.ToUInt16(file, itemOffset + 143);
            item.SkillAchievement3 = BitConverter.ToUInt16(file, itemOffset + 145);
            item.FskillAchivement1 = BitConverter.ToUInt16(file, itemOffset + 147);
            item.FskillAchivement2 = BitConverter.ToUInt16(file, itemOffset + 149);
            item.FskillAchivement3 = BitConverter.ToUInt16(file, itemOffset + 151);
            item.KeyAchievement = BitConverter.ToUInt16(file, itemOffset + 153);
            item.IdeaBlue = file[itemOffset + 155];
            item.IdeaRed = file[itemOffset + 156];
            item.IdeaWhite = file[itemOffset + 157];
            item.IdeaBlack = file[itemOffset + 158];
            item.FavoriteCategory1 = BitConverter.ToUInt16(file, itemOffset + 159);
            item.FavoriteItem1 = BitConverter.ToUInt16(file, itemOffset + 161);
            item.FavoriteCategory2 = BitConverter.ToUInt16(file, itemOffset + 163);
            item.FavoriteItem2 = BitConverter.ToUInt16(file, itemOffset + 165);
            item.CreateEventID = BitConverter.ToUInt16(file, itemOffset + 167);
            item.NormalTalk = BitConverter.ToUInt16(file, itemOffset + 169);
            item.CollisionId = BitConverter.ToUInt16(file, itemOffset + 171);
            item.BladeSize = file[itemOffset + 173];
            item.MemorySlot = file[itemOffset + 174];
            item.EventAsset = BitConverter.ToUInt16(file, itemOffset + 175);
            item.CenterBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 177));
            item.CamBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 181));
            item.MerceName = BitConverter.ToUInt16(file, itemOffset + 185);
            item.ReleaseLock = file[itemOffset + 187];
            item.CreateInfo = BitConverter.ToUInt16(file, itemOffset + 188);
            item.ExtraParts1 = file[itemOffset + 190];
            item.ExtraParts2 = file[itemOffset + 191];
            item.ExtraParts3 = file[itemOffset + 192];
            item.ExtraParts4 = file[itemOffset + 193];
            item.MnuCastName = BitConverter.ToUInt16(file, itemOffset + 194);
            item.MnuIlustName = BitConverter.ToUInt16(file, itemOffset + 196);
            item.MnuVoice1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 198));
            item.MnuVoice2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 202));
            item.MnuVoice3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 206));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 210);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 214);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 218);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 222);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 226);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 230);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 234);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 238);
            item.OnlyWpn = (item.Flag & 1) != 0;
            item.NoBuildWpn = (item.Flag & 2) != 0;
            item.OnlyChBtl = (item.Flag & 4) != 0;
            item.FreeEngage = (item.Flag & 8) != 0;
            item.NoMapRev = (item.Flag & 16) != 0;
            return item;
        }

        public static CHR_Dr ReadCHR_Dr(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_Dr();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Race = file[itemOffset + 6];
            item.RotateLimitPitch = file[itemOffset + 7];
            item.RotateLimitRoll = file[itemOffset + 8];
            item.Gender = file[itemOffset + 9];
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Model2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.Still = BitConverter.ToUInt16(file, itemOffset + 24);
            item.OffsetID = BitConverter.ToUInt16(file, itemOffset + 26);
            item.EyeRot = file[itemOffset + 28];
            item.Voice = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 29));
            item.ClipEvent = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 33));
            item.Com_SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 37));
            item.Com_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 41));
            item.Com_Vo = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 45));
            item.AiID = BitConverter.ToUInt16(file, itemOffset + 49);
            item.ChestHeight = BitConverter.ToUInt16(file, itemOffset + 51);
            item.LandingHeight = BitConverter.ToUInt16(file, itemOffset + 53);
            item.FootStep = file[itemOffset + 55];
            item.FootStepEffect = file[itemOffset + 56];
            item.DefBlade1 = BitConverter.ToUInt16(file, itemOffset + 57);
            item.DefBlade2 = BitConverter.ToUInt16(file, itemOffset + 59);
            item.DefBlade3 = BitConverter.ToUInt16(file, itemOffset + 61);
            item.DefLvType = file[itemOffset + 63];
            item.DefLv = file[itemOffset + 64];
            item.DefWPType = file[itemOffset + 65];
            item.DefWP = BitConverter.ToUInt16(file, itemOffset + 66);
            item.DefSPType = file[itemOffset + 68];
            item.DefSP = BitConverter.ToUInt16(file, itemOffset + 69);
            item.DefAcce = BitConverter.ToUInt16(file, itemOffset + 71);
            item.DefIdeaBlue = file[itemOffset + 73];
            item.DefIdeaRed = file[itemOffset + 74];
            item.DefIdeaWhite = file[itemOffset + 75];
            item.DefIdeaBlack = file[itemOffset + 76];
            item.HpMaxLv1 = BitConverter.ToUInt16(file, itemOffset + 77);
            item.StrengthLv1 = BitConverter.ToUInt16(file, itemOffset + 79);
            item.PowEtherLv1 = BitConverter.ToUInt16(file, itemOffset + 81);
            item.DexLv1 = BitConverter.ToUInt16(file, itemOffset + 83);
            item.AgilityLv1 = BitConverter.ToUInt16(file, itemOffset + 85);
            item.LuckLv1 = BitConverter.ToUInt16(file, itemOffset + 87);
            item.HpMaxLv99 = BitConverter.ToUInt16(file, itemOffset + 89);
            item.StrengthLv99 = BitConverter.ToUInt16(file, itemOffset + 91);
            item.PowEtherLv99 = BitConverter.ToUInt16(file, itemOffset + 93);
            item.DexLv99 = BitConverter.ToUInt16(file, itemOffset + 95);
            item.AgilityLv99 = BitConverter.ToUInt16(file, itemOffset + 97);
            item.LuckLv99 = BitConverter.ToUInt16(file, itemOffset + 99);
            item.FavoriteCategory1 = BitConverter.ToUInt16(file, itemOffset + 169);
            item.FavoriteItem1 = BitConverter.ToUInt16(file, itemOffset + 171);
            item.FavoriteCategory2 = BitConverter.ToUInt16(file, itemOffset + 173);
            item.FavoriteItem2 = BitConverter.ToUInt16(file, itemOffset + 175);
            item.CollisionId = BitConverter.ToUInt16(file, itemOffset + 177);
            item.EventAsset = BitConverter.ToUInt16(file, itemOffset + 179);
            item.RotateX = (sbyte)file[itemOffset + 181];
            item.RotateY = (sbyte)file[itemOffset + 182];
            item.RotateZ = (sbyte)file[itemOffset + 183];
            item.RotateDeg = (sbyte)file[itemOffset + 184];
            item.RotEffScale = BitConverter.ToUInt16(file, itemOffset + 185);
            item.CenterBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 187));
            item.CamBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 191));
            item.Personality = file[itemOffset + 195];
            item.IraParam = BitConverter.ToUInt16(file, itemOffset + 196);
            for (int i = 0, offset = itemOffset + 101; i < 34; i++, offset += 1)
            {
                item.WpnType[i] = file[offset];
            }
            for (int i = 0, offset = itemOffset + 135; i < 34; i++, offset += 1)
            {
                item.WpRate[i] = file[offset];
            }
            return item;
        }

        public static CHR_DriverParam ReadCHR_DriverParam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_DriverParam();
            item.Id = itemId;
            item.ExtMountNpc = BitConverter.ToUInt16(file, itemOffset);
            item.ExtMountBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.ExtMountCond = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static CHR_EnArrange ReadCHR_EnArrange(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_EnArrange();
            item.Id = itemId;
            item.ParamID = BitConverter.ToUInt16(file, itemOffset);
            item.EnemyBladeID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.BladeID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.BladeAtr = file[itemOffset + 6];
            item.ExtraParts = file[itemOffset + 7];
            item.Name = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Debug_Name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.Lv = file[itemOffset + 14];
            item.LvRand = file[itemOffset + 15];
            item.HpOver = file[itemOffset + 16];
            item.ExpRev = BitConverter.ToUInt16(file, itemOffset + 17);
            item.GoldRev = BitConverter.ToUInt16(file, itemOffset + 19);
            item.WPRev = BitConverter.ToUInt16(file, itemOffset + 21);
            item.SPRev = BitConverter.ToUInt16(file, itemOffset + 23);
            item.DropTableID = BitConverter.ToUInt16(file, itemOffset + 25);
            item.DropTableID2 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.DropTableID3 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.PreciousID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.Score = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ECube = BitConverter.ToUInt16(file, itemOffset + 35);
            item.Scale = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ChrSize = file[itemOffset + 39];
            item.TurnSize = file[itemOffset + 40];
            item.CamSize = file[itemOffset + 41];
            item.Flag = BitConverter.ToUInt32(file, itemOffset + 42);
            item.LinkRadius = file[itemOffset + 46];
            item.Detects = file[itemOffset + 47];
            item.SearchRange = BitConverter.ToUInt16(file, itemOffset + 48);
            item.SearchAngle = BitConverter.ToUInt16(file, itemOffset + 50);
            item.SearchRadius = file[itemOffset + 52];
            item.BatInterval = file[itemOffset + 53];
            item.BatArea = file[itemOffset + 54];
            item.EN_WATER_DEAD_NONE = file[itemOffset + 55];
            item.BatAreaType = file[itemOffset + 56];
            item.DrawWait = file[itemOffset + 57];
            item.AiGroup = file[itemOffset + 58];
            item.AiGroupNum = file[itemOffset + 59];
            item.BookID = BitConverter.ToUInt16(file, itemOffset + 60);
            item.EnhanceID1 = BitConverter.ToUInt16(file, itemOffset + 62);
            item.EnhanceID2 = BitConverter.ToUInt16(file, itemOffset + 64);
            item.EnhanceID3 = BitConverter.ToUInt16(file, itemOffset + 66);
            item.ParamRev = BitConverter.ToUInt16(file, itemOffset + 68);
            item.RstDebuffRev = BitConverter.ToUInt16(file, itemOffset + 70);
            item.HealPotTypeRev = file[itemOffset + 72];
            item.SummonID = BitConverter.ToUInt16(file, itemOffset + 73);
            item.BGMID = file[itemOffset + 75];
            item.SeEnvID = file[itemOffset + 76];
            item.ZoneID = file[itemOffset + 77];
            item.TimeSet = file[itemOffset + 78];
            item.WeatherSet = file[itemOffset + 79];
            item.DriverLev = file[itemOffset + 80];
            item.Race = BitConverter.ToUInt16(file, itemOffset + 81);
            item.LvMin = file[itemOffset + 83];
            item.LvMax = file[itemOffset + 84];
            item.ScaleMin = BitConverter.ToUInt16(file, itemOffset + 85);
            item.ScaleMax = BitConverter.ToUInt16(file, itemOffset + 87);
            item.Named = (item.Flag & 1) != 0;
            item.mBoss = (item.Flag & 2) != 0;
            item.Child = (item.Flag & 4) != 0;
            item.FAOff = (item.Flag & 8) != 0;
            item.NoEcSkip = (item.Flag & 16) != 0;
            item.LinkType = (item.Flag & 32) != 0;
            item.ChrColiOff = (item.Flag & 64) != 0;
            item.NoTarget = (item.Flag & 128) != 0;
            item.HikariSP4 = (item.Flag & 256) != 0;
            item.Homuri = (item.Flag & 512) != 0;
            item.Hikari = (item.Flag & 1024) != 0;
            item.NoNaviMesh = (item.Flag & 2048) != 0;
            item.Fixed = (item.Flag & 4096) != 0;
            item.DropFront = (item.Flag & 8192) != 0;
            item.NoWarp = (item.Flag & 16384) != 0;
            item.IgnoreLevPow = (item.Flag & 32768) != 0;
            item.AlwaysAttack = (item.Flag & 65536) != 0;
            item.PGMax = (item.Flag & 131072) != 0;
            item.Salvage = (item.Flag & 262144) != 0;
            return item;
        }

        public static CHR_EnParam ReadCHR_EnParam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_EnParam();
            item.Id = itemId;
            item.Debug_Name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ResourceID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.AiID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EnemyRole = file[itemOffset + 8];
            item.WalkSpeed = file[itemOffset + 9];
            item.RunSpeed = file[itemOffset + 10];
            item.BtlSpeed = file[itemOffset + 11];
            item.HpDefault = file[itemOffset + 12];
            item.HpLimit = file[itemOffset + 13];
            item.ScoutStartHp = file[itemOffset + 14];
            item.ScoutJoinRad = file[itemOffset + 15];
            item.ScoutEndHp = file[itemOffset + 16];
            item.HpMaxRev = BitConverter.ToUInt16(file, itemOffset + 17);
            item.StrengthRev = BitConverter.ToUInt16(file, itemOffset + 19);
            item.PowEtherRev = BitConverter.ToUInt16(file, itemOffset + 21);
            item.DexRev = BitConverter.ToUInt16(file, itemOffset + 23);
            item.AgilityRev = BitConverter.ToUInt16(file, itemOffset + 25);
            item.LuckRev = BitConverter.ToUInt16(file, itemOffset + 27);
            item.Parmor = BitConverter.ToUInt16(file, itemOffset + 29);
            item.Earmor = BitConverter.ToUInt16(file, itemOffset + 31);
            item.RstPower = (sbyte)file[itemOffset + 33];
            item.RstEther = (sbyte)file[itemOffset + 34];
            item.Atr = file[itemOffset + 35];
            item.RstFire = (sbyte)file[itemOffset + 36];
            item.RstWater = (sbyte)file[itemOffset + 37];
            item.RstWind = (sbyte)file[itemOffset + 38];
            item.RstEarth = (sbyte)file[itemOffset + 39];
            item.RstThunder = (sbyte)file[itemOffset + 40];
            item.RstIce = (sbyte)file[itemOffset + 41];
            item.RstDark = (sbyte)file[itemOffset + 42];
            item.RstLight = (sbyte)file[itemOffset + 43];
            item.CriticalRate = file[itemOffset + 44];
            item.GuardRate = file[itemOffset + 45];
            item.Flag = file[itemOffset + 46];
            item.HealPotDrop = file[itemOffset + 47];
            item.RstDebuff = BitConverter.ToUInt32(file, itemOffset + 48);
            item.IvdDebuff = BitConverter.ToUInt32(file, itemOffset + 52);
            item.WeakDebuff = BitConverter.ToUInt32(file, itemOffset + 56);
            item.RstFiCombo = BitConverter.ToUInt16(file, itemOffset + 60);
            item.IvdFiCombo = BitConverter.ToUInt16(file, itemOffset + 62);
            item.Aura = BitConverter.ToUInt16(file, itemOffset + 64);
            item.AwakeLev = file[itemOffset + 66];
            item.DyingHP = file[itemOffset + 67];
            item.WTNormal = file[itemOffset + 68];
            item.WTDying = file[itemOffset + 69];
            item.Hate0Target = file[itemOffset + 70];
            item.DeathArts = BitConverter.ToUInt16(file, itemOffset + 71);
            item.DeathArtsStop = BitConverter.ToUInt32(file, itemOffset + 73);
            item.ArtsNum1 = BitConverter.ToUInt16(file, itemOffset + 77);
            item.ArtsNum2 = BitConverter.ToUInt16(file, itemOffset + 79);
            item.ArtsNum3 = BitConverter.ToUInt16(file, itemOffset + 81);
            item.ArtsNum4 = BitConverter.ToUInt16(file, itemOffset + 83);
            item.ArtsNum5 = BitConverter.ToUInt16(file, itemOffset + 85);
            item.ArtsNum6 = BitConverter.ToUInt16(file, itemOffset + 87);
            item.ArtsNum7 = BitConverter.ToUInt16(file, itemOffset + 89);
            item.ArtsNum8 = BitConverter.ToUInt16(file, itemOffset + 91);
            item.ArtsNum9 = BitConverter.ToUInt16(file, itemOffset + 93);
            item.ArtsNum10 = BitConverter.ToUInt16(file, itemOffset + 95);
            item.ArtsNum11 = BitConverter.ToUInt16(file, itemOffset + 97);
            item.ArtsNum12 = BitConverter.ToUInt16(file, itemOffset + 99);
            item.ArtsNum13 = BitConverter.ToUInt16(file, itemOffset + 101);
            item.ArtsNum14 = BitConverter.ToUInt16(file, itemOffset + 103);
            item.ArtsNum15 = BitConverter.ToUInt16(file, itemOffset + 105);
            item.ArtsNum16 = BitConverter.ToUInt16(file, itemOffset + 107);
            item.NormalAttackTop = BitConverter.ToUInt16(file, itemOffset + 109);
            item.GrdDirFront = (item.Flag & 1) != 0;
            item.GrdDirLeft = (item.Flag & 2) != 0;
            item.GrdDirRight = (item.Flag & 4) != 0;
            item.GrdDirBack = (item.Flag & 8) != 0;
            item.FldDmgType = (item.Flag & 16) != 0;
            item.TrgRndLady = (item.Flag & 32) != 0;
            return item;
        }

        public static CHR_EnParam_Rev ReadCHR_EnParam_Rev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_EnParam_Rev();
            item.Id = itemId;
            item.HpMaxRev = BitConverter.ToUInt16(file, itemOffset);
            item.StrengthRev = BitConverter.ToUInt16(file, itemOffset + 2);
            item.PowEtherRev = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DexRev = BitConverter.ToUInt16(file, itemOffset + 6);
            item.AgilityRev = BitConverter.ToUInt16(file, itemOffset + 8);
            item.LuckRev = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static CHR_EnParamTable ReadCHR_EnParamTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_EnParamTable();
            item.Id = itemId;
            item.HpMaxBase = BitConverter.ToUInt32(file, itemOffset);
            item.StrengthBase = BitConverter.ToUInt16(file, itemOffset + 4);
            item.PowEtherBase = BitConverter.ToUInt16(file, itemOffset + 6);
            item.DexBase = BitConverter.ToUInt16(file, itemOffset + 8);
            item.AgilityBase = BitConverter.ToUInt16(file, itemOffset + 10);
            item.LuckBase = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static CHR_EnRstDebuff_Rev ReadCHR_EnRstDebuff_Rev(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_EnRstDebuff_Rev();
            item.Id = itemId;
            item.RevType = file[itemOffset];
            item.RstFiCombo = BitConverter.ToUInt16(file, itemOffset + 1);
            item.IvdFiCombo = BitConverter.ToUInt16(file, itemOffset + 3);
            item.RstDebuffRev = BitConverter.ToUInt32(file, itemOffset + 5);
            item.IvdDebuffRev = BitConverter.ToUInt32(file, itemOffset + 9);
            item.WeakDebuffRev = BitConverter.ToUInt32(file, itemOffset + 13);
            return item;
        }

        public static CHR_Ir ReadCHR_Ir(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new CHR_Ir();
            item.Id = itemId;
            item.driverID = BitConverter.ToUInt16(file, itemOffset);
            item.Type = file[itemOffset + 2];
            item.GroupID = file[itemOffset + 3];
            item.DriverWpn = file[itemOffset + 4];
            item.DefWpnAcce = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Flag = file[itemOffset + 7];
            item.LinkSet = BitConverter.ToUInt16(file, itemOffset + 8);
            item.WpnInNonView = (item.Flag & 1) != 0;
            return item;
        }

        public static COL_CharList ReadCOL_CharList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new COL_CharList();
            item.Id = itemId;
            item.Radius = BitConverter.ToUInt16(file, itemOffset);
            item.Height = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static EFF_KizunaLink ReadEFF_KizunaLink(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EFF_KizunaLink();
            item.Id = itemId;
            item.WavePower = BitConverter.ToInt16(file, itemOffset);
            item.WaveInterval = BitConverter.ToInt16(file, itemOffset + 2);
            item.WaveSpeed = BitConverter.ToInt16(file, itemOffset + 4);
            item.UTiling = BitConverter.ToInt16(file, itemOffset + 6);
            item.VTiling = BitConverter.ToInt16(file, itemOffset + 8);
            item.UScroll = BitConverter.ToInt16(file, itemOffset + 10);
            item.VScroll = BitConverter.ToInt16(file, itemOffset + 12);
            item.Bloom = BitConverter.ToInt16(file, itemOffset + 14);
            item.Red1 = file[itemOffset + 16];
            item.Green1 = file[itemOffset + 17];
            item.Blue1 = file[itemOffset + 18];
            item.Alpha1 = file[itemOffset + 19];
            item.Red2 = file[itemOffset + 20];
            item.Green2 = file[itemOffset + 21];
            item.Blue2 = file[itemOffset + 22];
            item.Alpha2 = file[itemOffset + 23];
            item.Texture = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            return item;
        }

        public static EventChange ReadEventChange(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EventChange();
            item.Id = itemId;
            item.chgName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.chgType = (sbyte)file[itemOffset + 4];
            item.id = BitConverter.ToInt32(file, itemOffset + 5);
            item.value0 = BitConverter.ToInt32(file, itemOffset + 9);
            item.value1 = BitConverter.ToInt32(file, itemOffset + 13);
            item.string0 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 17));
            return item;
        }

        public static EventGroup ReadEventGroup(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EventGroup();
            item.Id = itemId;
            item.grpName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.grpNameJP = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.atrDisp = file[itemOffset + 8];
            item.atrName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 9));
            item.atrNameJP = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 13));
            item.atrType = file[itemOffset + 17];
            item.atrOptStr1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.atrOptStr2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 22));
            item.atrDefStr1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 26));
            return item;
        }

        public static EVT_acttype ReadEVT_acttype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_acttype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.stat0 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.stat1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.stat2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 14));
            item.statI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.cmd0 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 22));
            item.cmd1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 26));
            item.cmd2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 30));
            return item;
        }

        public static EVT_assetList ReadEVT_assetList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_assetList();
            item.Id = itemId;
            item.facialSeat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.lensID = BitConverter.ToInt16(file, itemOffset + 4);
            return item;
        }

        public static EVT_bgm ReadEVT_bgm(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_bgm();
            item.Id = itemId;
            item.nodeName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.nodeNameJP = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.nodeExtra = file[itemOffset + 8];
            item.nodeWidth = file[itemOffset + 9];
            item.grpName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.grpNameJP = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 14));
            item.grpExtra = file[itemOffset + 18];
            item.grpArray = file[itemOffset + 19];
            item.atrDisp = file[itemOffset + 20];
            item.atrName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 21));
            item.atrNameJP = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 25));
            item.atrType = file[itemOffset + 29];
            item.atrOptStr1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 30));
            item.atrOptStr2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 34));
            item.atrDefStr1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 38));
            return item;
        }

        public static EVT_cutscene_bl ReadEVT_cutscene_bl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_cutscene_bl();
            item.Id = itemId;
            item.resource = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.id = BitConverter.ToInt16(file, itemOffset + 4);
            return item;
        }

        public static EVT_cutscene_pc ReadEVT_cutscene_pc(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_cutscene_pc();
            item.Id = itemId;
            item.resource = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.id = BitConverter.ToInt16(file, itemOffset + 4);
            item.scenarioMin = BitConverter.ToInt32(file, itemOffset + 6);
            item.scenarioMax = BitConverter.ToInt32(file, itemOffset + 10);
            return item;
        }

        public static EVT_cutscene_wp ReadEVT_cutscene_wp(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_cutscene_wp();
            item.Id = itemId;
            item.id = BitConverter.ToInt16(file, itemOffset);
            item.blade = BitConverter.ToInt16(file, itemOffset + 2);
            item.resourceR = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.resourceL = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.scenarioMin = BitConverter.ToInt32(file, itemOffset + 12);
            item.scenarioMax = BitConverter.ToInt32(file, itemOffset + 16);
            return item;
        }

        public static EVT_dof ReadEVT_dof(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_dof();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.dist = BitConverter.ToSingle(file, itemOffset + 4);
            item.range = BitConverter.ToSingle(file, itemOffset + 8);
            item.foMin = BitConverter.ToSingle(file, itemOffset + 12);
            item.pixel = BitConverter.ToSingle(file, itemOffset + 16);
            item.lens = BitConverter.ToSingle(file, itemOffset + 20);
            item.strength = BitConverter.ToSingle(file, itemOffset + 24);
            item.blend = BitConverter.ToSingle(file, itemOffset + 28);
            item.pixelLv = BitConverter.ToInt16(file, itemOffset + 32);
            item.hlv = BitConverter.ToInt16(file, itemOffset + 34);
            return item;
        }

        public static EVT_eyetype ReadEVT_eyetype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_eyetype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.stat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.disableWink = (sbyte)file[itemOffset + 10];
            return item;
        }

        public static EVT_facialtype ReadEVT_facialtype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_facialtype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static EVT_formation ReadEVT_formation(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_formation();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ofsX = BitConverter.ToSingle(file, itemOffset + 4);
            item.ofsZ = BitConverter.ToSingle(file, itemOffset + 8);
            item.rot = BitConverter.ToSingle(file, itemOffset + 12);
            return item;
        }

        public static EVT_headtype ReadEVT_headtype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_headtype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.stat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.blend = BitConverter.ToInt16(file, itemOffset + 10);
            item.weight = BitConverter.ToSingle(file, itemOffset + 12);
            return item;
        }

        public static EVT_lens ReadEVT_lens(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_lens();
            item.Id = itemId;
            item.thMin = BitConverter.ToInt16(file, itemOffset);
            item.thMax = BitConverter.ToInt16(file, itemOffset + 2);
            item.tvMin = BitConverter.ToInt16(file, itemOffset + 4);
            item.tvMax = BitConverter.ToInt16(file, itemOffset + 6);
            item.rhMin = BitConverter.ToInt16(file, itemOffset + 8);
            item.rhMax = BitConverter.ToInt16(file, itemOffset + 10);
            item.rvMin = BitConverter.ToInt16(file, itemOffset + 12);
            item.rvMax = BitConverter.ToInt16(file, itemOffset + 14);
            return item;
        }

        public static EVT_liptype ReadEVT_liptype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_liptype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.stat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.disableTalkLip = (sbyte)file[itemOffset + 10];
            return item;
        }

        public static EVT_listBf ReadEVT_listBf(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listBf();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.cssnd = file[itemOffset + 126];
            item.scenarioFlag = BitConverter.ToUInt16(file, itemOffset + 127);
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 129));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 133);
            item.nextIDtheater = BitConverter.ToUInt16(file, itemOffset + 137);
            item.toneMap = BitConverter.ToSingle(file, itemOffset + 139);
            return item;
        }

        public static EVT_listBl ReadEVT_listBl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listBl();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.cssnd = file[itemOffset + 126];
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 127));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 131);
            item.toneMap = BitConverter.ToSingle(file, itemOffset + 135);
            return item;
        }

        public static EVT_listDeb01 ReadEVT_listDeb01(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listDeb01();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.cssnd = file[itemOffset + 126];
            item.centerID = BitConverter.ToUInt16(file, itemOffset + 127);
            item.centerX = BitConverter.ToSingle(file, itemOffset + 129);
            item.centerY = BitConverter.ToSingle(file, itemOffset + 133);
            item.centerZ = BitConverter.ToSingle(file, itemOffset + 137);
            item.centerR = BitConverter.ToSingle(file, itemOffset + 141);
            item.centerForm = BitConverter.ToUInt16(file, itemOffset + 145);
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 147));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 151);
            item.nextIDtheater = BitConverter.ToUInt16(file, itemOffset + 155);
            item.toneMap = BitConverter.ToSingle(file, itemOffset + 157);
            return item;
        }

        public static EVT_listFev01 ReadEVT_listFev01(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listFev01();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.centerID = BitConverter.ToUInt16(file, itemOffset + 126);
            item.centerX = BitConverter.ToSingle(file, itemOffset + 128);
            item.centerY = BitConverter.ToSingle(file, itemOffset + 132);
            item.centerZ = BitConverter.ToSingle(file, itemOffset + 136);
            item.centerR = BitConverter.ToSingle(file, itemOffset + 140);
            item.centerForm = BitConverter.ToUInt16(file, itemOffset + 144);
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 146));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 150);
            item.toneMap = BitConverter.ToSingle(file, itemOffset + 154);
            return item;
        }

        public static EVT_listList ReadEVT_listList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listList();
            item.Id = itemId;
            item.type = file[itemOffset];
            item.chap = file[itemOffset + 1];
            item.listSeat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.setupSeat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.chgSeat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.target = file[itemOffset + 14];
            return item;
        }

        public static EVT_listQst01 ReadEVT_listQst01(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listQst01();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.centerID = BitConverter.ToUInt16(file, itemOffset + 126);
            item.centerX = BitConverter.ToSingle(file, itemOffset + 128);
            item.centerY = BitConverter.ToSingle(file, itemOffset + 132);
            item.centerZ = BitConverter.ToSingle(file, itemOffset + 136);
            item.centerR = BitConverter.ToSingle(file, itemOffset + 140);
            item.centerForm = BitConverter.ToUInt16(file, itemOffset + 144);
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 146));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 150);
            item.nextIDtheater = BitConverter.ToUInt16(file, itemOffset + 154);
            item.toneMap = BitConverter.ToSingle(file, itemOffset + 156);
            return item;
        }

        public static EVT_listTlk01 ReadEVT_listTlk01(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_listTlk01();
            item.Id = itemId;
            item.evtName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.mstxt = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.setupID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.chgStID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.chgEdID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.category = file[itemOffset + 14];
            item.weather = file[itemOffset + 15];
            item.clock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.clockStop = file[itemOffset + 20];
            item.cloud = file[itemOffset + 21];
            item.text = file[itemOffset + 22];
            item.opFadeOutEnable = file[itemOffset + 23];
            item.opFadeOut = BitConverter.ToUInt16(file, itemOffset + 24);
            item.opFadeWait = BitConverter.ToUInt16(file, itemOffset + 26);
            item.opFadeInEnable = file[itemOffset + 28];
            item.opFadeIn = BitConverter.ToUInt16(file, itemOffset + 29);
            item.opFadeColR = file[itemOffset + 31];
            item.opFadeColG = file[itemOffset + 32];
            item.opFadeColB = file[itemOffset + 33];
            item.edFadeOutEnable = file[itemOffset + 34];
            item.edFadeOut = BitConverter.ToUInt16(file, itemOffset + 35);
            item.edFadeWait = BitConverter.ToUInt16(file, itemOffset + 37);
            item.edFadeInEnable = file[itemOffset + 39];
            item.edFadeIn = BitConverter.ToUInt16(file, itemOffset + 40);
            item.edFadeColR = file[itemOffset + 42];
            item.edFadeColG = file[itemOffset + 43];
            item.edFadeColB = file[itemOffset + 44];
            item.stFormID = BitConverter.ToUInt16(file, itemOffset + 45);
            item.edFormID = BitConverter.ToUInt16(file, itemOffset + 47);
            item.opBgm = file[itemOffset + 49];
            item.edBgm = file[itemOffset + 50];
            item.hideNpc = file[itemOffset + 51];
            item.hideEne = file[itemOffset + 52];
            item.hideMob = file[itemOffset + 53];
            item.hideMap = file[itemOffset + 54];
            item.outsiderOpt = BitConverter.ToUInt16(file, itemOffset + 55);
            item.outsiderEnable = file[itemOffset + 57];
            item.outsiderType = file[itemOffset + 58];
            item.outsiderX = BitConverter.ToSingle(file, itemOffset + 59);
            item.outsiderY = BitConverter.ToSingle(file, itemOffset + 63);
            item.outsiderZ = BitConverter.ToSingle(file, itemOffset + 67);
            item.outsiderR = BitConverter.ToSingle(file, itemOffset + 71);
            item.listenType = file[itemOffset + 75];
            item.listenX = BitConverter.ToSingle(file, itemOffset + 76);
            item.listenY = BitConverter.ToSingle(file, itemOffset + 80);
            item.listenZ = BitConverter.ToSingle(file, itemOffset + 84);
            item.nextID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.zoneID = BitConverter.ToUInt16(file, itemOffset + 90);
            item.zoneX = BitConverter.ToSingle(file, itemOffset + 92);
            item.zoneY = BitConverter.ToSingle(file, itemOffset + 96);
            item.zoneZ = BitConverter.ToSingle(file, itemOffset + 100);
            item.zoneR = BitConverter.ToSingle(file, itemOffset + 104);
            item.chapID = file[itemOffset + 108];
            item.linkID = BitConverter.ToUInt16(file, itemOffset + 109);
            item.jijiDisp = file[itemOffset + 111];
            item.wpnDisp = BitConverter.ToUInt16(file, itemOffset + 112);
            item.colFilterNear = BitConverter.ToUInt16(file, itemOffset + 114);
            item.colFilterFar = BitConverter.ToUInt16(file, itemOffset + 116);
            item.envSeam = BitConverter.ToUInt16(file, itemOffset + 118);
            item.evtLight = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.hood = file[itemOffset + 124];
            item.voice = file[itemOffset + 125];
            item.scriptName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 126));
            item.scriptStartId = BitConverter.ToInt32(file, itemOffset + 130);
            return item;
        }

        public static EVT_nearfar ReadEVT_nearfar(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_nearfar();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.near = BitConverter.ToSingle(file, itemOffset + 4);
            item.far = BitConverter.ToSingle(file, itemOffset + 8);
            return item;
        }

        public static EVT_randtype ReadEVT_randtype(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_randtype();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.value = BitConverter.ToInt16(file, itemOffset + 4);
            item.id = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            return item;
        }

        public static EVT_setup ReadEVT_setup(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_setup();
            item.Id = itemId;
            item.setupName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.objName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.objType = (sbyte)file[itemOffset + 8];
            item.objID = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 9));
            item.objModel = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 13));
            item.wpnBlade = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 17));
            return item;
        }

        public static EVT_setupB ReadEVT_setupB(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new EVT_setupB();
            item.Id = itemId;
            item.setupName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.objName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.objType = file[itemOffset + 8];
            item.objID = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 9));
            item.objModel = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 13));
            item.wpnBlade = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 17));
            return item;
        }

        public static FacialConfig ReadFacialConfig(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FacialConfig();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.brow_type = BitConverter.ToInt16(file, itemOffset + 4);
            item.brow_weight = BitConverter.ToSingle(file, itemOffset + 6);
            item.eye_type = BitConverter.ToInt16(file, itemOffset + 10);
            item.eye_weight = BitConverter.ToSingle(file, itemOffset + 12);
            item.lip_type = BitConverter.ToInt16(file, itemOffset + 16);
            item.lip_weight = BitConverter.ToSingle(file, itemOffset + 18);
            item.facial_blend = BitConverter.ToInt16(file, itemOffset + 22);
            item.talk_head_weight = BitConverter.ToSingle(file, itemOffset + 24);
            item.talk_head_speed = BitConverter.ToSingle(file, itemOffset + 28);
            item.talk_lip_weight = BitConverter.ToSingle(file, itemOffset + 32);
            item.talk_lip_speed = BitConverter.ToSingle(file, itemOffset + 36);
            item.talk_blend = BitConverter.ToInt16(file, itemOffset + 40);
            return item;
        }

        public static FLD_Achievement ReadFLD_Achievement(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_Achievement();
            item.Id = itemId;
            item.StatsID = BitConverter.ToUInt16(file, itemOffset);
            item.Count = BitConverter.ToUInt32(file, itemOffset + 2);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            return item;
        }

        public static FLD_AchievementList ReadFLD_AchievementList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_AchievementList();
            item.Id = itemId;
            item.Title = BitConverter.ToUInt16(file, itemOffset);
            item.Category = file[itemOffset + 2];
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Task = BitConverter.ToUInt16(file, itemOffset + 5);
            item.VoiceCategory = BitConverter.ToUInt16(file, itemOffset + 7);
            item.AfterVoice = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Difficulty = file[itemOffset + 11];
            item.IdeaCategory = file[itemOffset + 12];
            item.IdeaValue = BitConverter.ToUInt16(file, itemOffset + 13);
            return item;
        }

        public static FLD_AchievementSet ReadFLD_AchievementSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_AchievementSet();
            item.Id = itemId;
            item.Category = file[itemOffset];
            item.AbilityLevel = file[itemOffset + 1];
            item.AchievementID1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.AchievementID2 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.AchievementID3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.AchievementID4 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.AchievementID5 = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static FLD_actorSE ReadFLD_actorSE(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_actorSE();
            item.Id = itemId;
            item.LOD = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.se_type = file[itemOffset + 4];
            item.seName = BitConverter.ToUInt16(file, itemOffset + 5);
            item.max_volume_Dist = BitConverter.ToSingle(file, itemOffset + 7);
            item.min_volume_Dist = BitConverter.ToSingle(file, itemOffset + 11);
            item.volumeMAX = file[itemOffset + 15];
            item.volumeMIN = file[itemOffset + 16];
            item.offsetX = BitConverter.ToSingle(file, itemOffset + 17);
            item.offsetY = BitConverter.ToSingle(file, itemOffset + 21);
            item.offsetZ = BitConverter.ToSingle(file, itemOffset + 25);
            return item;
        }

        public static FLD_AddItem ReadFLD_AddItem(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_AddItem();
            item.Id = itemId;
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset);
            item.ItemNumber1 = (sbyte)file[itemOffset + 2];
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.ItemNumber2 = (sbyte)file[itemOffset + 5];
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ItemNumber3 = (sbyte)file[itemOffset + 8];
            return item;
        }

        public static FLD_AntiBladeArea ReadFLD_AntiBladeArea(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_AntiBladeArea();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.BTL_MapRevId = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_BattleChallange ReadFLD_BattleChallange(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_BattleChallange();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlagMin = file[itemOffset + 6];
            item.QuestFlagMax = file[itemOffset + 7];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static FLD_BladePop ReadFLD_BladePop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_BladePop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.BladeSizeCheck = file[itemOffset + 4];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 5);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 7);
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 11);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 13);
            item.NpcTurn = file[itemOffset + 15];
            item.LookAt = file[itemOffset + 16];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 17);
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 19);
            item.BattleMot = BitConverter.ToUInt16(file, itemOffset + 21);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 25);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 27);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 29);
            return item;
        }

        public static FLD_BtnChallenge ReadFLD_BtnChallenge(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_BtnChallenge();
            item.Id = itemId;
            item.Start = BitConverter.ToUInt16(file, itemOffset);
            item.Speed = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Gsuccess = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Success = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_CampPop ReadFLD_CampPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_CampPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ConditionID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.CampPointName = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_ClimbingPOP ReadFLD_ClimbingPOP(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ClimbingPOP();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlagMin = file[itemOffset + 10];
            item.QuestFlagMax = file[itemOffset + 11];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.OP_gimmickType = file[itemOffset + 14];
            item.OP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 15);
            item.climiconRadius = BitConverter.ToUInt16(file, itemOffset + 17);
            return item;
        }

        public static FLD_CollectionTable ReadFLD_CollectionTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_CollectionTable();
            item.Id = itemId;
            item.FSID = BitConverter.ToUInt16(file, itemOffset);
            item.randitmPopMin = file[itemOffset + 2];
            item.randitmPopMax = file[itemOffset + 3];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.itm1Per = file[itemOffset + 6];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.itm2Per = file[itemOffset + 9];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.itm3Per = file[itemOffset + 12];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.itm4Per = file[itemOffset + 15];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 16);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 20);
            item.goldPopMin = file[itemOffset + 24];
            item.goldPopMax = file[itemOffset + 25];
            item.rsc_paramID = file[itemOffset + 26];
            return item;
        }

        public static FLD_ConditionAchievement ReadFLD_ConditionAchievement(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionAchievement();
            item.Id = itemId;
            item.AchievementSetID = BitConverter.ToUInt16(file, itemOffset);
            item.Value = file[itemOffset + 2];
            return item;
        }

        public static FLD_ConditionEnv ReadFLD_ConditionEnv(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionEnv();
            item.Id = itemId;
            item.TimeRange = BitConverter.ToUInt32(file, itemOffset);
            item.Weather = BitConverter.ToUInt32(file, itemOffset + 4);
            item.CloudHeight = file[itemOffset + 8];
            return item;
        }

        public static FLD_ConditionFieldSkiiLevel ReadFLD_ConditionFieldSkiiLevel(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionFieldSkiiLevel();
            item.Id = itemId;
            item.FieldSkillID = BitConverter.ToUInt16(file, itemOffset);
            item.Level = file[itemOffset + 2];
            return item;
        }

        public static FLD_ConditionFlag ReadFLD_ConditionFlag(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionFlag();
            item.Id = itemId;
            item.FlagType = file[itemOffset];
            item.FlagID = BitConverter.ToUInt16(file, itemOffset + 1);
            item.FlagMin = BitConverter.ToUInt16(file, itemOffset + 3);
            item.FlagMax = BitConverter.ToUInt16(file, itemOffset + 5);
            return item;
        }

        public static FLD_ConditionIdea ReadFLD_ConditionIdea(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionIdea();
            item.Id = itemId;
            item.PCID = BitConverter.ToUInt16(file, itemOffset);
            item.IdeaLevelBlue = file[itemOffset + 2];
            item.IdeaLevelRed = file[itemOffset + 3];
            item.IdeaLevelWhite = file[itemOffset + 4];
            item.IdeaLevelBlack = file[itemOffset + 5];
            item.Compatibility = BitConverter.ToUInt16(file, itemOffset + 6);
            item.TrustPoint = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static FLD_ConditionItem ReadFLD_ConditionItem(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionItem();
            item.Id = itemId;
            item.ItemCategory = file[itemOffset];
            item.ItemID = BitConverter.ToUInt16(file, itemOffset + 1);
            item.Number = file[itemOffset + 3];
            return item;
        }

        public static FLD_ConditionLevel ReadFLD_ConditionLevel(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionLevel();
            item.Id = itemId;
            item.PCID = BitConverter.ToUInt16(file, itemOffset);
            item.Level = file[itemOffset + 2];
            return item;
        }

        public static FLD_ConditionList ReadFLD_ConditionList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionList();
            item.Id = itemId;
            item.Premise = file[itemOffset];
            item.ConditionType1 = file[itemOffset + 1];
            item.Condition1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ConditionType2 = file[itemOffset + 4];
            item.Condition2 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.ConditionType3 = file[itemOffset + 7];
            item.Condition3 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ConditionType4 = file[itemOffset + 10];
            item.Condition4 = BitConverter.ToUInt16(file, itemOffset + 11);
            item.ConditionType5 = file[itemOffset + 13];
            item.Condition5 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ConditionType6 = file[itemOffset + 16];
            item.Condition6 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.ConditionType7 = file[itemOffset + 19];
            item.Condition7 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.ConditionType8 = file[itemOffset + 22];
            item.Condition8 = BitConverter.ToUInt16(file, itemOffset + 23);
            return item;
        }

        public static FLD_ConditionMapGimmick ReadFLD_ConditionMapGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionMapGimmick();
            item.Id = itemId;
            item.MapGimmickID = BitConverter.ToUInt16(file, itemOffset);
            item.EndCheck = file[itemOffset + 2];
            return item;
        }

        public static FLD_ConditionNamed ReadFLD_ConditionNamed(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionNamed();
            item.Id = itemId;
            item.Named = BitConverter.ToUInt16(file, itemOffset);
            item.Difficult = file[itemOffset + 2];
            return item;
        }

        public static FLD_ConditionPT ReadFLD_ConditionPT(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionPT();
            item.Id = itemId;
            item.Category = file[itemOffset];
            item.PCID1 = BitConverter.ToUInt16(file, itemOffset + 1);
            item.PCID2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.PCID3 = BitConverter.ToUInt16(file, itemOffset + 5);
            return item;
        }

        public static FLD_ConditionQuest ReadFLD_ConditionQuest(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionQuest();
            item.Id = itemId;
            item.QuestFlag1 = BitConverter.ToUInt16(file, itemOffset);
            item.QuestFlagMin1 = file[itemOffset + 2];
            item.QuestFlagMax1 = file[itemOffset + 3];
            item.QuestFlag2 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlagMin2 = file[itemOffset + 6];
            item.QuestFlagMax2 = file[itemOffset + 7];
            item.NotQuestFlag1 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.NotQuestFlagMin1 = file[itemOffset + 10];
            item.NotQuestFlagMax1 = file[itemOffset + 11];
            item.NotQuestFlag2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.NotQuestFlagMin2 = file[itemOffset + 14];
            item.NotQuestFlagMax2 = file[itemOffset + 15];
            return item;
        }

        public static FLD_ConditionScenario ReadFLD_ConditionScenario(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ConditionScenario();
            item.Id = itemId;
            item.ScenarioMin = BitConverter.ToUInt16(file, itemOffset);
            item.ScenarioMax = BitConverter.ToUInt16(file, itemOffset + 2);
            item.NotScenarioMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NotScenarioMax = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_DMGFloor ReadFLD_DMGFloor(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_DMGFloor();
            item.Id = itemId;
            item.Condition = BitConverter.ToUInt16(file, itemOffset);
            item.MAPID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.attributeID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DMG_interval = BitConverter.ToSingle(file, itemOffset + 6);
            item.Pc_dmg = file[itemOffset + 10];
            item.EN_dmg = file[itemOffset + 11];
            return item;
        }

        public static FLD_DMGGimmick ReadFLD_DMGGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_DMGGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DEPOP_gimmickType = file[itemOffset + 6];
            item.DEPOP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.DEPOP_Condition = BitConverter.ToUInt16(file, itemOffset + 9);
            item.DMG_interval = BitConverter.ToSingle(file, itemOffset + 11);
            item.Pc_dmg = file[itemOffset + 15];
            item.EN_dmg = file[itemOffset + 16];
            item.effect_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 17));
            item.SE_name = file[itemOffset + 21];
            item.volumeMAX = file[itemOffset + 22];
            item.volumeMIN = file[itemOffset + 23];
            item.effect_disp_r = BitConverter.ToUInt16(file, itemOffset + 24);
            item.effect_release_r = file[itemOffset + 26];
            item.dmggim_nextwait = BitConverter.ToInt16(file, itemOffset + 27);
            return item;
        }

        public static FLD_DoorGimmick ReadFLD_DoorGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_DoorGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.gimmickType = file[itemOffset + 6];
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.OP_gimmickType = file[itemOffset + 9];
            item.OP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.response_type = file[itemOffset + 12];
            item.response_CHR = file[itemOffset + 13];
            item.tgtMSG_ID = BitConverter.ToUInt16(file, itemOffset + 14);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 16);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.LODmodel = BitConverter.ToUInt16(file, itemOffset + 20);
            item.missMSG_ID = BitConverter.ToUInt16(file, itemOffset + 22);
            item.flag = file[itemOffset + 24];
            item.open_SE = BitConverter.ToUInt16(file, itemOffset + 25);
            item.open_SE_size = file[itemOffset + 27];
            item.open_camGim_ID = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.open_camGim_ATR = file[itemOffset + 32];
            item.close_SE = BitConverter.ToUInt16(file, itemOffset + 33);
            item.close_SE_size = file[itemOffset + 35];
            item.close_camGim_ID = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.close_camGim_ATR = file[itemOffset + 40];
            item.door_nextwait = BitConverter.ToSingle(file, itemOffset + 41);
            item.SPOP_gimmickType = file[itemOffset + 45];
            item.SPOP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 46);
            item.sp_close_camGim_ID = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.sp_close_camGim_ATR = file[itemOffset + 52];
            item.open_LODanime = (item.flag & 1) != 0;
            item.open_SE_type = (item.flag & 2) != 0;
            item.close_LODanime = (item.flag & 4) != 0;
            item.close_SE_type = (item.flag & 8) != 0;
            item.gmkCamPos = (item.flag & 16) != 0;
            return item;
        }

        public static FLD_EffectPop ReadFLD_EffectPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_EffectPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlagMin = file[itemOffset + 10];
            item.QuestFlagMax = file[itemOffset + 11];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static FLD_ElevatorGimmick ReadFLD_ElevatorGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ElevatorGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.OP_Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.tgt_callswitchMSG_ID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.callnameRadius = BitConverter.ToUInt16(file, itemOffset + 8);
            item.call_offsetID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.tgt_liftswitchMSG_ID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.liftnameRadius = BitConverter.ToUInt16(file, itemOffset + 14);
            item.lift_offsetID = BitConverter.ToUInt16(file, itemOffset + 16);
            item.LIFTLOD = BitConverter.ToUInt16(file, itemOffset + 18);
            item.shtALOD = BitConverter.ToUInt16(file, itemOffset + 20);
            item.shtBLOD = BitConverter.ToUInt16(file, itemOffset + 22);
            item.switchALOD = BitConverter.ToUInt16(file, itemOffset + 24);
            item.switchBLOD = BitConverter.ToUInt16(file, itemOffset + 26);
            item.switchSE = BitConverter.ToUInt16(file, itemOffset + 28);
            item.shutterSE = BitConverter.ToUInt16(file, itemOffset + 30);
            item.LiftStartSE = BitConverter.ToUInt16(file, itemOffset + 32);
            item.LiftLoopSE = BitConverter.ToUInt16(file, itemOffset + 34);
            item.LiftStopSE = BitConverter.ToUInt16(file, itemOffset + 36);
            item.LiftMinVolDist = file[itemOffset + 38];
            item.LiftMaxVolDist = file[itemOffset + 39];
            item.flag = file[itemOffset + 40];
            item.call_liftspeed = BitConverter.ToSingle(file, itemOffset + 41);
            item.mapjump_startPOS = file[itemOffset + 45];
            item.missMSG_ID = BitConverter.ToUInt16(file, itemOffset + 46);
            item.elevator_nextwait = BitConverter.ToInt16(file, itemOffset + 48);
            item.liftAMapJumpId = BitConverter.ToUInt16(file, itemOffset + 50);
            item.liftBMapJumpId = BitConverter.ToUInt16(file, itemOffset + 52);
            item.shutterfade = (item.flag & 1) != 0;
            item.lift_reverse = (item.flag & 2) != 0;
            return item;
        }

        public static FLD_ENActMove ReadFLD_ENActMove(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_ENActMove();
            item.Id = itemId;
            item.actIDL_Per = file[itemOffset];
            item.actMove_Per = file[itemOffset + 1];
            item.IDL_Per = file[itemOffset + 2];
            item.IDL_Time = file[itemOffset + 3];
            item.UIDL1_Per = file[itemOffset + 4];
            item.UIDL2_Per = file[itemOffset + 5];
            item.ExIDL1_Per = file[itemOffset + 6];
            item.ExIDL1_Time = file[itemOffset + 7];
            item.ExIDL2_Per = file[itemOffset + 8];
            item.ExIDL2_Time = file[itemOffset + 9];
            item.actIDL_Atr = file[itemOffset + 10];
            item.walk_Per = file[itemOffset + 11];
            item.run_Per = file[itemOffset + 12];
            item.Dir_Per = file[itemOffset + 13];
            item.Dir_Line = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Dir_Curve = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Dis_Min = file[itemOffset + 18];
            item.Dis_Max = file[itemOffset + 19];
            item.fldEne_Param = file[itemOffset + 20];
            item.actMove_Atr = file[itemOffset + 21];
            return item;
        }

        public static FLD_EnemyGroup ReadFLD_EnemyGroup(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_EnemyGroup();
            item.Id = itemId;
            item.EnemyID1 = BitConverter.ToUInt16(file, itemOffset);
            item.EnemyID2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.EnemyID3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.EnemyID4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EnemyID5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.EnemyID6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.EnemyID7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.EnemyID8 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.EnemyID9 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.EnemyID10 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.EnemyID11 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.EnemyID12 = BitConverter.ToUInt16(file, itemOffset + 22);
            return item;
        }

        public static FLD_EnemyWave ReadFLD_EnemyWave(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_EnemyWave();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlagMin = file[itemOffset + 6];
            item.QuestFlagMax = file[itemOffset + 7];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 14);
            item.popWeather = file[itemOffset + 18];
            item.instanceMax = file[itemOffset + 19];
            item.onlyOnce = file[itemOffset + 20];
            item.gimmick = BitConverter.ToUInt16(file, itemOffset + 21);
            item.waitTime = BitConverter.ToUInt16(file, itemOffset + 23);
            return item;
        }

        public static FLD_EnemyWaveIra ReadFLD_EnemyWaveIra(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_EnemyWaveIra();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlagMin = file[itemOffset + 6];
            item.QuestFlagMax = file[itemOffset + 7];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 14);
            item.popWeather = file[itemOffset + 18];
            item.instanceMax = file[itemOffset + 19];
            item.onlyOnce = file[itemOffset + 20];
            item.gimmick = BitConverter.ToUInt16(file, itemOffset + 21);
            item.waitTime = BitConverter.ToUInt16(file, itemOffset + 23);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 25);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.tgtMSG_ID = BitConverter.ToUInt16(file, itemOffset + 29);
            item.actionwindowID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.sealedStonePopID = BitConverter.ToUInt16(file, itemOffset + 33);
            return item;
        }

        public static FLD_FieldLockGimmick ReadFLD_FieldLockGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_FieldLockGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlagMin = file[itemOffset + 10];
            item.QuestFlagMax = file[itemOffset + 11];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.rockTYPE = file[itemOffset + 14];
            item.txtID = BitConverter.ToUInt16(file, itemOffset + 15);
            item.map_collisionID = BitConverter.ToUInt16(file, itemOffset + 17);
            return item;
        }

        public static FLD_FieldSkillList ReadFLD_FieldSkillList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_FieldSkillList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Type = file[itemOffset + 4];
            item.RandomID = BitConverter.ToUInt16(file, itemOffset + 5);
            item.MinLevel = file[itemOffset + 7];
            item.MaxLevel = file[itemOffset + 8];
            item.Category = file[itemOffset + 9];
            item.Rarity = file[itemOffset + 10];
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 11);
            item.VoiceCategory = BitConverter.ToUInt16(file, itemOffset + 13);
            item.Attirbute = file[itemOffset + 15];
            return item;
        }

        public static FLD_FieldSkillRandom ReadFLD_FieldSkillRandom(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_FieldSkillRandom();
            item.Id = itemId;
            item.Level1Chance = file[itemOffset];
            item.Level2Chance = file[itemOffset + 1];
            item.Level3Chance = file[itemOffset + 2];
            return item;
        }

        public static FLD_FieldSkillSetting ReadFLD_FieldSkillSetting(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_FieldSkillSetting();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.FieldSkillID1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.FieldSkillLevel1 = file[itemOffset + 4];
            item.FieldSkillID2 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.FieldSkillLevel2 = file[itemOffset + 7];
            item.SuccessVoiceCategory = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MissVoiceCategory = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static FLD_FootPrintsRoutes ReadFLD_FootPrintsRoutes(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_FootPrintsRoutes();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.FootEffect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 12);
            item.QuestFlagMin = file[itemOffset + 14];
            item.QuestFlagMax = file[itemOffset + 15];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 16);
            return item;
        }

        public static FLD_GravePopList ReadFLD_GravePopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_GravePopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.en_popID = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_IdeaTable ReadFLD_IdeaTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_IdeaTable();
            item.Id = itemId;
            item.TrustPoint = BitConverter.ToUInt32(file, itemOffset);
            item.WpnRatio = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NArtsProbRev = file[itemOffset + 6];
            item.BladeChangeRev = BitConverter.ToInt16(file, itemOffset + 7);
            item.BladeArtsRev = BitConverter.ToInt16(file, itemOffset + 9);
            item.FormSwichF = BitConverter.ToUInt16(file, itemOffset + 11);
            return item;
        }

        public static FLD_InnEvent ReadFLD_InnEvent(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_InnEvent();
            item.Id = itemId;
            item.Condition = BitConverter.ToUInt16(file, itemOffset);
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.KizunaTalkID = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_JumpGimmick ReadFLD_JumpGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_JumpGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.jumpType = file[itemOffset + 8];
            item.tgtMSG_ID = BitConverter.ToUInt16(file, itemOffset + 9);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 11);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.jump_nextwait = BitConverter.ToInt16(file, itemOffset + 15);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 17);
            return item;
        }

        public static FLD_KizunaTalk ReadFLD_KizunaTalk(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_KizunaTalk();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ConditionID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Title = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.EVCondition = BitConverter.ToUInt16(file, itemOffset + 10);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 12);
            return item;
        }

        public static FLD_LODList ReadFLD_LODList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_LODList();
            item.Id = itemId;
            item.LODID = BitConverter.ToUInt16(file, itemOffset);
            item.flag = BitConverter.ToUInt32(file, itemOffset + 2);
            item.ScenarioFlagMin1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMax1 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlag1 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlagMin1 = file[itemOffset + 12];
            item.QuestFlagMax1 = file[itemOffset + 13];
            item.Condition1 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ScenarioFlagMin2 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ScenarioFlagMax2 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.QuestFlag2 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.QuestFlagMin2 = file[itemOffset + 22];
            item.QuestFlagMax2 = file[itemOffset + 23];
            item.Condition2 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.ScenarioFlagMin3 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.ScenarioFlagMax3 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.QuestFlag3 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.QuestFlagMin3 = file[itemOffset + 32];
            item.QuestFlagMax3 = file[itemOffset + 33];
            item.Condition3 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.effect_anime_normal = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.effect_anime_reverse = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.effect_visibleON = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.effect_visibleOFF = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.effect_fadeOUT = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.LOD_fadeIN_TIME = BitConverter.ToSingle(file, itemOffset + 56);
            item.LOD_fadeOUT_TIME = BitConverter.ToSingle(file, itemOffset + 60);
            item.effect_skipframe = BitConverter.ToUInt16(file, itemOffset + 64);
            item.effect_pop_dist = BitConverter.ToSingle(file, itemOffset + 66);
            item.Visible = (item.flag & 1) != 0;
            item.AnimReverse = (item.flag & 2) != 0;
            item.VisibleChange1 = (item.flag & 4) != 0;
            item.AnimReverseChange1 = (item.flag & 8) != 0;
            item.AnimReverseSkip1 = (item.flag & 16) != 0;
            item.AnimPause1 = (item.flag & 32) != 0;
            item.VisibleChange2 = (item.flag & 64) != 0;
            item.AnimReverseChange2 = (item.flag & 128) != 0;
            item.AnimReverseSkip2 = (item.flag & 256) != 0;
            item.AnimPause2 = (item.flag & 512) != 0;
            item.VisibleChange3 = (item.flag & 1024) != 0;
            item.AnimReverseChange3 = (item.flag & 2048) != 0;
            item.AnimReverseSkip3 = (item.flag & 4096) != 0;
            item.AnimPause3 = (item.flag & 8192) != 0;
            item.LOD_fadeIN_collision = (item.flag & 16384) != 0;
            item.LOD_fadeOUT_collision = (item.flag & 32768) != 0;
            item.LOD_bind_type = (item.flag & 65536) != 0;
            return item;
        }

        public static FLD_LookSetBl ReadFLD_LookSetBl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_LookSetBl();
            item.Id = itemId;
            item.RefID = BitConverter.ToUInt16(file, itemOffset);
            item.LookType = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Chara = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_LookSetEn ReadFLD_LookSetEn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_LookSetEn();
            item.Id = itemId;
            item.RefID = BitConverter.ToUInt16(file, itemOffset);
            item.Chara = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static FLD_LookType000 ReadFLD_LookType000(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_LookType000();
            item.Id = itemId;
            item.Chara = BitConverter.ToUInt16(file, itemOffset);
            item.Radius = BitConverter.ToSingle(file, itemOffset + 2);
            item.UpperHeight = BitConverter.ToSingle(file, itemOffset + 6);
            item.LowerHeight = BitConverter.ToSingle(file, itemOffset + 10);
            item.LookTime = BitConverter.ToSingle(file, itemOffset + 14);
            item.Interval = BitConverter.ToSingle(file, itemOffset + 18);
            item.Priority = (sbyte)file[itemOffset + 22];
            return item;
        }

        public static FLD_MapGimmick ReadFLD_MapGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_MapGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.popTime = BitConverter.ToUInt32(file, itemOffset + 4);
            item.popWeather = file[itemOffset + 8];
            item.gimmickType = file[itemOffset + 9];
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.response_CHR = file[itemOffset + 14];
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 15);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 17);
            item.tgtMSG_ID = BitConverter.ToUInt16(file, itemOffset + 19);
            item.actionwindowID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.missMSG_ID = BitConverter.ToUInt16(file, itemOffset + 23);
            item.G1_LOD_switchtype = file[itemOffset + 25];
            item.G2_LOD_switchtype = file[itemOffset + 26];
            item.G3_LOD_switchtype = file[itemOffset + 27];
            item.G4_LOD_switchtype = file[itemOffset + 28];
            item.G5_LOD_switchtype = file[itemOffset + 29];
            item.OP_ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 30);
            item.OP_ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 32);
            item.OP_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 34);
            item.OP_QuestFlagMin = file[itemOffset + 36];
            item.OP_QuestFlagMax = file[itemOffset + 37];
            item.OP_Condition = BitConverter.ToUInt16(file, itemOffset + 38);
            item.OP_Time = BitConverter.ToUInt16(file, itemOffset + 40);
            item.OP_Weather = file[itemOffset + 42];
            item.OP_gimmickType = file[itemOffset + 43];
            item.OP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 44);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 46);
            item.G1_LODmodel = BitConverter.ToUInt16(file, itemOffset + 48);
            item.G1_LODanime_play = file[itemOffset + 50];
            item.G1_LOD_SE = BitConverter.ToUInt16(file, itemOffset + 51);
            item.G1_LOD_size = file[itemOffset + 53];
            item.nextwait1 = BitConverter.ToInt16(file, itemOffset + 54);
            item.G2_LODmodel = BitConverter.ToUInt16(file, itemOffset + 56);
            item.G2_LODanime_play = file[itemOffset + 58];
            item.G2_LOD_SE = BitConverter.ToUInt16(file, itemOffset + 59);
            item.G2_LOD_size = file[itemOffset + 61];
            item.nextwait2 = BitConverter.ToInt16(file, itemOffset + 62);
            item.G3_LODmodel = BitConverter.ToUInt16(file, itemOffset + 64);
            item.G3_LODanime_play = file[itemOffset + 66];
            item.G3_LOD_SE = BitConverter.ToUInt16(file, itemOffset + 67);
            item.G3_LOD_size = file[itemOffset + 69];
            item.nextwait3 = BitConverter.ToInt16(file, itemOffset + 70);
            item.G4_LODmodel = BitConverter.ToUInt16(file, itemOffset + 72);
            item.G4_LODanime_play = file[itemOffset + 74];
            item.G4_LOD_SE = BitConverter.ToUInt16(file, itemOffset + 75);
            item.G4_LOD_size = file[itemOffset + 77];
            item.nextwait4 = BitConverter.ToInt16(file, itemOffset + 78);
            item.G5_LODmodel = BitConverter.ToUInt16(file, itemOffset + 80);
            item.G5_LODanime_play = file[itemOffset + 82];
            item.G5_LOD_SE = BitConverter.ToUInt16(file, itemOffset + 83);
            item.G5_LOD_size = file[itemOffset + 85];
            item.nextwait5 = BitConverter.ToInt16(file, itemOffset + 86);
            item.mapobjID = BitConverter.ToUInt16(file, itemOffset + 88);
            item.mapobjeffect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 90));
            item.mapobjSE = BitConverter.ToUInt16(file, itemOffset + 94);
            item.mapobj_fadeOUT_TIME = BitConverter.ToSingle(file, itemOffset + 96);
            item.flag = BitConverter.ToUInt16(file, itemOffset + 100);
            item.mapobj_nextwait = BitConverter.ToUInt16(file, itemOffset + 102);
            item.gmkCamName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 104));
            item.camGim_ATR = file[itemOffset + 108];
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 109);
            item.effectID = BitConverter.ToUInt16(file, itemOffset + 111);
            item.MSG_ray = (item.flag & 1) != 0;
            item.mapobj_fadeOUT_collision = (item.flag & 2) != 0;
            item.gmkCamPos = (item.flag & 4) != 0;
            item.nowaitGmkCam = (item.flag & 8) != 0;
            item.G1_LOD_SE_type = (item.flag & 16) != 0;
            item.G2_LOD_SE_type = (item.flag & 32) != 0;
            item.G3_LOD_SE_type = (item.flag & 64) != 0;
            item.G4_LOD_SE_type = (item.flag & 128) != 0;
            item.G5_LOD_SE_type = (item.flag & 256) != 0;
            return item;
        }

        public static FLD_MapJump ReadFLD_MapJump(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_MapJump();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MapJumpId = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlagMin = file[itemOffset + 12];
            item.QuestFlagMax = file[itemOffset + 13];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static FLD_maplist ReadFLD_maplist(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_maplist();
            item.Id = itemId;
            item.resource = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.select = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.rscGmkId = BitConverter.ToUInt32(file, itemOffset + 8);
            item.ene_disp_r = file[itemOffset + 12];
            item.ene_disp_h = file[itemOffset + 13];
            item.ene_release_r = file[itemOffset + 14];
            item.ene_release_h = file[itemOffset + 15];
            item.wa_type = file[itemOffset + 16];
            item.wa_pop_rate = file[itemOffset + 17];
            item.wa_time_BNS = BitConverter.ToUInt16(file, itemOffset + 18);
            item.wa_end_time = file[itemOffset + 20];
            item.wb_type = file[itemOffset + 21];
            item.wb_pop_rate = file[itemOffset + 22];
            item.wb_time_BNS = BitConverter.ToUInt16(file, itemOffset + 23);
            item.wb_end_time = file[itemOffset + 25];
            item.wc_type = file[itemOffset + 26];
            item.wc_pop_rate = file[itemOffset + 27];
            item.wc_time_BNS = BitConverter.ToUInt16(file, itemOffset + 28);
            item.wc_end_time = file[itemOffset + 30];
            item.wd_type = file[itemOffset + 31];
            item.wd_pop_rate = file[itemOffset + 32];
            item.wd_time_BNS = BitConverter.ToUInt16(file, itemOffset + 33);
            item.wd_end_time = file[itemOffset + 35];
            item.wind_mor = file[itemOffset + 36];
            item.wind_non = file[itemOffset + 37];
            item.wind_eve = file[itemOffset + 38];
            item.wind_nit = file[itemOffset + 39];
            item.wind_mnit = file[itemOffset + 40];
            item.wind_emor = file[itemOffset + 41];
            item.wind_WA = file[itemOffset + 42];
            item.wind_WB = file[itemOffset + 43];
            item.wind_WC = file[itemOffset + 44];
            item.wind_WD = file[itemOffset + 45];
            item.weatherATR = file[itemOffset + 46];
            item.e_repoptime = file[itemOffset + 47];
            item.m_repoptime = file[itemOffset + 48];
            item.mapATR = file[itemOffset + 49];
            item.wa_ON_cndID = BitConverter.ToUInt16(file, itemOffset + 50);
            item.wa_OFF_cndID = BitConverter.ToUInt16(file, itemOffset + 52);
            item.wb_ON_cndID = BitConverter.ToUInt16(file, itemOffset + 54);
            item.wb_OFF_cndID = BitConverter.ToUInt16(file, itemOffset + 56);
            item.wc_ON_cndID = BitConverter.ToUInt16(file, itemOffset + 58);
            item.wc_OFF_cndID = BitConverter.ToUInt16(file, itemOffset + 60);
            item.wd_ON_cndID = BitConverter.ToUInt16(file, itemOffset + 62);
            item.wd_OFF_cndID = BitConverter.ToUInt16(file, itemOffset + 64);
            item.stopTIME_cndID = BitConverter.ToUInt16(file, itemOffset + 66);
            item.ebb_ON_cndID = BitConverter.ToUInt16(file, itemOffset + 68);
            item.ebb_inn_cndID = BitConverter.ToUInt16(file, itemOffset + 70);
            item.ebb_pop_rate = file[itemOffset + 72];
            item.st_allOFF_cndID = BitConverter.ToUInt16(file, itemOffset + 73);
            item.st_OFF_cndID = BitConverter.ToUInt16(file, itemOffset + 75);
            item.bgm_cndID = BitConverter.ToUInt16(file, itemOffset + 77);
            item.name_cndID = BitConverter.ToUInt16(file, itemOffset + 79);
            item.nameID = BitConverter.ToUInt16(file, itemOffset + 81);
            item.change_nameID = BitConverter.ToUInt16(file, itemOffset + 83);
            item.mapON_cndID = BitConverter.ToUInt16(file, itemOffset + 85);
            item.textID = BitConverter.ToUInt16(file, itemOffset + 87);
            item.e_balloondisp_r = file[itemOffset + 89];
            item.zone = file[itemOffset + 90];
            return item;
        }

        public static FLD_MercenariesMission ReadFLD_MercenariesMission(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_MercenariesMission();
            item.Id = itemId;
            item.QuestID = BitConverter.ToUInt16(file, itemOffset);
            item.Category = file[itemOffset + 2];
            item.RequestPerformance = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Repeatable = file[itemOffset + 5];
            item.AutoStart = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_MobGroupList ReadFLD_MobGroupList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_MobGroupList();
            item.Id = itemId;
            item.MOBID1 = BitConverter.ToUInt16(file, itemOffset);
            item.MOBID2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.MOBID3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.MOBID4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.MOBID5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MOBID6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.MOBID7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.MOBID8 = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static FLD_NpcGroupId ReadFLD_NpcGroupId(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_NpcGroupId();
            item.Id = itemId;
            item.memberNum = file[itemOffset];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 1);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 3);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 5);
            item.QuestFlagMin = file[itemOffset + 7];
            item.QuestFlagMax = file[itemOffset + 8];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 11);
            return item;
        }

        public static FLD_NpcMobMotionId ReadFLD_NpcMobMotionId(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_NpcMobMotionId();
            item.Id = itemId;
            item.cmdName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.flag = file[itemOffset + 4];
            item.notEyeBlink = (item.flag & 1) != 0;
            return item;
        }

        public static FLD_OwnerBonus ReadFLD_OwnerBonus(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_OwnerBonus();
            item.Id = itemId;
            item.Caption = BitConverter.ToUInt16(file, itemOffset);
            item.Type = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Value = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_QuestBattle ReadFLD_QuestBattle(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestBattle();
            item.Id = itemId;
            item.Refer = file[itemOffset];
            item.EnemyID = BitConverter.ToUInt16(file, itemOffset + 1);
            item.EnemyGroupID = BitConverter.ToUInt16(file, itemOffset + 3);
            item.EnemySpeciesID = BitConverter.ToUInt16(file, itemOffset + 5);
            item.EnemyRaceID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.Count = file[itemOffset + 9];
            item.CountFlag = BitConverter.ToUInt16(file, itemOffset + 10);
            item.DeadAll = file[itemOffset + 12];
            item.TimeCount = BitConverter.ToUInt16(file, itemOffset + 13);
            item.TimeCountFlag = file[itemOffset + 15];
            item.ReduceEnemyHP = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ReducePCHP = BitConverter.ToUInt16(file, itemOffset + 18);
            return item;
        }

        public static FLD_QuestCollect ReadFLD_QuestCollect(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestCollect();
            item.Id = itemId;
            item.Refer = file[itemOffset];
            item.ItemID = BitConverter.ToUInt16(file, itemOffset + 1);
            item.Category = file[itemOffset + 3];
            item.Count = file[itemOffset + 4];
            item.Deduct = file[itemOffset + 5];
            item.TresureID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EnemyID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MapID = BitConverter.ToUInt16(file, itemOffset + 10);
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.CollectionID = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static FLD_QuestCondition ReadFLD_QuestCondition(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestCondition();
            item.Id = itemId;
            item.ConditionID = BitConverter.ToUInt16(file, itemOffset);
            item.MapID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_QuestEvent ReadFLD_QuestEvent(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestEvent();
            item.Id = itemId;
            item.EventID = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static FLD_QuestFieldSkillCount ReadFLD_QuestFieldSkillCount(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestFieldSkillCount();
            item.Id = itemId;
            item.FieldSkillID = file[itemOffset];
            item.Count = BitConverter.ToUInt16(file, itemOffset + 1);
            return item;
        }

        public static FLD_QuestGimmick ReadFLD_QuestGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestGimmick();
            item.Id = itemId;
            item.MapID = BitConverter.ToUInt16(file, itemOffset);
            item.DoorGimmickID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ElevatorGimmickID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.JumpGimmickID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.MapGimmickID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.MapGmkIconOff = file[itemOffset + 10];
            item.WarpGimmickID = BitConverter.ToUInt16(file, itemOffset + 11);
            item.SalvagePointID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.TboxPopID = BitConverter.ToUInt16(file, itemOffset + 15);
            item.EnemyWaveID = BitConverter.ToUInt16(file, itemOffset + 17);
            item.CampPopID = BitConverter.ToUInt16(file, itemOffset + 19);
            item.CollectionPopID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.CollectionPopID_0 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.EndCheck = file[itemOffset + 25];
            return item;
        }

        public static FLD_QuestHints ReadFLD_QuestHints(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestHints();
            item.Id = itemId;
            item.MainChar1 = BitConverter.ToUInt16(file, itemOffset);
            item.MainChar2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.MainChar3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.MainChar4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.FSkillID1 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.FSkillID2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.FSkillID3 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.ClientNpc = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ZoneID = BitConverter.ToUInt16(file, itemOffset + 16);
            return item;
        }

        public static FLD_QuestList ReadFLD_QuestList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestList();
            item.Id = itemId;
            item.QuestTitle = BitConverter.ToUInt16(file, itemOffset);
            item.QuestCategory = file[itemOffset + 2];
            item.Visible = file[itemOffset + 3];
            item.Talker = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Summary = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ResultA = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ResultB = BitConverter.ToUInt16(file, itemOffset + 10);
            item.SortNo = BitConverter.ToUInt16(file, itemOffset + 12);
            item.RewardDisp = file[itemOffset + 14];
            item.RewardSetA = BitConverter.ToUInt16(file, itemOffset + 15);
            item.RewardSetB = BitConverter.ToUInt16(file, itemOffset + 17);
            item.PRTQuestID = BitConverter.ToUInt16(file, itemOffset + 19);
            item.FlagPRT = BitConverter.ToUInt16(file, itemOffset + 21);
            item.FlagCLD = BitConverter.ToUInt16(file, itemOffset + 23);
            item.PurposeID = BitConverter.ToUInt16(file, itemOffset + 25);
            item.CountCancel = file[itemOffset + 27];
            item.NextQuestA = BitConverter.ToUInt16(file, itemOffset + 28);
            item.CallEventA = BitConverter.ToUInt16(file, itemOffset + 30);
            item.NextQuestB = BitConverter.ToUInt16(file, itemOffset + 32);
            item.CallEventB = BitConverter.ToUInt16(file, itemOffset + 34);
            item.HintsID = BitConverter.ToUInt16(file, itemOffset + 36);
            item.ClearVoice = BitConverter.ToUInt16(file, itemOffset + 38);
            item.AutoStart = file[itemOffset + 40];
            item.ItemLost = BitConverter.ToUInt16(file, itemOffset + 41);
            item.CancelCondition = BitConverter.ToUInt16(file, itemOffset + 43);
            item.QuestIcon = BitConverter.ToUInt16(file, itemOffset + 45);
            item.LinkedQuestID = BitConverter.ToUInt16(file, itemOffset + 47);
            return item;
        }

        public static FLD_QuestReach ReadFLD_QuestReach(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestReach();
            item.Id = itemId;
            item.Category = file[itemOffset];
            item.MapID = BitConverter.ToUInt16(file, itemOffset + 1);
            item.PlaceID = BitConverter.ToUInt16(file, itemOffset + 3);
            return item;
        }

        public static FLD_QuestReward ReadFLD_QuestReward(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestReward();
            item.Id = itemId;
            item.Gold = BitConverter.ToUInt32(file, itemOffset);
            item.EXP = BitConverter.ToUInt32(file, itemOffset + 4);
            item.Sp = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Coin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.DevelopZone = file[itemOffset + 12];
            item.DevelopPoint = BitConverter.ToUInt16(file, itemOffset + 13);
            item.TrustPoint = BitConverter.ToUInt16(file, itemOffset + 15);
            item.MercenariesPoint = BitConverter.ToUInt16(file, itemOffset + 17);
            item.IdeaCategory = file[itemOffset + 19];
            item.IdeaValue = BitConverter.ToUInt16(file, itemOffset + 20);
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.ItemNumber1 = file[itemOffset + 24];
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.ItemNumber2 = file[itemOffset + 27];
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.ItemNumber3 = file[itemOffset + 30];
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 31);
            item.ItemNumber4 = file[itemOffset + 33];
            return item;
        }

        public static FLD_QuestRewardRandom ReadFLD_QuestRewardRandom(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestRewardRandom();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.ItemCategory1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ItemIDPercent1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ItemCategory2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ItemIDPercent2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.ItemCategory3 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ItemIDPercent3 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.ItemCategory4 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.ItemIDPercent4 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.ItemCategory5 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.ItemID5 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.ItemIDPercent5 = BitConverter.ToUInt16(file, itemOffset + 30);
            return item;
        }

        public static FLD_QuestTalk ReadFLD_QuestTalk(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestTalk();
            item.Id = itemId;
            item.MapID = BitConverter.ToUInt16(file, itemOffset);
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DummyGroup = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static FLD_QuestTalkDummyGroup ReadFLD_QuestTalkDummyGroup(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestTalkDummyGroup();
            item.Id = itemId;
            item.NpcID1 = BitConverter.ToUInt16(file, itemOffset);
            item.NpcID2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.NpcID3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NpcID4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.NpcID5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.NpcID6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.NpcID7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.NpcID8 = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static FLD_QuestTask ReadFLD_QuestTask(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestTask();
            item.Id = itemId;
            item.PreCondition = file[itemOffset];
            item.TaskType1 = file[itemOffset + 1];
            item.TaskID1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Branch1 = file[itemOffset + 4];
            item.TaskLog1 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.TaskUI1 = file[itemOffset + 7];
            item.TaskCondition1 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.TaskType2 = file[itemOffset + 10];
            item.TaskID2 = BitConverter.ToUInt16(file, itemOffset + 11);
            item.Branch2 = file[itemOffset + 13];
            item.TaskLog2 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.TaskUI2 = file[itemOffset + 16];
            item.TaskCondition2 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.TaskType3 = file[itemOffset + 19];
            item.TaskID3 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Branch3 = file[itemOffset + 22];
            item.TaskLog3 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.TaskUI3 = file[itemOffset + 25];
            item.TaskCondition3 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.TaskType4 = file[itemOffset + 28];
            item.TaskID4 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.Branch4 = file[itemOffset + 31];
            item.TaskLog4 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.TaskUI4 = file[itemOffset + 34];
            item.TaskCondition4 = BitConverter.ToUInt16(file, itemOffset + 35);
            return item;
        }

        public static FLD_QuestUse ReadFLD_QuestUse(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_QuestUse();
            item.Id = itemId;
            item.ItemID = BitConverter.ToUInt16(file, itemOffset);
            item.Category = file[itemOffset + 2];
            item.ItemNumber = file[itemOffset + 3];
            item.PartyInPC = BitConverter.ToUInt16(file, itemOffset + 4);
            item.bladeID = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static FLD_randomTalk ReadFLD_randomTalk(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_randomTalk();
            item.Id = itemId;
            item.type = (sbyte)file[itemOffset];
            item.talk0 = BitConverter.ToInt16(file, itemOffset + 1);
            item.text0 = BitConverter.ToInt16(file, itemOffset + 3);
            item.target0 = (sbyte)file[itemOffset + 5];
            item.talk1 = BitConverter.ToInt16(file, itemOffset + 6);
            item.text1 = BitConverter.ToInt16(file, itemOffset + 8);
            item.target1 = (sbyte)file[itemOffset + 10];
            return item;
        }

        public static FLD_RequestBlade ReadFLD_RequestBlade(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_RequestBlade();
            item.Id = itemId;
            item.RequestCategory = file[itemOffset];
            item.RequestAtr = file[itemOffset + 1];
            item.RequestPerformance = BitConverter.ToUInt16(file, itemOffset + 2);
            item.RequestRace = BitConverter.ToUInt16(file, itemOffset + 4);
            item.RequestGender = BitConverter.ToUInt16(file, itemOffset + 6);
            item.RequestArts = BitConverter.ToUInt16(file, itemOffset + 8);
            item.RequestArtsLevel = file[itemOffset + 10];
            item.RequestFSkill = BitConverter.ToUInt16(file, itemOffset + 11);
            item.RequestFSLevel = file[itemOffset + 13];
            item.RequestNumber = file[itemOffset + 14];
            return item;
        }

        public static FLD_RequestItemSet ReadFLD_RequestItemSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_RequestItemSet();
            item.Id = itemId;
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset);
            item.Count1 = file[itemOffset + 2];
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Count2 = file[itemOffset + 5];
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Count3 = file[itemOffset + 8];
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Count4 = file[itemOffset + 11];
            item.ItemID5 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Count5 = file[itemOffset + 14];
            item.Count5_0 = file[itemOffset + 15];
            item.MapID = BitConverter.ToUInt16(file, itemOffset + 16);
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 18);
            return item;
        }

        public static FLD_SalvageClimbLotTable ReadFLD_SalvageClimbLotTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvageClimbLotTable();
            item.Id = itemId;
            item.NoTBox = file[itemOffset];
            item.TBox = file[itemOffset + 1];
            item.RTBox = file[itemOffset + 2];
            item.SRTBox = file[itemOffset + 3];
            item.Enemy = file[itemOffset + 4];
            item.REnemy = file[itemOffset + 5];
            item.Voice1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.Voice2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.Voice3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 14));
            item.Voice4 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            return item;
        }

        public static FLD_SalvageEnemySet ReadFLD_SalvageEnemySet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvageEnemySet();
            item.Id = itemId;
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset);
            item.ene1Lv = (sbyte)file[itemOffset + 2];
            item.ene1Per = file[itemOffset + 3];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ene2Lv = (sbyte)file[itemOffset + 6];
            item.ene2Per = file[itemOffset + 7];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ene3Lv = (sbyte)file[itemOffset + 10];
            item.ene3Per = file[itemOffset + 11];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 12);
            item.ene4Lv = (sbyte)file[itemOffset + 14];
            item.ene4Per = file[itemOffset + 15];
            item.pop_act_type = file[itemOffset + 16];
            return item;
        }

        public static FLD_SalvageEvent ReadFLD_SalvageEvent(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvageEvent();
            item.Id = itemId;
            item.EventID1 = BitConverter.ToUInt16(file, itemOffset);
            item.Percent1 = file[itemOffset + 2];
            item.EventID2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.Percent2 = file[itemOffset + 5];
            item.EventID3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Percent3 = file[itemOffset + 8];
            item.EventID4 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Percent4 = file[itemOffset + 11];
            item.EventID5 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Percent5 = file[itemOffset + 14];
            item.EventID6 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.Percent6 = file[itemOffset + 17];
            return item;
        }

        public static FLD_SalvageItemSet ReadFLD_SalvageItemSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvageItemSet();
            item.Id = itemId;
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset);
            item.flag = file[itemOffset + 2];
            item.msgVisible = file[itemOffset + 3];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 4);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 8);
            item.goldPopMin = file[itemOffset + 12];
            item.goldPopMax = file[itemOffset + 13];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 14);
            item.itm1Num = file[itemOffset + 16];
            item.itm1Per = file[itemOffset + 17];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.itm2Num = file[itemOffset + 20];
            item.itm2Per = file[itemOffset + 21];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 22);
            item.itm3Num = file[itemOffset + 24];
            item.itm3Per = file[itemOffset + 25];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 26);
            item.itm4Num = file[itemOffset + 28];
            item.itm4Per = file[itemOffset + 29];
            item.itm5ID = BitConverter.ToUInt16(file, itemOffset + 30);
            item.itm5Num = file[itemOffset + 32];
            item.itm5Per = file[itemOffset + 33];
            item.itm6ID = BitConverter.ToUInt16(file, itemOffset + 34);
            item.itm6Num = file[itemOffset + 36];
            item.itm6Per = file[itemOffset + 37];
            item.itm7ID = BitConverter.ToUInt16(file, itemOffset + 38);
            item.itm7Num = file[itemOffset + 40];
            item.itm7Per = file[itemOffset + 41];
            item.itm8ID = BitConverter.ToUInt16(file, itemOffset + 42);
            item.itm8Num = file[itemOffset + 44];
            item.itm8Per = file[itemOffset + 45];
            item.randitmPopMin = file[itemOffset + 46];
            item.randitmPopMax = file[itemOffset + 47];
            item.rsc_paramID = file[itemOffset + 48];
            item.accessAngle = (item.flag & 1) != 0;
            return item;
        }

        public static FLD_SalvagePointList ReadFLD_SalvagePointList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvagePointList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.SalvagePointName = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.BtnChallenge0 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.BtnChallenge1 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.BtnChallenge2 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.StartEventID = BitConverter.ToUInt16(file, itemOffset + 14);
            item.SpecialItem = BitConverter.ToUInt16(file, itemOffset + 16);
            item.SpecialEventID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.SalvageTable1 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.SalvageTable2 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.SalvageTable3 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.SalvageTable4 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.SalvageTable5 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 30);
            return item;
        }

        public static FLD_SalvageTable ReadFLD_SalvageTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SalvageTable();
            item.Id = itemId;
            item.ColleTable1 = BitConverter.ToUInt16(file, itemOffset);
            item.ColleTablePercent1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ColleTable2 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ColleTablePercent2 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ColleTable3 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ColleTablePercent3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.TresureBoxHit = BitConverter.ToUInt16(file, itemOffset + 12);
            item.TresureTable1 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.TresureTablePercent1 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.TresureTable2 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.TresureTablePercent2 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.TresureTable3 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.TresureTablePercent3 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.EnemyLotteries = file[itemOffset + 26];
            item.EnemyPopHit = BitConverter.ToUInt16(file, itemOffset + 27);
            item.EnemyPopTable1 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.EnemyPopTablePercent1 = BitConverter.ToUInt16(file, itemOffset + 31);
            item.EnemyPopTable2 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.EnemyPopTablePercent2 = BitConverter.ToUInt16(file, itemOffset + 35);
            item.EnemyPopTable3 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.EnemyPopTablePercent3 = BitConverter.ToUInt16(file, itemOffset + 39);
            return item;
        }

        public static FLD_SealedStone ReadFLD_SealedStone(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SealedStone();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.FeedbackEffectName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.FinishEffectName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.FinishWaitTime = BitConverter.ToSingle(file, itemOffset + 14);
            item.StateName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 24);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 26);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 28);
            item.Priority = file[itemOffset + 30];
            item.EffectScale = BitConverter.ToSingle(file, itemOffset + 31);
            item.EffectOffsetX = BitConverter.ToSingle(file, itemOffset + 35);
            item.EffectOffsetY = BitConverter.ToSingle(file, itemOffset + 39);
            item.EffectOffsetZ = BitConverter.ToSingle(file, itemOffset + 43);
            return item;
        }

        public static FLD_SePop ReadFLD_SePop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_SePop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.flag = file[itemOffset + 4];
            item.seName = BitConverter.ToUInt16(file, itemOffset + 5);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 9);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 11);
            item.QuestFlagMin = file[itemOffset + 13];
            item.QuestFlagMax = file[itemOffset + 14];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 15);
            item.SEpopTime = BitConverter.ToUInt16(file, itemOffset + 17);
            item.wtrSEType = file[itemOffset + 19];
            item.gimmickType = file[itemOffset + 20];
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.OP_gimmickType = file[itemOffset + 23];
            item.OP_gimmickID = BitConverter.ToUInt16(file, itemOffset + 24);
            item.volumeMAX = file[itemOffset + 26];
            item.volumeMIN = file[itemOffset + 27];
            item.InRoom_volume = file[itemOffset + 28];
            item.se_type = (item.flag & 1) != 0;
            item.play_once = (item.flag & 2) != 0;
            return item;
        }

        public static FLD_TimeInfo ReadFLD_TimeInfo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_TimeInfo();
            item.Id = itemId;
            item.msg = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static FLD_Tutorial ReadFLD_Tutorial(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_Tutorial();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.SysMultiFlag = file[itemOffset + 10];
            return item;
        }

        public static FLD_UniquePreset ReadFLD_UniquePreset(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_UniquePreset();
            item.Id = itemId;
            item.Frequency = BitConverter.ToUInt16(file, itemOffset);
            item.Chara0 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Motion0 = file[itemOffset + 4];
            item.Delay0 = BitConverter.ToSingle(file, itemOffset + 5);
            item.Chara1 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Motion1 = file[itemOffset + 11];
            item.Delay1 = BitConverter.ToSingle(file, itemOffset + 12);
            item.Chara2 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Motion2 = file[itemOffset + 18];
            item.Delay2 = BitConverter.ToSingle(file, itemOffset + 19);
            item.Chara3 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Motion3 = file[itemOffset + 25];
            item.Delay3 = BitConverter.ToSingle(file, itemOffset + 26);
            item.Chara4 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.Motion4 = file[itemOffset + 32];
            item.Delay4 = BitConverter.ToSingle(file, itemOffset + 33);
            item.Chara5 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.Motion5 = file[itemOffset + 39];
            item.Delay5 = BitConverter.ToSingle(file, itemOffset + 40);
            return item;
        }

        public static FLD_UniqueTable ReadFLD_UniqueTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_UniqueTable();
            item.Id = itemId;
            item.RefID = BitConverter.ToUInt16(file, itemOffset);
            item.Probability = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DelayMin = BitConverter.ToSingle(file, itemOffset + 4);
            item.DelayMax = BitConverter.ToSingle(file, itemOffset + 8);
            item.FrequencyA = BitConverter.ToUInt16(file, itemOffset + 12);
            item.FrequencyB = BitConverter.ToUInt16(file, itemOffset + 14);
            item.FrequencyC = BitConverter.ToUInt16(file, itemOffset + 16);
            return item;
        }

        public static FLD_VoiceTable ReadFLD_VoiceTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_VoiceTable();
            item.Id = itemId;
            item.Driver1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Driver2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Driver3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Driver4 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.Driver5 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Driver6 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            return item;
        }

        public static FLD_VoiceTableBlade ReadFLD_VoiceTableBlade(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_VoiceTableBlade();
            item.Id = itemId;
            item.Blade1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Blade2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Blade3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Blade4 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.Blade5 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Blade6 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.Blade7 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.Blade8 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.Blade9 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.Blade10 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.Blade11 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            return item;
        }

        public static FLD_VoiceTableCommon ReadFLD_VoiceTableCommon(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_VoiceTableCommon();
            item.Id = itemId;
            item.CommonBlade1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.CommonBlade2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.CommonBlade3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.CommonBlade4 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.CommonBlade5 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.CommonBlade6 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.CommonBlade7 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.CommonBlade8 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.CommonBlade9 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.CommonBlade10 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.CommonBlade11 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.CommonBlade12 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.CommonBlade13 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.CommonBlade14 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.CommonBlade15 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 56));
            item.CommonBlade16 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 60));
            item.CommonBlade17 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 64));
            item.CommonBlade18 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 68));
            item.CommonBlade19 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 72));
            item.CommonBlade20 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 76));
            item.CommonBlade21 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 80));
            item.CommonBlade22 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 84));
            item.CommonBlade23 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 88));
            item.CommonBlade24 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 92));
            item.CommonBlade25 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 96));
            item.CommonBlade26 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 100));
            item.CommonBlade27 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 104));
            item.CommonBlade28 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 108));
            item.CommonBlade29 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 112));
            item.CommonBlade30 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 116));
            item.CommonBlade31 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.CommonBlade32 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 124));
            return item;
        }

        public static FLD_VoiceTableRare ReadFLD_VoiceTableRare(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_VoiceTableRare();
            item.Id = itemId;
            item.RareBlade1 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RareBlade2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.RareBlade3 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.RareBlade4 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.RareBlade5 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.RareBlade6 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.RareBlade7 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.RareBlade8 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.RareBlade9 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.RareBlade10 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.RareBlade11 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.RareBlade12 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.RareBlade13 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.RareBlade14 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.RareBlade15 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 56));
            item.RareBlade16 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 60));
            item.RareBlade17 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 64));
            item.RareBlade18 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 68));
            item.RareBlade19 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 72));
            item.RareBlade20 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 76));
            item.RareBlade21 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 80));
            item.RareBlade22 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 84));
            item.RareBlade23 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 88));
            item.RareBlade24 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 92));
            item.RareBlade25 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 96));
            item.RareBlade26 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 100));
            item.RareBlade27 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 104));
            item.RareBlade28 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 108));
            item.RareBlade29 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 112));
            item.RareBlade30 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 116));
            item.RareBlade31 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.RareBlade32 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 124));
            item.RareBlade33 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 128));
            item.RareBlade34 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 132));
            item.RareBlade35 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 136));
            item.RareBlade36 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 140));
            item.RareBlade37 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 144));
            item.RareBlade38 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 148));
            item.RareBlade39 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 152));
            item.RareBlade40 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 156));
            item.RareBlade41 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 160));
            item.RareBlade42 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 164));
            item.RareBlade43 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 168));
            return item;
        }

        public static FLD_WarpGimmick ReadFLD_WarpGimmick(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_WarpGimmick();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.gimmickType = file[itemOffset + 6];
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 9);
            item.tgtMSG_ID = BitConverter.ToUInt16(file, itemOffset + 11);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 13);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 15);
            item.fadeIN_Time = BitConverter.ToSingle(file, itemOffset + 17);
            item.fadeOUT_Time = BitConverter.ToSingle(file, itemOffset + 21);
            item.warp_nextwait = BitConverter.ToInt16(file, itemOffset + 25);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 27);
            return item;
        }

        public static FLD_WeatherInfo ReadFLD_WeatherInfo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_WeatherInfo();
            item.Id = itemId;
            item.msg = BitConverter.ToUInt16(file, itemOffset);
            item.eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.snd = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.sndBegin = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            return item;
        }

        public static FLD_wildcardData ReadFLD_wildcardData(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new FLD_wildcardData();
            item.Id = itemId;
            item.valueF4 = BitConverter.ToSingle(file, itemOffset);
            item.valueU2 = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static Fx_Act_Surface_Table ReadFx_Act_Surface_Table(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Fx_Act_Surface_Table();
            item.Id = itemId;
            item.SolidDefault = file[itemOffset];
            item.SolidWater = file[itemOffset + 1];
            item.SolidSoil = file[itemOffset + 2];
            item.SolidSand = file[itemOffset + 3];
            item.SolidGrass = file[itemOffset + 4];
            item.SolidWood = file[itemOffset + 5];
            item.SolidIron = file[itemOffset + 6];
            item.SolidWiremesh = file[itemOffset + 7];
            item.SolidSnow = file[itemOffset + 8];
            item.SolidCarpet = file[itemOffset + 9];
            item.SolidGel = file[itemOffset + 10];
            item.SolidCloud = file[itemOffset + 11];
            item.SolidIce = file[itemOffset + 12];
            item.FxSolidLuminescence = file[itemOffset + 13];
            item.FxSolidSpore = file[itemOffset + 14];
            item.FxSolidCloud = file[itemOffset + 15];
            item.LiquidWater = file[itemOffset + 16];
            item.LiquidCloud = file[itemOffset + 17];
            item.FxLiquidLuminescence = file[itemOffset + 18];
            return item;
        }

        public static Fx_FileName ReadFx_FileName(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Fx_FileName();
            item.Id = itemId;
            item.file_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static Fx_Surface_Chara_Table ReadFx_Surface_Chara_Table(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Fx_Surface_Chara_Table();
            item.Id = itemId;
            item.TYPE_HUMAN = file[itemOffset];
            item.TYPE_HUMAN_HEELS = file[itemOffset + 1];
            item.TYPE_HUMAN_GETA = file[itemOffset + 2];
            item.TYPE_NOPON = file[itemOffset + 3];
            item.TYPE_HUGE = file[itemOffset + 4];
            item.TYPE_FOUR_FOOTED = file[itemOffset + 5];
            item.TYPE_ENEMY_M = file[itemOffset + 6];
            item.TYPE_ENEMY_L = file[itemOffset + 7];
            return item;
        }

        public static IRA_Party ReadIRA_Party(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new IRA_Party();
            item.Id = itemId;
            item.driver11 = BitConverter.ToUInt16(file, itemOffset);
            item.blade11 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.blade12 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.driver21 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.blade21 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.blade22 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.driver31 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.blade31 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.blade32 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Guest1 = file[itemOffset + 18];
            item.Guest2 = file[itemOffset + 19];
            item.Guest3 = file[itemOffset + 20];
            return item;
        }

        public static ITM_BoosterList ReadITM_BoosterList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_BoosterList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Category = file[itemOffset + 4];
            item.Idea = (sbyte)file[itemOffset + 5];
            item.Rarity = file[itemOffset + 6];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 7);
            item.ValueMax = file[itemOffset + 11];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 12);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 40);
            return item;
        }

        public static ITM_CollectionList ReadITM_CollectionList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_CollectionList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Category = file[itemOffset + 4];
            item.Zone = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Rarity = file[itemOffset + 7];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 8);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 12);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 40);
            return item;
        }

        public static ITM_CrystalList ReadITM_CrystalList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_CrystalList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Rarity = file[itemOffset + 2];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 3);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 7);
            item.NoMultiple = BitConverter.ToUInt16(file, itemOffset + 9);
            item.ValueMax = file[itemOffset + 11];
            item.RareTableProb = file[itemOffset + 12];
            item.RareBladeRev = BitConverter.ToUInt16(file, itemOffset + 13);
            item.CommonPow = file[itemOffset + 15];
            item.AssureP = BitConverter.ToUInt16(file, itemOffset + 16);
            item.BladeID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.CommonID = BitConverter.ToUInt16(file, itemOffset + 20);
            item.CommonWpn = file[itemOffset + 22];
            item.CommonAtr = file[itemOffset + 23];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 40);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 44);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 48);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 52);
            return item;
        }

        public static ITM_EtherCrystal ReadITM_EtherCrystal(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_EtherCrystal();
            item.Id = itemId;
            item.Score = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static ITM_EventList ReadITM_EventList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_EventList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 4);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 8);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 12);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 32);
            return item;
        }

        public static ITM_FavoriteList ReadITM_FavoriteList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_FavoriteList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Category = file[itemOffset + 4];
            item.Zone = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Rarity = file[itemOffset + 7];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 8);
            item.Type = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Time = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ValueMax = file[itemOffset + 16];
            item.TrustPoint = BitConverter.ToUInt16(file, itemOffset + 17);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 19);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 23);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 27);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 31);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 35);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 39);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 43);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 47);
            return item;
        }

        public static ITM_HanaArtsEnh ReadITM_HanaArtsEnh(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_HanaArtsEnh();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Flag = file[itemOffset + 4];
            item.NeedPow = BitConverter.ToUInt16(file, itemOffset + 5);
            item.NeedEther = BitConverter.ToUInt32(file, itemOffset + 7);
            item.DustEther = BitConverter.ToUInt32(file, itemOffset + 11);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 15);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 17));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 21);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 25);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 29);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 33);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 37);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 41);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 45);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 49);
            item.JS = (item.Flag & 1) != 0;
            item.JK = (item.Flag & 2) != 0;
            item.JD = (item.Flag & 4) != 0;
            return item;
        }

        public static ITM_HanaAssist ReadITM_HanaAssist(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_HanaAssist();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 2);
            item.EnhanceCategory = file[itemOffset + 4];
            item.Flag = file[itemOffset + 5];
            item.NeedPow = BitConverter.ToUInt16(file, itemOffset + 6);
            item.NeedEther = BitConverter.ToUInt32(file, itemOffset + 8);
            item.DustEther = BitConverter.ToUInt32(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 16);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 22);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 26);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 30);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 34);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 38);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 42);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 46);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 50);
            item.JS = (item.Flag & 1) != 0;
            item.JK = (item.Flag & 2) != 0;
            item.JD = (item.Flag & 4) != 0;
            return item;
        }

        public static ITM_HanaAtr ReadITM_HanaAtr(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_HanaAtr();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.Caption = file[itemOffset + 1];
            item.Atr = file[itemOffset + 2];
            item.Flag = file[itemOffset + 3];
            item.NeedPow = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NeedEther = BitConverter.ToUInt32(file, itemOffset + 6);
            item.DustEther = BitConverter.ToUInt32(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 40);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 44);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 48);
            item.JS = (item.Flag & 1) != 0;
            item.JK = (item.Flag & 2) != 0;
            item.JD = (item.Flag & 4) != 0;
            return item;
        }

        public static ITM_HanaNArtsSet ReadITM_HanaNArtsSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_HanaNArtsSet();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.NArts = file[itemOffset + 1];
            item.NArtsRecastRev = file[itemOffset + 2];
            item.Flag = file[itemOffset + 3];
            item.NeedPow = BitConverter.ToUInt16(file, itemOffset + 4);
            item.NeedEther = BitConverter.ToUInt32(file, itemOffset + 6);
            item.DustEther = BitConverter.ToUInt32(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 40);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 44);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 48);
            item.JS = (item.Flag & 1) != 0;
            item.JK = (item.Flag & 2) != 0;
            item.JD = (item.Flag & 4) != 0;
            return item;
        }

        public static ITM_HanaRole ReadITM_HanaRole(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_HanaRole();
            item.Id = itemId;
            item.Name = file[itemOffset];
            item.Role = file[itemOffset + 1];
            item.PArmor = file[itemOffset + 2];
            item.EArmor = file[itemOffset + 3];
            item.HpMaxRev = file[itemOffset + 4];
            item.StrengthRev = file[itemOffset + 5];
            item.PowEtherRev = file[itemOffset + 6];
            item.DexRev = file[itemOffset + 7];
            item.AgilityRev = file[itemOffset + 8];
            item.LuckRev = file[itemOffset + 9];
            item.AutoHate = (sbyte)file[itemOffset + 10];
            item.ArtsHate = (sbyte)file[itemOffset + 11];
            item.Flag = file[itemOffset + 12];
            item.NeedPow = BitConverter.ToUInt16(file, itemOffset + 13);
            item.NeedEther = BitConverter.ToUInt32(file, itemOffset + 15);
            item.DustEther = BitConverter.ToUInt32(file, itemOffset + 19);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 23);
            item.UI = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 25));
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 29);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 33);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 37);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 41);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 45);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 49);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 53);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 57);
            item.JS = (item.Flag & 1) != 0;
            item.JK = (item.Flag & 2) != 0;
            item.JD = (item.Flag & 4) != 0;
            return item;
        }

        public static ITM_InfoList ReadITM_InfoList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_InfoList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Price = BitConverter.ToUInt32(file, itemOffset + 4);
            item.ClearNewGame = file[itemOffset + 8];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 9);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 13);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 17);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 21);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 25);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 29);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 33);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 37);
            return item;
        }

        public static ITM_Orb ReadITM_Orb(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_Orb();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Recipe = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EquipItemID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Price = BitConverter.ToUInt32(file, itemOffset + 10);
            item.Rarity = file[itemOffset + 14];
            item.Flag = file[itemOffset + 15];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 40);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 44);
            item.NoSell = (item.Flag & 1) != 0;
            return item;
        }

        public static ITM_OrbEquip ReadITM_OrbEquip(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_OrbEquip();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Enhance = BitConverter.ToUInt16(file, itemOffset + 6);
            item.EnhanceCategory = file[itemOffset + 8];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 9);
            item.Rarity = file[itemOffset + 13];
            item.Flag = file[itemOffset + 14];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 15);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 19);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 23);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 27);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 31);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 35);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 39);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 43);
            item.NoSell = (item.Flag & 1) != 0;
            return item;
        }

        public static ITM_OrbRecipe ReadITM_OrbRecipe(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_OrbRecipe();
            item.Id = itemId;
            item.RecipeType = file[itemOffset];
            item.Rarity = file[itemOffset + 1];
            item.RscCat = file[itemOffset + 2];
            item.AssortNumber = BitConverter.ToUInt16(file, itemOffset + 3);
            item.ItemID1 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.ItemNumber1 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ItemID2 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.ItemNumber2 = BitConverter.ToUInt16(file, itemOffset + 11);
            item.ItemID3 = BitConverter.ToUInt16(file, itemOffset + 13);
            item.ItemNumber3 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.ItemID4 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.ItemNumber4 = BitConverter.ToUInt16(file, itemOffset + 19);
            item.ItemID5 = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ItemNumber5 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.ItemID6 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.ItemNumber6 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ItemID7 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.ItemNumber7 = BitConverter.ToUInt16(file, itemOffset + 31);
            item.ItemID8 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ItemNumber8 = BitConverter.ToUInt16(file, itemOffset + 35);
            return item;
        }

        public static ITM_PcEquip ReadITM_PcEquip(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PcEquip();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.ArmorType = file[itemOffset + 6];
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.AddAtr = file[itemOffset + 9];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 10);
            item.Rarity = file[itemOffset + 14];
            item.Flag = BitConverter.ToUInt16(file, itemOffset + 15);
            item.PArmor = BitConverter.ToUInt16(file, itemOffset + 17);
            item.EArmor = BitConverter.ToUInt16(file, itemOffset + 19);
            item.Bns_HpMax = BitConverter.ToUInt16(file, itemOffset + 21);
            item.Bns_Strength = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Bns_PowEther = BitConverter.ToUInt16(file, itemOffset + 25);
            item.Bns_Dex = BitConverter.ToUInt16(file, itemOffset + 27);
            item.Bns_Agility = BitConverter.ToUInt16(file, itemOffset + 29);
            item.Bns_Luck = BitConverter.ToUInt16(file, itemOffset + 31);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.Icon = file[itemOffset + 35];
            item.Zone = BitConverter.ToUInt16(file, itemOffset + 36);
            item.Zone2 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 40);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 44);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 48);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 52);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 56);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 60);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 64);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 68);
            item.NoSell = (item.Flag & 1) != 0;
            item.EqPC01 = (item.Flag & 2) != 0;
            item.EqPC02 = (item.Flag & 4) != 0;
            item.EqPC03 = (item.Flag & 8) != 0;
            item.EqPC04 = (item.Flag & 16) != 0;
            item.EqPC05 = (item.Flag & 32) != 0;
            item.EqPC06 = (item.Flag & 64) != 0;
            item.EqPC07 = (item.Flag & 128) != 0;
            item.EqPC08 = (item.Flag & 256) != 0;
            item.EqPC09 = (item.Flag & 512) != 0;
            return item;
        }

        public static ITM_PcWpn ReadITM_PcWpn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PcWpn();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Rank = file[itemOffset + 6];
            item.Flag = file[itemOffset + 7];
            item.RscR = BitConverter.ToUInt16(file, itemOffset + 8);
            item.RscL = BitConverter.ToUInt16(file, itemOffset + 10);
            item.TypeRange = file[itemOffset + 12];
            item.WpnType = file[itemOffset + 13];
            item.Damage = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Stability = file[itemOffset + 16];
            item.CriRate = file[itemOffset + 17];
            item.GuardRate = file[itemOffset + 18];
            item.Enhance1 = BitConverter.ToUInt16(file, itemOffset + 19);
            item.PArmor = BitConverter.ToUInt16(file, itemOffset + 21);
            item.EArmor = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Enhance2 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.Private = (item.Flag & 1) != 0;
            return item;
        }

        public static ITM_PcWpnChip ReadITM_PcWpnChip(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PcWpnChip();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.Rank = file[itemOffset + 6];
            item.CreateWpn1 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.CreateWpn2 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.CreateWpn3 = BitConverter.ToUInt16(file, itemOffset + 11);
            item.CreateWpn4 = BitConverter.ToUInt16(file, itemOffset + 13);
            item.CreateWpn5 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.CreateWpn6 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.CreateWpn7 = BitConverter.ToUInt16(file, itemOffset + 19);
            item.CreateWpn8 = BitConverter.ToUInt16(file, itemOffset + 21);
            item.CreateWpn9 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.CreateWpn10 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.CreateWpn11 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.CreateWpn12 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.CreateWpn13 = BitConverter.ToUInt16(file, itemOffset + 31);
            item.CreateWpn14 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.CreateWpn15 = BitConverter.ToUInt16(file, itemOffset + 35);
            item.CreateWpn16 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.CreateWpn17 = BitConverter.ToUInt16(file, itemOffset + 39);
            item.CreateWpn18 = BitConverter.ToUInt16(file, itemOffset + 41);
            item.CreateWpn19 = BitConverter.ToUInt16(file, itemOffset + 43);
            item.CreateWpn20 = BitConverter.ToUInt16(file, itemOffset + 45);
            item.CreateWpn21 = BitConverter.ToUInt16(file, itemOffset + 47);
            item.CreateWpn22 = BitConverter.ToUInt16(file, itemOffset + 49);
            item.CreateWpn23 = BitConverter.ToUInt16(file, itemOffset + 51);
            item.CreateWpn24 = BitConverter.ToUInt16(file, itemOffset + 53);
            item.CreateWpn25 = BitConverter.ToUInt16(file, itemOffset + 55);
            item.CreateWpn26 = BitConverter.ToUInt16(file, itemOffset + 57);
            item.CreateWpn27 = BitConverter.ToUInt16(file, itemOffset + 59);
            item.CreateWpn28 = BitConverter.ToUInt16(file, itemOffset + 61);
            item.CreateWpn29 = BitConverter.ToUInt16(file, itemOffset + 63);
            item.CreateWpn30 = BitConverter.ToUInt16(file, itemOffset + 65);
            item.CreateWpn31 = BitConverter.ToUInt16(file, itemOffset + 67);
            item.CreateWpn32 = BitConverter.ToUInt16(file, itemOffset + 69);
            item.CreateWpn33 = BitConverter.ToUInt16(file, itemOffset + 71);
            item.CreateWpn34 = BitConverter.ToUInt16(file, itemOffset + 73);
            item.Price = BitConverter.ToUInt32(file, itemOffset + 75);
            item.Rarity = file[itemOffset + 79];
            item.Flag = file[itemOffset + 80];
            item.Zone = BitConverter.ToUInt16(file, itemOffset + 81);
            item.Zone2 = BitConverter.ToUInt16(file, itemOffset + 83);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 85);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 89);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 93);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 97);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 101);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 105);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 109);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 113);
            item.NoSell = (item.Flag & 1) != 0;
            return item;
        }

        public static ITM_PcWpnIr ReadITM_PcWpnIr(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PcWpnIr();
            item.Id = itemId;
            item.AtkLv1 = BitConverter.ToUInt16(file, itemOffset);
            item.AtkLv99 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.StbLv1 = file[itemOffset + 4];
            item.StbLv99 = file[itemOffset + 5];
            item.CriRateLv1 = file[itemOffset + 6];
            item.CriRateLv99 = file[itemOffset + 7];
            item.GuardRateLv1 = file[itemOffset + 8];
            item.GuardRateLv99 = file[itemOffset + 9];
            return item;
        }

        public static ITM_PcWpnType ReadITM_PcWpnType(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PcWpnType();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Role = file[itemOffset + 2];
            item.EffType = file[itemOffset + 3];
            item.JustRange = file[itemOffset + 4];
            item.JustRange2 = file[itemOffset + 5];
            item.VoiceType = file[itemOffset + 6];
            item.Motion = file[itemOffset + 7];
            return item;
        }

        public static ITM_PreciousList ReadITM_PreciousList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_PreciousList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Category = file[itemOffset + 4];
            item.Type = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Price = BitConverter.ToUInt32(file, itemOffset + 7);
            item.ValueMax = file[itemOffset + 11];
            item.ClearNewGame = file[itemOffset + 12];
            item.NoMultiple = BitConverter.ToUInt16(file, itemOffset + 13);
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 15);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 19);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 23);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 27);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 31);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 35);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 39);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 43);
            return item;
        }

        public static ITM_SalvageList ReadITM_SalvageList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_SalvageList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Rarity = file[itemOffset + 4];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 5);
            item.Quest = file[itemOffset + 9];
            item.NoSell = file[itemOffset + 10];
            item.Protect = file[itemOffset + 11];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 12);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 16);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 20);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 24);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 28);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 32);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 36);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 40);
            return item;
        }

        public static ITM_TresureList ReadITM_TresureList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ITM_TresureList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.Caption = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Category = file[itemOffset + 4];
            item.Graphic = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Zone = BitConverter.ToUInt16(file, itemOffset + 7);
            item.Rarity = file[itemOffset + 9];
            item.Price = BitConverter.ToUInt32(file, itemOffset + 10);
            item.Flag = BitConverter.ToUInt16(file, itemOffset + 14);
            item.NoMultiple = BitConverter.ToUInt16(file, itemOffset + 16);
            item.ClearNewGame = file[itemOffset + 18];
            item.sortJP = BitConverter.ToUInt32(file, itemOffset + 19);
            item.sortGE = BitConverter.ToUInt32(file, itemOffset + 23);
            item.sortFR = BitConverter.ToUInt32(file, itemOffset + 27);
            item.sortSP = BitConverter.ToUInt32(file, itemOffset + 31);
            item.sortIT = BitConverter.ToUInt32(file, itemOffset + 35);
            item.sortGB = BitConverter.ToUInt32(file, itemOffset + 39);
            item.sortCN = BitConverter.ToUInt32(file, itemOffset + 43);
            item.sortTW = BitConverter.ToUInt32(file, itemOffset + 47);
            return item;
        }

        public static LabeledMessage ReadLabeledMessage(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new LabeledMessage();
            item.Id = itemId;
            item.label = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.style = BitConverter.ToUInt16(file, itemOffset + 4);
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            return item;
        }

        public static ma01a_FLD_EnemyPop Readma01a_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma01a_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = file[itemOffset + 53];
            item.ene_disp_h = file[itemOffset + 54];
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 55);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 57);
            item.muteki_QuestFlagMin = file[itemOffset + 59];
            item.muteki_QuestFlagMax = file[itemOffset + 60];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 61);
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            return item;
        }

        public static ma01a_FLD_LandmarkPop Readma01a_FLD_LandmarkPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma01a_FLD_LandmarkPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MSGID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.category = file[itemOffset + 6];
            item.cndID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.getEXP = BitConverter.ToUInt16(file, itemOffset + 9);
            item.getSP = BitConverter.ToUInt16(file, itemOffset + 11);
            item.developZone = file[itemOffset + 13];
            item.get_DPT = BitConverter.ToUInt16(file, itemOffset + 14);
            item.MAPJUMPID = BitConverter.ToUInt16(file, itemOffset + 16);
            item.stoff_cndID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.flag = file[itemOffset + 20];
            item.noTelop = (item.flag & 1) != 0;
            return item;
        }

        public static ma01a_FLD_MapObjPop Readma01a_FLD_MapObjPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma01a_FLD_MapObjPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.StateName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Priority = file[itemOffset + 20];
            item.flag = file[itemOffset + 21];
            item.mapobjcol = (item.flag & 1) != 0;
            return item;
        }

        public static ma01a_FLD_NpcPop Readma01a_FLD_NpcPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma01a_FLD_NpcPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlagMin = file[itemOffset + 12];
            item.QuestFlagMax = file[itemOffset + 13];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Group = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 20);
            item.MountPoint = BitConverter.ToUInt16(file, itemOffset + 22);
            item.MountObject = BitConverter.ToUInt16(file, itemOffset + 24);
            item.MountPoint2 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.MountObject2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.flag = file[itemOffset + 30];
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.NpcTurn = file[itemOffset + 33];
            item.LookAt = file[itemOffset + 34];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 35);
            item.QuestID = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ShopID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.CloseRange = BitConverter.ToUInt16(file, itemOffset + 41);
            item.MoveSpeed = BitConverter.ToUInt16(file, itemOffset + 43);
            item.ReactionRange = BitConverter.ToUInt16(file, itemOffset + 45);
            item.ReactionPercent = BitConverter.ToUInt16(file, itemOffset + 47);
            item.ReactionMot = BitConverter.ToUInt16(file, itemOffset + 49);
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 51);
            item.BattleMot = BitConverter.ToUInt16(file, itemOffset + 53);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 55);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 57);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 59);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 61);
            item.FSID1 = BitConverter.ToUInt16(file, itemOffset + 63);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 65);
            item.FSID3 = BitConverter.ToUInt16(file, itemOffset + 67);
            item.Talkable = (item.flag & 1) != 0;
            return item;
        }

        public static ma02a_FLD_AutoTalk Readma02a_FLD_AutoTalk(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_AutoTalk();
            item.Id = itemId;
            item.MOBID = BitConverter.ToUInt16(file, itemOffset);
            item.Range = BitConverter.ToUInt16(file, itemOffset + 2);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Text = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Ontime = BitConverter.ToUInt16(file, itemOffset + 8);
            item.BeforeID = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static ma02a_FLD_CollectionPopList Readma02a_FLD_CollectionPopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_CollectionPopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 8);
            item.popWeather = file[itemOffset + 12];
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.randitmPopMin = file[itemOffset + 15];
            item.randitmPopMax = file[itemOffset + 16];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 17);
            item.itm1Per = file[itemOffset + 19];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 20);
            item.itm2Per = file[itemOffset + 22];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 23);
            item.itm3Per = file[itemOffset + 25];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 26);
            item.itm4Per = file[itemOffset + 28];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 29);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 33);
            item.goldPopMin = file[itemOffset + 37];
            item.goldPopMax = file[itemOffset + 38];
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 39);
            item.rsc_paramID = file[itemOffset + 41];
            item.initWaitTime = BitConverter.ToSingle(file, itemOffset + 42);
            item.initWaitTimeRand = BitConverter.ToSingle(file, itemOffset + 46);
            return item;
        }

        public static ma02a_FLD_EventPop Readma02a_FLD_EventPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_EventPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlagMin = file[itemOffset + 10];
            item.QuestFlagMax = file[itemOffset + 11];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Name = BitConverter.ToUInt16(file, itemOffset + 18);
            item.UIOffset = BitConverter.ToUInt16(file, itemOffset + 20);
            return item;
        }

        public static ma02a_FLD_LandmarkPop Readma02a_FLD_LandmarkPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_LandmarkPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MSGID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.category = file[itemOffset + 6];
            item.cndID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.getEXP = BitConverter.ToUInt16(file, itemOffset + 9);
            item.getSP = BitConverter.ToUInt16(file, itemOffset + 11);
            item.developZone = file[itemOffset + 13];
            item.get_DPT = BitConverter.ToUInt16(file, itemOffset + 14);
            item.MAPJUMPID = BitConverter.ToUInt16(file, itemOffset + 16);
            item.stoff_cndID = BitConverter.ToUInt16(file, itemOffset + 18);
            item.menuGroup = BitConverter.ToUInt16(file, itemOffset + 20);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 22);
            item.menuPriority = BitConverter.ToUInt16(file, itemOffset + 24);
            item.menu_transX = BitConverter.ToInt16(file, itemOffset + 26);
            item.menu_transY = BitConverter.ToInt16(file, itemOffset + 28);
            item.flag = file[itemOffset + 30];
            item.noTelop = (item.flag & 1) != 0;
            return item;
        }

        public static ma02a_FLD_MobPop Readma02a_FLD_MobPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_MobPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MobID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.MOBGroupID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 12);
            item.QuestFlagMin = file[itemOffset + 14];
            item.QuestFlagMax = file[itemOffset + 15];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Group = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 22);
            item.MountPoint = BitConverter.ToUInt16(file, itemOffset + 24);
            item.MountObject = BitConverter.ToUInt16(file, itemOffset + 26);
            item.MountPoint2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.MountObject2 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.LookAt = file[itemOffset + 32];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ReactionRange = BitConverter.ToUInt16(file, itemOffset + 35);
            item.ReactionPercent = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ReactionMot = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ScaleMin = file[itemOffset + 41];
            item.ScaleMax = file[itemOffset + 42];
            item.PopMin = file[itemOffset + 43];
            item.PopMax = file[itemOffset + 44];
            item.MotSpeedMin = file[itemOffset + 45];
            item.MotSpeedMax = file[itemOffset + 46];
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 47);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 49);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 51);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 53);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 55);
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 57);
            return item;
        }

        public static ma02a_FLD_TboxPop Readma02a_FLD_TboxPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma02a_FLD_TboxPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.flag = file[itemOffset + 12];
            item.msgVisible = file[itemOffset + 13];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 14);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 18);
            item.goldPopMin = file[itemOffset + 22];
            item.goldPopMax = file[itemOffset + 23];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 24);
            item.itm1Num = file[itemOffset + 26];
            item.itm1Per = file[itemOffset + 27];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 28);
            item.itm2Num = file[itemOffset + 30];
            item.itm2Per = file[itemOffset + 31];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 32);
            item.itm3Num = file[itemOffset + 34];
            item.itm3Per = file[itemOffset + 35];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 36);
            item.itm4Num = file[itemOffset + 38];
            item.itm4Per = file[itemOffset + 39];
            item.itm5ID = BitConverter.ToUInt16(file, itemOffset + 40);
            item.itm5Num = file[itemOffset + 42];
            item.itm5Per = file[itemOffset + 43];
            item.itm6ID = BitConverter.ToUInt16(file, itemOffset + 44);
            item.itm6Num = file[itemOffset + 46];
            item.itm6Per = file[itemOffset + 47];
            item.itm7ID = BitConverter.ToUInt16(file, itemOffset + 48);
            item.itm7Num = file[itemOffset + 50];
            item.itm7Per = file[itemOffset + 51];
            item.itm8ID = BitConverter.ToUInt16(file, itemOffset + 52);
            item.itm8Num = file[itemOffset + 54];
            item.itm8Per = file[itemOffset + 55];
            item.randitmPopMin = file[itemOffset + 56];
            item.randitmPopMax = file[itemOffset + 57];
            item.rsc_paramID = file[itemOffset + 58];
            item.msgdigVisible = file[itemOffset + 59];
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 60);
            item.Digflg = (item.flag & 1) != 0;
            return item;
        }

        public static ma03a_FLD_TboxPop Readma03a_FLD_TboxPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma03a_FLD_TboxPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.flag = file[itemOffset + 12];
            item.msgVisible = file[itemOffset + 13];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 14);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 18);
            item.goldPopMin = file[itemOffset + 22];
            item.goldPopMax = file[itemOffset + 23];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 24);
            item.itm1Num = file[itemOffset + 26];
            item.itm1Per = file[itemOffset + 27];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 28);
            item.itm2Num = file[itemOffset + 30];
            item.itm2Per = file[itemOffset + 31];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 32);
            item.itm3Num = file[itemOffset + 34];
            item.itm3Per = file[itemOffset + 35];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 36);
            item.itm4Num = file[itemOffset + 38];
            item.itm4Per = file[itemOffset + 39];
            item.itm5ID = BitConverter.ToUInt16(file, itemOffset + 40);
            item.itm5Num = file[itemOffset + 42];
            item.itm5Per = file[itemOffset + 43];
            item.itm6ID = BitConverter.ToUInt16(file, itemOffset + 44);
            item.itm6Num = file[itemOffset + 46];
            item.itm6Per = file[itemOffset + 47];
            item.itm7ID = BitConverter.ToUInt16(file, itemOffset + 48);
            item.itm7Num = file[itemOffset + 50];
            item.itm7Per = file[itemOffset + 51];
            item.itm8ID = BitConverter.ToUInt16(file, itemOffset + 52);
            item.itm8Num = file[itemOffset + 54];
            item.itm8Per = file[itemOffset + 55];
            item.randitmPopMin = file[itemOffset + 56];
            item.randitmPopMax = file[itemOffset + 57];
            item.rsc_paramID = file[itemOffset + 58];
            item.msgdigVisible = file[itemOffset + 59];
            item.Digflg = (item.flag & 1) != 0;
            return item;
        }

        public static ma04a_FLD_PreciousPopList Readma04a_FLD_PreciousPopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma04a_FLD_PreciousPopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlagMin = file[itemOffset + 6];
            item.QuestFlagMax = file[itemOffset + 7];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 14);
            item.popWeather = file[itemOffset + 18];
            item.itmID = BitConverter.ToUInt16(file, itemOffset + 19);
            item.QuestID = BitConverter.ToUInt16(file, itemOffset + 21);
            return item;
        }

        public static ma05a_FLD_EnemyPop Readma05a_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma05a_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = file[itemOffset + 53];
            item.ene_disp_h = file[itemOffset + 54];
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 55);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 57);
            item.muteki_QuestFlagMin = file[itemOffset + 59];
            item.muteki_QuestFlagMax = file[itemOffset + 60];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 61);
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            item.noNaviMesh = (item.flag & 8) != 0;
            return item;
        }

        public static ma05a_FLD_LandmarkPop Readma05a_FLD_LandmarkPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma05a_FLD_LandmarkPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MSGID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.category = file[itemOffset + 6];
            item.cndID = BitConverter.ToUInt16(file, itemOffset + 7);
            item.getEXP = BitConverter.ToUInt16(file, itemOffset + 9);
            item.getSP = BitConverter.ToUInt16(file, itemOffset + 11);
            item.developZone = file[itemOffset + 13];
            item.get_DPT = BitConverter.ToUInt16(file, itemOffset + 14);
            item.MAPJUMPID = BitConverter.ToUInt16(file, itemOffset + 16);
            item.menuGroup = BitConverter.ToUInt16(file, itemOffset + 18);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 20);
            item.stoff_cndID = BitConverter.ToUInt16(file, itemOffset + 22);
            item.menuPriority = BitConverter.ToUInt16(file, itemOffset + 24);
            item.menu_transX = BitConverter.ToInt16(file, itemOffset + 26);
            item.menu_transY = BitConverter.ToInt16(file, itemOffset + 28);
            item.flag = file[itemOffset + 30];
            item.noTelop = (item.flag & 1) != 0;
            return item;
        }

        public static ma05a_FLD_NpcPop Readma05a_FLD_NpcPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma05a_FLD_NpcPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlagMin = file[itemOffset + 12];
            item.QuestFlagMax = file[itemOffset + 13];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Group = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 20);
            item.MountPoint = BitConverter.ToUInt16(file, itemOffset + 22);
            item.MountObject = BitConverter.ToUInt16(file, itemOffset + 24);
            item.MountPoint2 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.MountObject2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.flag = file[itemOffset + 30];
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.NpcTurn = file[itemOffset + 33];
            item.LookAt = file[itemOffset + 34];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 35);
            item.QuestID = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ShopID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.CloseRange = BitConverter.ToUInt16(file, itemOffset + 41);
            item.MoveSpeed = BitConverter.ToUInt16(file, itemOffset + 43);
            item.ReactionRange = BitConverter.ToUInt16(file, itemOffset + 45);
            item.ReactionPercent = BitConverter.ToUInt16(file, itemOffset + 47);
            item.ReactionMot = BitConverter.ToUInt16(file, itemOffset + 49);
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 51);
            item.BattleMot = BitConverter.ToUInt16(file, itemOffset + 53);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 55);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 57);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 59);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 61);
            item.FSID1 = BitConverter.ToUInt16(file, itemOffset + 63);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 65);
            item.FSID3 = BitConverter.ToUInt16(file, itemOffset + 67);
            item.FSID4 = BitConverter.ToUInt16(file, itemOffset + 69);
            item.FSID5 = BitConverter.ToUInt16(file, itemOffset + 71);
            item.Talkable = (item.flag & 1) != 0;
            return item;
        }

        public static ma05c_FLD_EnemyPop Readma05c_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma05c_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = file[itemOffset + 53];
            item.ene_disp_h = file[itemOffset + 54];
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 55);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 57);
            item.muteki_QuestFlagMin = file[itemOffset + 59];
            item.muteki_QuestFlagMax = file[itemOffset + 60];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 61);
            item.Wpop_Priority = file[itemOffset + 63];
            item.Wpop_TimerCond = BitConverter.ToUInt16(file, itemOffset + 64);
            item.Wpop_PopNumCond = file[itemOffset + 66];
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            return item;
        }

        public static ma07a_FLD_CollectionPopList Readma07a_FLD_CollectionPopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma07a_FLD_CollectionPopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 8);
            item.popWeather = file[itemOffset + 12];
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.randitmPopMin = file[itemOffset + 15];
            item.randitmPopMax = file[itemOffset + 16];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 17);
            item.itm1Per = file[itemOffset + 19];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 20);
            item.itm2Per = file[itemOffset + 22];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 23);
            item.itm3Per = file[itemOffset + 25];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 26);
            item.itm4Per = file[itemOffset + 28];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 29);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 33);
            item.goldPopMin = file[itemOffset + 37];
            item.goldPopMax = file[itemOffset + 38];
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 39);
            item.rsc_paramID = file[itemOffset + 41];
            item.initWaitTime = BitConverter.ToSingle(file, itemOffset + 42);
            item.initWaitTimeRand = BitConverter.ToSingle(file, itemOffset + 46);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 50);
            return item;
        }

        public static ma07a_FLD_EventPop Readma07a_FLD_EventPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma07a_FLD_EventPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlagMin = file[itemOffset + 10];
            item.QuestFlagMax = file[itemOffset + 11];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 12);
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Icon = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Name = BitConverter.ToUInt16(file, itemOffset + 18);
            item.UIOffset = BitConverter.ToUInt16(file, itemOffset + 20);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 22);
            return item;
        }

        public static ma07a_FLD_NpcPop Readma07a_FLD_NpcPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma07a_FLD_NpcPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.NpcID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 8);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlagMin = file[itemOffset + 12];
            item.QuestFlagMax = file[itemOffset + 13];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Group = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 20);
            item.MountPoint = BitConverter.ToUInt16(file, itemOffset + 22);
            item.MountObject = BitConverter.ToUInt16(file, itemOffset + 24);
            item.MountPoint2 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.MountObject2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.flag = file[itemOffset + 30];
            item.EventID = BitConverter.ToUInt16(file, itemOffset + 31);
            item.NpcTurn = file[itemOffset + 33];
            item.LookAt = file[itemOffset + 34];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 35);
            item.QuestID = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ShopID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.CloseRange = BitConverter.ToUInt16(file, itemOffset + 41);
            item.MoveSpeed = BitConverter.ToUInt16(file, itemOffset + 43);
            item.ReactionRange = BitConverter.ToUInt16(file, itemOffset + 45);
            item.ReactionPercent = BitConverter.ToUInt16(file, itemOffset + 47);
            item.ReactionMot = BitConverter.ToUInt16(file, itemOffset + 49);
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 51);
            item.BattleMot = BitConverter.ToUInt16(file, itemOffset + 53);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 55);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 57);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 59);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 61);
            item.FSID1 = BitConverter.ToUInt16(file, itemOffset + 63);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 65);
            item.FSID3 = BitConverter.ToUInt16(file, itemOffset + 67);
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 69);
            item.Talkable = (item.flag & 1) != 0;
            return item;
        }

        public static ma08a_FLD_EnemyPop Readma08a_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma08a_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = BitConverter.ToUInt16(file, itemOffset + 53);
            item.ene_disp_h = BitConverter.ToUInt16(file, itemOffset + 55);
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 57);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 59);
            item.muteki_QuestFlagMin = file[itemOffset + 61];
            item.muteki_QuestFlagMax = file[itemOffset + 62];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 63);
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            return item;
        }

        public static ma10a_FLD_EnemyPop Readma10a_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma10a_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = BitConverter.ToUInt16(file, itemOffset + 53);
            item.ene_disp_h = file[itemOffset + 55];
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 56);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 58);
            item.muteki_QuestFlagMin = file[itemOffset + 60];
            item.muteki_QuestFlagMax = file[itemOffset + 61];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 62);
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            item.noNaviMesh = (item.flag & 8) != 0;
            return item;
        }

        public static ma20a_FLD_EnemyPop Readma20a_FLD_EnemyPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma20a_FLD_EnemyPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.tagetpoint_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 6);
            item.QuestFlagMin = file[itemOffset + 8];
            item.QuestFlagMax = file[itemOffset + 9];
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 12);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 14);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 16);
            item.popWeather = file[itemOffset + 20];
            item.ene1ID = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ene1Lv = (sbyte)file[itemOffset + 23];
            item.ene1Per = file[itemOffset + 24];
            item.ene1num = file[itemOffset + 25];
            item.ene1move = file[itemOffset + 26];
            item.ene2ID = BitConverter.ToUInt16(file, itemOffset + 27);
            item.ene2Lv = (sbyte)file[itemOffset + 29];
            item.ene2Per = file[itemOffset + 30];
            item.ene2num = file[itemOffset + 31];
            item.ene2move = file[itemOffset + 32];
            item.ene3ID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ene3Lv = (sbyte)file[itemOffset + 35];
            item.ene3Per = file[itemOffset + 36];
            item.ene3num = file[itemOffset + 37];
            item.ene3move = file[itemOffset + 38];
            item.ene4ID = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ene4Lv = (sbyte)file[itemOffset + 41];
            item.ene4Per = file[itemOffset + 42];
            item.ene4num = file[itemOffset + 43];
            item.ene4move = file[itemOffset + 44];
            item.party_flag = file[itemOffset + 45];
            item.flag = file[itemOffset + 46];
            item.pop_act_type = file[itemOffset + 47];
            item.form_range = file[itemOffset + 48];
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 49);
            item.squadScale = BitConverter.ToUInt16(file, itemOffset + 51);
            item.ene_disp_r = BitConverter.ToUInt16(file, itemOffset + 53);
            item.ene_disp_h = BitConverter.ToUInt16(file, itemOffset + 55);
            item.battlelockname = BitConverter.ToUInt16(file, itemOffset + 57);
            item.muteki_QuestFlag = BitConverter.ToUInt16(file, itemOffset + 59);
            item.muteki_QuestFlagMin = file[itemOffset + 61];
            item.muteki_QuestFlagMax = file[itemOffset + 62];
            item.muteki_Condition = BitConverter.ToUInt16(file, itemOffset + 63);
            item.ene_priority = (item.flag & 1) != 0;
            item.pop_smn = (item.flag & 2) != 0;
            item.popCloud = (item.flag & 4) != 0;
            item.noNaviMesh = (item.flag & 8) != 0;
            return item;
        }

        public static ma40a_FLD_CollectionPopList Readma40a_FLD_CollectionPopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma40a_FLD_CollectionPopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 8);
            item.popWeather = file[itemOffset + 12];
            item.CollectionTable = BitConverter.ToUInt16(file, itemOffset + 13);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 15);
            item.initWaitTime = BitConverter.ToSingle(file, itemOffset + 17);
            item.initWaitTimeRand = BitConverter.ToSingle(file, itemOffset + 21);
            item.rarity = file[itemOffset + 25];
            return item;
        }

        public static ma40a_FLD_MobPop Readma40a_FLD_MobPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma40a_FLD_MobPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MobID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.MOBGroupID = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ScenarioFlagMin = BitConverter.ToUInt16(file, itemOffset + 8);
            item.ScenarioFlagMax = BitConverter.ToUInt16(file, itemOffset + 10);
            item.QuestFlag = BitConverter.ToUInt16(file, itemOffset + 12);
            item.QuestFlagMin = file[itemOffset + 14];
            item.QuestFlagMax = file[itemOffset + 15];
            item.TimeRange = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Group = BitConverter.ToUInt16(file, itemOffset + 20);
            item.Mot = BitConverter.ToUInt16(file, itemOffset + 22);
            item.MountPoint = BitConverter.ToUInt16(file, itemOffset + 24);
            item.MountObject = BitConverter.ToUInt16(file, itemOffset + 26);
            item.MountPoint2 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.MountObject2 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.LookAt = file[itemOffset + 32];
            item.LookAtRange = BitConverter.ToUInt16(file, itemOffset + 33);
            item.ReactionRange = BitConverter.ToUInt16(file, itemOffset + 35);
            item.ReactionPercent = BitConverter.ToUInt16(file, itemOffset + 37);
            item.ReactionMot = BitConverter.ToUInt16(file, itemOffset + 39);
            item.ScaleMin = file[itemOffset + 41];
            item.ScaleMax = file[itemOffset + 42];
            item.PopMin = file[itemOffset + 43];
            item.PopMax = file[itemOffset + 44];
            item.MotSpeedMin = file[itemOffset + 45];
            item.MotSpeedMax = file[itemOffset + 46];
            item.BattleReaction = BitConverter.ToUInt16(file, itemOffset + 47);
            item.Visible_XZ = BitConverter.ToUInt16(file, itemOffset + 49);
            item.Visible_Y = BitConverter.ToUInt16(file, itemOffset + 51);
            item.Invisible_XZ = BitConverter.ToUInt16(file, itemOffset + 53);
            item.Invisible_Y = BitConverter.ToUInt16(file, itemOffset + 55);
            item.squadId = BitConverter.ToUInt16(file, itemOffset + 57);
            item.CloseRange = BitConverter.ToUInt16(file, itemOffset + 59);
            return item;
        }

        public static ma40a_FLD_TboxPop Readma40a_FLD_TboxPop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma40a_FLD_TboxPop();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.RSC_ID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.FSID = BitConverter.ToUInt16(file, itemOffset + 8);
            item.FSID2 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.flag = file[itemOffset + 12];
            item.msgVisible = file[itemOffset + 13];
            item.goldMin = BitConverter.ToUInt32(file, itemOffset + 14);
            item.goldMax = BitConverter.ToUInt32(file, itemOffset + 18);
            item.goldPopMin = file[itemOffset + 22];
            item.goldPopMax = file[itemOffset + 23];
            item.itm1ID = BitConverter.ToUInt16(file, itemOffset + 24);
            item.itm1Num = file[itemOffset + 26];
            item.itm1Per = file[itemOffset + 27];
            item.itm2ID = BitConverter.ToUInt16(file, itemOffset + 28);
            item.itm2Num = file[itemOffset + 30];
            item.itm2Per = file[itemOffset + 31];
            item.itm3ID = BitConverter.ToUInt16(file, itemOffset + 32);
            item.itm3Num = file[itemOffset + 34];
            item.itm3Per = file[itemOffset + 35];
            item.itm4ID = BitConverter.ToUInt16(file, itemOffset + 36);
            item.itm4Num = file[itemOffset + 38];
            item.itm4Per = file[itemOffset + 39];
            item.itm5ID = BitConverter.ToUInt16(file, itemOffset + 40);
            item.itm5Num = file[itemOffset + 42];
            item.itm5Per = file[itemOffset + 43];
            item.itm6ID = BitConverter.ToUInt16(file, itemOffset + 44);
            item.itm6Num = file[itemOffset + 46];
            item.itm6Per = file[itemOffset + 47];
            item.itm7ID = BitConverter.ToUInt16(file, itemOffset + 48);
            item.itm7Num = file[itemOffset + 50];
            item.itm7Per = file[itemOffset + 51];
            item.itm8ID = BitConverter.ToUInt16(file, itemOffset + 52);
            item.itm8Num = file[itemOffset + 54];
            item.itm8Per = file[itemOffset + 55];
            item.randitmPopMin = file[itemOffset + 56];
            item.randitmPopMax = file[itemOffset + 57];
            item.rsc_paramID = file[itemOffset + 58];
            item.msgdigVisible = file[itemOffset + 59];
            item.menuMapImage = BitConverter.ToUInt16(file, itemOffset + 60);
            item.Digflg = (item.flag & 1) != 0;
            item.DigPopflg = (item.flag & 2) != 0;
            return item;
        }

        public static ma41a_FLD_CollectionPopList Readma41a_FLD_CollectionPopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new ma41a_FLD_CollectionPopList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.gimmickID = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 6);
            item.POP_TIME = BitConverter.ToUInt32(file, itemOffset + 8);
            item.popWeather = file[itemOffset + 12];
            item.CollectionTable = BitConverter.ToUInt16(file, itemOffset + 13);
            item.nameRadius = BitConverter.ToUInt16(file, itemOffset + 15);
            item.rsc_paramID = file[itemOffset + 17];
            item.initWaitTime = BitConverter.ToSingle(file, itemOffset + 18);
            item.initWaitTimeRand = BitConverter.ToSingle(file, itemOffset + 22);
            return item;
        }

        public static Message ReadMessage(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Message();
            item.Id = itemId;
            item.style = BitConverter.ToUInt16(file, itemOffset);
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            return item;
        }

        public static MIN_TT_Crystal ReadMIN_TT_Crystal(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_Crystal();
            item.Id = itemId;
            item.Score = BitConverter.ToUInt16(file, itemOffset);
            item.Res = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            return item;
        }

        public static MIN_TT_Enemy ReadMIN_TT_Enemy(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_Enemy();
            item.Id = itemId;
            item.Name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.MoveType = file[itemOffset + 4];
            item.HitType = file[itemOffset + 5];
            item.HitW = file[itemOffset + 6];
            item.HitH = file[itemOffset + 7];
            item.Atk = file[itemOffset + 8];
            item.Speed = BitConverter.ToUInt16(file, itemOffset + 9);
            item.Range = BitConverter.ToUInt16(file, itemOffset + 11);
            item.Search = BitConverter.ToUInt16(file, itemOffset + 13);
            item.ActSpd = BitConverter.ToUInt16(file, itemOffset + 15);
            item.Hp = file[itemOffset + 17];
            item.BackFrm = file[itemOffset + 18];
            item.BackSpd = BitConverter.ToUInt16(file, itemOffset + 19);
            item.Score = BitConverter.ToUInt16(file, itemOffset + 21);
            item.ResID = file[itemOffset + 23];
            return item;
        }

        public static MIN_TT_PC ReadMIN_TT_PC(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_PC();
            item.Id = itemId;
            item.Hp = BitConverter.ToUInt16(file, itemOffset);
            item.HitW = file[itemOffset + 2];
            item.HitH = file[itemOffset + 3];
            item.AtkW = file[itemOffset + 4];
            item.AtkH = file[itemOffset + 5];
            item.SpdU = BitConverter.ToUInt16(file, itemOffset + 6);
            item.SpdLR = BitConverter.ToUInt16(file, itemOffset + 8);
            item.SpdD = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static MIN_TT_Stage ReadMIN_TT_Stage(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_Stage();
            item.Id = itemId;
            item.SpdD = BitConverter.ToUInt16(file, itemOffset);
            item.SpdU = BitConverter.ToUInt16(file, itemOffset + 2);
            item.AccU = BitConverter.ToUInt16(file, itemOffset + 4);
            item.MaxU = BitConverter.ToUInt16(file, itemOffset + 6);
            item.Scroll = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Bonus = BitConverter.ToUInt16(file, itemOffset + 10);
            item.StarRate = BitConverter.ToUInt16(file, itemOffset + 12);
            item.BotRate = BitConverter.ToUInt16(file, itemOffset + 14);
            item.BotVal = file[itemOffset + 16];
            item.BonusTime = BitConverter.ToUInt16(file, itemOffset + 17);
            item.UniRate = BitConverter.ToUInt16(file, itemOffset + 19);
            item.EthRate = file[itemOffset + 21];
            item.BonusEntry = file[itemOffset + 22];
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Res = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 25));
            return item;
        }

        public static MIN_TT_Tbox ReadMIN_TT_Tbox(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_Tbox();
            item.Id = itemId;
            item.Type = file[itemOffset];
            item.tdef1 = BitConverter.ToUInt16(file, itemOffset + 1);
            item.cond1 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.tdef2 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.cond2 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.tdef3 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.cond3 = BitConverter.ToUInt16(file, itemOffset + 11);
            item.tdef4 = BitConverter.ToUInt16(file, itemOffset + 13);
            item.cond4 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.tdef5 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.cond5 = BitConverter.ToUInt16(file, itemOffset + 19);
            item.tdef6 = BitConverter.ToUInt16(file, itemOffset + 21);
            item.cond6 = BitConverter.ToUInt16(file, itemOffset + 23);
            item.tdef7 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.cond7 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.tdef8 = BitConverter.ToUInt16(file, itemOffset + 29);
            item.cond8 = BitConverter.ToUInt16(file, itemOffset + 31);
            item.tdef9 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.cond9 = BitConverter.ToUInt16(file, itemOffset + 35);
            item.tdef10 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.cond10 = BitConverter.ToUInt16(file, itemOffset + 39);
            return item;
        }

        public static MIN_TT_Tdef ReadMIN_TT_Tdef(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MIN_TT_Tdef();
            item.Id = itemId;
            item.item1 = BitConverter.ToUInt16(file, itemOffset);
            item.rate1 = file[itemOffset + 2];
            item.item2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.rate2 = file[itemOffset + 5];
            item.item3 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.rate3 = file[itemOffset + 8];
            item.item4 = BitConverter.ToUInt16(file, itemOffset + 9);
            item.rate4 = file[itemOffset + 11];
            item.item5 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.rate5 = file[itemOffset + 14];
            item.item6 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.rate6 = file[itemOffset + 17];
            item.item7 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.rate7 = file[itemOffset + 20];
            item.item8 = BitConverter.ToUInt16(file, itemOffset + 21);
            item.rate8 = file[itemOffset + 23];
            item.item9 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.rate9 = file[itemOffset + 26];
            item.item10 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.rate10 = file[itemOffset + 29];
            item.item11 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.rate11 = file[itemOffset + 32];
            item.item12 = BitConverter.ToUInt16(file, itemOffset + 33);
            item.rate12 = file[itemOffset + 35];
            return item;
        }

        public static MNU_AnnouncePage ReadMNU_AnnouncePage(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_AnnouncePage();
            item.Id = itemId;
            item.title = BitConverter.ToUInt16(file, itemOffset);
            item.summary = BitConverter.ToUInt16(file, itemOffset + 2);
            item.image = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static MNU_AnnounceSchedule ReadMNU_AnnounceSchedule(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_AnnounceSchedule();
            item.Id = itemId;
            item.title = BitConverter.ToUInt16(file, itemOffset);
            item.summary = BitConverter.ToUInt16(file, itemOffset + 2);
            item.schedule = BitConverter.ToUInt16(file, itemOffset + 4);
            item.available = file[itemOffset + 6];
            item.@new = file[itemOffset + 7];
            item.order = file[itemOffset + 8];
            return item;
        }

        public static MNU_BladeCreate ReadMNU_BladeCreate(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_BladeCreate();
            item.Id = itemId;
            item.limited_item = BitConverter.ToUInt16(file, itemOffset);
            item.after_pt_in = file[itemOffset + 2];
            return item;
        }

        public static MNU_BlCoolTimeLv ReadMNU_BlCoolTimeLv(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_BlCoolTimeLv();
            item.Id = itemId;
            item.value = BitConverter.ToUInt32(file, itemOffset);
            return item;
        }

        public static MNU_BlImageID ReadMNU_BlImageID(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_BlImageID();
            item.Id = itemId;
            item.icon_id = BitConverter.ToUInt16(file, itemOffset);
            item.offs_x = BitConverter.ToInt16(file, itemOffset + 2);
            item.offs_y = BitConverter.ToInt16(file, itemOffset + 4);
            item.scale = BitConverter.ToSingle(file, itemOffset + 6);
            item.offs_x2 = BitConverter.ToInt16(file, itemOffset + 10);
            item.offs_y2 = BitConverter.ToInt16(file, itemOffset + 12);
            item.scale2 = BitConverter.ToSingle(file, itemOffset + 14);
            item.offs_x3 = BitConverter.ToInt16(file, itemOffset + 18);
            item.offs_y3 = BitConverter.ToInt16(file, itemOffset + 20);
            item.scale3 = BitConverter.ToSingle(file, itemOffset + 22);
            item.offs_x4 = BitConverter.ToInt16(file, itemOffset + 26);
            item.offs_y4 = BitConverter.ToInt16(file, itemOffset + 28);
            item.scale4 = BitConverter.ToSingle(file, itemOffset + 30);
            item.offs_x5 = BitConverter.ToInt16(file, itemOffset + 34);
            item.offs_y5 = BitConverter.ToInt16(file, itemOffset + 36);
            item.scale5 = BitConverter.ToSingle(file, itemOffset + 38);
            return item;
        }

        public static MNU_BtnChallenge2 ReadMNU_BtnChallenge2(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_BtnChallenge2();
            item.Id = itemId;
            item.Speed = file[itemOffset];
            item.Wait = BitConverter.ToUInt16(file, itemOffset + 1);
            item.Type = file[itemOffset + 3];
            item.Start1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Hit1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.End1 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.Param1 = file[itemOffset + 10];
            item.BtnType1 = file[itemOffset + 11];
            item.Point1 = file[itemOffset + 12];
            item.Start2 = BitConverter.ToUInt16(file, itemOffset + 13);
            item.Hit2 = BitConverter.ToUInt16(file, itemOffset + 15);
            item.End2 = BitConverter.ToUInt16(file, itemOffset + 17);
            item.Param2 = file[itemOffset + 19];
            item.BtnType2 = file[itemOffset + 20];
            item.Point2 = file[itemOffset + 21];
            item.Start3 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Hit3 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.End3 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.Param3 = file[itemOffset + 28];
            item.BtnType3 = file[itemOffset + 29];
            item.Point3 = file[itemOffset + 30];
            return item;
        }

        public static MNU_BtnChallengeSeq ReadMNU_BtnChallengeSeq(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_BtnChallengeSeq();
            item.Id = itemId;
            item.challenge01 = BitConverter.ToUInt16(file, itemOffset);
            item.challenge02 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.challenge03 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.challenge04 = file[itemOffset + 6];
            item.challenge05 = BitConverter.ToUInt16(file, itemOffset + 7);
            return item;
        }

        public static MNU_CampCraft ReadMNU_CampCraft(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_CampCraft();
            item.Id = itemId;
            item.driver_id = BitConverter.ToUInt16(file, itemOffset);
            item.shop_id = BitConverter.ToUInt16(file, itemOffset + 2);
            item.summary_msg = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static MNU_ChallengeParam ReadMNU_ChallengeParam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ChallengeParam();
            item.Id = itemId;
            item.InputType = file[itemOffset];
            item.PushRange = BitConverter.ToUInt16(file, itemOffset + 1);
            item.PushSweetRange = BitConverter.ToUInt16(file, itemOffset + 3);
            item.MashingCount = file[itemOffset + 5];
            item.MashingTime = BitConverter.ToUInt16(file, itemOffset + 6);
            item.PushSweetFrame = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static MNU_ChallengeResult ReadMNU_ChallengeResult(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ChallengeResult();
            item.Id = itemId;
            item.Point = file[itemOffset];
            item.Text = BitConverter.ToUInt32(file, itemOffset + 1);
            return item;
        }

        public static MNU_CharOrder ReadMNU_CharOrder(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_CharOrder();
            item.Id = itemId;
            item.layer = BitConverter.ToUInt16(file, itemOffset);
            item.useCond = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_CmnJog ReadMNU_CmnJog(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_CmnJog();
            item.Id = itemId;
            item.angle_range = BitConverter.ToUInt16(file, itemOffset);
            item.start_angle = BitConverter.ToUInt16(file, itemOffset + 2);
            item.def_select = file[itemOffset + 4];
            item.theme_col = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 5));
            item.item_sheet = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 9));
            return item;
        }

        public static MNU_CmnList ReadMNU_CmnList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_CmnList();
            item.Id = itemId;
            for (int i = 0, offset = itemOffset; i < 9; i++, offset += 2)
            {
                item.item[i] = BitConverter.ToUInt16(file, offset);
            }
            return item;
        }

        public static MNU_CmnWindow ReadMNU_CmnWindow(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_CmnWindow();
            item.Id = itemId;
            item.type = file[itemOffset];
            item.select = file[itemOffset + 1];
            item.text = BitConverter.ToUInt16(file, itemOffset + 2);
            item.title = BitConverter.ToUInt16(file, itemOffset + 4);
            item.select_ok_txt = BitConverter.ToUInt16(file, itemOffset + 6);
            item.select_cancel_txt = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static MNU_ColorList ReadMNU_ColorList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ColorList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.col_r = file[itemOffset + 4];
            item.col_g = file[itemOffset + 5];
            item.col_b = file[itemOffset + 6];
            return item;
        }

        public static MNU_Condition ReadMNU_Condition(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Condition();
            item.Id = itemId;
            item.cond = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_DamageValue ReadMNU_DamageValue(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_DamageValue();
            item.Id = itemId;
            item.value = BitConverter.ToSingle(file, itemOffset);
            return item;
        }

        public static MNU_DlcGift ReadMNU_DlcGift(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_DlcGift();
            item.Id = itemId;
            item.releasecount = file[itemOffset];
            item.title = BitConverter.ToUInt16(file, itemOffset + 1);
            item.condition = BitConverter.ToUInt16(file, itemOffset + 3);
            item.category = file[itemOffset + 5];
            item.item_id = BitConverter.ToUInt16(file, itemOffset + 6);
            item.value = BitConverter.ToUInt16(file, itemOffset + 8);
            item.disp_item_info = file[itemOffset + 10];
            item.getflag = BitConverter.ToUInt16(file, itemOffset + 11);
            return item;
        }

        public static MNU_EventTheater ReadMNU_EventTheater(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_EventTheater();
            item.Id = itemId;
            item.title = BitConverter.ToUInt16(file, itemOffset);
            item.event_id = BitConverter.ToUInt16(file, itemOffset + 2);
            item.condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.thumbnail = BitConverter.ToUInt16(file, itemOffset + 6);
            item.category = file[itemOffset + 8];
            item.chapter = file[itemOffset + 9];
            item.maincast = file[itemOffset + 10];
            item.blade_id = BitConverter.ToUInt16(file, itemOffset + 11);
            item.flag_index = BitConverter.ToUInt16(file, itemOffset + 13);
            item.map_id = BitConverter.ToUInt16(file, itemOffset + 15);
            item.fixed_time = file[itemOffset + 17];
            item.in_dlc = file[itemOffset + 18];
            item.fixed_weather = BitConverter.ToUInt16(file, itemOffset + 19);
            item.vandamme_in = file[itemOffset + 21];
            item.melef_in = file[itemOffset + 22];
            item.seeg_in = file[itemOffset + 23];
            item.rex_awaking = file[itemOffset + 24];
            return item;
        }

        public static MNU_FacePatternList ReadMNU_FacePatternList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_FacePatternList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.image_no = file[itemOffset + 4];
            return item;
        }

        public static MNU_Filename ReadMNU_Filename(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Filename();
            item.Id = itemId;
            item.filename = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static MNU_FontSet01 ReadMNU_FontSet01(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_FontSet01();
            item.Id = itemId;
            item.type = file[itemOffset];
            item.resource = BitConverter.ToUInt32(file, itemOffset + 1);
            item.image_type = file[itemOffset + 5];
            return item;
        }

        public static MNU_FSMenu ReadMNU_FSMenu(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_FSMenu();
            item.Id = itemId;
            item.next_jog = BitConverter.ToUInt16(file, itemOffset);
            item.layer_id = BitConverter.ToUInt16(file, itemOffset + 2);
            item.icon = BitConverter.ToUInt16(file, itemOffset + 4);
            item.text = BitConverter.ToUInt16(file, itemOffset + 6);
            item.desc = BitConverter.ToUInt16(file, itemOffset + 8);
            return item;
        }

        public static MNU_HanaMode ReadMNU_HanaMode(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_HanaMode();
            item.Id = itemId;
            item.JS_SET = BitConverter.ToUInt16(file, itemOffset);
            item.JK_SET = BitConverter.ToUInt16(file, itemOffset + 2);
            item.JD_SET = BitConverter.ToUInt16(file, itemOffset + 4);
            item.JS_EXPAND = BitConverter.ToUInt16(file, itemOffset + 6);
            item.JK_EXPAND = BitConverter.ToUInt16(file, itemOffset + 8);
            item.JD_EXPAND = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ITEM_MAKE = BitConverter.ToUInt16(file, itemOffset + 12);
            item.BASE_SET = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static MNU_HanaSet ReadMNU_HanaSet(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_HanaSet();
            item.Id = itemId;
            item.name = BitConverter.ToUInt16(file, itemOffset);
            item.icon = BitConverter.ToUInt16(file, itemOffset + 2);
            item.slotIcon = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static MNU_IconList ReadMNU_IconList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_IconList();
            item.Id = itemId;
            item.icon_index = file[itemOffset];
            return item;
        }

        public static MNU_InputAct ReadMNU_InputAct(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_InputAct();
            item.Id = itemId;
            item.act_id = file[itemOffset];
            item.text = BitConverter.ToUInt16(file, itemOffset + 1);
            item.text2 = BitConverter.ToUInt16(file, itemOffset + 3);
            item.text3 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.text4 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.repeat = file[itemOffset + 9];
            return item;
        }

        public static MNU_InputPad ReadMNU_InputPad(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_InputPad();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.pad_select = (sbyte)file[itemOffset + 4];
            item.select_text = BitConverter.ToUInt16(file, itemOffset + 5);
            item.loop = file[itemOffset + 7];
            item.repeat = file[itemOffset + 8];
            item.shift = file[itemOffset + 9];
            item.key_sort = file[itemOffset + 10];
            item.pad_decide = file[itemOffset + 11];
            item.pad_cancel = file[itemOffset + 12];
            item.pad_A = file[itemOffset + 13];
            item.pad_B = file[itemOffset + 14];
            item.pad_X = file[itemOffset + 15];
            item.pad_Y = file[itemOffset + 16];
            item.pad_L1 = file[itemOffset + 17];
            item.pad_L2 = file[itemOffset + 18];
            item.pad_L3 = file[itemOffset + 19];
            item.pad_R1 = file[itemOffset + 20];
            item.pad_R2 = file[itemOffset + 21];
            item.pad_R3 = file[itemOffset + 22];
            item.pad_START = file[itemOffset + 23];
            item.pad_SELECT = file[itemOffset + 24];
            item.pad_UP = file[itemOffset + 25];
            item.pad_DOWN = file[itemOffset + 26];
            item.pad_RIGHT = file[itemOffset + 27];
            item.pad_LEFT = file[itemOffset + 28];
            item.pad_LS_UP = file[itemOffset + 29];
            item.pad_LS_DOWN = file[itemOffset + 30];
            item.pad_LS_RIGHT = file[itemOffset + 31];
            item.pad_LS_LEFT = file[itemOffset + 32];
            item.pad_RS_UP = file[itemOffset + 33];
            item.pad_RS_DOWN = file[itemOffset + 34];
            item.pad_RS_RIGHT = file[itemOffset + 35];
            item.pad_RS_LEFT = file[itemOffset + 36];
            return item;
        }

        public static MNU_InputPointer ReadMNU_InputPointer(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_InputPointer();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.pointer_speed = (sbyte)file[itemOffset + 4];
            item.snap = file[itemOffset + 5];
            item.select_text = BitConverter.ToUInt16(file, itemOffset + 6);
            item.key_sort = file[itemOffset + 8];
            item.pad_decide = (sbyte)file[itemOffset + 9];
            item.pad_cancel = (sbyte)file[itemOffset + 10];
            item.pad_A = (sbyte)file[itemOffset + 11];
            item.pad_B = (sbyte)file[itemOffset + 12];
            item.pad_X = (sbyte)file[itemOffset + 13];
            item.pad_Y = (sbyte)file[itemOffset + 14];
            item.pad_L1 = (sbyte)file[itemOffset + 15];
            item.pad_L2 = (sbyte)file[itemOffset + 16];
            item.pad_R1 = (sbyte)file[itemOffset + 17];
            item.pad_R2 = (sbyte)file[itemOffset + 18];
            item.pad_START = (sbyte)file[itemOffset + 19];
            item.pad_SELECT = (sbyte)file[itemOffset + 20];
            item.pad_UP = (sbyte)file[itemOffset + 21];
            item.pad_DOWN = (sbyte)file[itemOffset + 22];
            item.pad_RIGHT = (sbyte)file[itemOffset + 23];
            item.pad_LEFT = (sbyte)file[itemOffset + 24];
            return item;
        }

        public static MNU_InputWheel ReadMNU_InputWheel(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_InputWheel();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.start_angle = BitConverter.ToUInt16(file, itemOffset + 4);
            item.angle_range = BitConverter.ToUInt16(file, itemOffset + 6);
            item.select_dir = file[itemOffset + 8];
            item.pad_decide = (sbyte)file[itemOffset + 9];
            item.pad_cancel = (sbyte)file[itemOffset + 10];
            item.pad_A = (sbyte)file[itemOffset + 11];
            item.pad_B = (sbyte)file[itemOffset + 12];
            item.pad_X = (sbyte)file[itemOffset + 13];
            item.pad_Y = (sbyte)file[itemOffset + 14];
            item.pad_L1 = (sbyte)file[itemOffset + 15];
            item.pad_L2 = (sbyte)file[itemOffset + 16];
            item.pad_R1 = (sbyte)file[itemOffset + 17];
            item.pad_R2 = (sbyte)file[itemOffset + 18];
            item.pad_START = (sbyte)file[itemOffset + 19];
            item.pad_SELECT = (sbyte)file[itemOffset + 20];
            return item;
        }

        public static MNU_jog_txt ReadMNU_jog_txt(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_jog_txt();
            item.Id = itemId;
            item.fs_menu_id = BitConverter.ToUInt16(file, itemOffset);
            item.txt = BitConverter.ToUInt16(file, itemOffset + 2);
            item.lock_flag = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static MNU_KeyOrder ReadMNU_KeyOrder(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_KeyOrder();
            item.Id = itemId;
            item.key = BitConverter.ToUInt16(file, itemOffset);
            item.order = BitConverter.ToUInt16(file, itemOffset + 2);
            item.order2 = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static MNU_Layer ReadMNU_Layer(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Layer();
            item.Id = itemId;
            item.group = file[itemOffset];
            item.sheet01 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 1));
            item.prio01 = file[itemOffset + 5];
            item.sheet02 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.prio02 = file[itemOffset + 10];
            item.sheet03 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 11));
            item.prio03 = file[itemOffset + 15];
            item.sheet04 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.prio04 = file[itemOffset + 20];
            item.sheet05 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 21));
            item.prio05 = file[itemOffset + 25];
            item.sheet06 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 26));
            item.prio06 = file[itemOffset + 30];
            item.hud_group = file[itemOffset + 31];
            return item;
        }

        public static MNU_MainOrder ReadMNU_MainOrder(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MainOrder();
            item.Id = itemId;
            item.layer = BitConverter.ToUInt16(file, itemOffset);
            item.useCond = BitConverter.ToUInt16(file, itemOffset + 2);
            item.guide = BitConverter.ToUInt16(file, itemOffset + 4);
            item.title = BitConverter.ToUInt16(file, itemOffset + 6);
            item.titleIcon = BitConverter.ToUInt16(file, itemOffset + 8);
            item.subTitle = BitConverter.ToUInt16(file, itemOffset + 10);
            item.resName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            return item;
        }

        public static MNU_MapGroup ReadMNU_MapGroup(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MapGroup();
            item.Id = itemId;
            item.include_map = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.disp_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.under_water = file[itemOffset + 6];
            item.condition = BitConverter.ToUInt16(file, itemOffset + 7);
            return item;
        }

        public static MNU_MapInfo ReadMNU_MapInfo(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MapInfo();
            item.Id = itemId;
            item.level_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.disp_name = BitConverter.ToUInt16(file, itemOffset + 4);
            item.under_water = file[itemOffset + 6];
            item.level_priority = BitConverter.ToUInt16(file, itemOffset + 7);
            item.condition = BitConverter.ToUInt16(file, itemOffset + 9);
            item.level_name2 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 11));
            return item;
        }

        public static MNU_ModelView ReadMNU_ModelView(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ModelView();
            item.Id = itemId;
            item.camera_file = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.efp_file = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.obj_model01 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.obj_model02 = BitConverter.ToUInt16(file, itemOffset + 10);
            return item;
        }

        public static MNU_Msg_SubContents ReadMNU_Msg_SubContents(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Msg_SubContents();
            item.Id = itemId;
            item.name = BitConverter.ToUInt16(file, itemOffset);
            item.caption = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_MsgChapterEnd ReadMNU_MsgChapterEnd(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MsgChapterEnd();
            item.Id = itemId;
            item.index = BitConverter.ToUInt16(file, itemOffset);
            item.title = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_MsgGiftFilter ReadMNU_MsgGiftFilter(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MsgGiftFilter();
            item.Id = itemId;
            item.name = BitConverter.ToUInt16(file, itemOffset);
            item.number = file[itemOffset + 2];
            return item;
        }

        public static MNU_MsgPopupTitle ReadMNU_MsgPopupTitle(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MsgPopupTitle();
            item.Id = itemId;
            item.name = BitConverter.ToUInt16(file, itemOffset);
            item.color = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.name2 = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static MNU_MsgQListTab ReadMNU_MsgQListTab(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_MsgQListTab();
            item.Id = itemId;
            item.item01 = BitConverter.ToUInt16(file, itemOffset);
            item.item02 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.item03 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.item04 = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static MNU_Name ReadMNU_Name(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Name();
            item.Id = itemId;
            item.name = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_OffsetList ReadMNU_OffsetList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_OffsetList();
            item.Id = itemId;
            item.offs_x = BitConverter.ToSingle(file, itemOffset);
            item.offs_y = BitConverter.ToSingle(file, itemOffset + 4);
            item.offs_z = BitConverter.ToSingle(file, itemOffset + 8);
            item.bone_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            return item;
        }

        public static MNU_OptionCamera ReadMNU_OptionCamera(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_OptionCamera();
            item.Id = itemId;
            item.name_id = BitConverter.ToUInt16(file, itemOffset);
            item.cap_id = BitConverter.ToUInt16(file, itemOffset + 2);
            item.setting_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.default_level = file[itemOffset + 8];
            return item;
        }

        public static MNU_OptionDisp ReadMNU_OptionDisp(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_OptionDisp();
            item.Id = itemId;
            item.name_id = BitConverter.ToUInt16(file, itemOffset);
            item.cap_id = BitConverter.ToUInt16(file, itemOffset + 2);
            item.max_level = file[itemOffset + 4];
            item.default_level = file[itemOffset + 5];
            return item;
        }

        public static MNU_OptionGameDif ReadMNU_OptionGameDif(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_OptionGameDif();
            item.Id = itemId;
            item.name_id = BitConverter.ToUInt16(file, itemOffset);
            item.cap_id = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_ResFont ReadMNU_ResFont(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ResFont();
            item.Id = itemId;
            item.file = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            return item;
        }

        public static MNU_ScriptList ReadMNU_ScriptList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ScriptList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.script = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            return item;
        }

        public static MNU_ShopCategoryName ReadMNU_ShopCategoryName(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopCategoryName();
            item.Id = itemId;
            item.icon_id = BitConverter.ToUInt16(file, itemOffset);
            item.name = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_ShopChange ReadMNU_ShopChange(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopChange();
            item.Id = itemId;
            item.DefTaskSet1 = BitConverter.ToUInt16(file, itemOffset);
            item.DefTaskSet2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DefTaskSet3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DefTaskSet4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.DefTaskSet5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.DefTaskSet6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.DefTaskSet7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.DefTaskSet8 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.AddTaskSet1 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.AddCondition1 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.AddTaskSet2 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.AddCondition2 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.AddTaskSet3 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.AddCondition3 = BitConverter.ToUInt16(file, itemOffset + 26);
            item.AddTaskSet4 = BitConverter.ToUInt16(file, itemOffset + 28);
            item.AddCondition4 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.AddTaskSet5 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.AddCondition5 = BitConverter.ToUInt16(file, itemOffset + 34);
            item.AddTaskSet6 = BitConverter.ToUInt16(file, itemOffset + 36);
            item.AddCondition6 = BitConverter.ToUInt16(file, itemOffset + 38);
            item.AddTaskSet7 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.AddCondition7 = BitConverter.ToUInt16(file, itemOffset + 42);
            item.AddTaskSet8 = BitConverter.ToUInt16(file, itemOffset + 44);
            item.AddCondition8 = BitConverter.ToUInt16(file, itemOffset + 46);
            item.LinkQuestTask = BitConverter.ToUInt16(file, itemOffset + 48);
            item.LinkQuestTaskID = BitConverter.ToUInt16(file, itemOffset + 50);
            item.UnitText = BitConverter.ToUInt16(file, itemOffset + 52);
            return item;
        }

        public static MNU_ShopChangeTask ReadMNU_ShopChangeTask(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopChangeTask();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.SetItem1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.SetNumber1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.SetItem2 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.SetNumber2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.SetItem3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.SetNumber3 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.SetItem4 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.SetNumber4 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.SetItem5 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.SetNumber5 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.HideReward = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Reward = BitConverter.ToUInt16(file, itemOffset + 24);
            item.HideRewardFlag = BitConverter.ToUInt16(file, itemOffset + 26);
            item.AddFlagValue = file[itemOffset + 28];
            return item;
        }

        public static MNU_ShopInn ReadMNU_ShopInn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopInn();
            item.Id = itemId;
            item.Price = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_ShopList ReadMNU_ShopList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopList();
            item.Id = itemId;
            item.Name = BitConverter.ToUInt16(file, itemOffset);
            item.ShopIcon = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ShopType = file[itemOffset + 4];
            item.TableID = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Discount1 = file[itemOffset + 7];
            item.Discount2 = file[itemOffset + 8];
            item.Discount3 = file[itemOffset + 9];
            item.Discount4 = file[itemOffset + 10];
            item.Discount5 = file[itemOffset + 11];
            return item;
        }

        public static MNU_ShopNormal ReadMNU_ShopNormal(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_ShopNormal();
            item.Id = itemId;
            item.DefItem1 = BitConverter.ToUInt16(file, itemOffset);
            item.DefItem2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.DefItem3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.DefItem4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.DefItem5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.DefItem6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.DefItem7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.DefItem8 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.DefItem9 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.DefItem10 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.Addtem1 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.AddCondition1 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.PrivilegeCheck1 = file[itemOffset + 24];
            item.Addtem2 = BitConverter.ToUInt16(file, itemOffset + 25);
            item.AddCondition2 = BitConverter.ToUInt16(file, itemOffset + 27);
            item.PrivilegeCheck2 = file[itemOffset + 29];
            item.Addtem3 = BitConverter.ToUInt16(file, itemOffset + 30);
            item.AddCondition3 = BitConverter.ToUInt16(file, itemOffset + 32);
            item.PrivilegeCheck3 = file[itemOffset + 34];
            item.Addtem4 = BitConverter.ToUInt16(file, itemOffset + 35);
            item.AddCondition4 = BitConverter.ToUInt16(file, itemOffset + 37);
            item.PrivilegeCheck4 = file[itemOffset + 39];
            item.Addtem5 = BitConverter.ToUInt16(file, itemOffset + 40);
            item.AddCondition5 = BitConverter.ToUInt16(file, itemOffset + 42);
            item.PrivilegeCheck5 = file[itemOffset + 44];
            item.PrivilegeFlag = BitConverter.ToUInt16(file, itemOffset + 45);
            item.PrivilegeItem = BitConverter.ToUInt16(file, itemOffset + 47);
            return item;
        }

        public static MNU_SortBuff ReadMNU_SortBuff(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SortBuff();
            item.Id = itemId;
            item.buff1 = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_SortEnhance ReadMNU_SortEnhance(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SortEnhance();
            item.Id = itemId;
            item.enhance1 = BitConverter.ToUInt16(file, itemOffset);
            item.enhance2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.enhance3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.enhance4 = BitConverter.ToUInt16(file, itemOffset + 6);
            return item;
        }

        public static MNU_SortFieldSkill ReadMNU_SortFieldSkill(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SortFieldSkill();
            item.Id = itemId;
            item.fs1 = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_SortRole ReadMNU_SortRole(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SortRole();
            item.Id = itemId;
            item.role1 = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_SortTable ReadMNU_SortTable(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SortTable();
            item.Id = itemId;
            item.sort_type1 = BitConverter.ToUInt16(file, itemOffset);
            item.sort_type2 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.sort_type3 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.sort_type4 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.sort_type5 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.sort_type6 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.sort_type7 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.sort_type8 = BitConverter.ToUInt16(file, itemOffset + 14);
            item.sort_type9 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.sort_type10 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.sort_type11 = BitConverter.ToUInt16(file, itemOffset + 20);
            item.sort_type12 = BitConverter.ToUInt16(file, itemOffset + 22);
            item.sort_type13 = BitConverter.ToUInt16(file, itemOffset + 24);
            item.sort_type14 = BitConverter.ToUInt16(file, itemOffset + 26);
            return item;
        }

        public static MNU_SoundBgm ReadMNU_SoundBgm(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SoundBgm();
            item.Id = itemId;
            item.resource = BitConverter.ToUInt16(file, itemOffset);
            item.time = BitConverter.ToSingle(file, itemOffset + 2);
            return item;
        }

        public static MNU_SoundSe ReadMNU_SoundSe(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SoundSe();
            item.Id = itemId;
            item.resource_id = BitConverter.ToUInt16(file, itemOffset);
            return item;
        }

        public static MNU_SpecialShop ReadMNU_SpecialShop(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_SpecialShop();
            item.Id = itemId;
            item.shop_id = BitConverter.ToUInt16(file, itemOffset);
            item.scenario_flag = BitConverter.ToUInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_Stream_full_bl ReadMNU_Stream_full_bl(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Stream_full_bl();
            item.Id = itemId;
            item.filename = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.filename_2nd = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            return item;
        }

        public static MNU_TextProperty ReadMNU_TextProperty(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_TextProperty();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.col_r = file[itemOffset + 4];
            item.col_g = file[itemOffset + 5];
            item.col_b = file[itemOffset + 6];
            item.Bold = file[itemOffset + 7];
            return item;
        }

        public static MNU_Tutorial ReadMNU_Tutorial(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_Tutorial();
            item.Id = itemId;
            item.script_file = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.param1 = BitConverter.ToUInt32(file, itemOffset + 4);
            return item;
        }

        public static MNU_txt ReadMNU_txt(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_txt();
            item.Id = itemId;
            item.obj_name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.text_id = BitConverter.ToUInt32(file, itemOffset + 4);
            return item;
        }

        public static MNU_UioReplace ReadMNU_UioReplace(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_UioReplace();
            item.Id = itemId;
            item.file = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.replace01 = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            return item;
        }

        public static MNU_WorldMap ReadMNU_WorldMap(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_WorldMap();
            item.Id = itemId;
            item.posX = BitConverter.ToInt16(file, itemOffset);
            item.posY = BitConverter.ToInt16(file, itemOffset + 2);
            return item;
        }

        public static MNU_WorldMapCond ReadMNU_WorldMapCond(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new MNU_WorldMapCond();
            item.Id = itemId;
            item.mapId = BitConverter.ToUInt16(file, itemOffset);
            item.cond1 = BitConverter.ToUInt16(file, itemOffset + 2);
            item.pos1 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.cond2 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.pos2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.cond3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.pos3 = BitConverter.ToUInt16(file, itemOffset + 12);
            item.enter = BitConverter.ToUInt16(file, itemOffset + 14);
            return item;
        }

        public static RSC_AreaBgmList ReadRSC_AreaBgmList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_AreaBgmList();
            item.Id = itemId;
            item.name = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.bgmCondition = BitConverter.ToUInt16(file, itemOffset + 4);
            return item;
        }

        public static RSC_BgmCondition ReadRSC_BgmCondition(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_BgmCondition();
            item.Id = itemId;
            item.ConditionA = BitConverter.ToUInt16(file, itemOffset);
            item.BgmIDA = BitConverter.ToUInt16(file, itemOffset + 2);
            item.ConditionB = BitConverter.ToUInt16(file, itemOffset + 4);
            item.BgmIDB = BitConverter.ToUInt16(file, itemOffset + 6);
            item.ConditionC = BitConverter.ToUInt16(file, itemOffset + 8);
            item.BgmIDC = BitConverter.ToUInt16(file, itemOffset + 10);
            item.ConditionD = BitConverter.ToUInt16(file, itemOffset + 12);
            item.BgmIDD = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Priority = file[itemOffset + 16];
            return item;
        }

        public static RSC_dropitemList ReadRSC_dropitemList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_dropitemList();
            item.Id = itemId;
            item.mdo = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.paramid0 = BitConverter.ToUInt16(file, itemOffset + 4);
            item.paramid1 = BitConverter.ToUInt16(file, itemOffset + 6);
            item.paramid2 = BitConverter.ToUInt16(file, itemOffset + 8);
            item.paramid3 = BitConverter.ToUInt16(file, itemOffset + 10);
            item.dropSE = BitConverter.ToUInt16(file, itemOffset + 12);
            item.getdropSE = BitConverter.ToUInt16(file, itemOffset + 14);
            item.limitType = file[itemOffset + 16];
            return item;
        }

        public static RSC_dropitemParam ReadRSC_dropitemParam(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_dropitemParam();
            item.Id = itemId;
            item.height = BitConverter.ToSingle(file, itemOffset);
            item.heightRand = BitConverter.ToSingle(file, itemOffset + 4);
            item.distance = BitConverter.ToSingle(file, itemOffset + 8);
            item.distanceRand = BitConverter.ToSingle(file, itemOffset + 12);
            item.time = BitConverter.ToSingle(file, itemOffset + 16);
            item.speedAtte = BitConverter.ToSingle(file, itemOffset + 20);
            item.rotYRand = BitConverter.ToSingle(file, itemOffset + 24);
            item.lifeTime = BitConverter.ToSingle(file, itemOffset + 28);
            item.flashTime = BitConverter.ToSingle(file, itemOffset + 32);
            item.flashInterval1 = BitConverter.ToSingle(file, itemOffset + 36);
            item.flashInterval2 = BitConverter.ToSingle(file, itemOffset + 40);
            item.vanishTime1 = BitConverter.ToSingle(file, itemOffset + 44);
            item.vanishTime2 = BitConverter.ToSingle(file, itemOffset + 48);
            item.radius = BitConverter.ToSingle(file, itemOffset + 52);
            item.initHeight = BitConverter.ToSingle(file, itemOffset + 56);
            item.startScale = BitConverter.ToSingle(file, itemOffset + 60);
            item.endScale = BitConverter.ToSingle(file, itemOffset + 64);
            item.scaleTime = BitConverter.ToSingle(file, itemOffset + 68);
            item.isSpin = file[itemOffset + 72];
            item.spinSpeed = BitConverter.ToSingle(file, itemOffset + 73);
            item.startSpinBound = file[itemOffset + 77];
            item.startSpinTime = BitConverter.ToSingle(file, itemOffset + 78);
            item.boundNum = file[itemOffset + 82];
            return item;
        }

        public static RSC_En ReadRSC_En(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_En();
            item.Id = itemId;
            item.DebugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.TypeFamily = file[itemOffset + 4];
            item.TypeGenus = file[itemOffset + 5];
            item.ActType = file[itemOffset + 6];
            item.FlyHeight = BitConverter.ToInt16(file, itemOffset + 7);
            item.FldMoveType = file[itemOffset + 9];
            item.Material = file[itemOffset + 10];
            item.ProxyID = file[itemOffset + 11];
            item.EnRadius = file[itemOffset + 12];
            item.EnRadius2 = file[itemOffset + 13];
            item.ChestHeight = BitConverter.ToUInt16(file, itemOffset + 14);
            item.ChestHeight2 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.BallRadius = BitConverter.ToSingle(file, itemOffset + 18);
            item.BallHeight = BitConverter.ToSingle(file, itemOffset + 22);
            item.CharColli = BitConverter.ToSingle(file, itemOffset + 26);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 30);
            item.EyeRot = file[itemOffset + 32];
            item.SearchBaseBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 33));
            item.CenterBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 37));
            item.CamBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 41));
            item.FrontAngle = file[itemOffset + 45];
            item.TurnAngleSmall = file[itemOffset + 46];
            item.TurnAngleBig = file[itemOffset + 47];
            item.Unduration = file[itemOffset + 48];
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 49));
            item.ChrFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 53));
            item.ActFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 57));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 61));
            item.RefMotion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 65));
            item.EffectPack = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 69));
            item.LoopEffect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 73));
            item.SePack = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 77));
            item.Voice = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 81));
            item.VoiceEx = file[itemOffset + 85];
            item.ClipEvent = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 86));
            item.Comp_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 90));
            item.Comp_Se = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 94));
            item.Comp_Vo = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 98));
            item.Flag = BitConverter.ToUInt16(file, itemOffset + 102);
            item.WeaponNum1 = BitConverter.ToUInt16(file, itemOffset + 104);
            item.WeaponNum2 = BitConverter.ToUInt16(file, itemOffset + 106);
            item.WeaponNum3 = BitConverter.ToUInt16(file, itemOffset + 108);
            item.WeaponNum4 = BitConverter.ToUInt16(file, itemOffset + 110);
            item.WeaponNum5 = BitConverter.ToUInt16(file, itemOffset + 112);
            item.MemorySlot = file[itemOffset + 114];
            item.Race = file[itemOffset + 115];
            item.DrType = file[itemOffset + 116];
            item.GoldDivideRev = (sbyte)file[itemOffset + 117];
            item.FootStep = file[itemOffset + 118];
            item.FootStepEffect = file[itemOffset + 119];
            item.SearchBoneRX = BitConverter.ToInt16(file, itemOffset + 120);
            item.SearchBoneRY = BitConverter.ToInt16(file, itemOffset + 122);
            item.SearchBoneRZ = BitConverter.ToInt16(file, itemOffset + 124);
            item.RotateX = (sbyte)file[itemOffset + 126];
            item.RotateY = (sbyte)file[itemOffset + 127];
            item.RotateZ = (sbyte)file[itemOffset + 128];
            item.RotateDeg = (sbyte)file[itemOffset + 129];
            item.RotateBone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 130));
            item.RotEffScale = BitConverter.ToUInt16(file, itemOffset + 134);
            item.ExtraParts1 = file[itemOffset + 136];
            item.ExtraParts2 = file[itemOffset + 137];
            item.ExtraParts3 = file[itemOffset + 138];
            item.ExtraParts4 = file[itemOffset + 139];
            item.DeadSeNum = file[itemOffset + 140];
            item.NoEcSkip = (item.Flag & 1) != 0;
            item.Map = (item.Flag & 2) != 0;
            item.Evt = (item.Flag & 4) != 0;
            item.NoWinVo = (item.Flag & 8) != 0;
            item.Bait = (item.Flag & 16) != 0;
            item.UseSearchBone = (item.Flag & 32) != 0;
            item.NoVanish = (item.Flag & 64) != 0;
            item.NoCamera = (item.Flag & 128) != 0;
            item.WeaponDrawDisp = (item.Flag & 256) != 0;
            item.JoinAll = (item.Flag & 512) != 0;
            item.DeathMotion = (item.Flag & 1024) != 0;
            return item;
        }

        public static RSC_EnGenus ReadRSC_EnGenus(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_EnGenus();
            item.Id = itemId;
            item.NAME = file[itemOffset];
            item.CAPTION = file[itemOffset + 1];
            item.Flag = file[itemOffset + 2];
            item.gimmicktype = (item.Flag & 1) != 0;
            return item;
        }

        public static RSC_EnUnd ReadRSC_EnUnd(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_EnUnd();
            item.Id = itemId;
            item.Flag = file[itemOffset];
            item.UndMinX = (sbyte)file[itemOffset + 1];
            item.UndMaxX = (sbyte)file[itemOffset + 2];
            item.UndMinZ = (sbyte)file[itemOffset + 3];
            item.UndMaxZ = (sbyte)file[itemOffset + 4];
            item.UndDeg = file[itemOffset + 5];
            item.UndX = (item.Flag & 1) != 0;
            item.UndZ = (item.Flag & 2) != 0;
            return item;
        }

        public static RSC_EnWpn ReadRSC_EnWpn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_EnWpn();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Scale = BitConverter.ToUInt16(file, itemOffset + 4);
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.MtpInChara = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.MtpInWpn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 14));
            item.MtpOutChara = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.MtpOutWpn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 22));
            return item;
        }

        public static RSC_GmkSetList ReadRSC_GmkSetList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_GmkSetList();
            item.Id = itemId;
            item.mapId = BitConverter.ToUInt16(file, itemOffset);
            item.enemy = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 2));
            item.enemy_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            item.npc = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            item.npc_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 14));
            item.mapObj = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.mapObj_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 22));
            item.tbox = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 26));
            item.tbox_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 30));
            item.@event = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 34));
            item.event_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 38));
            item.fieldLock = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 42));
            item.fieldLock_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 46));
            item.effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 50));
            item.effect_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 54));
            item.se = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 58));
            item.se_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 62));
            item.mob = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 66));
            item.mob_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 70));
            item.autoTalk = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 74));
            item.autoTalk_ms = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 78));
            item.landmark = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 82));
            item.landmark_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 86));
            item.formPc = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 90));
            item.formPcEv = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 94));
            item.collection = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 98));
            item.collection_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 102));
            item.areaBgm = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 106));
            item.areaBgm_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 110));
            item.areaWeather = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 114));
            item.salvage = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 118));
            item.salvage_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 122));
            item.mapGimmick = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 126));
            item.mapGimmick_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 130));
            item.precious = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 134));
            item.precious_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 138));
            item.grave = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 142));
            item.grave_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 146));
            item.kizunaTalk = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 150));
            item.kizunaTalk_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 154));
            item.jump = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 158));
            item.jump_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 162));
            item.warp = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 166));
            item.warp_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 170));
            item.squad = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 174));
            item.door = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 178));
            item.door_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 182));
            item.elevator = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 186));
            item.elevator_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 190));
            item.mapJump = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 194));
            item.mapJump_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 198));
            item.fieldVolume = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 202));
            item.climbing = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 206));
            item.climbing_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 210));
            item.blade = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 214));
            item.blade_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 218));
            item.dmgGimmick = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 222));
            item.dmgGimmick_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 226));
            item.footPrint = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 230));
            item.footPrint_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 234));
            item.antiBladeArea = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 238));
            item.antiBladeArea_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 242));
            item.tutorial = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 246));
            item.tutorial_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 250));
            item.enemyWave = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 254));
            item.enemyWave_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 258));
            item.battleChallenge = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 262));
            item.battleChallenge_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 266));
            item.campPop = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 270));
            item.campPop_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 274));
            item.sealedStone = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 278));
            item.sealedStone_bdat = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 282));
            return item;
        }

        public static RSC_MapObjList ReadRSC_MapObjList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_MapObjList();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Comp_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.SeEnv = BitConverter.ToUInt16(file, itemOffset + 16);
            item.flag = file[itemOffset + 18];
            item.ExtraParts1 = file[itemOffset + 19];
            item.BigObj = (item.flag & 1) != 0;
            return item;
        }

        public static RSC_MobList ReadRSC_MobList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_MobList();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.AddMotion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Comp_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.CollisionId = BitConverter.ToUInt16(file, itemOffset + 16);
            item.SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 18));
            item.SeEnv = BitConverter.ToUInt16(file, itemOffset + 22);
            item.Race = file[itemOffset + 24];
            item.FootStep = BitConverter.ToUInt16(file, itemOffset + 25);
            item.FootStepEffect = file[itemOffset + 27];
            item.OffsetID = BitConverter.ToUInt16(file, itemOffset + 28);
            item.ExtraParts1 = file[itemOffset + 30];
            item.ExtraParts2 = file[itemOffset + 31];
            item.ExtraParts3 = file[itemOffset + 32];
            item.ExtraParts4 = file[itemOffset + 33];
            item.ExtraParts5 = file[itemOffset + 34];
            item.ExtraParts6 = file[itemOffset + 35];
            return item;
        }

        public static RSC_NpcList ReadRSC_NpcList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_NpcList();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.AddMotion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.EvtRetarget = file[itemOffset + 12];
            item.Comp_Eff = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 13));
            item.CollisionId = BitConverter.ToUInt16(file, itemOffset + 17);
            item.SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 19));
            item.SeEnv = BitConverter.ToUInt16(file, itemOffset + 23);
            item.Race = file[itemOffset + 25];
            item.FootStep = BitConverter.ToUInt16(file, itemOffset + 26);
            item.FootStepEffect = file[itemOffset + 28];
            item.Roots = file[itemOffset + 29];
            item.Gender = file[itemOffset + 30];
            item.Name = BitConverter.ToUInt16(file, itemOffset + 31);
            item.OffsetID = BitConverter.ToUInt16(file, itemOffset + 33);
            item.EyeRot = file[itemOffset + 35];
            item.ExtraParts1 = file[itemOffset + 36];
            item.ExtraParts2 = file[itemOffset + 37];
            item.ExtraParts3 = file[itemOffset + 38];
            item.ExtraParts4 = file[itemOffset + 39];
            item.ExtraParts5 = file[itemOffset + 40];
            item.ExtraParts6 = file[itemOffset + 41];
            item.Scale = BitConverter.ToUInt16(file, itemOffset + 42);
            item.EventAsset = BitConverter.ToUInt16(file, itemOffset + 44);
            item.Job = BitConverter.ToUInt16(file, itemOffset + 46);
            item.HitonowaFlag = BitConverter.ToUInt16(file, itemOffset + 48);
            item.NpcMeetFlag = BitConverter.ToUInt16(file, itemOffset + 50);
            item.MSGID = BitConverter.ToUInt16(file, itemOffset + 52);
            return item;
        }

        public static RSC_NpcWpn ReadRSC_NpcWpn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_NpcWpn();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            return item;
        }

        public static RSC_PcWpn ReadRSC_PcWpn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_PcWpn();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Effpack = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Flag = file[itemOffset + 12];
            item.MenuImageID = BitConverter.ToUInt16(file, itemOffset + 13);
            item.SpMuz = (item.Flag & 1) != 0;
            return item;
        }

        public static RSC_PcWpnMount ReadRSC_PcWpnMount(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_PcWpnMount();
            item.Id = itemId;
            item.Wpn01rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Wpn01rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Wpn02rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.Wpn02rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.Wpn03rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.Wpn03rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.Wpn03lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.Wpn03lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            item.Wpn04rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 32));
            item.Wpn04rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 36));
            item.Wpn05rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 40));
            item.Wpn05rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 44));
            item.Wpn05lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 48));
            item.Wpn05lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 52));
            item.Wpn06rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 56));
            item.Wpn06rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 60));
            item.Wpn07rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 64));
            item.Wpn07rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 68));
            item.Wpn07lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 72));
            item.Wpn07lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 76));
            item.Wpn08rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 80));
            item.Wpn08rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 84));
            item.Wpn09rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 88));
            item.Wpn09rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 92));
            item.Wpn09lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 96));
            item.Wpn09lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 100));
            item.Wpn10rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 104));
            item.Wpn10rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 108));
            item.Wpn10lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 112));
            item.Wpn10lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 116));
            item.Wpn11rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 120));
            item.Wpn11rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 124));
            item.Wpn12rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 128));
            item.Wpn12rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 132));
            item.Wpn12lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 136));
            item.Wpn12lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 140));
            item.Wpn13rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 144));
            item.Wpn13rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 148));
            item.Wpn14rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 152));
            item.Wpn14rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 156));
            item.Wpn15rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 160));
            item.Wpn15rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 164));
            item.Wpn16rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 168));
            item.Wpn16rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 172));
            item.Wpn16lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 176));
            item.Wpn16lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 180));
            item.Wpn17rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 184));
            item.Wpn17rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 188));
            item.Wpn18rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 192));
            item.Wpn18rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 196));
            item.Wpn19rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 200));
            item.Wpn19rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 204));
            item.Wpn20rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 208));
            item.Wpn20rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 212));
            item.Wpn20lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 216));
            item.Wpn20lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 220));
            item.Wpn21rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 224));
            item.Wpn21rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 228));
            item.Wpn22rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 232));
            item.Wpn22rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 236));
            item.Wpn22lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 240));
            item.Wpn22lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 244));
            item.Wpn23rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 248));
            item.Wpn23rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 252));
            item.Wpn23lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 256));
            item.Wpn23lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 260));
            item.Wpn24rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 264));
            item.Wpn24rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 268));
            item.Wpn24lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 272));
            item.Wpn24lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 276));
            item.Wpn25rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 280));
            item.Wpn25rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 284));
            item.Wpn25lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 288));
            item.Wpn25lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 292));
            item.Wpn26rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 296));
            item.Wpn26rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 300));
            item.Wpn26lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 304));
            item.Wpn26lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 308));
            item.Wpn28rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 312));
            item.Wpn28rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 316));
            item.Wpn28lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 320));
            item.Wpn28lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 324));
            item.Wpn29rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 328));
            item.Wpn29rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 332));
            item.Wpn29lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 336));
            item.Wpn29lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 340));
            item.Wpn30rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 344));
            item.Wpn30rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 348));
            item.Wpn30lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 352));
            item.Wpn30lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 356));
            item.Wpn31rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 360));
            item.Wpn31rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 364));
            item.Wpn31lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 368));
            item.Wpn31lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 372));
            item.Wpn32rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 376));
            item.Wpn32rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 380));
            item.Wpn32lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 384));
            item.Wpn32lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 388));
            item.Wpn33rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 392));
            item.Wpn33rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 396));
            item.Wpn33lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 400));
            item.Wpn33lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 404));
            item.Wpn34rIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 408));
            item.Wpn34rOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 412));
            item.Wpn34lIn = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 416));
            item.Wpn34lOut = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 420));
            return item;
        }

        public static RSC_TboxList ReadRSC_TboxList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_TboxList();
            item.Id = itemId;
            item.Model = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Motion = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.Effect = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.SE = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.baseHeight = BitConverter.ToSingle(file, itemOffset + 16);
            item.box_distance = BitConverter.ToSingle(file, itemOffset + 20);
            item.initWaitTime = BitConverter.ToSingle(file, itemOffset + 24);
            item.initWaitTimeRand = BitConverter.ToSingle(file, itemOffset + 28);
            item.offsetID = BitConverter.ToUInt16(file, itemOffset + 32);
            item.MSG_ID = BitConverter.ToUInt16(file, itemOffset + 34);
            item.visible_Radius = BitConverter.ToUInt16(file, itemOffset + 36);
            item.invisible_Radius = BitConverter.ToUInt16(file, itemOffset + 38);
            item.shapeType = file[itemOffset + 40];
            item.posX = BitConverter.ToSingle(file, itemOffset + 41);
            item.posY = BitConverter.ToSingle(file, itemOffset + 45);
            item.posZ = BitConverter.ToSingle(file, itemOffset + 49);
            item.base_offset_Y = BitConverter.ToSingle(file, itemOffset + 53);
            item.FS_starttime = BitConverter.ToSingle(file, itemOffset + 57);
            item.TBOX_open_starttime = BitConverter.ToSingle(file, itemOffset + 61);
            item.flag = file[itemOffset + 65];
            item.TBOX_category = (item.flag & 1) != 0;
            return item;
        }

        public static RSC_TypeWpn ReadRSC_TypeWpn(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new RSC_TypeWpn();
            item.Id = itemId;
            item.rex = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.nia = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 4));
            item.sieg = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 8));
            item.tora = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 12));
            item.vandamme = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 16));
            item.melef = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 20));
            item.sin = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 24));
            item.metsu = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 28));
            return item;
        }

        public static SYS_BasicFormation ReadSYS_BasicFormation(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new SYS_BasicFormation();
            item.Id = itemId;
            item.OffsetDr1X = BitConverter.ToSingle(file, itemOffset);
            item.OffsetDr1Z = BitConverter.ToSingle(file, itemOffset + 4);
            item.OffsetDr1RotY = BitConverter.ToSingle(file, itemOffset + 8);
            item.OffsetDr2X = BitConverter.ToSingle(file, itemOffset + 12);
            item.OffsetDr2Z = BitConverter.ToSingle(file, itemOffset + 16);
            item.OffsetDr2RotY = BitConverter.ToSingle(file, itemOffset + 20);
            return item;
        }

        public static SYS_BladeOffset ReadSYS_BladeOffset(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new SYS_BladeOffset();
            item.Id = itemId;
            item.OffsetBlX = BitConverter.ToSingle(file, itemOffset);
            item.OffsetBlZ = BitConverter.ToSingle(file, itemOffset + 4);
            item.OffsetBlRotY = BitConverter.ToSingle(file, itemOffset + 8);
            return item;
        }

        public static SYS_MapJumpEvList ReadSYS_MapJumpEvList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new SYS_MapJumpEvList();
            item.Id = itemId;
            item.MapList = file[itemOffset];
            item.FormationId = BitConverter.ToUInt16(file, itemOffset + 1);
            item.InfoPict = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 3));
            item.InfoTxt = BitConverter.ToUInt16(file, itemOffset + 7);
            item.DecoType = file[itemOffset + 9];
            item.debugName = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 10));
            return item;
        }

        public static SYS_PcBtlKeyList ReadSYS_PcBtlKeyList(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new SYS_PcBtlKeyList();
            item.Id = itemId;
            item.Shift = file[itemOffset];
            item.Type1 = file[itemOffset + 1];
            item.Button1 = file[itemOffset + 2];
            item.Type2 = file[itemOffset + 3];
            item.Button2 = file[itemOffset + 4];
            item.Func = file[itemOffset + 5];
            item.Ignore = file[itemOffset + 6];
            item.UiPos = file[itemOffset + 7];
            item.FLD_A = BitConverter.ToUInt16(file, itemOffset + 8);
            item.FLD_B = BitConverter.ToUInt16(file, itemOffset + 10);
            item.BTL_A = BitConverter.ToUInt16(file, itemOffset + 12);
            item.BTL_B = BitConverter.ToUInt16(file, itemOffset + 14);
            item.Text1 = BitConverter.ToUInt16(file, itemOffset + 16);
            item.Text2 = BitConverter.ToUInt16(file, itemOffset + 18);
            item.move = (item.Ignore & 1) != 0;
            item.cam = (item.Ignore & 2) != 0;
            item.act = (item.Ignore & 4) != 0;
            item.hopper = (item.Ignore & 8) != 0;
            item.social = (item.Ignore & 16) != 0;
            item.challenge = (item.Ignore & 32) != 0;
            return item;
        }

        public static Vo_Battle_Blade ReadVo_Battle_Blade(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Battle_Blade();
            item.Id = itemId;
            item.Priority = file[itemOffset];
            item.Group = file[itemOffset + 1];
            item.CTDriver = BitConverter.ToUInt16(file, itemOffset + 2);
            item.LotRate = file[itemOffset + 6];
            item.Reply = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ReplyGroup = file[itemOffset + 9];
            item.Flag = file[itemOffset + 10];
            item.Interval = file[itemOffset + 11];
            for (int i = 0, offset = itemOffset + 4; i < 2; i++, offset += 1)
            {
                item.Cond[i] = file[offset];
            }
            for (int i = 0, offset = itemOffset + 12; i < 4; i++, offset += 4)
            {
                item.Voice[i] = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, offset));
            }
            item.LotNum = (item.Flag & 1) != 0;
            item.NoOverwrite = (item.Flag & 2) != 0;
            item.Dead = (item.Flag & 4) != 0;
            item.NoDir = (item.Flag & 8) != 0;
            item.NoChain = (item.Flag & 16) != 0;
            item.NoReplyOK = (item.Flag & 32) != 0;
            return item;
        }

        public static Vo_Battle_Driver ReadVo_Battle_Driver(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Battle_Driver();
            item.Id = itemId;
            item.Priority = file[itemOffset];
            item.Group = file[itemOffset + 1];
            item.CTDriver = BitConverter.ToUInt16(file, itemOffset + 2);
            item.LotRate = file[itemOffset + 6];
            item.Reply = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ReplyGroup = file[itemOffset + 9];
            item.Flag = file[itemOffset + 10];
            item.Interval = file[itemOffset + 11];
            item.SoloMode = file[itemOffset + 12];
            for (int i = 0, offset = itemOffset + 4; i < 2; i++, offset += 1)
            {
                item.Cond[i] = file[offset];
            }
            for (int i = 0, offset = itemOffset + 13; i < 4; i++, offset += 4)
            {
                item.Voice[i] = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, offset));
            }
            item.LotNum = (item.Flag & 1) != 0;
            item.NoOverwrite = (item.Flag & 2) != 0;
            item.Dead = (item.Flag & 4) != 0;
            item.NoDir = (item.Flag & 8) != 0;
            item.NoChain = (item.Flag & 16) != 0;
            item.NoReplyOK = (item.Flag & 32) != 0;
            return item;
        }

        public static Vo_Battle_Enemy ReadVo_Battle_Enemy(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Battle_Enemy();
            item.Id = itemId;
            item.Priority = file[itemOffset];
            item.Group = file[itemOffset + 1];
            item.EnemyVC = BitConverter.ToUInt16(file, itemOffset + 2);
            item.CondEx = BitConverter.ToUInt16(file, itemOffset + 6);
            item.LotRate = file[itemOffset + 8];
            item.Reply = BitConverter.ToUInt16(file, itemOffset + 9);
            item.ReplyGroup = file[itemOffset + 11];
            item.Flag = file[itemOffset + 12];
            item.Interval = file[itemOffset + 13];
            for (int i = 0, offset = itemOffset + 4; i < 2; i++, offset += 1)
            {
                item.Cond[i] = file[offset];
            }
            for (int i = 0, offset = itemOffset + 14; i < 4; i++, offset += 4)
            {
                item.Voice[i] = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, offset));
            }
            item.NoOverwrite = (item.Flag & 1) != 0;
            item.Dead = (item.Flag & 2) != 0;
            item.NoDir = (item.Flag & 4) != 0;
            item.NoChain = (item.Flag & 8) != 0;
            item.NoReplyOK = (item.Flag & 16) != 0;
            return item;
        }

        public static Vo_Condition ReadVo_Condition(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Condition();
            item.Id = itemId;
            return item;
        }

        public static Vo_Field ReadVo_Field(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Field();
            item.Id = itemId;
            item.Priority = file[itemOffset];
            return item;
        }

        public static Vo_Field_Filter ReadVo_Field_Filter(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Field_Filter();
            item.Id = itemId;
            item.TargetFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = BitConverter.ToUInt16(file, itemOffset + 4);
            item.ChangeFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 6));
            return item;
        }

        public static Vo_Filter ReadVo_Filter(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Filter();
            item.Id = itemId;
            item.TargetFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset));
            item.Condition = file[itemOffset + 4];
            item.Param1 = BitConverter.ToUInt16(file, itemOffset + 5);
            item.Param2 = BitConverter.ToUInt16(file, itemOffset + 7);
            item.ChangeFile = Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, itemOffset + 9));
            item.NextID = BitConverter.ToUInt16(file, itemOffset + 13);
            return item;
        }

        public static Vo_Group ReadVo_Group(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_Group();
            item.Id = itemId;
            item.Interval = file[itemOffset];
            return item;
        }

        public static Vo_WinSp ReadVo_WinSp(byte[] file, int itemId, int itemOffset, int tableOffset)
        {
            var item = new Vo_WinSp();
            item.Id = itemId;
            item.FLD_CondID = BitConverter.ToUInt16(file, itemOffset);
            item.NeedChrID = BitConverter.ToUInt16(file, itemOffset + 2);
            for (int i = 0, offset = itemOffset + 4; i < 3; i++, offset += 2)
            {
                item.ChrID[i] = BitConverter.ToUInt16(file, offset);
            }
            for (int i = 0, offset = itemOffset + 10; i < 3; i++, offset += 4)
            {
                item.Voice[i] = BitConverter.ToUInt32(file, offset);
            }
            for (int i = 0, offset = itemOffset + 22; i < 3; i++, offset += 2)
            {
                item.Timer[i] = BitConverter.ToUInt16(file, offset);
            }
            return item;
        }

        public static void SetReferences(BdatCollection tables)
        {
            foreach (BLD_BladeList item in tables.BLD_BladeList.Items)
            {
                item._StatusID = tables.CHR_Bl.GetItemOrNull(item.StatusID);
            }

            foreach (BLD_BladeModelList item in tables.BLD_BladeModelList.Items)
            {
                item._Gender = tables.MNU_Msg_Gender.GetItemOrNull(item.Gender);
                item._QuestRace = tables.MNU_Msg_Race.GetItemOrNull(item.QuestRace);
                item._Parts = new[]
                {
                    item.Parts1,
                    item.Parts2,
                    item.Parts3,
                    item.Parts4
                };
            }

            foreach (BLD_CommonList item in tables.BLD_CommonList.Items)
            {
                item._ArtsAchievementSet1 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievementSet1);
                item._ArtsAchievementSet2 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievementSet2);
                item._ArtsAchievementSet3 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievementSet3);
                item._Fskill = (FieldSkillCategory)item.Fskill;
                item._FskillAchivementSet1 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivementSet1);
                item._FskillAchivementSet2 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivementSet2);
                item._FskillAchivementSet3 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivementSet3);
                item._Gender = tables.MNU_Msg_Gender.GetItemOrNull(item.Gender);
                item._IdeaType = (IdeaCategoryBits)item.IdeaType;
                item._KeyAchievementSet = tables.FLD_AchievementSet.GetItemOrNull(item.KeyAchievementSet);
                item._ModelTable = tables.BLD_BladeModelList.GetItemOrNull(item.ModelTable);
                item._QuestRace = tables.MNU_Msg_Race.GetItemOrNull(item.QuestRace);
                item._SkillAchievementSet1 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievementSet1);
                item._SkillAchievementSet2 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievementSet2);
                item._SkillAchievementSet3 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievementSet3);
            }

            foreach (BLD_NameList item in tables.BLD_NameList.Items)
            {
                item._Category = tables.bld_bladename.GetItemOrNull(item.Category);
                item._Gender = tables.MNU_Msg_Gender.GetItemOrNull(item.Gender);
            }

            foreach (BLD_RareList item in tables.BLD_RareList.Items)
            {
                item._Blade = tables.CHR_Bl.GetItemOrNull(item.Blade);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (BTL_Arts_Bl item in tables.BTL_Arts_Bl.Items)
            {
                item._ArtsBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsBuff);
                item._ArtsDeBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsDeBuff);
                item._ArtsType = (ArtType)item.ArtsType;
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._BtnChal1 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChal1);
                item._BulletID = tables.BTL_Bullet.GetItemOrNull(item.BulletID);
                item._Caption = tables.btl_arts_bl_ms.GetItemOrNull(item.Caption);
                item._CmnBlType = (CommonBladeType)item.CmnBlType;
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Enhance3 = tables.BTL_Enhance.GetItemOrNull(item.Enhance3);
                item._Enhance4 = tables.BTL_Enhance.GetItemOrNull(item.Enhance4);
                item._Enhance5 = tables.BTL_Enhance.GetItemOrNull(item.Enhance5);
                item._Enhance6 = tables.BTL_Enhance.GetItemOrNull(item.Enhance6);
                item._HitDirID1 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID1);
                item._HitDirID10 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID10);
                item._HitDirID11 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID11);
                item._HitDirID12 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID12);
                item._HitDirID13 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID13);
                item._HitDirID14 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID14);
                item._HitDirID15 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID15);
                item._HitDirID16 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID16);
                item._HitDirID2 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID2);
                item._HitDirID3 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID3);
                item._HitDirID4 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID4);
                item._HitDirID5 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID5);
                item._HitDirID6 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID6);
                item._HitDirID7 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID7);
                item._HitDirID8 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID8);
                item._HitDirID9 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID9);
                item._HitEff = tables.BTL_HitEffect.GetItemOrNull(item.HitEff);
                item._Name = tables.btl_arts_bl_ms.GetItemOrNull(item.Name);
                item._RangeType = (ArtRangeType)item.RangeType;
                item._ReAct1 = (ReactType)item.ReAct1;
                item._ReAct10 = (ReactType)item.ReAct10;
                item._ReAct11 = (ReactType)item.ReAct11;
                item._ReAct12 = (ReactType)item.ReAct12;
                item._ReAct13 = (ReactType)item.ReAct13;
                item._ReAct14 = (ReactType)item.ReAct14;
                item._ReAct15 = (ReactType)item.ReAct15;
                item._ReAct16 = (ReactType)item.ReAct16;
                item._ReAct2 = (ReactType)item.ReAct2;
                item._ReAct3 = (ReactType)item.ReAct3;
                item._ReAct4 = (ReactType)item.ReAct4;
                item._ReAct5 = (ReactType)item.ReAct5;
                item._ReAct6 = (ReactType)item.ReAct6;
                item._ReAct7 = (ReactType)item.ReAct7;
                item._ReAct8 = (ReactType)item.ReAct8;
                item._ReAct9 = (ReactType)item.ReAct9;
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
            }

            foreach (BTL_Arts_BlSp item in tables.BTL_Arts_BlSp.Items)
            {
                item._AddBl = tables.CHR_Bl.GetItemOrNull(item.AddBl);
                item._ArtsBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsBuff);
                item._ArtsType = (ArtType)item.ArtsType;
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._BtnChal1 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChal1);
                item._BtnChal2 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChal2);
                item._BtnChal3 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChal3);
                item._BtnChal6 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChal6);
                item._BulletID = tables.BTL_Bullet.GetItemOrNull(item.BulletID);
                item._Caption = tables.btl_arts_blsp_ms.GetItemOrNull(item.Caption);
                item._CmnBlType = (CommonBladeType)item.CmnBlType;
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._HitDirID1 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID1);
                item._HitDirID10 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID10);
                item._HitDirID11 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID11);
                item._HitDirID12 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID12);
                item._HitDirID13 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID13);
                item._HitDirID14 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID14);
                item._HitDirID15 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID15);
                item._HitDirID16 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID16);
                item._HitDirID2 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID2);
                item._HitDirID3 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID3);
                item._HitDirID4 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID4);
                item._HitDirID5 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID5);
                item._HitDirID6 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID6);
                item._HitDirID7 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID7);
                item._HitDirID8 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID8);
                item._HitDirID9 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID9);
                item._HitEff = tables.BTL_HitEffect.GetItemOrNull(item.HitEff);
                item._Name = tables.btl_arts_blsp_ms.GetItemOrNull(item.Name);
                item._PC01 = tables.BTL_Arts_BlSp.GetItemOrNull(item.PC01);
                item._PC02 = tables.BTL_Arts_BlSp.GetItemOrNull(item.PC02);
                item._PC03 = tables.BTL_Arts_BlSp.GetItemOrNull(item.PC03);
                item._PC06 = tables.BTL_Arts_BlSp.GetItemOrNull(item.PC06);
                item._ReAct1 = (ReactType)item.ReAct1;
                item._ReAct10 = (ReactType)item.ReAct10;
                item._ReAct11 = (ReactType)item.ReAct11;
                item._ReAct12 = (ReactType)item.ReAct12;
                item._ReAct13 = (ReactType)item.ReAct13;
                item._ReAct14 = (ReactType)item.ReAct14;
                item._ReAct15 = (ReactType)item.ReAct15;
                item._ReAct16 = (ReactType)item.ReAct16;
                item._ReAct2 = (ReactType)item.ReAct2;
                item._ReAct3 = (ReactType)item.ReAct3;
                item._ReAct4 = (ReactType)item.ReAct4;
                item._ReAct5 = (ReactType)item.ReAct5;
                item._ReAct6 = (ReactType)item.ReAct6;
                item._ReAct7 = (ReactType)item.ReAct7;
                item._ReAct8 = (ReactType)item.ReAct8;
                item._ReAct9 = (ReactType)item.ReAct9;
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
            }

            foreach (BTL_Arts_Dr item in tables.BTL_Arts_Dr.Items)
            {
                item._ArtsBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsBuff);
                item._ArtsDeBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsDeBuff);
                item._ArtsType = (ArtType)item.ArtsType;
                item._BulletID = tables.BTL_Bullet.GetItemOrNull(item.BulletID);
                item._Caption = tables.btl_arts_dr_cap.GetItemOrNull(item.Caption);
                item._Driver = tables.CHR_Dr.GetItemOrNull(item.Driver);
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Enhance3 = tables.BTL_Enhance.GetItemOrNull(item.Enhance3);
                item._Enhance4 = tables.BTL_Enhance.GetItemOrNull(item.Enhance4);
                item._Enhance5 = tables.BTL_Enhance.GetItemOrNull(item.Enhance5);
                item._Enhance6 = tables.BTL_Enhance.GetItemOrNull(item.Enhance6);
                item._HitDirID1 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID1);
                item._HitDirID10 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID10);
                item._HitDirID11 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID11);
                item._HitDirID12 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID12);
                item._HitDirID13 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID13);
                item._HitDirID14 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID14);
                item._HitDirID15 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID15);
                item._HitDirID16 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID16);
                item._HitDirID2 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID2);
                item._HitDirID3 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID3);
                item._HitDirID4 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID4);
                item._HitDirID5 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID5);
                item._HitDirID6 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID6);
                item._HitDirID7 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID7);
                item._HitDirID8 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID8);
                item._HitDirID9 = tables.BTL_HitDirection.GetItemOrNull(item.HitDirID9);
                item._HitEff = tables.BTL_HitEffect.GetItemOrNull(item.HitEff);
                item._Name = tables.btl_arts_dr_ms.GetItemOrNull(item.Name);
                item._NextArts = tables.BTL_Arts_Dr.GetItemOrNull(item.NextArts);
                item._RangeType = (ArtRangeType)item.RangeType;
                item._ReAct1 = (ReactType)item.ReAct1;
                item._ReAct10 = (ReactType)item.ReAct10;
                item._ReAct11 = (ReactType)item.ReAct11;
                item._ReAct12 = (ReactType)item.ReAct12;
                item._ReAct13 = (ReactType)item.ReAct13;
                item._ReAct14 = (ReactType)item.ReAct14;
                item._ReAct15 = (ReactType)item.ReAct15;
                item._ReAct16 = (ReactType)item.ReAct16;
                item._ReAct2 = (ReactType)item.ReAct2;
                item._ReAct3 = (ReactType)item.ReAct3;
                item._ReAct4 = (ReactType)item.ReAct4;
                item._ReAct5 = (ReactType)item.ReAct5;
                item._ReAct6 = (ReactType)item.ReAct6;
                item._ReAct7 = (ReactType)item.ReAct7;
                item._ReAct8 = (ReactType)item.ReAct8;
                item._ReAct9 = (ReactType)item.ReAct9;
                item._UI = tables.MNU_IconList.GetItemOrNull(item.UI);
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
            }

            foreach (BTL_Arts_En item in tables.BTL_Arts_En.Items)
            {
                item._ArtsBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsBuff);
                item._ArtsDeBuff = tables.BTL_Buff.GetItemOrNull(item.ArtsDeBuff);
                item._ArtsType = (ArtType)item.ArtsType;
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._BulletID = tables.BTL_Bullet.GetItemOrNull(item.BulletID);
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._Name = tables.btl_arts_en_ms.GetItemOrNull(item.Name);
                item._ReAct1 = (ReactType)item.ReAct1;
                item._ReAct10 = (ReactType)item.ReAct10;
                item._ReAct11 = (ReactType)item.ReAct11;
                item._ReAct12 = (ReactType)item.ReAct12;
                item._ReAct13 = (ReactType)item.ReAct13;
                item._ReAct14 = (ReactType)item.ReAct14;
                item._ReAct15 = (ReactType)item.ReAct15;
                item._ReAct16 = (ReactType)item.ReAct16;
                item._ReAct2 = (ReactType)item.ReAct2;
                item._ReAct3 = (ReactType)item.ReAct3;
                item._ReAct4 = (ReactType)item.ReAct4;
                item._ReAct5 = (ReactType)item.ReAct5;
                item._ReAct6 = (ReactType)item.ReAct6;
                item._ReAct7 = (ReactType)item.ReAct7;
                item._ReAct8 = (ReactType)item.ReAct8;
                item._ReAct9 = (ReactType)item.ReAct9;
                item._Summon = tables.BTL_Summon.GetItemOrNull(item.Summon);
            }

            foreach (BTL_Aura item in tables.BTL_Aura.Items)
            {
                item._ChangeAtr = tables.MNU_Msg_Attr.GetItemOrNull(item.ChangeAtr + 1);
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Enhance3 = tables.BTL_Enhance.GetItemOrNull(item.Enhance3);
                item._Name = tables.btl_aura_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_Bl_KizunaLinkSet item in tables.BTL_Bl_KizunaLinkSet.Items)
            {
                item._KizunaLink1 = tables.BTL_Bl_KizunaLink.GetItemOrNull(item.KizunaLink1);
                item._KizunaLink2 = tables.BTL_Bl_KizunaLink.GetItemOrNull(item.KizunaLink2);
            }

            foreach (BTL_Bl_Personality item in tables.BTL_Bl_Personality.Items)
            {
                item._KizunaBase = tables.BTL_Bl_KizunaBase.GetItemOrNull(item.KizunaBase);
            }

            foreach (BTL_Buff item in tables.BTL_Buff.Items)
            {
                item._Caption = tables.btl_buff_cap.GetItemOrNull(item.Caption);
                item._Name = tables.btl_buff_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_ChBtl item in tables.BTL_ChBtl.Items)
            {
                item._Caption = tables.btl_chbtl_ms.GetItemOrNull(item.Caption);
                item._ClearReward = tables.GetItem(item.ClearReward);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Driver1 = tables.CHR_Dr.GetItemOrNull(item.Driver1);
                item._Driver2 = tables.CHR_Dr.GetItemOrNull(item.Driver2);
                item._Driver3 = tables.CHR_Dr.GetItemOrNull(item.Driver3);
                item._MapJump = tables.SYS_MapJumpList.GetItemOrNull(item.MapJump);
                item._Name = tables.btl_chbtl_ms.GetItemOrNull(item.Name);
                item._TresureResource1 = tables.RSC_TboxList.GetItemOrNull(item.TresureResource1);
                item._TresureResource2 = tables.RSC_TboxList.GetItemOrNull(item.TresureResource2);
                item._TresureResource3 = tables.RSC_TboxList.GetItemOrNull(item.TresureResource3);
                item._TresureSet1 = tables.BTL_ChBtlRewardSet.GetItemOrNull(item.TresureSet1);
                item._TresureSet2 = tables.BTL_ChBtlRewardSet.GetItemOrNull(item.TresureSet2);
                item._TresureSet3 = tables.BTL_ChBtlRewardSet.GetItemOrNull(item.TresureSet3);
                item._WpnRevTable = tables.BTL_ChBtlWpnRev.GetItemOrNull(item.WpnRevTable);
            }

            foreach (BTL_ChBtlRewardItem item in tables.BTL_ChBtlRewardItem.Items)
            {
                item._ItemID = tables.GetItem(item.ItemID);
            }

            foreach (BTL_ChBtlRewardSet item in tables.BTL_ChBtlRewardSet.Items)
            {
                item._UpItemID1 = tables.GetItem(item.UpItemID1);
                item._UpItemID2 = tables.GetItem(item.UpItemID2);
                item._UpItemID3 = tables.GetItem(item.UpItemID3);
                item._UpItemID4 = tables.GetItem(item.UpItemID4);
            }

            foreach (BTL_Class item in tables.BTL_Class.Items)
            {
                item._Name = tables.btl_class_ms.GetItemOrNull(item.Name);
                item._Role1 = tables.menu_role_name_ms.GetItemOrNull(item.Role1);
                item._Role2 = tables.menu_role_name_ms.GetItemOrNull(item.Role2);
                item._Role3 = tables.menu_role_name_ms.GetItemOrNull(item.Role3);
            }

            foreach (BTL_CmnBl_Armor item in tables.BTL_CmnBl_Armor.Items)
            {
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
            }

            foreach (BTL_CmnBl_Capacity item in tables.BTL_CmnBl_Capacity.Items)
            {
                item._ArtsLvProb = new[]
                {
                    item.ArtsLv1Prob,
                    item.ArtsLv2Prob,
                    item.ArtsLv3Prob,
                    item.ArtsLv4Prob,
                    item.ArtsLv5Prob
                };
                item._ArtsNumProb = new[]
                {
                    item.ArtsNum1Prob,
                    item.ArtsNum2Prob,
                    item.ArtsNum3Prob
                };
                item._NartsNumProb = new[]
                {
                    item.NartsNum1Prob,
                    item.NartsNum2Prob,
                    item.NartsNum3Prob
                };
                item._OrbNumProb = new[]
                {
                    item.OrbNum0Prob,
                    item.OrbNum1Prob,
                    item.OrbNum2Prob,
                    item.OrbNum3Prob
                };
                item._SkillLvProb = new[]
                {
                    item.SkillLv1Prob,
                    item.SkillLv2Prob,
                    item.SkillLv3Prob,
                    item.SkillLv4Prob,
                    item.SkillLv5Prob
                };
                item._SkillNumProb = new[]
                {
                    item.SkillNum1Prob,
                    item.SkillNum2Prob,
                    item.SkillNum3Prob
                };
            }

            foreach (BTL_CmnBl_NewBlArts item in tables.BTL_CmnBl_NewBlArts.Items)
            {
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
                item._NBA = new[]
                {
                    item.NBA_01,
                    item.NBA_02,
                    item.NBA_03,
                    item.NBA_04,
                    item.NBA_05,
                    item.NBA_06,
                    item.NBA_07,
                    item.NBA_08
                };
            }

            foreach (BTL_CmnBl_Power item in tables.BTL_CmnBl_Power.Items)
            {
                item._Pow = new[]
                {
                    item.Pow01,
                    item.Pow02,
                    item.Pow03,
                    item.Pow04,
                    item.Pow05,
                    item.Pow06,
                    item.Pow07,
                    item.Pow08,
                    item.Pow09,
                    item.Pow10
                };
            }

            foreach (BTL_CmnBl_StatusType item in tables.BTL_CmnBl_StatusType.Items)
            {
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
                item._Status = new[]
                {
                    item.Status01,
                    item.Status02,
                    item.Status03,
                    item.Status04,
                    item.Status05,
                    item.Status06
                };
            }

            foreach (BTL_Condition item in tables.BTL_Condition.Items)
            {
                item._FLD_CondID = tables.FLD_ConditionList.GetItemOrNull(item.FLD_CondID);
            }

            foreach (BTL_ElementalCombo item in tables.BTL_ElementalCombo.Items)
            {
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._Name = tables.btl_elementalcombo_ms.GetItemOrNull(item.Name);
                item._PreCombo = tables.BTL_ElementalCombo.GetItemOrNull(item.PreCombo);
                item._ReAct1 = (ReactType)item.ReAct1;
                item._ReAct10 = (ReactType)item.ReAct10;
                item._ReAct11 = (ReactType)item.ReAct11;
                item._ReAct12 = (ReactType)item.ReAct12;
                item._ReAct13 = (ReactType)item.ReAct13;
                item._ReAct14 = (ReactType)item.ReAct14;
                item._ReAct15 = (ReactType)item.ReAct15;
                item._ReAct16 = (ReactType)item.ReAct16;
                item._ReAct2 = (ReactType)item.ReAct2;
                item._ReAct3 = (ReactType)item.ReAct3;
                item._ReAct4 = (ReactType)item.ReAct4;
                item._ReAct5 = (ReactType)item.ReAct5;
                item._ReAct6 = (ReactType)item.ReAct6;
                item._ReAct7 = (ReactType)item.ReAct7;
                item._ReAct8 = (ReactType)item.ReAct8;
                item._ReAct9 = (ReactType)item.ReAct9;
                item._Reaction = tables.BTL_Reaction.GetItemOrNull(item.Reaction);
            }

            foreach (BTL_ElementalEffect item in tables.BTL_ElementalEffect.Items)
            {
                item._Atr1 = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr1 + 1);
                item._Caption = tables.btl_buff_ms.GetItemOrNull(item.Caption);
                item._Name = tables.btl_elementaleffect_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_EnBook item in tables.BTL_EnBook.Items)
            {
                item._BaseEnemyID = tables.CHR_EnArrange.GetItemOrNull(item.BaseEnemyID);
            }

            foreach (BTL_EnDropItem item in tables.BTL_EnDropItem.Items)
            {
                item._ItemID1 = tables.GetItem(item.ItemID1);
                item._ItemID2 = tables.GetItem(item.ItemID2);
                item._ItemID3 = tables.GetItem(item.ItemID3);
                item._ItemID4 = tables.GetItem(item.ItemID4);
                item._ItemID5 = tables.GetItem(item.ItemID5);
                item._ItemID6 = tables.GetItem(item.ItemID6);
                item._ItemID7 = tables.GetItem(item.ItemID7);
                item._ItemID8 = tables.GetItem(item.ItemID8);
            }

            foreach (BTL_EnDropQuest item in tables.BTL_EnDropQuest.Items)
            {
                item._GetConditon1 = tables.FLD_ConditionList.GetItemOrNull(item.GetConditon1);
                item._GetConditon2 = tables.FLD_ConditionList.GetItemOrNull(item.GetConditon2);
                item._GetConditon3 = tables.FLD_ConditionList.GetItemOrNull(item.GetConditon3);
                item._GetConditon4 = tables.FLD_ConditionList.GetItemOrNull(item.GetConditon4);
                item._ItemID1 = tables.GetItem(item.ItemID1);
                item._ItemID2 = tables.GetItem(item.ItemID2);
                item._ItemID3 = tables.GetItem(item.ItemID3);
                item._ItemID4 = tables.GetItem(item.ItemID4);
            }

            foreach (BTL_Enhance item in tables.BTL_Enhance.Items)
            {
                item._EnhanceEffect = tables.BTL_EnhanceEff.GetItemOrNull(item.EnhanceEffect);
            }

            foreach (BTL_EnhanceEff item in tables.BTL_EnhanceEff.Items)
            {
                item._Name = tables.btl_buff_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_FightCombo item in tables.BTL_FightCombo.Items)
            {
                item._Name = tables.btl_fightcombo_ms.GetItemOrNull(item.Name);
                item._Reaction = tables.BTL_Reaction.GetItemOrNull(item.Reaction);
            }

            foreach (BTL_HanaChipset item in tables.BTL_HanaChipset.Items)
            {
                item._AtrParts = tables.GetItem(item.AtrParts);
                item._NArtsParts1 = tables.GetItem(item.NArtsParts1);
                item._NArtsParts2 = tables.GetItem(item.NArtsParts2);
                item._NArtsParts3 = tables.GetItem(item.NArtsParts3);
                item._RoleParts = tables.GetItem(item.RoleParts);
            }

            foreach (BTL_IrGroupRev item in tables.BTL_IrGroupRev.Items)
            {
                item._GroupRev1 = tables.BTL_Class.GetItemOrNull(item.GroupRev1);
                item._GroupRev2 = tables.BTL_Class.GetItemOrNull(item.GroupRev2);
                item._GroupRev3 = tables.BTL_Class.GetItemOrNull(item.GroupRev3);
            }

            foreach (BTL_NamedList item in tables.BTL_NamedList.Items)
            {
                item._EnemyID = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID);
            }

            foreach (BTL_NamedList item in tables.BTL_NamedListIra.Items)
            {
                item._EnemyID = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID);
            }

            foreach (BTL_PouchBuff item in tables.BTL_PouchBuff.Items)
            {
                item._Name = tables.btl_pouchbuff_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_Reaction item in tables.BTL_Reaction.Items)
            {
                item._Name = tables.btl_buff_ms.GetItemOrNull(item.Name);
            }

            foreach (BTL_Skill_Bl item in tables.BTL_Skill_Bl.Items)
            {
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Enhance3 = tables.BTL_Enhance.GetItemOrNull(item.Enhance3);
                item._Enhance4 = tables.BTL_Enhance.GetItemOrNull(item.Enhance4);
                item._Enhance5 = tables.BTL_Enhance.GetItemOrNull(item.Enhance5);
                item._Name = tables.btl_skill_bl_name.GetItemOrNull(item.Name);
            }

            foreach (BTL_Skill_Dr item in tables.BTL_Skill_Dr.Items)
            {
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._Name = tables.btl_skill_dr_name.GetItemOrNull(item.Name);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table01.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table02.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table03.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table04.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table05.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table06.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table17.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table18.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Skill_Dr_Table item in tables.BTL_Skill_Dr_Table19.Items)
            {
                item._SkillID = tables.BTL_Skill_Dr.GetItemOrNull(item.SkillID);
            }

            foreach (BTL_Wpn_En item in tables.BTL_Wpn_En.Items)
            {
                item._RscL = tables.RSC_EnWpn.GetItemOrNull(item.RscL);
                item._RscR = tables.RSC_EnWpn.GetItemOrNull(item.RscR);
            }

            foreach (CHR_Bl item in tables.CHR_Bl.Items)
            {
                item._ArtsAchievement1 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievement1);
                item._ArtsAchievement2 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievement2);
                item._ArtsAchievement3 = tables.FLD_AchievementSet.GetItemOrNull(item.ArtsAchievement3);
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._BArts1 = tables.BTL_Arts_Bl.GetItemOrNull(item.BArts1);
                item._BArts2 = tables.BTL_Arts_Bl.GetItemOrNull(item.BArts2);
                item._BArts3 = tables.BTL_Arts_Bl.GetItemOrNull(item.BArts3);
                item._BartsEx = tables.BTL_Arts_BlSp.GetItemOrNull(item.BartsEx);
                item._BartsEx2 = tables.BTL_Arts_BlSp.GetItemOrNull(item.BartsEx2);
                item._BSkill1 = tables.BTL_Skill_Bl.GetItemOrNull(item.BSkill1);
                item._BSkill2 = tables.BTL_Skill_Bl.GetItemOrNull(item.BSkill2);
                item._BSkill3 = tables.BTL_Skill_Bl.GetItemOrNull(item.BSkill3);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._DefWeapon = tables.ITM_PcWpn.GetItemOrNull(item.DefWeapon);
                item._FavoriteCategory1 = tables.menu_favorite_category.GetItemOrNull(item.FavoriteCategory1 - 11);
                item._FavoriteCategory2 = tables.menu_favorite_category.GetItemOrNull(item.FavoriteCategory2 - 11);
                item._FavoriteItem1 = tables.ITM_FavoriteList.GetItemOrNull(item.FavoriteItem1);
                item._FavoriteItem2 = tables.ITM_FavoriteList.GetItemOrNull(item.FavoriteItem2);
                item._FSkill1 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkill1);
                item._FSkill2 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkill2);
                item._FSkill3 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkill3);
                item._FskillAchivement1 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivement1);
                item._FskillAchivement2 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivement2);
                item._FskillAchivement3 = tables.FLD_AchievementSet.GetItemOrNull(item.FskillAchivement3);
                item._Gender = tables.MNU_Msg_Gender.GetItemOrNull(item.Gender);
                item._KeyAchievement = tables.FLD_AchievementSet.GetItemOrNull(item.KeyAchievement);
                item._MerceName = tables.bld_mercename.GetItemOrNull(item.MerceName);
                item._MnuCastName = tables.menu_cast_name.GetItemOrNull(item.MnuCastName);
                item._MnuIlustName = tables.menu_ilust_name.GetItemOrNull(item.MnuIlustName);
                item._Name = tables.chr_bl_ms.GetItemOrNull(item.Name);
                item._NArts1 = tables.BTL_Buff.GetItemOrNull(item.NArts1);
                item._NArts2 = tables.BTL_Buff.GetItemOrNull(item.NArts2);
                item._NArts3 = tables.BTL_Buff.GetItemOrNull(item.NArts3);
                item._Personality = tables.BTL_Bl_Personality.GetItemOrNull(item.Personality);
                item._QuestRace = tables.MNU_Msg_Race.GetItemOrNull(item.QuestRace);
                item._SkillAchievement1 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievement1);
                item._SkillAchievement2 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievement2);
                item._SkillAchievement3 = tables.FLD_AchievementSet.GetItemOrNull(item.SkillAchievement3);
                item._Still = tables.MNU_IconList.GetItemOrNull(item.Still);
                item._WeaponType = tables.ITM_PcWpnType.GetItemOrNull(item.WeaponType);
                item._Achievement = new[]
                {
                    item._KeyAchievement,
                    item._ArtsAchievement1,
                    item._ArtsAchievement2,
                    item._ArtsAchievement3,
                    item._SkillAchievement1,
                    item._SkillAchievement2,
                    item._SkillAchievement3,
                    item._FskillAchivement1,
                    item._FskillAchivement2,
                    item._FskillAchivement3
                };
                item._ArtsAchievement = new[]
                {
                    item._ArtsAchievement1,
                    item._ArtsAchievement2,
                    item._ArtsAchievement3
                };
                item._BArts = new[]
                {
                    item._BArts1,
                    item._BArts2,
                    item._BArts3
                };
                item._BSkill = new[]
                {
                    item._BSkill1,
                    item._BSkill2,
                    item._BSkill3
                };
                item._FavoriteCategory = new[]
                {
                    item._FavoriteCategory1,
                    item._FavoriteCategory2
                };
                item._FavoriteItem = new[]
                {
                    item._FavoriteItem1,
                    item._FavoriteItem2
                };
                item._FSkill = new[]
                {
                    item._FSkill1,
                    item._FSkill2,
                    item._FSkill3
                };
                item._FskillAchivement = new[]
                {
                    item._FskillAchivement1,
                    item._FskillAchivement2,
                    item._FskillAchivement3
                };
                item._NArts = new[]
                {
                    item._NArts1,
                    item._NArts2,
                    item._NArts3
                };
                item._NArtsRecastRev = new[]
                {
                    item.NArtsRecastRev1,
                    item.NArtsRecastRev2,
                    item.NArtsRecastRev3
                };
                item._SkillAchievement = new[]
                {
                    item._SkillAchievement1,
                    item._SkillAchievement2,
                    item._SkillAchievement3
                };
            }

            foreach (CHR_Dr item in tables.CHR_Dr.Items)
            {
                item._AiID = tables.BTL_Ai.GetItemOrNull(item.AiID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._DefAcce = tables.ITM_PcEquip.GetItemOrNull(item.DefAcce);
                item._DefBlade1 = tables.CHR_Bl.GetItemOrNull(item.DefBlade1);
                item._DefBlade2 = tables.CHR_Bl.GetItemOrNull(item.DefBlade2);
                item._DefBlade3 = tables.CHR_Bl.GetItemOrNull(item.DefBlade3);
                item._FavoriteCategory1 = tables.menu_favorite_category.GetItemOrNull(item.FavoriteCategory1 - 11);
                item._FavoriteCategory2 = tables.menu_favorite_category.GetItemOrNull(item.FavoriteCategory2 - 11);
                item._FavoriteItem1 = tables.ITM_FavoriteList.GetItemOrNull(item.FavoriteItem1);
                item._FavoriteItem2 = tables.ITM_FavoriteList.GetItemOrNull(item.FavoriteItem2);
                item._Gender = tables.MNU_Msg_Gender.GetItemOrNull(item.Gender);
                item._IraParam = tables.CHR_Ir.GetItemOrNull(item.IraParam);
                item._Name = tables.chr_dr_ms.GetItemOrNull(item.Name);
            }

            foreach (CHR_DriverParam item in tables.CHR_DriverParam.Items)
            {
                item._ExtMountCond = tables.FLD_ConditionList.GetItemOrNull(item.ExtMountCond);
                item._ExtMountNpc = tables.RSC_NpcList.GetItemOrNull(item.ExtMountNpc);
            }

            foreach (CHR_EnArrange item in tables.CHR_EnArrange.Items)
            {
                item._BGMID = tables.RSC_BgmList.GetItemOrNull(item.BGMID);
                item._BladeID = tables.CHR_Bl.GetItemOrNull(item.BladeID);
                item._BookID = tables.BTL_EnBook.GetItemOrNull(item.BookID);
                item._DropTableID = tables.BTL_EnDropItem.GetItemOrNull(item.DropTableID);
                item._DropTableID2 = tables.BTL_EnDropItem.GetItemOrNull(item.DropTableID2);
                item._DropTableID3 = tables.BTL_EnDropItem.GetItemOrNull(item.DropTableID3);
                item._EnemyBladeID = tables.CHR_EnArrange.GetItemOrNull(item.EnemyBladeID);
                item._EnhanceID1 = tables.BTL_Enhance.GetItemOrNull(item.EnhanceID1);
                item._EnhanceID2 = tables.BTL_Enhance.GetItemOrNull(item.EnhanceID2);
                item._EnhanceID3 = tables.BTL_Enhance.GetItemOrNull(item.EnhanceID3);
                item._Name = tables.fld_enemyname.GetItemOrNull(item.Name);
                item._ParamID = tables.CHR_EnParam.GetItemOrNull(item.ParamID);
                item._ParamRev = tables.CHR_EnParam_Rev.GetItemOrNull(item.ParamRev);
                item._PreciousID = tables.GetItem(item.PreciousID);
                item._ZoneID = tables.FLD_maplist.GetItemOrNull(item.ZoneID);
            }

            foreach (CHR_EnParam item in tables.CHR_EnParam.Items)
            {
                item._AiID = tables.BTL_Ai.GetItemOrNull(item.AiID);
                item._ArtsNum1 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum1);
                item._ArtsNum10 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum10);
                item._ArtsNum11 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum11);
                item._ArtsNum12 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum12);
                item._ArtsNum13 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum13);
                item._ArtsNum14 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum14);
                item._ArtsNum15 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum15);
                item._ArtsNum16 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum16);
                item._ArtsNum2 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum2);
                item._ArtsNum3 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum3);
                item._ArtsNum4 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum4);
                item._ArtsNum5 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum5);
                item._ArtsNum6 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum6);
                item._ArtsNum7 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum7);
                item._ArtsNum8 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum8);
                item._ArtsNum9 = tables.BTL_Arts_En.GetItemOrNull(item.ArtsNum9);
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._Aura = tables.BTL_Aura.GetItemOrNull(item.Aura);
                item._ResourceID = tables.RSC_En.GetItemOrNull(item.ResourceID);
            }

            foreach (CHR_Ir item in tables.CHR_Ir.Items)
            {
                item._DefWpnAcce = tables.ITM_PcEquip.GetItemOrNull(item.DefWpnAcce);
                item._driverID = tables.CHR_Dr.GetItemOrNull(item.driverID);
                item._DriverWpn = tables.ITM_PcWpnIr.GetItemOrNull(item.DriverWpn);
                item._LinkSet = tables.BTL_Bl_KizunaLinkSet.GetItemOrNull(item.LinkSet);
                item._Type = (IraCharType)item.Type;
            }

            foreach (MNU_txt item in tables.dlc100_btl_time_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc101_named_dialog_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc102_named_list_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc103_btlch_order_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc105_btlch_telop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc107_vision_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc3_mnu076_char_menu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc302_npc_telop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc303_camp_menu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.dlc304_char_change_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (EventChange item in tables.EVT_chgBf01.Items)
            {
                item._chgType = tables.EVT_change.GetItemOrNull(item.chgType);
            }

            foreach (EventChange item in tables.EVT_chgDeb01.Items)
            {
                item._chgType = tables.EVT_change.GetItemOrNull(item.chgType);
            }

            foreach (EventChange item in tables.EVT_chgFev01.Items)
            {
                item._chgType = tables.EVT_change.GetItemOrNull(item.chgType);
            }

            foreach (EventChange item in tables.EVT_chgQst01.Items)
            {
                item._chgType = tables.EVT_change.GetItemOrNull(item.chgType);
            }

            foreach (EventChange item in tables.EVT_chgTlk01.Items)
            {
                item._chgType = tables.EVT_change.GetItemOrNull(item.chgType);
            }

            foreach (FacialConfig item in tables.EVT_facial_AZAMI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_BLADEANIMAL.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_BLADEFEMALE.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_BLADENORMAL.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_BLADESTRONG.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_BYAKKO.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_GUREN.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_HANA_1.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_HIKARI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_HOMURA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_HOTARU.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_IBUKI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_IDATEN.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_KAGUTSUCHI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_KAMUI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_KASANE.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_KOSMOS.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_KUBIRA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_MELEF.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_MIKUMARI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_MUSUBI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NANAKOORI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NIA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP000101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP000301.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP000701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP000801.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP000901.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001301.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001601.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001602.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001801.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP001901.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002301.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002601.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002801.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP002901.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003301.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003601.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003801.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP003901.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP004601.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010002.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010003.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010004.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010005.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010006.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP010007.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP030001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100102.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100301.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP100501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP190002.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP411001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP412001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP413000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP413101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP414000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP417001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP417101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP421001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP422001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423601.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP423701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP424000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP424101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP424201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP424501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP431001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP432001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP433000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP433101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP433201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP434000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP434201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP435001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP436001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP437001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP441001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP442001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP443000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP443101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP444000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP445001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP445101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP446001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP451001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP452001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453202.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453203.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453204.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453401.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP453701.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP454000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP454201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP454501.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP455001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP456001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP457001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP457101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP463000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP463101.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP463201.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP464000.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP465001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP471001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP472001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP473001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP474001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP475001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NP476001.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_NYUTSU.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_OTSUCHI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RAGOU.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RAIKO.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RARE_003.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RARE_025.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RARE_026.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RARE_027.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RARE_028.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_REX.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_RINNE.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_SAIKA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_SEORI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_SHIKI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_SIEG.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_SUZAKU.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_TOKIHA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_TOR.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_UKA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_VAJRA.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_VANDAMME.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_YAEGIRI.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_YUOH.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_ZAKURO.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facial_ZANTETSU.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facialTemplate.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facialTemplateBS.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facialTemplateJ.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (FacialConfig item in tables.EVT_facialTemplateN.Items)
            {
                item._brow_type = tables.EVT_browtype.GetItemOrNull(item.brow_type);
                item._eye_type = tables.EVT_eyetype.GetItemOrNull(item.eye_type);
                item._lip_type = tables.EVT_liptype.GetItemOrNull(item.lip_type);
            }

            foreach (EVT_listBf item in tables.EVT_listBf.Items)
            {
                item._category = (EventCategory)item.category;
                item._chgEdID = tables.EVT_chgBf01.GetItemOrNull(item.chgEdID);
                item._chgStID = tables.EVT_chgBf01.GetItemOrNull(item.chgStID);
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._envSeam = tables.EVT_listBf.GetItemOrNull(item.envSeam);
                item._linkID = tables.EVT_listBf.GetItemOrNull(item.linkID);
                item._nextIDtheater = tables.EVT_listBf.GetItemOrNull(item.nextIDtheater);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (EVT_listBl item in tables.EVT_listBl.Items)
            {
                item._category = (EventCategory)item.category;
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (EVT_listDeb01 item in tables.EVT_listDeb01.Items)
            {
                item._category = (EventCategory)item.category;
                item._chgEdID = tables.EVT_chgDeb01.GetItemOrNull(item.chgEdID);
                item._chgStID = tables.EVT_chgDeb01.GetItemOrNull(item.chgStID);
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._setupID = tables.EVT_setupDeb01.GetItemOrNull(item.setupID);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (EVT_listFev01 item in tables.EVT_listFev01.Items)
            {
                item._category = (EventCategory)item.category;
                item._chgEdID = tables.EVT_chgFev01.GetItemOrNull(item.chgEdID);
                item._chgStID = tables.EVT_chgFev01.GetItemOrNull(item.chgStID);
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._setupID = tables.EVT_setupFev01.GetItemOrNull(item.setupID);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (EVT_listQst01 item in tables.EVT_listQst01.Items)
            {
                item._category = (EventCategory)item.category;
                item._chgEdID = tables.EVT_chgQst01.GetItemOrNull(item.chgEdID);
                item._chgStID = tables.EVT_chgQst01.GetItemOrNull(item.chgStID);
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._setupID = tables.EVT_setupQst01.GetItemOrNull(item.setupID);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (EVT_listTlk01 item in tables.EVT_listTlk01.Items)
            {
                item._category = (EventCategory)item.category;
                item._chgEdID = tables.EVT_chgTlk01.GetItemOrNull(item.chgEdID);
                item._chgStID = tables.EVT_chgTlk01.GetItemOrNull(item.chgStID);
                item._edFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.edFormID);
                item._setupID = tables.EVT_setupTlk01.GetItemOrNull(item.setupID);
                item._stFormID = tables.SYS_MapJumpEvList.GetItemOrNull(item.stFormID);
                item._zoneID = tables.FLD_maplist.GetItemOrNull(item.zoneID);
            }

            foreach (FLD_AchievementList item in tables.FLD_AchievementList.Items)
            {
                item._Task = tables.FLD_QuestListAchievement.GetItemOrNull(item.Task);
            }

            foreach (FLD_AchievementSet item in tables.FLD_AchievementSet.Items)
            {
                item._AchievementID1 = tables.FLD_AchievementList.GetItemOrNull(item.AchievementID1);
                item._AchievementID2 = tables.FLD_AchievementList.GetItemOrNull(item.AchievementID2);
                item._AchievementID3 = tables.FLD_AchievementList.GetItemOrNull(item.AchievementID3);
                item._AchievementID4 = tables.FLD_AchievementList.GetItemOrNull(item.AchievementID4);
                item._AchievementID5 = tables.FLD_AchievementList.GetItemOrNull(item.AchievementID5);
                item._AchievementID = new[]
                {
                    item._AchievementID1,
                    item._AchievementID2,
                    item._AchievementID3,
                    item._AchievementID4,
                    item._AchievementID5
                };
            }

            foreach (FLD_AddItem item in tables.FLD_AddItem.Items)
            {
                item._ItemID1 = tables.GetItem(item.ItemID1);
                item._ItemID2 = tables.GetItem(item.ItemID2);
                item._ItemID3 = tables.GetItem(item.ItemID3);
            }

            foreach (FLD_AntiBladeArea item in tables.FLD_AntiBladeArea.Items)
            {
                item._BTL_MapRevId = tables.BTL_MapRev.GetItemOrNull(item.BTL_MapRevId);
            }

            foreach (FLD_BladePop item in tables.FLD_BladePop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (FLD_CampPop item in tables.FLD_CampPop.Items)
            {
                item._CampPointName = tables.fld_camppoint.GetItemOrNull(item.CampPointName);
                item._ConditionID = tables.FLD_ConditionList.GetItemOrNull(item.ConditionID);
            }

            foreach (FLD_ClimbingPOP item in tables.FLD_ClimbingPOP.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_CollectionTable item in tables.FLD_CollectionTable.Items)
            {
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
            }

            foreach (FLD_ConditionAchievement item in tables.FLD_ConditionAchievement.Items)
            {
                item._AchievementSetID = tables.FLD_AchievementSet.GetItemOrNull(item.AchievementSetID);
            }

            foreach (FLD_ConditionEnv item in tables.FLD_ConditionEnv.Items)
            {
                item._CloudHeight = tables.EVT_cloudtype.GetItemOrNull(item.CloudHeight);
                item._TimeRange = (TimeRange)item.TimeRange;
                item._Weather = (WeatherBits)item.Weather;
            }

            foreach (FLD_ConditionFieldSkiiLevel item in tables.FLD_ConditionFieldSkiiLevel.Items)
            {
                item._FieldSkillID = tables.FLD_FieldSkillList.GetItemOrNull(item.FieldSkillID);
            }

            foreach (FLD_ConditionItem item in tables.FLD_ConditionItem.Items)
            {
                item._ItemID = tables.GetItem(item.ItemID);
            }

            foreach (FLD_ConditionList item in tables.FLD_ConditionList.Items)
            {
                item._Condition1 = tables.GetCondition((ConditionType)item.ConditionType1, item.Condition1);
                item._Condition2 = tables.GetCondition((ConditionType)item.ConditionType2, item.Condition2);
                item._Condition3 = tables.GetCondition((ConditionType)item.ConditionType3, item.Condition3);
                item._Condition4 = tables.GetCondition((ConditionType)item.ConditionType4, item.Condition4);
                item._Condition5 = tables.GetCondition((ConditionType)item.ConditionType5, item.Condition5);
                item._Condition6 = tables.GetCondition((ConditionType)item.ConditionType6, item.Condition6);
                item._Condition7 = tables.GetCondition((ConditionType)item.ConditionType7, item.Condition7);
                item._Condition8 = tables.GetCondition((ConditionType)item.ConditionType8, item.Condition8);
                item._ConditionType1 = (ConditionType)item.ConditionType1;
                item._ConditionType2 = (ConditionType)item.ConditionType2;
                item._ConditionType3 = (ConditionType)item.ConditionType3;
                item._ConditionType4 = (ConditionType)item.ConditionType4;
                item._ConditionType5 = (ConditionType)item.ConditionType5;
                item._ConditionType6 = (ConditionType)item.ConditionType6;
                item._ConditionType7 = (ConditionType)item.ConditionType7;
                item._ConditionType8 = (ConditionType)item.ConditionType8;
                item._Premise = tables.EVT_andortype.GetItemOrNull(item.Premise + 1);
            }

            foreach (FLD_ConditionPT item in tables.FLD_ConditionPT.Items)
            {
                item._Category = (PartyConditionType)item.Category;
            }

            foreach (FLD_DMGFloor item in tables.FLD_DMGFloor.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MAPID = tables.FLD_maplist.GetItemOrNull(item.MAPID);
            }

            foreach (FLD_DMGGimmick item in tables.FLD_DMGGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._DEPOP_Condition = tables.FLD_ConditionList.GetItemOrNull(item.DEPOP_Condition);
            }

            foreach (FLD_DoorGimmick item in tables.FLD_DoorGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._LODmodel = tables.FLD_LODList.GetItemOrNull(item.LODmodel);
            }

            foreach (FLD_EffectPop item in tables.FLD_EffectPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_ElevatorGimmick item in tables.FLD_ElevatorGimmick.Items)
            {
                item._OP_Condition = tables.FLD_ConditionList.GetItemOrNull(item.OP_Condition);
            }

            foreach (FLD_EnemyGroup item in tables.FLD_EnemyGroup.Items)
            {
                item._EnemyID1 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID1);
                item._EnemyID10 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID10);
                item._EnemyID11 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID11);
                item._EnemyID12 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID12);
                item._EnemyID2 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID2);
                item._EnemyID3 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID3);
                item._EnemyID4 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID4);
                item._EnemyID5 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID5);
                item._EnemyID6 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID6);
                item._EnemyID7 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID7);
                item._EnemyID8 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID8);
                item._EnemyID9 = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID9);
            }

            foreach (FLD_EnemyWave item in tables.FLD_EnemyWave.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_EnemyWaveIra item in tables.FLD_EnemyWaveIra.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_FieldLockGimmick item in tables.FLD_FieldLockGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_FieldSkillList item in tables.FLD_FieldSkillList.Items)
            {
                item._Attirbute = tables.MNU_Msg_Attr.GetItemOrNull(item.Attirbute + 1);
                item._Caption = tables.fld_fieldskilltxt.GetItemOrNull(item.Caption);
                item._Category = (FieldSkillCategory)item.Category;
                item._Name = tables.fld_fieldskilltxt.GetItemOrNull(item.Name);
                item._RandomID = tables.FLD_FieldSkillRandom.GetItemOrNull(item.RandomID);
            }

            foreach (FLD_FieldSkillSetting item in tables.FLD_FieldSkillSetting.Items)
            {
                item._FieldSkillID1 = tables.FLD_FieldSkillList.GetItemOrNull(item.FieldSkillID1);
                item._FieldSkillID2 = tables.FLD_FieldSkillList.GetItemOrNull(item.FieldSkillID2);
                item._Name = tables.fld_fieldskillplace.GetItemOrNull(item.Name);
            }

            foreach (FLD_FootPrintsRoutes item in tables.FLD_FootPrintsRoutes.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_JumpGimmick item in tables.FLD_JumpGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
            }

            foreach (FLD_KizunaTalk item in tables.FLD_KizunaTalk.Items)
            {
                item._ConditionID = tables.FLD_ConditionList.GetItemOrNull(item.ConditionID);
                item._EVCondition = tables.FLD_ConditionList.GetItemOrNull(item.EVCondition);
                item._EventID = tables.EVT_listFev01.GetItemOrNull(item.EventID);
                item._Title = tables.fld_kizunatalktitle.GetItemOrNull(item.Title);
            }

            foreach (FLD_LODList item in tables.FLD_LODList.Items)
            {
                item._Condition1 = tables.FLD_ConditionList.GetItemOrNull(item.Condition1);
                item._Condition2 = tables.FLD_ConditionList.GetItemOrNull(item.Condition2);
                item._Condition3 = tables.FLD_ConditionList.GetItemOrNull(item.Condition3);
            }

            foreach (FLD_MapGimmick item in tables.FLD_MapGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._OP_Condition = tables.FLD_ConditionList.GetItemOrNull(item.OP_Condition);
                item._tgtMSG_ID = tables.fld_gmkname.GetItemOrNull(item.tgtMSG_ID);
            }

            foreach (FLD_MapJump item in tables.FLD_MapJump.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (FLD_maplist item in tables.FLD_maplist.Items)
            {
                item._bgm_cndID = tables.RSC_BgmCondition.GetItemOrNull(item.bgm_cndID);
                item._change_nameID = tables.fld_mapinfo.GetItemOrNull(item.change_nameID);
                item._ebb_inn_cndID = tables.FLD_ConditionList.GetItemOrNull(item.ebb_inn_cndID);
                item._ebb_ON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.ebb_ON_cndID);
                item._mapON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.mapON_cndID);
                item._name_cndID = tables.FLD_ConditionList.GetItemOrNull(item.name_cndID);
                item._nameID = tables.fld_mapinfo.GetItemOrNull(item.nameID);
                item._st_allOFF_cndID = tables.FLD_ConditionList.GetItemOrNull(item.st_allOFF_cndID);
                item._stopTIME_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stopTIME_cndID);
                item._wa_OFF_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wa_OFF_cndID);
                item._wa_ON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wa_ON_cndID);
                item._wa_time_BNS = (TimeRange)item.wa_time_BNS;
                item._wa_type = tables.FLD_WeatherInfo.GetItemOrNull(item.wa_type);
                item._wb_OFF_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wb_OFF_cndID);
                item._wb_ON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wb_ON_cndID);
                item._wb_time_BNS = (TimeRange)item.wb_time_BNS;
                item._wb_type = tables.FLD_WeatherInfo.GetItemOrNull(item.wb_type);
                item._wc_OFF_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wc_OFF_cndID);
                item._wc_ON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wc_ON_cndID);
                item._wc_time_BNS = (TimeRange)item.wc_time_BNS;
                item._wc_type = tables.FLD_WeatherInfo.GetItemOrNull(item.wc_type);
                item._wd_OFF_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wd_OFF_cndID);
                item._wd_ON_cndID = tables.FLD_ConditionList.GetItemOrNull(item.wd_ON_cndID);
                item._wd_time_BNS = (TimeRange)item.wd_time_BNS;
                item._wd_type = tables.FLD_WeatherInfo.GetItemOrNull(item.wd_type);
                item._zone = tables.fld_developmentname.GetItemOrNull(item.zone);
            }

            foreach (FLD_MercenariesMission item in tables.FLD_MercenariesMission.Items)
            {
                item._AutoStart = tables.FLD_ConditionList.GetItemOrNull(item.AutoStart);
                item._QuestID = tables.FLD_QuestListMercenaries.GetItemOrNull(item.QuestID);
            }

            foreach (FLD_MobGroupList item in tables.FLD_MobGroupList.Items)
            {
                item._MOBID1 = tables.RSC_MobList.GetItemOrNull(item.MOBID1);
                item._MOBID2 = tables.RSC_MobList.GetItemOrNull(item.MOBID2);
                item._MOBID3 = tables.RSC_MobList.GetItemOrNull(item.MOBID3);
                item._MOBID4 = tables.RSC_MobList.GetItemOrNull(item.MOBID4);
                item._MOBID5 = tables.RSC_MobList.GetItemOrNull(item.MOBID5);
                item._MOBID6 = tables.RSC_MobList.GetItemOrNull(item.MOBID6);
                item._MOBID7 = tables.RSC_MobList.GetItemOrNull(item.MOBID7);
                item._MOBID8 = tables.RSC_MobList.GetItemOrNull(item.MOBID8);
            }

            foreach (FLD_NpcGroupId item in tables.FLD_NpcGroupId.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (FLD_OwnerBonus item in tables.FLD_OwnerBonus.Items)
            {
                item._Type = tables.FLD_OwnerBonusParam.GetItemOrNull(item.Type);
            }

            foreach (FLD_QuestBattle item in tables.FLD_QuestBattle.Items)
            {
                item._EnemyGroupID = tables.FLD_EnemyGroup.GetItemOrNull(item.EnemyGroupID);
                item._EnemyID = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID);
                item._EnemySpeciesID = tables.RSC_EnGenus.GetItemOrNull(item.EnemySpeciesID);
            }

            foreach (FLD_QuestCollect item in tables.FLD_QuestCollect.Items)
            {
                item._Category = tables.menu_collectionitemtype.GetItemOrNull(item.Category - 3);
                item._EnemyID = tables.CHR_EnArrange.GetItemOrNull(item.EnemyID);
                item._ItemID = tables.GetItem(item.ItemID);
                item._MapID = tables.FLD_maplist.GetItemOrNull(item.MapID);
            }

            foreach (FLD_QuestCondition item in tables.FLD_QuestCondition.Items)
            {
                item._ConditionID = tables.FLD_ConditionList.GetItemOrNull(item.ConditionID);
                item._MapID = tables.FLD_maplist.GetItemOrNull(item.MapID);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
            }

            foreach (FLD_QuestFieldSkillCount item in tables.FLD_QuestFieldSkillCount.Items)
            {
                item._FieldSkillID = tables.FLD_FieldSkillList.GetItemOrNull(item.FieldSkillID);
            }

            foreach (FLD_QuestGimmick item in tables.FLD_QuestGimmick.Items)
            {
                item._MapID = tables.FLD_maplist.GetItemOrNull(item.MapID);
            }

            foreach (FLD_QuestHints item in tables.FLD_QuestHints.Items)
            {
                item._ClientNpc = tables.RSC_NpcList.GetItemOrNull(item.ClientNpc);
                item._FSkillID1 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkillID1);
                item._FSkillID2 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkillID2);
                item._FSkillID3 = tables.FLD_FieldSkillList.GetItemOrNull(item.FSkillID3);
                item._ZoneID = tables.FLD_maplist.GetItemOrNull(item.ZoneID);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestList.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestList.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestList.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestList.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestList.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTask.GetItemOrNull(item.PurposeID);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListAchievement.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListAchievement.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListAchievement.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListAchievement.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListAchievement.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskAchievement.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_achievement.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_achievement.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_achievement.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_achievement.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListBlade.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListBlade.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListBlade.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListBlade.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListBlade.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskBlade.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_blade.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_blade.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_blade.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_blade.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListIra.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListIra.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListIra.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListIra.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListIra.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskIra.GetItemOrNull(item.PurposeID);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListMercenaries.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListMercenaries.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListMercenaries.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListMercenaries.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListMercenaries.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskMercenaries.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_mercenaries.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_mercenaries.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_mercenaries.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_mercenaries.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListMini.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListMini.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListMini.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListMini.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListMini.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskMini.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_mini.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_mini.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_mini.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_mini.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListNormal.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListNormal.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListNormal.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListNormal.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListNormal.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskNormal.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_normal.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_normal.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_normal.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_normal.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestList item in tables.FLD_QuestListNormalIra.Items)
            {
                item._HintsID = tables.FLD_QuestHints.GetItemOrNull(item.HintsID);
                item._LinkedQuestID = tables.FLD_QuestListNormalIra.GetItemOrNull(item.LinkedQuestID);
                item._NextQuestA = tables.FLD_QuestListNormalIra.GetItemOrNull(item.NextQuestA);
                item._NextQuestB = tables.FLD_QuestListNormalIra.GetItemOrNull(item.NextQuestB);
                item._PRTQuestID = tables.FLD_QuestListNormalIra.GetItemOrNull(item.PRTQuestID);
                item._PurposeID = tables.FLD_QuestTaskNormalIra.GetItemOrNull(item.PurposeID);
                item._QuestTitle = tables.fld_quest_normal.GetItemOrNull(item.QuestTitle);
                item._ResultA = tables.fld_quest_normal.GetItemOrNull(item.ResultA);
                item._ResultB = tables.fld_quest_normal.GetItemOrNull(item.ResultB);
                item._RewardSetA = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetA);
                item._RewardSetB = tables.FLD_QuestReward.GetItemOrNull(item.RewardSetB);
                item._Summary = tables.fld_quest_normal.GetItemOrNull(item.Summary);
            }

            foreach (FLD_QuestReach item in tables.FLD_QuestReach.Items)
            {
                item._MapID = tables.FLD_maplist.GetItemOrNull(item.MapID);
            }

            foreach (FLD_QuestReward item in tables.FLD_QuestReward.Items)
            {
                item._DevelopZone = tables.FLD_maplist.GetItemOrNull(item.DevelopZone);
                item._ItemID1 = tables.GetItem(item.ItemID1);
                item._ItemID2 = tables.GetItem(item.ItemID2);
                item._ItemID3 = tables.GetItem(item.ItemID3);
                item._ItemID4 = tables.GetItem(item.ItemID4);
                item._ItemID = new[]
                {
                    item._ItemID1,
                    item._ItemID2,
                    item._ItemID3,
                    item._ItemID4
                };
                item._ItemNumber = new[]
                {
                    item.ItemNumber1,
                    item.ItemNumber2,
                    item.ItemNumber3,
                    item.ItemNumber4
                };
            }

            foreach (FLD_QuestTalk item in tables.FLD_QuestTalk.Items)
            {
                item._DummyGroup = tables.FLD_QuestTalkDummyGroup.GetItemOrNull(item.DummyGroup);
                item._MapID = tables.FLD_maplist.GetItemOrNull(item.MapID);
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTask.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskAchievement.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest_achievement.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest_achievement.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest_achievement.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest_achievement.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskBlade.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest_blade.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest_blade.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest_blade.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest_blade.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskIra.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskMercenaries.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskMini.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest_mini.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest_mini.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest_mini.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest_mini.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskNormal.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestTask item in tables.FLD_QuestTaskNormalIra.Items)
            {
                item._TaskCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition1);
                item._TaskCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition2);
                item._TaskCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition3);
                item._TaskCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.TaskCondition4);
                item._TaskID1 = tables.GetTask((TaskType)item.TaskType1, item.TaskID1);
                item._TaskID2 = tables.GetTask((TaskType)item.TaskType2, item.TaskID2);
                item._TaskID3 = tables.GetTask((TaskType)item.TaskType3, item.TaskID3);
                item._TaskID4 = tables.GetTask((TaskType)item.TaskType4, item.TaskID4);
                item._TaskLog1 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog1);
                item._TaskLog2 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog2);
                item._TaskLog3 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog3);
                item._TaskLog4 = tables.fld_quest_normal.GetItemOrNull(item.TaskLog4);
                item._TaskType1 = (TaskType)item.TaskType1;
                item._TaskType2 = (TaskType)item.TaskType2;
                item._TaskType3 = (TaskType)item.TaskType3;
                item._TaskType4 = (TaskType)item.TaskType4;
            }

            foreach (FLD_QuestUse item in tables.FLD_QuestUse.Items)
            {
                item._bladeID = tables.CHR_Bl.GetItemOrNull(item.bladeID);
                item._Category = tables.menu_favorite_category.GetItemOrNull(item.Category - 11);
                item._ItemID = tables.GetItem(item.ItemID);
            }

            foreach (FLD_randomTalk item in tables.FLD_randomTalk.Items)
            {
                item._text0 = tables.fld_randomtalk.GetItemOrNull(item.text0);
                item._text1 = tables.fld_randomtalk.GetItemOrNull(item.text1);
                item._type = tables.EVT_randtype.GetItemOrNull(item.type);
            }

            foreach (FLD_SalvageEnemySet item in tables.FLD_SalvageEnemySet.Items)
            {
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
            }

            foreach (FLD_SalvageItemSet item in tables.FLD_SalvageItemSet.Items)
            {
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
                item._itmID = new[]
                {
                    item._itm1ID,
                    item._itm2ID,
                    item._itm3ID,
                    item._itm4ID,
                    item._itm5ID,
                    item._itm6ID,
                    item._itm7ID,
                    item._itm8ID
                };
                item._itmNum = new[]
                {
                    item.itm1Num,
                    item.itm2Num,
                    item.itm3Num,
                    item.itm4Num,
                    item.itm5Num,
                    item.itm6Num,
                    item.itm7Num,
                    item.itm8Num
                };
                item._itmPer = new[]
                {
                    item.itm1Per,
                    item.itm2Per,
                    item.itm3Per,
                    item.itm4Per,
                    item.itm5Per,
                    item.itm6Per,
                    item.itm7Per,
                    item.itm8Per
                };
            }

            foreach (FLD_SalvagePointList item in tables.FLD_SalvagePointList.Items)
            {
                item._BtnChallenge0 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChallenge0);
                item._BtnChallenge1 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChallenge1);
                item._BtnChallenge2 = tables.MNU_BtnChallenge2.GetItemOrNull(item.BtnChallenge2);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._SalvagePointName = tables.fld_salvagepoint.GetItemOrNull(item.SalvagePointName);
                item._SalvageTable1 = tables.FLD_SalvageTable.GetItemOrNull(item.SalvageTable1);
                item._SalvageTable2 = tables.FLD_SalvageTable.GetItemOrNull(item.SalvageTable2);
                item._SalvageTable3 = tables.FLD_SalvageTable.GetItemOrNull(item.SalvageTable3);
                item._SalvageTable4 = tables.FLD_SalvageTable.GetItemOrNull(item.SalvageTable4);
                item._SalvageTable5 = tables.FLD_SalvageTable.GetItemOrNull(item.SalvageTable5);
                item._SpecialItem = tables.GetItem(item.SpecialItem);
                item._BtnChallenge = new[]
                {
                    item._BtnChallenge0,
                    item._BtnChallenge1,
                    item._BtnChallenge2
                };
                item._SalvageTable = new[]
                {
                    item._SalvageTable1,
                    item._SalvageTable2,
                    item._SalvageTable3,
                    item._SalvageTable4,
                    item._SalvageTable5
                };
            }

            foreach (FLD_SalvageTable item in tables.FLD_SalvageTable.Items)
            {
                item._ColleTable1 = tables.FLD_SalvageItemSet.GetItemOrNull(item.ColleTable1);
                item._ColleTable2 = tables.FLD_SalvageItemSet.GetItemOrNull(item.ColleTable2);
                item._ColleTable3 = tables.FLD_SalvageItemSet.GetItemOrNull(item.ColleTable3);
                item._EnemyPopTable1 = tables.FLD_SalvageEnemySet.GetItemOrNull(item.EnemyPopTable1);
                item._EnemyPopTable2 = tables.FLD_SalvageEnemySet.GetItemOrNull(item.EnemyPopTable2);
                item._EnemyPopTable3 = tables.FLD_SalvageEnemySet.GetItemOrNull(item.EnemyPopTable3);
                item._TresureTable1 = tables.FLD_SalvageItemSet.GetItemOrNull(item.TresureTable1);
                item._TresureTable2 = tables.FLD_SalvageItemSet.GetItemOrNull(item.TresureTable2);
                item._TresureTable3 = tables.FLD_SalvageItemSet.GetItemOrNull(item.TresureTable3);
                item._ColleTable = new[]
                {
                    item._ColleTable1,
                    item._ColleTable2,
                    item._ColleTable3
                };
                item._ColleTablePercent = new[]
                {
                    item.ColleTablePercent1,
                    item.ColleTablePercent2,
                    item.ColleTablePercent3
                };
                item._EnemyPopTable = new[]
                {
                    item._EnemyPopTable1,
                    item._EnemyPopTable2,
                    item._EnemyPopTable3
                };
                item._EnemyPopTablePercent = new[]
                {
                    item.EnemyPopTablePercent1,
                    item.EnemyPopTablePercent2,
                    item.EnemyPopTablePercent3
                };
                item._TresureTable = new[]
                {
                    item._TresureTable1,
                    item._TresureTable2,
                    item._TresureTable3
                };
                item._TresureTablePercent = new[]
                {
                    item.TresureTablePercent1,
                    item.TresureTablePercent2,
                    item.TresureTablePercent3
                };
            }

            foreach (FLD_SePop item in tables.FLD_SePop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._SEpopTime = (TimeRange)item.SEpopTime;
            }

            foreach (FLD_TimeInfo item in tables.FLD_TimeInfo.Items)
            {
                item._msg = tables.fld_mapinfo.GetItemOrNull(item.msg);
            }

            foreach (FLD_WarpGimmick item in tables.FLD_WarpGimmick.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
            }

            foreach (FLD_WeatherInfo item in tables.FLD_WeatherInfo.Items)
            {
                item._msg = tables.fld_mapinfo.GetItemOrNull(item.msg);
            }

            foreach (IRA_Party item in tables.IRA_Party.Items)
            {
                item._blade11 = tables.CHR_Dr.GetItemOrNull(item.blade11);
                item._blade12 = tables.CHR_Dr.GetItemOrNull(item.blade12);
                item._blade21 = tables.CHR_Dr.GetItemOrNull(item.blade21);
                item._blade22 = tables.CHR_Dr.GetItemOrNull(item.blade22);
                item._blade31 = tables.CHR_Dr.GetItemOrNull(item.blade31);
                item._blade32 = tables.CHR_Dr.GetItemOrNull(item.blade32);
                item._driver11 = tables.CHR_Dr.GetItemOrNull(item.driver11);
                item._driver21 = tables.CHR_Dr.GetItemOrNull(item.driver21);
                item._driver31 = tables.CHR_Dr.GetItemOrNull(item.driver31);
            }

            foreach (ITM_BoosterList item in tables.ITM_BoosterList.Items)
            {
                item._Category = tables.menu_ideacollar_ms.GetItemOrNull(item.Category + 1);
                item._Name = tables.itm_booster.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
            }

            foreach (ITM_CollectionList item in tables.ITM_CollectionList.Items)
            {
                item._Category = tables.menu_collectionitemtype.GetItemOrNull(item.Category - 3);
                item._Name = tables.itm_collection.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Zone = tables.FLD_maplist.GetItemOrNull(item.Zone);
            }

            foreach (ITM_CrystalList item in tables.ITM_CrystalList.Items)
            {
                item._BladeID = tables.CHR_Bl.GetItemOrNull(item.BladeID);
                item._CommonAtr = tables.MNU_Msg_Attr.GetItemOrNull(item.CommonAtr + 1);
                item._CommonWpn = tables.ITM_PcWpnType.GetItemOrNull(item.CommonWpn);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Name = tables.itm_crystal.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
            }

            foreach (ITM_EventList item in tables.ITM_EventList.Items)
            {
                item._Caption = tables.itm_evt.GetItemOrNull(item.Caption);
                item._Name = tables.itm_evt.GetItemOrNull(item.Name);
            }

            foreach (ITM_FavoriteList item in tables.ITM_FavoriteList.Items)
            {
                item._Category = tables.menu_favorite_category.GetItemOrNull(item.Category - 11);
                item._Name = tables.itm_favorite.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Type = tables.BTL_PouchBuffSet.GetItemOrNull(item.Type);
                item._Zone = tables.FLD_maplist.GetItemOrNull(item.Zone);
            }

            foreach (ITM_HanaArtsEnh item in tables.ITM_HanaArtsEnh.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._Name = tables.itm_orb.GetItemOrNull(item.Name);
            }

            foreach (ITM_HanaAssist item in tables.ITM_HanaAssist.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._Name = tables.itm_orb.GetItemOrNull(item.Name);
            }

            foreach (ITM_HanaAtr item in tables.ITM_HanaAtr.Items)
            {
                item._Atr = tables.MNU_Msg_Attr.GetItemOrNull(item.Atr + 1);
                item._Caption = tables.itm_hana_atr_ms.GetItemOrNull(item.Caption);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Name = tables.itm_hana_atr_ms.GetItemOrNull(item.Name);
            }

            foreach (ITM_HanaNArtsSet item in tables.ITM_HanaNArtsSet.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Name = tables.itm_hana_narts_set_ms.GetItemOrNull(item.Name);
                item._NArts = tables.BTL_Buff.GetItemOrNull(item.NArts);
            }

            foreach (ITM_HanaRole item in tables.ITM_HanaRole.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Name = tables.itm_hana_role_ms.GetItemOrNull(item.Name);
                item._Role = tables.menu_role_name_ms.GetItemOrNull(item.Role);
            }

            foreach (ITM_InfoList item in tables.ITM_InfoList.Items)
            {
                item._Caption = tables.itm_info.GetItemOrNull(item.Caption);
                item._Name = tables.itm_info.GetItemOrNull(item.Name);
            }

            foreach (ITM_Orb item in tables.ITM_Orb.Items)
            {
                item._EquipItemID = tables.GetItem(item.EquipItemID);
                item._Name = tables.itm_orb.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Recipe = tables.ITM_OrbRecipe.GetItemOrNull(item.Recipe);
            }

            foreach (ITM_OrbEquip item in tables.ITM_OrbEquip.Items)
            {
                item._Enhance = tables.BTL_Enhance.GetItemOrNull(item.Enhance);
                item._Name = tables.itm_orb.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
            }

            foreach (ITM_OrbRecipe item in tables.ITM_OrbRecipe.Items)
            {
                item._ItemID1 = tables.GetItem(item.ItemID1);
                item._ItemID2 = tables.GetItem(item.ItemID2);
                item._ItemID3 = tables.GetItem(item.ItemID3);
                item._ItemID4 = tables.GetItem(item.ItemID4);
                item._ItemID5 = tables.GetItem(item.ItemID5);
                item._ItemID6 = tables.GetItem(item.ItemID6);
                item._ItemID7 = tables.GetItem(item.ItemID7);
                item._ItemID8 = tables.GetItem(item.ItemID8);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._RecipeType = (RecipeType)item.RecipeType;
                item._RscCat = tables.menu_collectionitemtype.GetItemOrNull(item.RscCat - 3);
            }

            foreach (ITM_PcEquip item in tables.ITM_PcEquip.Items)
            {
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Name = tables.itm_pcequip.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Zone = tables.FLD_maplist.GetItemOrNull(item.Zone);
                item._Zone2 = tables.FLD_maplist.GetItemOrNull(item.Zone2);
            }

            foreach (ITM_PcWpn item in tables.ITM_PcWpn.Items)
            {
                item._Enhance1 = tables.BTL_Enhance.GetItemOrNull(item.Enhance1);
                item._Enhance2 = tables.BTL_Enhance.GetItemOrNull(item.Enhance2);
                item._Name = tables.itm_pcwpn_ms.GetItemOrNull(item.Name);
                item._RscL = tables.RSC_PcWpn.GetItemOrNull(item.RscL);
                item._RscR = tables.RSC_PcWpn.GetItemOrNull(item.RscR);
                item._WpnType = tables.ITM_PcWpnType.GetItemOrNull(item.WpnType);
            }

            foreach (ITM_PcWpnChip item in tables.ITM_PcWpnChip.Items)
            {
                item._CreateWpn1 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn1);
                item._CreateWpn10 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn10);
                item._CreateWpn11 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn11);
                item._CreateWpn12 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn12);
                item._CreateWpn13 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn13);
                item._CreateWpn14 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn14);
                item._CreateWpn15 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn15);
                item._CreateWpn16 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn16);
                item._CreateWpn17 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn17);
                item._CreateWpn18 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn18);
                item._CreateWpn19 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn19);
                item._CreateWpn2 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn2);
                item._CreateWpn20 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn20);
                item._CreateWpn21 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn21);
                item._CreateWpn22 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn22);
                item._CreateWpn23 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn23);
                item._CreateWpn24 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn24);
                item._CreateWpn25 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn25);
                item._CreateWpn26 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn26);
                item._CreateWpn27 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn27);
                item._CreateWpn28 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn28);
                item._CreateWpn29 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn29);
                item._CreateWpn3 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn3);
                item._CreateWpn30 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn30);
                item._CreateWpn31 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn31);
                item._CreateWpn32 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn32);
                item._CreateWpn33 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn33);
                item._CreateWpn34 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn34);
                item._CreateWpn4 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn4);
                item._CreateWpn5 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn5);
                item._CreateWpn6 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn6);
                item._CreateWpn7 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn7);
                item._CreateWpn8 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn8);
                item._CreateWpn9 = tables.ITM_PcWpn.GetItemOrNull(item.CreateWpn9);
                item._Name = tables.itm_pcwpnchip_ms.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Zone = tables.FLD_maplist.GetItemOrNull(item.Zone);
                item._Zone2 = tables.FLD_maplist.GetItemOrNull(item.Zone2);
                item._CreateWpn = new[]
                {
                    item._CreateWpn1,
                    item._CreateWpn2,
                    item._CreateWpn3,
                    item._CreateWpn4,
                    item._CreateWpn5,
                    item._CreateWpn6,
                    item._CreateWpn7,
                    item._CreateWpn8,
                    item._CreateWpn9,
                    item._CreateWpn10,
                    item._CreateWpn11,
                    item._CreateWpn12,
                    item._CreateWpn13,
                    item._CreateWpn14,
                    item._CreateWpn15,
                    item._CreateWpn16
                };
                item._Zones = new[]
                {
                    item._Zone,
                    item._Zone2
                };
            }

            foreach (ITM_PcWpnType item in tables.ITM_PcWpnType.Items)
            {
                item._Motion = tables.ITM_PcWpnType.GetItemOrNull(item.Motion);
                item._Name = tables.itm_pcwpntype_ms.GetItemOrNull(item.Name);
                item._Role = tables.menu_role_name_ms.GetItemOrNull(item.Role);
            }

            foreach (ITM_PreciousList item in tables.ITM_PreciousList.Items)
            {
                item._Caption = tables.itm_precious.GetItemOrNull(item.Caption);
                item._Name = tables.itm_precious.GetItemOrNull(item.Name);
                item._Type = tables.FLD_OwnerBonus.GetItemOrNull(item.Type);
            }

            foreach (ITM_SalvageList item in tables.ITM_SalvageList.Items)
            {
                item._Caption = tables.itm_salvage.GetItemOrNull(item.Caption);
                item._Name = tables.itm_salvage.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
            }

            foreach (ITM_TresureList item in tables.ITM_TresureList.Items)
            {
                item._Name = tables.itm_tresure.GetItemOrNull(item.Name);
                item._Rarity = tables.menu_rarity.GetItemOrNull(item.Rarity + 1);
                item._Zone = tables.FLD_maplist.GetItemOrNull(item.Zone);
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma01a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_LandmarkPop item in tables.ma01a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma01a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma01a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma02a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma02a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma02a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma02.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma02a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma02a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma02a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma02a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma02a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma02a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma02a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma02a_FLD_TboxPop item in tables.ma02a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma03a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma03a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma03a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma03.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_EventPop item in tables.ma03a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma03a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma03a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma03a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma03a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma03a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma04a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma04a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma04a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma02.GetItemOrNull(item.Text);
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma04a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma04a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma04a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma04a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma04a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma04a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma04a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma04a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma05a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma05a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma05a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma05.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma05a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma05a_FLD_EnemyPop item in tables.ma05a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma05a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma05a_FLD_LandmarkPop item in tables.ma05a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma05a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma05a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma05a_FLD_NpcPop item in tables.ma05a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._FSID4 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID4);
                item._FSID5 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID5);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma05a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma05a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma05c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma07a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma07a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma07a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma07.GetItemOrNull(item.Text);
            }

            foreach (ma07a_FLD_CollectionPopList item in tables.ma07a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma07a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma07a_FLD_EventPop item in tables.ma07a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma07a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma07a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma07a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma07a_FLD_NpcPop item in tables.ma07a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma07a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma07a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma07c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma08a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma08a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma08a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma08.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma08a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma08a_FLD_EnemyPop item in tables.ma08a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma08a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma08a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma08a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma08a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma08a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma08a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma08a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma08c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma10a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma10a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma10a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma10.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma10a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma10a_FLD_EnemyPop item in tables.ma10a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma10a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma10a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma10a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma10a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma10a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma10a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma10a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma10c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma11a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma11a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma11a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma11.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma11a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma11a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma11a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma11a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma11a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma11a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma11a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma11a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma11a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma13a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma13a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma13a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma13.GetItemOrNull(item.Text);
            }

            foreach (ma07a_FLD_CollectionPopList item in tables.ma13a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma08a_FLD_EnemyPop item in tables.ma13a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma13a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma13a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma13a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma13a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma05a_FLD_NpcPop item in tables.ma13a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._FSID4 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID4);
                item._FSID5 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID5);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma13a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma02a_FLD_TboxPop item in tables.ma13a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma13c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma15a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma15a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma15a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma15.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma15a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma15a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma15a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma15a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma15a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma15a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma15a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma15a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma15a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma15c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma16a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma16a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma16a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma16a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma16a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma16a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma16a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma16a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma17a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma08a_FLD_EnemyPop item in tables.ma17a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma17a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma17a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma17a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma17a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma17a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma17c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma18a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma05a_FLD_EnemyPop item in tables.ma18a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma18a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma18a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma18a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma18a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma18a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma18a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma18c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma20a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma20a_FLD_EnemyPop item in tables.ma20a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma20a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma20a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma20a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma20a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma20a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma20a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma05c_FLD_EnemyPop item in tables.ma20c_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma21a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma10a_FLD_EnemyPop item in tables.ma21a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma21a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma02a_FLD_LandmarkPop item in tables.ma21a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma21a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma21a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma21a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_EventPop item in tables.ma30a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma01a_FLD_LandmarkPop item in tables.ma30a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma30a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma40a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma40a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma40a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma40.GetItemOrNull(item.Text);
            }

            foreach (ma40a_FLD_CollectionPopList item in tables.ma40a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma40a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma40a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma05a_FLD_LandmarkPop item in tables.ma40a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma40a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma40a_FLD_MobPop item in tables.ma40a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma40a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma40a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma40a_FLD_TboxPop item in tables.ma40a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma41a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma41a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma41a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma41.GetItemOrNull(item.Text);
            }

            foreach (ma41a_FLD_CollectionPopList item in tables.ma41a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma41a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma41a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma05a_FLD_LandmarkPop item in tables.ma41a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma41a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma40a_FLD_MobPop item in tables.ma41a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma41a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma02a_FLD_TboxPop item in tables.ma41a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma42a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma49c_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma05a_FLD_LandmarkPop item in tables.ma49c_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._menuGroup = tables.MNU_MapGroup.GetItemOrNull(item.menuGroup);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma49c_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_LandmarkPop item in tables.ma50a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma50a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma50a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma02a_FLD_AutoTalk item in tables.ma90a_FLD_AutoTalk.Items)
            {
                item._BeforeID = tables.ma90a_FLD_AutoTalk.GetItemOrNull(item.BeforeID);
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._MOBID = tables.ma90a_FLD_MobPop.GetItemOrNull(item.MOBID);
                item._Text = tables.autotalk_ma02.GetItemOrNull(item.Text);
            }

            foreach (ma02a_FLD_CollectionPopList item in tables.ma90a_FLD_CollectionPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillList.GetItemOrNull(item.FSID);
                item._itm1ID = tables.ITM_CollectionList.GetItemOrNull(item.itm1ID);
                item._itm2ID = tables.ITM_CollectionList.GetItemOrNull(item.itm2ID);
                item._itm3ID = tables.ITM_CollectionList.GetItemOrNull(item.itm3ID);
                item._itm4ID = tables.ITM_CollectionList.GetItemOrNull(item.itm4ID);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma01a_FLD_EnemyPop item in tables.ma90a_FLD_EnemyPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._ene1ID = tables.CHR_EnArrange.GetItemOrNull(item.ene1ID);
                item._ene2ID = tables.CHR_EnArrange.GetItemOrNull(item.ene2ID);
                item._ene3ID = tables.CHR_EnArrange.GetItemOrNull(item.ene3ID);
                item._ene4ID = tables.CHR_EnArrange.GetItemOrNull(item.ene4ID);
                item._muteki_Condition = tables.FLD_ConditionList.GetItemOrNull(item.muteki_Condition);
                item._POP_TIME = (TimeRange)item.POP_TIME;
            }

            foreach (ma02a_FLD_EventPop item in tables.ma90a_FLD_EventPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (ma01a_FLD_LandmarkPop item in tables.ma90a_FLD_LandmarkPop.Items)
            {
                item._category = (LandmarkType)item.category;
                item._cndID = tables.FLD_ConditionList.GetItemOrNull(item.cndID);
                item._MAPJUMPID = tables.SYS_MapJumpList.GetItemOrNull(item.MAPJUMPID);
                item._MSGID = tables.fld_landmark.GetItemOrNull(item.MSGID);
                item._stoff_cndID = tables.FLD_ConditionList.GetItemOrNull(item.stoff_cndID);
            }

            foreach (ma01a_FLD_MapObjPop item in tables.ma90a_FLD_MapObjPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._RSC_ID = tables.RSC_MapObjList.GetItemOrNull(item.RSC_ID);
            }

            foreach (ma02a_FLD_MobPop item in tables.ma90a_FLD_MobPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._MOBGroupID = tables.FLD_MobGroupList.GetItemOrNull(item.MOBGroupID);
                item._MobID = tables.RSC_MobList.GetItemOrNull(item.MobID);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma01a_FLD_NpcPop item in tables.ma90a_FLD_NpcPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID1 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID1);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._FSID3 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID3);
                item._Group = tables.FLD_NpcGroupId.GetItemOrNull(item.Group);
                item._Mot = tables.FLD_NpcMobMotionId.GetItemOrNull(item.Mot);
                item._NpcID = tables.RSC_NpcList.GetItemOrNull(item.NpcID);
                item._ShopID = tables.MNU_ShopList.GetItemOrNull(item.ShopID);
                item._TimeRange = (TimeRange)item.TimeRange;
            }

            foreach (ma04a_FLD_PreciousPopList item in tables.ma90a_FLD_PreciousPopList.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._itmID = tables.ITM_PreciousList.GetItemOrNull(item.itmID);
            }

            foreach (ma03a_FLD_TboxPop item in tables.ma90a_FLD_TboxPop.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
                item._FSID = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID);
                item._FSID2 = tables.FLD_FieldSkillSetting.GetItemOrNull(item.FSID2);
                item._itm1ID = tables.GetItem(item.itm1ID);
                item._itm2ID = tables.GetItem(item.itm2ID);
                item._itm3ID = tables.GetItem(item.itm3ID);
                item._itm4ID = tables.GetItem(item.itm4ID);
                item._itm5ID = tables.GetItem(item.itm5ID);
                item._itm6ID = tables.GetItem(item.itm6ID);
                item._itm7ID = tables.GetItem(item.itm7ID);
                item._itm8ID = tables.GetItem(item.itm8ID);
                item._RSC_ID = tables.RSC_TboxList.GetItemOrNull(item.RSC_ID);
            }

            foreach (MIN_TT_Stage item in tables.MIN_TT_Stage.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (MIN_TT_Tbox item in tables.MIN_TT_Tbox.Items)
            {
                item._cond1 = tables.FLD_ConditionList.GetItemOrNull(item.cond1);
                item._cond10 = tables.FLD_ConditionList.GetItemOrNull(item.cond10);
                item._cond2 = tables.FLD_ConditionList.GetItemOrNull(item.cond2);
                item._cond3 = tables.FLD_ConditionList.GetItemOrNull(item.cond3);
                item._cond4 = tables.FLD_ConditionList.GetItemOrNull(item.cond4);
                item._cond5 = tables.FLD_ConditionList.GetItemOrNull(item.cond5);
                item._cond6 = tables.FLD_ConditionList.GetItemOrNull(item.cond6);
                item._cond7 = tables.FLD_ConditionList.GetItemOrNull(item.cond7);
                item._cond8 = tables.FLD_ConditionList.GetItemOrNull(item.cond8);
                item._cond9 = tables.FLD_ConditionList.GetItemOrNull(item.cond9);
                item._tdef1 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef1);
                item._tdef10 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef10);
                item._tdef2 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef2);
                item._tdef3 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef3);
                item._tdef4 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef4);
                item._tdef5 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef5);
                item._tdef6 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef6);
                item._tdef7 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef7);
                item._tdef8 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef8);
                item._tdef9 = tables.MIN_TT_Tdef.GetItemOrNull(item.tdef9);
            }

            foreach (MIN_TT_Tdef item in tables.MIN_TT_Tdef.Items)
            {
                item._item1 = tables.GetItem(item.item1);
                item._item10 = tables.GetItem(item.item10);
                item._item11 = tables.GetItem(item.item11);
                item._item12 = tables.GetItem(item.item12);
                item._item2 = tables.GetItem(item.item2);
                item._item3 = tables.GetItem(item.item3);
                item._item4 = tables.GetItem(item.item4);
                item._item5 = tables.GetItem(item.item5);
                item._item6 = tables.GetItem(item.item6);
                item._item7 = tables.GetItem(item.item7);
                item._item8 = tables.GetItem(item.item8);
                item._item9 = tables.GetItem(item.item9);
            }

            foreach (MNU_AnnouncePage item in tables.MNU_AnnouncePage.Items)
            {
                item._summary = tables.menu_announce.GetItemOrNull(item.summary);
                item._title = tables.menu_announce.GetItemOrNull(item.title);
            }

            foreach (MNU_AnnounceSchedule item in tables.MNU_AnnounceSchedule.Items)
            {
                item._schedule = tables.menu_announce.GetItemOrNull(item.schedule);
                item._summary = tables.menu_announce.GetItemOrNull(item.summary);
                item._title = tables.menu_announce.GetItemOrNull(item.title);
            }

            foreach (MNU_BladeCreate item in tables.MNU_BladeCreate.Items)
            {
                item._limited_item = tables.GetItem(item.limited_item);
            }

            foreach (MNU_BtnChallenge2 item in tables.MNU_BtnChallenge2.Items)
            {
                item._BtnType1 = (ButtonType)item.BtnType1;
                item._BtnType2 = (ButtonType)item.BtnType2;
                item._BtnType3 = (ButtonType)item.BtnType3;
                item._Param1 = tables.MNU_ChallengeParam.GetItemOrNull(item.Param1);
                item._Param2 = tables.MNU_ChallengeParam.GetItemOrNull(item.Param2);
                item._Param3 = tables.MNU_ChallengeParam.GetItemOrNull(item.Param3);
            }

            foreach (MNU_BtnChallengeSeq item in tables.MNU_BtnChallengeSeq.Items)
            {
                item._challenge01 = tables.MNU_BtnChallenge2.GetItemOrNull(item.challenge01);
                item._challenge02 = tables.MNU_BtnChallenge2.GetItemOrNull(item.challenge02);
                item._challenge03 = tables.MNU_BtnChallenge2.GetItemOrNull(item.challenge03);
                item._challenge04 = tables.MNU_BtnChallenge2.GetItemOrNull(item.challenge04);
                item._challenge05 = tables.MNU_BtnChallenge2.GetItemOrNull(item.challenge05);
            }

            foreach (MNU_CampCraft item in tables.MNU_CampCraft.Items)
            {
                item._driver_id = tables.CHR_Dr.GetItemOrNull(item.driver_id);
                item._shop_id = tables.MNU_ShopList.GetItemOrNull(item.shop_id);
                item._summary_msg = tables.menu_camp_ms.GetItemOrNull(item.summary_msg);
            }

            foreach (MNU_ChallengeResult item in tables.MNU_ChallengeResult.Items)
            {
                item._Text = tables.menu_ms.GetItemOrNull(item.Text);
            }

            foreach (MNU_CharOrder item in tables.MNU_CharBladeOrder.Items)
            {
                item._layer = tables.MNU_FSMenu.GetItemOrNull(item.layer);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_CharOrder item in tables.MNU_CharBladeOrder_ira.Items)
            {
                item._layer = tables.MNU_FSMenu.GetItemOrNull(item.layer);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_CharOrder item in tables.MNU_CharDriverOrder.Items)
            {
                item._layer = tables.MNU_FSMenu.GetItemOrNull(item.layer);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_CharOrder item in tables.MNU_CharDriverOrder_ira.Items)
            {
                item._layer = tables.MNU_FSMenu.GetItemOrNull(item.layer);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_CharOrder item in tables.MNU_CharHanaOrder.Items)
            {
                item._layer = tables.MNU_FSMenu.GetItemOrNull(item.layer);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_CmnWindow item in tables.MNU_CmnWindow.Items)
            {
                item._select_cancel_txt = tables.menu_cmnwindow.GetItemOrNull(item.select_cancel_txt);
                item._select_ok_txt = tables.menu_cmnwindow.GetItemOrNull(item.select_ok_txt);
                item._text = tables.menu_cmnwindow.GetItemOrNull(item.text);
                item._title = tables.menu_cmnwindow.GetItemOrNull(item.title);
            }

            foreach (MNU_Condition item in tables.MNU_Condition.Items)
            {
                item._cond = tables.FLD_ConditionList.GetItemOrNull(item.cond);
            }

            foreach (MNU_DlcGift item in tables.MNU_DlcGift.Items)
            {
                item._condition = tables.FLD_ConditionList.GetItemOrNull(item.condition);
                item._item_id = tables.GetItem(item.item_id);
                item._title = tables.menu_dlc_gift.GetItemOrNull(item.title);
            }

            foreach (MNU_EventTheater item in tables.MNU_EventTheater.Items)
            {
                item._blade_id = tables.CHR_Bl.GetItemOrNull(item.blade_id);
                item._chapter = tables.MNU_MsgEvthChapter.GetItemOrNull(item.chapter);
                item._maincast = tables.MNU_MsgEvthCast.GetItemOrNull(item.maincast);
                item._map_id = tables.FLD_maplist.GetItemOrNull(item.map_id);
                item._title = tables.menu_ev_theater_ms.GetItemOrNull(item.title);
            }

            foreach (MNU_EventTheater item in tables.MNU_EventTheater_ira.Items)
            {
                item._blade_id = tables.CHR_Bl.GetItemOrNull(item.blade_id);
                item._chapter = tables.MNU_MsgEvthChapter.GetItemOrNull(item.chapter);
                item._maincast = tables.MNU_MsgEvthCast.GetItemOrNull(item.maincast);
                item._map_id = tables.FLD_maplist.GetItemOrNull(item.map_id);
                item._title = tables.menu_ev_theater_ms.GetItemOrNull(item.title);
            }

            foreach (MNU_FSMenu item in tables.MNU_FSMenu.Items)
            {
                item._desc = tables.MNU_Msg_MenuDescription.GetItemOrNull(item.desc);
                item._text = tables.menu_sub_contents_ms.GetItemOrNull(item.text);
            }

            foreach (MNU_HanaSet item in tables.MNU_HanaSet.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_MainOrder item in tables.MNU_MainOrder.Items)
            {
                item._guide = tables.MNU_Msg_OperationGuide.GetItemOrNull(item.guide);
                item._subTitle = tables.MNU_Msg_SubContents.GetItemOrNull(item.subTitle);
                item._title = tables.menu_main_contents_ms.GetItemOrNull(item.title);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_MainOrder item in tables.MNU_MainOrder_ira.Items)
            {
                item._guide = tables.MNU_Msg_OperationGuide.GetItemOrNull(item.guide);
                item._subTitle = tables.MNU_Msg_SubContents.GetItemOrNull(item.subTitle);
                item._title = tables.menu_main_contents_ms.GetItemOrNull(item.title);
                item._useCond = tables.MNU_Condition.GetItemOrNull(item.useCond);
            }

            foreach (MNU_MapGroup item in tables.MNU_MapGroup.Items)
            {
                item._condition = tables.FLD_ConditionList.GetItemOrNull(item.condition);
                item._disp_name = tables.mnu_map_level_name_ms.GetItemOrNull(item.disp_name);
            }

            foreach (MNU_MapInfo item in tables.MNU_MapInfo.Items)
            {
                item._condition = tables.FLD_ConditionList.GetItemOrNull(item.condition);
                item._disp_name = tables.mnu_map_level_name_ms.GetItemOrNull(item.disp_name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ANGInfo.Items)
            {
                item._name = tables.menu_ang_info.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ArtsRange.Items)
            {
                item._name = tables.menu_range_type.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ArtsType.Items)
            {
                item._name = tables.menu_arts_type.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ArtsTypeIndex.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Attr.Items)
            {
                item._name = tables.menu_attr_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_CollectionItem.Items)
            {
                item._name = tables.menu_collectionitemtype.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ErrorInfo.Items)
            {
                item._name = tables.menu_error_info_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Gender.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ItemFilter.Items)
            {
                item._name = tables.menu_filter_category.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ItemListFilter.Items)
            {
                item._name = tables.menu_filter_category.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ItemSort.Items)
            {
                item._name = tables.menu_sort_category.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ItemType.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_MenuDescription.Items)
            {
                item._name = tables.menu_sub_contents_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Mercenaries.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_OperationGuide.Items)
            {
                item._name = tables.menu_operation_guide.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_OptList.Items)
            {
                item._name = tables.menu_option_name_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_PouchFilter.Items)
            {
                item._name = tables.menu_filter_category.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Race.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Rarelity.Items)
            {
                item._name = tables.menu_rarity.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Reaction.Items)
            {
                item._name = tables.menu_enemy_reaction.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_ReactionAll.Items)
            {
                item._name = tables.menu_enemy_reaction.GetItemOrNull(item.name);
            }

            foreach (MNU_Msg_SubContents item in tables.MNU_Msg_SubContents.Items)
            {
                item._caption = tables.MNU_Msg_MenuDescription.GetItemOrNull(item.caption);
                item._name = tables.menu_sub_contents_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_Msg_Weapon_Type.Items)
            {
                item._name = tables.itm_pcwpntype_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgBlStatusIndex.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_MsgChapterEnd item in tables.MNU_MsgChapterEnd.Items)
            {
                item._index = tables.menu_chapter_end_ms.GetItemOrNull(item.index);
                item._title = tables.menu_chapter_end_ms.GetItemOrNull(item.title);
            }

            foreach (MNU_Name item in tables.MNU_MsgDamageBuff.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgDrStatusIndex.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgEnbFamily.Items)
            {
                item._name = tables.menu_enemy_category.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgEvthCast.Items)
            {
                item._name = tables.menu_ev_theater_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgEvthChapter.Items)
            {
                item._name = tables.menu_ev_theater_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_MsgGiftFilter item in tables.MNU_MsgGiftFilter.Items)
            {
                item._name = tables.menu_dlc_gift.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgKeyAchieve.Items)
            {
                item._name = tables.fld_quest_achievement.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgMapFilter.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgPopup.Items)
            {
                item._name = tables.menu_popup_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgPopupSystem.Items)
            {
                item._name = tables.menu_popup_system_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_MsgPopupTitle item in tables.MNU_MsgPopupTitle.Items)
            {
                item._name = tables.menu_popup_title_ms.GetItemOrNull(item.name);
                item._name2 = tables.menu_popup_title_ms.GetItemOrNull(item.name2);
            }

            foreach (MNU_Name item in tables.MNU_MsgPouch.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgSelect.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgSelectTitle.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgTrustRank.Items)
            {
                item._name = tables.menu_st_congeniality.GetItemOrNull(item.name);
            }

            foreach (MNU_Name item in tables.MNU_MsgUniteBonus.Items)
            {
                item._name = tables.menu_ms.GetItemOrNull(item.name);
            }

            foreach (MNU_OptionCamera item in tables.MNU_OptionCamera.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_OptionDisp item in tables.MNU_OptionDisp.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_OptionDisp item in tables.MNU_OptionGame.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_OptionGameDif item in tables.MNU_OptionGameDif.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_OptionDisp item in tables.MNU_OptionGameDlc.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_OptionDisp item in tables.MNU_OptionSound.Items)
            {
                item._cap_id = tables.menu_option_cap_ms.GetItemOrNull(item.cap_id);
                item._name_id = tables.menu_option_name_ms.GetItemOrNull(item.name_id);
            }

            foreach (MNU_ShopCategoryName item in tables.MNU_ShopCategoryName.Items)
            {
                item._name = tables.menu_shop_category.GetItemOrNull(item.name);
            }

            foreach (MNU_ShopChange item in tables.MNU_ShopChange.Items)
            {
                item._AddCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition1);
                item._AddCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition2);
                item._AddCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition3);
                item._AddCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition4);
                item._AddCondition5 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition5);
                item._AddCondition6 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition6);
                item._AddCondition7 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition7);
                item._AddCondition8 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition8);
                item._AddTaskSet1 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet1);
                item._AddTaskSet2 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet2);
                item._AddTaskSet3 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet3);
                item._AddTaskSet4 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet4);
                item._AddTaskSet5 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet5);
                item._AddTaskSet6 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet6);
                item._AddTaskSet7 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet7);
                item._AddTaskSet8 = tables.MNU_ShopChangeTask.GetItemOrNull(item.AddTaskSet8);
                item._DefTaskSet1 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet1);
                item._DefTaskSet2 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet2);
                item._DefTaskSet3 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet3);
                item._DefTaskSet4 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet4);
                item._DefTaskSet5 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet5);
                item._DefTaskSet6 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet6);
                item._DefTaskSet7 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet7);
                item._DefTaskSet8 = tables.MNU_ShopChangeTask.GetItemOrNull(item.DefTaskSet8);
            }

            foreach (MNU_ShopChangeTask item in tables.MNU_ShopChangeTask.Items)
            {
                item._Name = tables.fld_shopchange.GetItemOrNull(item.Name);
                item._Reward = tables.FLD_QuestReward.GetItemOrNull(item.Reward);
                item._SetItem1 = tables.GetItem(item.SetItem1);
                item._SetItem2 = tables.GetItem(item.SetItem2);
                item._SetItem3 = tables.GetItem(item.SetItem3);
                item._SetItem4 = tables.GetItem(item.SetItem4);
                item._SetItem5 = tables.GetItem(item.SetItem5);
            }

            foreach (MNU_ShopList item in tables.MNU_ShopList.Items)
            {
                item._Name = tables.fld_shopname.GetItemOrNull(item.Name);
                item._ShopType = (ShopType)item.ShopType;
            }

            foreach (MNU_ShopNormal item in tables.MNU_ShopNormal.Items)
            {
                item._AddCondition1 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition1);
                item._AddCondition2 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition2);
                item._AddCondition3 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition3);
                item._AddCondition4 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition4);
                item._AddCondition5 = tables.FLD_ConditionList.GetItemOrNull(item.AddCondition5);
                item._Addtem1 = tables.GetItem(item.Addtem1);
                item._Addtem2 = tables.GetItem(item.Addtem2);
                item._Addtem3 = tables.GetItem(item.Addtem3);
                item._Addtem4 = tables.GetItem(item.Addtem4);
                item._Addtem5 = tables.GetItem(item.Addtem5);
                item._DefItem1 = tables.GetItem(item.DefItem1);
                item._DefItem10 = tables.GetItem(item.DefItem10);
                item._DefItem2 = tables.GetItem(item.DefItem2);
                item._DefItem3 = tables.GetItem(item.DefItem3);
                item._DefItem4 = tables.GetItem(item.DefItem4);
                item._DefItem5 = tables.GetItem(item.DefItem5);
                item._DefItem6 = tables.GetItem(item.DefItem6);
                item._DefItem7 = tables.GetItem(item.DefItem7);
                item._DefItem8 = tables.GetItem(item.DefItem8);
                item._DefItem9 = tables.GetItem(item.DefItem9);
                item._PrivilegeItem = tables.GetItem(item.PrivilegeItem);
            }

            foreach (MNU_SortEnhance item in tables.MNU_SortEnhance.Items)
            {
                item._enhance1 = tables.menu_sort_category.GetItemOrNull(item.enhance1 + 13);
                item._enhance2 = tables.menu_sort_category.GetItemOrNull(item.enhance2 + 13);
                item._enhance3 = tables.menu_sort_category.GetItemOrNull(item.enhance3 + 13);
                item._enhance4 = tables.menu_sort_category.GetItemOrNull(item.enhance4 + 13);
            }

            foreach (MNU_SortFieldSkill item in tables.MNU_SortFieldSkill.Items)
            {
                item._fs1 = tables.FLD_FieldSkillList.GetItemOrNull(item.fs1);
            }

            foreach (MNU_SortRole item in tables.MNU_SortRole.Items)
            {
                item._role1 = tables.menu_role_name_ms.GetItemOrNull(item.role1);
            }

            foreach (MNU_SortTable item in tables.MNU_SortTable.Items)
            {
                item._sort_type1 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type1);
                item._sort_type10 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type10);
                item._sort_type11 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type11);
                item._sort_type12 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type12);
                item._sort_type13 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type13);
                item._sort_type14 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type14);
                item._sort_type2 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type2);
                item._sort_type3 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type3);
                item._sort_type4 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type4);
                item._sort_type5 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type5);
                item._sort_type6 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type6);
                item._sort_type7 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type7);
                item._sort_type8 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type8);
                item._sort_type9 = tables.MNU_Msg_ItemSort.GetItemOrNull(item.sort_type9);
            }

            foreach (MNU_SoundBgm item in tables.MNU_SoundBgm.Items)
            {
                item._resource = tables.RSC_BgmList.GetItemOrNull(item.resource);
            }

            foreach (MNU_SpecialShop item in tables.MNU_SpecialShop.Items)
            {
                item._shop_id = tables.MNU_ShopList.GetItemOrNull(item.shop_id);
            }

            foreach (MNU_WorldMapCond item in tables.MNU_WorldMapCond.Items)
            {
                item._cond1 = tables.FLD_ConditionList.GetItemOrNull(item.cond1);
                item._cond2 = tables.FLD_ConditionList.GetItemOrNull(item.cond2);
                item._cond3 = tables.FLD_ConditionList.GetItemOrNull(item.cond3);
                item._enter = tables.FLD_ConditionList.GetItemOrNull(item.enter);
                item._mapId = tables.FLD_maplist.GetItemOrNull(item.mapId);
                item._pos1 = tables.MNU_WorldMap.GetItemOrNull(item.pos1);
                item._pos2 = tables.MNU_WorldMap.GetItemOrNull(item.pos2);
                item._pos3 = tables.MNU_WorldMap.GetItemOrNull(item.pos3);
            }

            foreach (MNU_txt item in tables.mnu001_title_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu002_balloon_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu003_dropitem_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu004_gauge_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu004_palette_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu004_palette2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu007_buff_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu007_damage_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu009_expget_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu010_mainmenu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu010_mainmenu2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu011_dr_custom_select_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu012_bl_custom_select_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu013_dr_arts_set_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu014_kizuna_ring_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu016_ptform_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu016_ptform2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu018_skip_time_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu018_world_map_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu018_zone_map_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu020_quest_list_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu020_quest_reward_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu020_top_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu021_blade_book_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu022_en_book_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu024_shop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu025_fade_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu027_info_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu027_list_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu027_text_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu029_fieldskill_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu030_actionwindow_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu030_elem_eff_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu030_enemystatus_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu030_fieldtarget_info_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu032_buttonchallenge_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu032_buttonchallenge2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu033_save_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu033_save2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu034_partystatus_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu034_partystatus2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu035_locationtelop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu035_locationtelop2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu036_eventsubtitle_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu037_bladechange_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu038_bladeform_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu039_combo_req_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu040_environmentinfo_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu041_eventskip_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu042_questorder_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu043_questresult_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu045_compass_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu046_popup_window_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu048_item_submenu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu048_itemlist_main_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu050_chapter_telop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu051_operation_info_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu052_link_jump_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu053_jog_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu054_mercenary_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu055_blade_create_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu055_blade_name_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu056_dr_equip_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu060_blade_set_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu061_inn_main_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu061_inn_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu061_lv_setup_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu062_battle_telop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu063_common_detail_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu064_cylinderselect_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu064_salvage_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu065_chain_attack_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu069_tutorial_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu070_pouch_main_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu070_pouch_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu071_bl_weapon_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu071_blade_weapon_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu072_bl_orb_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu072_blade_orb_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu074_comboroot_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu075_main_menu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu076_char_menu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu076_hana_submenu_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu079_event_theater_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu080_option_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu081_quest_log_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu082_ptform_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu083_bl_cmn_detail_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu083_cmn_status_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu083_dr_cmn_detail_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu084_dr_equip_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu085_shop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu086_blade_set_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu087_dialog_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu088_dr_arts_set_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu089_bl_kizuna_ring_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu089_dr_kizuna_ring_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu090_mercenary_form_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu090_mercenary_report_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu090_mercenary_top_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu091_hana_main_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu091_hana_main2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu091_parts_make_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu091_parts_make2_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu091_parts_recrystal_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu092_zone_telop_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu094_submenu_book_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu094_submenu_crystal_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu094_submenu_system_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu095_blade_release_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu096_blade_switch_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu100_bladecreate_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu100_name_select_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu101_sort_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu103_staffroll_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu104_gift_box_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu105_announce_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (MNU_txt item in tables.mnu999_chaincount_txt.Items)
            {
                item._text_id = tables.menu_ms.GetItemOrNull(item.text_id);
            }

            foreach (RSC_AreaBgmList item in tables.RSC_AreaBgmList.Items)
            {
                item._bgmCondition = tables.RSC_BgmCondition.GetItemOrNull(item.bgmCondition);
            }

            foreach (RSC_BgmCondition item in tables.RSC_BgmCondition.Items)
            {
                item._BgmIDA = tables.RSC_BgmList.GetItemOrNull(item.BgmIDA);
                item._BgmIDB = tables.RSC_BgmList.GetItemOrNull(item.BgmIDB);
                item._BgmIDC = tables.RSC_BgmList.GetItemOrNull(item.BgmIDC);
                item._BgmIDD = tables.RSC_BgmList.GetItemOrNull(item.BgmIDD);
                item._ConditionA = tables.FLD_ConditionList.GetItemOrNull(item.ConditionA);
                item._ConditionB = tables.FLD_ConditionList.GetItemOrNull(item.ConditionB);
                item._ConditionC = tables.FLD_ConditionList.GetItemOrNull(item.ConditionC);
                item._ConditionD = tables.FLD_ConditionList.GetItemOrNull(item.ConditionD);
            }

            foreach (RSC_En item in tables.RSC_En.Items)
            {
                item._TypeFamily = tables.MNU_MsgEnbFamily.GetItemOrNull(item.TypeFamily + 1);
                item._TypeGenus = tables.RSC_EnGenus.GetItemOrNull(item.TypeGenus);
            }

            foreach (RSC_EnGenus item in tables.RSC_EnGenus.Items)
            {
                item._NAME = tables.btl_engenus_ms.GetItemOrNull(item.NAME);
            }

            foreach (RSC_GmkSetList item in tables.RSC_GmkSetList.Items)
            {
                item._mapId = tables.FLD_maplist.GetItemOrNull(item.mapId);
            }

            foreach (RSC_NpcList item in tables.RSC_NpcList.Items)
            {
                item._Name = tables.fld_npcname.GetItemOrNull(item.Name);
            }

            foreach (RSC_PcWpn item in tables.RSC_PcWpn.Items)
            {
                item._MenuImageID = tables.MNU_Stream_WpnImg.GetItemOrNull(item.MenuImageID);
            }

            foreach (SYS_MapJumpEvList item in tables.SYS_MapJumpEvList.Items)
            {
                item._FormationId = tables.EVT_formation.GetItemOrNull(item.FormationId);
                item._MapList = tables.FLD_maplist.GetItemOrNull(item.MapList);
            }

            foreach (SYS_MapJumpEvList item in tables.SYS_MapJumpList.Items)
            {
                item._MapList = tables.FLD_maplist.GetItemOrNull(item.MapList);
            }

            foreach (Vo_Battle_Enemy item in tables.Vo_Battle_Enemy.Items)
            {
                item._CondEx = tables.FLD_ConditionList.GetItemOrNull(item.CondEx);
            }

            foreach (Vo_Field_Filter item in tables.Vo_Field_Filter.Items)
            {
                item._Condition = tables.FLD_ConditionList.GetItemOrNull(item.Condition);
            }

            foreach (Vo_WinSp item in tables.Vo_WinSp.Items)
            {
                item._FLD_CondID = tables.FLD_ConditionList.GetItemOrNull(item.FLD_CondID);
            }
        }
    }
}
