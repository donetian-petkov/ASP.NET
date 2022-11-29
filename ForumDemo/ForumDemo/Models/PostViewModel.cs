using System.ComponentModel.DataAnnotations;

namespace ForumDemo.Models;

public class PostViewModel : AddPostViewModel
{
    public int Id { get; set; }
}