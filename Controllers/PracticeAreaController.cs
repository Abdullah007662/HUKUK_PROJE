using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class PracticeAreaController : Controller
    {
        private readonly HukukContext _context;

        public PracticeAreaController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.PracticeAreas.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PracticeArea practiceArea)
        {
            _context.PracticeAreas.Add(practiceArea);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.PracticeAreas.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Update(PracticeArea practiceArea)
        {
            var update = _context.PracticeAreas.Find(practiceArea.PracticeAreaID);

            update!.Title = practiceArea.Title;
            update.Description = practiceArea.Description;
            update.Icon = practiceArea.Icon;
            update.ImageUrl = practiceArea.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _context.PracticeAreas.Find(id);
            _context.PracticeAreas.Remove(value!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
