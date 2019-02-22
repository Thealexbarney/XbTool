using System;
using System.IO;
using XbTool.Common;
using XbTool.Common.Textures;

namespace XbTool.Xbx.Textures
{
    public static class Extract
    {
        public static void ExtractTextures(string[] filenames, string outDir)
        {
            foreach (string filename in filenames)
            {
                try
                {
                    var file = new DataBuffer(File.ReadAllBytes(filename), Game.XBX, 0);
                    string name = Path.GetFileNameWithoutExtension(filename);

                    ReadMtxt(file, name, outDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message} {filename}");
                }
            }
        }

        public static void ReadMtxt(DataBuffer file, string name, string outDir)
        {
            var texture = new MtxtTexture(file);
            byte[] png = texture.ToPng();

            if (png == null)
            {
                Console.WriteLine($"{texture.Format} decoding not implemented. Converting to DDS.");
                throw new NotImplementedException("Just kidding. Not yet.");
            }

            File.WriteAllBytes(Path.Combine(outDir, name + ".png"), png);
        }
    }
}
