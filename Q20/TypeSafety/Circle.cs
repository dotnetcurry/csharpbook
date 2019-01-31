using System;

namespace TypeSafety
{
    public class Circle : IGeometricShape
    {
        public double Radius { get; set; }

        public double Circumference => 2 * Math.PI * Radius;

        public double Area => Math.PI * Radius * Radius;
    }

}
