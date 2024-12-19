using PurpleBuzzTask.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PurpleBuzzTask.DTOs.WorkDTOs
{
    public class UpdateWorkDTO
    {
        public int Id { get; set; }
        [MinLength(3), DisallowNull]
        public string Title { get; set; }

        
        
        public string Description { get; set; }
        public string? ExistingMainImgUrl { get; set; }
        public  List<WorkPhoto>? ExistingPhotos { get; set; }
        public IFormFile? NewMainImg { get; set; }
        public List<IFormFile>? NewPhotos { get; set; }
   
    
    }
}
