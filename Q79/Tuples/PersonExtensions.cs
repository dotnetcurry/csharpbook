namespace Tuples
{
    public static class PersonExtensions
    {
        public static void Deconstruct(this Person person, out string name, out string surname)
        {
            name = person.FirstName;
            surname = person.LastName;
        }
    }
}
