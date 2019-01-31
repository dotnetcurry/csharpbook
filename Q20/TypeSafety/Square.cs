namespace TypeSafety
{
    public class Square : IGeometricShape
    {
        public double Side { get; set; }

        public double Circumference => 4 * Side;

        public double Area => Side * Side;
    }

}
