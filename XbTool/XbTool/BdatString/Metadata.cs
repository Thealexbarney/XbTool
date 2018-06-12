using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XbTool.Bdat;
using XbTool.Types;

namespace XbTool.BdatString
{
    public static class Metadata
    {
        public static void ApplyMetadata(BdatStringCollection tables)
        {
            SetXb2EffectCaptions(tables);
            foreach ((string table, string member) reference in tables.Bdats.BdatFields.Keys)
            {
                BdatStringTable table = tables[reference.table];

                foreach (BdatStringItem item in table.Items)
                {
                    ResolveItemRef(item[reference.member]);
                }
            }
        }

        public static void ResolveItemRef(BdatStringValue value)
        {
            if (value.Resolved) return;

            BdatStringItem item = value.Parent;
            BdatStringTable table = item.Table;
            BdatStringCollection tables = table.Collection;
            BdatMember member = value.Member;
            BdatFieldInfo field = member.Metadata;

            if (value.Array != null)
            {
                foreach (var element in value.Array)
                {
                    ResolveItemRef(element);
                }

                value.Resolved = true;
                return;
            }

            if (field == null)
            {
                value.Resolved = true;
                return;
            }

            int refId = int.Parse(value.ValueString) + field.Adjust;

            switch (field.Type)
            {
                case BdatFieldType.Message:
                    value.Display = tables[field.RefTable][refId]?["name"].DisplayString;
                    if (string.IsNullOrWhiteSpace(value.DisplayString) && refId > 0)
                    {
                        value.Display = refId.ToString();
                    }
                    break;
                case BdatFieldType.Reference:
                    ApplyRef(field.RefTable);
                    break;
                case BdatFieldType.Item:
                    if (tables.Game == Game.XB2) ApplyRef(BdatStringTools.GetItemTableXb2(refId));
                    if (tables.Game == Game.XB1)
                    {
                        var itemType = (ItemTypeXb1)int.Parse(item[field.RefField].ValueString);
                        ApplyRef(BdatStringTools.GetItemTableXb1(itemType));
                    }
                    if (tables.Game == Game.XBX)
                    {
                        var itemType = (ItemTypeXbx)int.Parse(item[field.RefField].ValueString);
                        ApplyRef(BdatStringTools.GetItemTableXbx(itemType));
                    }

                    break;
                case BdatFieldType.Event:
                    ApplyRef(BdatStringTools.GetEventTable(refId));
                    break;
                case BdatFieldType.EventSetup:
                    ApplyRef(BdatStringTools.GetEventSetupTable(refId));
                    break;
                case BdatFieldType.QuestFlag:
                    ApplyRef(BdatStringTools.GetQuestListTable(refId));
                    break;
                case BdatFieldType.QuestFlagIra:
                    ApplyRef(BdatStringTools.GetQuestListIraTable(refId));
                    break;
                case BdatFieldType.Condition:
                    var conditionType = (ConditionType)int.Parse(item[field.RefField].ValueString);
                    ApplyRef(BdatStringTools.GetConditionTable(conditionType));
                    break;
                case BdatFieldType.Task:
                    var taskType = (TaskType)int.Parse(item[field.RefField].ValueString);
                    ApplyRef(BdatStringTools.GetTaskTable(taskType));
                    break;
                case BdatFieldType.ShopTable:
                    var shopType = (ShopType)int.Parse(item[field.RefField].ValueString);
                    ApplyRef(BdatStringTools.GetShopTable(shopType));
                    break;
                case BdatFieldType.Character:
                    ApplyRef(BdatStringTools.GetCharacterTable(refId));
                    break;
                case BdatFieldType.Enhance:
                    value.Display = BdatStringTools.GetEnhanceCaption(value);
                    break;
                case BdatFieldType.WeatherIdMap:
                    value.Display = BdatStringTools.PrintWeatherIdMap(refId, 13, tables);
                    break;
                case BdatFieldType.PouchBuff:
                    value.Display = GetPouchBuffCaption(value);
                    break;
                case BdatFieldType.Flag:
                    AddFlag(tables, field.RefTable, refId, value);
                    break;
                case BdatFieldType.GameFlag:
                    var flagType = item[field.RefField].ValueString;
                    AddFlag(tables, flagType + "bit", refId, value);
                    break;
                case BdatFieldType.Change:
                    var changeType = (ChangeType)int.Parse(item[field.RefField].ValueString);
                    if (changeType == ChangeType.scenario)
                    {
                        AddFlag(tables, "Scenario", refId, value);
                    }
                    break;
                case BdatFieldType.ItemComment:
                    ApplyRef(item.Id >= 1852 ? "MNU_item_mes_b" : "MNU_item_mes_a");
                    break;
                case BdatFieldType.Layer:
                    ApplyRef(BdatStringTools.GetLayerTable(refId));
                    break;
            }

            if (field.EnumType != null)
            {
                if (field.EnumType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                {
                    value.Display = BdatStringTools.PrintEnumFlags(field.EnumType, refId);
                }
                else
                {
                    value.Display = Enum.GetName(field.EnumType, refId);
                }
            }

            value.Resolved = true;

            void ApplyRef(string refTable)
            {
                if (refTable == null || !tables[refTable].ContainsId(refId))
                {
                    value.Display = refId == 0 ? null : refId.ToString();
                    return;
                }

                var reft = tables[refTable][refId].Display;

                if (reft != null)
                {
                    if (!reft.Resolved)
                    {
                        ResolveItemRef(reft);
                    }

                    if (!string.IsNullOrWhiteSpace(reft.DisplayString))
                    {
                        value.Display = reft.Display;
                    }
                }

                value.Reference = tables[refTable][refId];
                tables[refTable][refId].ReferencedBy.Add(value.Parent);
            }
        }

        public static void AddFlag(BdatStringCollection tables, string flagName, int refId, BdatStringValue value)
        {
            if (refId == 0)
            {
                value.Display = string.Empty;
                return;
            }

            flagName = "FLG_" + flagName;

            if (!tables.Tables.TryGetValue(flagName, out BdatStringTable flagTable))
            {
                flagTable = CreateFlagTable(tables, flagName);
                tables.Add(flagTable);
            }

            BdatStringItem flagItem = flagTable[refId];

            if (flagItem == null)
            {
                flagItem = new BdatStringItem();
                flagItem.Id = refId;
                flagItem.Table = flagTable;
                flagTable[refId] = flagItem;
            }

            value.Reference = flagItem;
            flagItem.ReferencedBy.Add(value.Parent);
        }

        public static BdatStringTable CreateFlagTable(BdatStringCollection tables, string name)
        {
            return new BdatStringTable
            {
                Collection = tables,
                Name = name,
                BaseId = 1,
                Members = new BdatMember[0],
                Items = new BdatStringItem[ushort.MaxValue],
                Filename = "flags"
            };
        }

        public static string GetPouchBuffCaption(BdatStringValue value)
        {
            if (value == null) return null;

            var item = value.Parent;
            var field = value.Member.Metadata;
            var tables = item.Table.Collection;

            int captionId = int.Parse(value.ValueString);
            BdatStringValue captionValue = tables["BTL_PouchBuff"][captionId]?["Name"];

            if (captionValue == null) return null;

            if (!captionValue.Resolved)
            {
                ResolveItemRef(captionValue);
            }

            string caption = captionValue.DisplayString;
            if (caption == null) return null;

            var sb = new StringBuilder(caption);

            var tags = BdatStringTools.ParseTags(caption);

            foreach (var tag in tags.OrderByDescending(x => x.Start))
            {
                if (tag.SubType != "PouchParam") continue;

                float buffValue = float.Parse(item[field.RefField].ValueString);

                sb.Remove(tag.Start, tag.Length);
                sb.Insert(tag.Start, buffValue);
            }

            return sb.ToString();
        }

        public static void SetXb2EffectCaptions(BdatStringCollection tables)
        {
            if (!tables.Tables.ContainsKey("BTL_Enhance") || !tables.Tables.ContainsKey("BTL_EnhanceEff")) return;

            BdatStringTable enhances = tables["BTL_Enhance"];
            BdatStringTable effects = tables["BTL_EnhanceEff"];

            List<BdatMember> newMembers = effects.Members.ToList();
            var captionMember = new BdatMember("Caption", BdatMemberType.Scalar, BdatValueType.String);
            newMembers.Add(captionMember);
            effects.Members = newMembers.ToArray();

            foreach (var effect in effects.Items)
            {
                effect.AddMember("Caption", new BdatStringValue("0", effect, captionMember));
                effect["Caption"].Display = "";
            }

            foreach (var enhance in enhances.Items)
            {
                int captionId = int.Parse(enhance["Caption"].ValueString);
                if (captionId == 0) continue;

                var effect = effects[int.Parse(enhance["EnhanceEffect"].ValueString)]["Caption"];

                string caption = tables["btl_enhance_cap"][captionId]?["name"].ValueString;

                effect.Value = captionId.ToString();
                effect.Display = caption;
            }

            foreach (var enhance in enhances.Items)
            {
                var effectCaptionId = int.Parse(enhance["EnhanceEffect"].ValueString);
                int enhanceCaptionId = int.Parse(enhance["Caption"].ValueString);
                if (enhanceCaptionId != 0 || effectCaptionId == 0) continue;

                var effect = effects[effectCaptionId]["Caption"];
                enhance["Caption"].Value = effect.ValueString;
            }
        }
    }
}
