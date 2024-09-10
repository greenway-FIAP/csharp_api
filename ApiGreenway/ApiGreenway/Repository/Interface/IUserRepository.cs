using ApiGreenway.Models;

namespace ApiGreenway.Repository.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int UserId);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    void DeleteUser(int UserId);
}
