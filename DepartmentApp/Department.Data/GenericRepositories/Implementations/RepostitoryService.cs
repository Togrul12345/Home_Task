using Department.Data.Contexts;
using Department.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.Data.Repositories.Implementations
{
    public class RepostitoryService<Tentity> : IRepositoryService<Tentity> where Tentity:class
    {
        private readonly DepartmentDbContext _departmentDbContext;

        public RepostitoryService(DepartmentDbContext departmentDbContext)
        {
            _departmentDbContext = departmentDbContext;
        }
        DbSet<Tentity> Table => _departmentDbContext.Set<Tentity>();

        public void Update(Tentity tentity)
        {
            Table.Update(tentity);
        }
    }
}
