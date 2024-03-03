namespace ViewsExample.Models
{
  public class Person
  {
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender PersonGender { get; set; }

    public Person(string name)
    {
      Name = name;
    }

    public Person(string name, DateTime? dateOfBirth, Gender gender)
    {
      Name = name;
      DateOfBirth = dateOfBirth;
      PersonGender = gender;
    }

    public enum Gender
    {
      Male, Female, Other
    }
  }
}
