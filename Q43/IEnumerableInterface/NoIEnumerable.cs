using System.Collections.Generic;

namespace IEnumerableInterface
{
    public class NoIEnumerable<T>
    {
        private readonly IEnumerable<T> enumerable;

        public NoIEnumerable(IEnumerable<T> enumerable)
        {
            this.enumerable = enumerable;
        }

        public IEnumerator<T> GetEnumerator() => enumerable.GetEnumerator();
    }

}
