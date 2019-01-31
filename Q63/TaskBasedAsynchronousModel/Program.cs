using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace TaskBasedAsynchronousModel
{
    class Program
    {
        private static SafeFileHandle srcFile;

        static async Task Main(string[] args)
        {
            BackgroundTask();
            await BackgroundTaskAsync();
            ContinueWith();
            await ContinueWithAsync();
            ErrorHandling();
            await ErrorHandlingAsync();
            AllTasks();
            await AllTasksAsync();
            AnyTasks();
            await AnyTasksAsync();
            await CancellationAsync();
            await StreamsAsync();
            await HttpAsync();
        }

        private static int DoComplexCalculation(int input)
        {
            // do the processing
            return input;
        }

        private static int DoAnotherComplexCalculation(int input)
        {
            // do the processing
            return input;
        }

        private static async Task HandleError(Exception exception)
        {
            // handle error

            await Task.Yield();
        }

        private static async Task HandleCancelation()
        {
            // handle cancelation

            await Task.Yield();
        }

        private static void BackgroundTask()
        {
            var backgroundTask = Task.Run(() => DoComplexCalculation(42));
            var result = backgroundTask.Result;
        }

        private static async Task BackgroundTaskAsync()
        {
            var backgroundTask = Task.Run(() => DoComplexCalculation(42));
            var result = await backgroundTask;
        }

        private static void ContinueWith()
        {
            var compositeTask = Task.Run(() => DoComplexCalculation(42))
                .ContinueWith(previous => DoAnotherComplexCalculation(previous.Result));
        }

        private static async Task ContinueWithAsync()
        {
            var intermediateResult = await Task.Run(() => DoComplexCalculation(42));
            var result = DoAnotherComplexCalculation(intermediateResult);
        }

        private static void ErrorHandling()
        {
            var initialTask = Task.Run(() => DoComplexCalculation(42));

            var successfulContinuation = initialTask.ContinueWith(previous =>
                DoAnotherComplexCalculation(previous.Result),
                    TaskContinuationOptions.OnlyOnRanToCompletion);
            var failedContinuation = initialTask.ContinueWith(previous =>
                HandleError(previous.Exception), TaskContinuationOptions.OnlyOnFaulted);
            var canceledContinuation = initialTask.ContinueWith(previous =>
                HandleCancelation(), TaskContinuationOptions.OnlyOnCanceled);
        }

        private static async Task ErrorHandlingAsync()
        {
            try
            {
                var intermediateResult = await Task.Run(() => DoComplexCalculation(42));
                var result = DoAnotherComplexCalculation(intermediateResult);
            }
            catch (TaskCanceledException)
            {
                await HandleCancelation();
            }
            catch (Exception exception)
            {
                await HandleError(exception);
            }
        }

        private static Task[] CreateTasks()
        {
            var backgroundTasks = new[]
            {
                Task.Run(() => DoComplexCalculation(1)),
                Task.Run(() => DoComplexCalculation(2)),
                Task.Run(() => DoComplexCalculation(3))
            };

            return backgroundTasks;
        }

        private static void AllTasks()
        {
            var backgroundTasks = CreateTasks();

            // wait synchronously
            Task.WaitAll(backgroundTasks);
        }

        private static async Task AllTasksAsync()
        {
            var backgroundTasks = CreateTasks();

            // wait asynchronously
            await Task.WhenAll(backgroundTasks);
        }

        private static void AnyTasks()
        {
            var backgroundTasks = CreateTasks();

            // wait synchronously
            Task.WaitAny(backgroundTasks);
        }

        private static async Task AnyTasksAsync()
        {
            var backgroundTasks = CreateTasks();

            // wait synchronously
            await Task.WhenAny(backgroundTasks);
        }

        private static async Task CancellationAsync()
        {
            var tokenSource = new CancellationTokenSource();
            var cancellableTask = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (tokenSource.Token.IsCancellationRequested)
                    {
                        // clean up before exiting
                        tokenSource.Token.ThrowIfCancellationRequested();
                    }
                    // do long-running processing
                }
                return 42;
            }, tokenSource.Token);
            // cancel the task
            tokenSource.Cancel();
            try
            {
                await cancellableTask;
            }
            catch (OperationCanceledException)
            {
                // handle cancelation
            }
        }

        private static async Task StreamsAsync()
        {
            var srcFile = "src.txt";
            var destFile = "dest.txt";

            using (FileStream srcStream = new FileStream(srcFile, FileMode.Open),
                              destStream = new FileStream(destFile, FileMode.Create))
            {
                await srcStream.CopyToAsync(destStream);
            }
        }

        private static async Task HttpAsync()
        {
            var url = "http://www.google.com";

            using (var httpClient = new HttpClient())
            {
                var content = await httpClient.GetStringAsync(url);
            }

        }
    }
}
