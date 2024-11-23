using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.Areas.Admin.Controllers;

[Area("Admin")]
public  class ServiceController : Controller
{
    public  readonly AppDbContext _appDbContext;
    public ServiceController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public IActionResult Index()
    {
        Service service = new Service()
        {
            Title = "Dasinma",
            Description = "Suretli dasinma",
            MainImageUrl = "work-slide-01.jpg"
        };
        Service service2 = new Service()
        {
            Title = "Analiz",
            Description = "Keyfiyyətli analiz",
            MainImageUrl = "work1-slide-01.jpg"
        };
        Service service3 = new Service()
        {
            Title = "Programlaşdırma",
            Description = ".Net Development",
            MainImageUrl = "work1-slide-01.jpg"
        };
        
        IEnumerable<Service> services = new List<Service>()
        {
            service,service2,service3
        };
        //_appDbContext.Services.AddRange(services);
        //_appDbContext.SaveChanges();
        return View(_appDbContext.Services);
        
    }
    public IActionResult Delete(int Id) {
        Console.WriteLine(true);
       Service? service= _appDbContext.Services.Find(Id);
        _appDbContext.Services.Remove(service);
        _appDbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Create()
    {
       
        return View();
    }
    [HttpPost]
    public IActionResult Create(Service service)
    {_appDbContext.Services.Add(service);
        _appDbContext.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
