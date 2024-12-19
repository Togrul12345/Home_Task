using PurpleBuzzTask.Models;
using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzTask.DTOs.WorkDTOs
{
    public class CreateWorkDTO
    {
        [Required(ErrorMessage ="required")]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "minimum 3 ola biler")]
        public string Description { get; set; }
    

        public List<IFormFile> WorkPhotos { get; set; }
        [Required(ErrorMessage = "required")]
        public IFormFile MainImg { get; set; }
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "required")]
        public List<int> EmployeIds { get; set; }


    }
}
