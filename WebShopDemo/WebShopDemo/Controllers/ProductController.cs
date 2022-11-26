using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

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
    
    [HttpGet]
    public IActionResult Add()
    {
        var model = new ProductDto();
        ViewData["Title"] = "Add New Product";
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductDto model)
    {
        ViewData["Title"] = "Add New Product";

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await productService.Add(model);

        return RedirectToAction(nameof(Index));

    }
}