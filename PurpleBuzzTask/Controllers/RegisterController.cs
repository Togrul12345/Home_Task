using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.Controllers
{
    public class RegisterController : Controller
    {
        public readonly AppDbContext _appDbContext;
        public UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager,AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserDTO appUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(appUserDTO);
            }

            AppUser user = new AppUser();
            user.FirstName = appUserDTO.FirstName;
            user.LastName = appUserDTO.LastName;
            user.Email = appUserDTO.Email;
            var result = await _userManager.CreateAsync(user, appUserDTO.Password);
            if (result.Succeeded)
            {
                JsonResult jsonResult = new JsonResult("User created");
                return jsonResult;
                
            }
            return RedirectToAction("Index", "Home");


        }
    }
}
