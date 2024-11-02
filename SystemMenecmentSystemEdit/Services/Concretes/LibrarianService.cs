using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Enums;
using SystemMenecmentSystemEdit.Models;
using SystemMenecmentSystemEdit.Services.Interface;

namespace SystemMenecmentSystemEdit.Services.Concretes
{
    internal class LibrarianService : ILibrarianService
    {
        public List<Librarian> Librarians;
        public LibrarianService()
        {
            Librarians = new List<Librarian>();
        }
        public void CreateLibrarian(Librarian librarian)
        {
            Librarians.Add(librarian);
        }

        public void DeleteLibrarian(int id, bool IsSoftDelete)
        {
            int index = -1;
            for(int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                if (IsSoftDelete)
                {
                    Librarians[index].LibrarianStatus = Enums.LibrarianStatus.removed;
                }
                else
                {
                    Librarians.Remove(Librarians[index]);
                }
            }
            else
            {
                throw new Exception($"LibrarianList daxilinde axtarilan {id}-idsine uygun isci tapilmadigi ucun silme yekunlasdi");
            }
        }

        public List<Librarian> GetAllLibrarians()
        {
            return Librarians;
        }

        public Librarian GetLibrarianById(int id)
        {
            int index = -1;
            for (int i = 0; i < Librarians.Count; i++)
            {
                if (Librarians[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                return Librarians[index];
            }
            else
            {
                throw new Exception($"{id}-idisine uygun deyer tapilmadi");
            }
        }
    }
}
