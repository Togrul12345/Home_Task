using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Models;

namespace SystemMenecmentSystemEdit.Services.Interface
{
    public interface IBookService
    {
        void CreateBook(Book book);
        void DeleteBook(int id);
        List<Book> GetAllBooks();
        Book GetBook(int id);

    }
}
