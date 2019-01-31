using NetFrameworkLibrary;
using System;

namespace NetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new Messages();
            Console.WriteLine(messages.Hello(".NET Core"));
            Console.ReadLine();
        }
    }
}
