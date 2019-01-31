using System;
using static StaticMembers.FibonacciNumberCalculator;

namespace StaticMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceMembers();
            StaticMembers();
            GenericStaticMembers();

            try
            {
                FailingClass();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void InstanceMembers()
        {
            var instance1 = new ClassWithInstanceMembers();
            instance1.InstanceProperty = 1;

            var instance2 = new ClassWithInstanceMembers();
            instance2.InstanceProperty = 2;

            instance1.InstanceMethod(); // Property value: 1
            instance2.InstanceMethod(); // Property value: 2
        }

        private static void StaticMembers()
        {
            var fibonacci8 = FibonacciNumberCalculator.GetFibonacciNumber(8); // 21
            fibonacci8 = GetFibonacciNumber(8); // 21
        }

        private static void GenericStaticMembers()
        {
            GenericClass<int>.StaticProperty = 1;
            GenericClass<float>.StaticProperty = 2;

            Console.WriteLine(GenericClass<int>.StaticProperty); // = 1
            Console.WriteLine(GenericClass<float>.StaticProperty); // = 2
        }

        private static void FailingClass()
        {
            try
            {
                var failedInstance = new FailingClass();
            }
            catch (TypeInitializationException) { }
            Config.ThrowException = false;
            var instance = new FailingClass();
        }
    }
}
