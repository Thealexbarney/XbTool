using XbTool.Types;

namespace XbTool.Salvaging
{
    public static class RunRaffle
    {
        public static void Run(BdatCollection tables)
        {
            var info = new RaffleInfo
            {
                SalvagePoint = 11,
                Cylinder = CylinderType.Normal,
                SalvageMasteryLevel = 0,
                ButtonChallengeLevel = 0
            };
            
            var raffle = new Raffle(info, tables);
            raffle.Create();
        }
    }
}
