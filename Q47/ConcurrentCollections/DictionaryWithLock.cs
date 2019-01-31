using System.Collections.Generic;

namespace ConcurrentCollections
{
    public class DictionaryWithLock<TKey, TValue>
    {
        private readonly object syncObject;
        private readonly Dictionary<TKey, TValue> dictionary;

        public DictionaryWithLock()
        {
            syncObject = new object();
            dictionary = new Dictionary<TKey, TValue>();
        }

        public TValue this[TKey key]
        {
            get
            {
                lock (syncObject)
                {
                    return dictionary[key];
                }
            }
            set
            {
                lock (syncObject)
                {
                    dictionary[key] = value;
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            lock (syncObject)
            {
                dictionary.Add(key, value);
            }
        }
    }

}
