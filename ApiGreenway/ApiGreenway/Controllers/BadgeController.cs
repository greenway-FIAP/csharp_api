using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/badge")]
[ApiController]
public class BadgeController : ControllerBase
{
    private readonly IBadgeRepository _badgeRepository;

    public BadgeController(IBadgeRepository _badgeRepository)
    {
        this._badgeRepository = _badgeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Badge>>> GetBadges()
    {
        try
        {
            var badges = await _badgeRepository.GetBadges();
            return Ok(badges);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{badgeId:int}")]
    public async Task<ActionResult<Badge>> GetBadgeById(int badgeId)
    {
        try
        {
            var badge = await _badgeRepository.GetBadgeById(badgeId);
            if (badge == null)
            {
                return NotFound($"Badge com o ID: {badgeId}, não foi encontrado(a)!");
            }

            return Ok(badge);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Badge>> CreateBadge([FromBody] Badge badge)
    {
        try
        {
            if (badge == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdBadge = await _badgeRepository.AddBadge(badge);
            return CreatedAtAction(nameof(GetBadgeById), new
            {
                badgeId = createdBadge.id_badge
            }, createdBadge);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{badgeId:int}")]
    public async Task<ActionResult<Badge>> UpdateBadge(int badgeId, [FromBody] Badge badge)
    {
        try
        {
            if (badge == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            badge.id_badge = badgeId;
            var updatedBadge = await _badgeRepository.UpdateBadge(badge);

            if (updatedBadge == null)
            {
                return NotFound($"Badge com o ID: {badgeId}, não foi encontrado(a)!");
            }

            return Ok(updatedBadge);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{badgeId:int}")]
    public async Task<ActionResult<Badge>> DeleteBadge(int badgeId)
    {
        try
        {
            var deletedBadge = await _badgeRepository.GetBadgeById(badgeId);

            if (deletedBadge == null)
            {
                return NotFound($"Badge com o ID: {badgeId}, não foi encontrado(a)!");
            }

            _badgeRepository.DeleteBadge(badgeId);

            return Ok("Badge, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }
}
