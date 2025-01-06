using Final.Bl.Dtos.AppUserDtos;
using Final.Bl.Exceptions;
using Final.Bl.Services.Concretes;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
     

        public AuthController(IAuthService authService)
        {
            _authService = authService;
    
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateAppUser createAppUser)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _authService.Register(createAppUser));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
          
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginAppUserDto loginAppUserDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelSateException();
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _authService.Login(loginAppUserDto));
                
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
        [Authorize(Roles ="Admin")]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return StatusCode(StatusCodes.Status200OK, "logged out successfully");
        }



    }
}
