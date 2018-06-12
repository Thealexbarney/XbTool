using System.Collections.Generic;
using System.Linq;
using XbTool.Bdat;

namespace XbTool.CodeGen
{
    public class BdatTableComparer : EqualityComparer<BdatTable>
    {
        private readonly BdatMemberComparer _memberComparer = new BdatMemberComparer();

        public override bool Equals(BdatTable x, BdatTable y)
        {
            return x != null && y != null && x.Members.SequenceEqual(y.Members, _memberComparer);
        }

        public override int GetHashCode(BdatTable obj)
        {
            if (obj == null) return 0;
            int hashCode = 1048720301;

            foreach (BdatMember member in obj.Members)
            {
                hashCode = hashCode * -1521134295 + _memberComparer.GetHashCode(member);
            }

            return hashCode;
        }
    }

    public class BdatMemberComparer : EqualityComparer<BdatMember>
    {
        public override bool Equals(BdatMember x, BdatMember y)
        {
            return x != null && y != null &&
                   x.Name == y.Name &&
                   x.Type == y.Type &&
                   x.ValType == y.ValType &&
                   x.MemberPos == y.MemberPos &&
                   x.ArrayCount == y.ArrayCount &&
                   x.FlagIndex == y.FlagIndex &&
                   x.FlagMask == y.FlagMask &&
                   x.FlagVarIndex == y.FlagVarIndex;
        }

        public override int GetHashCode(BdatMember obj)
        {
            if (obj == null) return 0;
            int hashCode = 235921822;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(obj.Name);
            hashCode = hashCode * -1521134295 + obj.Type.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.ValType.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.MemberPos.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.ArrayCount.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.FlagIndex.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.FlagMask.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.FlagVarIndex.GetHashCode();
            return hashCode;
        }
    }
}
