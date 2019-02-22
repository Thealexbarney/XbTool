using System;
using XbTool.Types;

namespace XbTool.Xb2.GameData
{
    public static class ItemData
    {
        public static ItemTypeXb2 GetItemCategory(int id)
        {
            if (id > 61000) return ItemTypeXb2.Crystal;
            if (id > 60000) return ItemTypeXb2.HanaAssist;
            if (id > 59000) return ItemTypeXb2.HanaNArtsSet;
            if (id > 58000) return ItemTypeXb2.HanaArtsEnh;
            if (id > 57000) return ItemTypeXb2.HanaAtr;
            if (id > 56000) return ItemTypeXb2.HanaRole;
            if (id > 50000) return ItemTypeXb2.Booster;
            if (id > 45000) return ItemTypeXb2.Crystal;
            if (id > 40000) return ItemTypeXb2.Favorite;
            if (id > 35000) return ItemTypeXb2.Tresure;
            if (id > 30000) return ItemTypeXb2.Collection;
            if (id > 27000) return ItemTypeXb2.Event;
            if (id > 26000) return ItemTypeXb2.Info;
            if (id > 25000) return ItemTypeXb2.Precious;
            if (id > 20000) return ItemTypeXb2.Salvage;
            if (id > 17000) return ItemTypeXb2.EquipOrb;
            if (id > 14000) return ItemTypeXb2.EmptyOrb;
            if (id > 10000) return ItemTypeXb2.PcWpnChip;
            if (id > 5000) return ItemTypeXb2.PcWpn;
            return ItemTypeXb2.PcEquip;
        }

        public static string GetCategoryTable(ItemTypeXb2 category)
        {
            switch (category)
            {
                case ItemTypeXb2.PcWpnChip: return "ITM_PcWpnChip";
                case ItemTypeXb2.PcEquip: return "ITM_PcEquip";
                case ItemTypeXb2.EquipOrb: return "ITM_OrbEquip";
                case ItemTypeXb2.PcWpn: return "ITM_PcWpn";
                case ItemTypeXb2.Salvage: return "ITM_SalvageList";
                case ItemTypeXb2.Precious: return "ITM_PreciousList";
                case ItemTypeXb2.Collection: return "ITM_CollectionList";
                case ItemTypeXb2.Tresure: return "ITM_TresureList";
                case ItemTypeXb2.EmptyOrb: return "ITM_Orb";
                case ItemTypeXb2.Favorite: return "ITM_FavoriteList";
                case ItemTypeXb2.Crystal: return "ITM_CrystalList";
                case ItemTypeXb2.Booster: return "ITM_BoosterList";
                case ItemTypeXb2.Info: return "ITM_InfoList";
                case ItemTypeXb2.Event: return "ITM_EventList";
                case ItemTypeXb2.HanaRole: return "ITM_HanaRole";
                case ItemTypeXb2.HanaAtr: return "ITM_HanaAtr";
                case ItemTypeXb2.HanaArtsEnh: return "ITM_HanaArtsEnh";
                case ItemTypeXb2.HanaNArtsSet: return "ITM_HanaNArtsSet";
                case ItemTypeXb2.HanaAssist: return "ITM_HanaAssist";
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        public static string GetName(int id, BdatCollection tables)
        {
            ItemTypeXb2 category = GetItemCategory(id);
            string tableName = GetCategoryTable(category);
            string name = tables[tableName].GetBdatItem(id).Read<Message>("_Name").name;

            if (category == ItemTypeXb2.PcEquip)
            {
                name += $" ({tables.ITM_PcEquip[id]._Rarity.name})";
            }

            return name;
        }
    }
}
