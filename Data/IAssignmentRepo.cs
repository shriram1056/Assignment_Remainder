using AsnRemainderAPI.Models;

namespace AsnRemainderAPI.Data
{
  public interface IAssignmentRepo
  {
    Task SaveChanges();
    Task<Assignment?> GetAssignmentById(int id);
    Task<List<Assignment>> GetAssignmentCommands();
    Task CreateAssignment(Assignment asn);
    void DeleteAssignment(Assignment asn);
  }
}