using System;
using System.Collections;

namespace CSharp2
{
    public class IntList : CollectionBase
    {
        public int this[int index]
        {
            get
            {
                return (int)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(int value)
        {
            return List.Add(value);
        }

        public int IndexOf(int value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, int value)
        {
            List.Insert(index, value);
        }

        public void Remove(int value)
        {
            List.Remove(value);
        }

        public bool Contains(int value)
        {
            return List.Contains(value);
        }

        protected override void OnValidate(Object value)
        {
            if (value.GetType() != typeof(System.Int32))
            {
                throw new ArgumentException("Value must be of type Int32.", "value");
            }
        }
    }

}
