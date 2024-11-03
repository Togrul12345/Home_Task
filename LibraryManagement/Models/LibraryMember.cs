using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMenecmentSystemEdit.Models
{
    public sealed class LibraryMember : Person
    {
        public LibraryMember(int id, string name) : base(id, name)
        {
        }
        public DateTime MemberShipDate { get; set; }

    }
}
