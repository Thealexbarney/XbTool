using XbTool.Types;

namespace XbTool.Xb2.GameData
{
    public static class GimmickData
    {
        public static string GetPlaceName(PlaceCategory category, int id, BdatCollection tables)
        {
            var tableName = GetPlaceTable(category, id);
            if (tableName == null) return string.Empty;
            var name = tables[tableName].GetBdatItem(id).Read<string>("name");
            return name;
        }

        public static string GetPlaceTable(PlaceCategory category, int id)
        {
            switch (category)
            {
                case PlaceCategory.None:
                    break;
                case PlaceCategory.Cat1:
                    break;
                case PlaceCategory.Landmark:
                    return GetLandmarkGmkTable(id);
                case PlaceCategory.Event:
                    return GetEventGmkTable(id);
            }
            return null;
        }

        public static string GetEventGmkTable(int id)
        {
            if (id > 41000) return "ma41a_FLD_EventPop";
            if (id > 40000) return "ma40a_FLD_EventPop";
            if (id > 31248) return "ma49c_FLD_EventPop";
            if (id > 30000) return "ma30a_FLD_EventPop";
            if (id > 21000) return "ma21a_FLD_EventPop";
            if (id > 20000) return "ma20a_FLD_EventPop";
            if (id > 18000) return "ma18a_FLD_EventPop";
            if (id > 17000) return "ma17a_FLD_EventPop";
            if (id > 16000) return "ma16a_FLD_EventPop";
            if (id > 15000) return "ma15a_FLD_EventPop";
            if (id > 13000) return "ma13a_FLD_EventPop";
            if (id > 11000) return "ma11a_FLD_EventPop";
            if (id > 10000) return "ma10a_FLD_EventPop";
            if (id > 8000) return "ma08a_FLD_EventPop";
            if (id > 7000) return "ma07a_FLD_EventPop";
            if (id > 5000) return "ma05a_FLD_EventPop";
            if (id > 4000) return "ma04a_FLD_EventPop";
            if (id > 3000) return "ma03a_FLD_EventPop";
            if (id > 2000) return "ma02a_FLD_EventPop";
            return null;
        }

        public static string GetLandmarkGmkTable(int id)
        {
            if (id > 2900) return "ma49c_FLD_LandmarkPop";
            if (id > 2400) return "ma41a_FLD_LandmarkPop";
            if (id > 2300) return "ma40a_FLD_LandmarkPop";
            if (id > 2100) return "ma21a_FLD_LandmarkPop";
            if (id > 2000) return "ma20a_FLD_LandmarkPop";
            if (id > 1800) return "ma18a_FLD_LandmarkPop";
            if (id > 1700) return "ma17a_FLD_LandmarkPop";
            if (id > 1600) return "ma16a_FLD_LandmarkPop";
            if (id > 1500) return "ma15a_FLD_LandmarkPop";
            if (id > 1300) return "ma13a_FLD_LandmarkPop";
            if (id > 1100) return "ma11a_FLD_LandmarkPop";
            if (id > 1000) return "ma10a_FLD_LandmarkPop";
            if (id > 800) return "ma08a_FLD_LandmarkPop";
            if (id > 700) return "ma07a_FLD_LandmarkPop";
            if (id > 500) return "ma05a_FLD_LandmarkPop";
            if (id > 400) return "ma04a_FLD_LandmarkPop";
            if (id > 300) return "ma03a_FLD_LandmarkPop";
            if (id > 200) return "ma02a_FLD_LandmarkPop";
            if (id > 100) return "ma01a_FLD_LandmarkPop";
            return null;
        }
    }
}
