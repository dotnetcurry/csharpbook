using LinqQueryExecution.Extensions;
using System.Collections.Generic;

namespace LinqQueryExecution
{
    partial class Program
    {
        private static void WhereExtension()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var query = list.Where(item => item < 3); // not executed yet
        }

        private static void SumExtension()
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            var sum = list.Sum(); // executes immediately
        }
    }
}
