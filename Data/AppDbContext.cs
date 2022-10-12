using Microsoft.EntityFrameworkCore;
using AsnRemaninderAPI.Models;

namespace AsnRemaninderAPI.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
  }
}