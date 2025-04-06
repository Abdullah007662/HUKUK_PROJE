using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class LawTypesController : Controller
    {
        private readonly HukukContext _context;

        public LawTypesController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.LawTypes.ToList();
            return View(values);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // CSRF korumasını etkinleştiriyoruz
        public IActionResult Delete(int id)
        {
            var values = _context.LawTypes.Find(id);
            if (values == null)
                return NotFound();

            _context.LawTypes.Remove(values);
            _context.SaveChanges();
            return Ok(); // SweetAlert'te response.ok için
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // CSRF korumasını etkinleştiriyoruz
        public IActionResult Create(LawTypes lawTypes)
        {
            _context.LawTypes.Add(lawTypes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.LawTypes.Find(id);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // CSRF korumasını etkinleştiriyoruz
        public IActionResult Update(LawTypes lawTypes)
        {
            var update = _context.LawTypes.Find(lawTypes.LawTypesID);
            if (update == null)
                return NotFound();

            update.Type = lawTypes.Type;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
