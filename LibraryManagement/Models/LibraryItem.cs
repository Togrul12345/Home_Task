using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMenecmentSystemEdit.Models
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public  int? PublicationYear { get; set; }
        public abstract void DisplayInfo();
        protected LibraryItem(int publicationYear,string title)
        {
            PublicationYear = publicationYear;
            Title = title;
        }
    }
}
