using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ImprovementMeasurementRepository : IImprovementMeasurementRepository
{
    public Task<ImprovementMeasurement> AddImprovementMeasurement(ImprovementMeasurement ImprovementMeasurement)
    {
        throw new NotImplementedException();
    }

    public void DeleteImprovementMeasurement(int ImprovementMeasurementId)
    {
        throw new NotImplementedException();
    }

    public Task<ImprovementMeasurement> GetImprovementMeasurementById(int ImprovementMeasurementId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ImprovementMeasurement>> GetImprovementMeasurements()
    {
        throw new NotImplementedException();
    }

    public Task<ImprovementMeasurement> UpdateImprovementMeasurement(ImprovementMeasurement ImprovementMeasurement)
    {
        throw new NotImplementedException();
    }
}
