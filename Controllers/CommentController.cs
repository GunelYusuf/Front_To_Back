using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        [AutoValidateAntiforgeryToken]

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

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id==null) return RedirectToAction("Index");
            Comment comment = _context.Comment.Find(id);
            if (comment==null)
            {
                return NotFound();
            }
            else
            {
                _context.Comment.Remove(comment);
                await _context.SaveChangesAsync();
            }
          return RedirectToAction("Index");

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Update(int? id, Comment comment)
        {
            if (id == null) return RedirectToAction("Index");
            Comment comments = _context.Comment.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                comments.Comments = comment.Comments;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}
