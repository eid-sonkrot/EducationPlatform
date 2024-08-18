using Domain.Models;

namespace Doamin.IRepository
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        Task<Assignment> GetAssignmentByNameAsync(string assignmentName);
    }
}
