using System;
using System.Collections.Generic;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;

namespace FronToBack.ViewModels
{
    public class UpdateRoleVM
    {
        public IList<IdentityRole> Roles { get; set; }

        public IList<string> UserRoles { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
