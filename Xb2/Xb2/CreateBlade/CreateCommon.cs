using System;
using System.Collections.Generic;
using System.Linq;
using Xb2.Types;

namespace Xb2.CreateBlade
{
    public class CreateCommon
    {
        private BdatCollection Tables { get; }
        private Random Rand { get; } = new Random();
        private IdeaCategory IdeaCat { get; set; }
        private int IdeaLevel { get; set; }
        private int BladePower { get; set; }
        private int TemplateId { get; set; }
        private BTL_CmnBl_Power BdatPower { get; set; }
        private CHR_Bl ChrBlade { get; set; }
        private BTL_CmnBl_Capacity Capacity { get; set; }
        private CharBlade Blade { get; set; }

        public DriverInfo DriverInfo { get; }
        public BladeCreateParams CreateParams { get; }

        public CreateCommon(BdatCollection tables, DriverInfo driverInfo, BladeCreateParams createParams)
        {
            Tables = tables;
            DriverInfo = driverInfo;
            CreateParams = createParams;
        }

        public CharBlade Create()
        {
            Blade = new CharBlade();
            CalcIdeaCat();
            int tier = CalcLevelTier(DriverInfo.Level);
            int power = GetPowerRng(tier);
            BladePower = CalcBladePower(power);
            Capacity = Tables.BTL_CmnBl_Capacity[BladePower];
            Blade.Power = BladePower;
            TemplateId = GetTemplateId();
            Blade.Attribute = GetBladeAttribute();
            GetBladeWeapon();
            GetBladeModel();
            Blade.ModelParts = GetModelParts();
            GetName();
            GetPersonality();
            Blade.OrbCount = GetOrbNum();
            Blade.StatusType = (StatusType)GetStatusType();
            Blade.StatusValue = GetStatusValue();
            GetArmorRating();
            GetSpecials();
            GetSpecialLv4();
            GetNArts();
            GetBSkills();
            //GetFSkills();
            //GetFavoriteCategory();
            //GetCrowns();
            ;
            return Blade;
        }

        private void CalcIdeaCat()
        {
            if (CreateParams.BoosterCount > 0)
            {
                IdeaCat = CreateParams.IdeaCategory;
            }
            else
            {
                int[] ideas = DriverInfo.IdeaLevels;
                int max = ideas.Max();
                var ties = new List<int>();

                for (int i = 0; i < ideas.Length; i++)
                {
                    if (ideas[i] == max)
                    {
                        ties.Add(i);
                    }
                }

                IdeaCat = (IdeaCategory)ties[Rand.Next(ties.Count)];
            }

            IdeaLevel = DriverInfo.IdeaLevels[(int)IdeaCat];
        }

        private int CalcLevelTier(int level)
        {
            BdatPower = Tables.BTL_CmnBl_Power
                .FirstOrDefault(x => x.MinLv <= level && x.MaxLv >= level);

            return BdatPower?.Id ?? 1;
        }

        private int GetPowerRng(int tier)
        {
            var probs = BdatPower._Pow;
            return GetRandomIndex(probs) + 1;
        }

        private int CalcBladePower(int basePower)
        {
            int pow = Tables.ITM_CrystalList[(int)CreateParams.Crystal].CommonPow;
            pow = pow + basePower + IdeaLevel / 5;
            return Math.Min(pow, 15);
        }

        private int GetTemplateId()
        {
            var driverIdea = DriverInfo.IdeaLevels[(int)IdeaCat];
            var ideaCatBits = 1 << (int)IdeaCat;

            var a = Tables.BLD_CommonList
                .Where(x => x.IdeaMin <= driverIdea && x.IdeaMax >= driverIdea)
                .Where(x => (x.IdeaType & ideaCatBits) != 0).ToArray();

            return a[GetRandomIndex(a.Select(x => (ushort)x.Ratio).ToArray())].Id;
        }

        private BladeAttribute GetBladeAttribute()
        {
            long attProb = Tables.BLD_CreateConfig[42].Value;
            float baseProb = 50 - attProb;
            var probs = new float[9];
            for (int i = 1; i < probs.Length; i++)
            {
                probs[i] = baseProb;
            }

            BladeAttribute[] attributes = IdeaToAttributes(IdeaCat);
            foreach (var attribute in attributes)
            {
                probs[(int)attribute] = attProb;
            }

            probs[(int)BladeAttribute.Light] = 0;

            var randVal = Rand.NextDouble() * probs.Sum();
            float sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal)
                {
                    return (BladeAttribute)i;
                }
            }

            return BladeAttribute.Fire;
        }

        private void GetBladeWeapon()
        {
            int randVal = Rand.Next(8);
            Blade.WeaponType = CommonWeapons[randVal];
            Blade.QuestRace = Blade.WeaponType == BladeWeapon.TwinRings ? Race.Animal : Race.Humanoid;
            Blade.Gender = Blade.QuestRace == Race.Humanoid ? (Gender)Rand.Next(1, 3) : Gender.Male;
        }

        private void GetBladeModel()
        {
            var driverIdea = DriverInfo.IdeaLevels[(int)IdeaCat];

            BLD_BladeModelList[] modelMatch = Tables.BLD_BladeModelList.Where(x =>
                x.Gender == (byte)Blade.Gender &&
                x.QuestRace == (byte)Blade.QuestRace &&
                x.IdeaMin <= driverIdea &&
                x.IdeaMax >= driverIdea).ToArray();

            int probTotal = modelMatch.Sum(x => x.Model1 + x.Model2);

            int randVal = Rand.Next(probTotal);
            int sum = 0;
            bool isBrute = false;

            foreach (var modelInfo in modelMatch)
            {
                sum += modelInfo.Model1;
                if (sum >= randVal)
                {
                    Blade.Model = modelInfo;
                    break;
                }
                sum += modelInfo.Model2;
                if (sum >= randVal)
                {
                    Blade.Model = modelInfo;
                    isBrute = true;
                    break;
                }
            }


            if (Blade.WeaponType == BladeWeapon.TwinRings)
            {
                Blade.StatusId = 1072;
                Blade.CommonBladeType = CommonBladeType.Animal;
            }
            else if (Blade.Gender == Gender.Female)
            {
                Blade.StatusId = 1055 + (int)Blade.WeaponType;
                Blade.CommonBladeType = CommonBladeType.Female;
            }
            else if (isBrute)
            {
                Blade.StatusId = 1048 + (int)Blade.WeaponType;
                Blade.CommonBladeType = CommonBladeType.Brute;
            }
            else
            {
                Blade.StatusId = 1041 + (int)Blade.WeaponType;
                Blade.CommonBladeType = CommonBladeType.Male;
            }

            var chrBlade = Tables.CHR_Bl[Blade.StatusId];
            ChrBlade = chrBlade;
            Blade.ModelName = chrBlade.Model;
            Blade.MotionName = chrBlade.Motion;
            Blade.SePackName = chrBlade.SePack;
            Blade.DefaultWeaponId = chrBlade.DefWeapon;
        }

        private int GetModelParts()
        {
            var probs = Blade.Model._Parts;
            return GetRandomIndex(probs) - 1;
        }

        private void GetName()
        {
            int race = (int)Blade.QuestRace << 1;
            int gender = (int)Blade.Gender;
            var name = Tables.BLD_NameList.Where(x => (x.Race & race) != 0 && (x.Gender & gender) != 0).ChooseRandom(Rand);

            Blade.NameId = name.Id;
            Blade.Name = name._Category.name;
        }

        private void GetPersonality()
        {
            switch (Blade.CommonBladeType)
            {
                case CommonBladeType.Male:
                    Blade.VoiceId = Rand.Next(12) + 61;
                    break;
                case CommonBladeType.Female:
                    Blade.VoiceId = Rand.Next(12) + 73;
                    break;
                case CommonBladeType.Brute:
                    Blade.VoiceId = Rand.Next(4) + 85;
                    break;
                case CommonBladeType.Animal:
                    Blade.VoiceId = Rand.Next(4) + 89;
                    break;
                default:
                    Blade.VoiceId = 61;
                    break;
            }

            BTL_Bl_Personality personality = Tables.BTL_Bl_Personality
                .FirstOrDefault(x => x.common && x.VoiceID == Blade.VoiceId);

            Blade.PersonalityId = personality?.Id ?? 0;
            Blade.KizunaLinkSet = Tables.BTL_Bl_KizunaLinkSet.First(x => x.VoiceID == Blade.VoiceId).Id;
        }

        public int GetOrbNum()
        {
            byte[] probs = Tables.BTL_CmnBl_Capacity[BladePower]._OrbNumProb;
            return GetRandomIndex(probs);
        }

        public int GetStatusType()
        {
            byte[] probs = Tables.BTL_CmnBl_StatusType.First(x => x.WpnType == (int)Blade.WeaponType)._Status;
            return GetRandomIndex(probs);
        }

        public int GetStatusValue()
        {
            return Rand.Next(Capacity.StatusRevRand) + Capacity.StatusRevCon;
        }

        public void GetArmorRating()
        {
            BTL_CmnBl_Armor armor = Tables.BTL_CmnBl_Armor.First(x => x.WpnType == (int)Blade.WeaponType);
            Blade.PhysicalArmor = armor.PArmorCon + Rand.Next(armor.PArmorRand);
            Blade.EtherArmor = armor.EArmorCon + Rand.Next(armor.EArmorRand);
        }

        public void GetSpecials()
        {
            var bArts = new List<Art>();

            for (int i = 0; i < 3; i++)
            {
                int spLevel = i + 1;
                BTL_Arts_Bl arts = Tables.BTL_Arts_Bl.Where(x =>
                        x.common &&
                        x.CmnBlType == (int)Blade.CommonBladeType &&
                        x.WpnType == (int)Blade.WeaponType &&
                        x.SpLv == spLevel)
                    .ChooseRandom(Rand);

                bArts.Add(new Art
                {
                    Id = arts.Id,
                    Name = arts._Name.name,
                    MaxLevel = GetRandomIndex(Capacity._ArtsLvProb)
                });
            }

            Blade.BArts = bArts;
        }

        public void GetSpecialLv4()
        {
            var special = Tables.BTL_Arts_BlSp.Where(x =>
                    x.CmnBlType == (int)Blade.CommonBladeType &&
                    x.WpnType == (int)Blade.WeaponType)
                .ChooseRandom(Rand);

            Blade.BArtEx = new Art
            {
                Id = special.Id,
                Name = special._Name.name,
                BArtExRev = Capacity.SpArtsRevCon + Rand.Next(Capacity.SpArtsRevRand)
            };
        }

        public void GetNArts()
        {
            int nArtsCount = GetRandomIndex(Capacity._NartsNumProb) + 1;
            var artIds = new List<int>();
            var arts = new List<Art>();

            var probs = Tables.BTL_CmnBl_NewBlArts.First(x => x.WpnType == (int)Blade.WeaponType)._NBA;
            var buffs = Tables.BTL_Buff;

            while (arts.Count < nArtsCount)
            {
                BTL_Buff nArt = buffs[GetRandomIndex(probs) + 1];
                if (artIds.Contains(nArt.Id)) continue;

                artIds.Add(nArt.Id);
                arts.Add(new Art { Id = nArt.Id, Name = nArt._Name.name });
            }

            Blade.NArts = arts;
        }

        public void GetBSkills()
        {
            int skillCount = GetRandomIndex(Capacity._SkillNumProb) + 1;
            var role = (Role)Tables.ITM_PcWpnType[(int)Blade.WeaponType].Role;

            BTL_Skill_Bl[] possibleSkills = Tables.BTL_Skill_Bl.Where(x =>
                role == Role.Tank && x.Tank != 0 ||
                role == Role.Attacker && x.Attacker != 0 ||
                role == Role.Healer && x.Healer != 0).ToArray();

            var skillIds = new List<int>();
            var skills = new List<Skill>();

            while (skillIds.Count < skillCount)
            {
                BTL_Skill_Bl skill = possibleSkills.ChooseRandom(Rand);
                if (skillIds.Contains(skill.Id)) continue;

                skillIds.Add(skill.Id);
                skills.Add(new Skill
                {
                    Id = skill.Id,
                    Name = skill._Name.name,
                    MaxLevel = GetRandomIndex(Capacity._SkillLvProb)
                });
            }

            Blade.BSkills = skills;
        }

        //public void GetFSkills()
        //{
        //    var fSkillCategory = Tables.BLD_CommonList[TemplateId].Fskill;

        //    var skillProb = Math.Clamp(DriverInfo.Level - 1, 1, 60);
        //    var skillCount = GetRandomIndex(FSkillProbs[skillProb]) + 1;

        //    var possibleSkills = new List<int>();
        //    var skillIds = new List<int>();
        //    var skills = new List<Skill>();

        //    f

        //    for (int i = startId; i < endId; i++)
        //    {
        //        if ((XmlRead.GetValue(BladeFSkillTable, BladeFSkillCategory, i) & 2) == 0) continue;

        //        int attribute = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillAttribute, i);
        //        if (attribute > 0 && attribute != (int)Blade.Attribute) continue;

        //        skillIds.Add(i);
        //        break;
        //    }

        //    for (int i = startId; i < endId; i++)
        //    {
        //        if ((XmlRead.GetValue(BladeFSkillTable, BladeFSkillCategory, i) & fSkillCategory) == 0) continue;

        //        int attribute = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillAttribute, i);
        //        if (attribute > 0 && attribute != (int)Blade.Attribute) continue;
        //        int nameId = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillName, i);
        //        if (nameId == 0) continue;

        //        possibleSkills.Add(i);
        //    }

        //    while (skillIds.Count < skillCount)
        //    {
        //        int skillId = possibleSkills[Rand.Next(possibleSkills.Count)];
        //        if (!skillIds.Contains(skillId))
        //        {
        //            skillIds.Add(skillId);
        //        }
        //    }

        //    foreach (int skillId in skillIds)
        //    {
        //        var art = new Skill { Id = skillId };
        //        int nameId = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillName, skillId);
        //        art.Name = XmlRead.GetString(BladeFSkillMsTable, MsName, nameId);
        //        int minLevel = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillMinLevel, skillId);
        //        int maxLevel = (int)XmlRead.GetValue(BladeFSkillTable, BladeFSkillMaxLevel, skillId);
        //        art.MaxLevel = Math.Min(Rand.Next(minLevel, maxLevel + 1), 3);
        //        skills.Add(art);
        //    }

        //    Blade.FSkills = skills;
        //}

        private int GetRandomIndex(int[] probs)
        {
            double randVal = Rand.Next(probs.Sum(x => x));
            int sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal && sum != 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private int GetRandomIndex(ushort[] probs)
        {
            double randVal = Rand.Next(probs.Sum(x => x));
            int sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal && sum != 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private int GetRandomIndex(byte[] probs)
        {
            double randVal = Rand.Next(probs.Sum(x => x));
            int sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal && sum != 0)
                {
                    return i;
                }
            }

            return 0;
        }

        private static BladeAttribute[] IdeaToAttributes(IdeaCategory idea)
        {
            switch (idea)
            {
                case IdeaCategory.Bravery:
                    return new[] { BladeAttribute.Fire, BladeAttribute.Water };
                case IdeaCategory.Truth:
                    return new[] { BladeAttribute.Wind, BladeAttribute.Ice };
                case IdeaCategory.Compassion:
                    return new[] { BladeAttribute.Earth, BladeAttribute.Electric };
                case IdeaCategory.Justice:
                    return new[] { BladeAttribute.Light, BladeAttribute.Dark };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static readonly int[] FSkillProbs00 = { 50, 45, 5 };
        private static readonly int[] FSkillProbs15 = { 40, 45, 15 };
        private static readonly int[] FSkillProbs30 = { 30, 45, 25 };
        private static readonly int[] FSkillProbs45 = { 20, 45, 35 };
        private static readonly int[] FSkillProbs60 = { 10, 45, 45 };

        private static readonly int[][] FSkillProbs =
        {
            new[] {50, 45, 5},
            new[] {40, 45, 15},
            new[] {30, 45, 25},
            new[] {20, 45, 35},
            new[] {10, 45, 45}
        };

        private static readonly BladeWeapon[] CommonWeapons =
        {
            BladeWeapon.TwinRings,
            BladeWeapon.Greataxe,
            BladeWeapon.Megalance,
            BladeWeapon.EtherCannon,
            BladeWeapon.ShieldHammer,
            BladeWeapon.ChromaKatana,
            BladeWeapon.Bitball,
            BladeWeapon.KnuckleClaws
        };
    }
}
