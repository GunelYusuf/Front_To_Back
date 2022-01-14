using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly Context _context;
        public BasketController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Error");
            PRODUCTS1 products = await _context.pRODUCTS1s.FindAsync(id);
            if (products == null) return RedirectToAction("Index", "Error");
            string basketCookie = Request.Cookies["basketCookie"];
            List<BasketProduct> basketProductList;
            if (basketCookie == null)
            {
                basketProductList = new List<BasketProduct>();
            }
            else
            {
                basketProductList = JsonConvert.DeserializeObject<List<BasketProduct>>(basketCookie);
            }

            BasketProduct isExistProduct = basketProductList.FirstOrDefault(p => p.Id == products.Id);
         
            if (isExistProduct == null)
            {
                BasketProduct basketProduct = new BasketProduct
                {
                    Id=products.Id,
                    Name = products.Name,
                    ImageUrl = products.ImageUrl,
                    Price = products.Price,
                    Count = 1
                };
                basketProductList.Add(basketProduct);
            }
            else
            {
                isExistProduct.Count++;
            }

            Response.Cookies.Append("basketCookie", JsonConvert.SerializeObject(basketProductList), new CookieOptions { MaxAge = TimeSpan.FromMinutes(14)});

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowBasket()
        {
            string basketCookie = Request.Cookies["basketCookie"];
            List<BasketProduct> basketProductList = new List<BasketProduct>();
            if (basketCookie != null)
            {
                basketProductList = JsonConvert.DeserializeObject<List<BasketProduct>>(basketCookie);
                foreach (var item in basketProductList)
                {
                    PRODUCTS1 product = _context.pRODUCTS1s.FirstOrDefault(p => p.Id == item.Id);
                    item.ImageUrl = product.ImageUrl;
                    item.Name = product.Name;
                    item.Price = product.Price;

                }
                Response.Cookies.Append("basketCookie",JsonConvert.SerializeObject(basketProductList),new CookieOptions { MaxAge = TimeSpan.FromMinutes(14)});
            }
            return Json(basketProductList);
        }

        public IActionResult Remove(int? id)
        {
            if (id == null) RedirectToAction("Index", "Error");
            PRODUCTS1 products = _context.pRODUCTS1s.Find(id);
            string basketCookie = Request.Cookies["basketCookie"];
            List<BasketProduct> basketProductList = JsonConvert.DeserializeObject<List<BasketProduct>>(basketCookie);
            BasketProduct isExistProduct = basketProductList.FirstOrDefault(p => p.Id == products.Id);
            basketProductList.Remove(isExistProduct);
            Response.Cookies.Append("basketCookie", JsonConvert.SerializeObject(basketProductList), new CookieOptions { MaxAge = TimeSpan.FromMinutes(14) });
            return Json(basketProductList);
        }
    }
}
