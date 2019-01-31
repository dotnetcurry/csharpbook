using System;
using System.Collections.Generic;

namespace LinqQueryExecution.Extensions
{
    static class EnumerableExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static int Sum(this IEnumerable<int> list)
        {
            var sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return sum;
        }
    }
}
