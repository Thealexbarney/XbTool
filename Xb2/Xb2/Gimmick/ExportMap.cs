using System.Drawing;
using System.IO;
using System.Text;
using Xb2.Textures;

namespace Xb2.Gimmick
{
    public static class ExportMap
    {
        public static void Export(IFileReader fs, MapInfo[] gimmicks, string outDir)
        {
            Directory.CreateDirectory(Path.Combine(outDir, "png"));

            foreach (var map in gimmicks)
            {
                foreach (var area in map.Areas)
                {
                    string texPath = $"/menu/image/{area.Name}_map.wilay";
                    var texBytes = fs.ReadFile(texPath);
                    var wilay = new WilayRead(texBytes);
                    Texture texture = wilay.Textures[0];
                    var bitmapBase = texture.ToBitmap();

                    var outerBrush = new SolidBrush(System.Drawing.Color.Black);
                    var innerBrush = new SolidBrush(System.Drawing.Color.GreenYellow);
                    Pen pen = new Pen(outerBrush, 2);

                    bitmapBase.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    foreach (var gmkType in area.Gimmicks)
                    {
                        var type = gmkType.Key;
                        var bitmap = (Bitmap)bitmapBase.Clone();
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            foreach (InfoEntry gmk in gmkType.Value)
                            {
                                var point = area.Get2DPosition(gmk.Xfrm.Position);
                                graphics.FillCircle(innerBrush, point.X, point.Y, 8);
                                graphics.DrawCircle(pen, point.X, point.Y, 8);
                            }
                        }

                        var png = bitmap.ToPng();

                        File.WriteAllBytes(Path.Combine(outDir, $"png/{map.DisplayName} - {area.DisplayName} - {type}.png"), png);
                    }
                }
            }
        }

        public static void ExportCsv(MapInfo[] gimmicks, string outDir)
        {
            Directory.CreateDirectory(Path.Combine(outDir, "mi"));
            Directory.CreateDirectory(Path.Combine(outDir, "gmk"));
            foreach (MapInfo map in gimmicks)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Name,DisplayName,Priority,Width,Height,LowerX,LowerY,LowerZ,UpperX,UpperY,UpperZ");

                foreach (var area in map.Areas)
                {
                    sb.AppendLine(
                        $"{area.Name},{area.DisplayName},{area.Priority}," +
                        $"{area.SegmentInfo.FullWidth},{area.SegmentInfo.FullHeight}," +
                        $"{area.LowerBound.X},{area.LowerBound.Y},{area.LowerBound.Z}," +
                        $"{area.UpperBound.X},{area.UpperBound.Y},{area.UpperBound.Z}");
                }
                File.WriteAllText(Path.Combine(outDir, $"mi/{map.Name}.csv"), sb.ToString());
            }

            foreach (var map in gimmicks)
            {
                foreach (var gmkTypeKv in map.Gimmicks)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Name,X,Y,Z");
                    var type = gmkTypeKv.Key;

                    foreach (var gmk in gmkTypeKv.Value.Info)
                    {
                        var pos = gmk.Xfrm.Position;
                        sb.AppendLine($"{gmk.String},{pos.X},{pos.Y},{pos.Z}");
                    }

                    File.WriteAllText(Path.Combine(outDir, $"gmk/{map.Name}-{type}.csv"), sb.ToString());
                }
            }
        }

        public static void FillCircle(this Graphics g, Brush brush,
            float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }

        public static void DrawCircle(this Graphics g, Pen pen,
            float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }
    }
}
