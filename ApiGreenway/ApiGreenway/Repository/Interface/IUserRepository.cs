using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;

namespace ApiGreenway.Repository.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int UserId);
}
