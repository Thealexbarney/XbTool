using System;
using System.Collections.Generic;
using System.Linq;
using XbTool.Types;

namespace XbTool.CreateBlade
{
    public class CreateCommon
    {
        private BdatCollection Tables { get; }
        private Random Rand { get; } = new Random();

        private DriverInfo DriverInfo { get; }
        private BladeCreateParams CreateParams { get; }
        private IdeaCategory IdeaCat { get; set; }
        private int IdeaLevel { get; set; }

        private CharBlade Blade { get; set; }
        private BLD_CommonList Template { get; set; }
        private BTL_CmnBl_Power BdatPower { get; set; }
        private BTL_CmnBl_Capacity Capacity { get; set; }

        public CreateCommon(BdatCollection tables, DriverInfo driverInfo, BladeCreateParams createParams)
        {
            Tables = tables;
            DriverInfo = driverInfo;
            CreateParams = createParams;
        }

        public CharBlade Create()
        {
            Blade = new CharBlade();
            CalcIdeaCategory();
            CalcBladePower();

            ChooseBladeTemplate();
            ChooseBladeAttribute();
            ChooseBladeWeapon();
            ChooseBladeModel();
            ChooseName();
            ChoosePersonality();

            Blade.OrbCount = GetRandomIndex(Capacity._OrbNumProb);
            Blade.StatusValue = Rand.Next(Capacity.StatusRevRand) + Capacity.StatusRevCon;
            Blade.StatusType = (StatusType)GetRandomIndex(Tables.BTL_CmnBl_StatusType
                .First(x => x.WpnType == (int)Blade.WeaponType)._Status);

            ChooseArmorRating();
            ChooseSpecials();
            ChooseSpecialLv4();
            ChooseBladeArts();
            ChooseBattleSkills();
            ChooseFieldSkills();
            ChooseFavoriteCategory();
            GetCrownCount();
            return Blade;
        }

        private void CalcIdeaCategory()
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

        private void CalcBladePower()
        {
            BdatPower = Tables.BTL_CmnBl_Power.First(x => x.MinLv <= DriverInfo.Level && x.MaxLv >= DriverInfo.Level);
            int basePower = GetRandomIndex(BdatPower._Pow) + 1;
            int crystalPow = Tables.ITM_CrystalList[(int)CreateParams.Crystal].CommonPow;
            Blade.Power = Math.Min(basePower + crystalPow + IdeaLevel / 5, 15);
            Capacity = Tables.BTL_CmnBl_Capacity[Blade.Power];
        }

        private void ChooseBladeTemplate()
        {
            var driverIdea = DriverInfo.IdeaLevels[(int)IdeaCat];
            var ideaCatBits = 1 << (int)IdeaCat;

            var possible = Tables.BLD_CommonList
                .Where(x => x.IdeaMin <= driverIdea && x.IdeaMax >= driverIdea)
                .Where(x => (x.IdeaType & ideaCatBits) != 0).ToArray();

            Template = possible.ChooseRandom(Rand, possible.Select(x => (int)x.Ratio));
        }

        private void ChooseBladeAttribute()
        {
            int attProb = (int)Tables.BLD_CreateConfig[42].Value;
            int baseProb = 50 - attProb;
            var probs = new int[9];
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

            Blade.Attribute = Attributes.ChooseRandom(Rand, probs);
        }

        private void ChooseBladeWeapon()
        {
            int randVal = Rand.Next(8);
            Blade.WeaponType = CommonWeapons[randVal];
            Blade.QuestRace = Blade.WeaponType == BladeWeapon.TwinRings ? Race.Animal : Race.Humanoid;
            Blade.Gender = Blade.QuestRace == Race.Humanoid ? (Gender)Rand.Next(1, 3) : Gender.Male;
        }

        private void ChooseBladeModel()
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

            Blade.ChrBlade = Tables.CHR_Bl[Blade.StatusId];
            Blade.ModelParts = GetRandomIndex(Blade.Model._Parts) - 1;

        }

        private void ChooseName()
        {
            int race = (int)Blade.QuestRace << 1;
            int gender = (int)Blade.Gender;
            var name = Tables.BLD_NameList.Where(x => (x.Race & race) != 0 && (x.Gender & gender) != 0).ChooseRandom(Rand);

            Blade.NameId = name.Id;
            Blade.Name = name._Category.name;
        }

        private void ChoosePersonality()
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

            Blade.Personality = Tables.BTL_Bl_Personality
                .FirstOrDefault(x => x.common && x.VoiceID == Blade.VoiceId);
            Blade.KizunaLinkSet = Tables.BTL_Bl_KizunaLinkSet.First(x => x.VoiceID == Blade.VoiceId);
        }

        private void ChooseArmorRating()
        {
            BTL_CmnBl_Armor armor = Tables.BTL_CmnBl_Armor.First(x => x.WpnType == (int)Blade.WeaponType);
            Blade.PhysicalArmor = armor.PArmorCon + Rand.Next(armor.PArmorRand);
            Blade.EtherArmor = armor.EArmorCon + Rand.Next(armor.EArmorRand);
        }

        private void ChooseSpecials()
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
                    MaxLevel = GetRandomIndex(Capacity._ArtsLvProb) + 1
                });
            }

            Blade.BArts = bArts;
        }

        private void ChooseSpecialLv4()
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

        private void ChooseBladeArts()
        {
            int nArtsCount = GetRandomIndex(Capacity._NartsNumProb) + 1;
            byte[] probs = Tables.BTL_CmnBl_NewBlArts.First(x => x.WpnType == (int)Blade.WeaponType)._NBA;
            Blade.NArts = new List<Art>();

            BTL_Buff[] arts = Tables.BTL_Buff.ChooseRandom(Rand, probs, nArtsCount);
            foreach (var nArt in arts)
            {
                Blade.NArts.Add(new Art { Id = nArt.Id, Name = nArt._Name.name });
            }
        }

        private void ChooseBattleSkills()
        {
            int skillCount = GetRandomIndex(Capacity._SkillNumProb) + 1;
            var role = (Role)Tables.ITM_PcWpnType[(int)Blade.WeaponType].Role;

            Blade.BSkills = new List<Skill>();
            BTL_Skill_Bl[] bSkills = Tables.BTL_Skill_Bl.Where(x =>
                role == Role.Tank && x.Tank != 0 ||
                role == Role.Attacker && x.Attacker != 0 ||
                role == Role.Healer && x.Healer != 0)
                .ChooseRandom(Rand, skillCount);

            foreach (var skill in bSkills)
            {
                int maxLevel = GetRandomIndex(Capacity._SkillLvProb) + 1;
                Blade.BSkills.Add(new Skill(skill.Id, skill._Name.name, maxLevel));
            }
        }

        private void ChooseFieldSkills()
        {
            int probsIndex = Math.Min(DriverInfo.Level - 1, 60) / 15;
            int skillCount = GetRandomIndex(FSkillProbs[probsIndex]) + 1;

            var skills = new List<Skill>();
            var fSkills = new List<FLD_FieldSkillList>
            {
                Tables.FLD_FieldSkillList.First(x =>
                    x._Category == FieldSkillCategory.Elemental && x.Attirbute == (int) Blade.Attribute)
            };

            fSkills.AddRange(Tables.FLD_FieldSkillList
                .Where(x => (x._Category & Template._Fskill) != 0 && x.Name != 0)
                .ChooseRandom(Rand, skillCount - 1));

            foreach (var skill in fSkills)
            {
                int maxLevel = Math.Min(Rand.Next(skill.MinLevel, skill.MaxLevel + 1), 3);
                skills.Add(new Skill(skill.Id, skill._Name.name, maxLevel));
            }

            Blade.FSkills = skills;
        }

        private void ChooseFavoriteCategory()
        {
            Blade.FavCategories = FavoriteCategories.ChooseRandom(Rand, Template.FavoriteCategoryMax);

            Blade.FavItems = Tables.ITM_FavoriteList.Where(x => x.Name != 0)
                .ChooseRandom(Rand, Template.FavoriteItemMax);
        }

        private void GetCrownCount()
        {
            Blade.AffinityNodeCount = GetAffinityNodeCount();

            for (int i = 0; i < 4; i++)
            {
                int threshold = Tables.FLD_wildcardData[63 + i].valueU2;

                if (Blade.AffinityNodeCount <= threshold)
                {
                    Blade.CrownCount = i + 1;
                    return;
                }
            }
        }

        private int GetAffinityNodeCount()
        {
            int count = 5;

            count += Blade.BArts.Sum(x => x.MaxLevel);
            count += Blade.NArts.Sum(x => x.MaxLevel);
            count += Blade.BSkills.Sum(x => x.MaxLevel);
            count += Blade.FSkills.Sum(x => x.MaxLevel);

            return count;
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

        private static readonly byte[][] FSkillProbs =
        {
            new byte[] {50, 45, 5},
            new byte[] {40, 45, 15},
            new byte[] {30, 45, 25},
            new byte[] {20, 45, 35},
            new byte[] {10, 45, 45}
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

        private static readonly ItemCategory[] FavoriteCategories =
        {
            ItemCategory.StapleFoods,
            ItemCategory.Vegetables,
            ItemCategory.Meat,
            ItemCategory.Seafood,
            ItemCategory.Desserts,
            ItemCategory.Drinks,
            ItemCategory.Instruments,
            ItemCategory.Art,
            ItemCategory.Literature,
            ItemCategory.BoardGames,
            ItemCategory.Cosmetics,
            ItemCategory.Textiles
        };

        private static readonly BladeAttribute[] Attributes =
        {
            BladeAttribute.None,
            BladeAttribute.Fire,
            BladeAttribute.Water,
            BladeAttribute.Wind,
            BladeAttribute.Earth,
            BladeAttribute.Electric,
            BladeAttribute.Ice,
            BladeAttribute.Light,
            BladeAttribute.Dark
        };
    }
}
