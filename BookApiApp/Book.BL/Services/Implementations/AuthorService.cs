using Book.BL.Services.Abstractions;
using Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Services.Implementations
{
    internal class AuthorService : IAuthorService
    {
        public Task<Author> CreateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
