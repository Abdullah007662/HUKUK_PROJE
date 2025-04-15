using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HUKUK_PROJE.ViewComponents
{
    public class _ServicePartials : ViewComponent
    {
        private readonly HukukContext _context;

        public _ServicePartials(HukukContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.PracticeAreas.Include(x => x.LawTypes).ToList();
            return View(values);
        }
    }
}
