using System;
using System.Linq;

namespace LinqStructure
{
    class Program
    {
        private static readonly Person[] persons = new[]
        {
            new Person("John", "Doe", 33),
            new Person("Jane", "Doe", 42),
            new Person("Johnny", "Doe", 13)
        };

        static void Main(string[] args)
        {
            LinqDataSource();
            LinqProjection();
            LinqFilter();
            LinqSorting();
        }

        private static void LinqDataSource()
        {
            var query =
                from person in persons
                select person;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        private static void LinqProjection()
        {
            var query =
                from person in persons
                select new { person.FirstName, person.LastName };

            foreach (var item in query)
            {
                Console.WriteLine($"FirstName: {item.FirstName}, LastName: {item.LastName}");
            }
        }

        private static void LinqFilter()
        {
            var query =
                from person in persons
                where person.Age > 21
                select new { person.FirstName, person.LastName };

            foreach (var item in query)
            {
                Console.WriteLine($"FirstName: {item.FirstName}, LastName: {item.LastName}");
            }
        }

        private static void LinqSorting()
        {
            var query =
                from person in persons
                where person.Age > 21
                orderby person.Age descending
                select new { person.FirstName, person.LastName };

            foreach (var item in query)
            {
                Console.WriteLine($"FirstName: {item.FirstName}, LastName: {item.LastName}");
            }
        }

    }
}
