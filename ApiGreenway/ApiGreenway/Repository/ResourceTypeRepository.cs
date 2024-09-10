using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class ResourceTypeRepository : IResourceTypeRepository
{
    public Task<ResourceType> AddResourceType(ResourceType resourceType)
    {
        throw new NotImplementedException();
    }

    public void DeleteResourceType(int ResourceTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<ResourceType> GetResourceTypeById(int ResourceTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ResourceType>> GetResourceTypes()
    {
        throw new NotImplementedException();
    }

    public Task<ResourceType> UpdateResourceType(ResourceType resourceType)
    {
        throw new NotImplementedException();
    }
}
