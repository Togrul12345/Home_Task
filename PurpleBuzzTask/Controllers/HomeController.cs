using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
