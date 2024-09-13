using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/process-step")]
[ApiController]
public class ProcessStepController : ControllerBase
{
    private readonly IProcessStepRepository _processStepRepository;

    public ProcessStepController(IProcessStepRepository processStepRepository)
    {
        this._processStepRepository = processStepRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessStep>>> GetProcessSteps()
    {
        try
        {
            var processSteps = await _processStepRepository.GetProcessSteps();
            return Ok(processSteps);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{processStepId:int}")]
    public async Task<ActionResult<ProcessStep>> GetProcessStepById(int processStepId)
    {
        try
        {
            var processStep = await _processStepRepository.GetProcessStepById(processStepId);
            if (processStep == null)
            {
                return NotFound($"Etapa do Processo com o ID: {processStepId}, não foi encontrado(a)!");
            }

            return Ok(processStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProcessStep>> CreateProcessStep([FromBody] ProcessStep processStep)
    {
        try
        {
            if (processStep == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProcessStep = await _processStepRepository.AddProcessStep(processStep);
            return CreatedAtAction(nameof(GetProcessStepById), new 
            { 
                processStepId = createdProcessStep.id_process_step 
            }, createdProcessStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{processStepId:int}")]
    public async Task<ActionResult<ProcessStep>> UpdateProcessStep(int processStepId, [FromBody] ProcessStep processStep)
    {
        try
        {
            if (processStep == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            processStep.id_process_step = processStepId;
            var updatedProcessStep = await _processStepRepository.UpdateProcessStep(processStep);

            if (updatedProcessStep == null)
            {
                return NotFound($"Etapa do Processo com o ID: {processStepId}, não foi encontrado(a)!");
            }

            return Ok(updatedProcessStep);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{processStepId:int}")]
    public async Task<ActionResult<ProcessStep>> DeleteProcessStep(int processStepId)
    {
        try
        {
            var deletedProcessStep = await _processStepRepository.GetProcessStepById(processStepId);
            if (deletedProcessStep == null)
            {
                return NotFound($"Etapa do Processo com o ID: {processStepId}, não foi encontrado(a)!");
            }

            _processStepRepository.DeleteProcessStep(processStepId);
            return Ok("Etapa do Processo, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
