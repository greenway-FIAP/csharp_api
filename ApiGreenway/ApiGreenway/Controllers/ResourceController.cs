using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/resource")]
[ApiController]
public class ResourceController : ControllerBase
{
    private readonly IResourceRepository _resourceRepository;

    public ResourceController(IResourceRepository resourceRepository)
    {
        this._resourceRepository = resourceRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
    {
        try
        {
            var resources = await _resourceRepository.GetResources();
            return Ok(resources);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{resourceId:int}")]
    public async Task<ActionResult<Resource>> GetResourceById(int resourceId)
    {
        try
        {
            var resource = await _resourceRepository.GetResourceById(resourceId);

            if (resource == null)
            {
                return NotFound($"Recurso com Id = {resourceId} não foi encontrado");
            }

            return Ok(resource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Resource>> CreateResource([FromBody] Resource resource)
    {
        try
        {
            if (resource == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdResource = await _resourceRepository.AddResource(resource);
            return CreatedAtAction(nameof(GetResourceById), new 
            { 
                resourceId = createdResource.id_resource 
            }, createdResource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{resourceId:int}")]
    public async Task<ActionResult<Resource>> UpdateResource(int resourceId, [FromBody] Resource resource)
    {
        try
        {
            if (resource == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            resource.id_resource = resourceId;
            var updatedResource = await _resourceRepository.UpdateResource(resource);

            if (updatedResource == null)
            {
                return NotFound($"Recurso com Id = {resourceId} não foi encontrado");
            }

            return Ok(updatedResource);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{resourceId:int}")]
    public async Task<ActionResult<Resource>> DeleteResource(int resourceId)
    {
        try
        {
            var deletedResource = await _resourceRepository.GetResourceById(resourceId);
            if (deletedResource == null)
            {
                return NotFound($"Recurso com Id = {resourceId} não foi encontrado");
            }

            _resourceRepository.DeleteResource(resourceId);
            return Ok("Recurso, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
