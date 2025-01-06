using Final.Bl.Dtos.CategoryDtos;
using Final.Core;
using Final.Data.GenericRepositories.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> Create(CreateCategoryDto createCategoryDto);
        Task<bool> DeleteAsync(int id);
        Task<Category> GetById(int id);
        Task<List<Category>> GetAll();
        Task<bool> Update(int id,UpdateCategoryDto updateCategoryDto);
    }
}
