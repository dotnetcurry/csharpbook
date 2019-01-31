using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace GenericCodeImprovements
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList();
            StringCollection();
            GenericList();
            Performance();
            Linq();
        }

        private static void ArrayList()
        {
            var list = new ArrayList();
            list.Add("one");
            list.Add(2); // will compile

            string first = (string)list[0];

            try
            {
                string second = (string)list[1]; // throws InvalidCastException
            }
            catch (InvalidCastException)
            { }
        }

        private static void StringCollection()
        {
            var list = new StringCollection();
            list.Add("one");
            //list.Add(2); // will not compile

            string first = list[0]; // no cast necessary
        }

        private static void GenericList()
        {
            var list = new List<string>();
            list.Add("one");
            //list.Add(2); // will not compile

            string first = list[0]; // no cast necessary
        }

        private static void Performance()
        {
            var stopwatch = new Stopwatch();
            var values = new[] { 0, 5, 4, 1, 9, 7, 8, 6, 3, 2 };

            var list = new ArrayList(values);

            stopwatch.Start();
            list.Sort();
            stopwatch.Stop();
            Console.WriteLine($"ArrayList: {stopwatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)} ms");

            stopwatch.Reset();

            var genericList = new List<int>(values);
            stopwatch.Start();
            genericList.Sort();
            stopwatch.Stop();
            Console.WriteLine($"List<T>: {stopwatch.Elapsed.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)} ms");
        }

        private static void Linq()
        {
            var numbers = new[] { 1, 2, 3 };
            var asStrings = numbers.Select(number => number.ToString()); // { "1", "2", "3" }
        }
    }
}
