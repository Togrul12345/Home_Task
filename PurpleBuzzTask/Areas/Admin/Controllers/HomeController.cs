using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;

namespace PurpleBuzzTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin,User,Manager")]
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
       

    }
}
