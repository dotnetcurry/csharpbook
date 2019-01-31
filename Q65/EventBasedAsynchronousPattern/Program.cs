using System;
using System.Net;
using System.Threading.Tasks;

namespace EventBasedAsynchronousPattern
{
    class Program
    {
        private static readonly Uri url = new Uri("http://www.google.com");

        static async Task Main(string[] args)
        {
            EventHandler();
            ErrorHandling();
            Cancelling();
            await WrapIntoTask();
        }

        private static void EventHandler()
        {
            var webClient = new WebClient();

            webClient.DownloadStringCompleted += (sender, args) =>
            {
                webClient.Dispose();
                var contents = args.Result;
                // process the result
            };

            webClient.DownloadStringAsync(url);
        }

        private static void ErrorHandling()
        {
            var webClient = new WebClient();

            webClient.DownloadStringCompleted += (sender, args) =>
            {
                webClient.Dispose();
                if (args.Error != null)
                {
                    // handle error
                }
                else
                {
                    var contents = args.Result;
                    // process the result
                }
            };

            webClient.DownloadStringAsync(url);
        }

        private static void Cancelling()
        {
            var webClient = new WebClient();

            webClient.DownloadStringCompleted += (sender, args) =>
            {
                webClient.Dispose();
                if (args.Cancelled)
                {
                    // handle cancellation
                }
                else if (args.Error != null)
                {
                    // handle error
                }
                else
                {
                    var contents = args.Result;
                    // process the result
                }
            };

            webClient.DownloadStringAsync(url);
        }

        private static async Task WrapIntoTask()
        {
            var taskSource = new TaskCompletionSource<string>();
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (sender, args) =>
            {
                webClient.Dispose();
                if (args.Cancelled)
                {
                    taskSource.SetCanceled();
                }
                else if (args.Error != null)
                {
                    taskSource.SetException(args.Error);
                }
                else
                {
                    taskSource.SetResult(args.Result);
                }
            };
            webClient.DownloadStringAsync(url);

            var contents = await taskSource.Task;

        }
    }
}
