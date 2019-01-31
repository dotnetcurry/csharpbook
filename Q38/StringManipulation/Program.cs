using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "a";
            text += "b";

            var jsonLiteral = "{" +
                "\"id\": 1," +
                "\"firstName\": \"John\"," +
                "\"lastName\": \"Doe\"," +
                "\"gender\": \"MALE\"" +
            "}";

            var numbers = new[] { "1", "2", "3" };
            var concatenated = numbers[0] + numbers[1] + numbers[2];

            concatenated = string.Empty;
            foreach (var number in numbers)
            {
                concatenated += number;
            }

            concatenated = string.Concat(numbers);

            concatenated = string.Join(", ", numbers);

            var values = Enumerable.Range(0, 10000);
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            
            concatenated = string.Empty;
            foreach (var value in values)
            {
                concatenated += value;
                concatenated += concatenated.Length;
            }

            stopwatch.Stop();
            Console.WriteLine($"String concatenation: {stopwatch.ElapsedMilliseconds} milliseconds");

            stopwatch.Reset();
            stopwatch.Start();


            var stringBuilder = new StringBuilder(50000);
            foreach (var value in values)
            {
                stringBuilder.Append(value);
                stringBuilder.Append(stringBuilder.Length);
            }
            var fromStringBuilder = stringBuilder.ToString();

            stopwatch.Stop();
            Console.WriteLine($"StringBuiler.Append: {stopwatch.ElapsedMilliseconds} milliseconds");

        }
    }
}
