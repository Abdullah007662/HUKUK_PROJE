﻿using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var values = _context.PracticeAreas.Include(x => x.LawTypes).ToList();
            return View(values);
        }
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
        public async Task<IActionResult> Create(PracticeArea practiceArea, IFormFile? ImageFile)
        {
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
                        Size = new Size(350, 650)
                    }));

                    await image.SaveAsync(savePath);
                }

                practiceArea.ImageUrl = "/PracticaAreaİmages/" + imageName;
            }

            _context.PracticeAreas.Add(practiceArea);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var values = _context.PracticeAreas.Find(id);
            ViewBag.v1 = _context.LawTypes
                .Select(x => new SelectListItem
                {
                    Text = x.Type,
                    Value = x.LawTypesID.ToString()
                }).ToList();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PracticeArea practiceArea, IFormFile? ImageFile)
        {
            var update = _context.PracticeAreas.Find(practiceArea.PracticeAreaID);
            if (update == null) return NotFound();

            update.Description = practiceArea.Description;
            update.Icon = practiceArea.Icon;
            update.LawTypesID = practiceArea.LawTypesID;

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
                        Size = new Size(350, 650)
                    }));

                    await image.SaveAsync(savePath);
                }

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
        public IActionResult Delete(int id)
        {
            var value = _context.PracticeAreas.Find(id);
            _context.PracticeAreas.Remove(value!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
