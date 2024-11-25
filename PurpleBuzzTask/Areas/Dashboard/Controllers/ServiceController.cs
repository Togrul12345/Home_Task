using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;
using System.Runtime.CompilerServices;

namespace PurpleBuzzTask.Areas.Admin.Controllers;

[Area("Dashboard")]
public class ServiceController : Controller
{
    public readonly AppDbContext _Context;
    public ServiceController(AppDbContext Context)
    {
        _Context = Context;
    }
    public IActionResult Index()
    {
        Service service = new Service()
        {
            Title = "Grafik dizayn",
            Description = "Ideal dizayn",
            MainImageUrl = "undraw_profile_3svg"
        };
        Service service2 = new Service()
        {
            Title = "UI/UX dizayn",
            Description = "Ideal ui dizayn",
            MainImageUrl = "undraw_profile_2svg"
        };
        Service service3 = new Service()
        {
            Title = "Branding",
            Description = "ideal branding",
            MainImageUrl = "undraw_profile_1svg"
        };

        IEnumerable<Service> services = new List<Service>()
        {
            service,service2,service3
        };
       


        return View(_Context.Services);
    }
    public IActionResult Delete(int id)
    {
        Service? deletedService = _Context.Services.Find(id);
        if (deletedService == null)
        {
            return BadRequest("Something went wrong");
        }
        _Context.Services.Remove(deletedService);
        _Context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Service service)
    {
        _Context.Services.Add(service);
        _Context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


}
