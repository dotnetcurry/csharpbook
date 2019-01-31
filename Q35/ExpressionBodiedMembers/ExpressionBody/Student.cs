using System;
using System.Collections.Generic;

namespace ExpressionBodiedMembers.ExpressionBody
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public void Dispose(Boolean dispose)
        { }

        public override string ToString() => $"{FullName}, {Age}";

        public string FullName => $"{Name} {Surname}";

        private int age;
        public int Age
        {
            get => age;
            set => age = value > 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
        }

        private Dictionary<string, int?> grades = new Dictionary<string, int?>();
        public int? this[string course]
        {
            get => grades.ContainsKey(course) ? grades[course] : null;
            set => grades[course] = value;
        }

        public Student(string name, string surname, int age) => (Name, Surname, Age) = (name, surname, age);

        ~Student() => Dispose(false);
    }
}
