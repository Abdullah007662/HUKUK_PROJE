using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HUKUK_PROJE.Controllers
{
    public class AboutController : Controller
    {
        private readonly HukukContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(HukukContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(About about)
        {
            _context.Abouts.Add(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.Abouts.Find(id);
            if (values == null)
            {
                return NotFound(); // Veya başka bir hata mesajı
            }
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Update(About about, IFormFile? ImageFile)
        {
            var update = _context.Abouts.Find(about.AboutID);

            if (update == null)
                return NotFound();

            update.Title = about.Title;
            update.Title = about.Title2;
            update.Description = about.Description;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "aboutimages", imageName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(stream);
                    stream.Position = 0;

                    using var image = Image.Load(stream);
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(1920, 1080) // Slider için ideal genişlik/yükseklik
                    }));

                    await image.SaveAsync(savePath);
                }

                // Eski resmi sil (isteğe bağlı)
                if (!string.IsNullOrEmpty(update.ImageUrl))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, update.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                update.ImageUrl = "/aboutimages/" + imageName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
