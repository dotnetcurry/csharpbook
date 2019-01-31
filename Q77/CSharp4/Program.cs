using System;

namespace CSharp4
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
            WriteAfter("Sample text");
            WriteAfter("Sample text", true);
            WriteAfter("Sample text", false, true);
            WriteAfter("Sample text", bold: true);
        }

        private static  void WriteAfter(string text, bool centered = false, bool bold = false)
        {
            // output text
        }


        private static void Before()
        {
            WriteBefore("Sample text");
            WriteBefore("Sample text", true);
            WriteBefore("Sample text", false, true);
            WriteBeforeBold("Sample text", true);
        }

        private static void WriteBefore(string text, bool centered, bool bold)
        {
            // output text
        }

        private static void WriteBefore(string text, bool centered)
        {
            WriteBefore(text, centered, false);
        }

        private static void WriteBefore(string text)
        {
            WriteBefore(text, false);
        }

        private static void WriteBeforeBold(string text, bool bold)
        {
            WriteBefore(text, false, bold);
        }

    }
}
