using System;
using System.Collections.Generic;
using static System.Math;

namespace CSharp6
{
    class Program
    {
        static void Main(string[] args)
        {
            After();
            Before();
        }

        private static void After()
        {
            var dictionary = new Dictionary<int, string>
            {
                [1] = "One",
                [2] = "Two",
                [3] = "Three",
                [4] = "Four",
                [5] = "Five"
            };


            try
            {
                MethodAfter(null);
            }
            catch (ArgumentNullException e)
            { }


            var input = string.Empty;

            var length = input?.Length ?? 0;


            var number = 2;

            var sqrt = Sqrt(number);

            var output = $"Length of '{input}' is {input.Length} characters.";
        }

        private static void MethodAfter(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            // method implementation
        }

        private static void Before()
        {
            var dictionary = new Dictionary<int, string>
            {
                { 1, "One" },
                { 2, "Two" },
                { 3, "Three" },
                { 4, "Four" },
                { 5, "Five" }
            };


            try
            {
                MethodBefore(null);
            }
            catch (ArgumentNullException e)
            { }


            var input = string.Empty;

            int length;
            if (input == null)
            {
                length = 0;
            }
            else
            {
                length = input.Length;
            }


            var number = 2;

            var sqrt = Math.Sqrt(number);

            var output = String.Format("Length of '{0}' is {1} characters.", input, input.Length);
        }

        private static void MethodBefore(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            // method implementation
        }

    }
}
