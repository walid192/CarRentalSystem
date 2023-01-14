using Car_Rental_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Car_Rental_System.Repositories;

namespace Car_Rental_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Car> cars = Data.GetAllCars();
            return View(cars );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact() { return View(); }
    }
}