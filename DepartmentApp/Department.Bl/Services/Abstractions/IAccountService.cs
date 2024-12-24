using Department.Bl.Dtos.AppUserDto;
using Department.Core;
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
        Task<AppUser> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<AppUser> GetByEmail(string email);
    }
}
