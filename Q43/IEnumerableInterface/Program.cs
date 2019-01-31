using System;
using System.Linq;

namespace IEnumerableInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Enumerable.Range(1, 10);

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    // process item
                }
            }

            foreach (var item in collection)
            {
                // process item
            }

            var noEnumerable = new NoIEnumerable<int>(collection);

            foreach (var item in noEnumerable)
            {
                // process item
            }

            var array = new[] { 1, 2, 3, 4, 5 }; // initialize array
            Span<int> span = array; // implicit cast
            var subSpan = span.Slice(start: 1, length: 3); // reference part of the array

            foreach (var item in subSpan)
            {
                // process item
            }
        }
    }
}
