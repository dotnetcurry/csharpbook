namespace CustomAttributes
{
    public class Person
    {
        [NotNullable]
        public string FirstName { get; set; }
        [NotNullable("LastName is required.")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }

}
