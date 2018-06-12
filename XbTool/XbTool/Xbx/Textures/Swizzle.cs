// ReSharper disable InconsistentNaming
using System;

namespace XbTool.Xbx.Textures
{
    public static class Swizzle
    {
        /* Credits:
          -AddrLib: actual code
          -Exzap: modifying code to apply to Wii U textures
          -AboodXD: porting, code improvements and cleaning up
        */

        private const uint m_banks = 4;
        private const uint m_banksBitcount = 2;
        private const uint m_pipes = 2;
        private const uint m_pipesBitcount = 1;
        private const uint m_pipeInterleaveBytes = 256;
        private const uint m_pipeInterleaveBytesBitcount = 8;
        private const uint m_rowSize = 2048;
        private const uint m_swapSize = 256;
        private const uint m_splitSize = 2048;


        static uint MicroTilePixels = 8 * 8;

        private static byte[] formatHwInfo =
        {
            0x00, 0x00, 0x00, 0x01, 0x08, 0x03, 0x00, 0x01, 0x08, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
            0x00, 0x00, 0x00, 0x01, 0x10, 0x07, 0x00, 0x00, 0x10, 0x03, 0x00, 0x01, 0x10, 0x03, 0x00, 0x01,
            0x10, 0x0B, 0x00, 0x01, 0x10, 0x01, 0x00, 0x01, 0x10, 0x03, 0x00, 0x01, 0x10, 0x03, 0x00, 0x01,
            0x10, 0x03, 0x00, 0x01, 0x20, 0x03, 0x00, 0x00, 0x20, 0x07, 0x00, 0x00, 0x20, 0x03, 0x00, 0x00,
            0x20, 0x03, 0x00, 0x01, 0x20, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x03, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x20, 0x03, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
            0x00, 0x00, 0x00, 0x01, 0x20, 0x0B, 0x00, 0x01, 0x20, 0x0B, 0x00, 0x01, 0x20, 0x0B, 0x00, 0x01,
            0x40, 0x05, 0x00, 0x00, 0x40, 0x03, 0x00, 0x00, 0x40, 0x03, 0x00, 0x00, 0x40, 0x03, 0x00, 0x00,
            0x40, 0x03, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x80, 0x03, 0x00, 0x00, 0x80, 0x03, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x10, 0x01, 0x00, 0x00,
            0x10, 0x01, 0x00, 0x00, 0x20, 0x01, 0x00, 0x00, 0x20, 0x01, 0x00, 0x00, 0x20, 0x01, 0x00, 0x00,
            0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x60, 0x01, 0x00, 0x00,
            0x60, 0x01, 0x00, 0x00, 0x40, 0x01, 0x00, 0x01, 0x80, 0x01, 0x00, 0x01, 0x80, 0x01, 0x00, 0x01,
            0x40, 0x01, 0x00, 0x01, 0x80, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
        };


        public static uint surfaceGetBitsPerPixel(uint surfaceFormat)
        {
            uint hwFormat = surfaceFormat & 0x3F;
            uint bpp = formatHwInfo[hwFormat * 4 + 0];
            return bpp;
        }


        public static uint computeSurfaceThickness(uint tileMode)
        {
            uint thickness = 1;

            if (tileMode == 3 || tileMode == 7 || tileMode == 11 || tileMode == 13 || tileMode == 15)
                thickness = 4;

            else if (tileMode == 16 || tileMode == 17)
                thickness = 8;

            return thickness;
        }


        public static uint computePixelIndexWithinMicroTile(uint x, uint y, uint bpp, uint tileMode)
        {
            uint z = 0;
            uint thickness;
            uint pixelBit8;
            uint pixelBit7;
            uint pixelBit6;
            uint pixelBit5;
            uint pixelBit4;
            uint pixelBit3;
            uint pixelBit2;
            uint pixelBit1;
            uint pixelBit0;
            pixelBit6 = 0;
            pixelBit7 = 0;
            pixelBit8 = 0;
            thickness = computeSurfaceThickness(tileMode);

            if (bpp == 0x08)
            {
                pixelBit0 = x & 1;
                pixelBit1 = (x & 2) >> 1;
                pixelBit2 = (x & 4) >> 2;
                pixelBit3 = (y & 2) >> 1;
                pixelBit4 = y & 1;
                pixelBit5 = (y & 4) >> 2;
            }

            else if (bpp == 0x10)
            {
                pixelBit0 = x & 1;
                pixelBit1 = (x & 2) >> 1;
                pixelBit2 = (x & 4) >> 2;
                pixelBit3 = y & 1;
                pixelBit4 = (y & 2) >> 1;
                pixelBit5 = (y & 4) >> 2;
            }

            else if (bpp == 0x20 || bpp == 0x60)
            {
                pixelBit0 = x & 1;
                pixelBit1 = (x & 2) >> 1;
                pixelBit2 = y & 1;
                pixelBit3 = (x & 4) >> 2;
                pixelBit4 = (y & 2) >> 1;
                pixelBit5 = (y & 4) >> 2;
            }

            else if (bpp == 0x40)
            {
                pixelBit0 = x & 1;
                pixelBit1 = y & 1;
                pixelBit2 = (x & 2) >> 1;
                pixelBit3 = (x & 4) >> 2;
                pixelBit4 = (y & 2) >> 1;
                pixelBit5 = (y & 4) >> 2;
            }

            else if (bpp == 0x80)
            {
                pixelBit0 = y & 1;
                pixelBit1 = x & 1;
                pixelBit2 = (x & 2) >> 1;
                pixelBit3 = (x & 4) >> 2;
                pixelBit4 = (y & 2) >> 1;
                pixelBit5 = (y & 4) >> 2;
            }

            else
            {
                pixelBit0 = x & 1;
                pixelBit1 = (x & 2) >> 1;
                pixelBit2 = y & 1;
                pixelBit3 = (x & 4) >> 2;
                pixelBit4 = (y & 2) >> 1;
                pixelBit5 = (y & 4) >> 2;
            }

            if (thickness > 1)
            {
                pixelBit6 = z & 1;
                pixelBit7 = (z & 2) >> 1;
            }

            if (thickness == 8)
                pixelBit8 = (z & 4) >> 2;

            return ((pixelBit8 << 8) | (pixelBit7 << 7) | (pixelBit6 << 6) |
                32 * pixelBit5 | 16 * pixelBit4 | 8 * pixelBit3 |
                4 * pixelBit2 | pixelBit0 | 2 * pixelBit1);
        }


        public static uint computePipeFromCoordWoRotation(uint x, uint y)
        {
            // hardcoded to assume 2 pipes
            uint pipe = ((y >> 3) ^ (x >> 3)) & 1;
            return pipe;
        }


        public static uint computeBankFromCoordWoRotation(uint x, uint y)
        {
            uint numPipes = m_pipes;
            uint numBanks = m_banks;
            uint bankBit0;
            uint bankBit0a;
            uint bank = 0;

            if (numBanks == 4)
            {
                bankBit0 = ((y / (16 * numPipes)) ^ (x >> 3)) & 1;
                bank = bankBit0 | 2 * (((y / (8 * numPipes)) ^ (x >> 4)) & 1);
            }

            else if (numBanks == 8)
            {
                bankBit0a = ((y / (32 * numPipes)) ^ (x >> 3)) & 1;
                bank = (bankBit0a | 2 * (((y / (32 * numPipes)) ^ (y / (16 * numPipes) ^ (x >> 4))) & 1) |
                    4 * (((y / (8 * numPipes)) ^ (x >> 5)) & 1));
            }

            return bank;
        }


        public static uint isThickMacroTiled(uint tileMode)
        {
            uint thickMacroTiled = 0;

            if (tileMode == 7 || tileMode == 11 || tileMode == 13 || tileMode == 15)
                thickMacroTiled = 1;

            return thickMacroTiled;
        }


        public static uint isBankSwappedTileMode(uint tileMode)
        {
            uint bankSwapped = 0;

            if (tileMode == 8 || tileMode == 9 || tileMode == 10 || tileMode == 11 || tileMode == 14 || tileMode == 15)
                bankSwapped = 1;

            return bankSwapped;
        }


        public static uint computeMacroTileAspectRatio(uint tileMode)
        {
            uint ratio = 1;

            if (tileMode == 5 || tileMode == 9)
                ratio = 2;

            else if (tileMode == 6 || tileMode == 10)
                ratio = 4;

            return ratio;
        }


        public static uint computeSurfaceBankSwappedWidth(uint tileMode, uint bpp, uint pitch)
        {
            if (isBankSwappedTileMode(tileMode) == 0)
                return 0;

            uint numSamples = 1;
            uint numBanks = m_banks;
            uint numPipes = m_pipes;
            uint swapSize = m_swapSize;
            uint rowSize = m_rowSize;
            uint splitSize = m_splitSize;
            uint groupSize = m_pipeInterleaveBytes;
            uint bytesPerSample = 8 * bpp;

            uint samplesPerTile = splitSize / bytesPerSample;
            uint slicesPerTile = Math.Max(1, numSamples / samplesPerTile);

            if (isThickMacroTiled(tileMode) != 0)
                numSamples = 4;

            uint bytesPerTileSlice = numSamples * bytesPerSample / slicesPerTile;

            uint factor = computeMacroTileAspectRatio(tileMode);
            uint swapTiles = Math.Max(1, (swapSize >> 1) / bpp);

            uint swapWidth = swapTiles * 8 * numBanks;
            uint heightBytes = numSamples * factor * numPipes * bpp / slicesPerTile;
            uint swapMax = numPipes * numBanks * rowSize / heightBytes;
            uint swapMin = groupSize * 8 * numBanks / bytesPerTileSlice;

            uint bankSwapWidth = Math.Max(swapMax, Math.Max(swapMin, swapWidth));

            while (bankSwapWidth >= (2 * pitch))
                bankSwapWidth >>= 1;

            return bankSwapWidth;
        }


        public static ulong AddrLib_computeSurfaceAddrFromCoordLinear(uint x, uint y, uint bpp, uint pitch)
        {
            uint rowOffset = y * pitch;
            uint pixOffset = x;

            uint addr = (rowOffset + pixOffset) * bpp;
            addr /= 8;

            return addr;
        }


        public static ulong AddrLib_computeSurfaceAddrFromCoordMicroTiled(uint x, uint y, uint bpp, uint pitch, uint tileMode)
        {
            ulong microTileThickness = 1;

            if (tileMode == 3)
                microTileThickness = 4;

            ulong microTileBytes = (MicroTilePixels * microTileThickness * bpp + 7) / 8;
            ulong microTilesPerRow = pitch >> 3;
            ulong microTileIndexX = x >> 3;
            ulong microTileIndexY = y >> 3;

            ulong microTileOffset = microTileBytes * (microTileIndexX + microTileIndexY * microTilesPerRow);

            ulong pixelIndex = computePixelIndexWithinMicroTile(x, y, bpp, tileMode);

            ulong pixelOffset = bpp * pixelIndex;

            pixelOffset >>= 3;

            return pixelOffset + microTileOffset;
        }


        public static ulong AddrLib_computeSurfaceAddrFromCoordMacroTiled(uint x, uint y, uint bpp, uint pitch, uint height, uint tileMode, uint pipeSwizzle, uint bankSwizzle)
        {
            ulong sampleSlice, numSamples;

            uint numPipes = m_pipes;
            uint numBanks = m_banks;
            uint numGroupBits = m_pipeInterleaveBytesBitcount;
            uint numPipeBits = m_pipesBitcount;
            uint numBankBits = m_banksBitcount;

            uint microTileThickness = computeSurfaceThickness(tileMode);

            ulong microTileBits = bpp * (microTileThickness * MicroTilePixels);
            ulong microTileBytes = (microTileBits + 7) / 8;

            ulong pixelIndex = computePixelIndexWithinMicroTile(x, y, bpp, tileMode);

            ulong pixelOffset = bpp * pixelIndex;

            ulong elemOffset = pixelOffset;

            ulong bytesPerSample = microTileBytes;
            if (microTileBytes <= m_splitSize)
            {
                numSamples = 1;
                sampleSlice = 0;
            }

            else
            {
                ulong samplesPerSlice = m_splitSize / bytesPerSample;
                ulong numSampleSplits = Math.Max(1, 1 / samplesPerSlice);
                numSamples = samplesPerSlice;
                sampleSlice = elemOffset / (microTileBits / numSampleSplits);
                elemOffset %= microTileBits / numSampleSplits;
            }
            elemOffset += 7;
            elemOffset /= 8;

            ulong pipe = computePipeFromCoordWoRotation(x, y);
            ulong bank = computeBankFromCoordWoRotation(x, y);

            ulong bankPipe = pipe + numPipes * bank;

            ulong swizzle_ = pipeSwizzle + numPipes * bankSwizzle;

            bankPipe ^= numPipes * sampleSlice * ((numBanks >> 1) + 1) ^ swizzle_;
            bankPipe %= numPipes * numBanks;
            pipe = bankPipe % numPipes;
            bank = bankPipe / numPipes;

            ulong sliceBytes = (height * pitch * microTileThickness * bpp * numSamples + 7) / 8;
            ulong sliceOffset = sliceBytes * (sampleSlice / microTileThickness);

            ulong macroTilePitch = 8 * m_banks;
            ulong macroTileHeight = 8 * m_pipes;

            if (tileMode == 5 || tileMode == 9)
            { // GX2_TILE_MODE_2D_TILED_THIN4 and GX2_TILE_MODE_2B_TILED_THIN2
                macroTilePitch >>= 1;
                macroTileHeight *= 2;
            }

            else if (tileMode == 6 || tileMode == 10)
            { // GX2_TILE_MODE_2D_TILED_THIN4 and GX2_TILE_MODE_2B_TILED_THIN4
                macroTilePitch >>= 2;
                macroTileHeight *= 4;
            }

            ulong macroTilesPerRow = pitch / macroTilePitch;
            ulong macroTileBytes = (numSamples * microTileThickness * bpp * macroTileHeight * macroTilePitch + 7) / 8;
            ulong macroTileIndexX = x / macroTilePitch;
            ulong macroTileIndexY = y / macroTileHeight;
            ulong macroTileOffset = (macroTileIndexX + macroTilesPerRow * macroTileIndexY) * macroTileBytes;

            if (tileMode == 8 || tileMode == 9 || tileMode == 10 || tileMode == 11 || tileMode == 14 || tileMode == 15)
            {
                uint[] bankSwapOrder = { 0, 1, 3, 2, 6, 7, 5, 4, 0, 0 };
                ulong bankSwapWidth = computeSurfaceBankSwappedWidth(tileMode, bpp, pitch);
                ulong swapIndex = macroTilePitch * macroTileIndexX / bankSwapWidth;
                bank ^= bankSwapOrder[swapIndex & (m_banks - 1)];
            }

            ulong groupMask = (ulong)((1 << (int)numGroupBits) - 1);

            ulong numSwizzleBits = (numBankBits + numPipeBits);

            ulong totalOffset = (elemOffset + ((macroTileOffset + sliceOffset) >> (int)numSwizzleBits));

            ulong offsetHigh = (totalOffset & ~groupMask) << (int)numSwizzleBits;
            ulong offsetLow = groupMask & totalOffset;

            ulong pipeBits = pipe << (int)numGroupBits;
            ulong bankBits = bank << (int)(numPipeBits + numGroupBits);

            return bankBits | pipeBits | offsetLow | offsetHigh;
        }

        public static void Deswizzle(Texture texture, int bppPower)
        {
            uint bpp = (uint) (1 << bppPower);
            uint bypp = bpp / 8;
            uint pipeSwizzle = (uint)((texture.Swizzle >> 8) & 1);
            uint bankSwizzle = (uint)((texture.Swizzle >> 9) & 3);


            int len = texture.Data.Length;
            uint originWidth = (uint) ((texture.Width + 3) / 4);
            int originHeight = (texture.Height + 3) / 4;

            var result = new byte[len];

            uint posOut = 0;

            for (uint y = 0; y < originHeight; y++)
            {
                for (uint x = 0; x < originWidth; x++)
                {
                    uint pos = (uint)AddrLib_computeSurfaceAddrFromCoordMacroTiled(x, y, bpp, (uint)texture.Pitch, (uint)texture.Height,
                        (uint)texture.TileMode, pipeSwizzle, bankSwizzle);


                    if (posOut + bypp <= len && pos + bypp <= len)
                    {
                        Array.Copy(texture.Data, pos, result, posOut, bypp);
                    }

                    posOut += bypp;
                }
            }

            texture.Data = result;
        }
    }
}
