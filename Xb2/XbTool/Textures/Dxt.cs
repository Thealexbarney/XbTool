using System;

namespace XbTool.Textures
{
    public static class Dxt
    {
        public static byte[] DecompressDxt1(Texture texture)
        {
            var image = new byte[texture.Height * texture.Width * 4];
            var widthBlocks = texture.Width / 4;
            var heightBlocks = texture.Height / 4;
            int pos = 0;

            for (int y = 0; y < heightBlocks; y++)
            {
                for (int x = 0; x < widthBlocks; x++)
                {
                    DecompressDxt1Block(texture, pos, image, x * 4, y * 4);
                    pos += 8;
                }
            }

            return image;
        }

        public static void DecompressDxt1Block(Texture texture, int pos, byte[] output, int xPos, int yPos)
        {
            if (pos >= texture.Data.Length) return;
            Color[] c = new Color[4];

            var color0 = BitConverter.ToUInt16(texture.Data, pos);
            var color1 = BitConverter.ToUInt16(texture.Data, pos + 2);
            var mask = BitConverter.ToUInt32(texture.Data, pos + 4);

            Color(color0, ref c[0]);
            Color(color1, ref c[1]);
            c[0].A = 255;
            c[1].A = 255;

            if (color0 > color1)
            {
                c[2].R = (byte)((2 * c[0].R + c[1].R) / 3);
                c[2].G = (byte)((2 * c[0].G + c[1].G) / 3);
                c[2].B = (byte)((2 * c[0].B + c[1].B) / 3);
                c[2].A = 255;

                c[3].R = (byte)((c[0].R + 2 * c[1].R) / 3);
                c[3].G = (byte)((c[0].G + 2 * c[1].G) / 3);
                c[3].B = (byte)((c[0].B + 2 * c[1].B) / 3);
                c[3].A = 255;
            }
            else
            {
                c[2].R = (byte)((c[0].R + c[1].R) / 2);
                c[2].G = (byte)((c[0].G + c[1].G) / 2);
                c[2].B = (byte)((c[0].B + c[1].B) / 2);
                c[2].A = 255;

                c[3].R = 0;
                c[3].G = 0;
                c[3].B = 0;
                c[3].A = 0;
            }

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    var index = mask & 3;
                    mask >>= 2;
                    var col = c[index];

                    var x2 = xPos + x;
                    var y2 = yPos + y;

                    var offset = (x2 + y2 * texture.Width) * 4;
                    output[offset] = col.B;
                    output[offset + 1] = col.G;
                    output[offset + 2] = col.R;
                    output[offset + 3] = col.A;
                }
            }
        }

        public static byte[] DecompressDxt5(Texture texture)
        {
            var image = new byte[texture.Height * texture.Width * 4];
            var widthBlocks = texture.Width / 4;
            var heightBlocks = texture.Height / 4;
            int pos = 0;

            for (int y = 0; y < heightBlocks; y++)
            {
                for (int x = 0; x < widthBlocks; x++)
                {
                    DecompressDxt5Block(texture, pos, image, x * 4, y * 4);
                    pos += 16;
                }
            }

            return image;
        }

        public static void DecompressDxt5Block(Texture texture, int pos, byte[] output, int xPos, int yPos)
        {
            if (pos >= texture.Data.Length) return;
            Color[] c = new Color[4];
            byte[] alpha = new byte[8];

            var alpha0 = texture.Data[pos];
            var alpha1 = texture.Data[pos + 1];
            var alphaMask = BitConverter.ToUInt64(texture.Data, pos) >> 16;

            var color0 = BitConverter.ToUInt16(texture.Data, pos + 8);
            var color1 = BitConverter.ToUInt16(texture.Data, pos + 10);
            var mask = BitConverter.ToUInt32(texture.Data, pos + 12);

            alpha[0] = alpha0;
            alpha[1] = alpha1;
            if (alpha[0] > alpha[1])
            {
                alpha[2] = (byte)((6 * alpha[0] + 1 * alpha[1] + 3) / 7);
                alpha[3] = (byte)((5 * alpha[0] + 2 * alpha[1] + 3) / 7);
                alpha[4] = (byte)((4 * alpha[0] + 3 * alpha[1] + 3) / 7);
                alpha[5] = (byte)((3 * alpha[0] + 4 * alpha[1] + 3) / 7);
                alpha[6] = (byte)((2 * alpha[0] + 5 * alpha[1] + 3) / 7);
                alpha[7] = (byte)((1 * alpha[0] + 6 * alpha[1] + 3) / 7);
            }
            else
            {
                alpha[2] = (byte)((4 * alpha[0] + 1 * alpha[1] + 2) / 5);
                alpha[3] = (byte)((3 * alpha[0] + 2 * alpha[1] + 2) / 5);
                alpha[4] = (byte)((2 * alpha[0] + 3 * alpha[1] + 2) / 5);
                alpha[5] = (byte)((1 * alpha[0] + 4 * alpha[1] + 2) / 5);
                alpha[6] = 0;
                alpha[7] = 255;
            }

            Color(color0, ref c[0]);
            Color(color1, ref c[1]);

            c[2].R = (byte)((2 * c[0].R + c[1].R) / 3);
            c[2].G = (byte)((2 * c[0].G + c[1].G) / 3);
            c[2].B = (byte)((2 * c[0].B + c[1].B) / 3);

            c[3].R = (byte)((c[0].R + 2 * c[1].R) / 3);
            c[3].G = (byte)((c[0].G + 2 * c[1].G) / 3);
            c[3].B = (byte)((c[0].B + 2 * c[1].B) / 3);

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    var index = mask & 3;
                    mask >>= 2;
                    var alphaIndex = alphaMask & 7;
                    alphaMask >>= 3;

                    var col = c[index];

                    var x2 = xPos + x;
                    var y2 = yPos + y;

                    var offset = (x2 + y2 * texture.Width) * 4;
                    output[offset] = col.B;
                    output[offset + 1] = col.G;
                    output[offset + 2] = col.R;
                    output[offset + 3] = alpha[alphaIndex];
                }
            }
        }

        public static void Color(ushort color, ref Color c)
        {
            c.R = (byte)((color >> 11) & 0x1f);
            c.G = (byte)((color >> 5) & 0x3f);
            c.B = (byte)(color & 0x1f);

            c.R = (byte)((c.R << 3) | (c.R >> 2));
            c.G = (byte)((c.G << 2) | (c.G >> 4));
            c.B = (byte)((c.B << 3) | (c.B >> 2));
        }
    }

    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;
    }
}
