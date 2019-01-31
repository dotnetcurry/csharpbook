using System.Collections.Generic;
using System.Linq;

namespace ImplementGenerics
{
    public class IntComparer
    {
        private readonly int compareWith;

        public IntComparer(int compareWith)
        {
            this.compareWith = compareWith;
        }

        public int CountDifferent(IEnumerable<int> numbers)
        {
            return numbers.Count(number => number != compareWith);
        }

        public int CountEqual(IEnumerable<int> numbers)
        {
            return numbers.Count(number => number == compareWith);
        }
    }

}
