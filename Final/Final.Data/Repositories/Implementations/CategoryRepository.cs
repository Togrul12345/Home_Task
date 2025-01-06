using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.GenericRepositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FinalAppDbContext finalAppDbContext) : base(finalAppDbContext)
        {
        }
    }
}
