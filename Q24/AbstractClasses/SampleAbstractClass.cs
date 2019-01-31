using System;
using System.Collections.Generic;

namespace AbstractClasses
{
    abstract class SampleAbstractClass : ISampleInterface
    {
        public abstract int MethodImplementation(int arg);
        public int Method(int arg)
        {
            OnMethodInvoked();
            return MethodImplementation(arg);
        }

        public virtual int Property { get; set; }

        public event EventHandler<EventArgs> MethodInvoked;
        protected virtual void OnMethodInvoked()
        {
            MethodInvoked?.Invoke(this, new EventArgs());
        }

        protected Dictionary<int, string> indexerDictionary = new Dictionary<int, string>();
        public virtual string this[int index]
        {
            get
            {
                return indexerDictionary[index];
            }
            set
            {
                indexerDictionary[index] = value;
            }
        }
    }

}
