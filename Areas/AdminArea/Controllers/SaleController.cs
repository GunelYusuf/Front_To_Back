using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.Models;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SaleController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context;

        public SaleController(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {

            List<Sales> sales = _context.Sales.Include(p => p.ProductSales).ThenInclude(p => p.PRODUCTS1).Include(u => u.AppUser).ToList();
            return View(sales);
        }

        public async Task <IActionResult> Detail(int? Id)
        {
            Sales sales = await _context.Sales.Include(p => p.ProductSales).ThenInclude(p => p.PRODUCTS1).Include(u => u.AppUser).FirstOrDefaultAsync();
            return View(sales);
        }
    }
}