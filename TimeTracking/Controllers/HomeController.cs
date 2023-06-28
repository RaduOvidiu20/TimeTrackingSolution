using Microsoft.AspNetCore.Mvc;

namespace TimeTracking.Web.Controllers;

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
        _logger.LogInformation("Index action method of  HomeController");
        return View();
    }

    [Route("[action]")]
    public IActionResult Contact()
    {
        _logger.LogInformation("Contact action method of  HomeController");
        return View();
    }
}