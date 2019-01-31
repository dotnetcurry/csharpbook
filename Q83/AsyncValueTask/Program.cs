using System;
using System.Threading.Tasks;

namespace AsyncValueTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var formTask = await ReturnsTask();
            var formValueTask = await ReturnsValueTask();
        }

        public static async Task<int> ReturnsTask()
        {
            await Task.Delay(10);
            return 42;
        }

        public static async ValueTask<int> ReturnsValueTask()
        {
            await Task.Delay(10);
            return 42;
        }

    }
}
