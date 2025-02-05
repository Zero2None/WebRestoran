using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Models;

namespace WebRestoran.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IRepo<Food> _foodRepo;

        //public HomeController(ILogger<HomeController> logger, IRepo<Food> foodRepo) 
        //{
        //    _logger = logger;
        //    _foodRepo = foodRepo;
        //}
        public HomeController(IRepo<Food> foodRepo)
        {
            _foodRepo = foodRepo;
        }
        public async Task<IActionResult> Index()
        {
            var foodItems = await _foodRepo.GetAllAsync();
            return View("Index", foodItems);
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

        public IActionResult Landing()
        {
            var foodItems = _foodRepo.GetAllAsync().Result; 
            return View(foodItems);
        }
    }
}
