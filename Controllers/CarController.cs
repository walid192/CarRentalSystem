using Microsoft.AspNetCore.Mvc;
using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using System.Diagnostics;

namespace Car_Rental_System.Controllers
{
    public class CarController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        public CarController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            List<Car> cars = Data.GetAllCars();
            return View(cars);
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car c) {
            if (c is null)
            {
                Debug.WriteLine("Null problem");
            }
            else {

                Models.CarRentalSystemContext db =  Models.CarRentalSystemContext.Instance;
                Data data = new Data(webHostEnvironment);
                Car newcar = new Car() {
                SeatingCapacity = c.SeatingCapacity,
                Model = c.Model,
                CarNumber = c.CarNumber,
                ImagePath = data.saveImage(c.CarImage),
                Brand = c.Brand,
                Engine = c.Engine,
                PassingYear=c.PassingYear,
                FuelType = c.FuelType ,
                };
                
                db.Cars.Add(newcar);
                db.SaveChanges();
                Debug.WriteLine("done");
            }
            

            return RedirectToAction("Index");
        }
    }
}
