using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _AdminSideBarPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
