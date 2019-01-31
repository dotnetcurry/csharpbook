using System.Threading;

namespace AbortingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadAbort();
        }

        private static void Abortable()
        {
            try
            {
                // do processing
            }
            catch (ThreadAbortException)
            {
                // clean up after abort
            }
        }

        private static void ThreadAbort()
        {
            var thread = new Thread(Abortable);
            thread.Start();
            thread.Abort();
            thread.Join();
        }
    }
}
