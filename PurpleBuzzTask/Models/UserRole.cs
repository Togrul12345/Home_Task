using Microsoft.AspNetCore.Identity;

namespace PurpleBuzzTask.Models
{
    public class UserRole:IdentityRole
    {
        public string Description { get; set; }
    }
}
