using Department.Bl.Dtos.AppUserDto;
using Department.Bl.Services.Abstractions;
using Department.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;



        public DepartmentController(IAccountService accountService, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signinManager = signinManager;
        }
        [HttpPost("Register")]
      
        public async Task<IActionResult> Register(CreateAppUserDto createAppUser)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(await _accountService.CreateAsync(createAppUser));
                return Ok(new { message = $"Please confirm email with token you received {code}" });
            }

            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost("EmailConfirmation")]
      
        public async Task<IActionResult> EmailVerification(string email, string code)
        {
            if (email == null || code == null)
            {
                return BadRequest("Invalid payload");
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("user can not be found");
            }
            var verified = await _userManager.ConfirmEmailAsync(user, code);
            if (verified.Succeeded)
            {
                return Ok(new
                {
                    message = "email confirmation completed successfully"
                });
            }
           
            return BadRequest("Something went wrong");
        }
        [HttpPost("ChangePassword")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, string email)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _accountService.ChangePassword(changePasswordDto, email));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost("Login")]
     
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                throw new Exception("Email is incorrect");
            }
            var result = await _signinManager.PasswordSignInAsync(user, loginDto.Password, true, true);
            if (!result.Succeeded)
            {
                throw new Exception("Password is incorrect");
            }
            await _userManager.AddToRoleAsync(user, "User");

            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpPost("AddRole")]
   
        public async Task<IActionResult> AddRole(string role)
        {
            var result = await _accountService.AddRole(role);
            if (!result.Succeeded)
            {
                throw new Exception("role couldnt added");
            }
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> GetAllUsers()
        {
            return StatusCode(StatusCodes.Status200OK, await _accountService.GetAppUsers());
        }
    }
}
