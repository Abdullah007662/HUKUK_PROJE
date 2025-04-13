using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
