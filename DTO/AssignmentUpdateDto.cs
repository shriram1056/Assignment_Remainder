namespace AsnRemainderAPI.DTO
{
  public class AssignmentUpdateDto
  {

    public string? AsnName { get; set; }

    public bool IsComplete { get; set; }

    public DateTime DueDate { get; set; }

    public int CourseId { get; set; }

  }
}