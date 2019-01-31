using NUnit.Framework;
using System;
using System.Linq;
using static FunctionalProgramming.Person;

namespace FunctionalProgramming
{
    public class Tests
    {
        public static int Fn1(int x)
        {
            return x + 1;
        }

        public static int Fn2(int x)
        {
            return x * 2;
        }

        public static int ComposedFn(int x)
        {
            return Fn2(Fn1(x));
        }

        [Test]
        public void Composition()
        {
            var x = 5;

            Assert.That(ComposedFn(x), Is.EqualTo(Fn2(Fn1(x))));
        }

        [Test]
        public void FirstClassFunctions()
        {
            var persons = new Person[0];

            var anyMinors = Array.Exists(persons, IsMinor);

            Assert.IsFalse(anyMinors);
        }

        string[] Imperative(string[] words)
        {
            var lowerCaseWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                lowerCaseWords[i] = words[i].ToLower();
            }
            return lowerCaseWords;
        }

        [Test]
        public void ImperativeApproach()
        {
            var words = new[] { "Capitalized" };

            var lowerCase = Imperative(words);

            CollectionAssert.AreEqual(new[] { "capitalized" }, lowerCase);
        }

        string[] Declarative(string[] words)
        {
            return words.Select(word => word.ToLower()).ToArray();
        }

        [Test]
        public void DeclarativeApproach()
        {
            var words = new[] { "Capitalized" };

            var lowerCase = Declarative(words);

            CollectionAssert.AreEqual(new[] { "capitalized" }, lowerCase);
        }

        [Test]
        public void LinqQuery()
        {
            var persons = new Person[0];

            var result = persons
                .Where(p => p.FirstName == "John")
                .Select(p => p.LastName)
                .OrderBy(s => s.ToLower())
                .ToList();

            CollectionAssert.IsEmpty(result);
        }

        public bool FirstNameIsJohn(Person p)
        {
            return p.FirstName == "John";
        }

        public string PersonLastName(Person p)
        {
            return p.LastName;
        }

        public string StringToLower(string s)
        {
            return s.ToLower();
        }

        [Test]
        public void LinqQueryWithFunctionArguments()
        {
            var persons = new Person[0];

            var result = persons
                .Where(FirstNameIsJohn)
                .Select(PersonLastName)
                .OrderBy(StringToLower)
                .ToList();

            CollectionAssert.IsEmpty(result);
        }
    }
}