using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using FronToBack.Models;
using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(Context context,UserManager<AppUser>userManager)
        {
            _context = context;
           _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("LogIn","Account");
            }
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          
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
                    Count = 1,
                    UserId=userId
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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
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
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ViewBag.UserID = userId;
            return View(basketProductList);
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
            return View(basketProductList);
        }

        public async Task<IActionResult> Sale()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("LogIn", "Account");

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Sales sales = new Sales();
            sales.AppUserId = user.Id;
            sales.SaleDate = DateTime.Now;

            List<BasketProduct> basketProducts = JsonConvert.DeserializeObject<List<BasketProduct>>(Request.Cookies["basketCookie"]);
            List<ProductSales> productSalesList = new List<ProductSales>();


            List<PRODUCTS1> dbProducts = new List<PRODUCTS1>();
            foreach (var item in basketProducts)
            {
                PRODUCTS1 dbProduct = await _context.pRODUCTS1s.FindAsync(item.Id);
                if (dbProduct.Count<item.Count)
                {
                    TempData["Failed"] = $"{item.Name} is not in the database";
                    return RedirectToAction("ShowBaket", "Basket");
                }
                dbProducts.Add(dbProduct);
             
            }

            double total = 0;
            foreach (var basketProduct in basketProducts)
            {
                PRODUCTS1 dbProduct = dbProducts.Find(p => p.Id == basketProduct.Id);

                await UpdateProductCount(dbProduct, basketProduct);

                ProductSales productSales = new ProductSales();
                productSales.SalesId = sales.Id;
                productSales.PRODUCTS1Id = dbProduct.Id;

                productSalesList.Add(productSales);
                total += basketProduct.Count * basketProduct.Price;
            }

            sales.ProductSales = productSalesList;
            sales.Total = total;
            await _context.Sales.AddAsync(sales);
            await _context.SaveChangesAsync();
            TempData["Success"] = "The sale was completed successfully";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("guntebrustemov@gmail.com", "Succes Sale!");
                mail.To.Add(user.Email);
                mail.Subject = "Successfully";
                mail.Body = "The sale was completed successfully!";
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("guntebrustemov", "gunteb7@");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);

                }
            }
            return RedirectToAction("Index", "Home");
        }

        private async Task UpdateProductCount(PRODUCTS1 product,BasketProduct basketProduct)
        {
            product.Count = product.Count - basketProduct.Count;
            await _context.SaveChangesAsync();
        }
    }
}
