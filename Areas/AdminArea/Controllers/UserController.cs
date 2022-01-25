using System.Linq;
using System.Threading.Tasks;
using FronToBack.Areas.AdminArea.ViewModels;
using FrontToBack.Areas.AdminArea.ViewModels;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FronToBack.Areas.AdminArea.Controllers
{

    [Area("AdminArea")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index(string name)
        {

            var users = name == null ? _userManager.Users.ToList() :
              _userManager.Users.Where(u => u.FullName.ToLower().Contains(name.ToLower())).ToList();
            //List<UserVM> userVMs = new List<UserVM>();
            //foreach (var user in users)
            //{
            //    UserVM userVM = new UserVM();
            //    userVM.FullName = user.FullName;
            //    userVM.UserName = user.UserName;
            //    userVM.Email = user.Email;
            //    userVM.Role = (await _userManager.GetRolesAsync(user))[0];
            //    userVMs.Add(userVM);
            //}
            return View(users);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserRoleVM userRoleVM = new UserRoleVM();
            userRoleVM.AppUser = user;
            //userRoleVM.Roles= _roleManager.Roles.ToList();
            userRoleVM.Roles = await _userManager.GetRolesAsync(user);
            return View(userRoleVM);
        }

        public IActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateUser(CreateUserVM user)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,

            };
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, user.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, $"{user.Role}");
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }


    }
}
