using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ApiGreenway.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UserController(IUserRepository userRepository, IConfiguration _configuration)
    {
        this._userRepository = userRepository;
        this._configuration = _configuration;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        try
        {
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetUserById(int userId)
    {
        try
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> AddUser(User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new
            {
                userId = createdUser.id_user
            }, createdUser);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(User user)
    {
        if (user == null || string.IsNullOrEmpty(user.ds_email) || string.IsNullOrEmpty(user.ds_password))
        {
            return BadRequest("E-mail ou senha inválidos.");
        }

        // Busque o usuário pelo e-mail
        var existingUser = await _userRepository.Login(user.ds_email);
        if (existingUser == null)
        {
            return BadRequest("E-mail ou senha inválidos.");
        }

        // Verifique a senha
        if (!BCrypt.Net.BCrypt.Verify(user.ds_password, existingUser.ds_password))
        {
            return BadRequest("E-mail ou senha inválidos.");
        }

        string token = CreateToken(existingUser);

        return Ok(token);
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.ds_email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("Jwt:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    [HttpPut("{userId:int}")]
    public async Task<ActionResult<User>> UpdateUser(int userId, [FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            user.id_user = userId;
            var updatedUser = await _userRepository.UpdateUser(user);
            if (updatedUser == null)
            {
                return NotFound($"Usuário com o ID: {userId}, não foi encontrado!");
            }

            return Ok("Usuário Atualizado com Sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult<User>> DeleteUser(int userId)
    {
        try
        {
            var deletedUser = await _userRepository.GetUserById(userId);
            if (deletedUser == null)
            {
                return NotFound($"Endereço com o ID: {userId}, não foi encontrado!");
            }
            _userRepository.DeleteUser(userId);

            return Ok("Usuário foi Deletado com Sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }
}
