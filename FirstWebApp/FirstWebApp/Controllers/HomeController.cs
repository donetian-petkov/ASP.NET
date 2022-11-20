using System.Diagnostics;
using FirstWebApp.Contracts;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITestService testService;

    public HomeController(
        ILogger<HomeController> logger,
        ITestService _testService)
    {
        _logger = logger;
        testService = _testService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Test()
    {

        var model = new TestModel();
        
        return View(model);
    }

    [HttpPost]
    public IActionResult Test(TestModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string product = testService.GetProduct(model);
        
        return RedirectToAction(nameof(Index));
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