using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorIdentity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
