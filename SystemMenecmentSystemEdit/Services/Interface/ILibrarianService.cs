using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Models;

namespace SystemMenecmentSystemEdit.Services.Interface
{
    internal interface ILibrarianService
    {
        Librarian GetLibrarianById(int id);
        List<Librarian> GetAllLibrarians();
        void CreateLibrarian(Librarian librarian);
        void DeleteLibrarian(int id,bool IsSoftDelete);

    }
}
