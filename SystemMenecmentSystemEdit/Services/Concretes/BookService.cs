using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Exceptions;
using SystemMenecmentSystemEdit.Models;
using SystemMenecmentSystemEdit.Services.Interface;

namespace SystemMenecmentSystemEdit.Services.Concretes
{
    public class BookService : IBookService
    {
        public List<Book> Books;
        public BookService()
        {
            Books=new List<Book>();
        }
        public void CreateBook(Book book)
        {
            Books.Add(book);
            
        }

        public void DeleteBook(int id)
        {
            int index = -1;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
               
                    Books.Remove(Books[index]);
                
            }
            else
            {
                throw new Exception($"LibrarianList daxilinde axtarilan {id}-idsine uygun isci tapilmadigi ucun silme yekunlasdi");
            }
        }

        public List<Book> GetAllBooks()
        {
            return Books;
        }

        public Book GetBook(int id)
        {
            int index = -1;
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {

                return Books[index];

            }
            else
            {
                throw new Exception("tapilamdi");
                
            }
            
        }
    }
}
