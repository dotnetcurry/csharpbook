using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5
{
    class Program
    {
        private static readonly string filename = "TextFile1.txt";

        static async Task Main(string[] args)
        {
            await After();
            Before();
        }

        private static async Task After()
        {
            var wordCount = await CountWordsAfter(filename);
        }

        private static async Task<int> CountWordsAfter(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                var text = await reader.ReadToEndAsync();
                return text.Split(' ').Length;
            }
        }

        private static void Before()
        {
            var wordCount = CountWordsBeforeWithTasks(filename).Result;
            wordCount = CountWordsBeforeSynchronous(filename).Result;
            wordCount = CountWordsBeforeAsynchronous(filename).Result;
        }

        private static Task<int> CountWordsBeforeWithTasks(string filename)
        {
            var reader = new StreamReader(filename);
            return reader.ReadToEndAsync()
                .ContinueWith(task =>
                {
                    reader.Close();
                    return task.Result.Split(' ').Length;
                });
        }

        private static Task<int> CountWordsBeforeSynchronous(string filename)
        {
            return Task.Run(() =>
            {
                using (var reader = new StreamReader(filename))
                {
                    return reader.ReadToEnd().Split(' ').Length;
                }
            });
        }

        private static Task<int> CountWordsBeforeAsynchronous(string filename)
        {
            var fileInfo = new FileInfo(filename);

            var stream = new FileStream(filename, FileMode.Open);
            var buffer = new byte[fileInfo.Length];
            return Task.Factory.FromAsync(stream.BeginRead, stream.EndRead, buffer, 0, buffer.Length, null)
                .ContinueWith(_ =>
                {
                    stream.Close();
                    return Encoding.UTF8.GetString(buffer).Split(' ').Length;
                });
        }

    }
}
