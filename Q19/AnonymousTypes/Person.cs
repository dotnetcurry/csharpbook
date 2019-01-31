namespace AnonymousTypes
{
    internal sealed class Person
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            var value = obj as Person;
            if (value == null)
            {
                return false;
            }

            return Equals(FirstName, value.FirstName) && Equals(LastName, value.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName?.GetHashCode() ?? 0 ^ LastName?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return $"{{ FirstName = {FirstName}, LastName = {LastName} }}";
        }
    }

}
