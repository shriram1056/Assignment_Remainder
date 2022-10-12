using Microsoft.EntityFrameworkCore;
using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Data
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