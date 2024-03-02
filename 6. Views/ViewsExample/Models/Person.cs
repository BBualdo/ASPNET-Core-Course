namespace ViewsExample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<string> Hobbies { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, DateTime? dateOfBirth, List<string> hobbies)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Hobbies = hobbies;
            Hobbies = hobbies;
        }
    }
}
