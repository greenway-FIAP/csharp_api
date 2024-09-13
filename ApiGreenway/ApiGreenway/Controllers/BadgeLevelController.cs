using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ApiGreenway.Controllers;

[Route("api/badge-level")]
[ApiController]
public class BadgeLevelController : ControllerBase
{
    private readonly IBadgeLevelRepository _badgeLevelRepository;

    public BadgeLevelController(IBadgeLevelRepository badgeLevelRepository)
    {
        this._badgeLevelRepository = badgeLevelRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BadgeLevel>>> GetBadgeLevels()
    {
        try
        {
            var badgeLevels = await _badgeLevelRepository.GetBadgeLevels();
            return Ok(badgeLevels);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{badgeLevelId:int}")]
    public async Task<ActionResult<BadgeLevel>> GetBadgeLevelById(int badgeLevelId)
    {
        try
        {
            var badgeLevel = await _badgeLevelRepository.GetBadgeLevelById(badgeLevelId);
            if (badgeLevel == null)
            {
                return NotFound($"Nivel da Badge com o ID: {badgeLevelId}, não foi encontrada");
            }

            return Ok(badgeLevel);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<BadgeLevel>> CreateBadgeLevel([FromBody] BadgeLevel badgeLevel)
    {
        try
        {
            if (badgeLevel == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdBadgeLevel = await _badgeLevelRepository.AddBadgeLevel(badgeLevel);
            return CreatedAtAction(nameof(GetBadgeLevelById), new
            {
                badgeLevelId = createdBadgeLevel.id_badge_level
            }, createdBadgeLevel);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{badgeLevelId:int}")]
    public async Task<ActionResult<BadgeLevel>> UpdateBadgeLevel(int badgeLevelId, [FromBody] BadgeLevel badgeLevel)
    {
        try
        {
            if (badgeLevel == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            badgeLevel.id_badge_level = badgeLevelId;
            var updatedBadgeLevel = await _badgeLevelRepository.UpdateBadgeLevel(badgeLevel);
            if (updatedBadgeLevel == null)
            {
                return NotFound($"Nivel da Badge com o ID: {badgeLevelId}, não foi encontrada");
            }

            return Ok(updatedBadgeLevel);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{badgeLevelId:int}")]
    public async Task<ActionResult<BadgeLevel>> DeleteBadgeLevel(int badgeLevelId)
    {
        try
        {
            var deletedBadgeLevel = await _badgeLevelRepository.GetBadgeLevelById(badgeLevelId);
            if (deletedBadgeLevel == null)
            {
                return NotFound($"Nivel da Badge com o ID: {badgeLevelId}, não foi encontrada");
            }
            _badgeLevelRepository.DeleteBadgeLevel(badgeLevelId);

            return Ok("Nivel da Badge, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }
}
