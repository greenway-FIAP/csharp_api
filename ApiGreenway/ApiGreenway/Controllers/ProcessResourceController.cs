using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/process-resource")]
[ApiController]
public class ProcessResourceController : ControllerBase
{
    private readonly IProcessResourceRepository _processResourceRepository;

    public ProcessResourceController(IProcessResourceRepository processResourceRepository)
    {
        this._processResourceRepository = processResourceRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessResource>>> GetProcessResources()
    {
        try
        {
            var processResources = await _processResourceRepository.GetProcessResources();
            return Ok(processResources);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{processResourceId:int}")]
    public async Task<ActionResult<ProcessResource>> GetProcessResourceById(int processResourceId)
    {
        try
        {
            var processResource = await _processResourceRepository.GetProcessResourceById(processResourceId);
            if (processResource == null)
            {
                return NotFound($"Processo do Recurso com o Id = {processResourceId} não foi encontrado(a)!");
            }

            return Ok(processResource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProcessResource>> CreateProcessResource([FromBody] ProcessResource processResource)
    {
        try
        {
            if (processResource == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProcessResource = await _processResourceRepository.AddProcessResource(processResource);
            return CreatedAtAction(nameof(GetProcessResourceById), new 
            { 
                processResourceId = createdProcessResource.id_process_resource 
            }, createdProcessResource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{processResourceId:int}")]
    public async Task<ActionResult<ProcessResource>> UpdateProcessResource(int processResourceId, [FromBody] ProcessResource processResource)
    {
        try
        {
            if (processResource == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            processResource.id_process_resource = processResourceId;
            var updatedProcessResource = await _processResourceRepository.UpdateProcessResource(processResource);

            if (updatedProcessResource == null)
            {
                return NotFound($"Processo do Recurso com o Id = {processResourceId} não foi encontrado(a)!");
            }

            return Ok(updatedProcessResource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{processResourceId:int}")]
    public async Task<ActionResult<ProcessResource>> DeleteProcessResource(int processResourceId)
    {
        try
        {
            var deletedProcessResource = await _processResourceRepository.GetProcessResourceById(processResourceId);
            
            if (deletedProcessResource == null)
            {
                return NotFound($"Processo do Recurso com o Id = {processResourceId} não foi encontrado(a)!");
            }

            _processResourceRepository.DeleteProcessResource(processResourceId);
            return Ok("Processo do Recurso, foi deletado(a) com sucesso!");

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }

}
