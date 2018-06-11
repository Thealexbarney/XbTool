using System;
using System.Linq;
using XbTool.Types;

namespace XbTool.Salvaging
{
    public class Raffle
    {
        FLD_SalvagePointList SalvagePoint { get; set; }
        FLD_SalvageTable SalvageTable { get; set; }
        public CylinderType Cylinder { get; set; }
        public int SkillLevel { get; set; }
        public int ButtonLevel { get; set; }
        private Random Rand { get; }

        public const int SkillEffectColl = 8;
        public const int ButtonEffect = 5;
        public const int DecayRateColl = 30;

        public const int SkillEffectTBox = 10;
        public const int DecayRateTBox = 25;

        public Raffle(RaffleInfo info, BdatCollection tables)
        {
            Cylinder = info.Cylinder;
            SkillLevel = info.SalvageMasteryLevel;
            ButtonLevel = info.ButtonChallengeLevel;
            SalvagePoint = tables.FLD_SalvagePointList[info.SalvagePoint];
            SalvageTable = SalvagePoint._SalvageTable[(int)Cylinder];
            Rand = new Random();
        }

        public void Create()
        {
            FLD_SalvageItemSet[] coll = new FLD_SalvageItemSet[3];
            FLD_SalvageItemSet[] treasure = new FLD_SalvageItemSet[3];

            {
                var collTables = SalvageTable._ColleTable;
                var collPer = SalvageTable._ColleTablePercent.Select(x => (int)x).ToArray();

                double decayMult = 1.0;
                double skillPercent = SkillLevel * 0.01;
                var skillMod = skillPercent * SkillEffectColl + 1;

                for (int i = 0; i < 3; i++)
                {
                    var c = ButtonLevel * (ButtonEffect * 0.01) + skillMod * decayMult;
                    if (c < Rand.NextDouble()) break;

                    coll[i] = collTables.ChooseRandom(Rand, collPer);
                    decayMult = DecayRateColl * .01 * decayMult;
                }
            }

            {
                var treasureTables = SalvageTable._TresureTable;
                var treasurePer = SalvageTable._TresureTablePercent.Select(x => (int)x).ToArray();
                var tBoxHit = SalvageTable.TresureBoxHit;

                double decayMult = 1.0;
                double skillPercent = SkillLevel * 0.01;
                var skillMod = skillPercent * SkillEffectTBox + tBoxHit * .0001;

                for (int i = 0; i < 3; i++)
                {
                    var c = ButtonLevel * (ButtonEffect * 0.01) + skillMod * decayMult;
                    if (c < Rand.NextDouble()) break;

                    treasure[i] = treasureTables.ChooseRandom(Rand, treasurePer);
                    decayMult = DecayRateTBox * .01 * decayMult;
                }
            }
        }
    }

    public class RaffleInfo
    {
        public int SalvagePoint { get; set; }
        public CylinderType Cylinder { get; set; }
        public int SalvageMasteryLevel { get; set; }
        public int ButtonChallengeLevel { get; set; }
    }

    public enum CylinderType
    {
        Normal,
        Silver,
        Golden,
        Premium
    }
}
