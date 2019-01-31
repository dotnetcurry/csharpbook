using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Serialization
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
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
        [DataMember]
        protected DateTime dateOfBirth;

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
    }

}
