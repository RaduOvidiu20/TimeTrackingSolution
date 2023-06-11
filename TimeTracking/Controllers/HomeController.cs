using Microsoft.AspNetCore.Mvc;



namespace TimeTracking.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
[Route("[action]")]
[Route("/")]
        public IActionResult Index()
        {
            return View();
        }
[Route("[action]")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}