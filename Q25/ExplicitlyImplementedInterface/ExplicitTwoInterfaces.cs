using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitlyImplementedInterface
{
    public class ExplicitTwoInterfaces : ISimpleInterface, ISecondInterface
    {
        void ISimpleInterface.Method()
        {
            Console.WriteLine("ISimpleInterface");
        }

        void ISecondInterface.Method()
        {
            Console.WriteLine("ISecondInterface");
        }
    }

}
