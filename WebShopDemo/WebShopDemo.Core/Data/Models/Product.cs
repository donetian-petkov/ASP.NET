using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebShopDemo.Core.Data.Models;

[Comment("Product to sell")]
public class Product
{
    [Key]
    [Comment("Primary Key")]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Comment("Product Name")]
    public string Name { get; set; }
    
    [Required]
    [Comment("Product Price")]
    public decimal Price { get; set; }
    
    [Required]
    [Comment("Product In Stock")]
    public int Quantity { get; set; }
}