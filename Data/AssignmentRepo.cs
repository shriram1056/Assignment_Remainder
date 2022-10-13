using AsnRemainderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsnRemainderAPI.Data
{
  public class AssignmentRepo : IAssignmentRepo
  {
    private readonly AppDbContext _context;

    public AssignmentRepo(AppDbContext context)
    {
      _context = context;
    }

    public async Task CreateAssignment(Assignment asn)
    {
      if (asn == null)
      {
        throw new ArgumentNullException(nameof(asn));
      }
      await _context.Assignments.AddAsync(asn);
    }

    public void DeleteAssignment(Assignment asn)
    {
      if (asn == null)
      {
        throw new ArgumentNullException(nameof(asn));
      }

      _context.Assignments.Remove(asn);
    }

    public async Task<Assignment?> GetAssignmentById(int id)
    {
      return await _context.Assignments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Assignment>> GetAllAssignments()
    {
      return await _context.Assignments.ToListAsync();
    }

    public async Task SaveChanges()
    {
      await _context.SaveChangesAsync();
    }
  }
}