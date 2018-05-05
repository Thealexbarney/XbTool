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
    }
}
