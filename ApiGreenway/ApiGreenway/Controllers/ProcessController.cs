using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/process")]
[ApiController]
public class ProcessController : ControllerBase
{
    private readonly IProcessRepository _processRepository;

    public ProcessController(IProcessRepository processRepository)
    {
        this._processRepository = processRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Process>>> GetProcesses()
    {
        try
        {
            var processes = await _processRepository.GetProcesses();
            return Ok(processes);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{processId:int}")]
    public async Task<ActionResult<Process>> GetProcessById(int processId)
    {
        try
        {
            var process = await _processRepository.GetProcessById(processId);
            if (process == null)
            {
                return NotFound($"Processo com o ID: {processId}, não foi encontrado(a)!");
            }

            return Ok(process);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Process>> CreateProcess([FromBody] Process process)
    {
        try
        {
            if (process == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdProcess = await _processRepository.AddProcess(process);
            return CreatedAtAction(nameof(GetProcessById), new 
            { 
                processId = createdProcess.id_process 
            }, createdProcess);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{processId:int}")]
    public async Task<ActionResult<Process>> UpdateProcess(int processId, [FromBody] Process process)
    {
        try
        {
            if (process == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            process.id_process = processId;
            var updatedProcess = await _processRepository.UpdateProcess(process);

            if (updatedProcess == null)
            {
                return NotFound($"Processo com o ID: {processId}, não foi encontrado(a)!");
            }

            return Ok(updatedProcess);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados do Banco de Dados");
        }
    }

    [HttpDelete("{processId:int}")]
    public async Task<ActionResult<Process>> DeleteProcess(int processId)
    {
        try
        {
            var deletedProcess = await _processRepository.GetProcessById(processId);

            if (deletedProcess == null)
            {
                return NotFound($"Processo com o ID: {processId}, não foi encontrado(a)!");
            }

            _processRepository.DeleteProcess(processId);

            return Ok("Processo, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }
}
