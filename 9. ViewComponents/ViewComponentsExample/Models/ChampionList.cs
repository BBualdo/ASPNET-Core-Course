namespace ViewComponentsExample.Models;

public class ChampionList
{
  public string ListName { get; set; } = "LoL Champions";
  public List<LoLChampion> ListItems { get; set; }

  public ChampionList(List<LoLChampion> lolChampions)
  {
    ListItems = lolChampions;
  }
}
