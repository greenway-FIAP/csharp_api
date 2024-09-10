using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class BadgeLevelRepository : IBadgeLevelRepository
{
    public Task<BadgeLevel> AddBadgeLevel(BadgeLevel BadgeLevel)
    {
        throw new NotImplementedException();
    }

    public void DeleteBadgeLevel(int BadgeLevelId)
    {
        throw new NotImplementedException();
    }

    public Task<BadgeLevel> GetBadgeLevelById(int BadgeLevelId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BadgeLevel>> GetBadgeLevels()
    {
        throw new NotImplementedException();
    }

    public Task<BadgeLevel> UpdateBadgeLevel(BadgeLevel BadgeLevel)
    {
        throw new NotImplementedException();
    }
}
