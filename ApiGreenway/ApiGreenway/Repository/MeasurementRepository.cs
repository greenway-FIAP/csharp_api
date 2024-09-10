using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class MeasurementRepository : IMeasurementRepository
{
    public Task<Measurement> AddMeasurement(Measurement Measurement)
    {
        throw new NotImplementedException();
    }

    public void DeleteMeasurement(int MeasurementId)
    {
        throw new NotImplementedException();
    }

    public Task<Measurement> GetMeasurementById(int MeasurementId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Measurement>> GetMeasurements()
    {
        throw new NotImplementedException();
    }

    public Task<Measurement> UpdateMeasurement(Measurement Measurement)
    {
        throw new NotImplementedException();
    }
}
