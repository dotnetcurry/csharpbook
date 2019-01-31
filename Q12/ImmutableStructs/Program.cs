using System;

namespace ImmutableStructs
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();

            // Point nullValue = null; // will not compile
            Point defaultValue = default(Point); // will set all fields to default value
            var x = defaultValue.X; // will set x to 0
            var y = defaultValue.Y; // will set y to 0
            Console.WriteLine($"x = {x}, y = {y}");

            defaultValue = new Point(); // equivalent to default(Point)
            Console.WriteLine($"x = {defaultValue.X}, y = {defaultValue.Y}");

            Console.ReadLine();
        }

        static void Method1()
        {
            var a = new Point();
            Console.WriteLine($"Method1 - start: x = {a.X}, y = {a.Y}");
            a = Method2(a);
            Console.WriteLine($"Method1 - end: x = {a.X}, y = {a.Y}");
        }

        static Point Method2(Point a)
        {
            Console.WriteLine($"Method2 - start: x = {a.X}, y = {a.Y}");
            // a.X = 1; // will not compile
            a = new Point(1, a.Y);
            Console.WriteLine($"Method2 - end: x = {a.X}, y = {a.Y}");
            return a;
        }

    }
}
