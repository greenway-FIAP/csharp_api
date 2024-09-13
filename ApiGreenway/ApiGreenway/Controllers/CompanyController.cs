using ApiGreenway.Models;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiGreenway.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        this._companyRepository = companyRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        try
        {
            var companies = await _companyRepository.GetCompanies();
            return Ok(companies);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{companyId:int}")]
    public async Task<ActionResult<Company>> GetCompanyById(int companyId)
    {
        try
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            if (company == null)
            {
                return NotFound($"Empresa com o Id: {companyId}, não foi encontrado(a)");
            }

            return Ok(company);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Company>> CreateCompany([FromBody] Company company)
    {
        try
        {
            if (company == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdCompany = await _companyRepository.AddCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new 
            { 
                companyId = createdCompany.id_company 
            }, createdCompany);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao salvar os dados no Banco de Dados");
        }
    }

    [HttpPut("{companyId:int}")]
    public async Task<ActionResult<Company>> UpdateCompany(int companyId, [FromBody] Company company)
    {
        try
        {
            if (company == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            company.id_company = companyId;

            var updatedCompany = await _companyRepository.UpdateCompany(company);

            if (updatedCompany == null)
            {
                return NotFound($"Empresa com o Id: {companyId}, não foi encontrado(a)");
            }

            return Ok(updatedCompany);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{companyId:int}")]
    public async Task<ActionResult<Company>> DeleteCompany(int companyId)
    {
        try
        {
            var deletedCompany = await _companyRepository.GetCompanyById(companyId);

            if (deletedCompany == null)
            {
                return NotFound($"Empresa com o Id: {companyId}, não foi encontrado(a)");
            }

            _companyRepository.DeleteCompany(companyId);
            return Ok("Empresa, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados no Banco de Dados");
        }
    }
}
