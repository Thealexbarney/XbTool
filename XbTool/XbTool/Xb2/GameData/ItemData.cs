using System;
using XbTool.Types;

namespace XbTool.Xb2.GameData
{
    public static class ItemData
    {
        public static ItemType GetItemCategory(int id)
        {
            if (id > 61000) return ItemType.Crystal;
            if (id > 60000) return ItemType.HanaAssist;
            if (id > 59000) return ItemType.HanaNArtsSet;
            if (id > 58000) return ItemType.HanaArtsEnh;
            if (id > 57000) return ItemType.HanaAtr;
            if (id > 56000) return ItemType.HanaRole;
            if (id > 50000) return ItemType.Booster;
            if (id > 45000) return ItemType.Crystal;
            if (id > 40000) return ItemType.Favorite;
            if (id > 35000) return ItemType.Tresure;
            if (id > 30000) return ItemType.Collection;
            if (id > 27000) return ItemType.Event;
            if (id > 26000) return ItemType.Info;
            if (id > 25000) return ItemType.Precious;
            if (id > 20000) return ItemType.Salvage;
            if (id > 17000) return ItemType.EquipOrb;
            if (id > 14000) return ItemType.EmptyOrb;
            if (id > 10000) return ItemType.PcWpnChip;
            if (id > 5000) return ItemType.PcWpn;
            return ItemType.PcEquip;
        }

        public static string GetCategoryTable(ItemType category)
        {
            switch (category)
            {
                case ItemType.PcWpnChip: return "ITM_PcWpnChip";
                case ItemType.PcEquip: return "ITM_PcEquip";
                case ItemType.EquipOrb: return "ITM_OrbEquip";
                case ItemType.PcWpn: return "ITM_PcWpn";
                case ItemType.Salvage: return "ITM_SalvageList";
                case ItemType.Precious: return "ITM_PreciousList";
                case ItemType.Collection: return "ITM_CollectionList";
                case ItemType.Tresure: return "ITM_TresureList";
                case ItemType.EmptyOrb: return "ITM_Orb";
                case ItemType.Favorite: return "ITM_FavoriteList";
                case ItemType.Crystal: return "ITM_CrystalList";
                case ItemType.Booster: return "ITM_BoosterList";
                case ItemType.Info: return "ITM_InfoList";
                case ItemType.Event: return "ITM_EventList";
                case ItemType.HanaRole: return "ITM_HanaRole";
                case ItemType.HanaAtr: return "ITM_HanaAtr";
                case ItemType.HanaArtsEnh: return "ITM_HanaArtsEnh";
                case ItemType.HanaNArtsSet: return "ITM_HanaNArtsSet";
                case ItemType.HanaAssist: return "ITM_HanaAssist";
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        public static string GetName(int id, BdatCollection tables)
        {
            var category = GetItemCategory(id);
            var tableName = GetCategoryTable(category);
            var name = tables[tableName].GetBdatItem(id).Read<Message>("_Name").name;

            if (category == ItemType.PcEquip)
            {
                name += $" ({tables.ITM_PcEquip[id]._Rarity.name})";
            }

            return name;
        }
    }
}
