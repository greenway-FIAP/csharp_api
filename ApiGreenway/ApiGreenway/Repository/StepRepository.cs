using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class StepRepository : IStepRepository
{
    public Task<Step> AddStep(Step step)
    {
        throw new NotImplementedException();
    }

    public void DeleteStep(int StepId)
    {
        throw new NotImplementedException();
    }

    public Task<Step> GetStepById(int StepId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Step>> GetSteps()
    {
        throw new NotImplementedException();
    }

    public Task<Step> UpdateStep(Step step)
    {
        throw new NotImplementedException();
    }
}
