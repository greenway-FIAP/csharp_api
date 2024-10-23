using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;

namespace ApiGreenway.Repository.Interface;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserById(int UserId);

    //Task<User> AddUser(User user);
    //Task<User> Login(string ds_email);

    Task<User> UpdateUser(UserUpdateDto user);
    void DeleteUser(int UserId);
}
