using System;
using System.Threading.Tasks;

namespace AsyncInExistingCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await AsyncMethod();
            SyncMethodWithBlocking();
            SyncMethodFireAndForget();
        }

        private static Task<object> GetDataAsync()
        {
            return Task.FromResult(new object());
        }

        private static async Task AsyncMethod()
        {
            var data = await GetDataAsync();
            // ...
        }

        public static void SyncMethodWithBlocking()
        {
            var data = GetDataAsync().Result;
            // ...
        }

        private static void SyncMethodFireAndForget()
        {
            GetDataAsync();
            // ...
        }
    }
}
