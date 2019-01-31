namespace ValueAndReferenceTypes
{
    class ReferenceTypes
    {
        public static void Method1()
        {
            var a = "1";
            Method2(a);
        }

        static void Method2(string a)
        {
            a = "2";
        }
    }
}
