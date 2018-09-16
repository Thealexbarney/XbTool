using System.IO;
using Ionic.Zlib;

namespace XbTool.Save
{
    public static class Compression
    {
        public static byte[] DecompressSave(byte[] input)
        {
            var output = new MemoryStream();
            var compStream = new MemoryStream(input, 0x10, input.Length - 0x10);

            using (var deflate = new ZlibStream(compStream, CompressionMode.Decompress, true))
            {
                deflate.CopyTo(output);
            }

            return output.ToArray();
        }
    }
}
