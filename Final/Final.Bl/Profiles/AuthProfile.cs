using AutoMapper;
using Final.Bl.Dtos.AppUserDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Profiles
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<CreateAppUser, AppUser>();
        }
    }
}
