using System;
using XbTool.Bdat;
using XbTool.BdatString;

namespace XbTool.Serialization
{
    public static class DeserializeStrings
    {
        public static BdatStringCollection DeserializeTables(BdatTables tables)
        {
            var collection = new BdatStringCollection { Bdats = tables };

            foreach (BdatTable table in tables.Tables)
            {
                var items = new BdatStringItem[table.ItemCount];

                var stringTable = new BdatStringTable
                {
                    Collection = collection,
                    Name = table.Name,
                    BaseId = table.BaseId,
                    Members = table.Members,
                    Items = items,
                    Filename = table.Filename
                };

                if (tables.DisplayFields.TryGetValue(table.Name, out string displayMember))
                {
                    stringTable.DisplayMember = displayMember;
                }

                for (int i = 0; i < table.ItemCount; i++)
                {
                    BdatStringItem item = ReadItem(table, i);
                    item.Table = stringTable;
                    item.Id = table.BaseId + i;

                    if (displayMember != null)
                    {
                        item.Display = item[displayMember];
                    }

                    items[i] = item;
                }

                collection.Add(stringTable);
            }

            return collection;
        }

        private static BdatStringItem ReadItem(BdatTable table, int itemIndex)
        {
            int itemOffset = table.ItemTableOffset + itemIndex * table.ItemSize;

            var item = new BdatStringItem();

            foreach (var member in table.Members)
            {
                switch (member.Type)
                {
                    case BdatMemberType.Scalar:
                        string v = ReadValue(table.Data, itemOffset + member.MemberPos, member.ValType);
                        item.AddMember(member.Name, new BdatStringValue(v, item, member));
                        break;
                    case BdatMemberType.Array:
                        var a = ReadArray(table.Data, itemOffset + member.MemberPos, member);
                        item.AddMember(member.Name, new BdatStringValue(a, item, member));
                        break;
                    case BdatMemberType.Flag:
                        var flagsMember = table.Members[member.FlagVarIndex];
                        var f = ReadFlag(table.Data, itemOffset, member, flagsMember);
                        item.AddMember(member.Name, new BdatStringValue(f, item, member));
                        break;
                }
            }

            return item;
        }

        private static string ReadValue(DataBuffer table, int valueOffset, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.UInt8:
                    return table[valueOffset].ToString();
                case BdatValueType.UInt16:
                    return table.ReadUInt16(valueOffset).ToString();
                case BdatValueType.UInt32:
                    return table.ReadUInt32(valueOffset).ToString();
                case BdatValueType.Int8:
                    return ((sbyte)table[valueOffset]).ToString();
                case BdatValueType.Int16:
                    return table.ReadInt16(valueOffset).ToString();
                case BdatValueType.Int32:
                    return table.ReadInt32(valueOffset).ToString();
                case BdatValueType.String:
                    return table.ReadUTF8Z(table.ReadInt32(valueOffset));
                case BdatValueType.FP32:
                    if (table.Game == Game.XBX)
                    {
                        uint value = table.ReadUInt32(valueOffset);
                        return ((float)(value * (1 / 4096.0))).ToString("R");
                    }
                    return table.ReadSingle(valueOffset).ToString("R");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string[] ReadArray(DataBuffer table, int arrayOffset, BdatMember member)
        {
            var values = new string[member.ArrayCount];
            int typeSize = GetTypeSize(member.ValType);

            for (int i = 0, offset = arrayOffset; i < member.ArrayCount; i++, offset += typeSize)
            {
                values[i] = ReadValue(table, offset, member.ValType);
            }

            return values;
        }

        private static string ReadFlag(DataBuffer table, int itemOffset, BdatMember member, BdatMember flagsMember)
        {
            uint flags = uint.Parse(ReadValue(table, itemOffset + flagsMember.MemberPos, flagsMember.ValType));
            return ((flags & member.FlagMask) != 0).ToString();
        }

        private static int GetTypeSize(BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.UInt8:
                case BdatValueType.Int8:
                    return 1;
                case BdatValueType.UInt16:
                case BdatValueType.Int16:
                    return 2;
                case BdatValueType.UInt32:
                case BdatValueType.Int32:
                case BdatValueType.String:
                case BdatValueType.FP32:
                    return 4;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
