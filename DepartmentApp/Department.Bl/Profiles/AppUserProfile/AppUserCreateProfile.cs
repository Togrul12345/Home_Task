using AutoMapper;
using Department.Bl.Dtos.AppUserDto;
using Department.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Bl.Profiles.AppUserProfile
{
    public class AppUserCreateProfile:Profile
    {
        public AppUserCreateProfile()
        {
            CreateMap<CreateAppUserDto, AppUser>();
            CreateMap<ChangePasswordDto, AppUser>();
        }
    }
}
