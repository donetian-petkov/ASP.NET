using ForumDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumDemo.Data.Configure;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        List<Post> posts = GetPosts();

        builder.HasData(posts);
    }

    private List<Post> GetPosts()
    {
        return new List<Post>()
        {
            new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "This is my first post! How exciting!"
            },
            new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "Not really that exciting anymore!"
            },
            new Post()
            {
                Id = 3,
                Title = "My third post",
                Content = "Let's see how this goes!"
            }
        };
    }
}