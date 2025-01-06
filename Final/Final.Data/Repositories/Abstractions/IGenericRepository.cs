using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.GenericRepositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity:BaseAuditableEntity
    {
        Task<Tentity> CreateAsync(Tentity tentity);
        Task<List<Tentity>> GetAllAsync();
        Task<Tentity> GetByIdAsync(int id);
        void Update(Tentity tentity);
        Task SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
        Task<int> SaveChangesAsync();
        
    }
}
