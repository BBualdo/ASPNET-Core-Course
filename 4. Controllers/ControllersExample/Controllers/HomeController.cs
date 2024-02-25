using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{

  public class HomeController : Controller
  {
    [Route("/")] // Attribute Routing
    [Route("home")]
    public ContentResult Index()
    {
      // return new ContentResult()
      // {
      //   Content = "<h1>Hello from Index Page</h1>",
      //   ContentType = "text/html"
      // };

      return Content("<h1>Hello from Index Page</h1>", "text/html"); // available when inherits from Controller
    }


    [Route("person")]
    public JsonResult Person()
    {
      Person person = new Person(Guid.NewGuid(), "Asia", "Opozda", 25);
      // return new JsonResult(person);
      return Json(person);
    }

    [Route("download-virtual")]
    public VirtualFileResult VirtualDownload()
    {
      // return new VirtualFileResult("/sample.pdf", "application/pdf");
      // or 
      return File("/sample.pdf", "application/pdf");
    }

    [Route("download-physical")]
    public PhysicalFileResult PhysicalDownload()
    {
      // return new PhysicalFileResult(@"C:\Users\soapm\Desktop\CSS Selector Cheat Sheet - Dark.pdf", "application/pdf");
      // or 
      return PhysicalFile(@"C:\Users\soapm\Desktop\CSS Selector Cheat Sheet - Dark.pdf", "application/pdf");
    }

    [Route("download-file-content")]
    public FileContentResult FileContentDownload()
    {
      byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\soapm\Desktop\CSS Selector Cheat Sheet - Dark.pdf");
      // return new FileContentResult(bytes, "application/pdf");
      // or
      return File(bytes, "application/pdf");
    }
  }
}
