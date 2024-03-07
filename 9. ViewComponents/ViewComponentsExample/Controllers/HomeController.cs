using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            return View();
        }

        [Route("lol-champions")]
        public ActionResult LoLChampions()
        {
            List<LoLChampion> champions = new List<LoLChampion>() {
                new LoLChampion("Yasuo", "AD"),
                new LoLChampion("Yone", "AD"),
                new LoLChampion("Ekko", "AP"),
                new LoLChampion("Fizz", "AP"),
                new LoLChampion("Cailtyn", "AD")
            };

            ChampionList championList = new ChampionList(champions);

            return ViewComponent("Champions", championList);
        }

    }
}
