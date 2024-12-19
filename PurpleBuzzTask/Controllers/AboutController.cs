using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.ViewModel;

namespace PurpleBuzzTask.Controllers
{
    public class AboutController : Controller
    {readonly AppDbContext context;
        public AboutController(AppDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            

            //context.Works.AddRange(teamMate, teamMate2, teamMate3);
            //context.SaveChanges();
            IEnumerable<Work> Works = context.Works;

            
           
           
           
            
     
            
            return View(Works);
        }
    }
}
