using System;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();
            Console.ReadLine();
        }

        static void Method1()
        {
            var a = new Point();
            Console.WriteLine($"Method1 - start: x = {a.x}, y = {a.y}");
            Method2(a);
            Console.WriteLine($"Method1 - end: x = {a.x}, y = {a.y}");
        }

        static void Method2(Point a)
        {
            Console.WriteLine($"Method2 - start: x = {a.x}, y = {a.y}");
            a.x = 1;
            Console.WriteLine($"Method2 - end: x = {a.x}, y = {a.y}");
        }
    }
}
