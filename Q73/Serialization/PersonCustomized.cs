using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization
{
    [Serializable]
    public class PersonCustomized
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;
                if (dateOfBirth.AddYears(age) > today)
                {
                    age--;
                }
                return age;
            }
        }
        protected DateTime dateOfBirth;
        [NonSerialized]
        private string password;

        public PersonCustomized(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        public void SetPassword(string newPassword)
        {
            password = newPassword;
        }
    }

}
