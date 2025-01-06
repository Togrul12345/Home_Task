using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core
{
    public class ProductSize:BaseAuditableEntity
    {
       
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Size Size { get; set; }
        public int SizeId { get; set; }
    }
}
