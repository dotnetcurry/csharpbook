using System;

namespace AbstractClasses
{
    interface ISampleInterface
    {
        int Method(int arg);

        int Property { get; set; }

        event EventHandler<EventArgs> MethodInvoked;

        string this[int index] { get; set; }
    }

}
