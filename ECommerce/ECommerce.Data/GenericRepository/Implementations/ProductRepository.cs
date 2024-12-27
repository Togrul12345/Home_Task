using ECommerce.Core.Entities;
using ECommerce.Data.Contexts;
using ECommerce.Data.GenericRepository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.GenericRepository.Implementations
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
