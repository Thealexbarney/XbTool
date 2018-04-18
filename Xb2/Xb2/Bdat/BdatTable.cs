using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Xb2.Bdat
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
            Members = ReadTableMembers(table);
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
