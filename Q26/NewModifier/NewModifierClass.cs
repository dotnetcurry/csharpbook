using System;

namespace NewModifier
{
    public class NewModifierClass : BaseClass
    {
        public new void Method()
        {
            Console.WriteLine("From NewModifierClass");
        }
    }

}
