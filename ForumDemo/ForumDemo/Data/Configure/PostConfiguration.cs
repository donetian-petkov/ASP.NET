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
        throw new NotImplementedException();
    }
}