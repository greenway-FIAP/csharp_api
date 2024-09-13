using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/sustainable-goal")]
[ApiController]
public class SustainableGoalController : ControllerBase
{
    private readonly ISustainableGoalRepository _sustainableGoalRepository;

    public SustainableGoalController(ISustainableGoalRepository sustainableGoalRepository)
    {
        this._sustainableGoalRepository = sustainableGoalRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SustainableGoal>>> GetSustainableGoals()
    {
        try
        {
            var sustainableGoals = await _sustainableGoalRepository.GetSustainableGoals();
            return Ok(sustainableGoals);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{sustainableGoalId:int}")]
    public async Task<ActionResult<SustainableGoal>> GetSustainableGoalById(int sustainableGoalId)
    {
        try
        {
            var sustainableGoal = await _sustainableGoalRepository.GetSustainableGoalById(sustainableGoalId);

            if (sustainableGoal == null)
            {
                return NotFound($"Meta Sustentável com o ID: {sustainableGoalId}, não encontrado(a)!");
            }

            return Ok(sustainableGoal);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<SustainableGoal>> CreateSustainableGoal([FromBody] SustainableGoal sustainableGoal)
    {
        try
        {
            if (sustainableGoal == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdSustainableGoal = await _sustainableGoalRepository.AddSustainableGoal(sustainableGoal);
            return CreatedAtAction(nameof(GetSustainableGoalById), new 
            { 
                sustainableGoalId = createdSustainableGoal.id_sustainable_goal 
            }, createdSustainableGoal);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{sustainableGoalId:int}")]
    public async Task<ActionResult<SustainableGoal>> UpdateSustainableGoal(int sustainableGoalId, [FromBody] SustainableGoal sustainableGoal)
    {
        try
        {
            if (sustainableGoal == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            sustainableGoal.id_sustainable_goal = sustainableGoalId;
            var updatedSustainableGoal = await _sustainableGoalRepository.UpdateSustainableGoal(sustainableGoal);

            if (updatedSustainableGoal == null)
            {
                return NotFound($"Meta Sustentável com o ID: {sustainableGoalId}, não encontrado(a)!");
            }

            return Ok(updatedSustainableGoal);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{sustainableGoalId:int}")]
    public async Task<ActionResult<SustainableGoal>> DeleteSustainableGoal(int sustainableGoalId)
    {
        try
        {
            var deletedSustainableGoal = await _sustainableGoalRepository.GetSustainableGoalById(sustainableGoalId);

            if (deletedSustainableGoal == null)
            {
                return NotFound($"Meta Sustentável com o ID: {sustainableGoalId}, não encontrado(a)!");
            }

            _sustainableGoalRepository.DeleteSustainableGoal(sustainableGoalId);
            return Ok("Meta Sustentável, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
