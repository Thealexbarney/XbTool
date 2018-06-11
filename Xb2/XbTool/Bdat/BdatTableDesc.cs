using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace XbTool.Bdat
{
    public class BdatTableDesc
    {
        public string Name { get; set; }
        public BdatFieldInfo[] TableRefs { get; set; }
        public BdatArrayInfo[] Arrays { get; set; }
        public BdatType Type { get; set; }
    }

    [DebuggerDisplay("{Name}")]
    public class BdatType
    {
        public BdatType() { }

        public BdatType(BdatMember[] members, List<string> tableNames, Dictionary<string, string> customNames)
        {
            Members = members;
            TableNames = tableNames;
            Name = tableNames.FirstOrDefault();

            foreach (string tableName in tableNames)
            {
                if (customNames.TryGetValue(tableName, out string typeName))
                {
                    Name = typeName;
                    return;
                }
            }
        }

        public string Name { get; set; }
        public BdatMember[] Members { get; set; }
        public List<string> TableNames { get; set; } = new List<string>();
        public List<BdatFieldInfo> TableRefs { get; } = new List<BdatFieldInfo>();
        public List<BdatArrayInfo> Arrays { get; } = new List<BdatArrayInfo>();
    }
}
