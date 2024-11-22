using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzTask.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
