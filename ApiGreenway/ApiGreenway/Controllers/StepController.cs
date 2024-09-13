using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/step")]
[ApiController]
public class StepController : ControllerBase
{
    private readonly IStepRepository _stepRepository;

    public StepController(IStepRepository stepRepository)
    {
        this._stepRepository = stepRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Step>>> GetSteps()
    {
        try
        {
            var steps = await _stepRepository.GetSteps();
            return Ok(steps);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{stepId:int}")]
    public async Task<ActionResult<Step>> GetStepById(int stepId)
    {
        try
        {
            var step = await _stepRepository.GetStepById(stepId);
            if (step == null)
            {
                return NotFound($"Etapa com o ID: {stepId}, não foi encontrado(a)!");
            }

            return Ok(step);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Step>> CreateStep([FromBody] Step step)
    {
        try
        {
            if (step == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdStep = await _stepRepository.AddStep(step);
            return CreatedAtAction(nameof(GetStepById), new 
            { 
                stepId = createdStep.id_step 
            }, createdStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{stepId:int}")]
    public async Task<ActionResult<Step>> UpdateStep(int stepId, [FromBody] Step step)
    {
        try
        {
            if (step == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            step.id_step = stepId;
            var updatedStep = await _stepRepository.UpdateStep(step);

            if (updatedStep == null)
            {
                return NotFound($"Etapa com o ID: {stepId}, não foi encontrado(a)!");
            }

            return Ok(updatedStep);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{stepId:int}")]
    public async Task<ActionResult<Step>> DeleteStep(int stepId)
    {
        try
        {

            var deletedStep = await _stepRepository.GetStepById(stepId);

            if (deletedStep == null)
            {
                return NotFound($"Etapa com o ID: {stepId}, não foi encontrado(a)!");
            }

            _stepRepository.DeleteStep(stepId);

            return Ok("Etapa, foi deletado(a) com sucesso!");

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
