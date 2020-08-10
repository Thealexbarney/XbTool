using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibHac;
using LibHac.Fs;
using LibHac.FsSystem;
using XbTool.Bdat;
using XbTool.Common;
using XbTool.Types;

namespace XbTool.Gimmick
{
    public static class ReadGmk
    {
        public static MapInfo[] ReadAll(IFileSystem fs, BdatCollection tables, IProgressReport progress = null)
        {
            progress?.LogMessage("Reading map info and gimmick sets");
            Dictionary<string, MapInfo> maps = MapInfo.ReadAll(fs);

            BdatTable<FLD_maplist> mapList = tables.FLD_maplist;
            BdatTable<MNU_MapInfo> areaList = tables.MNU_MapInfo;

            foreach (MapInfo mapInfo in maps.Values)
            {
                FLD_maplist map = mapList.FirstOrDefault(x => x.resource == mapInfo.Name && x._nameID != null);
                if (map == null) continue;
                if (map._nameID != null) mapInfo.DisplayName = map._nameID.name;

                foreach (MapAreaInfo areaInfo in mapInfo.Areas)
                {
                    MNU_MapInfo area = areaList.FirstOrDefault(x =>
                        x.level_name == areaInfo.Name || x.level_name2 == areaInfo.Name);
                    if (area == null)
                    {
                        progress?.LogMessage($"Found area {areaInfo.Name} that is not in the BDAT tables");
                        continue;
                    }

                    // Some areas use one of 2 maps depending on the game state.
                    // These 2 maps are always the same except one has a small addition or removal.
                    // We want the map with the most objects on it, so we use the second map for
                    // Gormott (ma05a), and the first map for everywhere else.
                    if (!string.IsNullOrWhiteSpace(area.level_name2)
                        && area.level_name == areaInfo.Name
                        && mapInfo.Name == "ma05a")
                    {
                        areaInfo.Priority = int.MaxValue;
                    }
                    else if (!string.IsNullOrWhiteSpace(area.level_name2)
                             && area.level_name2 == areaInfo.Name
                             && mapInfo.Name != "ma05a")
                    {
                        areaInfo.Priority = int.MaxValue;
                    }
                    else
                    {
                        areaInfo.Priority = area.level_priority;
                    }

                    if (area._disp_name?.name != null) areaInfo.DisplayName = area._disp_name.name;
                }

                Dictionary<string, Lvb> gimmickSet = ReadGimmickSet(fs, tables, map.Id);
                AssignGimmickAreas(gimmickSet, mapInfo);
            }

            return maps.Values.ToArray();
        }

        public static Dictionary<string, Lvb> ReadGimmickSet(IFileSystem fs, BdatCollection tables, int mapId)
        {
            RSC_GmkSetList setBdat = tables.RSC_GmkSetList.First(x => x.mapId == mapId);
            Dictionary<string, FieldInfo> fieldsDict = setBdat.GetType().GetFields().ToDictionary(x => x.Name, x => x);
            IEnumerable<FieldInfo> fields = fieldsDict.Values.Where(x => x.FieldType == typeof(string) && !x.Name.Contains("_bdat"));
            var gimmicks = new Dictionary<string, Lvb>();

            foreach (FieldInfo field in fields)
            {
                string value = (string)field.GetValue(setBdat);
                if (value == null) continue;
                string filename = $"/gmk/{value}.lvb";
                if (!fs.FileExists(filename)) continue;

                byte[] file = fs.ReadFile(filename);
                var lvb = new Lvb(new DataBuffer(file, Game.XB2, 0)) { Filename = field.Name };

                string bdatField = field.Name + "_bdat";
                if (fieldsDict.ContainsKey(bdatField))
                {
                    string bdatName = (string)fieldsDict[bdatField].GetValue(setBdat);
                    if (!string.IsNullOrWhiteSpace(bdatName)) lvb.BdatName = bdatName;
                }

                gimmicks.Add(field.Name, lvb);
            }

            return gimmicks;
        }

        public static void AssignGimmickAreas(Dictionary<string, Lvb> set, MapInfo mapInfo)
        {
            mapInfo.Gimmicks = set;
            foreach (KeyValuePair<string, Lvb> gmkType in set)
            {
                string type = gmkType.Key;
                foreach (InfoEntry gmk in gmkType.Value.Info)
                {
                    MapAreaInfo area = mapInfo.GetContainingArea(gmk.Xfrm.Position);
                    area?.AddGimmick(gmk, type);
                }
            }
        }
    }
}
