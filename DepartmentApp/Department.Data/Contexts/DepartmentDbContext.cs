using Department.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Department.Data.Contexts
{
    public class DepartmentDbContext:IdentityDbContext<AppUser>
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> opt):base(opt)
        {
            
        }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
