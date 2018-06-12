namespace XbTool.Textures
{
    public interface ITexture
    {
        int Width { get; }
        int Height { get; }
        byte[] Data { get; set; }
        TextureFormat Format { get; }
    }
}