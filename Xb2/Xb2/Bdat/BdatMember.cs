using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Xb2.Bdat
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

        public BdatMember(byte[] file, int tableOffset, int offset, HashSet<string> usedNames)
        {
            int infoOffset = tableOffset + BitConverter.ToUInt16(file, offset);
            int nameOffset = tableOffset + BitConverter.ToUInt16(file, offset + 4);

            var name = Stuff.GetUTF8Z(file, nameOffset);
            int dupe = 0;
            Name = name;

            while (usedNames.Contains(Name))
            {
                Name = $"{name}_{dupe++}";
            }

            usedNames.Add(Name);

            Type = (BdatMemberType)file[infoOffset];

            if (Type == BdatMemberType.Flag)
            {
                int memberTableOffset = BitConverter.ToUInt16(file, tableOffset + 32);
                FlagIndex = file[infoOffset + 1];
                FlagMask = BitConverter.ToUInt32(file, infoOffset + 2);
                FlagVarOffset = BitConverter.ToUInt16(file, infoOffset + 6);
                FlagVarIndex = (FlagVarOffset - memberTableOffset) / 6;
            }
            else
            {
                ValType = (BdatValueType)file[infoOffset + 1];
                MemberPos = BitConverter.ToUInt16(file, infoOffset + 2);
            }
            if (Type == BdatMemberType.Array)
            {
                ArrayCount = BitConverter.ToUInt16(file, infoOffset + 4);
            }
        }
    }
}
