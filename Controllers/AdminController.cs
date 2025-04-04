using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
