using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;
using ApiGreenway.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiGreenway.Repository;

public class UserRepository : IUserRepository
{
    private readonly dbContext _dbContext;

    public UserRepository(dbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    // Métodos CRUD

    public async Task<IEnumerable<User>> GetUsers()
    {
        var users = await _dbContext.Users.Where(u => u.ds_uid_fb != null && u.dt_finished_at == null).ToListAsync();
        if (users == null)
        {
            throw new Exception("Não há usuários cadastrados!");
        }

        return users;
    }

    public async Task<User> GetUserById(int UserId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.id_user == UserId && u.ds_uid_fb != null && u.dt_finished_at == null);
        if (user == null)
        {
            throw new Exception("Usuário não encontrado ou excluído!");
        }

        return user;
    }
}
