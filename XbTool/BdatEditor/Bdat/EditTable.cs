using System.Collections.Generic;
using XbTool.Bdat;

namespace BdatEditor.Bdat
{
    public class EditTable
    {
        public string Name { get; }
        public List<string> Columns { get; } = new List<string>();
        public List<object[]> Items { get;  } = new List<object[]>();

        public EditTable(BdatTable bdat)
        {
            Name = bdat.Name;
            foreach (var member in bdat.Members)
            {
                Columns.Add(member.Name);
            }

            for (int i = bdat.BaseId; i < bdat.BaseId + bdat.ItemCount; i++)
            {
                var item = new object[Columns.Count];
                for (int c = 0; c < Columns.Count; c++)
                {
                    item[c] = bdat.ReadValue(i, Columns[c]);
                }

                Items.Add(item);
            }
        }
    }
}
