namespace ViewsExample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, DateTime? dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }
}
