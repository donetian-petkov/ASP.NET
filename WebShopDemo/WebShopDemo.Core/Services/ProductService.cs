using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Data.Common;
using WebShopDemo.Core.Data.Models;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services;

/// <summary>
/// Manipulates Product Data
/// </summary>
public class ProductService : IProductService
{
    private readonly IConfiguration config;

    private readonly IRepository repo;

    /// <summary>
    /// Inversion of Control
    /// </summary>
    /// <param name="_config">Application Configuration</param>
    public ProductService(
        IConfiguration _config, 
        IRepository _repo)
    {
        config = _config;
        repo = _repo;
    }
        
    /// <summary>
    /// Gets All Products
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Product>> GetAll()
    {
        string dataPath = config.GetValue<string>("DataFiles:Products");

        string data = await File.ReadAllTextAsync(dataPath);

        return JsonConvert.DeserializeObject<IEnumerable<Product>>(data);
    }

    /// <summary>
    /// Add New Product 
    /// </summary>
    /// <param name="productDto">Product Model</param>
    /// <returns></returns>
    public async Task Add(Product productDto)
    {
        var product = new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Quantity = productDto.Quantity
        };
        
        await repo.AddAsync(product);
        await repo.SaveChangesAsync();

    }
} 