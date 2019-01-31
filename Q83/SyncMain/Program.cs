using System;
using System.Threading.Tasks;

namespace SyncMain
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            // asynchronous code
        }

    }
}
