using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Abstractions;
using Final.Data.GenericRepositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Repositories.Implementations
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(FinalAppDbContext finalAppDbContext) : base(finalAppDbContext)
        {
        }
    }
}
