using System;
using System.IO;

namespace XbTool.Textures
{
    public class WilayRead
    {
        public Texture[] Textures { get; }

        public WilayRead(byte[] file)
        {
            using (var stream = new MemoryStream(file))
            using (var reader = new BinaryReader(stream))
            {
                string magic = reader.ReadUTF8(4);
                if (magic != "LAHD")
                {
                    throw new NotSupportedException($"Can't read type {magic}");
                }

                int texturesOffset = BitConverter.ToInt32(file, 36);
                stream.Position = texturesOffset;

                int offset = reader.ReadInt32();
                int length = reader.ReadInt32();
                stream.Position = texturesOffset + offset;
                var offsets = new TextureOffset[length];
                Textures = new Texture[length];

                for (int i = 0; i < length; i++)
                {
                    offsets[i] = new TextureOffset
                    {
                        Field0 = reader.ReadInt32(),
                        Offset = reader.ReadInt32(),
                        Length = reader.ReadInt32()
                    };
                }

                for (int i = 0; i < length; i++)
                {
                    stream.Position = texturesOffset + offsets[i].Offset + offsets[i].Length - 56;

                    var texture = new byte[offsets[i].Length];
                    Array.Copy(file, texturesOffset + offsets[i].Offset, texture, 0, offsets[i].Length);
                    Textures[i] = new Texture(texture);
                }
            }
        }
    }

    public class TextureOffset
    {
        public int Field0 { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }

    public class Texture
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

        public Texture(byte[] texture)
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
