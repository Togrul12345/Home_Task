using Microsoft.AspNetCore.Mvc;

namespace PurpleBuzzTask.Controllers
{
    public class WorkSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
