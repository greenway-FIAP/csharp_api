using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/sustainable-improvement-actions")]
[ApiController]
public class SustainableImprovementActionsController : ControllerBase
{
    private readonly ISustainableImprovementActionsRepository _sustainableImprovementActionsRepository;

    public SustainableImprovementActionsController(ISustainableImprovementActionsRepository sustainableImprovementActionsRepository)
    {
        this._sustainableImprovementActionsRepository = sustainableImprovementActionsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SustainableImprovementActions>>> GetSustainableImprovementActions()
    {
        try
        {
            var sustainableImprovementActions = await _sustainableImprovementActionsRepository.GetSustainableImprovementActions();
            return Ok(sustainableImprovementActions);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{sustainableImprovementActionsId:int}")]
    public async Task<ActionResult<SustainableImprovementActions>> GetSustainableImprovementActionsById(int sustainableImprovementActionsId)
    {
        try
        {
            var sustainableImprovementActions = await _sustainableImprovementActionsRepository.GetSustainableImprovementActionsById(sustainableImprovementActionsId);

            if (sustainableImprovementActions == null)
            {
                return NotFound($"Ação de Melhoria Sustentável com o ID: {sustainableImprovementActionsId}, não foi encontrada!");
            }

            return Ok(sustainableImprovementActions);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<SustainableImprovementActions>> CreateSustainableImprovementActions([FromBody] SustainableImprovementActions sustainableImprovementActions)
    {
        try
        {

            if (sustainableImprovementActions == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdSustainableImprovementActions = await _sustainableImprovementActionsRepository.AddSustainableImprovementActions(sustainableImprovementActions);
            return CreatedAtAction(nameof(GetSustainableImprovementActionsById), new 
            { 
                sustainableImprovementActionsId = createdSustainableImprovementActions.id_sustainable_improvement_action 
            }, createdSustainableImprovementActions);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{sustainableImprovementActionsId:int}")]
    public async Task<ActionResult<SustainableImprovementActions>> UpdateSustainableImprovementActions(int sustainableImprovementActionsId, [FromBody] SustainableImprovementActions sustainableImprovementActions)
    {
        try
        {

            if (sustainableImprovementActions == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            sustainableImprovementActions.id_sustainable_improvement_action = sustainableImprovementActionsId;
            var updatedSustainableImprovementActions = await _sustainableImprovementActionsRepository.UpdateSustainableImprovementActions(sustainableImprovementActions);
            
            if (sustainableImprovementActions == null)
            {
                return NotFound($"Ação de Melhoria Sustentável com o ID: {sustainableImprovementActionsId}, não foi encontrada!");
            }

            return Ok(updatedSustainableImprovementActions);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{sustainableImprovementActionsId:int}")]
    public async Task<ActionResult<SustainableImprovementActions>> DeleteSustainableImprovementActions(int sustainableImprovementActionsId)
    {
        try
        {
            var deletedSustainableImprovementActions = await _sustainableImprovementActionsRepository.GetSustainableImprovementActionsById(sustainableImprovementActionsId);
            if (deletedSustainableImprovementActions == null)
            {
                return NotFound($"Ação de Melhoria Sustentável com o ID: {sustainableImprovementActionsId}, não foi encontrada!");
            }

            _sustainableImprovementActionsRepository.DeleteSustainableImprovementActions(sustainableImprovementActionsId);
            return Ok("Ação de Melhoria Sustentável, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
