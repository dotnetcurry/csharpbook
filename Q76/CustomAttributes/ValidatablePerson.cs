using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes
{
    public class ValidatablePerson : IValidatable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Dictionary<string, string> GetValidationErrors()
        {
            var errors = new Dictionary<string, string>();

            if (FirstName == null)
            {
                errors.Add(nameof(FirstName), "Null value is not allowed.");
            }
            if (LastName == null)
            {
                errors.Add(nameof(LastName), "LastName is required.");
            }

            return errors;
        }
    }

}
