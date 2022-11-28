using ForumDemo.Constants;
using ForumDemo.Data.Configure;
using ForumDemo.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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
        builder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(85));
        builder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(85));

        base.OnModelCreating(builder);
    }
    
    public DbSet<Post> Posts { get; set; }
}