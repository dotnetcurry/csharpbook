using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DynamicBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            NonExistentMember();
            NonExistentMemberDynamic();

            dynamic value = GetAnonymousType();
            Console.WriteLine($"{value.Name} {value.Surname}, {value.Age}");

            DynamicJson();
            UsingExpandoObject();
            UsingDynamicObject();
        }

        private static void NonExistentMember()
        {
            var text = "String value";
            var textLength = text.Length; // compiles - Length is a property of string
            var lengthString = text.Length.ToString(); // compiles - ToString() is a method of int
            //var textMonth = text.Month; // doesn't compile - Month is not a property of string
        }

        private static void NonExistentMemberDynamic()
        {
            dynamic text = "String value";
            var textLength = text.Length;
            var lengthString = text.Length.ToString();
            try
            {
                var textMonth = text.Month; // compiles but throws exception at runtime
            }
            catch (RuntimeBinderException)
            { }

            dynamic date = DateTime.Now;
            try
            {
                var dateLength = date.Length; // compiles but throws exception at runtime
            }
            catch (RuntimeBinderException)
            { }
            var dateMonth = date.Month;
        }

        private static dynamic GetAnonymousType()
        {
            return new
            {
                Name = "John",
                Surname = "Doe",
                Age = 42
            };
        }

        private static void DynamicJson()
        {
            string json = @"
                {
                    ""name"": ""John"",
                    ""surname"": ""Doe"",
                    ""age"": 42
                }";

            dynamic value = JObject.Parse(json);
            Console.WriteLine($"{value.name} {value.surname}, {value.age}");
        }

        private static void UsingExpandoObject()
        {
            dynamic person = new ExpandoObject();
            person.Name = "John";
            person.Surname = "Doe";
            person.Age = 42;

            Console.WriteLine($"{person.Name} {person.Surname}, {person.Age}");

            person.ToString = (Func<string>)(() => $"{person.Name} {person.Surname}, {person.Age}");
            Console.WriteLine(person.ToString());

            var dictionary = (IDictionary<string, object>)person;
            foreach (var member in dictionary)
            {
                Console.WriteLine($"{member.Key} = {member.Value}");
            }

            dictionary.Remove("ToString");
        }

        private static void UsingDynamicObject()
        {
            dynamic person = new MyDynamicObject();
            person.Name = "John";
            person.Surname = "Doe";
            person.Age = 42;

            Console.WriteLine($"{person.Name} {person.Surname}, {person.Age}");

            person.AsString = (Func<string>)(() => $"{person.Name} {person.Surname}, {person.Age}");
            Console.WriteLine(person.AsString());

            person.Remove("AsString");
            Console.WriteLine(person.ContainsKey("AsString"));

            var dictionary = (Dictionary<string, object>)person;
        }
    }
}
