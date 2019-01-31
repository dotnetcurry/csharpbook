using System;

namespace ExplicitlyImplementedInterface
{
    public class ImplicitTwoInterfaces : ISimpleInterface, ISecondInterface
    {
        public void Method()
        {
            Console.WriteLine("Implicit implementation");
        }
    }

}
