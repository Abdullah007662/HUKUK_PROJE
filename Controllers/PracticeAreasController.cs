using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    [AllowAnonymous]
    public class PracticeAreasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
