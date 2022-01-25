using System.Linq;
using System.Threading.Tasks;
using FrontToBack.Models;
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
    }
}
