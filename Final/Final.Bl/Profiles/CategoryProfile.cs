using AutoMapper;
using Final.Bl.Dtos.CategoryDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>().ForMember(dest=>dest.Name,d=>d.MapFrom(src=>src.Name));
            CreateMap<CreateCategoryDto, Category>().ForMember(dest => dest.Description, d => d.MapFrom(src => src.Description));
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
