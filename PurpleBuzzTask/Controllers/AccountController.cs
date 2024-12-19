using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.Utilities;

namespace PurpleBuzzTask.Controllers
{
    public class AccountController : Controller
    {public readonly IConfiguration _configuration;
        public readonly AppDbContext _appDbContext;
        public UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;



        public AccountController(UserManager<AppUser> userManager, AppDbContext appDbContext, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public IActionResult Register()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserDTO appUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(appUserDTO);
            }

            AppUser user = new AppUser();
            user.FirstName = appUserDTO.FirstName;
            user.LastName = appUserDTO.LastName;
            user.Email = appUserDTO.Email;
            user.UserName = appUserDTO.UserName;
            var result = await _userManager.CreateAsync(user, appUserDTO.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(appUserDTO);
            }
          await  _userManager.AddToRoleAsync(user, "User");
            EmailService emailService = new EmailService(_configuration);
            emailService.Send(user.Email);
            return RedirectToAction("Index", "Home");


        }

        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {

                ModelState.AddModelError(string.Empty, "something went wrong");
                return View(dto);
            }
            AppUser? appUser = new AppUser();
            appUser = _userManager.Users.FirstOrDefault(a => a.UserName == dto.EmailOrUsername);

            if (appUser == null)
            {
               appUser= _userManager.Users.FirstOrDefault(a => a.Email == dto.EmailOrUsername);
                if (appUser == null)
                {
                    ModelState.AddModelError(string.Empty, "username or passwor is wrong");
                    return View();
                }
            }
           var result=await _signInManager.PasswordSignInAsync(appUser, dto.Password, true, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "username or password is wrong");
                return View();
            }

            return RedirectToAction(nameof(Index),"home");





        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");

        }
        public async Task CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }
    }
}
