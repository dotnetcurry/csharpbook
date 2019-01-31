using System;
using System.Collections;
using System.Collections.Generic;

namespace BoxingExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Boxing();
            Unboxing();

            try
            {
                ThrowsInvalidCastException();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }

            ChangesAfterUnboxing();
            NonGenericCollection();
            GenericCollection();
            MixedTypeCollection();

            Console.WriteLine(BoxingBecauseOfApi());
        }

        private static void Boxing()
        {
            int a = 42;
            object o = a;
        }

        private static void Unboxing()
        {
            object o = 42;
            int a = (int)o;
        }

        private static void ThrowsInvalidCastException()
        {
            object o = 42;
            long i = (int)o;  // int will be implicitly cast to long
            long l = (long)o; // InvalidCastException will be thrown
        }

        private static void ChangesAfterUnboxing()
        {
            object o = new Point();
            //((Point)o).X = 1; // will not compile
            Point p = (Point)o;
            p.X = 1; // will leave the value of o unchanged
        }

        private static void NonGenericCollection()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            foreach (object i in list)
            {
                Console.WriteLine(i);
            }
        }

        private static void GenericCollection()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }

        private static void MixedTypeCollection()
        {
            var list = new List<object>();
            list.Add(42);
            list.Add(true);
            list.Add(3.14);
            foreach (object i in list)
            {
                Console.WriteLine(i);
            }
        }

        private static string BoxingBecauseOfApi()
        {
            return String.Format("{0} = {1}", "boxing", true);
        }
    }
}
