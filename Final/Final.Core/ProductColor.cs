using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core
{
    public class ProductColor:BaseAuditableEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        
    }
}
