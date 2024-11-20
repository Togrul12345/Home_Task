using AcademtManagementEFApp.Helpers;
using AcademtManagementEFApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademtManagementEFApp.Context
{
    public class AppDBContext:DbContext
    {
       public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlHelper.GetConnectionString());
        }
    }
}
