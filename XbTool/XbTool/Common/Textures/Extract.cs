using System;
using System.IO;
using LibHac;
using XbTool.Xb2;
using XbTool.Xb2.Textures;
using FileInfo = XbTool.Xb2.FileInfo;

namespace XbTool.Common.Textures
{
    public static class Extract
    {
        public static void ExtractTextures(FileArchive archive, string texDir, string outDir, IProgressReport progress = null)
        {
            FileInfo[] fileInfos = archive.GetChildFileInfos(texDir);
            progress?.SetTotal(fileInfos.Length);

            foreach (FileInfo info in fileInfos)
            {
                try
                {
                    byte[] file = archive.ReadFile(info);
                    string filename = Path.GetFileNameWithoutExtension(info.Filename);

                    ExportWilayTextures(file, filename, outDir, progress);
                }
                catch (Exception ex)
                {
                    progress?.LogMessage($"{ex.Message} {info.Filename}");
                }
                progress?.ReportAdd(1);
            }
        }

        public static void ExtractTextures(string[] filenames, string outDir, IProgressReport progress = null)
        {
            progress?.SetTotal(filenames.Length);

            foreach (string filename in filenames)
            {
                try
                {
                    byte[] file = File.ReadAllBytes(filename);
                    string name = Path.GetFileNameWithoutExtension(filename);

                    ExportWilayTextures(file, name, outDir, progress);
                }
                catch (Exception ex)
                {
                    progress?.LogMessage($"{ex.Message} {filename}");
                }
                progress?.ReportAdd(1);
            }
        }

        private static void ExportWilayTextures(byte[] file, string name, string outDir, IProgressReport progress = null)
        {
            var wilay = new WilayRead(file);

            Directory.CreateDirectory(outDir);
            for (int i = 0; i < wilay.Textures.Length; i++)
            {
                byte[] png = wilay.Textures[i].ToPng();

                if (png == null)
                {
                    progress?.LogMessage($"{wilay.Textures[i].Format} decoding not implemented. Converting to DDS.");

                    byte[] dds = Dds.CreateDds(wilay.Textures[i]);
                    File.WriteAllBytes(Path.Combine(outDir, name + "_" + i + ".dds"), dds);
                    continue;
                }

                File.WriteAllBytes(Path.Combine(outDir, name + "_" + i + ".png"), png);
            }
        }
    }
}

