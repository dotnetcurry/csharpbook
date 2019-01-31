namespace AnonymousTypes
{
    class SourcePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SourceAddress Address { get; set; }
        public SourcePerson Father { get; set; }
    }
}
