using System.Linq;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class RoleController : Controller
    {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly Context _context;

            public RoleController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, Context context)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _roleManager = roleManager;
                _context = context;
            }

            public IActionResult Index()
            {
            var roles = _roleManager.Roles.ToList();
               return View(roles);
            }
    }
}