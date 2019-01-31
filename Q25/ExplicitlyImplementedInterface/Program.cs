using System;

namespace ExplicitlyImplementedInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            ImplicitClassAccess();
            ImplicitInterfaceAccess();
            ExplicitClassAccess();
            ExplicitInterfaceAccess();
            MemberAndExplicit();
            TwoInterfacesImplicit();
            TwoInterfacesExplicit();
        }

        private static void ImplicitClassAccess()
        {
            var instance = new ImplicitImplementation();
            instance.Method(); // outputs: Implicit implementation 
        }

        private static void ImplicitInterfaceAccess()
        {
            var instance = new ImplicitImplementation();
            var asInterface = (ISimpleInterface)instance;
            asInterface.Method(); // outputs: Implicit implementation
        }

        private static void ExplicitClassAccess()
        {
            var instance = new ExplicitImplementation();
            //instance.Method(); // will not build
        }

        private static void ExplicitInterfaceAccess()
        {
            var instance = new ExplicitImplementation();
            var asInterface = (ISimpleInterface)instance;
            asInterface.Method(); // outputs: Explicit implementation
        }

        private static void MemberAndExplicit()
        {
            var instance = new ClassMemberAndExplicitImplementation();
            instance.Method(); // outputs: Regular class member

            var asInterface = (ISimpleInterface)instance;
            asInterface.Method(); // outputs: Explicit implementation
        }

        private static void TwoInterfacesImplicit()
        {
            var instance = new ImplicitTwoInterfaces();
            var asSimpleInterface = (ISimpleInterface)instance;
            asSimpleInterface.Method(); // outputs: Implicit implementation

            var asSecondInterface = (ISecondInterface)instance;
            asSecondInterface.Method(); // outputs: Implicit implementation
        }

        private static void TwoInterfacesExplicit()
        {
            var instance = new ExplicitTwoInterfaces();
            var asSimpleInterface = (ISimpleInterface)instance;
            asSimpleInterface.Method(); // outputs: ISimpleInterface

            var asSecondInterface = (ISecondInterface)instance;
            asSecondInterface.Method(); // outputs: ISecondInterface
        }
    }
}
