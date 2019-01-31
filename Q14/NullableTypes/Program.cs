using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            HasValueProperty();
            ValueProperty();
            ShorterNotation();
            ImplicitCast();
            ExplicitCast();
            BoxingSetValue();
            BoxingUnsetValue();
        }

        private static void HasValueProperty()
        {
            var nonEmpty = new Nullable<int>(0);
            Console.WriteLine(nonEmpty.HasValue);
            var empty = new Nullable<int>();
            Console.WriteLine(empty.HasValue);
        }

        private static void ValueProperty()
        {
            var nonEmpty = new Nullable<int>(0);
            Console.WriteLine(nonEmpty.Value);
            var empty = new Nullable<int>();
            Console.WriteLine(empty.HasValue);
        }

        private static void ShorterNotation()
        {
            var nonEmpty = new int?(0);
            var empty = new int?();
        }

        private static void ImplicitCast()
        {
            int? nonEmpty = 0;
            int? empty = null;
        }

        private static void ExplicitCast()
        {
            int? nonEmpty = 0;
            int a = (int)nonEmpty;
        }

        private static void BoxingSetValue()
        {
            int? nonEmpty = 0;
            var boxed = (object)nonEmpty;
            int? unboxedNullable = (int?)boxed;
            int unboxedInt = (int)boxed;
        }

        private static void BoxingUnsetValue()
        {
            int? empty = null;
            var boxed = (object)empty;
            int? unboxedNullable = (int?)boxed;
        }
    }
}
