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
            return View();
        }
    }
}
