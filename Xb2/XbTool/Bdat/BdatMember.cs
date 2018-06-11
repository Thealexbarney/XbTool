using System.Collections.Generic;
using System.Diagnostics;

namespace XbTool.Bdat
{
    [DebuggerDisplay("{" + nameof(Name) + ", nq}")]
    public class BdatMember
    {
        public string Name { get; }
        public BdatMemberType Type { get; }
        public BdatValueType ValType { get; }
        public int MemberPos { get; }
        public int ArrayCount { get; }
        public int FlagVarOffset { get; }
        public int FlagIndex { get; }
        public uint FlagMask { get; }
        public int FlagVarIndex { get; }
        public BdatFieldInfo Metadata { get; set; }

        public BdatMember(string name, BdatMemberType type, BdatValueType valType)
        {
            Name = name;
            Type = type;
            ValType = valType;
        }

        public BdatMember(DataBuffer table, int offset, HashSet<string> usedNames)
        {
            int infoOffset = table.ReadUInt16(offset);
            int nameOffset = table.Game == Game.XB1 ? offset + 4 : table.ReadUInt16(offset + 4);

            var name = table.ReadUTF8Z(nameOffset);
            int dupe = 0;
            Name = name;

            while (usedNames.Contains(Name))
            {
                Name = $"{name}_{dupe++}";
            }

            usedNames.Add(Name);

            Type = (BdatMemberType)table[infoOffset];

            if (Type == BdatMemberType.Flag)
            {
                int memberTableOffset = table.ReadUInt16(32);
                FlagIndex = table[infoOffset + 1];
                FlagMask = table.ReadUInt32(infoOffset + 2);
                FlagVarOffset = table.ReadUInt16(infoOffset + 6);
                FlagVarIndex = (FlagVarOffset - memberTableOffset) / 6;
            }
            else
            {
                ValType = (BdatValueType)table[infoOffset + 1];
                MemberPos = table.ReadUInt16(infoOffset + 2);
            }
            if (Type == BdatMemberType.Array)
            {
                ArrayCount = table.ReadUInt16(infoOffset + 4);
            }
        }
    }
}
