using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiGreenway.Repository;

public class BadgeLevelRepository : IBadgeLevelRepository
{
    private readonly dbContext _dbContext;

    public BadgeLevelRepository(dbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<IEnumerable<BadgeLevel>> GetBadgeLevels()
    {
        return await _dbContext.BadgeLevels.ToListAsync();
    }

    public async Task<BadgeLevel> GetBadgeLevelById(int BadgeLevelId)
    {
        return await _dbContext.BadgeLevels.FirstOrDefaultAsync(b => b.id_badge_level == BadgeLevelId);
    }

    public async Task<BadgeLevel> AddBadgeLevel(BadgeLevel badgeLevel)
    {
        var badgeLevelDb = await _dbContext.BadgeLevels.AddAsync(badgeLevel);
        await _dbContext.SaveChangesAsync();
        return badgeLevelDb.Entity;
    }

    public async Task<BadgeLevel> UpdateBadgeLevel(BadgeLevel badgeLevel)
    {
        var badgeLevelDb = await _dbContext.BadgeLevels.FirstOrDefaultAsync(b => b.id_badge_level == badgeLevel.id_badge_level);
        if (badgeLevelDb == null)
        {
            return null; // Retorna null se o Address não for encontrado
        }

        // Atualiza o nome da rua
        badgeLevelDb.ds_name = badgeLevel.ds_name;
        badgeLevelDb.tx_description = badgeLevel.tx_description;

        badgeLevel.dt_updated_at = DateTime.Now;

        await _dbContext.SaveChangesAsync();
        return badgeLevelDb;

    }
    public void DeleteBadgeLevel(int BadgeLevelId)
    {
        throw new NotImplementedException();
    }
}
