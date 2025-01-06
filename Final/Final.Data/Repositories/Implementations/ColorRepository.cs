using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Implementations;
using Final.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Repositories.Implementations
{
    public class ColorRepository : GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(FinalAppDbContext finalAppDbContext) : base(finalAppDbContext)
        {
        }
    }
}
