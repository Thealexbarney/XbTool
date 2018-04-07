using System;
using Xb2.Bdat;
using Xb2.BdatString;

namespace Xb2.Serialization
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

                for (int i = 0; i < table.ItemCount; i++)
                {
                    BdatStringItem item = ReadItem(table, i);
                    item.Table = stringTable;
                    item.Id = table.BaseId + i;

                    if (tables.DisplayFields.TryGetValue(table.Name, out var fieldName))
                    {
                        item.Display = item[fieldName];
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
                        string v = ReadValue(table.Table, itemOffset + member.MemberPos, member.ValType);
                        item.AddMember(member.Name, new BdatStringValue(v, item, member));
                        break;
                    case BdatMemberType.Array:
                        var a = ReadArray(table.Table, itemOffset + member.MemberPos, member);
                        item.AddMember(member.Name, new BdatStringValue(a, item, member));
                        break;
                    case BdatMemberType.Flag:
                        var flagsMember = table.Members[member.FlagVarIndex];
                        var f = ReadFlag(table.Table, itemOffset, member, flagsMember);
                        item.AddMember(member.Name, new BdatStringValue(f, item, member));
                        break;
                }
            }

            return item;
        }

        private static string ReadValue(byte[] file, int valueOffset, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.UInt8:
                    return file[valueOffset].ToString();
                case BdatValueType.UInt16:
                    return BitConverter.ToUInt16(file, valueOffset).ToString();
                case BdatValueType.UInt32:
                    return BitConverter.ToUInt32(file, valueOffset).ToString();
                case BdatValueType.Int8:
                    return ((sbyte)file[valueOffset]).ToString();
                case BdatValueType.Int16:
                    return BitConverter.ToInt16(file, valueOffset).ToString();
                case BdatValueType.Int32:
                    return BitConverter.ToInt32(file, valueOffset).ToString();
                case BdatValueType.String:
                    return Stuff.GetUTF8Z(file, BitConverter.ToInt32(file, valueOffset));
                case BdatValueType.FP32:
                    return BitConverter.ToSingle(file, valueOffset).ToString("R");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string[] ReadArray(byte[] file, int arrayOffset, BdatMember member)
        {
            var values = new string[member.ArrayCount];
            int typeSize = GetTypeSize(member.ValType);

            for (int i = 0, offset = arrayOffset; i < member.ArrayCount; i++, offset += typeSize)
            {
                values[i] = ReadValue(file, offset, member.ValType);
            }

            return values;
        }

        private static string ReadFlag(byte[] file, int itemOffset, BdatMember member, BdatMember flagsMember)
        {
            uint flags = uint.Parse(ReadValue(file, itemOffset + flagsMember.MemberPos, flagsMember.ValType));
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
