using System;
using System.ComponentModel;

namespace GenericTypeConstraints
{
    static class Extensions
    {
        public static bool IsAfter<T>(this T value, T compareTo) where T : IComparable
        {
            return value.CompareTo(compareTo) > 0;
        }

        public static TDelegate Combine<TDelegate>(this TDelegate source, TDelegate target) where TDelegate : Delegate
        {
            // Delegate.Combine must be used instead of the + operator
            return (TDelegate)Delegate.Combine(source, target);
        }

        public static string GetDescription<TEnum>(this TEnum value) where TEnum : Enum
        {
            var type = typeof(TEnum);
            var member = type.GetMember(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(member[0], typeof(DescriptionAttribute));
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
