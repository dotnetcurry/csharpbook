using System;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullableAttribute : Attribute
    {
        public string ErrorMessage { get; set; } = "Null value is not allowed.";

        public NotNullableAttribute()
        { }

        public NotNullableAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

}
