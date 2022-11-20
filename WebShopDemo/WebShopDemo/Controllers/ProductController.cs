using Microsoft.AspNetCore.Mvc;

namespace WebShopDemo.Controllers;

/// <summary>
/// Web Shop Products
/// </summary>

public class ProductController : Controller
{
    // GET
    /// <summary>
    /// List All Products   
    /// </summary>
    /// <returns></returns>
    public IActionResult Index() => View();
}