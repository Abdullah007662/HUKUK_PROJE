using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _BannerPartials : ViewComponent
    {
        private readonly HukukContext _context;

        public _BannerPartials(HukukContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
    }
}
