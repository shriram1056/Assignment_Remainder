using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Data
{
  public interface ICourseRepo
  {
    Task SaveChanges();
    Task<Course?> GetCourseById(int id);
    Task<List<Course>> GetCourseCommands();
    Task CreateCourse(Course asn);
    void DeleteCourse(Course asn);
  }
}