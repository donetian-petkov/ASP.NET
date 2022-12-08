using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class Agent
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; }
    
    
}