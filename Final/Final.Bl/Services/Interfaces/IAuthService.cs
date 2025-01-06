using Final.Bl.Dtos.AppUserDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AppUser> Register(CreateAppUser createAppUser);
        Task<string> Login(LoginAppUserDto loginAppUserDto);
    }
}
