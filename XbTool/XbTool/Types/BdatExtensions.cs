namespace XbTool.Types
{
    public static class BdatExtensions
    {
        public static object GetItem(this BdatCollection tables, int id)
        {
            if (id > 61000) return tables.ITM_EtherCrystal.GetItemOrNull(id);
            if (id > 60000) return tables.ITM_HanaAssist.GetItemOrNull(id);
            if (id > 59000) return tables.ITM_HanaNArtsSet.GetItemOrNull(id);
            if (id > 58000) return tables.ITM_HanaArtsEnh.GetItemOrNull(id);
            if (id > 57000) return tables.ITM_HanaAtr.GetItemOrNull(id);
            if (id > 56000) return tables.ITM_HanaRole.GetItemOrNull(id);
            if (id > 50000) return tables.ITM_BoosterList.GetItemOrNull(id);
            if (id > 45000) return tables.ITM_CrystalList.GetItemOrNull(id);
            if (id > 40000) return tables.ITM_FavoriteList.GetItemOrNull(id);
            if (id > 35000) return tables.ITM_TresureList.GetItemOrNull(id);
            if (id > 30000) return tables.ITM_CollectionList.GetItemOrNull(id);
            if (id > 27000) return tables.ITM_EventList.GetItemOrNull(id);
            if (id > 26000) return tables.ITM_InfoList.GetItemOrNull(id);
            if (id > 25000) return tables.ITM_PreciousList.GetItemOrNull(id);
            if (id > 20000) return tables.ITM_SalvageList.GetItemOrNull(id);
            if (id > 17000) return tables.ITM_OrbEquip.GetItemOrNull(id);
            if (id > 14000) return tables.ITM_Orb.GetItemOrNull(id);
            if (id > 10000) return tables.ITM_PcWpnChip.GetItemOrNull(id);
            if (id > 5000) return tables.ITM_PcWpn.GetItemOrNull(id);
            return tables.ITM_PcEquip.GetItemOrNull(id);
        }

        public static object GetTask(this BdatCollection tables, TaskType taskType, int id)
        {
            switch (taskType)
            {
                case TaskType.Battle:
                    return tables.FLD_QuestBattle.GetItemOrNull(id);
                case TaskType.T2:
                    break;
                case TaskType.Collect:
                    return tables.FLD_QuestCollect.GetItemOrNull(id);
                case TaskType.UseItem:
                    return tables.FLD_QuestUse.GetItemOrNull(id);
                case TaskType.ReachPlace:
                    return tables.FLD_QuestReach.GetItemOrNull(id);
                case TaskType.Talk:
                    return tables.FLD_QuestTalk.GetItemOrNull(id);
                case TaskType.T7:
                    break;
                case TaskType.Gimmick:
                    return tables.FLD_QuestGimmick.GetItemOrNull(id);
                case TaskType.Mercenary:
                    break;
                case TaskType.QuestCondition:
                    return tables.FLD_QuestCondition.GetItemOrNull(id);
                case TaskType.UseFieldSkill:
                    return tables.FLD_QuestFieldSkillCount.GetItemOrNull(id);
                case TaskType.StatCount:
                    return tables.FLD_Achievement.GetItemOrNull(id);
            }

            return null;
        }

        public static object GetCondition(this BdatCollection tables, ConditionType conditionType, int id)
        {
            switch (conditionType)
            {
                case ConditionType.Scenario:
                    return tables.FLD_ConditionScenario.GetItemOrNull(id);
                case ConditionType.Quest:
                    return tables.FLD_ConditionQuest.GetItemOrNull(id);
                case ConditionType.Environment:
                    return tables.FLD_ConditionEnv.GetItemOrNull(id);
                case ConditionType.Flag:
                    return tables.FLD_ConditionFlag.GetItemOrNull(id);
                case ConditionType.Item:
                    return tables.FLD_ConditionItem.GetItemOrNull(id);
                case ConditionType.Party:
                    return tables.FLD_ConditionPT.GetItemOrNull(id);
                case ConditionType.Idea:
                    return tables.FLD_ConditionIdea.GetItemOrNull(id);
                case ConditionType.Level:
                    return tables.FLD_ConditionLevel.GetItemOrNull(id);
                case ConditionType.Achievement:
                    return tables.FLD_ConditionAchievement.GetItemOrNull(id);
                case ConditionType.FieldSkill:
                    return tables.FLD_ConditionFieldSkiiLevel.GetItemOrNull(id);
            }

            return null;
        }
    }
}
