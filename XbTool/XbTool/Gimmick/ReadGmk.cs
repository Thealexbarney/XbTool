using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using XbTool.Types;

namespace XbTool.Gimmick
{
    public static class ReadGmk
    {
        public static MapInfo[] ReadAll(IFileReader fs, BdatCollection tables)
        {
            Dictionary<string, MapInfo> maps = MapInfo.ReadAll(fs);

            var mapList = tables.FLD_maplist;
            var areaList = tables.MNU_MapInfo;

            foreach (MapInfo mapInfo in maps.Values)
            {
                var map = mapList.FirstOrDefault(x => x.resource == mapInfo.Name && x._nameID != null);
                if (map == null) continue;
                if (map._nameID != null) mapInfo.DisplayName = map._nameID.name;

                foreach (var areaInfo in mapInfo.Areas)
                {
                    MNU_MapInfo area = areaList.FirstOrDefault(x =>
                        x.level_name == areaInfo.Name || x.level_name2 == areaInfo.Name);
                    Debug.Assert(area != null, "Area does not exist");

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

                var gimmickSet = ReadGimmickSet(fs, tables, map.Id);
                AssignGimmickAreas(gimmickSet, mapInfo);
            }

            return maps.Values.ToArray();
        }

        public static Dictionary<string, Lvb> ReadGimmickSet(IFileReader fs, BdatCollection tables, int mapId)
        {
            RSC_GmkSetList setBdat = tables.RSC_GmkSetList.First(x => x.mapId == mapId);
            var fieldsDict = setBdat.GetType().GetFields().ToDictionary(x => x.Name, x => x);
            var fields = fieldsDict.Values.Where(x => x.FieldType == typeof(string) && !x.Name.Contains("_bdat"));
            var gimmicks = new Dictionary<string, Lvb>();

            foreach (FieldInfo field in fields)
            {
                var value = (string)field.GetValue(setBdat);
                if (value == null) continue;
                string filename = $"/gmk/{value}.lvb";
                if (!fs.Exists(filename)) continue;

                byte[] file = fs.ReadFile(filename);
                var lvb = new Lvb(new DataBuffer(file, Game.XB2, 0)) { Filename = field.Name };

                string bdatField = field.Name + "_bdat";
                if (fieldsDict.ContainsKey(bdatField))
                {
                    var bdatName = (string)fieldsDict[bdatField].GetValue(setBdat);
                    if (!string.IsNullOrWhiteSpace(bdatName)) lvb.BdatName = bdatName;
                }

                gimmicks.Add(field.Name, lvb);
            }

            return gimmicks;
        }

        public static void AssignGimmickAreas(Dictionary<string, Lvb> set, MapInfo mapInfo)
        {
            mapInfo.Gimmicks = set;
            foreach (var gmkType in set)
            {
                var type = gmkType.Key;
                foreach (var gmk in gmkType.Value.Info)
                {
                    MapAreaInfo area = mapInfo.GetContainingArea(gmk.Xfrm.Position);
                    area?.AddGimmick(gmk, type);
                }
            }
        }
    }
}
