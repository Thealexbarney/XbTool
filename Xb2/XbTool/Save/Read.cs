using System.Diagnostics;

namespace XbTool.Save
{
    public static class Read
    {
        public static SDataSave ReadSave(byte[] saveFile)
        {
            var save = new DataBuffer(saveFile, Game.XB2, 0);
            var saveData = new SDataSave(save);

            return saveData;
        }

        public static string ReadSizedUTF8(DataBuffer save, int maxLength)
        {
            int endPosition = save.Position + maxLength + 4;
            string result = save.ReadUTF8ZLen(maxLength);
            save.Position = endPosition;
            return result;
        }

        public static void ReadBitfieldArray(DataBuffer save, byte[] arrayOut, int count, int size)
        {
            Debug.Assert(size == 1 || size == 2 || size == 4);
            Debug.Assert(count * size % 8 == 0);
            int byteCount = count * size / 8;
            byte[] bytes = save.ReadBytes(byteCount);
            int iArr = 0;

            for (int i = 0; i < byteCount; i++)
            {
                byte b = bytes[i];
                switch (size)
                {
                    case 1:
                        for (int j = 0; j < 8; j++)
                        {
                            arrayOut[iArr++] = (byte) ((b >> j) & 1);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < 4; j++)
                        {
                            arrayOut[iArr++] = (byte)((b >> (j * 2)) & 3);
                        }
                        break;
                    case 4:
                        for (int j = 0; j < 2; j++)
                        {
                            arrayOut[iArr++] = (byte)((b >> (j * 4)) & 15);
                        }
                        break;
                }
            }
        }
    }
}
