using System;
using System.Collections.Generic;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;

 namespace FrontToBack.Areas.AdminArea.ViewModels
{
    public class UserRoleVM
    {
        public AppUser AppUser;

        public IList<string> Roles;
    }
}
