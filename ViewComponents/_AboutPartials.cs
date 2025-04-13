using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _AboutPartials : ViewComponent
    {
        private readonly HukukContext _context;

        public _AboutPartials(HukukContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.ToList();
            return View(value);
        }
    }
}
