using System.ComponentModel.DataAnnotations.Schema;

namespace WebShopDemo.Core.Data.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public int UserCreatedId { get; set; }
    
    public int UserUpdatedId { get; set; }
    
    [ForeignKey(nameof(UserCreatedId))] 
    public User UserCreated { get; set; }
    
    [ForeignKey(nameof(UserUpdatedId))] 
    public User UserUpdated { get; set; }

}