using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.Controllers
{
    public class RegisterController : Controller
    {
        public  UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AppUserDTO appUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(appUserDTO);
            }
         AppUser user= new AppUser();
            user.FirstName = appUserDTO.FirstName;
            user.LastName = appUserDTO.LastName;
            user.Email=appUserDTO.Email;
            var result = _userManager.CreateAsync(user, appUserDTO.Password);

            return RedirectToAction("Index","Home");
        }
    }
}
