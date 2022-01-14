using System;
using System.Collections.Generic;
using System.Linq;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class CategoryController:Controller
    {
        private readonly Context _context;
        public CategoryController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<CATEGORY1> cATEGORies = _context.cATEGORies
                .Include(p => p.pRODUCTS1s)
                .ToList();
            return View(cATEGORies);
        }
    }
}
