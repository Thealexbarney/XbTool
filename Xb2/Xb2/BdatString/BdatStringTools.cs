using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xb2.Bdat;

namespace Xb2.BdatString
{
    public static class BdatStringTools
    {
        public static (string value, string childTable, string childId) ReadValue(string tableName, int itemId, string memberName, BdatStringCollection tables, BdatInfo info)
        {
            string val = (string)tables[tableName][itemId]?[memberName];
            string display = val;
            string childTable = null;
            string childId = null;

            if (val == null || !info.FieldInfo.TryGetValue((tableName, memberName), out var field))
            {
                return (display, null, null);
            }

            int refId = int.Parse(val) + field.Adjust;

            switch (field.Type)
            {
                case BdatFieldType.Message:

                    display = (string)tables[field.RefTable][refId]?["name"];
                    if (display == null && val != "0")
                    {
                        display = refId.ToString();
                    }
                    break;
                case BdatFieldType.Reference:
                    ApplyRef(field.RefTable);
                    break;
                case BdatFieldType.Item:
                    ApplyRef(GetItemTable(refId));
                    break;
                case BdatFieldType.Condition:
                    var conditionType = (ConditionType)int.Parse((string)tables[tableName][itemId]?[field.RefField]);
                    ApplyRef(GetConditionTable(conditionType));
                    break;
                case BdatFieldType.Task:
                    var taskType = (TaskType)int.Parse((string)tables[tableName][itemId]?[field.RefField]);
                    ApplyRef(GetTaskTable(taskType));
                    break;
                case BdatFieldType.Character:
                    ApplyRef(GetCharacterTable(refId));
                    break;
                case BdatFieldType.Enhance:
                    display = GetEnhanceCaption(itemId, tables);
                    break;
                case BdatFieldType.TimeRange:
                    display = PrintTimeRange(int.Parse((string)tables[tableName][itemId]?[memberName]));
                    break;
                case BdatFieldType.WeatherBitfield:
                    display = PrintWeatherBits((WeatherBits)int.Parse((string)tables[tableName][itemId]?[memberName]));
                    break;
                case BdatFieldType.WeatherIdMap:
                    display = PrintWeatherIdMap(int.Parse((string)tables[tableName][itemId]?[memberName]), 13, tables);
                    break;
            }

            if (field.EnumType != null)
            {
                display = refId == 0 ? null : Enum.GetName(field.EnumType, refId);
            }

            return (display, childTable, childId);


            void ApplyRef(string refTable)
            {
                if (refTable == null || !tables[refTable].ContainsId(refId))
                {
                    display = refId == 0 ? null : refId.ToString();
                    return;
                }

                var refIdString = refId.ToString();
                display = refIdString;
                childTable = refTable;
                childId = refIdString;

                if (info.DisplayFields.TryGetValue(refTable, out var displayField))
                {
                    var child = ReadValue(refTable, refId, displayField, tables, info);
                    if (!string.IsNullOrWhiteSpace(child.value))
                    {
                        display = child.value;
                    }
                }
            }
        }

        private static string GetEnhanceCaption(int itemId, BdatStringCollection tables)
        {
            BdatStringItem item = tables["BTL_Enhance"][itemId];
            if (item == null) return null;

            int capId = int.Parse((string)item["Caption"]);
            string cap = (string)tables["btl_enhance_cap"][capId]?["name"];
            if (cap == null) return null;

            var sb = new StringBuilder(cap);

            var tags = ParseTags(cap);

            foreach (var tag in tags.OrderByDescending(x => x.Start))
            {
                if (tag.SubType != "Enhance") continue;
                string replace = string.Empty;

                if (tag.Values.Count <= 0)
                {
                    int effectId = int.Parse((string)item["EnhanceEffect"]);
                    replace = (string)tables["BTL_EnhanceEff"][effectId]["Param"];
                }
                else if (tag.Values.TryGetValue("kind", out var field))
                {
                    replace = (string)item[field];
                }

                sb.Remove(tag.Start, tag.Length);
                sb.Insert(tag.Start, replace);
            }

            return sb.ToString();
        }

        public static string GetItemTable(int id)
        {
            if (id > 61000) return "ITM_EtherCrystal";
            if (id > 60000) return "ITM_HanaAssist";
            if (id > 59000) return "ITM_HanaNArtsSet";
            if (id > 58000) return "ITM_HanaArtsEnh";
            if (id > 57000) return "ITM_HanaAtr";
            if (id > 56000) return "ITM_HanaRole";
            if (id > 50000) return "ITM_BoosterList";
            if (id > 45000) return "ITM_CrystalList";
            if (id > 40000) return "ITM_FavoriteList";
            if (id > 35000) return "ITM_TresureList";
            if (id > 30000) return "ITM_CollectionList";
            if (id > 27000) return "ITM_EventList";
            if (id > 26000) return "ITM_InfoList";
            if (id > 25000) return "ITM_PreciousList";
            if (id > 20000) return "ITM_SalvageList";
            if (id > 17000) return "ITM_OrbEquip";
            if (id > 14000) return "ITM_Orb";
            if (id > 10000) return "ITM_PcWpnChip";
            if (id > 5000) return "ITM_PcWpn";
            return "ITM_PcEquip";
        }

        public static string GetCharacterTable(int id)
        {
            if (id > 2000) return "RSC_NpcList";
            if (id > 1000) return "CHR_Bl";
            return "CHR_Dr";
        }

        public static string GetConditionTable(ConditionType conditionType)
        {
            switch (conditionType)
            {
                case ConditionType.Scenario:
                    return "FLD_ConditionScenario";
                case ConditionType.Quest:
                    return "FLD_ConditionQuest";
                case ConditionType.Environment:
                    return "FLD_ConditionEnv";
                case ConditionType.Flag:
                    return "FLD_ConditionFlag";
                case ConditionType.Item:
                    return "FLD_ConditionItem";
                case ConditionType.Party:
                    return "FLD_ConditionPT";
                case ConditionType.Idea:
                    return "FLD_ConditionIdea";
                case ConditionType.Level:
                    return "FLD_ConditionLevel";
                case ConditionType.Achievement:
                    return "FLD_ConditionAchievement";
                case ConditionType.FieldSkill:
                    return "FLD_ConditionFieldSkiiLevel";
            }

            return null;
        }

        public static string GetTaskTable(TaskType taskType)
        {
            switch (taskType)
            {
                case TaskType.Battle:
                    return "FLD_QuestBattle";
                case TaskType.T2:
                    break;
                case TaskType.Collect:
                    return "FLD_QuestCollect";
                case TaskType.UseItem:
                    return "FLD_QuestUse";
                case TaskType.ReachPlace:
                    return "FLD_QuestReach";
                case TaskType.Talk:
                    return "FLD_QuestTalk";
                case TaskType.T7:
                    break;
                case TaskType.Gimmick:
                    return "FLD_QuestGimmick";
                case TaskType.Mercenary:
                    break;
                case TaskType.QuestCondition:
                    return "FLD_QuestCondition";
                case TaskType.UseFieldSkill:
                    return "FLD_QuestFieldSkillCount";
                case TaskType.StatCount:
                    return "FLD_Achievement";
            }

            return null;
        }

        public static string PrintTimeRange(int timeRange)
        {
            var sb = new StringBuilder();
            bool first = true;

            for (int i = 0; i < TimeRanges.Length; i++)
            {
                if ((timeRange & (1 << i)) != 0)
                {
                    if (!first) sb.Append(", ");
                    sb.Append(TimeRanges[i]);
                    first = false;
                }
            }

            if ((timeRange & (1 << 15)) != 0)
            {
                if (!first) sb.Append(", ");
                sb.Append(TimeRanges[3]);
            }

            return sb.ToString();
        }

        public static string[] TimeRanges =
        {
            "7:00 - 11:59",
            "12:00 - 15:59",
            "16:00 - 18:59",
            "19:00 - 23:59",
            "0:00 - 4:59",
            "5:00 - 6:59",
            "7:00 - 18:59",
            "19:00 - 6:59",
            "0:00 - 23:59"
        };

        public static string PrintWeatherBits(WeatherBits weather)
        {
            var sb = new StringBuilder();
            bool first = true;

            foreach (var flag in weather.GetIndividualFlags())
            {
                if (!first) sb.Append(", ");
                sb.Append(flag);
                first = false;
            }

            return sb.ToString();
        }

        public static string PrintWeatherIdMap(int weather, int mapId, BdatStringCollection tables)
        {
            if (weather == 0xFF) return "All";

            var sb = new StringBuilder();
            bool first = true;

            Weather[] weathers = new Weather[4];
            BdatStringItem map = tables["FLD_maplist"][mapId];
            weathers[0] = (Weather)Enum.Parse(typeof(Weather), (string)map["wa_type"]);
            weathers[1] = (Weather)Enum.Parse(typeof(Weather), (string)map["wb_type"]);
            weathers[2] = (Weather)Enum.Parse(typeof(Weather), (string)map["wc_type"]);
            weathers[3] = (Weather)Enum.Parse(typeof(Weather), (string)map["wd_type"]);

            for (int i = 0; i < 4; i++)
            {
                if ((weather & (1 << i)) != 0)
                {
                    if (!first) sb.Append(", ");
                    sb.Append(weathers[i]);
                    first = false;
                }
            }

            return sb.ToString();
        }

        public static List<BdatTag> ParseTags(string text)
        {
            int pos = 0;
            var tags = new List<BdatTag>();

            while (true)
            {
                int start = text.IndexOf('[', pos);
                if (start == -1) break;

                if (start > 0 && text[start - 1] == '\\')
                {
                    pos = start + 1;
                    continue;
                }

                int end = text.IndexOf(']', start);
                int length = end - start + 1;
                pos = end + 1;

                var tagText = text.Substring(start + 1, length - 2).Trim(); // Leave out brackets
                var values = tagText.Split(' ');

                if (values.Length == 0) throw new InvalidDataException();

                var tagHead = values[0].Split(':');
                if (tagHead.Length != 2) throw new InvalidDataException();

                var tag = new BdatTag
                {
                    Type = tagHead[0],
                    SubType = tagHead[1],
                    Start = start,
                    Length = length
                };

                for (int i = 1; i < values.Length; i++)
                {
                    string[] keyVal = values[i].Split('=');
                    if (keyVal.Length != 2) throw new InvalidDataException();
                    tag.Values.Add(keyVal[0], keyVal[1]);
                }

                tags.Add(tag);
            }

            return tags;
        }
    }

    public class BdatTag
    {
        public string Type { get; set; }
        public string SubType { get; set; }
        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
