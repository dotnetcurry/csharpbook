using System;

namespace BoxingInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            IPoint i1 = p;
            IPoint i2 = i1;
            i1.X = 1;
            Console.WriteLine($"p.X = {p.X}");
            Console.WriteLine($"i1.X = {i1.X}");
            Console.WriteLine($"i2.X = {i2.X}");
        }

    }
}
