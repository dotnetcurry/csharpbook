using System;

namespace ExplicitlyImplementedInterface
{
    public class ClassMemberAndExplicitImplementation : ISimpleInterface
    {
        public void Method()
        {
            Console.WriteLine("Regular class member");
        }

        void ISimpleInterface.Method()
        {
            Console.WriteLine("Explicit implementation");
        }
    }

}
