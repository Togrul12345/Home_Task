using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Work> Works { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
