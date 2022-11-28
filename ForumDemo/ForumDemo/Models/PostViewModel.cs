using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models;

public class PostViewModel
{
    [UIHint("hidden")] 
    public int Id { get; set; }
    
    [Display(Name = "Title")]
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} has to be between {2} and {3} words")]
    public string Title { get; set; }

    [Display(Name = "Content")]
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} has to be between {2} and {3} words")]
    public string Content { get; set; }
}