using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableVsEnumerable
{
    static class RepositoryExtensions
    {
        public static IEnumerable<Person> GetPersonsExternalContext(this PersonContext context, Expression<Func<Person, bool>> predicate)
        {
            return context.Persons.Where(predicate);
        }
    }
}
