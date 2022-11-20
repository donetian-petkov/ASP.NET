using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.Models;

/// <summary>
/// Product Model
/// </summary>
public class ProductDto
{
    /// <summary>
    /// Product Identifier
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Product Name
    /// </summary>
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    /// <summary>
    /// Product Price
    /// </summary>
    [Range(typeof(decimal), "0.1", "79228162514264337593543950335M", ConvertValueInInvariantCulture = true)]
    public decimal Price { get; set; }
    
    /// <summary>
    /// Quantity in stock
    /// </summary>
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}