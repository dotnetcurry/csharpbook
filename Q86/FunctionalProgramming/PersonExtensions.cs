namespace FunctionalProgramming
{
    public static class PersonExtensions
    {
        public static Person Rename(this Person person, string firstName)
        {
            return person.With(firstName: firstName);
        }
    }
}
