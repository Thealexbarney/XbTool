using System;

namespace Xb2.Bdat
{
    public class BdatTable
    {
        public string Name { get; }

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

        public BdatTable(byte[] file, int offset)
        {
            if (BitConverter.ToUInt32(file, offset) != 0x54414442) return;

            EncryptionFlag = BitConverter.ToUInt16(file, offset + 4);
            NamesOffset = BitConverter.ToUInt16(file, offset + 6);
            ItemSize = BitConverter.ToUInt16(file, offset + 8);
            HashTableOffset = BitConverter.ToUInt16(file, offset + 10);
            HashTableLength = BitConverter.ToUInt16(file, offset + 12);
            ItemTableOffset = BitConverter.ToUInt16(file, offset + 14);
            ItemCount = BitConverter.ToUInt16(file, offset + 16);
            BaseId = BitConverter.ToUInt16(file, offset + 18);
            Field14 = BitConverter.ToUInt16(file, offset + 20);
            Checksum = BitConverter.ToUInt16(file, offset + 22);
            StringsOffset = BitConverter.ToUInt32(file, offset + 24);
            StringsLength = BitConverter.ToUInt32(file, offset + 28);
            MemberTableOffset = BitConverter.ToUInt16(file, offset + 32);
            MemberCount = BitConverter.ToUInt16(file, offset + 34);

            Name = Stuff.GetUTF8Z(file, offset + NamesOffset);
            Members = ReadTableMembers(file, offset);
        }

        public static BdatMember[] ReadTableMembers(byte[] file, int offset)
        {
            int memberTableOffset = BitConverter.ToUInt16(file, offset + 32);
            int memberCount = BitConverter.ToUInt16(file, offset + 34);
            var members = new BdatMember[memberCount];

            for (int i = 0; i < memberCount; i++)
            {
                int memberOffset = offset + memberTableOffset + i * 6;
                var member = new BdatMember(file, offset, memberOffset);
                members[i] = member;
            }

            return members;
        }
    }

    public class BdatTable<T> : IBdatTable where T : class
    {
        public string Name { get; set; }
        public int BaseId { get; set; }
        public BdatMember[] Members { get; set; }
        public T[] Items { get; set; }
        public T this[int itemId] => Items[itemId - BaseId];
        public T GetItemOrNull(int itemId) => ContainsId(itemId) ? this[itemId] : null;
        public Type ItemType { get; } = typeof(T);
        Array IBdatTable.Items { get => Items; set => Items = (T[])value; }

        public bool ContainsId(int itemId)
        {
            int id = itemId - BaseId;
            return id >= 0 && id < Items.Length;
        }
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
