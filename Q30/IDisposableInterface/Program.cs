using System;
using System.IO;
using System.Xml;

namespace IDisposableInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            UsingIDisposable();
            ManualIDisposable();
            DisposeMultipleInstances();
            DisposeMultipleDifferentInstances();
        }

        private static void UsingIDisposable()
        {
            var filename = "TextFile1.txt";

            using (var reader = new StreamReader(filename))
            {
                var contents = reader.ReadToEnd();
                Console.WriteLine($"Read {contents.Length} characters from file.");
            }
        }
        private static void ManualIDisposable()
        {
            var filename = "TextFile1.txt";

            {
                var reader = new StreamReader(filename);
                try
                {
                    var contents = reader.ReadToEnd();
                    Console.WriteLine($"Read {contents.Length} characters from file.");
                }
                finally
                {
                    if (reader != null)
                    {
                        ((IDisposable)reader).Dispose();
                    }
                }
            }
        }

        private static void DisposeMultipleInstances()
        {
            var filename1 = "TextFile1.txt";
            var filename2 = "TextFile2.txt";

            using (StreamReader reader1 = new StreamReader(filename1),
                                reader2 = new StreamReader(filename2))
            {
                // process the files
            }
        }

        private static void DisposeMultipleDifferentInstances()
        {
            var filename1 = "TextFile1.txt";
            var filename2 = "TextFile2.txt";

            using (var reader1 = new StreamReader(filename1))
            using (var reader2 = XmlReader.Create(filename2))
            {
                // process the files
            }
        }
    }
}
