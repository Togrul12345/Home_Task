using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;

namespace PurpleBuzzTask.Areas.Admin.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
       

    }
}
