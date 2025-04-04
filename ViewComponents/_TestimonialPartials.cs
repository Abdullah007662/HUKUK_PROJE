using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _TestimonialPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
