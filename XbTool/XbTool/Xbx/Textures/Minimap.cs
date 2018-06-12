using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using XbTool.Textures;

namespace XbTool.Xbx.Textures
{
    public static class Minimap
    {
        public static void ExtractMinimap(string inDir, string outDir)
        {
            var filenames = Directory.GetFiles(inDir, "map_???_???_???.catex");
            Directory.CreateDirectory(outDir);
            var segmentGroups = filenames.Select(x => new Segment(x)).GroupBy(x => x.MapId);
            var maps = new List<Map>();

            foreach (var segmentGroup in segmentGroups)
            {
                var normalSegs = segmentGroup.Where(x => x.XSeg < 999 && x.YSeg < 999).ToList();
                var map = new Map
                {
                    Id = segmentGroup.Key,
                    Segments = segmentGroup.ToList(),
                    DefaultSegment = segmentGroup.First(x => x.XSeg == 999),
                    XMin = normalSegs.Min(x => x.XSeg),
                    XMax = normalSegs.Max(x => x.XSeg),
                    YMin = normalSegs.Min(x => x.YSeg),
                    YMax = normalSegs.Max(x => x.YSeg)
                };

                map.Height = map.YMax - map.YMin + 1;
                map.Width = map.XMax - map.XMin + 1;

                foreach (var seg in map.Segments)
                {
                    seg.X = seg.XSeg - map.XMin;
                    seg.Y = seg.YSeg - map.YMin;
                }

                maps.Add(map);
            }

            foreach (var map in maps)
            {
                var png = StitchMap(map);
                var outName = Path.Combine(outDir, $"{map.Id}.png");
                File.WriteAllBytes(outName, png);
            }
        }

        private static byte[] StitchMap(Map map)
        {
            var defaultSegFile = File.ReadAllBytes(map.DefaultSegment.Filename);
            var defaultSeg = new Texture(new DataBuffer(defaultSegFile, Game.XBX, 0)).ToBitmap();

            using (var bitmap = new Bitmap(map.Width * 256, map.Height * 256, PixelFormat.Format32bppArgb))
            using (Graphics img = Graphics.FromImage(bitmap))
            {
                for (int x = 0; x < map.Width; x++)
                {
                    for (int y = 0; y < map.Height; y++)
                    {
                        img.DrawImage(defaultSeg, x * 256, y * 256);
                    }
                }

                foreach (var seg in map.Segments)
                {
                    var segFile = File.ReadAllBytes(seg.Filename);
                    var segmentTex = new Texture(new DataBuffer(segFile, Game.XBX, 0));
                    var segBitmap = segmentTex.ToBitmap();
                    img.DrawImage(segBitmap, seg.X * 256, seg.Y * 256);
                }

                return bitmap.ToPng();
            }
        }

        private class Map
        {
            public List<Segment> Segments { get; set; }
            public Segment DefaultSegment { get; set; }
            public int Id { get; set; }
            public int XMin { get; set; }
            public int XMax { get; set; }
            public int YMin { get; set; }
            public int YMax { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private class Segment
        {
            public string Filename { get; set; }
            public int MapId { get; set; }
            public int XSeg { get; set; }
            public int YSeg { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public Segment(string filename)
            {
                Filename = filename;
                string name = Path.GetFileNameWithoutExtension(filename);
                if (name == null) throw new ArgumentException($"Invalid minimap filename {filename}");
                var split = name.Split('_');
                MapId = int.Parse(split[1]);
                XSeg = int.Parse(split[2]);
                YSeg = int.Parse(split[3]);
            }
        }
    }
}
