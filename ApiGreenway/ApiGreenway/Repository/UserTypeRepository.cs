using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class UserTypeRepository : IUserTypeRepository
{
    public Task<UserType> AddUserType(UserType userType)
    {
        throw new NotImplementedException();
    }

    public void DeleteUserType(int UserTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<UserType> GetUserTypeById(int UserTypeId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserType>> GetUserTypes()
    {
        throw new NotImplementedException();
    }

    public Task<UserType> UpdateUserType(UserType userType)
    {
        throw new NotImplementedException();
    }
}
