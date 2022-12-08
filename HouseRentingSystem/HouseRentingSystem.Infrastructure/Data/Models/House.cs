using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class House
{
    
    [Key]
    public int Id { get; set; }

    // min - 10
    [Required]
    [StringLength(50)]
    public string Title { get; set; } = null!;
    
    // min - 30
    [Required]
    [StringLength(150)]
    public string Address { get; set; } = null!;
    
    // min - 50
    [Required]
    [StringLength(500)]
    public string Description { get; set; } = null!;
    
    [Required]
    [StringLength(200)]
    public string ImageUrl { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "money")]
    [Precision(18,2)]
    public decimal PricePerMonth { get; set; }
    
    [Required] 
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))] 
    public Category Category { get; set; } = null!;
    
    [Required] 
    public int AgentId { get; set; }
    
    [ForeignKey(nameof(AgentId))] 
    public Agent Agent { get; set; } = null!;

    public string RenterId { get; set; }

    [ForeignKey(nameof(RenterId))]
    public IdentityUser Renter { get; set; }
}