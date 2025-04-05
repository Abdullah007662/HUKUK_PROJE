using HUKUK_PROJE.Entities;
using HUKUK_PROJE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HUKUK_PROJE.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerDTO.KullanıcıAdı,
                    Email = registerDTO.Email,
                    Name = registerDTO.KullanıcıAdı
                };

                var result = await _userManager.CreateAsync(user, registerDTO.Şifre!);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }

                // Hataları ekrana gönder
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerDTO);
        }
    }
}
