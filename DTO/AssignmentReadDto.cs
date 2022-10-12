namespace AsnRemaninderAPI.DTO
{
  public class AssignmentReadDto
  {

    public long Id { get; set; }

    public string? AsnName { get; set; }

    public bool IsComplete { get; set; }

    public DateTime DueDate { get; set; }

  }
}
