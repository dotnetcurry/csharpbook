using System.ComponentModel;

namespace GenericTypeConstraints
{
    public enum FuelType
    {
        Petrol,
        Diesel,
        [Description("Liquid petroleum gas")]
        LPG
    }

}
