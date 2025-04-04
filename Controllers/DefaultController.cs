﻿using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using MimeKit.Text;

namespace HUKUK_PROJE.Controllers
{
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
            // Hatalı satırı kaldırıyoruz ve _hukukContext kullanıyoruz.
            List<SelectListItem> Type = _hukukContext.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();
            ViewBag.v1 = Type;

            // ModelState validasyonunu kontrol et
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Lütfen tüm alanları doldurunuz!" });
            }

            // Veritabanına Kaydetme
            Contact newAppointment = new Contact
            {
                NameSurname = model.NameSurname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
                Message = model.Message,
                LawTypeID = model.LawTypeID // Seçilen kategori bilgisi
            };

            _hukukContext.Contacts.Add(newAppointment);
            _hukukContext.SaveChanges();

            // Kullanıcıya Mail Gönderme
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("Hukuk Randevu Sistemi", "kcdmirapo96@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress(model.NameSurname, model.Email));

                mimeMessage.Subject = "Randevu Onayı";

                // Seçilen kategori bilgisini almak için
                var selectedCategory = _hukukContext.LawTypes
                    .FirstOrDefault(x => x.LawTypesID == model.LawTypeID)?.Type;

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = $"Merhaba {model.NameSurname},\n\n" +
                               $"Randevu talebiniz alınmıştır.\n\n" +
                               $"Tarih: {model.AppointmentDate:dd/MM/yyyy}\n" +
                               $"Saat: {model.AppointmentTime}\n\n" +
                               $"Seçtiğiniz Kategori: {selectedCategory}\n\n" +
                               $"Detaylar için bizimle iletişime geçebilirsiniz."
                };

                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn"); // Şifreyi .env veya appsettings.json'dan al
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                return Ok();  // Başarı durumunda sadece 200 OK döndür
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Mail gönderilirken hata oluştu: {ex.Message}" });
            }
        }


        public IActionResult Index()
        {
            // Kategorileri view'e gönder
            ViewBag.v1 = _hukukContext.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();
            return View();
        }
    }
}
