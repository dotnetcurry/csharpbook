using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodWithLocalFunction();
            MethodWithNestedLocalFunction();
            MethodWithLambda();
            LateValidation();
            ImmediateValidation();
            LocalFunctionValidation();
        }

        public static void MethodWithLocalFunction()
        {
            Console.WriteLine("Inside Method");
            LocalFunction();

            void LocalFunction()
            {
                Console.WriteLine("Inside LocalFunction");
            }
        }

        public static void MethodWithNestedLocalFunction()
        {
            Console.WriteLine("Inside Method");
            LocalFunction();

            void LocalFunction()
            {
                Console.WriteLine("Inside LocalFunction");
                NestedLocalFunction();

                void NestedLocalFunction()
                {
                    Console.WriteLine("Inside NestedLocalFunction");
                }
            }
        }

        public static void MethodWithLambda()
        {
            Action lambda = () =>
            {
                Console.WriteLine("Inside Lambda");
            };

            Console.WriteLine("Inside Method");
            lambda();
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items.Where(predicate);
        }

        public static IEnumerable<int> FibonacciSequence(int maxN)
        {
            if (maxN < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxN));
            }
            if (maxN >= 0)
            {
                yield return 0;
            }
            if (maxN >= 1)
            {
                yield return 1;
            }
            if (maxN >= 2)
            {
                var beforePrevious = 0;
                var previous = 1;
                for (var i = 2; i <= maxN; i++)
                {
                    var current = beforePrevious + previous;

                    beforePrevious = previous;
                    previous = current;

                    yield return current;
                }
            }
        }

        private static void LateValidation()
        {
            try
            {
                var sequence = FibonacciSequence(-1);
                // no exception thrown yet
                foreach (var n in sequence)
                {
                    // use the numbers
                }

            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        public static IEnumerable<int> FibonacciSequenceImmediateValidation(int maxN)
        {
            if (maxN < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxN));
            }
            return FibonacciSequenceNoValidation(maxN);
        }

        private static IEnumerable<int> FibonacciSequenceNoValidation(int maxN)
        {
            if (maxN >= 0)
            {
                yield return 0;
            }
            if (maxN >= 1)
            {
                yield return 1;
            }
            if (maxN >= 2)
            {
                var beforePrevious = 0;
                var previous = 1;
                for (var i = 2; i <= maxN; i++)
                {
                    var current = beforePrevious + previous;

                    beforePrevious = previous;
                    previous = current;

                    yield return current;
                }
            }
        }

        private static void ImmediateValidation()
        {
            try
            {
                var sequence = FibonacciSequenceImmediateValidation(-1);
                // exception thrown in the previous line
                foreach (var n in sequence)
                {
                    // use the numbers
                }
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        public static IEnumerable<int> FibonacciSequenceWithLocalFunction(int maxN)
        {
            if (maxN < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxN));
            }
            return FibonacciSequenceNoValidation();

            IEnumerable<int> FibonacciSequenceNoValidation()
            {
                if (maxN >= 0)
                {
                    yield return 0;
                }
                if (maxN >= 1)
                {
                    yield return 1;
                }
                if (maxN >= 2)
                {
                    var beforePrevious = 0;
                    var previous = 1;
                    for (var i = 2; i <= maxN; i++)
                    {
                        var current = beforePrevious + previous;

                        beforePrevious = previous;
                        previous = current;

                        yield return current;
                    }
                }
            }
        }


        private static void LocalFunctionValidation()
        {
            try
            {
                var sequence = FibonacciSequenceWithLocalFunction(-1);
                // exception thrown in the previous line
                foreach (var n in sequence)
                {
                    // use the numbers
                }
            }
            catch (ArgumentOutOfRangeException)
            { }
        }

        public static Task AsyncMethod(int input)
        {
            // perform validation
            return AsyncLocalFunction();

            async Task AsyncLocalFunction()
            {
                // actual async code
            }
        }

    }
}
