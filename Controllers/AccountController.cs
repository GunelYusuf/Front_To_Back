﻿using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FronToBack.ViewModels;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                FullName = register.FullName,
                UserName = register.UserName,
                Email = register.Email

            };
            // user.IsActive = true;
            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, true);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CheckSignIn()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }

        public IActionResult LogIn()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> LogIn(LoginVM login)
        {
            if (!ModelState.IsValid) return View();
            AppUser dbUser = await _userManager.FindByNameAsync(login.UserName);

            if (dbUser == null)
            {
                ModelState.AddModelError("", "UserName or Password wrong");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(dbUser, login.Password, true, true);

            if (dbUser.IsActive == false)
            {
                ModelState.AddModelError("", "User is Deactive");
                return View();
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "is LockOut");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password wrong");
                return View();
            }

            var roles = await _userManager.GetRolesAsync(dbUser);

            if (roles[0] == "Admin")
            {
                return RedirectToAction("Index", "Dashboard", new { area = "AdminArea" });
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task CreateRole()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!await _roleManager.RoleExistsAsync("Member"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> ForgetPassword(ForgetPassword forget)
        {
            AppUser user = await _userManager.FindByEmailAsync(forget.User.Email);
            if (user == null) NotFound();


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("guntebrustemov@gmail.com", "Reset");
                mail.To.Add(user.Email);
                mail.Subject = "Reset Password";
                mail.Body = $"<a href={link}>Go to Reset Password</a>";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("guntebrustemov", "gunteb7@");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                   
                }
                return Content("salam");
                return RedirectToAction("Home", "Index");
            }
        }

        public IActionResult ResetPassword(string email, string token)
        {
            return View();
        }
    }

}
