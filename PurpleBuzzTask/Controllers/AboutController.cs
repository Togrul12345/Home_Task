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
            Work teamMate = new Work()
            { 
                UserName = "Muxtar Huseynov",
                Profession = "Responsive-Design",
                ImgUrl = "team-02.jpg"


            };
            Work teamMate2 = new Work()
            {
                UserName = "Togrul Bagirov",
                Profession = "Backend-Developer",
                ImgUrl = "team-03.jpg"
            };
            Work teamMate3 = new Work()
            {
                UserName = "Cebrayil Cebrayilov",
                Profession = "Frontend-Developer",
                 ImgUrl = "team-01.jpg"
            };

            //context.Works.AddRange(teamMate, teamMate2, teamMate3);
            //context.SaveChanges();
            IEnumerable<Work> Works = context.Works;

            
           
           
           
            
     
            
            return View(Works);
        }
    }
}
