using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ResourceRepository : IResourceRepository
{
    public Task<Resource> AddResource(Resource resource)
    {
        throw new NotImplementedException();
    }

    public void DeleteResource(int ResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<Resource> GetResourceById(int ResourceId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Resource>> GetResources()
    {
        throw new NotImplementedException();
    }

    public Task<Resource> UpdateResource(Resource resource)
    {
        throw new NotImplementedException();
    }
}
