using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericTypeConstraints
{
    class Program
    {
        static void Main(string[] args)
        {
            Generic();
            NonGeneric();
            Class();
            Struct();
            Constructor();
        }

        private static void Generic()
        {
            var members = new List<Member>() { /* ... */ };
            IEnumerable<Member> membersOfAge = SelectOfAgeGeneric(members);
        }

        private static void NonGeneric()
        {
            var members = new List<Member>() { /* ... */ };
            IEnumerable<IPerson> membersOfAge = SelectOfAgeNonGeneric(members);
        }

        private static void Class()
        {
            var person = new PersonClass()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 42
            };
            RenamePerson(person, "Jane");
            Console.WriteLine(person.FirstName); // = "Jane"
        }

        private static void Struct()
        {
            var person = new PersonStruct()
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 42
            };
            RenamePerson(person, "Jane");
            Console.WriteLine(person.FirstName); // = "John"
        }

        private static void Constructor()
        {
            var personStruct = CreatePerson<PersonStruct>("John", "Doe", 42);
            var personClass = CreatePerson<PersonClass>("John", "Doe", 42);
        }

        public static IEnumerable<T> SelectOfAgeGeneric<T>(IEnumerable<T> persons) where T : IPerson
        {
            return persons.Where(person => person.Age >= 18);
        }

        public static IEnumerable<IPerson> SelectOfAgeNonGeneric(IEnumerable<IPerson> persons)
        {
            return persons.Where(person => person.Age >= 18);
        }

        public static void RenamePerson<T>(T person, string newName) where T : /*class,*/ IPerson
        {
            person.FirstName = newName;
        }

        public static T CreatePerson<T>(string firstName, string lastName, int age) where T : IPerson, new()
        {
            var person = new T() // uses the constructor
            {
                // uses property setters from the interface
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            return person;
        }

        public static unsafe byte[] Serialize<T>(T value) where T : unmanaged
        {
            var bufferSize = sizeof(T);
            var buffer = new byte[bufferSize];
            fixed (byte* bufferPtr = &buffer[0])
            {
                Buffer.MemoryCopy(&value, bufferPtr, bufferSize, bufferSize);
            }
            return buffer;
        }

    }
}
