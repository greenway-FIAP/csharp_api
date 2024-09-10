using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProcessBadgeRepository : IProcessBadgeRepository
{
    public Task<ProcessBadge> AddProcessBadge(ProcessBadge processBadge)
    {
        throw new NotImplementedException();
    }

    public void DeleteProcessBadge(int ProcessBadgeId)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessBadge> GetProcessBadgeById(int ProcessBadgeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProcessBadge>> GetProcessBadges()
    {
        throw new NotImplementedException();
    }

    public Task<ProcessBadge> UpdateProcessBadge(ProcessBadge processBadge)
    {
        throw new NotImplementedException();
    }
}
