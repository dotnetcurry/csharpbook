using System;
using System.Collections.Generic;

namespace AbstractClasses
{
    class SampleClass : ISampleInterface
    {
        public int Method(int arg)
        {
            OnMethodInvoked();
            return arg * 2;
        }

        public int Property { get; set; }

        public event EventHandler<EventArgs> MethodInvoked;

        private void OnMethodInvoked()
        {
            MethodInvoked?.Invoke(this, new EventArgs());
        }

        private Dictionary<int, string> indexerDictionary = new Dictionary<int, string>();
        public string this[int index]
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
