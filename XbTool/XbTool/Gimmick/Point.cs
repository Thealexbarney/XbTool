namespace XbTool.Gimmick
{
    public class Point3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Point3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3(DataBuffer data)
        {
            X = data.ReadSingle();
            Y = data.ReadSingle();
            Z = data.ReadSingle();
        }
    }

    public class Point2
    {
        public float X { get; }
        public float Y { get; }

        public Point2(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
