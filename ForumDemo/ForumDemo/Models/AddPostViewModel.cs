using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models;

public class AddPostViewModel
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} has to be between {1} and {2} words")]
    public string Title { get; set; }

    [Display(Name = "Content")]
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "The {0} has to be between {1} and {2} words")]
    public string Content { get; set; }
}