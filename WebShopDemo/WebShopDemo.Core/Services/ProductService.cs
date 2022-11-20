using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Core.Services;

/// <summary>
/// Manipulates Product Data
/// </summary>
public class ProductService : IProductService
{
    private readonly IConfiguration config;

    /// <summary>
    /// Inversion of Control
    /// </summary>
    /// <param name="_config">Application Configuration</param>
    public ProductService(IConfiguration _config)
    {
        config = _config;
    }
        
    /// <summary>
    /// Gets All Products
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        string dataPath = config.GetValue<string>("DataFiles.Products");

        string data = await File.ReadAllTextAsync(dataPath);

        return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(data);
    }
} 