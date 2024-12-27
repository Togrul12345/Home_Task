using ECommerce.Bl.Dtos.ProductDtos;
using ECommerce.Core.Entities;
using ECommerce.Data.GenericRepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Bl.Services.Abstractions
{
    public interface IProductService:IGenericRepository<Product>
    {
        Task<Product> CreateProductAsync(CreateProductDto createProductDto);
        Task<Product> UpdateProduct(UpdateProductDto updateProductDto,int id);
        Task<Product> EditProduct(EditProductDto editProductDto)
    }
}
