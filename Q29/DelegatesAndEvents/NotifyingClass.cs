using System;

namespace DelegatesAndEvents
{
    public class NotifyingClass
    {
        public event EventHandler<MethodEventArgs> MethodInvoked;

        public void Method(int argument)
        {
            MethodInvoked?.Invoke(this, new MethodEventArgs(argument));
        }
    }

}
