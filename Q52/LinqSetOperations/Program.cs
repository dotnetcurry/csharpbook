using System.Linq;

namespace LinqSetOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Union();
            Intersect();
            Except();
            Distinct();
            DistinctPerson();
            DistinctPersonCustomComparer();
        }

        private static void Union()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 3, 4, 5 };

            var query = list1.Union(list2); // = { 1, 2, 3, 4, 5 }
        }

        private static void Intersect()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 3, 4, 5 };

            var query = list1.Intersect(list2); // = { 3 }
        }

        private static void Except()
        {
            var list1 = new[] { 1, 2, 3 };
            var list2 = new[] { 3, 4, 5 };

            var query = list1.Except(list2); // = { 1, 2 }
        }

        private static void Distinct()
        {
            var list = new[] { 1, 2, 1, 3, 1, 4, 1, 5 };

            var query = list.Distinct(); // = { 1, 2, 3, 4, 5 }
        }

        private static void DistinctPerson()
        {
            var persons = new[]
            {
                new Person { Id = 1 },
                new Person { Id = 2 },
                new Person { Id = 1 }
            };

            var query = persons.Distinct(); // .Count() == 3
        }

        private static void DistinctPersonCustomComparer()
        {
            var persons = new[]
            {
                new Person { Id = 1 },
                new Person { Id = 2 },
                new Person { Id = 1 }
            };

            var query = persons.Distinct(new PersonComparer()); // .Count() == 2
        }
    }
}
