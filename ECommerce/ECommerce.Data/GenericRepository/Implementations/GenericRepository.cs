using ECommerce.Core.Entities;
using ECommerce.Data.Contexts;
using ECommerce.Data.GenericRepository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.GenericRepository.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseAuditableEntity, new()
    {
        private readonly ECommerceDbContext _context;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
        }
        public DbSet<Tentity> Table => _context.Set<Tentity>();
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var result = await Table.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (result == null)
            {
                throw new Exception("Tentity is not found");
            }
            return result;
        }

        public void HardDelete(Tentity entity)
        {
            Table.Remove(entity);
        }

       

        public void SoftDelete(Tentity entity)
        {
            entity.IsDeleted = true;
        }

        public void Update(Tentity entity)
        {
           _context.Update(entity);
        }

         async Task<int> IGenericRepository<Tentity>.SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
