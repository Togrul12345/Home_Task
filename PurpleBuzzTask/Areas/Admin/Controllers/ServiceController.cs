using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.Services.Concretes;
using PurpleBuzzTask.Services.Interfaces;
using PurpleBuzzTask.Utilities;
using System.Runtime.CompilerServices;

namespace PurpleBuzzTask.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IServiceForService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ServiceController(IWebHostEnvironment webHostEnvironment, IServiceForService service, AppDbContext context)
        {

            _webHostEnvironment = webHostEnvironment;
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> services = await _context.Services.Include(a => a.Works).ToListAsync();

            return View(services);
        }
        public IActionResult Delete(int id)
        {
            var result = _context.Works.Any(x => x.ServiceId == id);
            if (result)
            {
                return BadRequest("Something went wrong");
            }
            Service? deletedService = _context.Services.Find(id);
            if (deletedService == null) {
                return NotFound();
            }
            else
            {
                _context.Services.Remove(deletedService);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    return StatusCode(404, "something is wrong");
                }
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {

                return View(serviceDto);
            }
            if (!serviceDto.Img.CheckType())
            {
                ModelState.AddModelError("img", "image formati olmalidir");
                return View(serviceDto);
            }
            if (!serviceDto.Img.CheckSize(2))
            {
                ModelState.AddModelError("img", "2mbytdan kicik olmalidir");
                return View(serviceDto);
            }
            Service service = new Service
            {
                CreatedAt = DateTime.Now,
                Description = serviceDto.Description,
                MainImageUrl = serviceDto.Img.UploadImage(_webHostEnvironment.WebRootPath, "test"),
                Title = serviceDto.Title
            };
            _service.CreateService(service);


            return RedirectToAction(nameof(Index));

        }


    }

}

