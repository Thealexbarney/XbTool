using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xb2.Bdat;
using Xb2.Types;

namespace Xb2.Serialization
{
    public static class Deserialize
    {
        public static readonly Dictionary<string, FieldInfo> Fields = typeof(BdatCollection).GetFields().ToDictionary(x => x.Name, x => x);

        public static BdatCollection ReadBdats(DataBuffer[] files)
        {
            var tables = new BdatCollection();

            foreach (DataBuffer file in files)
            {
                ReadBdat(file, tables);
            }

            ReadFunctions.SetReferences(tables);

            return tables;
        }

        private static void ReadBdat(DataBuffer file, BdatCollection tables)
        {
            if (file.Length <= 12) throw new InvalidDataException("File is too short");
            int fileLength = file.ReadInt32(4);
            if (file.Length != fileLength) throw new InvalidDataException("Incorrect file length field");

            BdatTools.DecryptBdat(file);

            int tableCount = file.ReadInt32(0);

            for (int i = 0; i < tableCount; i++)
            {
                int offset = file.ReadInt32(8 + 4 * i);
                DataBuffer tableBuffer = file.Slice(offset, file.Length - offset);
                ReadTable(tableBuffer, tables);
            }
        }

        private static void ReadTable(DataBuffer file, BdatCollection tables)
        {
            if (file.ReadUTF8(0, 4) != "BDAT") return;

            int namesOffset = file.ReadUInt16(6);
            var tableName = file.ReadUTF8Z(namesOffset);

            var itemType = TypeMap.GetTableType(tableName);
            var tableType = typeof(BdatTable<>).MakeGenericType(itemType);
            var table = (IBdatTable)Activator.CreateInstance(tableType);
            table.Name = tableName;
            table.BaseId = file.ReadUInt16(18);
            table.Members = BdatTable.ReadTableMembers(file);
            table.Items = ReadItems(file, itemType);

            Fields[tableName].SetValue(tables, table);
        }

        private static Array ReadItems(DataBuffer table, Type itemType)
        {
            int itemSize = table.ReadUInt16(8);
            int itemTableOffset = table.ReadUInt16(14);
            int itemCount = table.ReadUInt16(16);
            int baseId = table.ReadUInt16(18);

            Array items = Array.CreateInstance(itemType, itemCount);
            var func = TypeMap.GetTableReadFunction(itemType);

            for (int i = 0; i < itemCount; i++)
            {
                int itemOffset = table.Start + itemTableOffset + i * itemSize;
                object item = func(table.File, baseId + i, itemOffset, table.Start);
                items.SetValue(item, i);
            }

            return items;
        }
    }
}
