using System;
using System.IO;
using Ionic.Zlib;

namespace XbTool.Xb2.Textures
{
    public class WilayRead
    {
        public LahdTexture[] Textures { get; }

        public WilayRead(byte[] file)
        {
            var stream = new MemoryStream(file);
            var reader = new BinaryReader(stream);

            string magic = reader.ReadUTF8(4);

            if (magic == "xbc1")
            {
                reader.BaseStream.Position += 4;
                int uncompressedSize = reader.ReadInt32();
                stream.Position = 0x30;

                file = new byte[uncompressedSize];
                var uncompressedData = new MemoryStream(file);

                using (var deflate = new ZlibStream(stream, CompressionMode.Decompress, true))
                {
                    deflate.CopyTo(uncompressedData, uncompressedSize);
                }

                uncompressedData.Position = 0;
                stream = uncompressedData;
                reader = new BinaryReader(stream);
            }
            else if (magic != "LAHD")
            {
                throw new NotSupportedException($"Can't read type {magic}");
            }

            int texturesOffset = BitConverter.ToInt32(file, 36);
            stream.Position = texturesOffset;

            int offset = reader.ReadInt32();
            int length = reader.ReadInt32();
            stream.Position = texturesOffset + offset;
            var offsets = new TextureOffset[length];
            Textures = new LahdTexture[length];

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
                Textures[i] = new LahdTexture(texture);
            }
        }
    }

    public class TextureOffset
    {
        public int Field0 { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
