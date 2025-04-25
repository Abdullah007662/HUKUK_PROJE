using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;

namespace HUKUK_PROJE.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly HukukContext _hukukContext;

        public DefaultController(HukukContext hukukContext)
        {
            _hukukContext = hukukContext;
        }

        [HttpPost]
        public IActionResult Create([FromForm] Contact model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Lütfen tüm alanları doldurunuz!" });
            }

            Contact newAppointment = new Contact
            {
                NameSurname = model.NameSurname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Message = model.Message,
                LawTypes = _hukukContext.LawTypes.FirstOrDefault(x => x.LawTypesID == model.LawTypes!.LawTypesID)
            };

            _hukukContext.Contacts.Add(newAppointment);
            _hukukContext.SaveChanges();

            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Hukuk Randevu Sistemi", "kcdmirapo96@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress(model.NameSurname, model.Email));
                mimeMessage.Subject = "Randevu Onayı";

                var selectedCategory = _hukukContext.LawTypes
                    .FirstOrDefault(x => x.LawTypesID == model.LawTypes!.LawTypesID)?.Type;

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = $"Merhaba {model.NameSurname},\n\n" +
                               $"Randevu talebiniz oluşturulmuştur.\n\n" +
                               $"Seçtiğiniz Kategori: {selectedCategory}\n\n" +
                               $"Detaylar için bizimle iletişime geçebilirsiniz."
                };

                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                // ✅ Redirect URL'yi dön
                return Ok(new { redirectUrl = Url.Action("Index", "Default") });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Mail gönderilirken hata oluştu: {ex.Message}" });
            }
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _hukukContext.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();
            var banner1 = _hukukContext.Banners.FirstOrDefault(x => x.BannerID == 1);
            var banner2 = _hukukContext.Banners.FirstOrDefault(x => x.BannerID == 2);

            ViewBag.Banner1Image = banner1?.ImageUrl ?? "img/banner/default1.jpg";
            ViewBag.Banner2Image = banner2?.ImageUrl ?? "img/banner/default2.jpg";

            return View();
        }

    }
}
