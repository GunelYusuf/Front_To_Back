using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FronToBack.Models;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //ViewBag.ProductCount = _context.pRODUCTS1s.Count();
            List<PRODUCTS1> pRODUCTS1s = _context.pRODUCTS1s.Include(g => g.CATEGORY1).Take(5).ToList();
            return PartialView("_ProductPartial", pRODUCTS1s);

        }
        //public IActionResult LoadMore()
        //{
        //    return Json(_context.pRODUCTS1s.Select(p => new ProductReturn
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Price = p.Price,
        //        ImageUrl = p.ImageUrl,
        //        CATEGORY1 = p.CATEGORY1.Name

        //    }).Take(4).ToList()); ;
        //}

        public IActionResult LoadMore(int skip)
        {
            IEnumerable<PRODUCTS1> pRODUCTS1s = _context.pRODUCTS1s.Include(c => c.CATEGORY1).Skip(skip).Take(8).ToList();
            return Json(_context.pRODUCTS1s.Skip(skip).Take(5).ToList());
        }

        public IActionResult Search(string search)
        {
            IEnumerable<PRODUCTS1> pRODUCTS1s = _context.pRODUCTS1s
                .Include(c => c.CATEGORY1)
                .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .OrderByDescending(p => p.Id)
                .Take(8)
                .ToList();
            return PartialView("_SearchPartial", pRODUCTS1s);
        }

        public IActionResult Detail(int id)
        {
            IEnumerable<Comment> comments= _context.Comment.Where(c => c.PRODUCTS1Id == id);

            PRODUCTS1 pRODUCTS1 = _context.pRODUCTS1s.Include(c => c.CATEGORY1).FirstOrDefault(p => p.Id == id);
            ViewBag.ProductID =pRODUCTS1.Id;
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserID = userId;
            PRODUCTS1 pRODUCTS = new PRODUCTS1
            {
                Name = pRODUCTS1.Name,
                Price = pRODUCTS1.Price,
                CATEGORY1Id = pRODUCTS1.CATEGORY1Id,
                ImageUrl = pRODUCTS1.ImageUrl,
                CommentProduct = comments,
            };
            return View(pRODUCTS);

        }

    }
}