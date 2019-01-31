using System;

namespace ExplicitlyImplementedInterface
{
    public class ImplicitImplementation : ISimpleInterface
    {
        public void Method()
        {
            Console.WriteLine("Implicit implementation");
        }
    }

}
