using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.Models;
using FrontToBack.DAL;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontToBack.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        public HeaderViewComponent(Context context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserName = user.FullName;
            };
            ViewBag.ProductCount = 0;
            string basketCookie = Request.Cookies["basketCookie"];
            if (basketCookie!=null)
            {
               
                List<BasketProduct> basketProductList = JsonConvert.DeserializeObject<List<BasketProduct>>(basketCookie);
                ViewBag.ProductCount = basketProductList.Count;

                //if total product number
                //foreach (var item in basketProductList)
                //{
                //    total += item.Count;
                //}
                //ViewBag.ProductCount = total;
            }
            Bio bio = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));

        }
    }
}
