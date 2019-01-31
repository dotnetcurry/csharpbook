namespace Tuples
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Deconstruct(out string name, out string surname)
        {
            name = FirstName;
            surname = LastName;
        }
    }
}
