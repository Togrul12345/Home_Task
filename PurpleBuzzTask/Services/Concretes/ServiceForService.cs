using PurpleBuzzTask.Services.Interfaces;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.DAL;
using Microsoft.EntityFrameworkCore;

namespace PurpleBuzzTask.Services.Concretes
{
    public class ServiceForService : IServiceForService
    {
        private readonly AppDbContext _appDbContext;
        public ServiceForService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateService(Service service)
        {
            _appDbContext.Services.Add(service);
            int rows =await  _appDbContext.SaveChangesAsync();
            if (rows != 1)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<List<Service>> GetAllService()
        {
          List<Service> services=await  _appDbContext.Services.ToListAsync();
            return services;    
        }

        public Task<Service> GetServiceById(int id)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
