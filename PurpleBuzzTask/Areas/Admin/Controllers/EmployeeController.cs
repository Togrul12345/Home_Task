using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.DTOs.EmployeeDTOs;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.Utilities;

namespace PurpleBuzzTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            IEnumerable<Employee> employees = _context.Employees.Include(a => a.EmployeeWorks);
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Works = new SelectList(_context.Works, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO createEmployeeDTO)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee()
                {
                    Name = createEmployeeDTO.Name,
                    Surname = createEmployeeDTO.Surname,
                    Profession = createEmployeeDTO.Profession,
                    ImgUrl = createEmployeeDTO.ImgUrl.UploadImage(_webHostEnvironment.WebRootPath, "test")
                };
                _context.Employees.Add(employee);
                foreach (var Id in createEmployeeDTO.WorkIds)
                {
                    EmployeeWork employeeWork = new EmployeeWork()
                    {
                        Employee = employee,
                        WorkId = Id

                    };
                    _context.EmployeeWorks.Add(employeeWork);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Employee");
            }

            return View(createEmployeeDTO);

        




           

        }

    }
}

