using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/measurement-type")]
[ApiController]
public class MeasurementTypeController : ControllerBase
{
    private readonly IMeasurementTypeRepository _measurementTypeRepository;

    public MeasurementTypeController(IMeasurementTypeRepository measurementTypeRepository)
    {
        this._measurementTypeRepository = measurementTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeasurementType>>> GetMeasurementTypes()
    {
        try
        {
            var measurementTypes = await _measurementTypeRepository.GetMeasurementTypes();
            return Ok(measurementTypes);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{measurementTypeId:int}")]
    public async Task<ActionResult<MeasurementType>> GetMeasurementTypeById(int measurementTypeId)
    {
        try
        {
            var measurementType = await _measurementTypeRepository.GetMeasurementTypeById(measurementTypeId);

            if (measurementType == null)
            {
                return NotFound($"Tipo de Medição com o ID: {measurementTypeId}, não foi encontrado(a)!");
            }

            return Ok(measurementType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<MeasurementType>> CreateMeasurementType([FromBody] MeasurementType measurementType)
    {
        try
        {
            if (measurementType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdMeasurementType = await _measurementTypeRepository.AddMeasurementType(measurementType);
            return CreatedAtAction(nameof(GetMeasurementTypeById), new 
            { 
                measurementTypeId = createdMeasurementType.id_measurement_type 
            }, createdMeasurementType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{measurementTypeId:int}")]
    public async Task<ActionResult<MeasurementType>> UpdateMeasurementType(int measurementTypeId, [FromBody] MeasurementType measurementType)
    {
        try
        {
            if (measurementType == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            measurementType.id_measurement_type = measurementTypeId;
            var updatedMeasurementType = await _measurementTypeRepository.UpdateMeasurementType(measurementType);

            if (updatedMeasurementType == null)
            {
                return NotFound($"Tipo de Medição com o ID: {measurementTypeId}, não foi encontrado(a)!");
            }

            return Ok(updatedMeasurementType);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{measurementTypeId:int}")]
    public async Task<ActionResult<MeasurementType>> DeleteMeasurementType(int measurementTypeId)
    {
        try
        {
            var deletedMeasurementType = await _measurementTypeRepository.GetMeasurementTypeById(measurementTypeId);

            if (deletedMeasurementType == null)
            {
                return NotFound($"Tipo de Medição com o ID: {measurementTypeId}, não foi encontrado(a)!");
            }

            _measurementTypeRepository.DeleteMeasurementType(measurementTypeId);
            return Ok("Tipo de Medição, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
