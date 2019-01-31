using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

namespace InterpolatedStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeFormatting();
            InterpolatedStrings();
            InterpolatedStringsWithExpressions();
            InterpolatedStringsWithBraces();
            InterpolatedStringsWithExcapeSequences();
            VerbatimStringLiterals();
            VerbatimInterpolatedStrings();
            InterpolatedStringsWithAlignmentAndFormatting();
            InterpolatedStringsWithCulture();
            EfFromSql();
            EfInterpolated();
            EfInjection();
            LocalizedCompositeFormatting();
            LocalizedInterpolatedString();
        }

        private static void CompositeFormatting()
        {
            var name = "John";
            var formatted = string.Format("Hello, {0}!", name); // = "Hello, John!"
        }

        private static void InterpolatedStrings()
        {
            var name = "John";
            var formatted = $"Hello, {name}!"; // = "Hello, John!"
        }

        private static void InterpolatedStringsWithExpressions()
        {
            var a = 4;
            var b = 2;
            var formatted = $"{a} + {b} = {a + b}"; // = "4 + 2 = 6"
        }

        private static void InterpolatedStringsWithBraces()
        {
            var A = new[] { 1, 2, 3, 4, 5 };
            var formatted = $"{nameof(A)} = {{ {string.Join(", ", A)} }}"; // = "A = { 1, 2, 3, 4, 5 }"
        }

        private static void InterpolatedStringsWithExcapeSequences()
        {
            var a = 3.5;
            var b = 12.25;
            var formatted = $"{a}\n+ {b}\n= {a + b}";
        }

        private static void VerbatimStringLiterals()
        {
            var regular = "File path:\r\n\"C:\\Temp\"";
            var verbatim = @"File path:
""C:\Temp""";
        }

        private static void VerbatimInterpolatedStrings()
        {
            var a = 3.5;
            var b = 12.25;
            var formatted = $@"{a}
+ {b}
= {a + b}";
        }

        private static void InterpolatedStringsWithAlignmentAndFormatting()
        {
            var a = 3.5;
            var b = 12.25;
            var formatted = $"  {a,5:0.00}\n+ {b,5:0.00}\n= {a + b,5:0.00}";

            var n = 3.5;
            var alignmentAndFormatting = $"{n,5:0.00}"; // = " 3.50"
            var alignmentOnly = $"{n,5}"; // = "  3.5"
            var formattingOnly = $"{n:0.00}"; // = "3.50"
            var neither = $"{n}"; // = "3.5"
        }

        private static void InterpolatedStringsWithCulture()
        {
            var culture = CultureInfo.GetCultureInfo("sl-SI");
            var a = 3.5;
            var b = 12.25;
            FormattableString formattableString = $"  {a,5:0.00}\n+ {b,5:0.00}\n= {a + b,5:0.00}";
            var formatted = formattableString.ToString(culture); // = "   3,50\n+ 12,25\n= 15,75"
        }

        private static void EfFromSql()
        {
            using (var context = new EFContext())
            {
                var param = "Doe";
                var query = context.Persons.FromSql($"SELECT * FROM Persons WHERE LastName = {param};");
            }
        }

        private static void EfInterpolated()
        {
            using (var context = new EFContext())
            {
                var param = "Doe";
                var sql = $"SELECT * FROM Persons WHERE LastName = {param};";
                var query = context.Persons.FromSql(sql);
            }
        }

        private static void EfInjection()
        {
            using (var context = new EFContext())
            {
                var param = "Doe'; DROP TABLE Persons; --";
                var sql = $"SELECT * FROM Persons WHERE LastName = '{param}';";
                var query = context.Persons.FromSql(sql);
            }
        }

        private static void LocalizedCompositeFormatting()
        {
            var name = "John";
            // Properties.Strings.Localized = "Hello, {0}!"
            var formatted = string.Format(Properties.Strings.Localized, name); // = "Hello, John!"
        }

        private static void LocalizedInterpolatedString()
        {
            var name = "John";
            FormattableString formattableString = $"Hello, {name}!";
            // formattableString.Format = "Hello, {0}!"
            // formattableString.GetArguments() = [ name ]
            var formatted = string.Format(GetTranslation(formattableString.Format),
                formattableString.GetArguments()); // = "Hello, John!"
        }

        private static string GetTranslation(string original)
        {
            // return the translation based on the content of the original string
            return original;
        }

    }
}
