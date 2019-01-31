using System;

namespace DelegatesAndEvents
{
    public class MethodEventArgs : EventArgs
    {
        public int Argument { get; private set; }

        public MethodEventArgs(int argument)
        {
            Argument = argument;
        }
    }

}
