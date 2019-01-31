using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ImmutableCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var immutableList = new[] { 1, 2, 3, 4, 5 }.ToImmutableList();

            immutableList = ImmutableList<int>.Empty.AddRange(new[] { 1, 2, 3, 4, 5 });


            immutableList = immutableList.Add(6);

            immutableList = immutableList
                .Add(6)
                .Add(7)
                .Add(8);

            immutableList = immutableList.AddRange(new[] { 6, 7, 8 });


            for (var i = immutableList.Count - 1; i >= 0; i--)
            {
                if (immutableList[i] % 2 == 0)
                {
                    immutableList = immutableList.RemoveAt(i);
                }
            }

            immutableList = immutableList.RemoveAll(n => n % 2 == 0);


            immutableList = immutableList
                .Add(6)
                .Remove(2);

            var builder = immutableList.ToBuilder();
            builder.Add(6);
            builder.Remove(2);
            immutableList = builder.ToImmutable();


            var snapshots = new Stack<ImmutableList<int>>();

            snapshots.Push(immutableList);
            immutableList = immutableList.Add(6);

            immutableList = snapshots.Pop(); // undo: revert list to previous state


            var list = new List<int>(new[] { 1, 2, 3, 4, 5 });
            var mutableSnapshots = new Stack<List<int>>();

            mutableSnapshots.Push(list.ToList());
            list.Add(6);

            list = mutableSnapshots.Pop();

        }
    }
}
