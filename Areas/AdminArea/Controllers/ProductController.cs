using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.Areas.AdminArea.ViewModels;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly Context _context;
        public ProductController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<PRODUCTS1> products = _context.pRODUCTS1s.Include(c => c.CATEGORY1).ToList();
            return View(products);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return NotFound();
            PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(Id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);
        }

        public IActionResult Create()
        {
            List < SelectListItem> categories= (from i in _context.cATEGORies.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Name,
                                                    Value = i.Id.ToString()
                                                }).ToList();
            ViewBag.dgr = categories;
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PRODUCTS1 product)
        {
            bool isExist = _context.pRODUCTS1s.Any(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name", "The product with this name already exists");
                View();
            }
           PRODUCTS1 newProduct = new PRODUCTS1
            {
                CATEGORY1=product.CATEGORY1,
                Name = product.Name,
                Price = product.Price,
                ImageProduct=product.ImageProduct,
                CATEGORY1Id=product.CATEGORY1Id
               
            };
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}