using System.Collections;
using System.Collections.Generic;

namespace CSharp2
{
    class Program
    {
        static void Main(string[] args)
        {
            After();
            Before();
        }

        private static void After()
        {
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
        }

        private static void Before()
        {
            {
                ArrayList numbers = new ArrayList();
                numbers.Add(1);
                numbers.Add(2);
                numbers.Add(3);

                int sum = 0;
                for (int i = 0; i < numbers.Count; i++)
                {
                    sum += (int)numbers[i];
                }
            }

            {
                IntList numbers = new IntList();
                numbers.Add(1);
                numbers.Add(2);
                numbers.Add(3);

                int sum = 0;
                for (int i = 0; i < numbers.Count; i++)
                {
                    sum += numbers[i];
                }
            }
        }
    }
}
