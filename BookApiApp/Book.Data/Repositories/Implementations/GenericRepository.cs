using Book.Core.Entities.Base;
using Book.Data.DAL;
using Book.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        public readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<Tentity> Table => _context.Set<Tentity>();
        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }
        public async Task<Tentity> GetByIdAsync(int id)
        {
           return await Table.FirstOrDefaultAsync(x => x.Id == id);   
        }

        public void Update(Tentity entity)
        {
           Table.Update(entity);
        }

        public void Delete(Tentity entity)
        {
          Table.Remove(entity);
        }
    }
}

