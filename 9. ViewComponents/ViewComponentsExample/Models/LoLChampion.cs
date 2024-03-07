namespace ViewComponentsExample.Models;

public class LoLChampion
{
  public string Name { get; set; }
  public string Damage { get; set; }

  public LoLChampion(string name, string damage)
  {
    Name = name;
    Damage = damage;
  }
}
