using System.Collections.Generic;
using System.IO;
using System.Linq;
using XbTool.Bdat;
using XbTool.Types;

namespace XbTool.Xb2.Quest
{
    public static class Read
    {
        public static void ExportQuests(BdatCollection tables, string outDir)
        {
            Directory.CreateDirectory(outDir);

            var quests = ReadQuests(tables.FLD_QuestListNormal);
            var export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests normal.txt"), export);

            quests = ReadQuests(tables.FLD_QuestListBlade);
            export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests blade.txt"), export);

            quests = ReadQuests(tables.FLD_QuestListMini);
            export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests mini.txt"), export);

            quests = ReadQuests(tables.FLD_QuestList);
            export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests.txt"), export);

            quests = ReadQuests(tables.FLD_QuestListIra);
            export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests ira.txt"), export);

            quests = ReadQuests(tables.FLD_QuestListNormalIra);
            export = Export.ExportQuests(quests);
            File.WriteAllText(Path.Combine(outDir, "quests normal ira.txt"), export);
        }

        public static List<QuestParent> ReadQuests(BdatTable<FLD_QuestList> table)
        {
            var parents = table.Where(x => x.FlagPRT != 0).ToArray();
            var quests = new List<QuestParent>();

            foreach (var parent in parents)
            {
                var quest = ReadParentQuest(parent);
                quests.Add(quest);
            }

            return quests;
        }

        public static QuestParent ReadParentQuest(FLD_QuestList parentQuest)
        {
            var quest = new QuestParent();
            quest.Id = parentQuest.Id;
            quest.Flag = parentQuest.FlagPRT;
            quest.Summary = parentQuest._Summary?.name;
            quest.Title = parentQuest._QuestTitle?.name;
            if (string.IsNullOrWhiteSpace(quest.Title)) quest.Title = $"Quest #{quest.Id}";

            var childQuest = parentQuest._NextQuestA;
            int stage = 1;
            while (childQuest != null)
            {
                var child = ReadChildQuest(childQuest);
                child.Parent = quest;
                child.Stage = stage++;

                quest.Children.Add(child);
                childQuest = childQuest._NextQuestA;
            }

            return quest;
        }

        public static QuestChild ReadChildQuest(FLD_QuestList childQuest)
        {
            var quest = new QuestChild();
            quest.Id = childQuest.Id;
            quest.Flag = childQuest.FlagCLD;

            var purpose = childQuest._PurposeID;
            if (purpose?.TaskType1 > 0)
            {
                var task = new QuestTask();
                task.Type = purpose._TaskType1;
                task.Id = purpose.TaskID1;
                task.Log = purpose._TaskLog1?.name;
                task.Condition = purpose._TaskCondition1;
                task.Task = purpose._TaskID1;

                quest.Tasks.Add(task);
            }

            if (purpose?.TaskType2 > 0)
            {
                var task = new QuestTask();
                task.Type = purpose._TaskType2;
                task.Id = purpose.TaskID2;
                task.Log = purpose._TaskLog2?.name;
                task.Condition = purpose._TaskCondition2;
                task.Task = purpose._TaskID2;

                quest.Tasks.Add(task);
            }

            return quest;
        }
    }

    public class QuestParent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Flag { get; set; }
        public List<QuestChild> Children { get; } = new List<QuestChild>();
    }

    public class QuestChild
    {
        public int Id { get; set; }
        public QuestParent Parent { get; set; }
        public int Stage { get; set; }
        public int Flag { get; set; }
        public List<QuestTask> Tasks { get; } = new List<QuestTask>();

    }

    public class QuestTask
    {
        public int Id { get; set; }
        public TaskType Type { get; set; }
        public string Log { get; set; }
        public FLD_ConditionList Condition { get; set; }
        public object Task { get; set; }
    }
}
