using EnumerationTypes.BinaryLiterals;

namespace EnumerationTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            MagicNumber();
            DayWithName();
            Casting();
            Weekend();
            HasFlag();
            ToStringWithFlags();
            Parsing();
        }

        private static void MagicNumber()
        {
            var currentDay = 7;

            if (currentDay == 7) // Sunday as a magic number
            {
                // ...
            }
        }

        private static void DayWithName()
        {
            var currentDay = DayOfWeek.Sunday;

            if (currentDay == DayOfWeek.Sunday) // Sunday as a day with a name
            {
                // ...
            }
        }

        private static void Casting()
        {
            int asNumeric = (int)DayOfWeek.Sunday;
            DayOfWeek asEnumeration = (DayOfWeek)100; // no exception will be thrown
        }

        private static void Weekend()
        {
            var day = DayOfWeek.Saturday;

            var weekend = DayOfWeek.Saturday | DayOfWeek.Sunday; // output = 0b110_0000
            var isDayInWeekend = (weekend & day) == day;
        }

        private static void HasFlag()
        {
            var day = DayOfWeek.Saturday;

            var isInWeekend = DayOfWeek.Weekend.HasFlag(day);
        }

        private static void ToStringWithFlags()
        {
            var firstTwoDays = DayOfWeek.Monday | DayOfWeek.Tuesday;
            System.Console.WriteLine(firstTwoDays.ToString());
        }

        private static void Parsing()
        {
            DayOfWeek parsed;
            System.Enum.TryParse("Monday, Tuesday", out parsed);
        }
    }
}
