using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core
{
    public class Color:BaseAuditableEntity
    {
        public string Name { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }

    }
}
