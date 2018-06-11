using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using XbTool.Textures;

namespace XbTool.Gimmick
{
    public static class ExportMap
    {
        public static void Export(IFileReader fs, MapInfo[] gimmicks, string outDir)
        {
            Directory.CreateDirectory(Path.Combine(outDir, "png"));

            foreach (var map in gimmicks)
            {
                //if (map.Name != "ma02a") continue;
                foreach (var area in map.Areas)
                {
                    //if (area.Name != "ma02a_f01") continue;
                    string texPath = $"/menu/image/{area.Name}_map.wilay";
                    var texBytes = fs.ReadFile(texPath);
                    var wilay = new WilayRead(texBytes);
                    Texture texture = wilay.Textures[0];
                    var bitmapBase = texture.ToBitmap();
                    float scale = 2;
                    bitmapBase = ResizeImage(bitmapBase, (int)(bitmapBase.Width * scale), (int)(bitmapBase.Height * scale));

                    //var outerBrush = new SolidBrush(System.Drawing.Color.Black);
                    //var backing = new SolidBrush(System.Drawing.Color.White);
                    var innerBrush = new SolidBrush(System.Drawing.Color.GreenYellow);
                    Pen pen = new Pen(innerBrush, 1 * scale);

                    bitmapBase.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    foreach (var gmkType in area.Gimmicks)
                    {
                        var type = gmkType.Key;
                        //if (type != "landmark") continue;
                        var bitmap = (Bitmap)bitmapBase.Clone();
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            foreach (InfoEntry gmk in gmkType.Value)
                            {
                                var point = area.Get2DPosition(gmk.Xfrm.Position);
                                graphics.FillCircle(innerBrush, point.X, point.Y, 8);
                                graphics.DrawCircle(pen, point.X, point.Y, 8);
                            }
                            //foreach (InfoEntry gmk in gmkType.Value)
                            //{
                            //    //if (gmk.String != "landmark_ma02a_101") continue;
                            //    var point = area.Get2DPosition(gmk.Xfrm.Position);
                            //    var pointS = area.Get2DPosition(gmk.Xfrm.Scale);
                            //    //graphics.FillCircle(innerBrush, point.X * scale, point.Y * scale, 5 * scale);
                            //    //DrawEllipse(graphics, pen, point.X * scale, point.Y * scale, pointS.X / 2 * scale, pointS.Y / 2 * scale);
                            //    DrawRect(graphics, pen, point.X * scale, point.Y * scale, pointS.X / 2 * scale, pointS.Y / 2 * scale);
                            //    //graphics.DrawCircle(pen, point.X * scale, point.Y * scale, 5 * scale);
                            //}

                            //foreach (InfoEntry gmk in gmkType.Value)
                            //{
                            //    //var text = gmk.String.Split('_').Last();
                            //    var text = gmk.Type.ToString();
                            //    var point = area.Get2DPosition(gmk.Xfrm.Position);

                            //    //graphics.FillRectangle(backing, point.X * scale, point.Y * scale, 30 * scale, 12 * scale);
                            //    graphics.FillRectangle(backing, point.X * scale, point.Y * scale, 12 * scale, 12 * scale);
                            //    graphics.DrawString(text, new Font("Arial", 8 * scale), outerBrush, point.X * scale, point.Y * scale);
                            //}
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
                        $"{area.Name},\"{area.DisplayName}\",{area.Priority}," +
                        $"{area.SegmentInfo.FullWidth},{area.SegmentInfo.FullHeight}," +
                        $"{area.LowerBound.X},{area.LowerBound.Y},{area.LowerBound.Z}," +
                        $"{area.UpperBound.X},{area.UpperBound.Y},{area.UpperBound.Z}");
                }
                File.WriteAllText(Path.Combine(outDir, $"mi/{map.Name}.csv"), sb.ToString());
            }

            var sbAll = new StringBuilder();
            string header = "GmkType,Id,Id in file,Name,XformType,PosX,PosY,PosZ,fc,RotX,RotY,RotZ,f1c,ScaleX,ScaleY,ScaleZ,f2c,f30,f32,f34,f38,f3c";
            sbAll.Append("Map,Filename,");
            sbAll.AppendLine(header);

            foreach (var map in gimmicks)
            {
                foreach (var gmkTypeKv in map.Gimmicks)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(header);
                    var type = gmkTypeKv.Key;

                    foreach (var gmk in gmkTypeKv.Value.Info)
                    {
                        var pos = gmk.Xfrm.Position;
                        var xfrm = gmk.Xfrm;
                        string csvLine = $"{gmk.GmkType},{gmk.Id},{gmk.IdInFile},{gmk.Name},{gmk.Type},{pos.X},{pos.Y},{pos.Z},{xfrm.FieldC}," +
                                         $"{xfrm.Rotation.X},{xfrm.Rotation.Y},{xfrm.Rotation.Z},{xfrm.Field1C}," +
                                         $"{xfrm.Scale.X},{xfrm.Scale.Y},{xfrm.Scale.Z},{xfrm.Field2C}," +
                                         $"{xfrm.Field30},{xfrm.Field32},{xfrm.Field34},{xfrm.Field38},{xfrm.Field3C}";
                        sb.AppendLine(csvLine);
                        sbAll.Append($"{map.Name},{type},");
                        sbAll.AppendLine(csvLine);
                    }

                    File.WriteAllText(Path.Combine(outDir, $"gmk/{map.Name}-{type}.csv"), sb.ToString());
                }
            }

            File.WriteAllText(Path.Combine(outDir, "gmk/all.csv"), sbAll.ToString());
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void FillCircle(this Graphics g, Brush brush,
            float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }

        public static void DrawRect(this Graphics g, Pen pen,
            float centerX, float centerY, float scaleX, float scaleY)
        {
            g.DrawRectangle(pen, centerX - scaleX / 2, centerY - scaleY / 2, scaleX, scaleY);
        }

        public static void DrawEllipse(this Graphics g, Pen pen,
            float centerX, float centerY, float scaleX, float scaleY)
        {
            g.DrawEllipse(pen, centerX - scaleX / 2, centerY - scaleY / 2, scaleX, scaleY);
        }

        public static void FillEllipse(this Graphics g, Brush brush,
            float centerX, float centerY, float scaleX, float scaleY)
        {
            g.FillEllipse(brush, centerX - scaleX / 2, centerY - scaleY / 2, scaleX, scaleY);
        }

        public static void FillRect(this Graphics g, Brush brush,
            float centerX, float centerY, float scaleX, float scaleY)
        {
            g.FillRectangle(brush, centerX - scaleX / 2, centerY - scaleY / 2, scaleX, scaleY);
        }

        public static void DrawCircle(this Graphics g, Pen pen,
            float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                radius + radius, radius + radius);
        }
    }
}
