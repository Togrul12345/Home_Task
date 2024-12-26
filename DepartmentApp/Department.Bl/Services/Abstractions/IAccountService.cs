using Department.Bl.Dtos.AppUserDto;
using Department.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Bl.Services.Abstractions
{
    public interface IAccountService
    {
        Task<AppUser> CreateAsync(CreateAppUserDto createAppUser);
        Task<AppUser> ChangePassword(ChangePasswordDto changePasswordDto,string email);
        Task<AppUser> GetByEmail(string email);
        Task<IdentityResult> AddRole(string role);
        Task<IEnumerable<AppUser>> GetAppUsers();
    }
}
