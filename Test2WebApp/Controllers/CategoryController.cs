using Microsoft.AspNetCore.Mvc;
using Test2.DataAccess.Data;
using Test2.Models;

namespace Test2WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { 
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(cat);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category Create is not done";
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? catFromDb = _db.Categories.Find(id);
            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(cat);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category Update is not done";
            return View();

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("Index");
            }
            Category? catFromDb = _db.Categories.Find(id);
            if (catFromDb == null)
            {
                return NotFound();
            }
            return View(catFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? cat= _db.Categories.Find(id);
            if (cat == null)
            {
                TempData["error"] = "Category Delete is not done";
                return Index();
            }
            _db.Categories.Remove(cat);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully!";
            return RedirectToAction("Index");

        }
    }
}
