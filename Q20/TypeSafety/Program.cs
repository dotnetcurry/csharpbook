using System;
using System.Collections;
using System.Collections.Generic;

namespace TypeSafety
{
    class Program
    {
        static void Main(string[] args)
        {
            NonExistentMembers();
            NonExistentMembersWithCast();

            try
            {
                ThrowsInvalidCastException();
            }
            catch (InvalidCastException)
            { }

            SafeCasting();
            NonExistentMembersViaObject();

            try
            {
                NonGenericCollection();
            }
            catch (InvalidCastException)
            { }

            GenericCollection();
            Unsafe();
        }

        private static void NonExistentMembers()
        {
            string text = "String value";
            int textLength = text.Length;
            //int textMonth = text.Month; // won't compile

            DateTime date = DateTime.Now;
            //int dateLength = date.Length; // won't compile
            int dateMonth = date.Month;
        }

        private static void NonExistentMembersWithCast()
        {
            string text = "String value";
            int textLength = text.Length;
            //int textMonth = ((DateTime)text).Month; // won't compile

            DateTime date = DateTime.Now;
            //int dateLength = ((string)date).Length; // won't compile
            int dateMonth = date.Month;
        }

        private static void ThrowsInvalidCastException()
        {
            IGeometricShape circle = new Circle { Radius = 1 };
            Square square = ((Square)circle); // no compiler error
            var side = square.Side;
        }

        private static void SafeCasting()
        {
            IGeometricShape shape = new Circle { Radius = 1 };

            if (shape is Square)
            {
                Square square = ((Square)shape);
                var side = square.Side;
            }
            if (shape is Circle)
            {
                Circle circle = ((Circle)shape);
                var radius = circle.Radius;
            }
        }

        private static void NonExistentMembersViaObject()
        {
            string text = "String value";
            int textLength = text.Length;
            try
            {
                int textMonth = ((DateTime)(object)text).Month;
            }
            catch (InvalidCastException)
            { }

            DateTime date = DateTime.Now;
            try
            {
                int dateLength = ((string)(object)date).Length;
            }
            catch (InvalidCastException)
            { }
            int dateMonth = date.Month;
        }

        private static void NonGenericCollection()
        {
            var list = new ArrayList();
            list.Add("String value");
            int length = ((string)list[0]).Length;
            int month = ((DateTime)list[0]).Month; // no compiler error
        }

        private static void GenericCollection()
        {
            var list = new List<string>();
            list.Add("String value");
            int length = list[0].Length;
            //int month = list[0].Month; // compiler error
        }

        private static void Unsafe()
        {
            unsafe
            {
                long longValue = 42;
                long* longPointer = &longValue;
                double* doublePointer = (double*)longPointer;
                double doubleValue = *doublePointer;
            }
        }
    }
}
