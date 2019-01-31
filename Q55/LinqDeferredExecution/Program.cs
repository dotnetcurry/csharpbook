using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDeferredExecution
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleEvaluation();
            MultipleEvaluations();
            StoreResult();
            Aggregate();
        }

        private static void SingleEvaluation()
        {
            var list = new List<int> { 1, 2, 3 };
            var query = list.Select(item => item * 2);
            list.Add(4);

            foreach (var item in query)
            {
                Console.Write($"{item} "); // 2 4 6 8 
            }

            Console.WriteLine();
        }

        private static void MultipleEvaluations()
        {
            var list = new List<int> { 1, 2, 3 };
            var query = list.Select(item => item * 2);

            foreach (var item in query)
            {
                Console.Write($"{item} "); // 2 4 6 
            }

            Console.WriteLine();

            list.Add(4);

            foreach (var item in query)
            {
                Console.Write($"{item} "); // 2 4 6 8  
            }

            Console.WriteLine();
        }

        private static void StoreResult()
        {
            var list = new List<int> { 1, 2, 3 };
            var result = list.Select(item => item * 2).ToList();
            list.Add(4);

            foreach (var item in result)
            {
                Console.Write($"{item} "); // 2 4 6
            }

            Console.WriteLine();
        }

        private static void Aggregate()
        {
            var list = new List<int> { 1, 2, 3 };
            var result = list.Select(item => item * 2).Sum();
            list.Add(4);

            Console.Write(result); // 12

            Console.WriteLine();
        }
    }
}
