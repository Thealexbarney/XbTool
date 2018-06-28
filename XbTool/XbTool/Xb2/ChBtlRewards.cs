using System.Collections.Generic;
using System.Linq;
using System.Text;
using XbTool.CodeGen;
using XbTool.Common;
using XbTool.Types;
using XbTool.Xb2.GameData;

namespace XbTool.Xb2
{
    public static class ChBtlRewards
    {
        public static string PrintHtml(BdatCollection tables)
        {
            var sb = new Indenter();
            List<RewardSet> rewards = ReadAllRewards(tables);

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine("<title>Xenoblade 2 Challenge Battle Rewards</title>");
            sb.AppendLine("</head>");

            sb.AppendLine("<body>");
            sb.AppendLine("<pre>");
            foreach (var chBtl in rewards)
            {
                foreach (var set in chBtl.Rewards)
                {
                    sb.AppendLine($"{chBtl.Name} Treasure Box {set.BoxNum}");
                    sb.AppendLine($"Need {set.Need} Ether Cubes");
                    sb.AppendLine($"{set.AppointItem} x{set.AppointCount}");
                    sb.AppendLine($"{set.MinGold}-{set.MaxGold} gold");
                    sb.AppendLine($"{set.MinItems}-{set.MaxItems} items:");
                    var table = new Table("Name", "Prob");
                    foreach (var item in set.Items)
                    {
                        table.AddRow(item.Name, item.Percent.ToString("P"));
                    }

                    sb.AppendLine(table.Print());
                    sb.AppendLine();
                }
            }
            sb.AppendLine("</pre>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }

        public static string PrintCsv(BdatCollection tables)
        {
            var sb = new StringBuilder();
            List<RewardSet> rewards = ReadAllRewards(tables);

            sb.AppendLine("Challenge,Challenge Name,Box,Item,Item Name,Prob");

            foreach (var chBtl in rewards)
            {
                foreach (var set in chBtl.Rewards)
                {
                    foreach (var item in set.Items)
                    {
                        sb.AppendLine(
                            $"{chBtl.Id},\"{chBtl.Name}\",{set.BoxNum},{item.Id},\"{item.Name}\",{item.Percent:R}");
                    }
                }
            }

            return sb.ToString();
        }

        private static List<RewardSet> ReadAllRewards(BdatCollection tables)
        {
            var rewards = new List<RewardSet>();

            foreach (var chBtl in tables.BTL_ChBtl)
            {
                rewards.Add(ReadRewardSet(tables, chBtl.Id));
            }

            return rewards;
        }

        public static RewardSet ReadRewardSet(BdatCollection tables, int chBtlId)
        {
            BTL_ChBtl chBtl = tables.BTL_ChBtl[chBtlId];
            var rewards = new RewardSet { Id = chBtlId, Name = chBtl._Name.name };
            for (int i = 0; i < 3; i++)
            {
                Reward reward = ReadReward(tables, chBtl._TresureSet[i].Id);
                reward.BoxNum = i + 1;
                reward.Need = chBtl._TresureNeed[i];
                rewards.Rewards.Add(reward);
            }

            return rewards;
        }

        public static Reward ReadReward(BdatCollection tables, int rewardSetId)
        {
            var set = tables.BTL_ChBtlRewardSet[rewardSetId];
            var reward = new Reward
            {
                Id = rewardSetId,
                MinGold = (int)set.GoldMin,
                MaxGold = (int)set.GoldMax,
                MinItems = set.ItemNumMin,
                MaxItems = set.ItemNumMax,
                AppointCount = set.AppointItemNum,
                AppointItem = ItemData.GetName(set.AppointItem, tables)
            };

            int minValue = set.ItemValueMin;
            int maxValue = set.ItemValueMax;

            reward.Items = tables.BTL_ChBtlRewardItem.Where(x => x.ItemValue >= minValue && x.ItemValue <= maxValue)
                .Select(x => new Item { Id = x.ItemID, Prob = x.Param1 }).ToList();

            foreach (var item in reward.Items)
            {
                var cat = ItemData.GetItemCategory(item.Id);
                if (cat == set._UpCategory1 || cat == set._UpCategory2) item.Prob *= 2;
                if (cat == set._DownCategory1 || cat == set._DownCategory2) item.Prob /= 2;

                if (item.Id == set.UpItemID1
                    || item.Id == set.UpItemID2
                    || item.Id == set.UpItemID3
                    || item.Id == set.UpItemID4)
                {
                    item.Prob *= 2;
                }
            }

            var totalProb = reward.Items.Sum(x => x.Prob);

            foreach (var item in reward.Items)
            {
                item.Name = ItemData.GetName(item.Id, tables);
                item.Percent = (float)item.Prob / totalProb;
            }

            return reward;
        }

        public class Item
        {
            public int Id;
            public string Name;
            public int Prob;
            public float Percent;
        }

        public class Reward
        {
            public int Id;
            public int BoxNum;
            public int Need;
            public int MinGold;
            public int MaxGold;
            public int MinItems;
            public int MaxItems;
            public int AppointCount;
            public string AppointItem;
            public List<Item> Items = new List<Item>();
        }

        public class RewardSet
        {
            public int Id;
            public string Name;
            public List<Reward> Rewards = new List<Reward>();
        }
    }
}
