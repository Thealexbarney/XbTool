using System;

namespace XbTool.Textures
{
    public static class Swizzle
    {
        public static void Deswizzle(Texture texture, int bppPower)
        {
            int bpp = 1 << bppPower;

            int len = texture.Data.Length;
            int originWidth = (texture.Width + 3) / 4;
            int originHeight = (texture.Height + 3) / 4;

            int xb = CountZeros(Pow2RoundUp(originWidth));
            int yb = CountZeros(Pow2RoundUp(originHeight));

            int hh = Pow2RoundUp(originHeight) >> 1;

            if (!IsPow2(originHeight) && originHeight <= hh + hh / 3 && yb > 3)
            {
                yb--;
            }

            var result = new byte[len];
            int width = RoundSize(originWidth, 64 >> bppPower);
            int xBase = 4 - bppPower;
            int posOut = 0;

            for (int y = 0; y < originHeight; y++)
            {
                for (int x = 0; x < originWidth; x++)
                {
                    int pos = GetAddr(x, y, xb, yb, width, xBase) * bpp;

                    if (posOut + bpp <= len && pos + bpp <= len)
                    {
                        Array.Copy(texture.Data, pos, result, posOut, bpp);
                    }

                    posOut += bpp;
                }
            }

            texture.Data = result;
        }

        private static int RoundSize(int size, int pad)
        {
            int mask = pad - 1;
            if ((size & mask) != 0)
            {
                size &= ~mask;
                size += pad;
            }

            return size;
        }

        private static int Pow2RoundUp(int value)
        {
            value--;

            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;

            return value + 1;
        }

        private static int CountZeros(int value)
        {
            for (int i = 0; i < 32; i++)
            {
                if ((value & (1 << i)) != 0)
                {
                    return i;
                }
            }

            return 32;
        }

        private static bool IsPow2(int value)
        {
            return (value & (value - 1)) == 0;
        }

        private static int GetAddr(int x, int y, int xb, int yb, int width, int xBase)
        {
            int xCnt = xBase;
            int yCnt = 1;
            int xUsed = 0;
            int yUsed = 0;
            int address = 0;

            while (xUsed < xBase + 2 && xUsed + xCnt < xb)
            {
                int xMask = (1 << xCnt) - 1;
                int yMask = (1 << yCnt) - 1;

                address |= (x & xMask) << xUsed + yUsed;
                address |= (y & yMask) << xUsed + yUsed + xCnt;

                x >>= xCnt;
                y >>= yCnt;

                xUsed += xCnt;
                yUsed += yCnt;

                xCnt = Math.Max(Math.Min(xb - xUsed, 1), 0);
                yCnt = Math.Max(Math.Min(yb - yUsed, yCnt << 1), 0);
            }

            address |= (x + y * (width >> xUsed)) << (xUsed + yUsed);
            return address;
        }
    }
}
