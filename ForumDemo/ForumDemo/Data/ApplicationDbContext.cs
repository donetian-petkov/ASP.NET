using ForumDemo.Constants;
using ForumDemo.Data.Configure;
using ForumDemo.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumDemo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration<Post>(new PostConfiguration());
        base.OnModelCreating(builder);
    }
    
    public DbSet<Post> Posts { get; set; }
}