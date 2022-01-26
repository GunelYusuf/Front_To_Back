using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.ViewModels;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(string role)
        {
            if (!string.IsNullOrEmpty(role))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.Trim()));
                }
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Delete(string role)
        {

            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.DeleteAsync(new IdentityRole(role));
            }
            return NotFound();
        }


        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UpdateRoleVM updateUserRole = new UpdateRoleVM
            {
                User = user,
                UserId = user.Id,
                Roles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(user)
            };
            return View(updateUserRole);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(string id,IList<string>Roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            UpdateRoleVM updateUserRole = new UpdateRoleVM
            {
                User = user,
                UserId = user.Id,
                Roles = _roleManager.Roles.ToList(),
                UserRoles = await _userManager.GetRolesAsync(user)
            };
            return View(updateUserRole);

        }

    }
}