using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HUKUK_PROJE.Entities;
using HUKUK_PROJE.Models;
using Microsoft.AspNetCore.Authorization;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                Random rnd = new Random();
                int code = rnd.Next(100000, 1000000);
                user.ConfirmCode = code;
                await _userManager.UpdateAsync(user);

                // Mail gönderimi
                MimeMessage mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Hukuk Panel", "kcdmirapo96@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("User", user.Email));
                mimeMessage.Subject = "Giriş Kodunuz";
                mimeMessage.Body = new TextPart("plain") { Text = "Doğrulama Kodunuz: " + code };

                using (var client = new SmtpClient())
                {
                    // Gmail SMTP ayarları
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn"); // Şifreyi .env veya appsettings.json'dan al
                    await client.SendAsync(mimeMessage);
                    client.Disconnect(true);
                }

                TempData["Mail"] = user.Email;
                return RedirectToAction("VerifyCode");
            }
        }

        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
        return View();
    }

    [HttpGet]
    public IActionResult VerifyCode()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && user.ConfirmCode == model.Code)
        {
            // Gerçek giriş işlemi burada yapılabilir.
            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("Result", "Home"); // Admin panelin controller'ı ve action'ı
        }

        ModelState.AddModelError("", "Kod hatalı.");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login"); // Giriş sayfasına yönlendirme
    }
}
