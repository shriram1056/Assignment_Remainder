using AsnRemainderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsnRemainderAPI.Data
{

  public class CourseRepo : ICourseRepo
  {
    private readonly AppDbContext _context;

    public CourseRepo(AppDbContext context)
    {
      _context = context;
    }
    public async Task CreateCourse(Course course)
    {
      if (course == null)
      {
        throw new ArgumentNullException(nameof(course));
      }
      await _context.Courses.AddAsync(course);
    }

    public void DeleteCourse(Course course)
    {
      if (course == null)
      {
        throw new ArgumentNullException(nameof(course));
      }

      _context.Courses.Remove(course);
    }

    public async Task<Course?> GetCourseById(int id)
    {
      return await _context.Courses.Include(course => course.Assignments).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Course>> GetAllCourses()
    {
      return await _context.Courses.Include(course => course.Assignments).ToListAsync();
    }

    public async Task SaveChanges()
    {
      await _context.SaveChangesAsync();
    }
  }
}
