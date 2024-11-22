﻿using Microsoft.AspNetCore.Mvc;
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
            TeamMate teamMate = new TeamMate()
            { 
                UserName = "Muxtar Huseynov",
                Profession = "Responsive-Design",
                ImgUrl = "~/img/team-02.jpg"


            };
            TeamMate teamMate2 = new TeamMate()
            {
                UserName = "Togrul Bagirov",
                Profession = "Backend-Developer",
                ImgUrl = "~/img/team-03.jpg"
            };
            TeamMate teamMate3 = new TeamMate()
            {
                UserName = "Cebrayil Cebrayilov",
                Profession = "Frontend-Developer",
                 ImgUrl = "~/img/team-01.jpg"
            };


            //AppDbContext dbContext = new AppDbContext();
            //dbContext.AddRange(teamMates);
            //dbContext.SaveChanges();
            context.TeamMates.AddRange(teamMate, teamMate2, teamMate3);
            context.SaveChanges();
            IEnumerable<TeamMate> teamMates= context.TeamMates;
            
     
            
            return View(teamMates);
        }
    }
}
