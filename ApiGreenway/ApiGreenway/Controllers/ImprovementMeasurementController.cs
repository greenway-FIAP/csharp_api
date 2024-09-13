using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/improvement-measurement")]
[ApiController]
public class ImprovementMeasurementController : ControllerBase
{
    private readonly IImprovementMeasurementRepository _improvementMeasurementRepository;

    public ImprovementMeasurementController(IImprovementMeasurementRepository improvementMeasurementRepository)
    {
        this._improvementMeasurementRepository = improvementMeasurementRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ImprovementMeasurement>>> GetImprovementMeasurements()
    {
        try
        {
            var improvementMeasurements = await _improvementMeasurementRepository.GetImprovementMeasurements();
            return Ok(improvementMeasurements);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{improvementMeasurementId:int}")]
    public async Task<ActionResult<ImprovementMeasurement>> GetImprovementMeasurementById(int improvementMeasurementId)
    {
        try
        {
            var improvementMeasurement = await _improvementMeasurementRepository.GetImprovementMeasurementById(improvementMeasurementId);
            if (improvementMeasurement == null)
            {
                return NotFound($"Medição de Melhoria com o ID: {improvementMeasurementId}, não foi encontrado(a)!");
            }

            return Ok(improvementMeasurement);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ImprovementMeasurement>> CreateImprovementMeasurement([FromBody] ImprovementMeasurement improvementMeasurement)
    {
        try
        {
            if (improvementMeasurement == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdImprovementMeasurement = await _improvementMeasurementRepository.AddImprovementMeasurement(improvementMeasurement);
            return CreatedAtAction(nameof(GetImprovementMeasurementById), new
            {
                improvementMeasurementId = createdImprovementMeasurement.id_improvement_measurement
            }, createdImprovementMeasurement);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{improvementMeasurementId:int}")]
    public async Task<ActionResult<ImprovementMeasurement>> UpdateImprovementMeasurement(int improvementMeasurementId, [FromBody] ImprovementMeasurement improvementMeasurement)
    {
        try
        {
            if (improvementMeasurement == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            improvementMeasurement.id_improvement_measurement = improvementMeasurementId;
            var updatedImprovementMeasurement = await _improvementMeasurementRepository.UpdateImprovementMeasurement(improvementMeasurement);

            if (updatedImprovementMeasurement == null)
            {
                return NotFound($"Medição de Melhoria com o ID: {improvementMeasurementId}, não foi encontrado(a)!");
            }

            return Ok(updatedImprovementMeasurement);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{improvementMeasurementId:int}")]
    public async Task<ActionResult<Address>> DeleteAddress(int improvementMeasurementId)
    {
        try
        {
            var deletedAddress = await _improvementMeasurementRepository.GetImprovementMeasurementById(improvementMeasurementId);
            if (deletedAddress == null)
            {
                return NotFound($"Medição de Melhoria com o ID: {improvementMeasurementId}, não foi encontrado(a)!");
            }
            _improvementMeasurementRepository.DeleteImprovementMeasurement(improvementMeasurementId);

            return Ok("Medição de Melhoria, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }
}