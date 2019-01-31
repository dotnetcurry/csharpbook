using System;
using System.Collections.Generic;

namespace ExpressionBodiedMembers.RegularBody
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public void Dispose(Boolean dispose)
        { }

        public override string ToString()
        {
            return $"{FullName}, {Age}";
        }

        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    Age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        private Dictionary<string, int?> grades = new Dictionary<string, int?>();
        public int? this[string course]
        {
            get
            {
                if (grades.ContainsKey(course))
                {
                    return grades[course];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                grades[course] = value;
            }
        }

        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        ~Student()
        {
            Dispose(false);
        }
    }
}
