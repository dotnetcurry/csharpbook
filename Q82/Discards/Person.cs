namespace Discards
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Deconstruct(out string name, out string surname, out int age)
        {
            name = FirstName;
            surname = LastName;
            age = Age;
        }
    }
}
