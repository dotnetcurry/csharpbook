namespace ValueAndReferenceTypes
{
    class ValueTypes
    {
        public static void Method1()
        {
            var a = 1;
            Method2(a);
        }

        static void Method2(int a)
        {
            a = 2;
        }
    }
}
