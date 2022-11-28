using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
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

    /// <summary>
    /// Add New Product 
    /// </summary>
    /// <param name="productDto">Product Model</param>
    /// <returns></returns>
    Task Add(ProductDto productDto);

    Task Delete(Guid id);

}