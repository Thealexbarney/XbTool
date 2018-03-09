using System;
using System.IO;
using Xb2.Bdat;
using Xb2.BdatString;

namespace Xb2.Serialization
{
    public static class DeserializeStrings
    {
        public static BdatStringCollection ReadBdats(byte[][] files, string[] filenames)
        {
            var tables = new BdatStringCollection();

            for (int i = 0; i < files.Length; i++)
            {
                ReadBdat(files[i], tables, filenames[i]);
            }

            return tables;
        }

        private static void ReadBdat(byte[] file, BdatStringCollection tables, string filename)
        {
            if (file.Length <= 12) throw new InvalidDataException("File is too short");
            int fileLength = BitConverter.ToInt32(file, 4);
            if (file.Length != fileLength) throw new InvalidDataException("Incorrect file length field");

            BdatTools.DecryptBdat(file);

            int tableCount = BitConverter.ToInt32(file, 0);

            for (int i = 0; i < tableCount; i++)
            {
                int offset = BitConverter.ToInt32(file, 8 + 4 * i);
                var table = ReadTable(file, offset);
                if (table == null) continue;
                if (tableCount > 1) table.Filename = filename;
                tables.Add(table);
            }
        }

        private static BdatStringTable ReadTable(byte[] file, int offset)
        {
            if (BitConverter.ToUInt32(file, offset) != 0x54414442) return null;

            int namesOffset = BitConverter.ToUInt16(file, offset + 6);
            var tableName = Stuff.GetUTF8Z(file, offset + namesOffset);
            var members = BdatTable.ReadTableMembers(file, offset);

            var table = new BdatStringTable
            {
                Name = tableName,
                BaseId = BitConverter.ToUInt16(file, offset + 18),
                Members = members,
                Items = ReadItems(file, offset, members)
            };

            return table;
        }

        private static BdatStringItem[] ReadItems(byte[] file, int offset, BdatMember[] members)
        {
            int itemSize = BitConverter.ToUInt16(file, offset + 8);
            int itemTableOffset = BitConverter.ToUInt16(file, offset + 14);
            int itemCount = BitConverter.ToUInt16(file, offset + 16);

            var items = new BdatStringItem[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                int itemOffset = offset + itemTableOffset + i * itemSize;
                BdatStringItem item = ReadItem(file, offset, itemOffset, members);
                items[i] = item;
            }

            return items;
        }

        private static BdatStringItem ReadItem(byte[] file, int tableOffset, int itemOffset, BdatMember[] members)
        {
            var item = new BdatStringItem();

            foreach (var member in members)
            {
                switch (member.Type)
                {
                    case BdatMemberType.Scalar:
                        string v = ReadValue(file, tableOffset, itemOffset + member.MemberPos, member.ValType);
                        item.Add(member.Name, v);
                        break;
                    case BdatMemberType.Array:
                        var a = ReadArray(file, tableOffset, itemOffset + member.MemberPos, member);
                        item.Add(member.Name, a);
                        break;
                    case BdatMemberType.Flag:
                        var flagsMember = members[member.FlagVarIndex];
                        var f = ReadFlag(file, tableOffset, itemOffset, member, flagsMember);
                        item.Add(member.Name, f);
                        break;
                }
            }

            return item;
        }

        private static string ReadValue(byte[] file, int tableOffset, int valueOffset, BdatValueType type)
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
                    return Stuff.GetUTF8Z(file, tableOffset + BitConverter.ToInt32(file, valueOffset));
                case BdatValueType.FP32:
                    return BitConverter.ToSingle(file, valueOffset).ToString("R");
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static string[] ReadArray(byte[] file, int tableOffset, int arrayOffset, BdatMember member)
        {
            var values = new string[member.ArrayCount];
            int typeSize = GetTypeSize(member.ValType);

            for (int i = 0, offset = arrayOffset; i < member.ArrayCount; i++, offset += typeSize)
            {
                values[i] = ReadValue(file, tableOffset, offset, member.ValType);
            }

            return values;
        }

        private static string ReadFlag(byte[] file, int tableOffset, int itemOffset, BdatMember member, BdatMember flagsMember)
        {
            uint flags = uint.Parse(ReadValue(file, tableOffset, itemOffset + flagsMember.MemberPos, flagsMember.ValType));
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
