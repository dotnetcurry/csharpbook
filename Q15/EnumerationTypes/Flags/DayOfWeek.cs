using System;

namespace EnumerationTypes.Flags
{
    [Flags]
    public enum DayOfWeek
    {
        None = 0x0,
        Monday = 0x1,
        Tuesday = 0x2,
        Wednesday = 0x4,
        Thursday = 0x8,
        Friday = 0x10,
        Saturday = 0x20,
        Sunday = 0x40
    }

}
