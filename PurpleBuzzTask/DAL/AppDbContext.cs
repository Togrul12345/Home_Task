using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkPhoto> WorkPhotos { get; set; }

        //public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EmployeeWork> EmployeeWorks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext(DbContextOptions options):base(options) 
        {
            
        }
       

    }
}
