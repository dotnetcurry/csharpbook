using System;
using System.Threading.Tasks;

namespace OldConsoleApp
{
    class Program
    {
        private static Task<object> GetDataAsync()
        {
            return Task.FromResult(new object());
        }

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            var data = await GetDataAsync();
            // ...
        }

    }
}
