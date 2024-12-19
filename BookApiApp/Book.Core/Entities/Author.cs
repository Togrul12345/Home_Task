using Book.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Entities
{
    public class Author : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
