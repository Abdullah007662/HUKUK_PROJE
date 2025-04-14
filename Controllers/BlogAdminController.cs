using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace HUKUK_PROJE.Controllers
{
    public class BlogAdminController : Controller
    {
        private readonly HukukContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogAdminController(HukukContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var values = _context.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "Blogimages", imageName);

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

                blog.ImageUrl = "/Blogimages/" + imageName;
            }

            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Blogs.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Blog blog, IFormFile? ImageFile)
        {
            var update = _context.Blogs.Find(blog.BlogID);

            if (update == null)
                return NotFound();
            update.Title = blog.Title;
            update.Description = blog.Description;
            update.SmallTitle = blog.SmallTitle;


            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var savePath = Path.Combine(_env.WebRootPath, "Blogimages", imageName);

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

                update.ImageUrl = "/Blogimages/" + imageName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var values = _context.Blogs.Find(id);
            _context.Blogs.Remove(values!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
