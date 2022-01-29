using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.Models;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FronToBack.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Context _context ;

        public CommentController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,Context context )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Comment comment)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var dataComment = new Comment();
                    dataComment.PRODUCTS1Id = comment.PRODUCTS1Id;
                    dataComment.UserId = comment.UserId;
                    dataComment.Comments = comment.Comments;
                    await _context.Comment.AddAsync(dataComment);
                    _context.SaveChanges();

                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
            return RedirectToAction("Index");

        }

    }
}
