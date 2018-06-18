using System;
using XbTool.Common.Textures;

namespace XbTool.Xb2.Textures
{
    public class LahdTexture : ITexture
    {
        public int Field0 { get; }
        public int Field4 { get; }
        public int Field8 { get; }
        public int FieldC { get; }
        public int Field10 { get; }
        public int Field14 { get; }
        public int Width { get; }
        public int Height { get; }
        public int Depth { get; }
        public int Field24 { get; }
        public TextureFormat Format { get; }
        public int Levels { get; }
        public int Field30 { get; }
        public int Field34 { get; }
        public byte[] Data { get; set; }

        public LahdTexture(byte[] texture)
        {
            int footer = texture.Length - 56;
            Data = texture;
            Field0 = BitConverter.ToInt32(texture, footer);
            Field4 = BitConverter.ToInt32(texture, footer + 4);
            Field8 = BitConverter.ToInt32(texture, footer + 8);
            FieldC = BitConverter.ToInt32(texture, footer + 0xC);
            Field10 = BitConverter.ToInt32(texture, footer + 0x10);
            Field14 = BitConverter.ToInt32(texture, footer + 0x14);
            Width = BitConverter.ToInt32(texture, footer + 0x18);
            Height = BitConverter.ToInt32(texture, footer + 0x1C);
            Depth = BitConverter.ToInt32(texture, footer + 0x20);
            Field24 = BitConverter.ToInt32(texture, footer + 0x24);
            Format = (TextureFormat)BitConverter.ToInt32(texture, footer + 0x28);
            Levels = BitConverter.ToInt32(texture, footer + 0x2C);
            Field30 = BitConverter.ToInt32(texture, footer + 0x30);
            Field34 = BitConverter.ToInt32(texture, footer + 0x34);
        }
    }
}
