using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Exceptions;

namespace SystemMenecmentSystemEdit.Models
{
    internal class LibraryCatalog
    {
        public List<Book> Books { get; set; }
        public  LibraryItem this[int id]
        {
            get
            {
              
                int index = -1;
                for (int i = 0; i < Books.Count; i++)
                {
                    if (Books[id] == Books[i])
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
                    throw new LibraryItemException("it is not found");
                }
            }


        }
        public LibraryCatalog(List<Book> books)
        {
            Books= books;
        }
    }
}
