using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Data
{
  public class AssignmentRepo : IAssignmentRepo
  {
    private readonly AppDbContext _context;

    public AssignmentRepo(AppDbContext context)
    {
      _context = context;
    }
    
    public Task CreateAssignment(Assignment asn)
    {
      throw new NotImplementedException();
    }

    public void DeleteAssignment(Assignment asn)
    {
      throw new NotImplementedException();
    }

    public Task<Assignment?> GetAssignmentById(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<Assignment>> GetAssignmentCommands()
    {
      throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
      throw new NotImplementedException();
    }
  }
}