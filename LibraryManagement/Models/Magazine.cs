using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMenecmentSystemEdit.Models
{
    internal class Magazine : LibraryItem
    {
        public Magazine(int publicationYear, string title) : base(publicationYear, title)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("it is magazine");
        }
    }
}
