using System;

namespace CustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            AttributeBasedValidation();
            MethodBasedValidation();
        }

        private static void AttributeBasedValidation()
        {
            var person = new Person();
            var errors = person.GetValidationErrors();
        }

        private static void MethodBasedValidation()
        {
            var person = new ValidatablePerson();
            var errors = person.GetValidationErrors();
        }
    }
}
