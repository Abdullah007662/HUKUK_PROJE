using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;

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
            var values = _context.PracticeAreas.ToList();
            return View(values);
        }
    }
}
