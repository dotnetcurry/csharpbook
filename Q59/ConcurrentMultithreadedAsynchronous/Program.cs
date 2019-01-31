using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentMultithreadedAsynchronous
{
    class Program
    {
        private static void DoProcess()
        {
            // CPU intensive code
        }

        static void Main(string[] args)
        {
            var thread = new Thread(DoProcess);
            thread.Start();
            // CPU intensive code
            thread.Join();

            var task = Task.Run((Action)DoProcess);
            // CPU intensive code
            task.Wait();

            var path = "TextFile1.txt";
            var fileInfo = new FileInfo(path);
            var buffer = new byte[fileInfo.Length];

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, buffer.Length, useAsync: true))
            {
                var streamTask = stream.ReadAsync(buffer, 0, buffer.Length);
                // other CPU-bound code
                var bytesRead = streamTask.Result;
            }

        }
    }
}
