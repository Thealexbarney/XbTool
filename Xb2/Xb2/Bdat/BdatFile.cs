using System;
using System.IO;

namespace Xb2.Bdat
{
    public class BdatFile
    {
        public string Name { get; }
        public int TableCount { get; }
        public int FileLength { get; }
        public BdatTable[] Tables { get; }

        public BdatFile(byte[] file, string filename)
        {
            if (file.Length <= 12) throw new InvalidDataException("File is too short");
            FileLength = BitConverter.ToInt32(file, 4);
            if (file.Length != FileLength) throw new InvalidDataException("Incorrect file length field");

            BdatTools.DecryptBdat(file);

            Name = filename;
            TableCount = BitConverter.ToInt32(file, 0);
            Tables = new BdatTable[TableCount];

            for (int i = 0; i < TableCount; i++)
            {
                int offset = BitConverter.ToInt32(file, 8 + 4 * i);
                Tables[i] = new BdatTable(file, offset);
            }
        }
    }
}
