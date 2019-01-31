using System;
using System.Threading.Tasks;

namespace AsyncPitfalls
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AsyncMethod();
            SyncMethod();
        }

        private static void DoSomeStuff()
        { }

        private static void DoSomeMoreStuff()
        { }

        public static async Task AsyncMethod()
        {
            DoSomeStuff();                   // synchronous method
            await DoSomeLengthyStuffAsync(); // long-running asynchronous method
            DoSomeMoreStuff();               // another synchronous method

            async Task DoSomeLengthyStuffAsync()
            {
                await Task.Yield();
            }
        }

        public static void SyncMethod()
        {
            DoSomeStuff();             // synchronous method
            DoSomeLengthyStuffAsync(); // long-running asynchronous method
            DoSomeMoreStuff();         // another synchronous method

            async void DoSomeLengthyStuffAsync()
            {
                await Task.Yield();
            }
        }
    }
}
