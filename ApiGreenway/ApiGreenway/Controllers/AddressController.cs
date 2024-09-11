using ApiGreenway.Models;
using ApiGreenway.Repository;
using ApiGreenway.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGreenway.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository _addressRepository;

    public AddressController(IAddressRepository addressRepository)
    {
        this._addressRepository = addressRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
    {
        try
        {
            var addresses = await _addressRepository.GetAddresses();
            return Ok(addresses);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpGet("{AddressId:int}")]
    public async Task<ActionResult<Address>> GetAddressById(int AddressId)
    {
        try
        {
            var address = await _addressRepository.GetAddressById(AddressId);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao recuperar os dados do Banco de Dados");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Address>> CreateAddress([FromBody] Address address)
    {
        try
        {
            if (address == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            var createdAddress = await _addressRepository.AddAddress(address);
            return CreatedAtAction(nameof(GetAddressById), new
            {
                AddressId = createdAddress.id_address
            }, createdAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{AddressId:int}")]
    public async Task<ActionResult<Address>> UpdateAddress(int AddressId, [FromBody] Address address)
    {
        try
        {
            if (address == null)
            {
                return BadRequest("Alguns daos estão inválidos, verifique!!");
            }

            address.id_address = AddressId;
            var updatedAddress = await _addressRepository.UpdateAddress(address);
            if(updatedAddress == null)
            {
                return NotFound($"Endereço com o ID: {AddressId}, não foi encontrado!");
            }

            return Ok(updatedAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{AddressId:int}")]
    public async Task<ActionResult<Address>> DeleteAddress(int AddressId)
    {
        try
        {
            var deletedAddress = await _addressRepository.GetAddressById(AddressId);
            if (deletedAddress == null)
            {
                return NotFound($"Endereço com o ID: {AddressId}, não foi encontrado!");
            }
            _addressRepository.DeleteAddress(AddressId);

            return Ok(deletedAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }

}
