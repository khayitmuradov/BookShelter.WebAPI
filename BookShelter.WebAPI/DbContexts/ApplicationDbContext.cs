using BookShelter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelter.WebAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasIndex(x => x.Title).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.PhoneNumber).IsUnique();
    }
}
