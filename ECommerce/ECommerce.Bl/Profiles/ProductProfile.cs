using AutoMapper;
using ECommerce.Bl.Dtos.ProductDtos;
using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bl.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
          
        }
    }
}
