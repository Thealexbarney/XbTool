using System.Collections.Generic;
using XbTool.Bdat;

namespace BdatEditor.Bdat
{
    public class EditTable
    {
        public string Name { get; }
        public List<BdatMember> Columns { get; } = new List<BdatMember>();
        public List<object[]> Items { get; } = new List<object[]>();

        public EditTable(BdatTable bdat)
        {
            Name = bdat.Name;
            foreach (BdatMember member in bdat.Members)
            {
                Columns.Add(member);
            }

            for (int i = bdat.BaseId; i < bdat.BaseId + bdat.ItemCount; i++)
            {
                var item = new object[Columns.Count + 1];
                item[0] = i;
                for (int c = 0; c < Columns.Count; c++)
                {
                    item[c + 1] = bdat.ReadValue(i, Columns[c].Name);
                }

                Items.Add(item);
            }
        }
    }
}
