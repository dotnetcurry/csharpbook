using System.Xml.Linq;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinqQueryExecution
{
    partial class Program
    {
        static void Main(string[] args)
        {
            WhereExtension();
            SumExtension();
            LinqToXml();
            LinqToEntitiesQuery();
            LinqToEntitiesRemoteFunction();
            LinqToEntitiesCustomFunction();
        }

        private static void LinqToXml()
        {
            var xmlString = @"
<persons>
    <person name=""John"" surname=""Doe"" age=""33"" />
    <person name=""Jane"" surname=""Doe"" age=""42"" />
    <person name=""Johnny"" surname=""Doe"" age=""13"" />
</persons>
";

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements()
                .Where(element => int.Parse(element.Attribute("age").Value) > 21);

        }

        private static DbContextOptions<PersonContext> CreateOptions()
        {
            var connectionString = "Data Source = Persons.db";

            var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionsBuilder.UseSqlite(connectionString);
            var options = optionsBuilder.Options;

            return options;
        }

        private static void LinqToEntitiesQuery()
        {
            var options = CreateOptions();

            using (var context = new PersonContext(options))
            {
                var query = context.Persons.Where(person => person.Age > 21);

                var result = query.ToList();
            }
        }

        private static void LinqToEntitiesRemoteFunction()
        {
            var options = CreateOptions();

            using (var context = new PersonContext(options))
            {
                var query = context.Persons.Where(person => Math.Abs(person.Age) > 21);

                var result = query.ToList();
            }
        }

        private static int CustomFunction(int val)
        {
            return val + 1;
        }

        private static void LinqToEntitiesCustomFunction()
        {
            var options = CreateOptions();

            using (var context = new PersonContext(options))
            {
                var query = context.Persons.Where(person => CustomFunction(person.Age) > 21);

                var result = query.ToList();
            }
        }
    }
}
