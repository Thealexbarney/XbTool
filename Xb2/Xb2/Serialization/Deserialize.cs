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

        public static BdatCollection ReadBdats(byte[][] files)
        {
            var tables = new BdatCollection();

            foreach (byte[] file in files)
            {
                ReadBdat(file, tables);
            }

            return tables;
        }

        private static void ReadBdat(byte[] file, BdatCollection tables)
        {
            if (file.Length <= 12) throw new InvalidDataException("File is too short");
            int fileLength = BitConverter.ToInt32(file, 4);
            if (file.Length != fileLength) throw new InvalidDataException("Incorrect file length field");

            BdatTools.DecryptBdat(file);

            int tableCount = BitConverter.ToInt32(file, 0);

            for (int i = 0; i < tableCount; i++)
            {
                int offset = BitConverter.ToInt32(file, 8 + 4 * i);
                ReadTable(file, offset, tables);
            }
        }

        private static void ReadTable(byte[] file, int offset, BdatCollection tables)
        {
            if (BitConverter.ToUInt32(file, offset) != 0x54414442) return;

            int namesOffset = BitConverter.ToUInt16(file, offset + 6);
            var tableName = Stuff.GetUTF8Z(file, offset + namesOffset);

            var itemType = TypeMap.GetTableType(tableName);
            var tableType = typeof(BdatTable<>).MakeGenericType(itemType);
            var table = (IBdatTable)Activator.CreateInstance(tableType);
            table.Name = tableName;
            table.BaseId = BitConverter.ToUInt16(file, offset + 18);
            table.Members = BdatTable.ReadTableMembers(file, offset);
            table.Items = ReadItems(file, offset, itemType);

            Fields[tableName].SetValue(tables, table);
        }

        private static Array ReadItems(byte[] file, int offset, Type itemType)
        {
            int itemSize = BitConverter.ToUInt16(file, offset + 8);
            int itemTableOffset = BitConverter.ToUInt16(file, offset + 14);
            int itemCount = BitConverter.ToUInt16(file, offset + 16);

            Array items = Array.CreateInstance(itemType, itemCount);
            var func = TypeMap.GetTableReadFunction(itemType);

            for (int i = 0; i < itemCount; i++)
            {
                int itemOffset = offset + itemTableOffset + i * itemSize;
                object item = func(file, itemOffset, offset);
                items.SetValue(item, i);
            }

            return items;
        }
    }
}
