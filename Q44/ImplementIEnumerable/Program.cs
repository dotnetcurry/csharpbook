using System;
using System.Collections.Generic;

namespace ImplementIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static IEnumerable<T> GetArrayWrapper<T>(T[] array) => new ArrayWrapper<T>(array);

        public static IEnumerable<T> GetArrayWrapperWithYield<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (var index = 0; index < array.Length; index++)
            {
                yield return array[index];
            }
        }

        public static IEnumerable<long> GetFibonacciSequence()
        {
            yield return 1;
            yield return 1;

            long preprevious = 1;
            long previous = 1;

            while (true)
            {
                var current = preprevious + previous;
                preprevious = previous;
                previous = current;
                yield return current;
            }
        }

    }
}
