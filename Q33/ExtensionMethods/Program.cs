using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtensionSyntax();
            RegularSyntax();
            InvokesInstanceMethod();
            ForcesExtensionMethod();
            Linq();
        }

        private static void ExtensionSyntax()
        {
            var input = "Hello, World!";
            var contains = input.ContainsIgnoreCase("world"); // true
        }

        private static void RegularSyntax()
        {
            var input = "Hello, World!";
            var contains = StringExtensions.ContainsIgnoreCase(input, "world"); // true
        }

        private static void InvokesInstanceMethod()
        {
            var input = "Hello, World!";
            var contains = input.Contains("world"); // false
        }

        private static void ForcesExtensionMethod()
        {
            var input = "Hello, World!";
            var contains = StringExtensions.Contains(input, "world"); // true
        }

        private static void Linq()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var countEven = list.Count(n => n % 2 == 0); // 2
        }
    }
}
