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
}
