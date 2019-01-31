using System.Collections.Generic;
using System.Threading;

namespace ConcurrentCollections
{
    public class DictionaryWithReaderWriterLock<TKey, TValue>
    {
        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();
        private readonly Dictionary<TKey, TValue> dictionary;

        public DictionaryWithReaderWriterLock()
        {
            dictionaryLock = new ReaderWriterLockSlim();
            dictionary = new Dictionary<TKey, TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                dictionaryLock.EnterReadLock();
                try
                {
                    return dictionary[key];
                }
                finally
                {
                    dictionaryLock.ExitReadLock();
                }
            }
            set
            {
                dictionaryLock.EnterWriteLock();
                try
                {
                    dictionary[key] = value;
                }
                finally
                {
                    dictionaryLock.ExitWriteLock();
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            dictionaryLock.EnterWriteLock();
            try
            {
                dictionary.Add(key, value);
            }
            finally
            {
                dictionaryLock.ExitWriteLock();
            }
        }
    }

}
