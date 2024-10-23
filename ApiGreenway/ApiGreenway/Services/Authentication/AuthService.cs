using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;
using FirebaseAdmin.Auth;

namespace ApiGreenway.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly dbContext _dbContext;

    public AuthService(HttpClient httpClient, dbContext dbContext)
    {
        _httpClient = httpClient;
        _dbContext = dbContext;
    }

    public async Task<string> LoginAsync(UserLoginDTO request)
    {
        var credentials = new
        {
            request.ds_email,
            request.ds_password,
            returnSecureToken = true,
        };
        var response = await _httpClient.PostAsJsonAsync("", credentials);

        var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

        return authFirebaseObject!.IdToken!;
    }

    public async Task<string> RegisterAsync(UserRegisterDTO request)
    {
        var userArgs = new UserRecordArgs
        {
            Email = request.ds_email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.ds_password),
        };
        var userDb = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

        await _dbContext.Users.AddAsync(UserRegisterDTO.ReferenceEquals(userDb, null) ? throw new Exception("Erro ao cadastrar usuário") : new User
        {
            ds_email = userDb.Email,
            ds_password = userDb.Uid,
        });

        return userDb.Uid;
    }
}
