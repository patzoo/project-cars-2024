using Microsoft.AspNetCore.Mvc;
using P_Cars_Project.Data;
using P_Cars_Project.Data.Models;
using P_Cars_Project.Models;
using System.Diagnostics;

namespace P_Cars_Project.Controllers
{
    public class CategoryController : Controller
    {
        // dependency injection
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            Category cat = new Category();

            return View(cat);
        }

        [HttpPost]
        public IActionResult Add(Category cat)
        {

             if (ModelState.IsValid)
            {
                db.Categories.Add(cat);
                db.SaveChanges();
                return RedirectToAction("All");
            }

            return View(cat);
        }

            
        [HttpGet]
        public IActionResult All()
        {
          var categories = this.db.Categories.ToList();


            return View(categories);
        }

         [HttpGet]
        public IActionResult Delete(int id)
        {
          var cat = this.db.Categories.Where(x=>x.Id == id).FirstOrDefault();

            this.db.Categories.Remove(cat);
            this.db.SaveChanges();
                return RedirectToAction("All");
        }

        
    }
}
