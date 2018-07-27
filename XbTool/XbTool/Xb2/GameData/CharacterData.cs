using XbTool.Types;

namespace XbTool.Xb2.GameData
{
    public static class CharacterData
    {
        public static object GetCharacter(int id, BdatCollection tables)
        {
            if (id > 2000) return tables.RSC_NpcList[id];
            if (id > 1000) return tables.CHR_Bl[id];
            if (id > 0) return tables.CHR_Dr[id];
            return null;
        }
    }
}
