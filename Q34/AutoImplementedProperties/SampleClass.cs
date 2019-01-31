using System;

namespace AutoImplementedProperties
{
    public class SampleClass
    {
        public int publicField = 42;

        private int regularPropertyValue = 42;
        public int RegularProperty
        {
            get
            {
                return regularPropertyValue;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                regularPropertyValue = value;
            }
        }

        public int AutoImplementedProperty { get; protected set; } = 42;

        public int ReadOnlyAutoImplementedProperty { get; } = 42;

        public SampleClass()
        {
            AutoImplementedProperty = 42;
        }

        public SampleClass(int value)
        {
            ReadOnlyAutoImplementedProperty = value;
        }

        public void Method()
        {
            //ReadOnlyAutoImplementedProperty = -1; // won't compile
        }

    }

}
