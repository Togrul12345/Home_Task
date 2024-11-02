using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SystemMenecmentSystemEdit.Exceptions;
using SystemMenecmentSystemEdit.Models;


namespace SystemMenecmentSystemEdit.Helper
{
    public static class LibraryHelper
    {
        public static int CalculateAge(this LibraryItem libraryItem)
        {
            if (libraryItem.PublicationYear == null)
            {
                throw new LibraryItemException("null olabilmez");
            }
            int age= DateTime.Now.Year - libraryItem.PublicationYear.Value;
            return age;
        }
        public static string TitleCase(this LibraryItem libraryitem)
        {
            return libraryitem.Title[0].ToString().ToUpper() + libraryitem.Title.Substring(1).ToLower();

        }
    }
}
