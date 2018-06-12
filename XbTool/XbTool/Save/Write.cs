using System;
using System.Diagnostics;
using System.Text;

namespace XbTool.Save
{
    public static class Write
    {
        public static byte[] WriteSave(SDataSave saveFile)
        {
            var saveBytes = new byte[0x1176A0];
            var save = new DataBuffer(saveBytes, Game.XB2, 0);
            saveFile.WriteSave(save);

            return saveBytes;
        }

        public static void WriteSizedUTF8(this DataBuffer save, string value, int maxLength)
        {

            int lengthPosition = save.Position + maxLength;
            int length = Encoding.UTF8.GetByteCount(value);
            if (length > maxLength)
                throw new ArgumentOutOfRangeException(nameof(value),
                    $"String must be a maximum of {maxLength} bytes. Actual: {length}");

            save.WriteUTF8(value);
            save.Position = lengthPosition;
            save.WriteInt32(length);
        }

        public static void WriteBitfieldArray(DataBuffer save, byte[] arrayIn, int count, int size)
        {
            Debug.Assert(size == 1 || size == 2 || size == 4);
            Debug.Assert(count * size % 8 == 0);
            int byteCount = count * size / 8;
            int iArr = 0;

            for (int i = 0; i < byteCount; i++)
            {
                byte b = 0;
                switch (size)
                {
                    case 1:
                        for (int j = 0; j < 8; j++)
                        {
                            b |= (byte)((arrayIn[iArr++] & 1) << j);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < 4; j++)
                        {
                            b |= (byte)((arrayIn[iArr++] & 3) << (j * 2));
                        }
                        break;
                    case 4:
                        for (int j = 0; j < 2; j++)
                        {
                            b |= (byte)((arrayIn[iArr++] & 15) << (j * 4));
                        }
                        break;
                }
                save.WriteUInt8(b);
            }
        }
    }
}
