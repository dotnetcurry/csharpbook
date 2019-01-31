using System.Linq;

namespace LinqMethodSyntax
{
    class Program
    {
        private static readonly Person[] persons = new[]
        {
            new Person("John", "Doe", 33),
            new Person("Jane", "Doe", 42),
            new Person("Johnny", "Doe", 13)
        };

        private static readonly Room[] rooms = new[]
        {
            new Room() { Number = 101, Guests = new[]
            {
                new Person("John", "Doe", 33)
            } },
            new Room() { Number = 102, Guests = new[]
            {
                new Person("Jane", "Doe", 42),
                new Person("Johnny", "Doe", 13)
            } }
        };

        static void Main(string[] args)
        {
            SelectMethod();
            SelectQuery();
            WhereMethod();
            OrderByMethod();
            OrderByQuery();
            OrderByMethodReordered();
            OrderByMethodMissingProperty();
            QueryRequiresSelect();
            MethodWithSelect();
            MethodWithoutSelect();
            TakeMethod();
            SkipMethod();
            SkipQuery();
            AnyMethod();
            AnyMethodNoParam();
            AllMethod();
            SelectNestedLoops();
            SelectManySingleLoop();
            SelectManyWhere();
        }

        private static void SelectMethod()
        {
            var query = persons.Select(person => new { person.FirstName, person.LastName });
        }

        private static void SelectQuery()
        {
            var query =
                from person in persons
                select new { person.FirstName, person.LastName };
        }

        private static void WhereMethod()
        {
            var query = persons
                .Where(person => person.Age > 21)
                .Select(person => new { person.FirstName, person.LastName });
        }

        private static void OrderByMethod()
        {
            var query = persons
                .Where(person => person.Age > 21)
                .OrderByDescending(person => person.Age)
                .Select(person => new { person.FirstName, person.LastName });
        }

        private static void OrderByQuery()
        {
            var query =
                from person in persons
                where person.Age > 21
                orderby person.Age descending
                select new { person.FirstName, person.LastName };
        }

        private static void OrderByMethodReordered()
        {
            var query = persons
                .Select(person => new { person.FirstName, person.LastName, person.Age })
                .OrderByDescending(person => person.Age)
                .Where(person => person.Age > 21);
        }

        private static void OrderByMethodMissingProperty()
        {
            //var query = persons
            //    .Select(person => new { person.FirstName, person.LastName })
            //    .OrderByDescending(person => person.Age) // won't compile
            //    .Where(person => person.Age > 21);
        }

        private static void QueryRequiresSelect()
        {
            var query =
                from person in persons
                where person.Age > 21
                select person;
        }

        private static void MethodWithSelect()
        {
            var query = persons
                .Where(person => person.Age > 21)
                .Select(person => person);
        }

        private static void MethodWithoutSelect()
        {
            var query = persons.Where(person => person.Age > 21);
        }

        private static void TakeMethod()
        {
            var query = persons
                .Where(person => person.Age > 21)
                .OrderByDescending(person => person.Age)
                .Take(1)
                .Select(person => new { person.FirstName, person.LastName });
        }

        private static void SkipMethod()
        {
            var query = persons
                .Where(person => person.Age > 21)
                .OrderByDescending(person => person.Age)
                .Skip(10)
                .Take(10)
                .Select(person => new { person.FirstName, person.LastName });
        }

        private static void SkipQuery()
        {
            var query = (
                from person in persons
                where person.Age > 21
                orderby person.Age descending
                select new { person.FirstName, person.LastName }
            ).Skip(10).Take(10);
        }

        private static void AnyMethod()
        {
            var any = persons.Any(person => person.Age > 21);
        }

        private static void AnyMethodNoParam()
        {
            var notEmpty = persons.Any();
        }

        private static void AllMethod()
        {
            var all = persons.All(person => person.Age > 21);
        }

        private static void SelectNestedLoops()
        {
            var guests = rooms.Select(room => room.Guests);

            foreach (var roomGuests in guests)
            {
                foreach (var guest in roomGuests)
                {
                    // process guest
                }
            }
        }

        private static void SelectManySingleLoop()
        {
            var guests = rooms.SelectMany(room => room.Guests);

            foreach (var guest in guests)
            {
                // process guest
            }
        }

        private static void SelectManyWhere()
        {
            var guestsOfAge = rooms
                .SelectMany(room => room.Guests)
                .Where(guest => guest.Age > 21);
        }
    }
}
