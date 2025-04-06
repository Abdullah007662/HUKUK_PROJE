using HUKUK_PROJE.Context;
using HUKUK_PROJE.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HUKUK_PROJE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HukukContext _context;

        public EmployeeController(HukukContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateEmploye()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmploye(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = _context.Employees.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            var update = _context.Employees.Find(employee.EmployeeID!);
            update!.NameSurname = employee.NameSurname;
            update.Department = employee.Department;
            update.FacebookUrl = employee.FacebookUrl;
            update.InstagramUrl = employee.InstagramUrl;
            update.TwitterUrl = employee.TwitterUrl;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var value = _context.Employees.Find(id);
            _context.Employees.Remove(value!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
