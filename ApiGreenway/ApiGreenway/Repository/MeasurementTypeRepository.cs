using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class MeasurementTypeRepository : IMeasurementTypeRepository
{
    public Task<MeasurementType> AddMeasurementType(MeasurementType measurementType)
    {
        throw new NotImplementedException();
    }

    public void DeleteMeasurementType(int MeasurementTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<MeasurementType> GetMeasurementTypeById(int MeasurementTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MeasurementType>> GetMeasurementTypes()
    {
        throw new NotImplementedException();
    }

    public Task<MeasurementType> UpdateMeasurementType(MeasurementType measurementType)
    {
        throw new NotImplementedException();
    }
}
