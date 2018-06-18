using System;
using XbTool.Common;
using XbTool.Common.Textures;

namespace XbTool.Xbx.Textures
{
    public class MtxtTexture : ITexture
    {
        public int Swizzle { get; set; }
        public int Dimension { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Unk { get; set; }
        public int Type { get; set; }
        public int Datasize { get; set; }
        public int AaMode { get; set; }
        public int TileMode { get; set; }
        public int Unk2 { get; set; }
        public int Alignment { get; set; }
        public int Pitch { get; set; }

        public TextureFormat Format { get; set; }
        public byte[] Data { get; set; }

        public MtxtTexture(DataBuffer data)
        {
            Swizzle = data.ReadInt32(data.Length - 0x70, true);
            Dimension = data.ReadInt32();
            Width = data.ReadInt32();
            Height = data.ReadInt32();
            Depth = data.ReadInt32();
            Unk = data.ReadInt32();
            Type = data.ReadInt32();
            Datasize = data.ReadInt32();
            AaMode = data.ReadInt32();
            TileMode = data.ReadInt32();
            Unk2 = data.ReadInt32();
            Alignment = data.ReadInt32();
            Pitch = data.ReadInt32();
            Data = data.ReadBytes(0, Datasize);
            switch (Type)
            {
                case 49:
                    Format = TextureFormat.BC1;
                    break;
                default:
                    throw new NotImplementedException($"Texture format {Type}");
            }
        }
    }
}
