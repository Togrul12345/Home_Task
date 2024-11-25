using PurpleBuzzTask.Areas.Dashboard.Models;

namespace PurpleBuzzTask.Models
{
    public class Work:BaseAuditableEntity
    {
      
        public string UserName { get; set; }
        public string Profession { get; set; }
        public string ImgUrl {  get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
