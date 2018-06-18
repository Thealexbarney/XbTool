using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XbTool.Types;

namespace XbTool.Xb2.Quest
{
    public static class Export
    {
        public static string ExportQuests(IList<QuestParent> quests)
        {
            var sb = new StringBuilder();
            var delim = new String('=', 20);

            foreach (var quest in quests)
            {
                sb.AppendLine(delim);
                sb.AppendLine(quest.Title);

                foreach (var child in quest.Children)
                {
                    sb.AppendLine();
                    sb.AppendLine($"Stage {child.Stage}");
                    foreach (var task in child.Tasks)
                    {
                        PrintTask(sb, task);
                    }
                }
            }

            return sb.ToString();
        }

        private static void PrintTask(StringBuilder sb, QuestTask task)
        {
            sb.AppendLine(task.Log);
            sb.AppendLine($"Task: {task.Type}");

            switch (task.Task)
            {
                case FLD_QuestBattle battle:
                    if (battle.EnemyID > 0)
                    {
                        var enemy = battle._EnemyID;
                        var rsc = enemy._ParamID?._ResourceID;
                        sb.AppendLine($"{enemy._Name?.name}; {enemy.Debug_Name} ;{rsc?.DebugName}; {rsc?._TypeFamily?._name.name} {rsc?._TypeGenus?._NAME?.name}");
                    }

                    if (battle.EnemyGroupID > 0)
                    {
                        foreach (var enemy in battle._EnemyGroupID._EnemyID.Where(x => x != null))
                        {
                            var rsc = enemy._ParamID?._ResourceID;
                            sb.AppendLine($"{enemy._Name?.name}; {enemy.Debug_Name} ;{rsc?.DebugName}; {rsc?._TypeFamily?._name.name} {rsc?._TypeGenus?._NAME?.name}");
                        }
                    }

                    break;
            }
        }
    }
}
