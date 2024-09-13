using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/measurement")]
[ApiController]
public class MeasurementController : ControllerBase
{
    private readonly IMeasurementRepository _measurementRepository;

    public MeasurementController(IMeasurementRepository measurementRepository)
    {
        this._measurementRepository = measurementRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
    {
        try
        {
            var measurements = await _measurementRepository.GetMeasurements();
            return Ok(measurements);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{measurementId:int}")]
    public async Task<ActionResult<Measurement>> GetMeasurementById(int measurementId)
    {
        try
        {
            var measurement = await _measurementRepository.GetMeasurementById(measurementId);
            if (measurement == null)
            {
                return NotFound($"Medição com o ID: {measurementId}, não foi encontrado(a)!");
            }

            return Ok(measurement);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Measurement>> CreateMeasurement([FromBody] Measurement measurement)
    {
        try
        {
            if (measurement == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdMeasurement = await _measurementRepository.AddMeasurement(measurement);
            return CreatedAtAction(nameof(GetMeasurementById), new
            {
                measurementId = createdMeasurement.id_measurement
            }, createdMeasurement);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{measurementId:int}")]
    public async Task<ActionResult<Measurement>> UpdateMeasurement(int measurementId, [FromBody] Measurement measurement)
    {
        try
        {
            if (measurement == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            measurement.id_measurement = measurementId;
            var updatedMeasurement = await _measurementRepository.UpdateMeasurement(measurement);

            if (updatedMeasurement == null)
            {
                return NotFound($"Medição com o ID: {measurementId}, não foi encontrado(a)!");
            }

            return Ok(updatedMeasurement);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{measurementId:int}")]
    public async Task<ActionResult<Measurement>> DeleteMeasurement(int measurementId)
    {
        try
        {
            var deletedMeasurement = await _measurementRepository.GetMeasurementById(measurementId);

            if (deletedMeasurement == null)
            {
                return NotFound($"Medição com o ID: {measurementId}, não foi encontrado(a)!");
            }

            _measurementRepository.DeleteMeasurement(measurementId);
            return Ok("Medição, foi deletado(a) com sucesso!");

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }

}
