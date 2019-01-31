using System.Collections.Generic;
using System.Linq;

namespace ImplementGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            NonGeneric();
            GenericExplicit();
            GenericImplicit();
            GenericDouble();
            GenericString();
            IntComparer();
            GenericComparerExplicit();
            GenericComparerFactory();
            GenericComparerDouble();
        }

        public static void NonGeneric()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var different = CountDifferentInts(numbers, 0); // = 4
        }

        public static void GenericExplicit()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var different = CountDifferentGeneric<int>(numbers, 0); // = 4
        }

        public static void GenericImplicit()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var different = CountDifferentGeneric(numbers, 0); // = 4
        }

        public static void GenericDouble()
        {
            var numbers = new[] { -1.5, 0, 1.5, 0, -2.5, 0, 2.5 };
            var different = CountDifferentGeneric(numbers, 0d); // = 4
        }

        public static void GenericString()
        {
            var strings = new[] { "a", "", "b", "", "c", "", "d" };
            var different = CountDifferentGeneric(strings, ""); // = 4
        }

        public static void IntComparer()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var instance = new IntComparer(0);
            var different = instance.CountDifferent(numbers); // = 4
            var equal = instance.CountEqual(numbers); // = 3
        }

        public static void GenericComparerExplicit()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var instance = new GenericComparer<int>(0);
            var different = instance.CountDifferent(numbers); // = 4
            var equal = instance.CountEqual(numbers); // = 3
        }

        public static void GenericComparerFactory()
        {
            var numbers = new[] { -1, 0, 1, 0, -2, 0, 2 };
            var instance = GenericComparer.Create(0);
            var different = instance.CountDifferent(numbers); // = 4
            var equal = instance.CountEqual(numbers); // = 3
        }

        public static void GenericComparerDouble()
        {
            var numbers = new[] { -1.5, 0, 1.5, 0, -2.5, 0, 2.5 };
            var instance = GenericComparer.Create(0d);
            var different = instance.CountDifferent(numbers); // = 4
            var equal = instance.CountEqual(numbers); // = 3
        }

        public static int CountDifferentInts(IEnumerable<int> numbers, int compareWith)
        {
            return numbers.Count(number => number != compareWith);
        }

        public static int CountDifferentGeneric<T>(IEnumerable<T> vals, T compareWith)
        {
            // won't compile: Operator '!=' cannot be applied to operands of type 'T' and 'T'
            //return vals.Count(val => val != compareWith);
            return vals.Count(val => !object.Equals(val, compareWith));
        }
    }
}
