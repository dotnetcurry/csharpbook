using System.Collections.Generic;

namespace LinqSetOperations
{
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Id.GetHashCode();
        }
    }

}
