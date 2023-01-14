using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Car_Rental_System.Controllers
{
    public class RentController : Controller
    {
        public IActionResult Index()
        {
            List<Rent> rents= Data.GetAllRents();
            return View(rents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<string> brands = Data.GetBrand();
            List<string> models = Data.GetModels();
            List<string> drivers=Data.GetDrivers();
            ViewBag.Brands = brands;
            ViewBag.Models = models;
            ViewBag.Drivers = drivers;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Rent rent) {

            Data.addRent(rent);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult GetBrand()
        {
            List<string> list = Data.GetBrand();
            return Json (list);
        }
    }




}
