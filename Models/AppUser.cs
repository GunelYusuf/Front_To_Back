using System;
using Microsoft.AspNetCore.Identity;

namespace FronToBack.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
