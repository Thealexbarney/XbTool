using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace XbTool.Textures
{
    public static class Decode
    {
        public static byte[] ToPng(this Texture texture)
        {
            byte[] image = texture.DecodeTexture();
            if (image == null) return null;
            return CreatePng(image, texture.Width, texture.Height);
        }

        public static Bitmap ToBitmap(this Texture texture)
        {
            byte[] image = texture.DecodeTexture();
            if (image == null) return null;
            return ToBitmap(image, texture.Width, texture.Height);
        }

        public static byte[] DecodeTexture(this Texture texture)
        {
            byte[] decoded = null;

            switch (texture.Format)
            {
                case TextureFormat.BC1:
                    Swizzle.Deswizzle(texture, 3);
                    decoded = Dxt.DecompressDxt1(texture);
                    break;
                case TextureFormat.BC3:
                    Swizzle.Deswizzle(texture, 4);
                    decoded = Dxt.DecompressDxt5(texture);
                    break;
                case TextureFormat.BC4:
                    Swizzle.Deswizzle(texture, 3);
                    break;
                case TextureFormat.BC6H_UF16:
                case TextureFormat.BC7:
                    Swizzle.Deswizzle(texture, 4);
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

            byte[] png = bitmap.ToPng();

            gchPixels.Free();
            return png;
        }

        public static Bitmap ToBitmap(byte[] image, int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            var boundsRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(boundsRect,
                ImageLockMode.WriteOnly,
                bitmap.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int bytes = bmpData.Stride * bitmap.Height;
            Marshal.Copy(image, 0, ptr, bytes);
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

        public static byte[] ToPng(this Bitmap bitmap)
        {
            byte[] png;
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                png = stream.ToArray();
            }

            return png;
        }
    }
}
