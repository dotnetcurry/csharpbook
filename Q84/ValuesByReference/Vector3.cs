namespace ValuesByReference
{
    public struct Vector3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Scale(int factor)
        {
            X *= factor;
            Y *= factor;
            Z *= factor;
        }

        // other struct members omitted for brevity

        private static readonly Vector3 zero = new Vector3(0, 0, 0);
        public static ref readonly Vector3 Zero => ref zero;
    }
}
