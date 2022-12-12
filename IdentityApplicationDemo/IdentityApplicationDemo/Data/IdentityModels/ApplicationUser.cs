using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IdentityApplicationDemo.Data.IdentityModels;

public class ApplicationUser : IdentityUser<Guid>
{
    [StringLength(50)]
    public string? FirstName { get; set; }
    
    [StringLength(50)]
    public string? LastName { get; set; }
}