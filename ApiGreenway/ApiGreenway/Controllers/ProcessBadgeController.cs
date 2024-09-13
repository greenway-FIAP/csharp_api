using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/process-badge")]
[ApiController]
public class ProcessBadgeController : ControllerBase
{
    private readonly IProcessBadgeRepository _processBadgeRepository;

    public ProcessBadgeController(IProcessBadgeRepository processBadgeRepository)
    {
        this._processBadgeRepository = processBadgeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessBadge>>> GetProcessBadges()
    {
        try
        {
            var processBadges = await _processBadgeRepository.GetProcessBadges();
            return Ok(processBadges);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{processBadgeId:int}")]
    public async Task<ActionResult<ProcessBadge>> GetProcessBadgeById(int processBadgeId)
    {
        try
        {
            var processBadge = await _processBadgeRepository.GetProcessBadgeById(processBadgeId);
            if (processBadge == null)
            {
                return NotFound($"Processo da Badge com o ID: {processBadgeId}, não foi encontrado(a)!");
            }

            return Ok(processBadge);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProcessBadge>> CreateProcessBadge([FromBody] ProcessBadge processBadge)
    {
        try
        {
            if (processBadge == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProcessBadge = await _processBadgeRepository.AddProcessBadge(processBadge);
            return CreatedAtAction(nameof(GetProcessBadgeById), new 
            { 
                processBadgeId = createdProcessBadge.id_process_badge 
            }, createdProcessBadge);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{processBadgeId:int}")]
    public async Task<ActionResult<ProcessBadge>> UpdateProcessBadge(int processBadgeId, [FromBody] ProcessBadge processBadge)
    {
        try
        {
            if (processBadge == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            processBadge.id_process_badge = processBadgeId;
            var updatedProcessBadge = await _processBadgeRepository.UpdateProcessBadge(processBadge);

            if(updatedProcessBadge == null)
            {
                return NotFound($"Processo da Badge com o ID: {processBadgeId}, não foi encontrado(a)!");
            }

            return Ok(updatedProcessBadge);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{processBadgeId:int}")]
    public async Task<ActionResult<ProcessBadge>> DeleteProcessBadge(int processBadgeId)
    {
        try
        {
            var deletedProcessBadge = await _processBadgeRepository.GetProcessBadgeById(processBadgeId);

            if (deletedProcessBadge == null)
            {
                return NotFound($"Processo da Badge com o ID: {processBadgeId}, não foi encontrado(a)!");
            }

            _processBadgeRepository.DeleteProcessBadge(processBadgeId);
            return Ok("Processo da Badge, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }
}
