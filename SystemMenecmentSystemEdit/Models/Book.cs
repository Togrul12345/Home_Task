using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMenecmentSystemEdit.Enums;

namespace SystemMenecmentSystemEdit.Models
{
    public class Book : LibraryItem
    {
        private static int _count;
        public  int Id { get; set; }
        public Book(int publicationYear, string title) : base(publicationYear, title)
        {
            _count++;
            Id = _count;
        }

        public BookGenre janre { get; set; }
        

        public override void DisplayInfo()
        {
            Console.WriteLine("It is Book");
        }
    }
}
