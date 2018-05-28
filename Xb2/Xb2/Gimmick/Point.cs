namespace Xb2.Gimmick
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
