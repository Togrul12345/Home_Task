using PurpleBuzzTask.Areas.Dashboard.Models;
using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzTask.Models
{
    public class Work:BaseAuditableEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "minimum 3 ola biler")]
        public string Description { get; set; }
        public string MainImgUrl { get; set; }
        public List<WorkPhoto> WorkPhotos { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public ICollection<EmployeeWork>? EmployeeWorks { get; set; }

    }
}
