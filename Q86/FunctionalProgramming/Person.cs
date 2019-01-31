namespace FunctionalProgramming
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public static bool IsMinor(Person person)
        {
            return person.Age < 18;
        }

        public static Person Rename(Person person, string firstName)
        {
            return new Person(firstName, person.LastName, person.Age);
        }

        public Person With(string firstName = null, string lastName = null, int? age = null)
        {
            return new Person(firstName ?? this.FirstName, lastName ?? this.LastName, age ?? this.Age);
        }

        public static Person RenameUsingWith(Person person, string firstName)
        {
            return person.With(firstName: firstName);
        }

        public static Person MultiRenameNested(Person person)
        {
            return Rename(Rename(person, "Jane"), "Jack");
        }

        public static Person MultiRenameUsingWith(Person person)
        {
            return person.With(firstName: "Jane").With(firstName: "Jack");
        }

        public static Person MultiRenameMultiLine(Person person)
        {
            return person
                .With(firstName: "Jane")
                .With(firstName: "Jack");
        }

        public static Person MultiRename(Person person)
        {
            return person.Rename("Jane").Rename("Jack");
        }
    }
}
