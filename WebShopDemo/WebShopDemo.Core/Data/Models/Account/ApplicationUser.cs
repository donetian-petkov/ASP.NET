using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebShopDemo.Core.Data.Models.Account;

public class ApplicationUser : IdentityUser
{
    [StringLength(20)]
    public string? FirstName { get; set; }
    
    [StringLength(20)]
    public string? LastName { get; set; }


}