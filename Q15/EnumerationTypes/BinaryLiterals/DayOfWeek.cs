using System;

namespace EnumerationTypes.BinaryLiterals
{
    [Flags]
    public enum DayOfWeek
    {
        None = 0b0,
        Monday = 0b1,
        Tuesday = 0b10,
        Wednesday = 0b100,
        Thursday = 0b1000,
        Friday = 0b1_0000,
        Saturday = 0b10_0000,
        Sunday = 0b100_0000,
        Weekday = Monday | Tuesday | Wednesday | Thursday | Friday,
        Weekend = Saturday | Sunday
    }

}
