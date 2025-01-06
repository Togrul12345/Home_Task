using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.GenericRepositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseAuditableEntity, new()
    {
        private readonly FinalAppDbContext _finalAppDbContext;

        public GenericRepository(FinalAppDbContext finalAppDbContext)
        {
            _finalAppDbContext = finalAppDbContext;
        }
        public DbSet<Tentity> Table => _finalAppDbContext.Set<Tentity>();

        public async Task<Tentity> CreateAsync(Tentity tentity)
        {
            await Table.AddAsync(tentity);
            return tentity
;
        }

        public async Task<List<Tentity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var result = await Table.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (result == null)
            {
                throw new Exception("Something went wrong");
            }
            return result;
        }

        public async Task HardDeleteAsync(int id)
        {
            var result= await GetByIdAsync(id);
            Table.Remove(result);
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _finalAppDbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            result.CreatedAt = DateTime.Now;
            await SaveChangesAsync();
            
        }

        public async void Update(Tentity tentity)
        {
           
            Table.Update(tentity);
        }
    }
}
