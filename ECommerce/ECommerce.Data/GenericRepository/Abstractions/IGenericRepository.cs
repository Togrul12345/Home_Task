using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.GenericRepository.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseAuditableEntity
    {
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity> GetByIdAsync(int id);
        void SoftDelete(Tentity entity);
        void HardDelete(Tentity entity);
        void Update(Tentity entity);
        Task<Tentity> CreateAsync(Tentity entity);
        Task<int> SaveChanges();
    }
}
