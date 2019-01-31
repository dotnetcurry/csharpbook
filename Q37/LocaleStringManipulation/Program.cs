using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace LocaleStringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var date = new DateTime(2018, 9, 1);
            var enDate = date.ToString("d"); // = "9/1/2018"

            var slCulture = CultureInfo.GetCultureInfo("sl-SI");
            var slDate = date.ToString("d", slCulture); // = "1. 09. 2018"

            var pi = 3.14;
            var enPi = pi.ToString(); // = "3.14"
            var slPi = pi.ToString(slCulture); // = "3,14"

            var temperature = 21.5;
            var timestamp = new DateTime(2018, 9, 1, 16, 15, 30);
            var formatString = "Temperature: {0} °C at {1}";
            var enFormatted = string.Format(formatString, temperature, timestamp); // = "Temperature: 21.5 °C at 9/1/2018 4:15:30 PM"
            var slFormatted = string.Format(slCulture, formatString, temperature, timestamp); // = "Temperature: 21,5 °C at 1. 09. 2018 16:15:30"

            var stringNumber = "3,14";
            Double.TryParse(stringNumber, out var enNumber); // = 314
            Double.TryParse(stringNumber, NumberStyles.Any, slCulture, out var slNumber); // = 3.14

            var doubleS = "ss";
            var eszett = "ß";
            var equalOrdinal = string.Equals(doubleS, eszett); // = false
            var equalCulture = string.Equals(doubleS, eszett, StringComparison.CurrentCulture); // = true

            var czCulture = CultureInfo.GetCultureInfo("cs-CZ");
            var words = new[] { "channel", "double" };
            var ordinalSortedSet = new SortedSet<string>(words); // = { "channel", "double" }
            var cultureSortedSet = new SortedSet<string>(words, StringComparer.Create(czCulture, ignoreCase: true)); // = { "double", "channel" }

            var trCulture = CultureInfo.GetCultureInfo("tr-TR");
            var lowerCaseI = "i";
            var upperCaseIen = lowerCaseI.ToUpper(); // = "I"
            var upperCaseItr = lowerCaseI.ToUpper(trCulture); // = "İ"
        }
    }
}
