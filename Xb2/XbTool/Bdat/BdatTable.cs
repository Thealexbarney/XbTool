using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace XbTool.Bdat
{
    [DebuggerDisplay("{" + nameof(Name) + ", nq}")]
    public class BdatTable
    {
        public string Name { get; }
        public string Filename { get; set; }

        public int EncryptionFlag { get; } // Maybe other flags too?
        public int NamesOffset { get; }
        public int ItemSize { get; }
        public int HashTableOffset { get; }
        public int HashTableLength { get; }
        public int ItemTableOffset { get; }
        public int ItemCount { get; }
        public int BaseId { get; }
        public int Field14 { get; }
        public ushort Checksum { get; }
        public uint StringsOffset { get; }
        public uint StringsLength { get; }
        public int MemberTableOffset { get; }
        public int MemberCount { get; }

        public BdatMember[] Members { get; }
        private Dictionary<string, BdatMember> MembersDict { get; }
        public DataBuffer Data { get; }

        public BdatTable(DataBuffer table)
        {
            Data = table;
            if (table.ReadUTF8(0, 4) != "BDAT") return;

            EncryptionFlag = table.ReadUInt16(4);
            NamesOffset = table.ReadUInt16(6);
            ItemSize = table.ReadUInt16(8);
            HashTableOffset = table.ReadUInt16(10);
            HashTableLength = table.ReadUInt16(12);
            ItemTableOffset = table.ReadUInt16(14);
            ItemCount = table.ReadUInt16(16);
            BaseId = table.ReadUInt16(18);
            Field14 = table.ReadUInt16(20);
            Checksum = table.ReadUInt16(22);
            StringsOffset = table.ReadUInt32(24);
            StringsLength = table.ReadUInt32(28);
            MemberTableOffset = table.ReadUInt16(32);
            MemberCount = table.ReadUInt16(34);

            Name = table.ReadUTF8Z(NamesOffset);
            switch (table.Game)
            {
                case Game.XB1:
                    Members = ReadTableMembersFromHash(table);

                    // Fix incorrectly named table in Xenoblade 1
                    if (Name == "FLD_GimCamList1202" && ItemCount == 1)
                        Name = "FLD_GimCamList1201";

                    break;
                case Game.XBX:
                case Game.XB2:
                    Members = ReadTableMembers(table);
                    break;
            }

            MembersDict = Members.ToDictionary(x => x.Name, x => x);
        }

        public long ReadInt(int itemId, string memberName)
        {
            var member = MembersDict[memberName];
            var itemIndex = itemId - BaseId;
            var itemOffset = ItemTableOffset + itemIndex * ItemSize;
            var valueOffset = itemOffset + member.MemberPos;

            if(member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
            return ReadIntValue(valueOffset, member.ValType);
        }

        public float ReadFloat(int itemId, string memberName)
        {
            var member = MembersDict[memberName];
            var itemIndex = itemId - BaseId;
            var itemOffset = ItemTableOffset + itemIndex * ItemSize;
            var valueOffset = itemOffset + member.MemberPos;

            if(member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
            return ReadFloatValue(valueOffset, member.ValType);
        }

        public string ReadString(int itemId, string memberName)
        {
            var member = MembersDict[memberName];
            var itemIndex = itemId - BaseId;
            var itemOffset = ItemTableOffset + itemIndex * ItemSize;
            var valueOffset = itemOffset + member.MemberPos;

            if(member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
            return ReadStringValue(valueOffset, member.ValType);
        }

        public static BdatMember[] ReadTableMembers(DataBuffer file)
        {
            int memberTableOffset = file.ReadUInt16(32);
            int memberCount = file.ReadUInt16(34);
            var members = new BdatMember[memberCount];
            var usedNames = new HashSet<string>();

            for (int i = 0; i < memberCount; i++)
            {
                int memberOffset = memberTableOffset + i * 6;
                var member = new BdatMember(file, memberOffset, usedNames);
                members[i] = member;
            }

            return members;
        }

        public static BdatMember[] ReadTableMembersFromHash(DataBuffer file)
        {
            int hashTableOffset = file.ReadUInt16(10);
            int hashTableLength = file.ReadUInt16(12);

            var members = new List<BdatMember>();
            var usedNames = new HashSet<string>();

            for (int i = 0; i < hashTableLength; i++)
            {
                int nextChain = file.ReadUInt16(hashTableOffset + i * 2);
                while (nextChain != 0)
                {
                    var member = new BdatMember(file, nextChain, usedNames);
                    members.Add(member);
                    nextChain = file.ReadUInt16(nextChain + 2);
                }
            }

            return members.OrderBy(x => x.MemberPos).ToArray();
        }

        private long ReadIntValue(int valueOffset, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.UInt8:
                    return Data[valueOffset];
                case BdatValueType.UInt16:
                    return Data.ReadUInt16(valueOffset);
                case BdatValueType.UInt32:
                    return Data.ReadUInt32(valueOffset);
                case BdatValueType.Int8:
                    return ((sbyte)Data[valueOffset]);
                case BdatValueType.Int16:
                    return Data.ReadInt16(valueOffset);
                case BdatValueType.Int32:
                    return Data.ReadInt32(valueOffset);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private float ReadFloatValue(int valueOffset, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.FP32:
                    if (Data.Game == Game.XBX)
                    {
                        uint value = Data.ReadUInt32(valueOffset);
                        return (float)(value * (1 / 4096.0));
                    }
                    return Data.ReadSingle(valueOffset);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private string ReadStringValue(int valueOffset, BdatValueType type)
        {
            switch (type)
            {
                case BdatValueType.String:
                    return Data.ReadUTF8Z(Data.ReadInt32(valueOffset));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public class BdatTable<T> : IBdatTable, IReadOnlyList<T> where T : class
    {
        public string Name { get; set; }
        public int BaseId { get; set; }
        public BdatMember[] Members { get; set; }
        public T[] Items { get; set; }
        public T this[int itemId] => Items[itemId - BaseId];
        public T GetItemOrNull(int itemId) => ContainsId(itemId) ? this[itemId] : null;
        public T GetItemOrNull(uint itemId) => GetItemOrNull((int)itemId);
        public Type ItemType { get; } = typeof(T);
        Array IBdatTable.Items { get => Items; set => Items = (T[])value; }

        public bool ContainsId(int itemId)
        {
            int id = itemId - BaseId;
            return id >= 0 && id < Items.Length;
        }

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int Count => Items.Length;
    }

    public interface IBdatTable
    {
        string Name { get; set; }
        int BaseId { get; set; }
        BdatMember[] Members { get; set; }
        Type ItemType { get; }
        Array Items { get; set; }
    }
}
