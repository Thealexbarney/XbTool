using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Xb2.Textures
{
    public static class Decode
    {
        public static byte[] ToPng(this Texture texture)
        {
            byte[] image = DecodeTexture(texture);
            if (image == null) return null;
            return CreatePng(image, texture.Width, texture.Height);
        }

        public static byte[] DecodeTexture(Texture texture)
        {
            byte[] decoded = null;

            switch (texture.Format)
            {
                case TextureFormat.BC1:
                    Swizzle.Deswizzle(texture,3);
                    decoded = Dxt.DecompressDxt1(texture);
                    break;
                case TextureFormat.BC3:
                    Swizzle.Deswizzle(texture, 4);
                    decoded = Dxt.DecompressDxt5(texture);
                    break;
                case TextureFormat.BC4:
                case TextureFormat.BC6H_UF16:
                case TextureFormat.BC7:
                    break;
            }

            return decoded;
        }

        public static byte[] CreatePng(byte[] image, int width, int height)
        {
            GCHandle gchPixels = GCHandle.Alloc(image, GCHandleType.Pinned);

            var bitmap = new Bitmap(width, height, width * sizeof(uint),
                PixelFormat.Format32bppArgb,
                gchPixels.AddrOfPinnedObject());

            byte[] png;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                png = stream.ToArray();
            }

            gchPixels.Free();
            return png;
        }
    }
}
