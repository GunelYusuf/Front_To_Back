using System.Collections.Generic;
using System.Linq;
using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Software","Developer");


            List<Slider> sliders = _context.Sliders.ToList();
            SliderTitle sliderTitle = _context.SliderTitles.FirstOrDefault();
            About about = _context.Abouts.FirstOrDefault();
            List<FlowerExperts> flowers = _context.Flowers.ToList();
            Join join = _context.Joins.FirstOrDefault();
            List<Blogs> blogs= _context.blogs.ToList();
            List<SliderMain2> sliderMain2s = _context.sliderMain2s.ToList();
            List<CATEGORY1> cATEGORY1s = _context.cATEGORies.ToList();
            List<PRODUCTS1> pRODUCTS1s = _context.pRODUCTS1s.Include(e => e.CATEGORY1).Take(7).ToList();

            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = sliders;
            homeVM.SliderTitles = sliderTitle;
            homeVM.About = about;
            homeVM.FlowerExperts = flowers;
            homeVM.Join = join;
            homeVM.Blogs = blogs;
            homeVM.sliderMain2s = sliderMain2s;
            homeVM.cATEGORies =cATEGORY1s;
            homeVM.pRODUCTS1s = pRODUCTS1s;

            return View(homeVM);
        }

        public IActionResult GetSession()
        {
           string session = HttpContext.Session.GetString("Software");
            return Content(session);
        }
    }
}
