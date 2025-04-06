using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<SelectListItem> Type = _hukukContext.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();
            ViewBag.v1 = Type;

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Lütfen tüm alanları doldurunuz!" });
            }

            // Aynı gün ve saat için başka randevu var mı kontrolü
            bool isSlotTaken = _hukukContext.Contacts.Any(x =>
                x.AppointmentDate == model.AppointmentDate &&
                x.AppointmentTime == model.AppointmentTime
            );

            if (isSlotTaken)
            {
                return Conflict(new { message = "Bu tarih ve saat için zaten bir randevu alınmış. Lütfen başka bir zaman seçiniz." });
            }

            Contact newAppointment = new Contact
            {
                NameSurname = model.NameSurname,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime,
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
                    client.Authenticate("kcdmirapo96@gmail.com", "oauifwpqhjjgrzgn");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }

                return Ok();
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
            return View();
        }
        [HttpGet]
        public IActionResult GetUnavailableTimes(DateTime date)
        {
            var unavailableTimes = _hukukContext.Contacts
                .Where(c => c.AppointmentDate == date)
                .Select(c => c.AppointmentTime.ToString(@"hh\:mm")) // Saatleri HH:mm formatında al
                .ToList();

            return Json(unavailableTimes);
        }

    }
}
