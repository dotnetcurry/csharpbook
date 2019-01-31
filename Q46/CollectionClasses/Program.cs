using System;
using System.Collections.Generic;

namespace CollectionClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> enumerable = new List<int>() { 1, 2, 3, 4, 5 };

            foreach (var item in enumerable)
            {
                // process items
            }


            ICollection<int> collection = new List<int>() { 1, 2, 3, 4, 5 };

            var count = collection.Count;
            collection.Add(6);
            collection.Remove(2);
            collection.Clear();


            IList<int> list = new List<int> { 1, 2, 3, 4, 5 };

            var item2 = list[2]; // item2 = 3
            list[2] = 6; // list = { 1, 2, 6, 4, 5 }

            list.Insert(2, 0); // list = { 1, 2, 0, 6, 4, 5 }
            list.RemoveAt(2); // list = { 1, 2, 6, 4, 5 }


            ISet<int> set = new HashSet<int> { 1, 2, 3, 4, 5 };

            var added = set.Add(0);


            set = new HashSet<int> { 1, 2, 3, 4, 5 };

            set.UnionWith(new[] { 5, 6 });              // set = { 1, 2, 3, 4, 5, 6 }
            set.IntersectWith(new[] { 3, 4, 5, 6, 7 }); // set = { 3, 4, 5, 6 }
            set.ExceptWith(new[] { 6, 7 });             // set = { 3, 4, 5 }
            set.SymmetricExceptWith(new[] { 4, 5, 6 }); // set = { 3, 6 }


            set = new HashSet<int> { 1, 2, 3, 4, 5 };

            var isSubset = set.IsSubsetOf(new[] { 1, 2, 3, 4, 5 }); // = true
            var isProperSubset = set.IsProperSubsetOf(new[] { 1, 2, 3, 4, 5 }); // = false
            var isSuperset = set.IsSupersetOf(new[] { 1, 2, 3, 4, 5 }); // = true
            var isProperSuperset = set.IsProperSupersetOf(new[] { 1, 2, 3, 4, 5 }); // = false
            var equals = set.SetEquals(new[] { 1, 2, 3, 4, 5 }); // = true
            var overlaps = set.Overlaps(new[] { 5, 6 }); // = true


            IDictionary<string, string> dictionary = new Dictionary<string, string>
            {
                ["one"] = "ena",
                ["two"] = "dva",
                ["three"] = "tri",
                ["four"] = "štiri",
                ["five"] = "pet"
            };

            var value = dictionary["two"];
            dictionary["zero"] = "nič";

            try
            {
                dictionary.Add("zero", "nič");
            }
            catch (ArgumentException)
            { }

            var contains = dictionary.ContainsKey("two");
            var removed = dictionary.Remove("two");

            ICollection<string> keys = dictionary.Keys;
            ICollection<string> values = dictionary.Values;


            var queue = new Queue<int>(new[] { 1, 2, 3, 4, 5 });

            queue.Enqueue(6);
            var dequeuedItem = queue.Dequeue();

            var peekedItem = queue.Peek();


            var stack = new Stack<int>(new[] { 1, 2, 3, 4, 5 });

            stack.Push(6);
            var poppedItem = stack.Pop();
            peekedItem = stack.Peek();
        }
    }
}
