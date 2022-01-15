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
    }
}
