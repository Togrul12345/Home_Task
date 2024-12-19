using PurpleBuzzTask.Areas.Dashboard.Models.Base;

namespace PurpleBuzzTask.Areas.Dashboard.Models
{
    public class BaseAuditableEntity:BaseEntity
    {
   
        public DateTime CreatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
