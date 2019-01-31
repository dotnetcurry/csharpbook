namespace Timers
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadingTimer();
            TimersTimer();
        }

        private static void ThreadingTimer()
        {
            object stateObject = null;

            var timer = new System.Threading.Timer(state =>
            {
                // code to execute
            }, stateObject, 50, System.Threading.Timeout.Infinite);
        }

        private static void TimersTimer()
        {
            object stateObject = null;

            var timer = new System.Threading.Timer(state =>
            {
                // code to execute
            }, stateObject, 50, System.Threading.Timeout.Infinite);
        }
    }
}
