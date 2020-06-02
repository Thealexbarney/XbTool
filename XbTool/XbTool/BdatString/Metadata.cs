using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using XbTool.Bdat;
using XbTool.Common;
using XbTool.Types;
using XbTool.Xb2.GameData;

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
                foreach (BdatStringValue element in value.Array)
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

            if (!int.TryParse(value.ValueString, out int refId))
            {
                value.Resolved = true;
                return;
            }

            refId += field.Adjust;

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
                case BdatFieldType.OneWayReference:
                    ApplyRef(field.RefTable, false);
                    break;
                case BdatFieldType.Item:
                    if (tables.Game == Game.XB2) ApplyRef(BdatStringTools.GetItemTableXb2(refId));
                    if (tables.Game == Game.XB1 || tables.Game == Game.XB1DE)
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
                case BdatFieldType.Quest when tables.Game == Game.XB1DE:
                    ApplyRef(BdatStringTools.GetQuestJournalTableXb1(refId));
                    break;
                case BdatFieldType.QuestMenu when tables.Game == Game.XB1DE:
                    ApplyRef(BdatStringTools.GetQuestMenuTableXb1(refId));
                    break;
                case BdatFieldType.Quest:
                    throw new InvalidDataException();
                case BdatFieldType.QuestFlag:
                    ApplyRef(BdatStringTools.GetQuestListTable(refId));
                    break;
                case BdatFieldType.QuestFlagIra:
                    ApplyRef(BdatStringTools.GetQuestListIraTable(refId));
                    break;
                case BdatFieldType.Condition:
                    if (tables.Game == Game.XB2)
                    {
                        var conditionType = (ConditionType)int.Parse(item[field.RefField].ValueString);
                        ApplyRef(BdatStringTools.GetConditionTable(conditionType));
                    }
                    if (tables.Game == Game.XBX)
                    {
                        var conditionType = (ConditionTypeXbx)int.Parse(item[field.RefField].ValueString);
                        ApplyRef(BdatStringTools.GetConditionTableXbx(conditionType));
                    }

                    break;
                case BdatFieldType.Task when tables.Game == Game.XB2:
                    var taskType = (TaskType)int.Parse(item[field.RefField].ValueString);
                    ApplyRef(BdatStringTools.GetTaskTable(taskType));
                    break;
                case BdatFieldType.Task when tables.Game == Game.XB1 || tables.Game == Game.XB1DE:
                    var taskTypeXb1 = (TaskTypeXb1)int.Parse(item[field.RefField].ValueString);
                    int itemId = int.Parse(item[field.Field].ValueString);
                    ApplyRef(BdatStringTools.GetTaskTableXb1(taskTypeXb1, itemId));
                    break;
                case BdatFieldType.ShopTable:
                    var shopType = (ShopType)int.Parse(item[field.RefField].ValueString);
                    ApplyRef(BdatStringTools.GetShopTable(shopType));
                    break;
                case BdatFieldType.Character:
                    ApplyRef(BdatStringTools.GetCharacterTable(refId));
                    break;
                case BdatFieldType.Enhance:
                    if (tables.Game == Game.XB2) value.Display = BdatStringTools.GetEnhanceCaption(value);
                    if (tables.Game == Game.XBX) value.Display = BdatStringTools.GetEnhanceCaptionXbx(value);
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
                    string flagType = item[field.RefField].ValueString;
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
                case BdatFieldType.Place:
                    var placeCat = (PlaceCategory)int.Parse(item[field.RefField].ValueString);
                    string placeTable = GimmickData.GetPlaceTable(placeCat, refId);
                    if (placeTable != null) ApplyRef(placeTable);
                    break;
                case BdatFieldType.Enemy when tables.Game == Game.XB1DE:
                    ApplyRef(BdatStringTools.GetEnemyTableXb1(refId), member.Type != BdatMemberType.None);
                    break;
                case BdatFieldType.ArmorStyle when tables.Game == Game.XB1DE:
                {
                    int characterId = int.Parse(item[field.RefField].ValueString);
                    int equipItemId = int.Parse(item[field.Field].ValueString);

                    if (equipItemId != 0)
                    {
                        ApplyRef(BdatStringTools.GetArmorStyleTableXb1(characterId));
                    }
                    break;
                }
                case BdatFieldType.WeaponStyle when tables.Game == Game.XB1DE:
                {
                    int characterId = 0;
                    int equipItemId = int.Parse(item[field.Field].ValueString);

                    for (int i = 0; i <= 16; i++)
                    {
                        string fieldName = $"equip_pc{i}";
                        if (item.Values.TryGetValue(fieldName, out BdatStringValue equipPcValue))
                        {
                            if (equipPcValue.ValueString == "1")
                            {
                                characterId = i;
                                break;
                            }
                        }
                    }

                    if (equipItemId != 0 && characterId != 0)
                    {
                        ApplyRef(BdatStringTools.GetWeaponStyleTableXb1(characterId));
                    }
                    break;
                }
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

            void ApplyRef(string refTable, bool addReverseRef = true)
            {
                if (refTable == null || !tables.Tables.ContainsKey(refTable) || !tables[refTable].ContainsId(refId))
                {
                    value.Display = refId == 0 ? null : refId.ToString();
                    return;
                }

                BdatStringValue reft = tables[refTable][refId].Display;

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

                if (addReverseRef)
                {
                    tables[refTable][refId].ReferencedBy.Add(value.Parent);
                }
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

            BdatStringItem item = value.Parent;
            BdatFieldInfo field = value.Member.Metadata;
            BdatStringCollection tables = item.Table.Collection;

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

            List<BdatTag> tags = BdatStringTools.ParseTags(caption);

            foreach (BdatTag tag in tags.OrderByDescending(x => x.Start))
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

            foreach (BdatStringItem effect in effects.Items)
            {
                effect.AddMember("Caption", new BdatStringValue("0", effect, captionMember));
                effect["Caption"].Display = "";
            }

            foreach (BdatStringItem enhance in enhances.Items)
            {
                int captionId = int.Parse(enhance["Caption"].ValueString);
                if (captionId == 0) continue;

                BdatStringValue effect = effects[int.Parse(enhance["EnhanceEffect"].ValueString)]["Caption"];

                string caption = tables["btl_enhance_cap"][captionId]?["name"].ValueString;

                effect.Value = captionId.ToString();
                effect.Display = caption;
            }

            foreach (BdatStringItem enhance in enhances.Items)
            {
                int effectCaptionId = int.Parse(enhance["EnhanceEffect"].ValueString);
                int enhanceCaptionId = int.Parse(enhance["Caption"].ValueString);
                if (enhanceCaptionId != 0 || effectCaptionId == 0) continue;

                BdatStringValue effect = effects[effectCaptionId]["Caption"];
                enhance["Caption"].Value = effect.ValueString;
            }
        }
    }
}
