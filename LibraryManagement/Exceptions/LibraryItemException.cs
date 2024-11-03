using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMenecmentSystemEdit.Exceptions
{
    public class LibraryItemException:Exception
    {
        public LibraryItemException():base("it is Exception")
        {
            
        }
        public LibraryItemException(string message):base(message)
        {
            
        }
    }
}
