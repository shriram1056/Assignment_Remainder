using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Data
{

  public class CourseRepo : ICourseRepo
  {
    private readonly AppDbContext _context;

    public CourseRepo(AppDbContext context)
    {
      _context = context;
    }
    public Task CreateCourse(Course asn)
    {
      throw new NotImplementedException();
    }

    public void DeleteCourse(Course asn)
    {
      throw new NotImplementedException();
    }

    public Task<Course?> GetCourseById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Course>> GetCourseCommands()
    {
      throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
      throw new NotImplementedException();
    }
  }
}
