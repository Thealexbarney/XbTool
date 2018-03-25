using System;
using System.Collections.Generic;
using Xb2.Bdat;

namespace Xb2.BdatString
{
    public class BdatStringCollection
    {
        public Dictionary<string, BdatStringTable> Tables { get; } = new Dictionary<string, BdatStringTable>();

        public BdatStringTable this[string tableName] => Tables[tableName];

        public void Add(BdatStringTable table)
        {
            Tables.Add(table.Name, table);
        }
    }

    public class BdatStringTable
    {
        public string Name { get; set; }
        public string Filename { get; set; }
        public int BaseId { get; set; }
        public BdatMember[] Members { get; set; }
        public BdatStringItem[] Items { get; set; }
        public BdatStringItem this[int itemId] => ContainsId(itemId) ? Items[itemId - BaseId] : null;

        public bool ContainsId(int itemId)
        {
            int id = itemId - BaseId;
            return id >= 0 && id < Items.Length;
        }
    }

    public class BdatStringItem
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public Dictionary<string, object> Values { get; } = new Dictionary<string, object>();

        public HashSet<BdatStringItem> ReferencedBy { get; } = new HashSet<BdatStringItem>();

        public object this[string memberName] => Values[memberName];

        public void Add(string member, object value)
        {
            Values[member] = value;
        }
    }

    public enum ItemType
    {
        PcWpnChip = 1,
        PcEquip = 2,
        EquipOrb = 3,
        PcWpn = 4,
        Salvage = 5,
        Precious = 6,
        CollectionList = 7,
        Tresure = 8,
        EmptyOrb = 9,
        Favorite = 10,
        CrystalList = 11,
        Booster = 12,
        HealPot = 13,
        Info = 14,
        Event = 15,
        HanaRole = 16,
        HanaAtr = 17,
        HanaArtsEnh = 18,
        HanaNArtsSet = 19,
        HanaAssist = 20
    }

    public enum Weather
    {
        Overcast = 1,
        Lightning,
        Rain,
        Thunderstorm,
        Storm,
        Fog,
        Snow,
        Sandstorm,
        CrystalSquall,
        SurfaceHeat,
        NightIncense,
        Overcast2,
        Aurora,
        CloudSeaMist
    }

    [Flags]
    public enum WeatherBits
    {
        Overcast = 1 << 0,
        Lightning = 1 << 1,
        Rain = 1 << 2,
        Thunderstorm = 1 << 3,
        Storm = 1 << 4,
        Fog = 1 << 5,
        Snow = 1 << 6,
        Sandstorm = 1 << 7,
        CrystalSquall = 1 << 8,
        SurfaceHeat = 1 << 9,
        NightIncense = 1 << 10,
        Overcast2 = 1 << 11,
        Aurora = 1 << 12,
        CloudSeaMist = 1 << 13
    }
}
