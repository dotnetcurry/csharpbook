using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultithreadingAbstractions
{
    class Program
    {
        private static readonly IEnumerable<int> list = Enumerable.Range(0, 1000);

        static void Main(string[] args)
        {
            BackgroundTask();
            ParallelLinq();
            SequentialLinq();
            ParallelLinqWithDegreeOfParallelism();
            ParallelLinqTake();
            ParallelLinqOrderedTake();
        }

        private static int DoComplexCalculation(int input)
        {
            // do the processing
            return input;
        }

        private static void BackgroundTask()
        {
            var backgroundTask = Task.Run(() => DoComplexCalculation(42));
            // do other work
            var result = backgroundTask.Result;
        }

        private static void ParallelLinq()
        {
            var query = list.AsParallel()
                .Select(item => DoComplexCalculation(item));
        }

        private static void SequentialLinq()
        {
            var query = list.Select(item => DoComplexCalculation(item));
        }

        private static void ParallelLinqWithDegreeOfParallelism()
        {
            var query = list.AsParallel().WithDegreeOfParallelism(2)
                .Select(item => DoComplexCalculation(item));
        }

        private static void ParallelLinqTake()
        {
            var query = list.AsParallel()
                .Select(item => DoComplexCalculation(item))
                .Take(10);
        }

        private static void ParallelLinqOrderedTake()
        {
            var query = list.AsParallel().AsOrdered()
                .Select(item => DoComplexCalculation(item))
                .Take(10);
        }
    }
}
