using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ProcessResourceRepository : IProcessResourceRepository
{
    public Task<ProcessResource> AddProcessResource(ProcessResource processResource)
    {
        throw new NotImplementedException();
    }

    public void DeleteProcessResource(int ProcessResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessResource> GetProcessResourceById(int ProcessResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProcessResource>> GetProcessResources()
    {
        throw new NotImplementedException();
    }

    public Task<ProcessResource> UpdateProcessResource(ProcessResource processResource)
    {
        throw new NotImplementedException();
    }
}
