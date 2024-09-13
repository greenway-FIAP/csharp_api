
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using ResourceType = ApiGreenway.Models.ResourceType;

namespace ApiGreenway.Controllers;

[Route("api/resource-type")]
[ApiController]
public class ResourceTypeController : ControllerBase
{
    private readonly IResourceTypeRepository _resourceTypeRepository;

    public ResourceTypeController(IResourceTypeRepository resourceTypeRepository)
    {
        this._resourceTypeRepository = resourceTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResourceType>>> GetResourceTypes()
    {
        try
        {
            var resourceTypes = await _resourceTypeRepository.GetResourceTypes();
            return Ok(resourceTypes);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{resourceTypeId:int}")]
    public async Task<ActionResult<ResourceType>> GetResourceTypeById(int resourceTypeId)
    {
        try
        {
            var resourceType = await _resourceTypeRepository.GetResourceTypeById(resourceTypeId);

            if (resourceType == null)
            {
                return NotFound($"Tipo de Recurso com o ID: {resourceTypeId}, não foi encontrado(a)!");
            }


            return Ok(resourceType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ResourceType>> CreateResourceType([FromBody] ResourceType resourceType)
    {
        try
        {
            if (resourceType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdResourceType = await _resourceTypeRepository.AddResourceType(resourceType);
            return CreatedAtAction(nameof(GetResourceTypeById), new 
            { 
                resourceTypeId = createdResourceType.id_resource_type 
            }, createdResourceType);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{resourceTypeId:int}")]
    public async Task<ActionResult<ResourceType>> UpdateResourceType(int resourceTypeId, [FromBody] ResourceType resourceType)
    {
        try
        {

            if (resourceType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            resourceType.id_resource_type = resourceTypeId;
            var updatedResourceType = await _resourceTypeRepository.UpdateResourceType(resourceType);

            if (updatedResourceType == null)
            {
                return NotFound($"Tipo de Recurso com o ID: {resourceTypeId}, não foi encontrado(a)!");
            }

            return Ok(updatedResourceType);


        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{resourceTypeId:int}")]
    public async Task<ActionResult<ResourceType>> DeleteResourceType(int resourceTypeId)
    {
        try
        {
            var deletedResourceType = await _resourceTypeRepository.GetResourceTypeById(resourceTypeId);
            if (deletedResourceType == null)
            {
                return NotFound($"Tipo de Recurso com o ID: {resourceTypeId}, não foi encontrado(a)!");
            }

            _resourceTypeRepository.DeleteResourceType(resourceTypeId);
            return Ok("Tipo de Recurso, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
