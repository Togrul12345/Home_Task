using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string AppUserId { get; set; }
    }
}
