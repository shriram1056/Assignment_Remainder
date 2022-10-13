using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.DTO
{
  public class CourseReadDto
  {
    public long Id { get; set; }
    public string? CourseName { get; set; }
    public long AsnDueCount { get; set; }
    public List<AssignmentReadDto>? Assignments { get; set; }
  }
}
