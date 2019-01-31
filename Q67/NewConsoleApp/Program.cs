using System;
using System.Threading.Tasks;

namespace NewConsoleApp
{
    class Program
    {
        private static Task<object> GetDataAsync()
        {
            return Task.FromResult(new object());
        }

        static async Task<int> Main(string[] args)
        {
            var data = await GetDataAsync();
            // ...

            var result = 0;

            return result;
        }

    }
}
