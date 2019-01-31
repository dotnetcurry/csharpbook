using System;
using System.Collections.Generic;

namespace CustomAttributes
{
    public static class ValidationExtensions
    {
        public static Dictionary<string, string> GetValidationErrors(this object instance)
        {
            var errors = new Dictionary<string, string>();

            var attributeType = typeof(NotNullableAttribute);
            var instanceType = instance.GetType();
            var properties = instanceType.GetProperties();
            foreach (var property in properties)
            {
                var attribute = (NotNullableAttribute)Attribute.GetCustomAttribute(property, attributeType);
                if (attribute != null)
                {
                    var propertyValue = property.GetValue(instance);
                    if (propertyValue == null)
                    {
                        errors.Add(property.Name, attribute.ErrorMessage);
                    }
                }
            }

            return errors;
        }
    }

}
