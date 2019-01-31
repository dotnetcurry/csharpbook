using System;

namespace NewModifier
{
    public class NonVirtualDerivedClass : NonVirtualBaseClass
    {
        public new void Method() // will still compile
        {
            Console.WriteLine("From NonVirtualDerivedClass");
        }
    }
}
