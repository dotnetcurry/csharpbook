using System;

namespace BoxingStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            object o = p;
            p.X = 1;
            Console.WriteLine($"p.X = {p.X}");
            Console.WriteLine($"o.X = {((Point)o).X}");
        }
    }
}
