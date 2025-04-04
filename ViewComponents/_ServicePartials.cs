using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _ServicePartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
