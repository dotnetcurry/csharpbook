using System;

namespace ExplicitlyImplementedInterface
{
    public class ExplicitImplementation : ISimpleInterface
    {
        void ISimpleInterface.Method()
        {
            Console.WriteLine("Explicit implementation");
        }
    }

}
