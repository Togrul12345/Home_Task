using AutoMapper;
using Final.Bl.Dtos.ColorDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Profiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColorDto, Color>();
        }
    }
}
