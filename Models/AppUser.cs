using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FronToBack.Models;
using Microsoft.AspNetCore.Identity;

namespace FrontToBack.Models
{
    public class AppUser:IdentityUser
    {
        [Required,StringLength(maximumLength:50)]

        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public List<Sales> Sales { get; set; }

       
    }
}
