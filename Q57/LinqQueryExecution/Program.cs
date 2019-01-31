using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryExecution
{
    class Program
    {
        private static readonly List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

        static void Main(string[] args)
        {
            EnumerableLambda();
            EnumerableAnonymousMethod();
            EnumerableNamedMethod();
            QueryableLambda();
            QueryableAnonymousMethod();
            QueryableNamedMethod();
        }

        private static void EnumerableLambda()
        {
            var query = list.Where(item => item < 3);
        }

        private static void EnumerableAnonymousMethod()
        {
            var query = list.Where(delegate (int item)
            {
                return item < 3;
            });
        }

        private static bool LessThan3(int val)
        {
            return val < 3;
        }

        private static void EnumerableNamedMethod()
        {
            var query = list.Where(LessThan3);
        }

        private static void QueryableLambda()
        {
            using (var context = new PersonContext())
            {
                var query = context.Persons.Where(person => person.Age > 21);
            }
        }

        private static void QueryableAnonymousMethod()
        {
            using (var context = new PersonContext())
            {
                var query = context.Persons.Where(delegate (Person person)
                {
                    return person.Age > 21;
                });
            }
        }

        private static bool OlderThan21(Person person)
        {
            return person.Age > 21;
        }


        private static void QueryableNamedMethod()
        {
            using (var context = new PersonContext())
            {
                var query = context.Persons.Where(OlderThan21);
            }
        }
    }
}
