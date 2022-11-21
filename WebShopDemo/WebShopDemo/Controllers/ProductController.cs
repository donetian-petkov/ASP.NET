using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;

namespace WebShopDemo.Controllers;

/// <summary>
/// Web Shop Products
/// </summary>

public class ProductController : Controller
{

    private readonly IProductService productService;

    public ProductController(IProductService _productService)
    {
        productService = _productService;
    }
    
    // GET
    /// <summary>
    /// List All Products   
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAll();
        ViewData["Title"] = "Products";
        
        return View(products);
    }
}