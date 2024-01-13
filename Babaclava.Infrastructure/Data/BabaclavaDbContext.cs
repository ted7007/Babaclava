using Babaclava.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Babaclava.Infrastructure.Data;

public class BabaclavaDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserResult> UserResults { get; set; }
    
    public BabaclavaDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        InitializeBabaclavaScheme(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void InitializeBabaclavaScheme(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany<UserResult>()
            .WithOne();

        builder.Entity<Book>()
            .HasMany<UserResult>()
            .WithOne();

        builder.Entity<UserResult>()
            .HasKey(ur => new { ur.BookId, ur.UserId });
    }
}