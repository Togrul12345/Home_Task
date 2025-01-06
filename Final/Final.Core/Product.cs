using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core
{
    public class Product:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
    
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
    }
}
