using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/company-representative")]
[ApiController]
public class CompanyRepresentativeController : ControllerBase
{
    private readonly ICompanyRepresentativeRepository _companyRepresentativeRepository;

    public CompanyRepresentativeController(ICompanyRepresentativeRepository companyRepresentativeRepository)
    {
        this._companyRepresentativeRepository = companyRepresentativeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyRepresentative>>> GetCompanyRepresentatives()
    {
        try
        {
            var companyRepresentatives = await _companyRepresentativeRepository.GetCompanyRepresentatives();
            return Ok(companyRepresentatives);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{companyRepresentativeId:int}")]
    public async Task<ActionResult<CompanyRepresentative>> GetCompanyRepresentativeById(int companyRepresentativeId)
    {
        try
        {
            var companyRepresentative = await _companyRepresentativeRepository.GetCompanyRepresentativeById(companyRepresentativeId);
            if (companyRepresentative == null)
            {
                return NotFound($"Representante da Empresa com o ID: {companyRepresentativeId}, não foi encontrado(a)!");
            }

            return Ok(companyRepresentative);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<CompanyRepresentative>> CreateCompanyRepresentative([FromBody] CompanyRepresentative companyRepresentative)
    {
        try
        {
            if (companyRepresentative == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdCompanyRepresentative = await _companyRepresentativeRepository.AddCompanyRepresentative(companyRepresentative);
            return CreatedAtAction(nameof(GetCompanyRepresentativeById), new 
            { 
                companyRepresentativeId = createdCompanyRepresentative.id_company_representative 
            }, createdCompanyRepresentative);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao salvar os dados no Banco de Dados");
        }
    }

    [HttpPut("{companyRepresentativeId:int}")]
    public async Task<ActionResult<CompanyRepresentative>> UpdateCompanyRepresentative(int companyRepresentativeId, [FromBody] CompanyRepresentative companyRepresentative)
    {
        try
        {
            if (companyRepresentative == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            companyRepresentative.id_company_representative = companyRepresentativeId;
            var updateCompanyRepresentative = await _companyRepresentativeRepository.UpdateCompanyRepresentative(companyRepresentative);

            if (updateCompanyRepresentative == null)
            {
                return NotFound($"Representante da Empresa com o ID: {companyRepresentativeId}, não foi encontrado(a)!");
            }

            return Ok(updateCompanyRepresentative);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{companyRepresentativeId:int}")]
    public async Task<ActionResult<CompanyRepresentative>> DeleteCompanyRepresentative(int companyRepresentativeId)
    {
        try
        {
            var companyRepresentativeToDelete = await _companyRepresentativeRepository.GetCompanyRepresentativeById(companyRepresentativeId);
            if (companyRepresentativeToDelete == null)
            {
                return NotFound($"Representante da Empresa com o ID: {companyRepresentativeId}, não foi encontrado(a)!");
            }
            _companyRepresentativeRepository.DeleteCompanyRepresentative(companyRepresentativeId);
            return Ok("Representante da Empresa, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados no Banco de Dados");
        }
    }
}
