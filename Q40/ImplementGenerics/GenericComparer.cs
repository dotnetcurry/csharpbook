using System.Collections.Generic;
using System.Linq;

namespace ImplementGenerics
{
    public class GenericComparer<T>
    {
        private readonly T compareWith;

        public GenericComparer(T compareWith)
        {
            this.compareWith = compareWith;
        }

        public int CountDifferent(IEnumerable<T> vals)
        {
            return vals.Count(val => !object.Equals(val, compareWith));
        }

        public int CountEqual(IEnumerable<T> numbers)
        {
            return numbers.Count(val => object.Equals(val, compareWith));
        }
    }

    public static class GenericComparer
    {
        public static GenericComparer<T> Create<T>(T compareWith)
        {
            return new GenericComparer<T>(compareWith);
        }
    }
}
