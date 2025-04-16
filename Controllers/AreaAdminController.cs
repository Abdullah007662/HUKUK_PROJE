using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HUKUK_PROJE.Controllers
{
    public class AreaAdminController : Controller
    {
        private readonly HukukContext _context;
        private readonly IWebHostEnvironment _env;

        public AreaAdminController(HukukContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var values = _context.Areas.Include(x => x.LawTypes).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.v1 = _context.LawTypes
               .Select(x => new SelectListItem
               {
                   Text = x.Type,
                   Value = x.LawTypesID.ToString()
               }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Area area, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "AreaImages", imageName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(stream);
                    stream.Position = 0;

                    using var image = Image.Load(stream);
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(800, 600)
                    }));

                    await image.SaveAsync(savePath);
                }

                area.ImageUrl = "/AreaImages/" + imageName;
            }

            _context.Areas.Add(area);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.v1 = _context.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();

            var value = _context.Areas.Find(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Area area, IFormFile? ImageFile)
        {
            var update = _context.Areas.Find(area.AreaID);
            if (update == null) return NotFound();

            update.Description = area.Description;
            update.LawTypesID = area.LawTypesID;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "AreaImages", imageName);

                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);

                using (var stream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(stream);
                    stream.Position = 0;

                    using var image = Image.Load(stream);
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Mode = ResizeMode.Max,
                        Size = new Size(350, 650)
                    }));

                    await image.SaveAsync(savePath);
                }

                // Eski görseli sil
                if (!string.IsNullOrEmpty(update.ImageUrl))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, update.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                update.ImageUrl = "/AreaImages/" + imageName;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.v1 = _context.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();

            var value = _context.Areas.Find(id);
            return View(value);
        }

    }
}
