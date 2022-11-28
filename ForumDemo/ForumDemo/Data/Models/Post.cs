using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static ForumDemo.Constants.DataConstants.Post;

namespace ForumDemo.Data.Models;

[Comment("Published Posts")]
public class Post
{
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Comment("Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Content")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
}