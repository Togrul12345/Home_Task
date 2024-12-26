using AutoMapper;
using Department.Bl.Dtos.AppUserDto;
using Department.Bl.Services.Abstractions;
using Department.Core;
using Department.Data.Contexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(IMapper mapper, UserManager<AppUser> userManager, DepartmentDbContext departmentDbContext, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _departmentDbContext = departmentDbContext;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddRole(string role)
        {
            return await _roleManager.CreateAsync(new IdentityRole { Name = role });

        }

        public async Task<AppUser> ChangePassword(ChangePasswordDto changePasswordDto, string email)
        {

            var user = await GetByEmail(email);
            var updatedData = _mapper.Map<AppUser>(changePasswordDto);
            updatedData.Email = email;
            await _userManager.UpdateAsync(updatedData);

            return updatedData;
        }

        public async Task<AppUser> CreateAsync(CreateAppUserDto createAppUser)
        {
            AppUser createdUser = _mapper.Map<AppUser>(createAppUser);

            var result = await _userManager.CreateAsync(createdUser, createAppUser.Password);
            if (!result.Succeeded)
            {
                throw new Exception("couldnt create AppUser");
            }
      

            return createdUser;
        }

        public async Task<IEnumerable<AppUser>> GetAppUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetByEmail(string email)
        {
            var result = await _userManager.Users.FirstOrDefaultAsync(a => a.Email == email);

            if (result is null)
            {
                throw new Exception("result is not found");
            }
            _departmentDbContext.Users.Entry(result).State = EntityState.Detached;

            return result;
        }
    }
}
