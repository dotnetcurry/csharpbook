using System;
using System.Collections.Generic;

namespace StaticMembers
{
    public static class FibonacciNumberCalculator
    {
        public static int GetFibonacciNumber(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            else if (n < 2)
            {
                return n;
            }
            else
            {
                var numbers = new List<int> { 0, 1 };
                for (int i = 2; i <= n; i++)
                {
                    numbers.Add(numbers[i - 1] + numbers[i - 2]);
                }
                return numbers[n];
            }
        }

        private static List<int> numbers;

        static FibonacciNumberCalculator()
        {
            numbers = new List<int> { 0, 1 };
        }

        public static int GetFibonacciNumberWithMemoization(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }
            else if (n < numbers.Count)
            {
                return numbers[n];
            }
            else
            {
                for (int i = numbers.Count; i <= n; i++)
                {
                    numbers.Add(numbers[i - 1] + numbers[i - 2]);
                }
                return numbers[n];
            }
        }
    }

}
