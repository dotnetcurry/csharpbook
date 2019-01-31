using System;
using System.Threading.Tasks;

namespace AsyncExceptions
{
    class Program
    {
        private static Task ThrowsNotImplementedExceptionAsync()
        {
            return Task.Run(() => throw new NotImplementedException());
        }

        private static Task<T> ThrowsNotImplementedExceptionAsync<T>(T input)
        {
            return Task.Run((Func<T>)(() => throw new NotImplementedException()));
        }

        private static int Process(int input)
        {
            return input;
        }

        static async Task Main(string[] args)
        {
            WaitThrowsAggregateException();
            ResultThrowsAggregateException();
            AsyncMethodThrowsExceptionDirectly();
            AsyncMethodReturnsFaultedTask();
            await AwaitThrowsActualException();
            NoExceptionsWithoutAwait();
            WaitAllThrowsAggregateException();
            await WhenAllThrowsActualException();
            WaitAnyThrowsAggregateException();
            await WhenAnyThrowsActualException();
        }

        private static void WaitThrowsAggregateException()
        {
            try
            {
                ThrowsNotImplementedExceptionAsync().Wait();
            }
            catch (AggregateException e) when (e.InnerExceptions[0] is NotImplementedException inner)
            {
                // handle inner exception
            }
        }

        private static void ResultThrowsAggregateException()
        {
            try
            {
                var result = ThrowsNotImplementedExceptionAsync(42).Result;
            }
            catch (AggregateException e) when (e.InnerExceptions[0] is NotImplementedException inner)
            {
                // handle inner exception
            }
        }

        private static Task<int> ProcessAsync(int input)
        {
            if (input < 0)
            {
                // not recommended
                throw new ArgumentOutOfRangeException(nameof(input));
            }

            return Task.Run(() => Process(input));
        }

        private static void AsyncMethodThrowsExceptionDirectly()
        {
            try
            {
                var result = ProcessAsync(-1).Result;
            }
            catch (ArgumentOutOfRangeException)
            {
                // handle inner exception
            }
        }

        private static Task<int> ImprovedProcessAsync(int input)
        {
            if (input < 0)
            {
                return Task.FromException<int>(new ArgumentOutOfRangeException(nameof(input)));
            }

            return Task.Run(() => Process(input));
        }

        private static void AsyncMethodReturnsFaultedTask()
        {
            try
            {
                var result = ImprovedProcessAsync(-1).Result;
            }
            catch (AggregateException e) when (e.InnerExceptions[0] is ArgumentOutOfRangeException inner)
            {
                // handle inner exception
            }
        }

        private static async Task AwaitThrowsActualException()
        {
            try
            {
                await ThrowsNotImplementedExceptionAsync();
            }
            catch (NotImplementedException e)
            {
                // handle exception
            }
        }

        private static void NoExceptionsWithoutAwait()
        {
            try
            {
                ThrowsNotImplementedExceptionAsync();
            }
            catch (Exception e)
            {
                // won't catch exception
            }
        }

        private static Task[] CreateTasks()
        {
            var tasks = new[]
            {
                ThrowsNotImplementedExceptionAsync(),
                ThrowsNotImplementedExceptionAsync()
            };

            return tasks;
        }

        private static void WaitAllThrowsAggregateException()
        {
            var tasks = CreateTasks();

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException e)
            {
                foreach (var inner in e.InnerExceptions)
                {
                    // handle exception
                }
            }
        }

        private static async Task WhenAllThrowsActualException()
        {
            var tasks = CreateTasks();

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (NotImplementedException e)
            {
                // handle exception

                foreach (var task in tasks)
                {
                    if (task.IsFaulted)
                    {
                        // handle task.Exception
                    }
                }
            }
        }

        private static void WaitAnyThrowsAggregateException()
        {
            var tasks = CreateTasks();

            try
            {
                var completedIndex = Task.WaitAny(tasks);

                if (tasks[completedIndex].IsFaulted)
                {
                    // handle task.Exception
                }

            }
            catch (Exception e)
            {
                // won't catch exception
            }

        }

        private static async Task WhenAnyThrowsActualException()
        {
            var tasks = CreateTasks();

            try
            {
                var task = await Task.WhenAny(tasks);

                if (task.IsFaulted)
                {
                    // handle task.Exception
                }
            }
            catch (NotImplementedException e)
            {
                // won't catch exception
            }
        }
    }
}
