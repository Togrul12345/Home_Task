using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Enums;

namespace SystemMenecmentSystemEdit.Models
{
    public  class Librarian:Person
    {
        public LibrarianStatus LibrarianStatus { get; set; }
        public Librarian(int id, string name) : base(id, name)
        {
        }

        public DateTime HireDate { get; set; }
        
    }
}
