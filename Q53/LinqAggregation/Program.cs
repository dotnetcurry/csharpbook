using System;
using System.Linq;

namespace LinqAggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            Count();
            CountWithPredicate();
            NumericAggregation();
            NonNumericAggregation();
            Aggregate();
        }

        private static void Count()
        {
            var list = new[] { 1, 2, 3, 4, 5 };

            var count = list.Count(); // = 5
        }

        private static void CountWithPredicate()
        {
            var list = new[] { 1, 2, 3, 4, 5 };

            var count = list.Count(x => x % 2 == 0); // = 2
        }

        private static void NumericAggregation()
        {
            var list = new[] { 1, 2, 3, 4, 5 };

            var min = list.Min(); // = 1
            var max = list.Max(); // = 5
            var sum = list.Sum(); // = 15
            var average = list.Average(); // = 3
        }

        private static void NonNumericAggregation()
        {
            var persons = new[]
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 33 },
                new Person { FirstName = "Jane", LastName = "Roe", Age = 24 },
                new Person { FirstName = "Max", LastName = "Lane", Age = 42 }
            };

            var minAge = persons.Min(person => person.Age); // = 24
        }

        private static void Aggregate()
        {
            var persons = new[]
            {
                new Person { FirstName = "John", LastName = "Doe", Age = 33 },
                new Person { FirstName = "Jane", LastName = "Roe", Age = 24 },
                new Person { FirstName = "Max", LastName = "Lane", Age = 42 }
            };

            var youngestFullName = persons.Aggregate<Person, Person, string>(seed: null,
                (youngest, person) => youngest == null || person.Age < youngest.Age ? person : youngest,
                youngest => youngest != null ?
                    $"{youngest.FirstName} {youngest.LastName}" :
                    null); // = "Jane Roe"
        }
    }
}
