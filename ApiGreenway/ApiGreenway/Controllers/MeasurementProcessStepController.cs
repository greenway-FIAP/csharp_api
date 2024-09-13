using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/measurement-process-step")]
[ApiController]
public class MeasurementProcessStepController : ControllerBase
{
    private readonly IMeasurementProcessStepRepository _measurementProcessStepRepository;

    public MeasurementProcessStepController(IMeasurementProcessStepRepository measurementProcessStepRepository)
    {
        this._measurementProcessStepRepository = measurementProcessStepRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeasurementProcessStep>>> GetMeasurementProcessSteps()
    {
        try
        {
            var measurementProcessSteps = await _measurementProcessStepRepository.GetMeasurementProcessSteps();
            return Ok(measurementProcessSteps);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{measurementProcessStepId:int}")]
    public async Task<ActionResult<MeasurementProcessStep>> GetMeasurementProcessStepById(int measurementProcessStepId)
    {
        try
        {
            var measurementProcessStep = await _measurementProcessStepRepository.GetMeasurementProcessStepById(measurementProcessStepId);
            if (measurementProcessStep == null)
            {
                return NotFound($"Medição de Processo com o ID: {measurementProcessStepId}, não foi encontrado(a)!");
            }

            return Ok(measurementProcessStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<MeasurementProcessStep>> CreateMeasurementProcessStep([FromBody] MeasurementProcessStep measurementProcessStep)
    {
        try
        {
            if (measurementProcessStep == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdMeasurementProcessStep = await _measurementProcessStepRepository.AddMeasurementProcessStep(measurementProcessStep);
            return CreatedAtAction(nameof(GetMeasurementProcessStepById), new 
            { 
                measurementProcessStepId = createdMeasurementProcessStep.id_measurement_process_step 
            }, createdMeasurementProcessStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao salvar os dados no Banco de Dados");
        }
    }

    [HttpPut("{measurementProcessStepId:int}")]
    public async Task<ActionResult<Address>> UpdateAddress(int measurementProcessStepId, [FromBody] MeasurementProcessStep measurementProcessStep)
    {
        try
        {
            if (measurementProcessStep == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            measurementProcessStep.id_measurement_process_step = measurementProcessStepId;
            var updatedMeasurementProcessStep = await _measurementProcessStepRepository.UpdateMeasurementProcessStep(measurementProcessStep);

            if (updatedMeasurementProcessStep == null)
            {
                return NotFound($"Medição de Processo com o ID: {measurementProcessStepId}, não foi encontrado(a)!");
            }

            return Ok(updatedMeasurementProcessStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{measurementProcessStepId:int}")]
    public async Task<ActionResult<MeasurementProcessStep>> DeleteMeasurementProcessStep(int measurementProcessStepId)
    {
        try
        {
            var deletedMeasurementProcessStep = await _measurementProcessStepRepository.GetMeasurementProcessStepById(measurementProcessStepId);

            if (deletedMeasurementProcessStep == null)
            {
                return NotFound($"Medição de Processo com o ID: {measurementProcessStepId}, não foi encontrado(a)!");
            }

            _measurementProcessStepRepository.DeleteMeasurementProcessStep(measurementProcessStepId);

            return Ok("Medição de Processos, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados no Banco de Dados");
        }
    }
}
