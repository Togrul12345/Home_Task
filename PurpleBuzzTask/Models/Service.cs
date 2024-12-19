using PurpleBuzzTask.Areas.Dashboard.Models;

namespace PurpleBuzzTask.Models
{
    public class Service:BaseAuditableEntity
    {
        
        public string Title { get; set; }

        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public ICollection<Work> Works { get; set; }

    }
}
