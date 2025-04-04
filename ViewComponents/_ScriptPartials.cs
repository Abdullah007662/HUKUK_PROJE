using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.ViewComponents
{
    public class _ScriptPartials:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
