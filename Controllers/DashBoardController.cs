using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly HukukContext _context;

        public DashBoardController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contactCount = _context.Contacts.Count();
            ViewBag.ContactCount = contactCount;

            var Lawtype = _context.LawTypes.Count();
            ViewBag.type = Lawtype;

            var serviceCount = _context.PracticeAreas.Count();
            ViewBag.service = serviceCount;

            var blogcount = _context.Blogs.Count();
            ViewBag.blogcount = blogcount;


            var last5Contacts = _context.Contacts
                .OrderByDescending(x => x.ContactID) 
                .Take(5)
                .ToList();

            return View(last5Contacts); 
        }
    }
}
