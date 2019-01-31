using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            NonParameterizedThread();
            ParameterizedThread();
            CallbackParameter();
            ThreadJoin();
            ThreadJoinWithTimeout();
        }

        private static void NonParameterized()
        {
            // do processing
        }

        private static void NonParameterizedThread()
        {
            var thread = new Thread(NonParameterized);
            thread.Start();
        }

        private static void Parameterized(object input)
        {
            // do processing
        }

        private static void ParameterizedThread()
        {
            object input = null;

            var thread = new Thread(Parameterized);
            thread.Start(input);
        }

        private static void ReturnResult(object input)
        {
            var callback = (Action<int>)input;

            // do processing
            var result = 42;

            callback(result);
        }

        private static void CallbackParameter()
        {
            int result = 0;
            Action<int> callback = output => result = output;

            var thread = new Thread(ReturnResult);
            thread.Start(callback);
        }

        private static void ThreadJoin()
        {
            var thread = new Thread(NonParameterized);
            thread.Start();
            thread.Join();
        }

        private static void ThreadJoinWithTimeout()
        {
            var timeout = 100;

            var thread = new Thread(NonParameterized);
            thread.Start();
            var joined = thread.Join(timeout);
        }
    }
}
