using AutoMapper;
using Department.Bl.Dtos.AppUserDto;
using Department.Bl.Services.Abstractions;
using Department.Core;
using Department.Data.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Bl.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly DepartmentDbContext _departmentDbContext;

        public AccountService(IMapper mapper,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<AppUser> ChangePassword(ChangePasswordDto changePasswordDto)
        {
          
            var updatedUser=_mapper.Map<AppUser>(changePasswordDto);
           await _userManager.UpdateAsync(updatedUser);
            return updatedUser;
        }

        public async Task<AppUser> CreateAsync(CreateAppUserDto createAppUser)
        {
            AppUser createdUser = _mapper.Map<AppUser>(createAppUser);

            var result = await _userManager.CreateAsync(createdUser,createAppUser.Password);
            if (!result.Succeeded)
            {
                throw new Exception("couldnt create AppUser");
            }
            
            return createdUser;
        }

        public Task<AppUser> GetByEmail(string email)
        {
          
        }
    }
}
