using AutoMapper;
using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Abstractions;
using Final.Data.GenericRepositories.Implementations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Create(CreateCategoryDto createCategoryDto)
        {
            Category category = _mapper.Map<Category>(createCategoryDto);
            category.ImgUrl = createCategoryDto.File.FileName;
          
           await _categoryRepository.CreateAsync(category);
           await _categoryRepository.SaveChangesAsync();
            return category;
        }
        public async Task<bool> DeleteAsync(int id)
        {
           await _categoryRepository.HardDeleteAsync(id);
           await _categoryRepository.SaveChangesAsync();
            return true;
        }
        public async Task<Category> GetById(int id)
        {
          return await _categoryRepository.GetByIdAsync(id);
        }
        public async Task<List<Category>> GetAll()
        {
           return await _categoryRepository.GetAllAsync();
        }

        public async Task<bool> Update(int id,UpdateCategoryDto updateCategoryDto)
        {
           Category category= _mapper.Map<Category>(updateCategoryDto);
            category.Id = id;

            _categoryRepository.Update(category);
           await _categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}
