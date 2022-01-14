using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontToBack.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly Context _context;
        public HeaderViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.ProductCount = 0;
            string basketCookie = Request.Cookies["basketCookie"];
            if (basketCookie!=null)
            {
                int total = 0;
                List<BasketProduct> basketProductList = JsonConvert.DeserializeObject<List<BasketProduct>>(basketCookie);
                ViewBag.ProductCount = basketProductList.Count;

            // if total product number
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
