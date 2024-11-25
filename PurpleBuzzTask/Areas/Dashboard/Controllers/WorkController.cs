using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.ViewModel;

namespace PurpleBuzzTask.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class WorkController : Controller
    {
        public readonly AppDbContext _appDbContext;
        public WorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            
     
          
            return View(_appDbContext.Works);

        }
        public IActionResult Create()
        {
            ViewBag.Services = new SelectList(_appDbContext.Services,"Title","Id");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Work work)
        {
            
            _appDbContext.Works.Add(work);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
