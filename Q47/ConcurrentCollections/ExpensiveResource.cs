using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrentCollections
{
    public class ExpensiveResource
    {
        private ExpensiveResource()
        { }

        public static ExpensiveResource Create(string key)
        {
            return new ExpensiveResource();
        }
    }
}
