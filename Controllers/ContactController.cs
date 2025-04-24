using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace HUKUK_PROJE.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly HukukContext _context;

        public ContactController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _context.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();

            var banner1 = _context.Banners.FirstOrDefault(x => x.BannerID == 1);
            var banner2 = _context.Banners.FirstOrDefault(x => x.BannerID == 2);

            ViewBag.Banner1Image = banner1?.ImageUrl ?? "img/banner/default1.jpg";
            ViewBag.Banner2Image = banner2?.ImageUrl ?? "img/banner/default2.jpg";

            return View();
        }
    }
}
