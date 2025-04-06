using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class AboutController : Controller
    {
        private readonly HukukContext _context;

        public AboutController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.Abouts.Find(id);
            if (values == null)
            {
                return NotFound(); // Veya başka bir hata mesajı
            }
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(About about)
        {
            var update = _context.Abouts.FirstOrDefault(a => a.AboutID == about.AboutID);
            if (update == null)
            {
                return NotFound(); // Hata yönetimi
            }

            // Veritabanı güncelleniyor
            update.SignatureUrl = about.SignatureUrl;
            update.Description = about.Description;
            update.ImageUrl = about.ImageUrl;
            update.Title = about.Title;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
