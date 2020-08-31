using Microsoft.AspNetCore.Mvc;

namespace RevFlix.Client.Controllers
{
  public class UserController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
