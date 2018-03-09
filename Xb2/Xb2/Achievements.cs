using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Xb2.BdatString;
using Xb2.Types;

namespace Xb2
{
    public static class Achievements
    {
        public static void PrintAchievements(BdatCollection tables)
        {
            var achieves = GetAchievements(tables);
            Console.WriteLine("Blade ID,Blade Name,Skill,Type,Col,Level,Idea Category,Idea Points,Condition,Count,Result");
            foreach (var achieve in achieves)
            {
                Console.Write(PrintBladeAchievement(achieve));
            }
        }

        public static string PrintBladeAchievement(BladeAchievements blade)
        {
            var sw = new StringWriter();
            var csv = new CsvWriter(sw);

            for (int i = 0; i < blade.Sets.Length; i++)
            {
                var set = blade.Sets[i];
                for (int j = 0; j < set.Achievements.Length; j++)
                {
                    var achieve = set.Achievements[j];

                    csv.WriteField(blade.Id);
                    csv.WriteField(blade.Name);
                    csv.WriteField(set.Name);
                    csv.WriteField(set.Type);
                    csv.WriteField(i + 1);
                    csv.WriteField(j + 1);
                    if (achieve == null)
                    {
                        csv.NextRecord();
                        continue;
                    }
                    csv.WriteField(achieve.RewardPoints > 0 ? achieve.RewardCategory.ToString() : "");
                    csv.WriteField(achieve.RewardPoints > 0 ? achieve.RewardPoints.ToString() : "");
                    csv.WriteField(achieve.Condition);
                    csv.WriteField(achieve.Count > 0 ? achieve.Count.ToString() : "");
                    csv.WriteField(achieve.Result);
                    csv.NextRecord();
                }
            }

            return sw.ToString();
        }

        public static List<BladeAchievements> GetAchievements(BdatCollection tables)
        {
            var blades = new List<BladeAchievements>();
            int baseId = tables.CHR_Bl.BaseId;
            for (int i = 0; i < tables.CHR_Bl.Items.Length; i++)
            {
                CHR_Bl blade = tables.CHR_Bl.Items[i];
                if (blade.ArtsAchievement1 == 0) continue;

                var ba = new BladeAchievements();
                ba.Name = tables.chr_bl_ms[blade.Name].name;
                ba.Id = baseId + i;
                ba.Sets[0] = GetAchievementSet(tables, blade.KeyAchievement, "Key");
                ba.Sets[1] = GetAchievementSet(tables, blade.ArtsAchievement1, "Special");
                ba.Sets[2] = GetAchievementSet(tables, blade.ArtsAchievement2, "Special");
                ba.Sets[3] = GetAchievementSet(tables, blade.ArtsAchievement3, "Special");
                ba.Sets[4] = GetAchievementSet(tables, blade.SkillAchievement1, "Battle Skill");
                ba.Sets[5] = GetAchievementSet(tables, blade.SkillAchievement2, "Battle Skill");
                ba.Sets[6] = GetAchievementSet(tables, blade.SkillAchievement3, "Battle Skill");
                ba.Sets[7] = GetAchievementSet(tables, blade.FskillAchivement1, "Field Skill");
                ba.Sets[8] = GetAchievementSet(tables, blade.FskillAchivement2, "Field Skill");
                ba.Sets[9] = GetAchievementSet(tables, blade.FskillAchivement3, "Field Skill");

                ba.Sets[1].Name = tables.btl_arts_bl_ms[tables.BTL_Arts_Bl[blade.BArts1].Name].name;
                if (blade.BArts2 != 0)
                    ba.Sets[2].Name = tables.btl_arts_bl_ms[tables.BTL_Arts_Bl[blade.BArts2].Name].name;
                if (blade.BArts3 != 0)
                    ba.Sets[3].Name = tables.btl_arts_bl_ms[tables.BTL_Arts_Bl[blade.BArts3].Name].name;

                ba.Sets[4].Name = tables.btl_skill_bl_name[tables.BTL_Skill_Bl[blade.BSkill1].Name].name;
                ba.Sets[5].Name = tables.btl_skill_bl_name[tables.BTL_Skill_Bl[blade.BSkill2].Name].name;
                ba.Sets[6].Name = tables.btl_skill_bl_name[tables.BTL_Skill_Bl[blade.BSkill3].Name].name;

                ba.Sets[7].Name = tables.fld_fieldskilltxt[tables.FLD_FieldSkillList[blade.FSkill1].Name].name;

                if (blade.FSkill2 != 0)
                    ba.Sets[8].Name = tables.fld_fieldskilltxt[tables.FLD_FieldSkillList[blade.FSkill2].Name].name;

                if (blade.FSkill3 != 0)
                    ba.Sets[9].Name = tables.fld_fieldskilltxt[tables.FLD_FieldSkillList[blade.FSkill3].Name].name;

                blades.Add(ba);
            }

            return blades;
        }

        public static AchievementSet GetAchievementSet(BdatCollection tables, int setId, string type)
        {
            if (setId == 0) return null;
            var setIn = tables.FLD_AchievementSet[setId];
            var set = new AchievementSet();

            set.Type = type;
            set.Achievements[0] = GetAchievement(tables, setIn.AchievementID1);
            set.Achievements[1] = GetAchievement(tables, setIn.AchievementID2);
            set.Achievements[2] = GetAchievement(tables, setIn.AchievementID3);
            set.Achievements[3] = GetAchievement(tables, setIn.AchievementID4);
            set.Achievements[4] = GetAchievement(tables, setIn.AchievementID5);

            return set;
        }

        public static Achievement GetAchievement(BdatCollection tables, int achieveId)
        {
            if (achieveId == 0) return null;
            var achieve = new Achievement();
            int taskId = tables.FLD_AchievementList[achieveId].Task;
            if (taskId == 0) return achieve;

            var qla = tables.FLD_QuestListAchievement;
            var qta = tables.FLD_QuestTaskAchievement;
            achieve.Result = tables.fld_quest_achievement[qla[taskId].ResultA].name.Replace('\n', ' ');
            int purposeId = qla[qla[taskId].NextQuestA].PurposeID;
            int rewardId = qla[taskId].RewardSetA;
            var reward = tables.FLD_QuestReward[rewardId];
            achieve.Condition = tables.fld_quest_achievement[qta[purposeId].TaskLog1].name.Replace('\n', ' ');
            achieve.Count = GetCount(tables, purposeId);
            achieve.RewardCategory = (IdeaCategory)reward.IdeaCategory;
            achieve.RewardPoints = reward.IdeaValue;

            return achieve;
        }

        public static int GetCount(BdatCollection tables, int qtId)
        {
            var qta = tables.FLD_QuestTaskAchievement[qtId];
            var taskType = (TaskType)qta.TaskType1;
            var taskId = qta.TaskID1;

            switch (taskType)
            {
                case TaskType.Battle:
                    return tables.FLD_QuestBattle[taskId].Count;
                case TaskType.Collect:
                    return tables.FLD_QuestCollect[taskId].Count;
                case TaskType.UseItem:
                    return tables.FLD_QuestUse[taskId].ItemNumber;
                case TaskType.QuestCondition:
                    int conditionId = tables.FLD_QuestCondition[taskId].ConditionID;
                    var conditionType = (ConditionType)tables.FLD_ConditionList[conditionId].ConditionType1;
                    if (conditionType != ConditionType.Idea) break;
                    var condition1 = tables.FLD_ConditionList[conditionId].Condition1;
                    return tables.FLD_ConditionIdea[condition1].TrustPoint;
                case TaskType.UseFieldSkill:
                    return tables.FLD_QuestFieldSkillCount[taskId].Count;
                case TaskType.StatCount:
                    return (int)tables.FLD_Achievement[taskId].Count;
            }

            return -1;
        }
    }

    public class BladeAchievements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AchievementSet[] Sets { get; } = new AchievementSet[10];
    }

    public class AchievementSet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Achievement[] Achievements { get; } = new Achievement[5];
    }

    public class Achievement
    {
        public string Condition { get; set; }
        public int Count { get; set; }
        public string Result { get; set; }
        public IdeaCategory RewardCategory { get; set; }
        public int RewardPoints { get; set; }
    }
}
