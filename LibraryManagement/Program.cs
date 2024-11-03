using SystemMenecmentSystemEdit.Models;
using SystemMenecmentSystemEdit.Services.Concretes;
using SystemMenecmentSystemEdit.Services.Interface;

namespace SystemMenecmentSystemEdit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILibrarianService service = new LibrarianService();
            //Librarian librarian = new Librarian( 1,"Togrul")
            //{
            //    HireDate = DateTime.Now
            //};
            //service.CreateLibrarian(librarian);
            //Librarian baseLibrarian =service.GetLibrarianById(1);
            //try { Console.WriteLine(baseLibrarian.LibrarianStatus); }
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            Book book = new Book(2000, "C#_language")
            {
                janre = Enums.BookGenre.Fiction
            };
            IBookService bookService = new BookService();
            bookService.CreateBook(book);
            Console.WriteLine(bookService.GetBook(1).Title); 




        }
    }
}
