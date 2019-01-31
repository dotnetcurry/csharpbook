using System;

namespace AutoImplementedProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            FieldAccess();
            PropertyAccess();
        }

        private static void FieldAccess()
        {
            var instance = new SampleClass();
            var value = instance.publicField;
            instance.publicField = -1;
        }

        private static void PropertyAccess()
        {
            var instance = new SampleClass();
            var value = instance.RegularProperty;
            //instance.RegularProperty = -1; // won't compile
        }
    }
}
