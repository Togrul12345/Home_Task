using AutoMapper;
using Final.Bl.Dtos.SizeDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Profiles
{
    public class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeDto, Size>();
        }
    }
}
