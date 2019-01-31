using System;
using System.Collections.Generic;

namespace ParametersByReference
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = 1;
            var point = new Point(1, 1); // Point is a struct
            PassValueByValue(number, point);
            // number = 1
            // point.X = 1, point.Y = 1

            var list = new List<int>();
            var str = "original";
            PassReferenceByValue(list, str);
            // list = { 1 }
            // str = "original"

            number = 1;
            point = new Point(1, 1);
            PassValueByReference(ref number, ref point);
            // number = 2
            // point.X = 2, point.Y = 1

            list = new List<int>();
            str = "original";
            PassReferenceByReference(ref list, ref str);
            // list = { 2 }
            // str = "modified"

            number = 1;
            point = new Point(1, 1);
            PassValueAsOut(out number, out point);
            // number = 2
            // point.X = 2, point.Y = 1

            list = new List<int>();
            str = "original";
            PassReferenceAsOut(out list, out str);
            // list = { 2 }
            // str = "modified"
        }

        private static void PassValueByValue(int number, Point point)
        {
            number += 1;
            point.X += 1;
        }

        private static void PassReferenceByValue(List<int> list, string str)
        {
            list.Add(1);
            list = new List<int>(new[] { 2 });
            str = "modified";
        }

        private static void PassValueByReference(ref int number, ref Point point)
        {
            number += 1;
            point.X += 1;
        }

        private static void PassReferenceByReference(ref List<int> list, ref string str)
        {
            list.Add(1);
            list = new List<int>(new[] { 2 });
            str = "modified";
        }

        private static void PassValueAsOut(out int number, out Point point)
        {
            // number += 1; // will not compile
            number = 2;
            // point.X += 1; // will not compile
            point = new Point(2, 1);
        }

        private static void PassReferenceAsOut(out List<int> list, out string str)
        {
            // list.Add(1); // will not compile
            list = new List<int>(new[] { 2 });
            str = "modified";
        }

        void OverloadedMethod(int number)
        {
            // method implementation
        }

        void OverloadedMethod(ref int number)
        {
            // method implementation
        }

        // will not compile
        // void OverloadedMethod(out int number)
        // {
        //     // method implementation
        // }
    }
}
