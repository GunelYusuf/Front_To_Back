using System.Linq;
using System.Threading.Tasks;
using FronToBack.Areas.AdminArea.ViewModels;
using FrontToBack.Areas.AdminArea.ViewModels;
using FrontToBack.DAL;
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
        private readonly Context _context;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,Context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IActionResult> Index(string name)
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

        public async Task<IActionResult> CreateUser(RegisterVM user)
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
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateUser(string id)
        {
            if (id == null) return NotFound();
            var user = _userManager.FindByIdAsync(id);
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UpdateUser(AppUser appUser)
        {
            AppUser user = await _userManager.FindByIdAsync(appUser.Id);
            
            user.FullName = appUser.FullName;
            user.UserName = appUser.UserName;
            user.PasswordHash = appUser.PasswordHash;
            user.Email = appUser.Email;
            await _userManager.UpdateAsync(user);
            return View();

        }


        public async Task<IActionResult> IsActive(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }
            if (user.IsActive)
            {
                user.IsActive = false;
            }
            else
            {
                user.IsActive = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
