using System;

namespace DelegatesAndEvents
{
    public class InstrumentedNotifyingClass
    {
        private EventHandler<MethodEventArgs> methodInvokedDelegate;

        public event EventHandler<MethodEventArgs> MethodInvoked
        {
            add
            {
                methodInvokedDelegate += value;
                Console.WriteLine("Added event handler.");
            }

            remove
            {
                methodInvokedDelegate -= value;
                Console.WriteLine("Removed event handler.");
            }
        }

        public void Method(int argument)
        {
            methodInvokedDelegate?.Invoke(this, new MethodEventArgs(argument));
        }
    }

}
