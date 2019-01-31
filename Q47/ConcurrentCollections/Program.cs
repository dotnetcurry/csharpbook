using System.Collections.Concurrent;

namespace ConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var concurrentDictionary = new ConcurrentDictionary<string, ExpensiveResource>();
            var newKey = "key";

            var resource = concurrentDictionary.GetOrAdd(newKey, key => ExpensiveResource.Create(key));


            var syncObject = new object();

            var success = concurrentDictionary.TryGetValue(newKey, out resource);
            if (!success)
            {
                lock (syncObject)
                {
                    // was the resource created by another thread after the check outside of lock?
                    if (!concurrentDictionary.TryGetValue(newKey, out resource))
                    {
                        resource = ExpensiveResource.Create(newKey);
                        concurrentDictionary.TryAdd(newKey, resource);
                    }
                }
            }

        }
    }
}
