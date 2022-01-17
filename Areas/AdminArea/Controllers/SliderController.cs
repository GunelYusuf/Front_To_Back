using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FronToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SliderController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>Create(Slider slider)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                ModelState.AddModelError("Photo", "Don't empty");
            }
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "just image");
                return View();
            }
            if (slider.Photo.Length / 1024 > 100)
            {
                ModelState.AddModelError("Photo", "Size cannot be more than 100");
                return View();
            }

            string fileName = Guid.NewGuid() + slider.Photo.FileName;
            bool isImage = slider.Photo.ContentType.Contains("image/");
            string path = _env.WebRootPath;


            return Content(path);
        }
    }
}
