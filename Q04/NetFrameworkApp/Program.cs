using CommonLibrary;
using System;

namespace NetFrameworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new Messages();
            Console.WriteLine(messages.Hello(".NET Framework"));
            Console.ReadLine();
        }
    }
}
