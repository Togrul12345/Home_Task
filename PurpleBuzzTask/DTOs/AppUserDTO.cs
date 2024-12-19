using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PurpleBuzzTask.DTOs
{
    public class AppUserDTO
    {
        
       
        [Required]
        [MinLength(2,ErrorMessage ="min length must be 2")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "max length must be 30")]
        public string LastName  { get; set; }
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
     
        [DataType(DataType.Password, ErrorMessage = "sdsasasasasas")]
        public string Password { get; set; }
        
        [DataType(DataType.Password),Compare(nameof(Password),ErrorMessage ="uygun password deyil")]
        public string ConfirmPassword { get; set; }
        
    }
}
