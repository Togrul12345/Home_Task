using AutoMapper;
using Final.Bl.Dtos.CategoryDtos;
using Final.Bl.Dtos.ProductDtos;
using Final.Bl.Services.Interfaces;
using Final.Core;
using Final.Data.GenericRepositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Create(CreateProductDto createProductDto)
        {
           Product product= _mapper.Map<Product>(createProductDto);
           await _productRepository.CreateAsync(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           await _productRepository.HardDeleteAsync(id);
            return true;
        }

        public async Task<List<Product>> GetAll()
        {
          return  await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetById(int id)
        {
          return await _productRepository.GetByIdAsync(id);
        }

        public async Task<bool> Update(int id, UpdateCategoryDto updateCategoryDto)
        {
           Product product= _mapper.Map<Product>(updateCategoryDto);
            product.Id = id;
            _productRepository.Update(product);
           await _productRepository.SaveChangesAsync();
            return true;
        }
    }
}
