using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Dtos.ProductDtos;
using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Create(CreateProductDto createProductDto);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task<bool> Update(int id, UpdateCategoryDto updateCategoryDto);
    }
}
