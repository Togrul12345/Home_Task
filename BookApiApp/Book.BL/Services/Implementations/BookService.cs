using Book.BL.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Services.Implementations
{
    internal class BookService : IBookService
    {
        public Task<Core.Entities.Book> CreateAsync(Core.Entities.Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Core.Entities.Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Entities.Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Entities.Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
