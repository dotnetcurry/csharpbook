using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementIEnumerable
{
    public class ArrayWrapper<T> : IEnumerable<T>
    {
        private readonly T[] array;

        public ArrayWrapper(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            this.array = array;
        }

        public IEnumerator<T> GetEnumerator() => new ArrayEnumerator(array);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class ArrayEnumerator : IEnumerator<T>
        {
            private readonly T[] array;

            public ArrayEnumerator(T[] array)
            {
                this.array = array;
            }

            private int index = -1;

            public T Current => index >= 0 && index < array.Length ? array[index] : default(T);

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < array.Length;
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            { }

        }
    }
}
