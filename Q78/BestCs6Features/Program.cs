using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCs6Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static int GetFibonacciNumberBefore(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Negative value not allowed", "n");
            }

            // TODO: calculate Fibonacci number
            return n;
        }

        private static int GetFibonacciNumberAfter(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Negative value not allowed", nameof(n));
            }

            // TODO: calculate Fibonacci number
            return n;
        }

        private static int GetStringLengthBefore(string arg)
        {
            return arg != null ? arg.Length : 0;
        }

        private static int GetStringLengthAfter(string arg)
        {
            return arg?.Length ?? 0;
        }

        private static string FirstItemAsString<T>(List<T> list) where T : class
        {
            return list?.FirstOrDefault()?.ToString();
        }

        private static async Task HandleAsyncBefore(AsyncResource resource, bool throwException)
        {
            Exception exceptionToLog = null;
            try
            {
                await resource.OpenAsync(throwException);
            }
            catch (Exception exception)
            {
                exceptionToLog = exception;
            }
            if (exceptionToLog != null)
            {
                await resource.LogAsync(exceptionToLog);
            }
        }

        public async Task HandleAsyncAfter(AsyncResource resource, bool throwException)
        {
            try
            {
                await resource.OpenAsync(throwException);
            }
            catch (Exception exception)
            {
                await resource.LogAsync(exception);
            }
            finally
            {
                await resource.CloseAsync();
            }
        }

    }
}
