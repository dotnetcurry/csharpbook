namespace AutoImplementedProperties
{
    public class DerivedClass : SampleClass
    {
        public DerivedClass()
        {
            RegularProperty = -1; // will throw exception
        }
    }

}
