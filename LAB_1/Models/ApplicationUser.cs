using Microsoft.AspNetCore.Identity;

namespace WEB.Models
{
    public class ApplicationUser: IdentityUser
    {
        public byte[]? AvatarImage { get; set; }
    }
}
