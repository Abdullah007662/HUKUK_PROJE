using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HUKUK_PROJE.Controllers
{
    public class AreaController : Controller
    {
        private readonly HukukContext _context;

        public AreaController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AreaDetails(int id)
        {
            var value = await _context.Areas
                .Include(x => x.LawTypes)
                .FirstOrDefaultAsync(x => x.AreaID == id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }



    }
}
