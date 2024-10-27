using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;

namespace ApiGreenway.Services.Authentication;

public interface IAuthService
{
    Task<string> RegisterAsync(UserRegisterDTO request);
    Task<string> LoginAsync(UserLoginDTO request);

    Task<string> UpdateUserByEmailAsync(string oldEmail, UserUpdateDto request);

    Task<string> DeleteAsync(int userId);
}
