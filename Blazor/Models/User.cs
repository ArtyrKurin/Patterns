using Microsoft.AspNetCore.Identity;

namespace Blazor.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
