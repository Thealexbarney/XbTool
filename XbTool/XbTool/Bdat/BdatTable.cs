using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XbTool.Bdat;
using XbTool.BdatString;
using XbTool.CodeGen;
using XbTool.Common;

namespace XbTool.Bdat
{
    [DebuggerDisplay("{" + nameof(Name) + ", nq}")]
    public class BdatTable
    {
        public string Name { get; set; }
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

        public BdatMember[] Members { get; private set; }
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
                case Game.XB1DE:
                    Members = ReadTableMembers(table);
                    break;
            }

            MembersDict = Members.ToDictionary(x => x.Name, x => x);
        }

        public string ReadValue(int itemId, string memberName)
        {
            BdatMember member = MembersDict[memberName];
            int itemIndex = itemId - BaseId;
            int itemOffset = ItemTableOffset + itemIndex * ItemSize;
            int valueOffset = itemOffset + member.MemberPos;

            if (member.Type == BdatMemberType.Array) //return "Array";
            {
                String outString = "";
                //Set data length by type
                int bytes = GetTypeBytes(member.ValType);
                //Add each item
                for (int i = 0; i < member.ArrayCount; i++)
                {
                    outString = string.Concat(outString, ReadIndividualValue(member, valueOffset + i * bytes).ToString());
                    if (i < member.ArrayCount - 1)
                        outString = string.Concat(outString, ":");
                }
                return outString;
            }
            if (member.Type == BdatMemberType.Flag) return ((sbyte)Data[valueOffset]).ToString();
            return ReadIndividualValue(member, valueOffset);
        }
        private int GetTypeBytes (BdatValueType type)
        {
            //also for arrays
            switch (type)
            {
                case BdatValueType.Int8:
                case BdatValueType.UInt8:
                    return 1;
                case BdatValueType.UInt16:
                case BdatValueType.Int16:
                    return 2;
                    break;
                case BdatValueType.Int32:
                case BdatValueType.UInt32:
                case BdatValueType.String:
                case BdatValueType.FP32:
                    return 4;
                default:
                    return 1;
            }
        }

        private string ReadIndividualValue(BdatMember member, int valueOffset)
        //Custom, only used for arrays.
        {
            switch (member.ValType)
            {
                case BdatValueType.UInt8:
                    return Data[valueOffset].ToString();
                case BdatValueType.UInt16:
                    return Data.ReadUInt16(valueOffset).ToString();
                case BdatValueType.UInt32:
                    return Data.ReadUInt32(valueOffset).ToString();
                case BdatValueType.Int8:
                    return ((sbyte)Data[valueOffset]).ToString();
                case BdatValueType.Int16:
                    return Data.ReadInt16(valueOffset).ToString();
                case BdatValueType.Int32:
                    return Data.ReadInt32(valueOffset).ToString();
                case BdatValueType.String:
                    return Data.ReadUTF8Z(Data.ReadInt32(valueOffset));
                case BdatValueType.FP32:
                    if (Data.Game == Game.XBX)
                    {
                        uint value = Data.ReadUInt32(valueOffset);
                        return ((float)(value * (1 / 4096.0))).ToString("R");
                    }
                    return Data.ReadSingle(valueOffset).ToString("R");
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public void WriteValue(int itemId, string memberName, string value)
        {

            BdatMember member = MembersDict[memberName];
            int itemIndex = itemId - BaseId;
            int itemOffset = ItemTableOffset + itemIndex * ItemSize;
            int valueOffset = itemOffset + member.MemberPos;

            if (member.Type == BdatMemberType.Array)
            {
                int i = 0;
                int bytes = GetTypeBytes(member.ValType);
                string[] array_items = value.Split(':');
                foreach (String array_item in array_items)
                {
                    WriteIndividualValue(member, valueOffset + i*bytes, array_item);
                    i++;
                }
            }

            if (member.Type == BdatMemberType.Flag)
            {
                if (value == "0" || value == "1")
                {
                    Data.WriteUInt8(byte.Parse(value), valueOffset);
                    return;
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(value), "Flags must be 1 or 0!");
            }

            WriteIndividualValue(member, valueOffset, value);
        }
        private void WriteIndividualValue(BdatMember member, int valueOffset, string value)
        {
            switch (member.ValType)
            {
                case BdatValueType.UInt8:
                    Data.WriteUInt8(byte.Parse(value), valueOffset);
                    break;
                case BdatValueType.UInt16:
                    Data.WriteUInt16(ushort.Parse(value), valueOffset);
                    break;
                case BdatValueType.UInt32:
                    Data.WriteUInt32(uint.Parse(value), valueOffset);
                    break;
                case BdatValueType.Int8:
                    Data.WriteInt8(sbyte.Parse(value), valueOffset);
                    break;
                case BdatValueType.Int16:
                    Data.WriteInt16(short.Parse(value), valueOffset);
                    break;
                case BdatValueType.Int32:
                    Data.WriteInt32(int.Parse(value), valueOffset);
                    break;
                case BdatValueType.FP32:
                    Data.WriteSingle(float.Parse(value), valueOffset);
                    break;
                case BdatValueType.String:
                    int offset = Data.ReadInt32(valueOffset);
                    string oldValue = Data.ReadUTF8Z(offset);
                    int oldLength = Encoding.UTF8.GetByteCount(oldValue);
                    int length = Encoding.UTF8.GetByteCount(value);
                    if (length > oldLength) throw new ArgumentOutOfRangeException(nameof(value), "String is too long! Must be shorter or equal to previous.");
                    Data.WriteUTF8Z(value, offset);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public long ReadInt(int itemId, string memberName)
        {
            BdatMember member = MembersDict[memberName];
            int itemIndex = itemId - BaseId;
            int itemOffset = ItemTableOffset + itemIndex * ItemSize;
            int valueOffset = itemOffset + member.MemberPos;

            if (member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
            return ReadIntValue(valueOffset, member.ValType);
        }

        public float ReadFloat(int itemId, string memberName)
        {
            BdatMember member = MembersDict[memberName];
            int itemIndex = itemId - BaseId;
            int itemOffset = ItemTableOffset + itemIndex * ItemSize;
            int valueOffset = itemOffset + member.MemberPos;

            if (member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
            return ReadFloatValue(valueOffset, member.ValType);
        }

        public string ReadString(int itemId, string memberName)
        {
            BdatMember member = MembersDict[memberName];
            int itemIndex = itemId - BaseId;
            int itemOffset = ItemTableOffset + itemIndex * ItemSize;
            int valueOffset = itemOffset + member.MemberPos;

            if (member.Type != BdatMemberType.Scalar) throw new NotImplementedException();
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

        public void PrependMember(BdatMember newMember)
        {
            foreach (BdatMember member in Members.Where(x => x.Type == BdatMemberType.Flag))
            {
                member.FlagVarIndex++;
            }

            MembersDict.Add(newMember.Name, newMember);

            var newMemberArray = new BdatMember[Members.Length + 1];
            newMemberArray[0] = newMember;
            Array.Copy(Members, 0, newMemberArray, 1, Members.Length);

            Members = newMemberArray;
        }
    }

    public class BdatTable<T> : IBdatTable, IReadOnlyList<T> where T : BdatItem
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
        public BdatItem GetBdatItem(int itemId) => this[itemId];

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
        BdatItem GetBdatItem(int itemId);
    }

    public abstract class BdatItem
    {
        public int Id { get; set; }

        public T Read<T>(string member) => (T)GetType().GetField(member).GetValue(this);
        public long ReadInt(string member) => (long)GetType().GetField(member).GetValue(this);
        public float ReadFloat(string member) => (float)GetType().GetField(member).GetValue(this);
        public string ReadString(string member) => (string)GetType().GetField(member).GetValue(this);
    }
}
