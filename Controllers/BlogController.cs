using HUKUK_PROJE.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly HukukContext _context;

        public BlogController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 3;
            var totalBlogs = _context.Blogs.Count();
            var blogs = _context.Blogs
                                .OrderByDescending(b => b.BlogID)
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalBlogs / pageSize);

            return View(blogs);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var value = _context.Blogs.Find(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult AreaDetails(int id)
        {
            return View();
        }
    }
}
