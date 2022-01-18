using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.Areas.AdminArea.ViewModels;
using FronToBack.Extensions;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            ViewBag.category = categories;
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

            if (ModelState["ImageProduct"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                ModelState.AddModelError("ImageProduct", "Don't empty");
            }

            if (!product.ImageProduct.IsImage())
            {
                ModelState.AddModelError("ImageProduct", "just image");
                return View();
            }
            if (product.ImageProduct.IsCorrectSize(300))
            {
                ModelState.AddModelError("ImageProduct", "Enter the size correctly");
                return View();
            }



            string fileName = await product.ImageProduct.SaveImageAsync(_env.WebRootPath, "Products-Images");
            PRODUCTS1 newProduct = new PRODUCTS1
            {
                CATEGORY1=product.CATEGORY1,
                Name = product.Name,
                Price = product.Price,
                ImageUrl=fileName,
                CATEGORY1Id=product.CATEGORY1Id
               
            };
            await _context.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(id);
            if (dbProduct == null) return NotFound();

            return View(dbProduct);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();
            PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(id);
            if (dbProduct == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "Products-Images", dbProduct.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.pRODUCTS1s.Remove(dbProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(id);
            if (dbProduct == null) return NotFound();

            List<SelectListItem> categories = (from i in _context.cATEGORies.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();
            ViewBag.category = categories;
            return View(dbProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, PRODUCTS1 product)
        {
            if (id == null) return NotFound();

            if (!ModelState.IsValid) return View();
            bool isExist = _context.pRODUCTS1s.Any(c => c.Name.ToLower() == product.Name.ToLower().Trim());

            PRODUCTS1 isExistProduct = _context.pRODUCTS1s.FirstOrDefault(p => p.Id == product.Id);

            if (isExist && !(isExistProduct.Name.ToLower() == product.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "The product with this name already exists");
                return View();
            };



            if (product.ImageProduct != null)
            {
                if (ModelState["ImageProduct"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    ModelState.AddModelError("ImageProduct", "Don't empty");
                }

                if (!product.ImageProduct.IsImage())
                {
                    ModelState.AddModelError("ImageProduct", "just image");
                    return View();
                }
                if (product.ImageProduct.IsCorrectSize(400))
                {
                    ModelState.AddModelError("ImageProduct", "Enter the size correctly");
                    return View();
                }
                PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(id);
                string path = Path.Combine(_env.WebRootPath, "Products-Images", dbProduct.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                string fileName = await product.ImageProduct.SaveImageAsync(_env.WebRootPath, "Products-Images");

                dbProduct.CATEGORY1 = product.CATEGORY1;
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.ImageUrl = fileName;
                dbProduct.CATEGORY1Id = product.CATEGORY1Id;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
