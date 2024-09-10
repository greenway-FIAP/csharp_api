using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class SectorRepository : ISectorRepository
{
    public Task<Sector> AddSector(Sector sector)
    {
        throw new NotImplementedException();
    }

    public void DeleteSector(int SectorId)
    {
        throw new NotImplementedException();
    }

    public Task<Sector> GetSectorById(int SectorId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Sector>> GetSectors()
    {
        throw new NotImplementedException();
    }

    public Task<Sector> UpdateSector(Sector sector)
    {
        throw new NotImplementedException();
    }
}
