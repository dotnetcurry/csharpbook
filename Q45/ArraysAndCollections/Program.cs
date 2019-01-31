using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 1, 2, 3, 4, 5 };
            var item2 = array[2];

            array[2] = 0;

            var newArray = InsertIntoArray(array, 2, 0);

            var list = new List<int> { 1, 2, 3, 4, 5 };
            list.Insert(2, 0);

            list.Add(6);

            list = new List<int>(25);

            var linkedList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

            var secondNode = linkedList.First.Next;
            linkedList.AddAfter(secondNode, 0);

            ICollection<int> collection = new List<int> { 1, 2, 3, 4, 5 };

            foreach (var item in collection)
            {
                // process items
            }

            collection = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

            foreach (var item in collection)
            {
                // process items
            }

        }

        public static T[] InsertIntoArray<T>(T[] array, int index, T item)
        {
            var newArray = new T[array.Length + 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }
            newArray[index] = item;
            for (int i = index + 1; i < newArray.Length; i++)
            {
                newArray[i] = array[i - 1];
            }
            return newArray;
        }

    }
}
