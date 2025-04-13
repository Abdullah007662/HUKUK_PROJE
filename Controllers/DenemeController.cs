using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
