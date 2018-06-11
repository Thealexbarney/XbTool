using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using XbTool.Bdat;
using XbTool.Types;

namespace XbTool.Serialization
{
    public static class Deserialize
    {
        public static readonly Dictionary<string, FieldInfo> Fields = typeof(BdatCollection).GetFields().ToDictionary(x => x.Name, x => x);

        public static BdatCollection DeserializeTables(BdatTables files)
        {
            var tables = new BdatCollection();

            foreach (BdatTable table in files.Tables)
            {
                ReadTable(table, tables);
            }

            ReadFunctions.SetReferences(tables);

            return tables;
        }

        private static void ReadTable(BdatTable file, BdatCollection tables)
        {
            Type itemType = TypeMap.GetTableType(file.Name);
            Type tableType = typeof(BdatTable<>).MakeGenericType(itemType);
            var table = (IBdatTable)Activator.CreateInstance(tableType);
            table.Name = file.Name;
            table.BaseId = file.BaseId;
            table.Members = file.Members;
            table.Items = ReadItems(file, itemType);

            Fields[file.Name].SetValue(tables, table);
        }

        private static Array ReadItems(BdatTable table, Type itemType)
        {
            Array items = Array.CreateInstance(itemType, table.ItemCount);
            var func = TypeMap.GetTableReadFunction(itemType);

            for (int i = 0; i < table.ItemCount; i++)
            {
                int itemOffset = table.Data.Start + table.ItemTableOffset + i * table.ItemSize;
                object item = func(table.Data.File, table.BaseId + i, itemOffset, table.Data.Start);
                items.SetValue(item, i);
            }

            return items;
        }
    }
}
