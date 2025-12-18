using Microsoft.AspNetCore.Mvc;
using SampleWebApplication.Data;
using SampleWebApplication.Models;

namespace SampleWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category != null)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category != null)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
