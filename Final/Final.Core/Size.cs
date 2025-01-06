using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core
{
    public class Size:BaseAuditableEntity
    {
        public float Title { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
