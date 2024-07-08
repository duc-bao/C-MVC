using BanSachMVC.Data;
using BanSachMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanSachMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {

        _db = db; }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        // post
        [HttpPost]
        // CHống giả mạo method post
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name ", "The name must not same displayOrder");
            }
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }
        public IActionResult Edit(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryfromDbFrist = _db.Categories.FirstOrDefault(c => c.Id == id);
            // var categoryfromDBSignle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null) {
                return NotFound();
            }


            return View(categoryFromDb);
        }
        // post
        [HttpPost]
        // CHống giả mạo method post
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name ", "The name must not same displayOrder");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }
        public IActionResult Delelte(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryfromDbFrist = _db.Categories.FirstOrDefault(c => c.Id == id);
            // var categoryfromDBSignle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }
        // post
        [HttpPost]
        // CHống giả mạo method post
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int ? id)
        {
            var categoryDb = _db.Categories.Find(id);
           if(categoryDb == null)
            {
                return NotFound();
            }else
            {
                _db.Categories.Remove(categoryDb);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
           
            return View(categoryDb);
        }
    }
}
