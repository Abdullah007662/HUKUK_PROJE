using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class BannerController : Controller
    {
        private readonly HukukContext _context;

        public BannerController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _context.Banners.Find(id);
            _context.Banners.Remove(value!);
            _context.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Banners.Find(id);

            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Banner banner)
        {
            var update = _context.Banners.Find(banner.BannerID);

            update!.Title = banner.Title;
            update!.Description = banner.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
