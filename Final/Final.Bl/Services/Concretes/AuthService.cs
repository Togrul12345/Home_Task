using AutoMapper;
using Final.Bl.Dtos.AppUserDtos;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtService;



        public AuthService(IMapper mapper, UserManager<AppUser> userManager, IJwtService jwtService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<string> Login(LoginAppUserDto loginAppUserDto)
        {
            AppUser? appUser = await _userManager.FindByNameAsync(loginAppUserDto.UserName);
            if (appUser == null)
            {
                throw new Exception("Couldnt found");
            }
            var result = await _userManager.CheckPasswordAsync(appUser, loginAppUserDto.Password);
            if (!result)
            {
                throw new Exception("Something went wrong");
            }
            return _jwtService.GenerateToken(appUser) ;
        }

        public async Task<AppUser> Register(CreateAppUser createAppUser)
        {
            AppUser appUser = _mapper.Map<AppUser>(createAppUser);
           
            var result = await _userManager.CreateAsync(appUser, createAppUser.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Couldnt create!");
            }
            return appUser;
        }
    }
}
