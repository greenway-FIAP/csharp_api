using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;

namespace ApiGreenway.Repository;

public class UserRepository : IUserRepository
{
    public Task<User> AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int UserId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}
