using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XbTool.Types;
using XbTool.Xb2.GameData;

namespace XbTool.Xb2.Quest
{
    public static class Export
    {
        public static string ExportQuests(IList<QuestParent> quests, BdatCollection tables)
        {
            var sb = new StringBuilder();
            string delim = new String('=', 20);

            foreach (QuestParent quest in quests)
            {
                sb.AppendLine(delim);
                sb.AppendLine(quest.Title);

                foreach (QuestChild child in quest.Children)
                {
                    sb.AppendLine();
                    sb.AppendLine($"Stage {child.Stage}");
                    foreach (QuestTask task in child.Tasks)
                    {
                        PrintTask(sb, task, tables);
                    }
                }
            }

            return sb.ToString();
        }

        private static void PrintTask(StringBuilder sb, QuestTask task, BdatCollection tables)
        {
            sb.AppendLine(task.Log);
            sb.AppendLine($"Task: {task.Type}");

            switch (task.Task)
            {
                case FLD_QuestBattle battle:
                    PrintBattleTask(sb, battle);
                    break;
                case FLD_QuestTalk talk:
                    PrintTalkTask(sb, talk, tables);
                    break;
                case FLD_QuestReach reach:
                    PrintReachTask(sb, reach, tables);
                    break;
            }
        }

        private static void PrintBattleTask(StringBuilder sb, FLD_QuestBattle battle)
        {
            if (battle.EnemyID > 0)
            {
                CHR_EnArrange enemy = battle._EnemyID;
                RSC_En rsc = enemy._ParamID?._ResourceID;
                sb.AppendLine(
                    $"{enemy._Name?.name}; {enemy.Debug_Name} ;{rsc?.DebugName}; {rsc?._TypeFamily?._name.name} {rsc?._TypeGenus?._NAME?.name}");
            }

            if (battle.EnemyGroupID > 0)
            {
                foreach (CHR_EnArrange enemy in battle._EnemyGroupID._EnemyID.Where(x => x != null))
                {
                    RSC_En rsc = enemy._ParamID?._ResourceID;
                    sb.AppendLine(
                        $"{enemy._Name?.name}; {enemy.Debug_Name} ;{rsc?.DebugName}; {rsc?._TypeFamily?._name.name} {rsc?._TypeGenus?._NAME?.name}");
                }
            }
        }

        private static void PrintTalkTask(StringBuilder sb, FLD_QuestTalk talk, BdatCollection tables)
        {
            object character = CharacterData.GetCharacter(talk.NpcID, tables);

            switch (character)
            {
                case RSC_NpcList npc:
                    sb.AppendLine($"{npc._Name?.name}; {npc._Roots}; {npc._Gender}");
                    break;
                case CHR_Bl blade:
                    sb.AppendLine($"{blade._Name?.name}");
                    break;
                case CHR_Dr driver:
                    sb.AppendLine($"{driver._Name?.name}");
                    break;
            }
        }

        private static void PrintReachTask(StringBuilder sb, FLD_QuestReach reach, BdatCollection tables)
        {
            string name = GimmickData.GetPlaceName(reach._Category, reach.PlaceID, tables);
            sb.AppendLine($"{reach._Category}; {reach._MapID?._nameID?.name}; {name}");
        }
    }
}
