using Mediplus.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediplus.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<DoctorHospital> DoctorHospitals { get; set; }
    }
}
