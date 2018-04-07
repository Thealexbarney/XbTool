using System.Collections.Generic;
using System.Diagnostics;
using Xb2.Bdat;

namespace Xb2.BdatString
{
    public class BdatStringCollection
    {
        public Dictionary<string, BdatStringTable> Tables { get; } = new Dictionary<string, BdatStringTable>();
        public BdatTables Bdats { get; set; }

        public BdatStringTable this[string tableName] => Tables[tableName];

        public void Add(BdatStringTable table)
        {
            Tables.Add(table.Name, table);
        }
    }

    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class BdatStringTable
    {
        public BdatStringCollection Collection { get; set; }
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

        private string DebugString => Name;
    }

    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class BdatStringItem
    {
        public int Id { get; set; }
        public BdatStringTable Table { get; set; }
        public Dictionary<string, BdatStringValue> Values { get; } = new Dictionary<string, BdatStringValue>();
        public BdatStringValue Display { get; set; }

        public HashSet<BdatStringItem> ReferencedBy { get; } = new HashSet<BdatStringItem>();

        public BdatStringValue this[string memberName] => Values[memberName];

        public void AddMember(string memberName, BdatStringValue value)
        {
            Values[memberName] = value;
        }

        private string DebugString => $"Item: {Table.Name}[{Id}] Display: {Display?.Display ?? Id}";
    }

    [DebuggerDisplay("{" + nameof(DebugString) + ", nq}")]
    public class BdatStringValue
    {
        public BdatStringValue(object value, BdatStringItem parent, BdatMember member)
        {
            Parent = parent;
            Value = value;
            Display = value;
            Member = member;
        }

        public bool Resolved { get; set; }
        public object Value { get; }
        public object Display { get; set; }
        public BdatStringItem Parent { get; }
        public BdatMember Member { get; }
        public BdatStringItem Reference { get; set; }

        public string ValueString => (string)Value;
        public string DisplayString => (string)Display;

        private string DebugString => $"Item: {Parent.Table.Name}[{Parent.Id}] Value: {Value} Display: {Display}";
    }
}
