using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using XbTool.Bdat;
using XbTool.Types;

namespace XbTool
{
    public static class Achievements
    {
        public static void PrintAchievements(BdatCollection tables, StreamWriter writer)
        {
            var achievements = GetBladeAchievements(tables.CHR_Bl);
            var csv = new CsvWriter(writer, new Configuration { HasHeaderRecord = false });
            writer.WriteLine("Blade ID,Blade Name,Skill,Type,Col,Row,Level,Idea Category,Idea Points,Condition,Count,Result");
            csv.WriteRecords(achievements);
        }

        private static IEnumerable<Achievement> GetAchievementSet(CHR_Bl blade, FLD_AchievementSet set, string skillName, string type, int column)
        {
            var achievements = new List<Achievement>();
            int level = 1;
            for (int i = 0; i < set._AchievementID.Length; i++)
            {
                var achieve = set._AchievementID[i];
                var output = new Achievement();
                achievements.Add(output);

                output.BladeId = blade.Id;
                output.BladeName = blade._Name.name;
                output.Skill = skillName;
                output.Type = type;
                output.Col = column;
                output.Row = i + 1;
                if (achieve == null) continue;

                output.Level = level++.ToString();
                FLD_QuestList quest = achieve._Task;
                if (quest == null) continue;

                FLD_QuestTask task = quest._NextQuestA._PurposeID;
                int ideaPoints = quest._RewardSetA.IdeaValue;
                var ideaCategory = (IdeaCategory)quest._RewardSetA.IdeaCategory;

                output.IdeaCategory = ideaPoints > 0 ? ideaCategory.ToString() : "";
                output.IdeaPoints = ideaPoints > 0 ? ideaPoints.ToString() : "";
                output.Condition = task._TaskLog1.name;
                output.Count = GetTaskCount(task) > 0 ? GetTaskCount(task).ToString() : "";
                output.Result = achieve._Task._ResultA.name;
            }

            return achievements;
        }

        private static IEnumerable<Achievement> GetBladeAchievements(BdatTable<CHR_Bl> tables)
        {
            var achievements = new List<Achievement>();
            foreach (CHR_Bl blade in tables.Items.Where(x => x._ArtsAchievement1 != null))
            {
                achievements.AddRange(GetAchievementSet(blade, blade._KeyAchievement, string.Empty, "Key", 1));

                for (int i = 0; i < 3; i++)
                {
                    achievements.AddRange(GetAchievementSet(blade, blade._ArtsAchievement[i], blade._BArts[i]?._Name.name, "Special", 2 + i));
                    achievements.AddRange(GetAchievementSet(blade, blade._SkillAchievement[i], blade._BSkill[i]?._Name.name, "Battle Skill", 5 + i));
                    achievements.AddRange(GetAchievementSet(blade, blade._FskillAchivement[i], blade._FSkill[i]?._Name.name, "Field Skill", 8 + i));
                }
            }

            return achievements.OrderBy(x => x.BladeId).ThenBy(x => x.Col).ThenBy(x => x.Row);
        }

        private static int GetTaskCount(FLD_QuestTask questTask)
        {
            switch (questTask._TaskID1)
            {
                case FLD_QuestBattle task:
                    return task.Count;
                case FLD_QuestCollect task:
                    return task.Count;
                case FLD_QuestUse task:
                    return task.ItemNumber;
                case FLD_QuestCondition task:
                    var condition = task._ConditionID._Condition1 as FLD_ConditionIdea;
                    return condition?.TrustPoint ?? -1;
                case FLD_QuestFieldSkillCount task:
                    return task.Count;
                case FLD_Achievement task:
                    return (int)task.Count;
                default:
                    return -1;
            }
        }

        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class Achievement
        {
            public int BladeId { get; set; }
            public string BladeName { get; set; }
            public string Skill { get; set; }
            public string Type { get; set; }
            public int Col { get; set; }
            public int Row { get; set; }
            public string Level { get; set; }
            public string IdeaCategory { get; set; }
            public string IdeaPoints { get; set; }
            public string Condition { get; set; }
            public string Count { get; set; }
            public string Result { get; set; }
        }
    }
}
