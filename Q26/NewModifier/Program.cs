namespace NewModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass();
            NewModifierClass();
            NonVirtualDerivedClass();
        }

        private static void DerivedClass()
        {
            var instance = new DerivedClass();
            instance.Method(); // output: From DerivedClass

            var asBase = (BaseClass)instance;
            asBase.Method(); // output: From DerivedClass
        }

        private static void NewModifierClass()
        {
            var instance = new NewModifierClass();
            instance.Method(); // output: From NewModifierClass

            var asBase = (BaseClass)instance;
            asBase.Method(); // output: From BaseClass
        }

        private static void NonVirtualDerivedClass()
        {
            var instance = new NonVirtualDerivedClass();
            instance.Method(); // output: From NonVirtualDerivedClass

            var asBase = (NonVirtualBaseClass)instance;
            asBase.Method(); // output: From NonVirtualBaseClass
        }
    }
}
