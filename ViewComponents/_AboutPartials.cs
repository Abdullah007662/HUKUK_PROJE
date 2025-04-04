using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _AboutPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
