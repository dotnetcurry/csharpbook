using System;
using System.Linq;

namespace LinqGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            GroupByQuerySyntax();
            GroupByMethodSyntax();
            HavingQuerySyntax();
            HavingMethodSyntax();
            ToLookup();
        }

        private static void GroupByQuerySyntax()
        {
            var words = new[] { "chair", "bench", "table", "lamp" };

            var query = from word in words
                        group word by word.Length;

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine($"* {item}");
                }
            }
        }

        private static void GroupByMethodSyntax()
        {
            var words = new[] { "chair", "bench", "table", "lamp" };

            var query = words.GroupBy(word => word.Length);

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine($"* {item}");
                }
            }
        }

        private static void HavingQuerySyntax()
        {
            var words = new[] { "chair", "bench", "table", "lamp" };

            var query = from word in words
                        group word by word.Length into grouping
                        where grouping.Key >= 5
                        select grouping;

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine($"* {item}");
                }
            }
        }

        private static void HavingMethodSyntax()
        {
            var words = new[] { "chair", "bench", "table", "lamp" };

            var query = words
                .GroupBy(word => word.Length)
                .Where(group => group.Key >= 5);

            foreach (var group in query)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var item in group)
                {
                    Console.WriteLine($"* {item}");
                }
            }
        }

        private static void ToLookup()
        {
            var words = new[] { "chair", "bench", "table", "lamp" };

            var lookup = words
                .ToLookup(word => word.Length);

            Console.WriteLine(lookup.Contains(4)); // true

            foreach (var item in lookup[5])
            {
                Console.WriteLine($"* {item}");
            }

        }
    }
}
