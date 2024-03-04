﻿using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    [Route("home")]
    public IActionResult Index()
    {
      return View();
    }

    [Route("about")]
    public IActionResult About()
    {
      return View();
    }

    [Route("contact")]
    public IActionResult Contact()
    {
      return View();
    }
  }
}
