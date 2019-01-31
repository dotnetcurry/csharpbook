using System;

namespace StaticMembers
{
    public class ClassWithInstanceMembers
    {
        public int InstanceProperty { get; set; }

        public void InstanceMethod()
        {
            Console.WriteLine($"Property value: {InstanceProperty}");
        }
    }

}
