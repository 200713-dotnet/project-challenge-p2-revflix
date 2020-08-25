using Microsoft.EntityFrameworkCore;
using RevFlix.Service.Models;

namespace RevFlix.Service
{
  public class RevFlixDbContext : DbContext
  {
    public DbSet<UserProfile> UserProfile { get; set; }
    public DbSet<UserMovie> UserMovie { get; set; }
    public DbSet<UserGenre> UserGenre { get; set; }
    public DbSet<Genre> Genre { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public RevFlixDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<UserProfile>().HasKey(e => e.Id);
      builder.Entity<UserMovie>().HasKey(e => e.Id);
      builder.Entity<UserGenre>().HasKey(e => e.Id);
      builder.Entity<Genre>().HasKey(e => e.Id);
      builder.Entity<Movie>().HasKey(e => e.Id);

    }
  }
}
