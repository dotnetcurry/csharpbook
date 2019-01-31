using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableVsEnumerable
{
    class Program
    {
        public static PersonContext Context { get; set; }

        public static IQueryable<Person> GetPersonsQueryable(Expression<Func<Person, bool>> predicate)
        {
            return Context.Persons.Where(predicate);
        }

        public static IEnumerable<Person> GetPersonsEnumerable(Expression<Func<Person, bool>> predicate)
        {
            return Context.Persons.Where(predicate);
        }

        public static IEnumerable<Person> GetPersonsEnumerable(Expression<Func<Person, bool>> predicate, int maxResults)
        {
            return Context.Persons
                .Where(predicate)
                .Take(maxResults);
        }
        public static IEnumerable<Person> GetPersonsInternalContext(Expression<Func<Person, bool>> predicate)
        {
            using (var context = new PersonContext())
            {
                return context.Persons.Where(predicate);
            }
        }

        public static IEnumerable<Person> GetPersonsInternalContextFixed(Expression<Func<Person, bool>> predicate)
        {
            using (var context = new PersonContext())
            {
                foreach (var item in context.Persons.Where(predicate))
                {
                    yield return item;
                }
            }
        }


        static void Main(string[] args)
        {
            Context = new PersonContext();

            QueryableQuery();
            EnumerableQuery();
            ComposedEnumerableQuery();
            EnumerableToQueryable();
            DisposedContext();
            FixedDisposedContext();
        }

        private static void QueryableQuery()
        {
            var query = GetPersonsQueryable(person => person.Age > 21)
                .Where(person => person.Name == "Jane");
        }

        private static void EnumerableQuery()
        {
            var query = GetPersonsEnumerable(person => person.Age > 21)
                .Where(person => person.Name == "Jane");
        }

        private static void ComposedEnumerableQuery()
        {
            var query = GetPersonsEnumerable(person => person.Age > 21 && person.Name == "Jane");
        }

        private static void EnumerableToQueryable()
        {
            IQueryable<Person> queryableList = new List<Person>().AsQueryable();
        }

        private static void DisposedContext()
        {
            try
            {
                var result = GetPersonsInternalContext(person => person.Age > 21).ToList();
            }
            catch (ObjectDisposedException)
            { }
        }

        private static void FixedDisposedContext()
        {
            var result = GetPersonsInternalContextFixed(person => person.Age > 21).ToList();
        }
    }
}
