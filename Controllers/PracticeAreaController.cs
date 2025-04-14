﻿using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HUKUK_PROJE.Controllers
{
    public class PracticeAreaController : Controller
    {
        private readonly HukukContext _context;
        private readonly IWebHostEnvironment _env;

        public PracticeAreaController(HukukContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var values = _context.PracticeAreas.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PracticeArea practiceArea)
        {
            _context.PracticeAreas.Add(practiceArea);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var values = _context.PracticeAreas.Find(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PracticeArea practiceArea, IFormFile? ImageFile)
        {
            var update = _context.PracticeAreas.Find(practiceArea.PracticeAreaID);

            if (update == null)
                return NotFound();

            update.Title = practiceArea.Title;
            update.Description= practiceArea.Description;
            update.Icon= practiceArea.Icon;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "PracticaAreaİmages", imageName);

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

                // Eski görsel varsa sil (isteğe bağlı)
                if (!string.IsNullOrEmpty(update.ImageUrl))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, update.ImageUrl.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                update.ImageUrl = "/PracticaAreaİmages/" + imageName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _context.PracticeAreas.Find(id);
            _context.PracticeAreas.Remove(value!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
