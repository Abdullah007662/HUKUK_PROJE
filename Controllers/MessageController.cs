using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HUKUK_PROJE.Controllers
{
    public class MessageController : Controller
    {
        private readonly HukukContext _hukukContext;

        public MessageController(HukukContext hukukContext)
        {
            _hukukContext = hukukContext;
        }

        public IActionResult Index()
        {
            var values = _hukukContext.Contacts
                .Include(x => x.LawTypes)
                .ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _hukukContext.Contacts.Find(id);
            _hukukContext.Contacts.Remove(value!);
            _hukukContext.SaveChanges();
            return Ok();
        }
    }
}
