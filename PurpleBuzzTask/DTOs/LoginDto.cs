using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzTask.DTOs
{
    public class LoginDto
    {
        [Required]
        [Display(Prompt ="enter email or username")]
        public string EmailOrUsername { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
