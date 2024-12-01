using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P_Cars_Project.Data;
using P_Cars_Project.Data.Models;

namespace P_Cars_Project.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext db;

        public CarController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = db.Categories
          .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
          .ToList();

            ViewBag.Users = db.Users
                .Select(u => new SelectListItem { Value = u.Id, Text = u.UserName })
                .ToList();

            return View(new Car());
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {

            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("All");
            }

            return View(car);
        }


        [HttpGet]
        public IActionResult All()
        {
            var cars = this.db.Cars.Include(x => x.Category).Include(u => u.IdentityUser).ToList();


            return View(cars);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cat = this.db.Cars.Where(x => x.Id == id).FirstOrDefault();

            this.db.Cars.Remove(cat);
            this.db.SaveChanges();
            return RedirectToAction("all");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = this.db.Cars.Where(x => x.Id == id).FirstOrDefault();

            if(car == null){
                throw new Exception("nema kola");
            }

            ViewBag.Categories = db.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            ViewBag.Users = db.Users
                .Select(u => new SelectListItem { Value = u.Id, Text = u.UserName })
                .ToList();


            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if(ModelState.IsValid == false){
                // do it again
                ViewBag.Categories = db.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();

                ViewBag.Users = db.Users
                    .Select(u => new SelectListItem { Value = u.Id, Text = u.UserName })
                    .ToList();

                    return View(car);
            }

            var existingCar = db.Cars.FirstOrDefault(x=>x.Id == car.Id);


            if(existingCar == null) {
                throw new Exception("nema kola");
            }

            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.IsBooked = car.IsBooked;
            existingCar.CategoryId = car.CategoryId;
            existingCar.IdentityUserId = car.IdentityUserId;
            existingCar.CarPhoto = car.CarPhoto;

            db.SaveChanges();

            return RedirectToAction("all");
        }
    }
}
