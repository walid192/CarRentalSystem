using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Car_Rental_System.Controllers
{
    public class DriverController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        public DriverController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Driver> drivers = Data.GetAllDrivers();
           
            return View(drivers);
        }

        public IActionResult Add()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Add(Driver driver) {

            if (driver is null)
            {
                Debug.WriteLine("Null problem");
            }
            else
            {

                Models.CarRentalSystemContext db =  Models.CarRentalSystemContext.Instance;
                Data data = new Data(webHostEnvironment);
                Driver newdriver = new Driver()
                {
                    DriverName=driver.DriverName,
                    Age=driver.Age,
                    Address=driver.Address,
                    Experience=driver.Experience,
                    MobileNumber=driver.MobileNumber,
                    ImagePath = data.SaveDriverImage(driver.DriverImage),
                    
                };

                db.Drivers.Add(newdriver);
                db.SaveChanges();
                Debug.WriteLine("done");
            }


            return RedirectToAction("Index");
        }
    }
}
