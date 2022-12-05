using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebShopDemo.Core.Constants;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers;

/// <summary>
/// Web Shop Products
/// </summary>

[Authorize]
public class ProductController : BaseController
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
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var products = await productService.GetAll();
        ViewData["Title"] = "Products";
        
        return View(products);
    }
    
    [HttpGet]
    [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
    public IActionResult Add()
    {
        var model = new ProductDto();
        ViewData["Title"] = "Add New Product";
        
        return View(model);
    }

    [HttpPost]
    [Authorize(Roles = $"{RoleConstants.Manager}, {RoleConstants.Supervisor}")]
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

    [HttpPost]
    [Authorize(Policy = "CanDeleteProduct")]
    public async Task<IActionResult> Delete([FromForm]string id)
    {

        Guid guidId = Guid.Parse(id);

        await productService.Delete(guidId);
        
        return RedirectToAction(nameof(Index));
    }
}