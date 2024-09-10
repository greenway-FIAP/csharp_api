using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class MeasurementProcessStepRepository : IMeasurementProcessStepRepository
{
    public Task<MeasurementProcessStep> AddMeasurementProcessStep(MeasurementProcessStep MeasurementProcessStep)
    {
        throw new NotImplementedException();
    }

    public void DeleteMeasurementProcessStep(int MeasurementProcessStepId)
    {
        throw new NotImplementedException();
    }

    public Task<MeasurementProcessStep> GetMeasurementProcessStepById(int MeasurementProcessStepId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MeasurementProcessStep>> GetMeasurementProcessSteps()
    {
        throw new NotImplementedException();
    }

    public Task<MeasurementProcessStep> UpdateMeasurementProcessStep(MeasurementProcessStep MeasurementProcessStep)
    {
        throw new NotImplementedException();
    }
}
