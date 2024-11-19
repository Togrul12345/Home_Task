using Microsoft.AspNetCore.Mvc;
using MvcTask1.Models;

namespace MvcTask1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "Fizaret",
            };
            Student student2 = new Student()
            {
                Id = 2,
                Name = "MirYusif",
            };
            List<Student> students = new List<Student>() { student, student2 };
            return View(students);
        }
    }
}
