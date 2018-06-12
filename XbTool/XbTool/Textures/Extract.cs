using System;
using System.IO;

namespace XbTool.Textures
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

                    ExportWilayTextures(file, filename, outDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {info.Filename}");
                }
            }
        }

        public static void ExtractTextures(string[] filenames, string outDir)
        {
            foreach (var filename in filenames)
            {
                try
                {
                    byte[] file = File.ReadAllBytes(filename);
                    string name = Path.GetFileNameWithoutExtension(filename);

                    ExportWilayTextures(file, name, outDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {filename}");
                }
            }
        }

        private static void ExportWilayTextures(byte[] file, string name, string outDir)
        {
            var wilay = new WilayRead(file);

            Directory.CreateDirectory(outDir);
            for (int i = 0; i < wilay.Textures.Length; i++)
            {
                byte[] png = wilay.Textures[i].ToPng();

                if (png == null)
                {
                    Console.WriteLine($"{wilay.Textures[i].Format} decoding not implemented. Converting to DDS.");

                    byte[] dds = Dds.CreateDds(wilay.Textures[i]);
                    File.WriteAllBytes(Path.Combine(outDir, name + "_" + i + ".dds"), dds);
                    continue;
                }

                File.WriteAllBytes(Path.Combine(outDir, name + "_" + i + ".png"), png);
            }
        }
    }
}

