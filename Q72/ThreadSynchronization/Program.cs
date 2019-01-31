using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSynchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessWithSemaphore();
            ResetEvents();
        }

        private static void Process(SemaphoreSlim semaphore)
        {
            semaphore.Wait();
            try
            {
                // do the processing
            }
            finally
            {
                semaphore.Release();
            }
        }

        private static void ProcessWithSemaphore()
        {
            var semaphore = new SemaphoreSlim(3, 3);

            var tasks = Enumerable.Range(0, 10)
                .Select(index => Task.Run(() => Process(semaphore)))
                .ToArray();

            Task.WaitAll(tasks);
        }

        private static void ResetEvents()
        {
            var handle = new AutoResetEvent(false);

            var task = Task.Run(() =>
            {
                Console.WriteLine("Task start");
                handle.WaitOne();
                Console.WriteLine("Task end");
            });

            Thread.Sleep(10);

            Console.WriteLine("Before signal");
            handle.Set();
            Console.WriteLine("After signal");

            task.Wait();
        }
    }
}
