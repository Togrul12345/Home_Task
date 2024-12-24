using Department.Bl.Dtos.AppUserDto;
using Department.Bl.Services.Abstractions;
using Department.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;



        public DepartmentController(IAccountService accountService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
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
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _accountService.ChangePassword(changePasswordDto)); 

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
