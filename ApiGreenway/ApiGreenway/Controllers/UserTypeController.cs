using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/user-type")]
[ApiController]
public class UserTypeController : ControllerBase
{
    private readonly IUserTypeRepository _userTypeRepository;

    public UserTypeController(IUserTypeRepository userTypeRepository)
    {
        this._userTypeRepository = userTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserType>>> GetUserTypes()
    {
        try
        {
            var userTypes = await _userTypeRepository.GetUserTypes();
            return Ok(userTypes);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{userTypeId:int}")]
    public async Task<ActionResult<UserType>> GetUserTypeById(int userTypeId)
    {
        try
        {
            var userType = await _userTypeRepository.GetUserTypeById(userTypeId);

            if (userType == null)
            {
                return NotFound($"Tipo de Usuário com o ID: {userTypeId}, não foi encontrado(a)!");
            }

            return Ok(userType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserType>> CreateUserType([FromBody] UserType userType)
    {
        try
        {
            if (userType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdUserType = await _userTypeRepository.AddUserType(userType);
            return CreatedAtAction(nameof(GetUserTypeById), new 
            { 
                userTypeId = createdUserType.id_user_type 
            }, createdUserType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{userTypeId:int}")]
    public async Task<ActionResult<UserType>> UpdateUserType(int userTypeId, [FromBody] UserType userType)
    {
        try
        {
            if (userType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            userType.id_user_type = userTypeId;
            var updatedUserType = await _userTypeRepository.UpdateUserType(userType);

            if (userType == null)
            {
                return NotFound($"Tipo de Usuário com o ID: {userTypeId}, não foi encontrado(a)!");
            }

            return Ok(updatedUserType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{userTypeId:int}")]
    public async Task<ActionResult<UserType>> DeleteUserType(int userTypeId)
    {
        try
        {
            var deletedUserType = await _userTypeRepository.GetUserTypeById(userTypeId);

            if (deletedUserType == null)
            {
                return NotFound($"Tipo de Usuário com o ID: {userTypeId}, não foi encontrado(a)!");
            }

            _userTypeRepository.DeleteUserType(userTypeId);

            return Ok("Tipo de Usuário, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}

