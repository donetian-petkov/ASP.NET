using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Contracts;

/// <summary>
/// Manipulates Product Data
/// </summary>

public interface IProductService
{
    /// <summary>
    /// Gets All Products 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductDto>> GetAll();
}