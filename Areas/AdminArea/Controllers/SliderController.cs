using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FronToBack.Extensions;
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
            if (!slider.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "just image");
                return View();
            }
            if (slider.Photo.IsCorrectSize(300))
            {
                ModelState.AddModelError("Photo", "Enter the size correctly");
                return View();
            }


            string root = _env.WebRootPath;
            
            Slider newSlider = new Slider();
            newSlider.ImageUrl = await slider.Photo.SaveImageAsync(_env.WebRootPath, "Main-Images");

            await _context.Sliders.AddAsync(newSlider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Slider dbslider =await _context.Sliders.FindAsync(id);
            if (dbslider == null) return NotFound();

            return View(dbslider);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteSlider(int? id)
        {
            if (id == null) return NotFound();
            Slider dbslider = await _context.Sliders.FindAsync(id);
            if (dbslider == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath,"Main-Images",dbslider.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            _context.Sliders.Remove(dbslider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
