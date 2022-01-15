using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CATEGORY1> categories = _context.cATEGORies.ToList();
            return View(categories);
        }

        public async Task<IActionResult>Detail(int? Id)
        {
            if (Id == null) return NotFound();
            CATEGORY1 dbCategory = await _context.cATEGORies.FindAsync(Id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CATEGORY1 category)
        {
            bool isExist = _context.cATEGORies.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (isExist)
            {
                ModelState.AddModelError("Name", "The category with this name already exists");
                View();
            }
            CATEGORY1 newCategory = new CATEGORY1
            {
                Name = category.Name,
                Description = category.Description
            };
           await _context.AddAsync(newCategory);
           await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id,string name)
        {
            if (id == null) return NotFound();
            CATEGORY1 dbCategory = await _context.cATEGORies.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }

        [HttpPost]

        public async Task<IActionResult> Update(CATEGORY1 category)
        {
            if (!ModelState.IsValid) return View();
            bool isExist = _context.cATEGORies.Any(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            CATEGORY1 isExistCategory = _context.cATEGORies.FirstOrDefault(c => c.Id == category.Id);
            if (isExist && !(isExistCategory.Name.ToLower() == category.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "The category with this name already exists");
                View();
            }
            {
                isExistCategory.Name = category.Name;
                isExistCategory.Description = category.Description;
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
          

        }
    }
}
