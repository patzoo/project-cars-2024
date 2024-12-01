using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P_Cars_Project.Data;
using P_Cars_Project.Data.Models;

namespace P_Cars_Project.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }

        
        [HttpGet]
        public IActionResult Rent(int carId, string userId)
        {
            
            if(carId ==0 ||  userId == null){
                throw new Exception("nema kola");
            }

            var car = this.db.Cars.FirstOrDefault(x=>x.Id == carId);

            car.IsBooked= true;

            var booking = new Booking();

            booking.CarId = carId;
            booking.IdentityUserId = userId;

            this.db.Bookings.Add(booking);

            this.db.SaveChanges();
            return RedirectToAction("all", "car");
        }
    }
}
