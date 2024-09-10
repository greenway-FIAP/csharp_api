using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProcessStepRepository : IProcessStepRepository
{
    public Task<ProcessStep> AddProcessStep(ProcessStep processStep)
    {
        throw new NotImplementedException();
    }

    public void DeleteProcessStep(int ProcessStepId)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessStep> GetProcessStepById(int ProcessStepId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProcessStep>> GetProcessSteps()
    {
        throw new NotImplementedException();
    }

    public Task<ProcessStep> UpdateProcessStep(ProcessStep processStep)
    {
        throw new NotImplementedException();
    }
}
