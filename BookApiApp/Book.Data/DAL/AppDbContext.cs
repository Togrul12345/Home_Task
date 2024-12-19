using Entities=Book.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Book.Data.DAL
{
    public class AppDbContext:DbContext
    {
      
        public AppDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<Entities.Author> Authors { get; set; }
        public DbSet<Entities.Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
