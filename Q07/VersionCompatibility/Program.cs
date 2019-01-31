using System;
using System.Runtime.CompilerServices;

namespace VersionCompatibility
{
    class Program
    {
        public static void LogMessage(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            // logging implementation
            Console.WriteLine($"{memberName} ({sourceFilePath}, {sourceLineNumber}): {message}");
        }

        static void Main(string[] args)
        {
            LogMessage("Hello");
            Console.ReadLine();
        }
    }
}
