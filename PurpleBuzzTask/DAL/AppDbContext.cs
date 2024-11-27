using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Work> Works { get; set; }
        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
