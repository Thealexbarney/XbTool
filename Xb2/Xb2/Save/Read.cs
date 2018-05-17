namespace Xb2.Save
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
            int length = save.ReadInt32(save.Position + maxLength);
            string result = save.ReadUTF8(length);
            save.Position = endPosition;
            return result;
        }
    }
}
