using System.IO;
using System.Threading.Tasks;

namespace AsynchronousProgrammingModel
{
    class Program
    {
        private static readonly string filename = "TextFile1.txt";
        private static readonly int timeout = 100;

        static async Task Main(string[] args)
        {
            BeginReadEndRead();
            BeginReadHandleWait();
            BeginReadIsCompleted();
            BeginReadCallback();
            await WrapIntoTask();
        }

        private static void BeginReadEndRead()
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                var asyncResult = stream.BeginRead(buffer, 0, buffer.Length, null, null);
                // execute other code in the meantime
                var bytesRead = stream.EndRead(asyncResult); // blocks until completion
            }
            // use buffer contents
        }

        private static void BeginReadHandleWait()
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                var asyncResult = stream.BeginRead(buffer, 0, buffer.Length, null, null);
                // execute other code in the meantime
                if (asyncResult.AsyncWaitHandle.WaitOne(timeout)) // blocks temporarily
                {
                    asyncResult.AsyncWaitHandle.Close();
                    var bytesRead = stream.EndRead(asyncResult); // executes immediately
                }
                else
                {
                    // the operation has not completed until timeout
                }
            }
            // use buffer contents
        }

        private static void BeginReadIsCompleted()
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                var asyncResult = stream.BeginRead(buffer, 0, buffer.Length, null, null);
                while (!asyncResult.IsCompleted)
                {
                    // execute other code in the meantime
                }
                var bytesRead = stream.EndRead(asyncResult); // executes immediately
            }
            // use buffer contents
        }

        private static void BeginReadCallback()
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];
            var stream = new FileStream(filename, FileMode.Open);
            stream.BeginRead(buffer, 0, buffer.Length, asyncResult =>
            {
                var bytesRead = stream.EndRead(asyncResult); // executes immediately
                stream.Dispose();
                // use buffer contents
            }, null);
            // immediately continue executing other code
        }

        private static async Task WrapIntoTask()
        {
            var fileInfo = new FileInfo(filename);
            var buffer = new byte[fileInfo.Length];
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                var bytesRead = await Task<int>.Factory.FromAsync(stream.BeginRead,
                    stream.EndRead, buffer, 0, buffer.Length, null); // releases thread for other work
            }
            // use buffer contents
        }
    }
}
