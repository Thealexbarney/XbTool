using System;
using System.IO;

namespace Xb2.Textures
{
    public static class Extract
    {
        public static void ExtractTextures(FileArchive archive, string texDir, string outDir)
        {
            FileInfo[] fileInfos = archive.GetChildFileInfos(texDir);

            foreach (FileInfo info in fileInfos)
            {
                try
                {
                    byte[] file = archive.ReadFile(info);
                    string filename = Path.GetFileNameWithoutExtension(info.Filename);

                    var wilay = new WilayRead(file);

                    Directory.CreateDirectory(outDir);
                    for (int i = 0; i < wilay.Textures.Length; i++)
                    {
                        byte[] png = wilay.Textures[i].ToPng();

                        if (png == null)
                        {
                            Console.WriteLine($"{wilay.Textures[i].Format} decoding not implemented");
                            continue;
                        }

                        File.WriteAllBytes(Path.Combine(outDir, filename + "_" + i + ".png"), png);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {info.Filename}");
                }
            }
        }
    }
}
