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

    [HttpGet("{addressId:int}")]
    public async Task<ActionResult<Address>> GetAddressById(int addressId)
    {
        try
        {
            var address = await _addressRepository.GetAddressById(addressId);
            if (address == null)
            {
                return NotFound($"Endereço com o ID: {addressId}, não foi encontrado(a)!");
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
                addressId = createdAddress.id_address
            }, createdAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar dados no Banco de Dados");
        }
    }

    [HttpPut("{addressId:int}")]
    public async Task<ActionResult<Address>> UpdateAddress(int addressId, [FromBody] Address address)
    {
        try
        {
            if (address == null)
            {
                return BadRequest("Alguns dados estão inválidos, verifique!!");
            }

            address.id_address = addressId;
            var updatedAddress = await _addressRepository.UpdateAddress(address);

            if(updatedAddress == null)
            {
                return NotFound($"Endereço com o ID: {addressId}, não foi encontrado(a)!");
            }

            return Ok(updatedAddress);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar os dados no Banco de Dados");
        }
    }

    [HttpDelete("{addressId:int}")]
    public async Task<ActionResult<Address>> DeleteAddress(int addressId)
    {
        try
        {
            var deletedAddress = await _addressRepository.GetAddressById(addressId);

            if (deletedAddress == null)
            {
                return NotFound($"Endereço com o ID: {addressId}, não foi encontrado(a)!");
            }

            _addressRepository.DeleteAddress(addressId);

            return Ok("Endereço, foi deletado(a) com sucesso!");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar os dados do Banco de Dados");
        }
    }

}
