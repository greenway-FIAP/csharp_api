using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/sector")]
[ApiController]
public class SectorController : ControllerBase
{
    private readonly ISectorRepository _sectorRepository;

    public SectorController(ISectorRepository sectorRepository)
    {
        this._sectorRepository = sectorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sector>>> GetSectors()
    {
        try
        {
            var sectors = await _sectorRepository.GetSectors();
            return Ok(sectors);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{sectorId:int}")]
    public async Task<ActionResult<Sector>> GetSectorById(int sectorId)
    {
        try
        {
            var sector = await _sectorRepository.GetSectorById(sectorId);

            if (sector == null)
            {
                return NotFound($"Setor com o ID: {sectorId}, não encontrado(a)!");
            }

            return Ok(sector);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Sector>> CreateSector([FromBody] Sector sector)
    {
        try
        {
            if (sector == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdSector = await _sectorRepository.AddSector(sector);
            return CreatedAtAction(nameof(GetSectorById), new 
            { 
                sectorId = createdSector.id_sector 
            }, createdSector);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{sectorId:int}")]
    public async Task<ActionResult<Sector>> UpdateSector(int sectorId, [FromBody] Sector sector)
    {
        try
        {
            if (sector == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            sector.id_sector = sectorId;
            var updatedSector = await _sectorRepository.UpdateSector(sector);

            if (updatedSector == null)
            {
                return NotFound($"Setor com o ID: {sectorId}, não encontrado(a)!");
            }

            return Ok(updatedSector);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar dados no Banco de Dados");
        }
    }

    [HttpDelete("{sectorId:int}")]
    public async Task<ActionResult<Sector>> DeleteSector(int sectorId)
    {
        try
        {
            var deletedSector = await _sectorRepository.GetSectorById(sectorId);
            if (deletedSector == null)
            {
                return NotFound($"Setor com o ID: {sectorId}, não encontrado(a)!");
            }

            _sectorRepository.DeleteSector(sectorId);
            return Ok("Setor, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar dados no Banco de Dados");
        }
    }
}
