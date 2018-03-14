using System.IO;
using System.Linq;
using CsvHelper;
using Xb2.Bdat;
using Xb2.BdatString;
using Xb2.Types;

namespace Xb2
{
    public static class Achievements
    {
        public static void PrintAchievements(BdatCollection tables, StreamWriter writer)
        {
            var csv = new CsvWriter(writer);
            writer.WriteLine("Blade ID,Blade Name,Skill,Type,Col,Level,Idea Category,Idea Points,Condition,Count,Result");
            PrintBladeAchievements(tables.CHR_Bl, csv);
        }

        private static void PrintAchievement(CsvWriter csv, CHR_Bl blade, FLD_AchievementSet set, string skillName, string type, int column)
        {
            for (int i = 0; i < set._AchievementID.Length; i++)
            {
                var achieve = set._AchievementID[i];
                FLD_QuestList quest = achieve?._Task;

                csv.WriteField(blade.Id);
                csv.WriteField(blade._Name.name);
                csv.WriteField(skillName);
                csv.WriteField(type);
                csv.WriteField(column);
                csv.WriteField(i + 1);
                if (quest == null)
                {
                    csv.NextRecord();
                    continue;
                }

                FLD_QuestTask task = quest._NextQuestA._PurposeID;
                int ideaPoints = quest._RewardSetA.IdeaValue;
                var ideaCategory = (IdeaCategory)quest._RewardSetA.IdeaCategory;

                csv.WriteField(ideaPoints > 0 ? ideaCategory.ToString() : "");
                csv.WriteField(ideaPoints > 0 ? ideaPoints.ToString() : "");
                csv.WriteField(task._TaskLog1.name);
                csv.WriteField(GetTaskCount(task) > 0 ? GetTaskCount(task).ToString() : "");
                csv.WriteField(achieve._Task._ResultA.name);
                csv.NextRecord();
            }
        }

        private static void PrintBladeAchievements(BdatTable<CHR_Bl> tables, CsvWriter csv)
        {
            foreach (CHR_Bl blade in tables.Items.Where(x => x._ArtsAchievement1 != null))
            {
                PrintAchievement(csv, blade, blade._KeyAchievement, string.Empty, "Key", 1);

                for (int i = 0; i < 3; i++)
                {
                    PrintAchievement(csv, blade, blade._ArtsAchievement[i], blade._BArts[i]?._Name.name, "Special", 2 + i);
                }

                for (int i = 0; i < 3; i++)
                {
                    PrintAchievement(csv, blade, blade._SkillAchievement[i], blade._BSkill[i]?._Name.name, "Battle Skill", 5 + i);
                }

                for (int i = 0; i < 3; i++)
                {
                    PrintAchievement(csv, blade, blade._FskillAchivement[i], blade._FSkill[i]?._Name.name, "Field Skill", 8 + i);
                }
            }
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
    }
}
