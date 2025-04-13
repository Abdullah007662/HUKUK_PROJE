using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HUKUK_PROJE.Controllers
{
    public class BannerController : Controller
    {
        private readonly HukukContext _context;
        private readonly IWebHostEnvironment _env;

        public BannerController(HukukContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var values = _context.Banners.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Banners.Find(id);

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Banner banner, IFormFile? ImageFile)
        {
            var update = _context.Banners.Find(banner.BannerID);

            if (update == null)
                return NotFound();

            update.Title = banner.Title;
            update.Description = banner.Description;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "bannerimages", imageName);

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

                update.ImageUrl = "/bannerimages/" + imageName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
