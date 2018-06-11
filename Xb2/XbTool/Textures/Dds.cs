using System;
using System.IO;
using System.Text;

namespace XbTool.Textures
{
    public static class Dds
    {
        public static byte[] CreateHeader(Texture tex)
        {
            int bpp;
            uint flags = 0;
            string fourCC;
            int dxgiFormat = 0;

            switch (tex.Format)
            {
                case TextureFormat.BC1:
                    bpp = 4;
                    flags |= 4;
                    fourCC = "DXT1";
                    break;
                case TextureFormat.BC3:
                    bpp = 8;
                    flags |= 4;
                    fourCC = "DXT5";
                    break;
                case TextureFormat.BC4:
                    bpp = 8;
                    flags |= 4;
                    fourCC = "DX10";
                    dxgiFormat = 80;
                    break;
                case TextureFormat.BC7:
                    bpp = 8;
                    flags |= 4;
                    fourCC = "DX10";
                    dxgiFormat = 98;
                    break;
                case TextureFormat.BC6H_UF16:
                    bpp = 4;
                    flags |= 4;
                    fourCC = "DX10";
                    dxgiFormat = 95;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            int size = tex.Height * tex.Width * bpp / 8;

            var writer = new BinaryWriter(new MemoryStream());

            writer.Write(Encoding.ASCII.GetBytes("DDS "));
            writer.Write(124);

            uint dwFlags = 1 | 2 | 4 | 0x1000;
            dwFlags |= 0x80000;

            writer.Write(dwFlags);
            writer.Write(tex.Height);
            writer.Write(tex.Width);
            writer.Write(size);
            writer.Write(0);
            writer.Write(0);
            writer.Seek(44, SeekOrigin.Current);

            writer.Write(32);
            writer.Write(flags);
            writer.Write(Encoding.ASCII.GetBytes(fourCC));
            writer.Seek(20, SeekOrigin.Current);

            writer.Write(0x1000);
            writer.Seek(16, SeekOrigin.Current);

            if (fourCC == "DX10")
            {
                writer.Write(dxgiFormat);
                writer.Write(3);
                writer.Write(0);
                writer.Write(1);
                writer.Write(0);
            }

            writer.BaseStream.SetLength(writer.BaseStream.Position);
            return ((MemoryStream)writer.BaseStream).ToArray();
        }

        public static byte[] CreateDds(Texture tex)
        {
            var header = CreateHeader(tex);
            var bodyLength = BitConverter.ToInt32(header, 20);

            var file = new byte[header.Length + bodyLength];
            Array.Copy(header, file, header.Length);
            Array.Copy(tex.Data, 0, file, header.Length, Math.Min(bodyLength, tex.Data.Length));

            return file;
        }
    }
}
