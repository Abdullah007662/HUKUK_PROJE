using HUKUK_PROJE.Entities;
using HUKUK_PROJE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SettingsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new UpdateUserViewModel
            {
                UserName = user?.UserName,
                NameSurname = user?.Name,
                Email = user?.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return View(model);
            }

            // Şifre güncelleme
            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.CurrentPassword!);
                if (!passwordCheck)
                {
                    TempData["Error"] = "Mevcut şifreniz hatalı.";
                    return View(model);
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    TempData["Error"] = "Yeni şifreler uyuşmuyor.";
                    return View(model);
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword!, model.NewPassword!);
                if (!result.Succeeded)
                {
                    TempData["Error"] = "Şifre değiştirme sırasında hata oluştu.";
                    return View(model);
                }
            }

            // Diğer bilgiler
            if (user.Email != model.Email)
                user.Email = model.Email!;
            if (user.Name != model.NameSurname)
                user.Name = model.NameSurname!;
            if (user.UserName != model.UserName)
                user.UserName = model.UserName!;

            await _userManager.UpdateAsync(user);

            TempData["Success"] = "Bilgiler başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
