using Microsoft.AspNetCore.Mvc;

namespace PCAccessoriesShop.Controllers
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
            return View();
        }

        [Route("Home/Error")]
        public IActionResult Error()
        {
            ViewBag.StatusCode = 500;
            return View("Error");
        }

        [Route("Home/Error/{statusCode}")]
        public IActionResult ErrorStatus(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            return View("Error");
        }
    }
}
