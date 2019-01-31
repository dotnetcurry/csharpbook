namespace CSharp3
{
    public class NameAndAge
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public NameAndAge(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

}
