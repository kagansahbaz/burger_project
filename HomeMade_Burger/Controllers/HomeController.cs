using HomeMade_Burger.Models;
using HomeMade_Burger.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeMade_Burger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderDetailRepository orderDetailRepository;

        public HomeController(ILogger<HomeController> logger, IOrderDetailRepository orderDetailRepository)
        {
            _logger = logger;
            this.orderDetailRepository = orderDetailRepository;
        }

        public IActionResult Index()
        {
           
            return View();
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
    }
}