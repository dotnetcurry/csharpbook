using System;
using System.Threading.Tasks;

namespace AsyncMain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program start");
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"{i + 1} seconds passed.");
            }
        }
    }
}
