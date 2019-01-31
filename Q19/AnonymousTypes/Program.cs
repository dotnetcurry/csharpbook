using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            AnonymousPerson();
            AggregatedPerson();
            AggregatedPersonExplicit();
            AnonymousTypeArray();
            Linq();
        }

        private static void AnonymousPerson()
        {
            var person = new
            {
                FirstName = "John",
                LastName = "Doe"
            };

            Console.WriteLine(person.ToString());
            // Output: { FirstName = John, LastName = Doe }
        }

        private static void AggregatedPerson()
        {
            var person = new SourcePerson
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new SourceAddress { Country = "USA" },
                Father = new SourcePerson { FirstName = "Jack" }
            };

            var aggregatedPerson = new
            {
                person.FirstName,
                person.LastName,
                person.Address.Country,
                FatherName = person.Father.FirstName
            };
        }

        private static void AggregatedPersonExplicit()
        {
            var person = new SourcePerson
            {
                FirstName = "John",
                LastName = "Doe",
                Address = new SourceAddress { Country = "USA" },
                Father = new SourcePerson { FirstName = "Jack" }
            };

            var aggregatedPerson = new
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Country = person.Address.Country,
                FatherName = person.Father.FirstName
            };
        }

        private static void AnonymousTypeArray()
        {
            var person1 = new
            {
                FirstName = "Anders",
                LastName = "Hejlsberg"
            };
            var person2 = new
            {
                FirstName = "Mads",
                LastName = "Torgersen"
            };
            var persons = new[]
            {
                person1,
                person2
            };
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        private static void Linq()
        {
            var persons = new List<SourcePerson>();

            var personNames =
                from p in persons
                select new { p.FirstName, p.LastName };
        }
    }
}

