using System.Diagnostics;
using Mediplus.Context;
using Mediplus.DTOs;
using Mediplus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mediplus.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext appDbContext)
        {
            _context = appDbContext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAppointment()
        {
          
            await _context.SaveChangesAsync();
            IEnumerable<Hospital> hospitals = _context.Hospitals;
            IEnumerable<Doctor> doctors = _context.Doctors;

            ViewBag.Hospitals = new SelectList(hospitals, "Id", "HospitalName");
            ViewBag.Doctors = new SelectList(doctors, "Id", "DoctorName");
            CreateHospitalDto doctorHospital = new CreateHospitalDto();
            return View(doctorHospital);
        }
       
       
        



    }
}
