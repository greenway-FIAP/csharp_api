using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class BadgeRepository : IBadgeRepository
{
    public Task<Badge> AddBadge(Badge Badge)
    {
        throw new NotImplementedException();
    }

    public void DeleteBadge(int BadgeId)
    {
        throw new NotImplementedException();
    }

    public Task<Badge> GetBadgeById(int BadgeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Badge>> GetBadges()
    {
        throw new NotImplementedException();
    }

    public Task<Badge> UpdateBadge(Badge Badge)
    {
        throw new NotImplementedException();
    }
}
