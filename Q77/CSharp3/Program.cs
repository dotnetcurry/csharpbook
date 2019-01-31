using System.Collections.Generic;
using System.Linq;

namespace CSharp3
{
    class Program
    {
        private static readonly List<Person> persons = new List<Person>();

        static void Main(string[] args)
        {
            After();
            Before();
        }

        private static void After()
        {
            var minors = persons.Where(person => person.Age < 18)
                .Select(person => new { person.Name, person.Age })
                .ToList();

        }

        private static void Before()
        {
            List<NameAndAge> minors = new List<NameAndAge>();
            foreach (Person person in persons)
            {
                if (person.Age > 18)
                {
                    minors.Add(new NameAndAge(person.Name, person.Age));
                }
            }
        }
    }
}
