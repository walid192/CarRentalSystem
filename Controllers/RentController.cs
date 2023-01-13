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
            return View();
        } 
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Rent rent) {


            return View();
        }
    }
}
