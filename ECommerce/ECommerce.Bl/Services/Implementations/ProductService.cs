using AutoMapper;
using ECommerce.Bl.Dtos.ProductDtos;
using ECommerce.Bl.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.Contexts;
using ECommerce.Data.GenericRepository.Abstractions;
using ECommerce.Data.GenericRepository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Bl.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ECommerceDbContext eCommerceDbContext, IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }



        public async Task<Product> CreateProductAsync(CreateProductDto entity)
        {
          Product product=  _mapper.Map<Product>(entity);
            
            await _productRepository.CreateAsync(product);
            await  _productRepository.SaveChanges();
            return product;
            
        }

        public Task<Product> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
           var product=await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Book is not found");
            }
            return product;
        }

        public void HardDelete(Product entity)
        {
            throw new NotImplementedException();
        }

       

        public void SoftDelete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

       async Task<int> IGenericRepository<Product>.SaveChanges()
        {
          return await _productRepository.SaveChanges();
        }

        public async Task<Product> UpdateProduct(UpdateProductDto updateProductDto,int id)
        {
           Product result =_mapper.Map<Product>(updateProductDto);
            Product product=await _productRepository.GetByIdAsync(id);
            result.UpdatedAt = DateTime.Now;
            result.Id = id;
            _productRepository.Update(result);
            await _productRepository.SaveChanges();
            return result;
            
        }

        public Task<Product> EditProduct(EditProductDto editProductDto)
        {
            _mapper.Map<Product>(editProductDto);
        }
    }
}
