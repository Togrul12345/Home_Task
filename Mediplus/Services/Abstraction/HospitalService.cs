using Mediplus.Context;
using Mediplus.Models;
using Mediplus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mediplus.Services.Abstraction
{
    public class HospitalService : IHospitalService
    {private readonly AppDbContext _appDbContext;
        public HospitalService(AppDbContext context)
        {
            _appDbContext = context;
            
        }
        public void CreateHospital(Hospital hospital)
        {
            _appDbContext.Hospitals.Add(hospital);
            _appDbContext.SaveChanges();
        }

        public async Task<List<Hospital>> GetAllHospitals()
        {
            List<Hospital> hospitals =await _appDbContext.Hospitals.ToListAsync();
            return hospitals;   
           
        }

        public async Task<Hospital> GetHospitalById(int id)
        {
            Hospital? hospital =await _appDbContext.Hospitals.FindAsync(id);
            return hospital;
        }

        public void RemoveHospital(Hospital hospital, int id)
        {
            if (id != hospital.Id)
            {
                throw new Exception("Something went wrong");
            }
           
            _appDbContext.Hospitals.Remove(hospital);
            _appDbContext.SaveChanges();
        }
    }
}
