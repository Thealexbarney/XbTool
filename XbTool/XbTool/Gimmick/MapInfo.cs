using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using LibHac.IO;
using XbTool.Common;

namespace XbTool.Gimmick
{
    [DebuggerDisplay("{" + nameof(DisplayName) + ", nq}")]
    public class MapInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Dictionary<string, Lvb> Gimmicks { get; set; }
        public MapAreaInfo[] Areas { get; }

        public MapInfo(DataBuffer data)
        {
            int count = data.ReadInt32(4, true);
            Areas = new MapAreaInfo[count];

            for (int i = 0; i < count; i++)
            {
                var area = new MapAreaInfo();
                int start = data.Position;
                area.Name = data.ReadUTF8Z();
                area.DisplayName = area.Name;
                data.Position = start + 32;
                float xLo = data.ReadSingle();
                float yLo = data.ReadSingle();
                float zLo = data.ReadSingle();
                float xHi = data.ReadSingle();
                float yHi = data.ReadSingle();
                float zHi = data.ReadSingle();
                area.LowerBound = new Point3(xLo, yLo, zLo);
                area.UpperBound = new Point3(xHi, yHi, zHi);
                area.Size = new Point3(xHi - xLo, yHi - yLo, zHi - zLo);
                data.Position = start + 72;
                Areas[i] = area;

                if (area.Name.EndsWith("_cave1"))
                {
                    area.Name = "dlc3_" + area.Name.Replace("_cave1", "");
                }
            }
        }

        public MapAreaInfo GetContainingArea(Point3 point)
        {
            MapAreaInfo containingArea = null;
            int minPriority = int.MaxValue;

            foreach (MapAreaInfo area in Areas)
            {
                if (area.Contains(point) && area.Priority < minPriority)
                {
                    containingArea = area;
                    minPriority = area.Priority;
                }
            }

            return containingArea;
        }

        public static Dictionary<string, MapInfo> ReadAll(IFileSystem fs)
        {
            var infos = new Dictionary<string, MapInfo>();
            IEnumerable<string> filenames = fs.OpenDirectory("/menu/minimap", OpenDirectoryMode.Files)
                .EnumerateEntries("*.mi", SearchOptions.Default).Select(x => x.FullPath);

            foreach (string filename in filenames)
            {
                if (filename == null) continue;
                byte[] file = fs.ReadFile(filename);
                var info = new MapInfo(new DataBuffer(file, Game.XB2, 0))
                {
                    Name = Path.GetFileNameWithoutExtension(filename)
                };
                info.DisplayName = info.Name;
                infos.Add(info.Name, info);
            }

            foreach (MapInfo map in infos.Values)
            {
                foreach (MapAreaInfo area in map.Areas)
                {
                    string name = area.Name;
                    byte[] file = fs.ReadFile($"/menu/minimap/{name}_map.seg");
                    area.SegmentInfo = new MapSegmentInfo(new DataBuffer(file, Game.XB2, 0));
                }
            }

            return infos;
        }
    }

    [DebuggerDisplay("{" + nameof(DisplayName) + ", nq}")]
    public class MapAreaInfo
    {
        public MapSegmentInfo SegmentInfo { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, List<InfoEntry>> Gimmicks { get; } = new Dictionary<string, List<InfoEntry>>();

        public Point3 LowerBound { get; set; }
        public Point3 UpperBound { get; set; }
        public Point3 Size { get; set; }

        public bool Contains(Point3 point)
        {
            return point.X >= LowerBound.X && point.X < UpperBound.X
                   && point.Y >= LowerBound.Y && point.Y < UpperBound.Y
                   && point.Z >= LowerBound.Z && point.Z < UpperBound.Z;
        }

        public void AddGimmick(InfoEntry gimmick, string type)
        {
            if (!Gimmicks.ContainsKey(type))
            {
                Gimmicks.Add(type, new List<InfoEntry>());
            }

            Gimmicks[type].Add(gimmick);
        }

        public Point2 Get2DPosition(Point3 point3)
        {
            float x = (point3.X - LowerBound.X) / Size.X * SegmentInfo.FullWidth;
            float y = (point3.Z - LowerBound.Z) / Size.Z * SegmentInfo.FullHeight;
            return new Point2(x, y);
        }
    }

    public class MapSegmentInfo
    {
        public int SegWidth { get; }
        public int SegHeight { get; }
        public int Width { get; }
        public int Height { get; }
        public int FullExtraWidth { get; }
        public int FullExtraHeight { get; }
        public int FullWidth { get; }
        public int FullHeight { get; }

        public MapSegmentInfo(DataBuffer data)
        {
            SegWidth = data.ReadInt32();
            SegHeight = data.ReadInt32();
            Width = data.ReadInt32();
            Height = data.ReadInt32();
            FullExtraWidth = data.ReadUInt16();
            FullExtraHeight = data.ReadUInt16();
            FullWidth = SegWidth * Width - FullExtraWidth;
            FullHeight = SegHeight * Height - FullExtraHeight;
        }
    }
}
