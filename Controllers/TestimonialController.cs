using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly HukukContext _context;

        public TestimonialController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(Testimonial testimonial)
        {
            var update = _context.Testimonials.Find(testimonial.TestimonialID);

            update!.NameSurname = testimonial.NameSurname;
            update.Description = testimonial.Description;
            update.ImageUrl = testimonial.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
