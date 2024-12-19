using PurpleBuzzTask.Models;

namespace PurpleBuzzTask.Services.Interfaces
{
    public interface IServiceForService
    {
        public Task<List<Service>> GetAllService();
        public Task CreateService(Service service);
        public Task<Service> GetServiceById(int id);
        public Task SoftDelete(int id);
        public Task HardDelete(int id);
    }
}
