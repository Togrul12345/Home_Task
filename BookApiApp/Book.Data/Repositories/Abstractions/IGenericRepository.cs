using Book.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Abstractions
{
    public interface IGenericRepository<Tentity> where Tentity : BaseEntity
    {
        Task<IEnumerable<Tentity>> GetAllAsync();   
        Task<Tentity> GetByIdAsync(int id);
        Task<Tentity> CreateAsync(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);
    }
}
